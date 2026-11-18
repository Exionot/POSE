using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Util;
using cc105_pose_proj.Services;
using Krypton.Toolkit;

namespace cc105_pose_proj.UserControls
{
    public partial class OpenProduct : UserControl, IDialogControl
    {
        public event EventHandler<DialogResult>? RequestClose;
        private readonly BusinessService _businessService = new();
        private readonly InventoryMovementService _movementService = new();
        private readonly ProductService _productService = new();
        private Product? CurrentProduct;
        public OpenProduct(Product? product)
        {
            CurrentProduct = product;
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

        private void OpenProduct_Load(object sender, EventArgs e)
        {
            var user = Session.CurrentUser;
            if (user == null) return;

            foreach (var business in _businessService.GetBusinesses())
                businessComboBox.Items.Add(business);

            int? targetBusinessId = CurrentProduct?.Business.Id ?? user.Business?.Id;

            if (targetBusinessId.HasValue)
            {
                businessComboBox.SelectedItem = businessComboBox.Items
                    .OfType<Business>()
                    .FirstOrDefault(b => b.Id == targetBusinessId.Value);
            }

            businessComboBox.Enabled = user.IsAdmin;

            if (CurrentProduct == null)
                return;

            Image img = Image.FromFile(AppPaths.ResourceDir + CurrentProduct.Image);
            productPictureBox.Image = (Image)img.Clone();
            img?.Dispose();

            nameField.Text = CurrentProduct.Name;
            priceField.Text = CurrentProduct.Price.ToString();
            stockField.Text = CurrentProduct.Quantity.ToString();
        }

        private void OpenProduct_Resize(object sender, EventArgs e)
        {
            headerPanel.Height = (int)(this.Height * 0.1);
            imagePanel.Height = (int)(this.Height * 0.4);
            infoPanel.Height = (int)(this.Height * 0.5);

            int backButtonMargin = 20;
            int backButtonSize = headerPanel.Height - backButtonMargin;
            backBtn.Size = new Size(backButtonSize, backButtonSize);
            backBtn.Top = backButtonMargin;
            backBtn.Left = backButtonMargin;


            int pictureBoxSize = imagePanel.Height - selectImgBtn.Height -
                (selectImgBtn.Margin.Top + selectImgBtn.Margin.Bottom);
            productPictureBox.Size = new Size(pictureBoxSize, pictureBoxSize);

            selectImgBtn.Top = productPictureBox.Bottom + selectImgBtn.Margin.Top;

            foreach (Control element in imagePanel.Controls)
                element.Left = (imagePanel.Width - element.Width) / 2;

            int infoPanelTop = 0;
            foreach (Panel rowPanel in infoPanel.Controls.OfType<Panel>().OrderBy(p => p.TabIndex))
            {
                var label = rowPanel.Controls.OfType<Label>().FirstOrDefault();
                var textbox = rowPanel.Controls.OfType<KryptonTextBox>().FirstOrDefault();
                var comboBox = rowPanel.Controls.OfType<KryptonComboBox>().FirstOrDefault();
                int padding = rowPanel.Padding.Top + rowPanel.Padding.Bottom;

                int textboxHeight = textbox == null ? 0 : textbox.Height;
                int comboBoxHeight = comboBox == null ? 0 : comboBox.Height;

                rowPanel.Height = padding + label!.Height + textboxHeight + comboBoxHeight;
                rowPanel.Width = infoPanel.Width;
                rowPanel.Top = infoPanelTop;
                rowPanel.Left = 0;
                infoPanelTop += rowPanel.Height;
            }
        }

        private void editStockBtn_Click(object sender, EventArgs e)
        {
            var editStock = new EditStock(CurrentProduct!.Quantity);
            DialogResult result = PopupForm.Open(this, editStock, "Edit Stock");

            if (result == DialogResult.OK)
            {
                var updatedProduct = _productService.GetProductById(CurrentProduct.Id);
                if (updatedProduct == null)
                    return;

                if (!_movementService.RecordMovement(
                    CurrentProduct.Id, editStock.SelectedType, 
                    editStock.AdjustedQuantity, out int movementId))
                    return;

                updatedProduct.Quantity = _movementService.CalculateNewStock(
                    updatedProduct.Quantity, editStock.AdjustedQuantity, editStock.SelectedType);

                if (!_productService.UpdateProduct(updatedProduct))
                {
                    _movementService.DeleteMovement(movementId);
                    return;
                }
    
                CurrentProduct = updatedProduct;
                stockField.Text = CurrentProduct.Quantity.ToString();
            }
        }
    }
}
