using cc105_pose_proj.Forms.Interfaces;
using cc105_pose_proj.Presenters;
using cc105_pose_proj.Services.Interfaces;
using System.ComponentModel;
using System.Data;
using static cc105_pose_proj.Services.PricingService;

namespace cc105_pose_proj.Forms
{
    public partial class BuyerForm : Form, IBuyerForm
    {
        private readonly BuyerFormPresenter _presenter;
        private readonly DataTable _itemsTable = new();
        public BuyerForm(ITransactionStateService transactionStateService)
        {
            InitializeComponent();
            SetupGridColumns();

            _presenter = new BuyerFormPresenter(this, transactionStateService);
        }

        private void SetupGridColumns()
        {
            _itemsTable.Columns.Add("Name", typeof(string));
            _itemsTable.Columns.Add("Price", typeof(decimal));
            _itemsTable.Columns.Add("Qty", typeof(int));
            _itemsTable.Columns.Add("Discount", typeof(string));
            _itemsTable.Columns.Add("Total", typeof(decimal));

            transactionGrid.DataSource = _itemsTable;
            transactionGrid.Columns["Price"]!.DefaultCellStyle.Format = "C2";
            transactionGrid.Columns["Total"]!.DefaultCellStyle.Format = "C2";
            transactionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            transactionGrid.Columns["Name"]!.FillWeight = 42f;
            transactionGrid.Columns["Price"]!.FillWeight = 16f;
            transactionGrid.Columns["Qty"]!.FillWeight = 8f;
            transactionGrid.Columns["Discount"]!.FillWeight = 18f;
            transactionGrid.Columns["Total"]!.FillWeight = 16f;
        }

        public void ShowIdle()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowIdle));
                return;
            }

            _itemsTable.Rows.Clear();
            transactionPanel.Visible = false;
        }

        public void ShowTransactionItems(List<LineItem> lineItems)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowTransactionItems(lineItems)));
                return;
            }

            transactionPanel.Visible = true;

            _itemsTable.Rows.Clear();
            foreach (var line in lineItems)
            {
                DataRow row = _itemsTable.NewRow();
                row["Name"] = line.Product.Name;
                row["Price"] = line.Price;
                row["Qty"] = line.Quantity;
                row["Discount"] = line.AppliedDiscount != null ? line.AppliedDiscount.Name : "N/A";
                row["Total"] = line.LineTotal;
                _itemsTable.Rows.Add(row);
            }
        }

        private void BuyerForm_Resize(object sender, EventArgs e)
        {
            int adPanelPadding = adPanel.Margin.Left + adPanel.Margin.Right;

            adPanel.Width = (this.Width / 2) - adPanelPadding;
            adPanel.Top = adPanel.Margin.Top;
            adPanel.Left = adPanel.Margin.Left;
            adPanel.Height = this.Height - (adPanel.Margin.Top + adPanel.Margin.Bottom);

            int transactionPanelPadding = transactionPanel.Margin.Right + transactionPanel.Margin.Left;

            transactionPanel.Width = (this.Width / 2) - transactionPanelPadding;
            transactionPanel.Top = transactionPanel.Margin.Top;
            transactionPanel.Left = adPanel.Right + adPanel.Margin.Right + transactionPanel.Margin.Left;
            transactionPanel.Height = this.Height - (transactionPanel.Margin.Top + transactionPanel.Margin.Bottom);


            

            int totalsPanelTop = totalsPanel.Padding.Top;
            foreach(Panel rowPanel in totalsPanel.Controls.OfType<Panel>().OrderBy(r => r.TabIndex))
            {
                var label1 = rowPanel.Controls.OfType<Label>().FirstOrDefault();
                var label2 = rowPanel.Controls.OfType<Label>().LastOrDefault();

                if (label1 == null || label2 == null) continue;

                rowPanel.Top = totalsPanelTop;
                rowPanel.Height = Math.Max(label1.Height, label2.Height);
                rowPanel.Width = totalsPanel.Width;

                label1.Top = 0;
                label1.Left = rowPanel.Padding.Left;

                label2.Top = 0;
                label2.Left = rowPanel.Right - rowPanel.Padding.Right - label2.Width;

                totalsPanelTop += rowPanel.Height;
            }

            totalsPanel.Height = totalsPanel.Controls.OfType<Panel>().Sum(r => r.Height);
            transactionGrid.Height = transactionPanel.Height - transactionPanel.Padding.Top 
                - transactionPanel.Padding.Bottom - transactionGrid.Margin.Bottom - totalsPanel.Height;

            transactionGrid.Top = transactionPanel.Padding.Top;
            totalsPanel.Top = transactionGrid.Bottom + transactionGrid.Margin.Bottom;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SubTotal { set => subTotalLabel.Text = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SavedTotal { set => discountLabel.Text = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Total { set => totalLabel.Text = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Change { set => changeLabel.Text = value; }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            transactionGrid.DataSource = null;

            base.OnFormClosing(e);
        }
    }
}
