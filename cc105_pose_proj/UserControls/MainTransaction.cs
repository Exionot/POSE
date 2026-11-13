using cc105_pose_proj.Models;
using cc105_pose_proj.UserControls;
using cc105_pose_proj.Util;
using cc105_pose_proj.Navigation;
using System.Data;
using cc105_pose_proj.Data;

namespace cc105_pose_proj
{
    public partial class MainTransaction : UserControl
    {
        private readonly INavigator _nav;
        private readonly IRepository<Product> _productRepo = new ProductRepository();
        private readonly DataTable _items = new();
        private readonly Dictionary<String, Button> _productButtons = [];
        private readonly Dictionary<String, Product> _products = [];
        public MainTransaction(INavigator nav)
        {
            _nav = nav;
            InitializeComponent();

            _items.Columns.Add("Name", typeof(string));
            _items.Columns.Add("Price", typeof(decimal));
            _items.Columns.Add("Qty", typeof(int));
            _items.Columns.Add("Total", typeof(decimal), "Price * Qty");
            transactionGrid.DataSource = _items;
            transactionGrid.Columns["Price"]!.DefaultCellStyle.Format = "C2";
            transactionGrid.Columns["Total"]!.DefaultCellStyle.Format = "C2";
            transactionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            float namePercent = 65f;
            float otherPercent = (100 - namePercent) / 3;
            transactionGrid.Columns["Name"]!.FillWeight = namePercent;
            transactionGrid.Columns["Price"]!.FillWeight = otherPercent;
            transactionGrid.Columns["Qty"]!.FillWeight = otherPercent;
            transactionGrid.Columns["Total"]!.FillWeight = otherPercent;

            updateTotal();
        }

        private void MainTransaction_Load(object sender, EventArgs e)
        {
            List<Product> productList = _productRepo.GetAll();

            productButtonPanel.Controls.Clear();
            foreach (Product p in productList)
            {
                string name = p.Name;
                if (_products.ContainsKey(Name))
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
                btn.Click += (_, _) => addToGrid(p);
                productButtonPanel.Controls.Add(btn);

                _productButtons.Add(name, btn);
                _products.Add(name, p);
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
            actionPanel.Width = (int)(totalPanel.Width * 0.6);
        }

        private DataRow? SelectedRow() =>
            (transactionGrid.CurrentRow?.DataBoundItem as DataRowView)?.Row;

        private void addToGrid(Product p)
        {
            DataRow? row = _items.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("Name") == p.Name);

            if (row == null)
            {
                row = _items.NewRow();
                row["Name"] = p.Name;
                row["Price"] = p.Price;
                row["Qty"] = 1;
                _items.Rows.InsertAt(row, 0);
            }
            else
            {
                int newQty = (int)row["Qty"] + 1;

                int index = _items.Rows.IndexOf(row);

                DataRow newRow = _items.NewRow();
                newRow["Name"] = row["Name"];
                newRow["Price"] = row["Price"];
                newRow["Qty"] = newQty;

                _items.Rows.RemoveAt(index);
                _items.Rows.InsertAt(newRow, 0);
            }

            UpdateProductQuantity(p.Name, -1);
            updateTotal();
            focusFirstRow();
        }

        private void focusFirstRow()
        {
            transactionGrid.ClearSelection();
            if (_items.Rows.Count > 0)
            {
                transactionGrid.CurrentCell = transactionGrid.Rows[0].Cells[0];
                transactionGrid.Rows[0].Selected = true;
            }
        }

        private void removeOne(DataRow row)
        {
            int qty = (int)row["Qty"];
            UpdateProductQuantity(row.Field<string>("Name")!, 1);

            int index = _items.Rows.IndexOf(row);

            if (qty > 1) row["Qty"] = qty - 1;
            else _items.Rows.RemoveAt(index);

            updateTotal();
        }

        private void removeAll(DataRow row)
        {
            UpdateProductQuantity(row.Field<string>("Name")!, (int)row["Qty"]);
            _items.Rows.Remove(row);
            updateTotal();
        }

        private void UpdateProductQuantity(string productName, int quantityChange)
        {
            Product p = _products[productName];

            int newQty = p.Quantity + quantityChange;
            p.Quantity = newQty;

            _productButtons[productName].Enabled = newQty > 0;
        }

        private void updateTotal() =>
            totalLabel.Text = _items.AsEnumerable().Sum(r => r.Field<decimal>("Total")).ToString("C2");

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (SelectedRow() is DataRow row) removeOne(row);
        }

        private void removeAllBtn_Click(object sender, EventArgs e)
        {
            if (SelectedRow() is DataRow row) removeAll(row);
        }

        private void clearTableBtn_Click(object sender, EventArgs e)
        {
            if (_items.Rows.Count == 0) return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all items?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            foreach (DataRow row in _items.Rows)
                UpdateProductQuantity(row.Field<string>("Name")!, row.Field<int>("Qty"));
            

            _items.Rows.Clear();
            updateTotal();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (_items.Rows.Count > 0){
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
