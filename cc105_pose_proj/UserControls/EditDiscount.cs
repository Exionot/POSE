using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Services;
using cc105_pose_proj.Util;
using Krypton.Toolkit;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace cc105_pose_proj.UserControls
{
    public partial class EditDiscount : UserControl, IDialogControl
    {
        public event EventHandler<DialogResult>? RequestClose;
        private readonly DiscountService _discountService = new();
        private readonly ProductService _productService = new();
        private readonly BusinessService _businessService = new();
        private Discount? CurrentDiscount;
        private DiscountType? SelectedDiscountType;
        private Business? SelectedBusiness;
        private List<Product> SelectedProducts = [];
        private bool IsEditMode;
        private bool _isInitializing = true;
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
            discountTypeComboBox.SelectedIndex = -1;

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

            _isInitializing = false;

            nameField.Text = CurrentDiscount?.Name;

            discountTypeComboBox.SelectedItem = discountTypeComboBox.Items
                .OfType<DiscountTypeItem>()
                .FirstOrDefault(dt => dt.Type == CurrentDiscount?.Type);

            ReloadValueTextBox();
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
            if (_isInitializing)
                return;

            SelectedBusiness = businessComboBox.SelectedItem as Business;
            RefreshItems();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (HasUnsavedChanges())
            {
                var result = MessageBox.Show(
                    "Close this window? Unsaved actions will be lost!",
                    "Exit", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                    RequestClose?.Invoke(this, DialogResult.Cancel);
                return;
            }

            RequestClose?.Invoke(this, DialogResult.Cancel);
        }

        private void ReloadValueTextBox()
        {
            valueLabel.Text = SelectedDiscountType switch
            {
                DiscountType.PERCENTAGE => "Value (%)",
                DiscountType.BUY_X_GET_Y => "Buy",
                _ => "Value"
            };

            valueField.Text = "0";
            getField.Text = CurrentDiscount?.GetAmount.ToString() ?? "0";

            if (SelectedDiscountType == CurrentDiscount?.Type)
                valueField.Text = CurrentDiscount?.Value.ToString();

            if (SelectedDiscountType == DiscountType.BUY_X_GET_Y)
            {
                getLabel.Visible = true;
                getField.Visible = true;
                valueField.Width = (getField.Left - getField.Margin.Left) - valueField.Left;
                valueField.Text = CurrentDiscount?.BuyAmount.ToString() ?? "0";
            }
            else
            {
                getLabel.Visible = false;
                getField.Visible = false;
                valueField.Width = getField.Right - valueField.Left;
            }
        }

        private void RefreshItems()
        {
            productFlowPanel.Controls.Clear();

            var allProducts = _productService.GetProducts()
                .Where(pr => pr.Business?.Id == SelectedBusiness?.Id)
                .DistinctBy(pr => pr.Id)
                .ToList();

            foreach (Product p in allProducts)
            {
                var btn = Buttons.CreateProductButton(p, 55, false);
                if (IsEditMode && CurrentDiscount!.EligibleItems.Any(i => i.Id == p.Id))
                {
                    btn.ToggleButton();
                    SelectedProducts.Add(p);
                }
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

        private bool HasUnsavedChanges()
        {
            string name = nameField.Text.Trim();
            var discountTypeItem = (DiscountTypeItem?)discountTypeComboBox.SelectedItem;
            var type = discountTypeItem?.Type;
            var business = SelectedBusiness;
            string valueText = valueField.Text.Trim();
            string getText = getField.Text.Trim();

            if (CurrentDiscount == null)
            {
                return name.Length > 0
                    || type != null
                    || business != null
                    || valueText.Length > 0
                    || getText.Length > 0;
            }

            bool nameChanged = name != CurrentDiscount.Name;
            bool typeChanged = type != CurrentDiscount.Type;
            bool businessChanged = business?.Id != CurrentDiscount.CreatedBy.Id;
            bool valueChanged = type == DiscountType.BUY_X_GET_Y ?
                !int.TryParse(valueText, out var buyAmount) || buyAmount != CurrentDiscount.BuyAmount
                : !decimal.TryParse(valueText, out var value) || value != CurrentDiscount.Value;
            bool getChanged = !int.TryParse(getText, out var getAmount) || getAmount != CurrentDiscount.GetAmount;
            bool itemsChanged =
                !SelectedProducts.Select(p => p.Id)
                    .OrderBy(id => id)
                    .SequenceEqual(
                        CurrentDiscount.EligibleItems.Select(i => i.Id)
                            .OrderBy(id => id)
                    );

            return nameChanged
                || typeChanged
                || businessChanged
                || valueChanged
                || getChanged
                || itemsChanged;
        }

        private bool TryBuildDiscount(out Discount discount)
        {
            discount = null!;

            string name = nameField.Text.Trim();
            if (name.Length == 0) return false;

            var discountTypeItem = (DiscountTypeItem?)discountTypeComboBox.SelectedItem;
            var type = discountTypeItem?.Type;

            if (type is not DiscountType) return false;

            if (businessComboBox.SelectedItem is not Business business) return false;

            decimal value = 0;
            int buyAmount = 0;
            int getAmount = 0;

            string valueText = valueField.Text.Trim();
            bool isValueInvalid = type == DiscountType.BUY_X_GET_Y ?
                !int.TryParse(valueText, out buyAmount) || buyAmount < 0
                : !decimal.TryParse(valueText, out value) || value < 0;
            if (isValueInvalid) return false;

            if (!int.TryParse(getField.Text, out getAmount) || getAmount < 0) return false;

            discount = new Discount
            {
                Id = CurrentDiscount?.Id ?? 0,
                Name = name,
                Type = type.Value,
                Value = type != DiscountType.BUY_X_GET_Y ? value : 0,
                BuyAmount = type == DiscountType.BUY_X_GET_Y ? buyAmount : 0,
                GetAmount = type == DiscountType.BUY_X_GET_Y ? getAmount : 0,
                Active = true,
                CreatedBy = business,
                EligibleItems = SelectedProducts
            };
            return true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!HasUnsavedChanges()) return;

            if (!TryBuildDiscount(out var discount))
            {
                MessageBox.Show("Could not save discount. Check your input.", "Save Failed");
                return;
            }

            bool isEditMode = CurrentDiscount != null;
            bool success = isEditMode ?
                _discountService.UpdateDiscount(discount)
                : _discountService.CreateDiscount(discount);
            string message = isEditMode ? "Discount update success!" : "Discount creation success!";

            if (!success)
            {
                MessageBox.Show("Something went wrong", "Fail");
                return;
            }
            MessageBox.Show(message, "Success");
            RequestClose?.Invoke(this, DialogResult.OK);
        }

        private void discountTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing)
                return;

            var discountTypeItem = (DiscountTypeItem?)discountTypeComboBox.SelectedItem;
            SelectedDiscountType = discountTypeItem?.Type;
            ReloadValueTextBox();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (CurrentDiscount == null) return;

            var result = MessageBox.Show(
                "Are you sure you want to delete this product? This action is ireversable.",
                "Delete Product",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation);

            if (result == DialogResult.OK)
            {
                if (!_discountService.DeleteDiscount(CurrentDiscount.Id))
                {
                    MessageBox.Show("Product delete failed", "Delete");
                    return;
                }

                MessageBox.Show("Product deletion success!", "Success");
                RequestClose?.Invoke(this, DialogResult.OK);
            }
        }
    }
}
