using cc105_pose_proj.Models;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Services;
using cc105_pose_proj.UserControls;
using cc105_pose_proj.Util;
using System.Data;
using System.Windows.Forms;
using static cc105_pose_proj.Services.PricingService;

namespace cc105_pose_proj
{
    public partial class MainTransaction : UserControl
    {
        private readonly INavigator _nav;
        private readonly ProductService _productService = new();
        private readonly PricingService _pricingService = new();
        private readonly DiscountService _discountService = new(null);

        private List<Discount> _activeDiscounts = [];
        private readonly List<CartItem> _cart = [];

        private readonly DataTable _items = new();
        private readonly Dictionary<string, Button> _productButtons = [];
        private readonly Dictionary<string, Product> _products = [];

        public MainTransaction(INavigator nav)
        {
            _nav = nav;
            InitializeComponent();

            _items.Columns.Add("Name", typeof(string));
            _items.Columns.Add("Price", typeof(decimal));
            _items.Columns.Add("Qty", typeof(int));
            _items.Columns.Add("Discount", typeof(string));
            _items.Columns.Add("Total", typeof(decimal));

            transactionGrid.DataSource = _items;
            transactionGrid.Columns["Price"]!.DefaultCellStyle.Format = "C2";
            transactionGrid.Columns["Total"]!.DefaultCellStyle.Format = "C2";
            transactionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            transactionGrid.Columns["Name"]!.FillWeight = 38f;
            transactionGrid.Columns["Price"]!.FillWeight = 16f;
            transactionGrid.Columns["Qty"]!.FillWeight = 12f;
            transactionGrid.Columns["Discount"]!.FillWeight = 18f;
            transactionGrid.Columns["Total"]!.FillWeight = 16f;

            UpdateSaleSummary();
        }

        private void MainTransaction_Load(object sender, EventArgs e)
        {
            _activeDiscounts = _discountService.GetDiscounts()
                .Where(d => d.Active)
                .ToList();

            List<Product> productList = _productService.GetProducts();

            productButtonPanel.Controls.Clear();
            _productButtons.Clear();
            _products.Clear();

            foreach (Product p in productList)
            {
                string name = p.Name;
                if (_products.ContainsKey(name))
                    continue;

                Button btn = new();
                try
                {
                    Buttons.CreateProductButton(btn, p);
                }
                catch (Exception ex) when (ex is IOException or ArgumentException)
                {
                    btn.Text = name;
                }

                btn.Enabled = p.Quantity > 0;
                btn.Click += (_, _) => AddToCart(p);
                productButtonPanel.Controls.Add(btn);

                _productButtons.Add(name, btn);
                _products.Add(name, p);
            }

            UpdateSaleSummary();
        }

        private void MainTransaction_Resize(object sender, EventArgs e)
        {
            rightPanel.Width = (int)(this.Width * 0.4) + 5;
            leftPanel.Width = (int)(this.Width * 0.6);

            headerPanel.Height = (int)(this.Height * 0.1);

            int backButtonMargin = 30;
            int backButtonSize = headerPanel.Height - backButtonMargin;
            backBtn.Size = new Size(backButtonSize, backButtonSize);
            backBtn.Top = backButtonMargin;
            backBtn.Left = backButtonMargin;

            productsPanel.Width = rightPanel.Width;

            int productButtonMargin = 15;
            int productLabelAllowance = 35;
            productButtonPanel.Width = productsPanel.Width - (productButtonMargin * 2);
            productButtonPanel.Height = productsPanel.Height - (productButtonMargin * 2) - productLabelAllowance;
            productButtonPanel.Top = productButtonMargin + productLabelAllowance;
            productButtonPanel.Left = (productsPanel.Width - productButtonPanel.Width) / 2;

            transactionPanel.Height = (int)(leftPanel.Height * 0.65);

            int gridMargin = 30;
            transactionGrid.Width = transactionPanel.Width - (gridMargin * 2);
            transactionGrid.Height = (int)(transactionPanel.Height * 1) - (gridMargin * 2);
            transactionGrid.Top = transactionPanel.Height - (transactionGrid.Height + gridMargin);
            transactionGrid.Left = (transactionPanel.Width - transactionGrid.Width) / 2;

            totalPanel.Height = (int)(leftPanel.Height * 0.35) + 5;

            totalListPanel.Width = (int)(totalPanel.Width * 0.4) + 5;
            int totalListPadding = 30;
            foreach (Panel p in totalListPanel.Controls.OfType<Panel>())
            {
                var labels = p.Controls.OfType<Label>();

                p.Height = labels.FirstOrDefault()!.Height + 10;
                p.Width = totalListPanel.Width - totalListPadding;
                p.Left = totalListPadding;

                FitTotalLabel(labels);
            }

            int rowGap = 5;
            totalRowPanel.Top = totalListPanel.Bottom - totalRowPanel.Height - totalListPadding;
            savedRowPanel.Top = totalRowPanel.Top - savedRowPanel.Height - rowGap;
            subTotalRowPanel.Top = savedRowPanel.Top - subTotalRowPanel.Height - rowGap;

            actionPanel.Width = (int)(totalPanel.Width * 0.6);
        }

        private void FitTotalLabel(IEnumerable<Label> labels)
        {
            foreach (Label l in labels)
            {
                if (l.Anchor.HasFlag(AnchorStyles.Left))
                    l.Left = 0;
                else if (l.Anchor.HasFlag(AnchorStyles.Right))
                    l.Left = l.Parent!.Width - l.Width;
                l.Top = (l.Parent!.Height - l.Height) / 2;
            }
        }

        private string? GetSelectedProductName()
        {
            var view = transactionGrid.CurrentRow?.DataBoundItem as DataRowView;
            return view?.Row.Field<string>("Name");
        }

        private void AddToCart(Product p)
        {
            var existing = _cart.FirstOrDefault(c => c.Product.Id == p.Id);
            int currentQty = existing?.Quantity ?? 0;

            if (currentQty >= p.Quantity)
            {
                MessageBox.Show(
                    $"Cannot add more than {p.Quantity} units of '{p.Name}'. Stock limit reached.",
                    "Insufficient Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (existing == null)
            {
                _cart.Insert(0, new CartItem(p, 1));
            }
            else
            {
                _cart.Remove(existing);
                _cart.Insert(0, existing with { Quantity = currentQty + 1 });
            }

            UpdateSaleSummary();
            FocusFirstRow();
        }

        private void RemoveOne()
        {
            string? name = GetSelectedProductName();
            if (name == null) return;

            var existing = _cart.FirstOrDefault(c => c.Product.Name == name);
            if (existing == null) return;

            int index = _cart.IndexOf(existing);
            if (existing.Quantity > 1)
            {
                _cart[index] = existing with { Quantity = existing.Quantity - 1 };
            }
            else
            {
                _cart.RemoveAt(index);
            }

            UpdateSaleSummary();
        }

        private void RemoveAll()
        {
            string? name = GetSelectedProductName();
            if (name == null) return;

            _cart.RemoveAll(c => c.Product.Name == name);
            UpdateSaleSummary();
        }

        private void ClearCart()
        {
            if (_cart.Count == 0) return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all items?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            _cart.Clear();
            UpdateSaleSummary();
        }

        private void UpdateSaleSummary()
        {
            SaleSummary summary = _pricingService.CalculateSale(_cart, _activeDiscounts);

            _items.Rows.Clear();
            foreach (var line in summary.LineItems)
            {
                DataRow row = _items.NewRow();
                row["Name"] = line.Product.Name;
                row["Price"] = line.Price;
                row["Qty"] = line.Quantity;
                row["Discount"] = line.AppliedDiscount != null
                    ? $"{line.AppliedDiscount.Name}"
                    : "N/A";
                row["Total"] = line.LineTotal;
                _items.Rows.Add(row);
            }

            subTotalLabel.Text = summary.Subtotal.ToString("C2");
            discountLabel.Text = summary.TotalSaved > 0
                ? $"-{summary.TotalSaved:C2}"
                : "₱0.00";
            totalLabel.Text = summary.GrandTotal.ToString("C2");

            foreach (var (name, product) in _products)
            {
                int inCart = _cart.FirstOrDefault(c => c.Product.Id == product.Id)?.Quantity ?? 0;
                int remaining = product.Quantity - inCart;

                if (_productButtons.TryGetValue(name, out var btn))
                {
                    btn.Enabled = remaining > 0;
                }
            }

            foreach (Panel pn in totalListPanel.Controls.OfType<Panel>())
            {
                FitTotalLabel(pn.Controls.OfType<Label>());
            }
        }

        private void FocusFirstRow()
        {
            transactionGrid.ClearSelection();
            if (_items.Rows.Count > 0)
            {
                transactionGrid.CurrentCell = transactionGrid.Rows[0].Cells[0];
                transactionGrid.Rows[0].Selected = true;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e) => RemoveOne();
        private void removeAllBtn_Click(object sender, EventArgs e) => RemoveAll();
        private void clearTableBtn_Click(object sender, EventArgs e) => ClearCart();

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (_cart.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Cancel this transaction and go back to home?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result != DialogResult.Yes)
                    return;
            }

            _nav.NavigateTo(new Home(_nav));
        }
    }
}
