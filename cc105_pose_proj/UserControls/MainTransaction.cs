using cc105_pose_proj.Models;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Presenters;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;
using cc105_pose_proj.Util;
using Krypton.Toolkit;
using System.ComponentModel;
using System.Data;
using static cc105_pose_proj.Services.PricingService;

namespace cc105_pose_proj
{
    public partial class MainTransaction : UserControl, IMainTransactionView
    {
        public event EventHandler<Product>? ProductSelected;
        public event EventHandler? RemoveOneRequest;
        public event EventHandler? RemoveAllRequest;
        public event EventHandler? ClearCartRequest;
        public event EventHandler? BackRequest;
        public event EventHandler? CheckoutRequest;

        private readonly MainTransactionViewPresenter _presenter;
        private readonly DataTable _items = new();
        private readonly Dictionary<string, Button> _productButtons = [];

        public MainTransaction(
                INavigator nav,
                IProductService productService,
                IDiscountService discountService,
                IDialogService dialogService,
                ITransactionStateService transactionStateService)
        {
            InitializeComponent();
            SetupGridColumns();
            LayoutUtil.SetAutoFitEvents(totalListPanel);

            _presenter = new MainTransactionViewPresenter(
                this,
                nav,
                productService,
                discountService,
                dialogService,
                transactionStateService);

            removeOneBtn.Click += (_, _) => RemoveOneRequest?.Invoke(this, EventArgs.Empty);
            removeAllBtn.Click += (_, _) => RemoveAllRequest?.Invoke(this, EventArgs.Empty);
            clearTableBtn.Click += (_, _) => ClearCartRequest?.Invoke(this, EventArgs.Empty);
            backBtn.Click += (_, _) => BackRequest?.Invoke(this, EventArgs.Empty);
        }

        private void SetupGridColumns()
        {
            _items.Columns.Add("Name", typeof(string));
            _items.Columns.Add("Price", typeof(decimal));
            _items.Columns.Add("Qty", typeof(int));
            _items.Columns.Add("Discount", typeof(string));
            _items.Columns.Add("Total", typeof(decimal));

            transactionGrid.DataSource = _items;
            transactionGrid.Columns["Price"]!.DefaultCellStyle.Format = "C2";
            transactionGrid.Columns["Total"]!.DefaultCellStyle.Format = "C2";
            transactionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            transactionGrid.Columns["Name"]!.FillWeight = 42f;
            transactionGrid.Columns["Price"]!.FillWeight = 16f;
            transactionGrid.Columns["Qty"]!.FillWeight = 8f;
            transactionGrid.Columns["Discount"]!.FillWeight = 18f;
            transactionGrid.Columns["Total"]!.FillWeight = 16f;
        }

        public void SetProductButtons(List<Product> products)
        {
            productButtonPanel.Controls.Clear();
            _productButtons.Clear();

            foreach (var p in products)
            {
                if (_productButtons.ContainsKey(p.Name))
                    continue;

                Button btn;
                try
                {
                    btn = Buttons.CreateProductButton(p);
                }
                catch (Exception ex) when (ex is IOException or ArgumentException)
                {
                    btn = new Button { Text = p.Name };
                }

                btn.Enabled = p.Quantity > 0;
                btn.Click += (_, _) => ProductSelected?.Invoke(this, p);

                productButtonPanel.Controls.Add(btn);
                _productButtons.Add(p.Name, btn);
            }
        }

        public void SetCartItems(List<LineItem> lineItems)
        {
            _items.Rows.Clear();
            foreach (var line in lineItems)
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

            foreach (Panel pn in totalListPanel.Controls.OfType<Panel>())
            {
                LayoutUtil.FitTotalLabel(pn.Controls.OfType<Label>());
            }
        }

        public void SetProductAvailability(string productName, bool isAvailable)
        {
            if (_productButtons.TryGetValue(productName, out var btn))
            {
                btn.Enabled = isAvailable;
            }
        }

        public void FocusFirstRow()
        {
            transactionGrid.ClearSelection();
            if (_items.Rows.Count > 0)
            {
                transactionGrid.CurrentCell = transactionGrid.Rows[0].Cells[0];
                transactionGrid.Rows[0].Selected = true;
            }
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
            int totalPanelPadding = 30;
            foreach (Panel p in totalListPanel.Controls.OfType<Panel>())
            {
                var labels = p.Controls.OfType<Label>();
                p.Height = labels.FirstOrDefault()!.Height + 10;
                p.Width = totalListPanel.Width - totalPanelPadding;
                p.Left = totalPanelPadding;
                LayoutUtil.FitTotalLabel(labels);
            }

            int rowGap = 5;
            totalRowPanel.Top = totalListPanel.Bottom - totalRowPanel.Height - totalPanelPadding;
            savedRowPanel.Top = totalRowPanel.Top - savedRowPanel.Height - rowGap;
            subTotalRowPanel.Top = savedRowPanel.Top - subTotalRowPanel.Height - rowGap;

            actionPanel.Width = (int)(totalPanel.Width * 0.6);
            int buttonMargin = 10;
            int totalButtonMargin = buttonMargin * 4;
            foreach (KryptonButton b in flowLayoutPanel1.Controls.OfType<KryptonButton>())
            {
                b.AutoSize = false;
                b.Height = (actionPanel.Height - totalPanelPadding - totalButtonMargin) / 2;
                b.Width = (actionPanel.Width - totalPanelPadding - (totalButtonMargin * 2)) / 2;
            }
        }

        

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string Subtotal
        {
            set => subTotalLabel.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string TotalSaved
        {
            set => discountLabel.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string GrandTotal
        {
            set => totalLabel.Text = value;
        }

        public string? SelectedProductName
        {
            get
            {
                var view = transactionGrid.CurrentRow?.DataBoundItem as DataRowView;
                return view?.Row.Field<string>("Name");
            }
        }
    }
}
