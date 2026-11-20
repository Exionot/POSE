using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Services;
using cc105_pose_proj.Util;
using Krypton.Toolkit;
using Microsoft.VisualBasic.ApplicationServices;

namespace cc105_pose_proj.UserControls
{
    public partial class EditDiscount : UserControl, IDialogControl
    {
        public event EventHandler<DialogResult>? RequestClose;
        private readonly DiscountService _discountService = new();
        private readonly ProductService _productService = new();
        private readonly BusinessService _businessService = new();
        private Discount? CurrentDiscount;
        private Business? SelectedBusiness;
        private List<Product> SelectedProducts = [];
        private bool IsEditMode;
        public EditDiscount(Discount? discount = null)
        {
            CurrentDiscount = discount;
            IsEditMode = CurrentDiscount != null;
            InitializeComponent();
            ResizeControl();
        }
        private void ResizeControl()
        {
            MainForm? main = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (main == null)
                return;

            this.Size = new Size(
                (int)(main.ClientSize.Width / 3),
                (int)(main.ClientSize.Height * 0.9)
            );
        }

        private void EditDiscount_Load(object sender, EventArgs e)
        {
            var user = Session.CurrentUser;
            if (user == null) return;

            discountTypeComboBox.DataSource = DiscountTypeItem.All;
            businessComboBox.DataSource = _businessService.GetBusinesses();
            SelectedBusiness = CurrentDiscount?.CreatedBy;

            int? targetBusinessId = SelectedBusiness?.Id ?? user.Business?.Id;

            businessComboBox.SelectedIndex = -1;
            if (targetBusinessId.HasValue)
            {
                businessComboBox.SelectedItem = businessComboBox.Items
                    .OfType<Business>()
                    .FirstOrDefault(b => b.Id == targetBusinessId.Value);
            }

            if (IsEditMode && CurrentDiscount != null)
            {
                nameField.Text = CurrentDiscount.Name;
                discountTypeComboBox.SelectedItem = DiscountTypeItem.All.Where(dt => CurrentDiscount.Type == dt.Type);
                valueField.Text = CurrentDiscount.Value.ToString();

                var discountType = CurrentDiscount.Type;
                valueLabel.Text = discountType switch
                {
                    DiscountType.PERCENTAGE => "Value (%)",
                    DiscountType.BUY_X_GET_Y => "Buy",
                    _ => "Value"
                };

                if (discountType == DiscountType.BUY_X_GET_Y)
                {
                    getLabel.Visible = true;
                    getField.Visible = true;
                    valueField.Width = (getField.Left - getField.Margin.Left) - valueField.Left;
                    valueField.Text = CurrentDiscount.BuyAmount.ToString();
                    getField.Text = CurrentDiscount.GetAmount.ToString();
                }
                else
                {
                    getLabel.Visible = false;
                    getField.Visible = false;
                    valueField.Width = getField.Right - valueField.Left;
                }
            }

            RefreshItems();
        }

        private void EditDiscount_Resize(object sender, EventArgs e)
        {
            int infoPanelTop = infoPanel.Margin.Top;
            foreach (Panel rowPanel in infoPanel.Controls.OfType<Panel>().OrderBy(p => p.TabIndex))
            {
                var label = rowPanel.Controls.OfType<Label>().OrderBy(p => p.TabIndex).FirstOrDefault()!;
                var tb = rowPanel.Controls.OfType<KryptonTextBox>().OrderBy(p => p.TabIndex).FirstOrDefault();
                var cb = rowPanel.Controls.OfType<KryptonComboBox>().FirstOrDefault();
                var flowPanel = rowPanel.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();

                rowPanel.Width = infoPanel.Width;
                rowPanel.Top = infoPanelTop;
                rowPanel.Left = infoPanel.Left;

                label.Top = rowPanel.Padding.Top;
                label.Left = rowPanel.Padding.Left;

                int setPos = label.Bottom + label.Margin.Bottom;
                if (tb != null)
                {
                    tb.Top = setPos;
                    tb.Left = rowPanel.Padding.Left;
                }
                if (cb != null)
                {
                    cb.Top = setPos;
                    cb.Left = rowPanel.Padding.Left;
                }
                if (flowPanel != null)
                {
                    flowPanel.Top = setPos;
                    flowPanel.Left = rowPanel.Padding.Left;
                }


                infoPanelTop += rowPanel.Height;
            }

            infoPanel.Height = this.ClientSize.Height - headerPanel.Height;
            itemsRowPanel.Height = infoPanel.ClientSize.Height - itemsRowPanel.Top;
        }

        private void businessComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedBusiness = businessComboBox.SelectedValue as Business;
            RefreshItems();
        }

        private void RefreshItems()
        {
            productFlowPanel.Controls.Clear();
            foreach (Product p in _productService.GetProducts().Where(pr => pr.Business.Id == SelectedBusiness?.Id))
            {
                var btn = Buttons.CreateProductButton(p, 55, false);
                if (IsEditMode && CurrentDiscount!.EligibleItems.Any(i => i.Id == p.Id))
                    btn.ToggleButton();
                btn.Click += (_, _) =>
                {
                    if (!btn.ToggleButton())
                    {
                        SelectedProducts.Remove(p);
                        return;
                    }
                    SelectedProducts.Add(p);
                };

                productFlowPanel.Controls.Add(btn);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            RequestClose?.Invoke(this, DialogResult.Cancel);
        }
    }
}
