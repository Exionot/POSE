using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Services;
using cc105_pose_proj.Util;
using Krypton.Toolkit;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace cc105_pose_proj.UserControls
{
    public partial class OpenProduct : UserControl, IDialogControl
    {
        public event EventHandler<DialogResult>? RequestClose;
        private readonly BusinessService _businessService = new();
        private readonly InventoryMovementService _movementService = new();
        private readonly ProductService _productService = new();
        private Product? CurrentProduct;
        private string? NewImagePath;
        private bool IsSaved = false;
        public OpenProduct(Product? product = null)
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

            businessComboBox.SelectedIndex = -1;
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

            int backButtonMargin = 15;
            int backButtonSize = headerPanel.Height - (backButtonMargin * 2);
            backBtn.Size = new Size(backButtonSize, backButtonSize);
            backBtn.Top = backButtonMargin;
            backBtn.Left = backButtonMargin;

            foreach (KryptonButton btn in headerPanel.Controls.OfType<KryptonButton>())
                btn.Top = (headerPanel.Height - btn.Height) / 2;

            saveBtn.Left = headerPanel.Right - backButtonMargin - saveBtn.Width;
            deleteBtn.Left = saveBtn.Left - saveBtn.Margin.Left - deleteBtn.Width;

            deleteBtn.Visible = Session.CurrentUser!.IsAdmin;

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

            bool isEditMode = CurrentProduct != null;
            stockField.Enabled = !isEditMode;
            if (!isEditMode)
            {
                stockRowPanel.Controls.Remove(editStockBtn);
                stockField.Width = stockRowPanel.Width - stockRowPanel.Padding.Right - stockRowPanel.Padding.Left;
            }
        }

        private void editStockBtn_Click(object sender, EventArgs e)
        {
            if (CurrentProduct == null) return;

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

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (IsSaved)
                RequestClose?.Invoke(this, DialogResult.Cancel);

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

        private bool HasUnsavedChanges()
        {
            string name = nameField.Text.Trim();
            string priceText = priceField.Text.Trim();
            var selected = businessComboBox.SelectedItem as Business;

            if (CurrentProduct == null)
            {
                return NewImagePath != null
                    || name.Length > 0
                    || priceText.Length > 0
                    || selected != null;
            }

            bool priceChanged = !decimal.TryParse(priceText, out decimal price)
                                || CurrentProduct.Price != price;

            bool imageChanged = NewImagePath != null
                && CurrentProduct.Image != Path.GetFileName(NewImagePath);

            return CurrentProduct.Name != name
                || priceChanged
                || CurrentProduct.Business?.Id != selected?.Id
                || imageChanged;
        }

        private bool TryBuildProduct(out Product product)
        {
            product = null!;

            string name = nameField.Text.Trim();
            if (name.Length == 0) return false;

            if (!decimal.TryParse(priceField.Text, NumberStyles.Number,
                    CultureInfo.CurrentCulture, out decimal price) || price < 0) return false;

            if (businessComboBox.SelectedItem is not Business business) return false;

            NewImagePath ??= AppPaths.ResourceDir + "Default.png";

            product = new Product
            {
                Id = CurrentProduct?.Id ?? 0,
                Name = name,
                Price = price,
                Quantity = int.Parse(stockField.Text),
                Business = business
            };
            return true;
        }

        private void selectImgBtn_Click(object sender, EventArgs e)
        {
            string? imgPath = SelectImage();
            if (imgPath == null) return;

            NewImagePath = imgPath;
            productPictureBox.Image = Image.FromFile(NewImagePath);
        }

        private string? SelectImage()
        {
            using var fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select an Image";
            fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return fileDialog.FileName;
            }

            return null;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!TryBuildProduct(out var product))
            {
                MessageBox.Show("Could not save product. Check your input.", "Save Failed");
                return;
            }

            bool isEditMode = CurrentProduct != null;

            bool success = isEditMode ?
                _productService.UpdateProduct(product, NewImagePath) :
                _productService.CreateProduct(product, NewImagePath!);
            string message = isEditMode ? "Product update success!" : "Product creation success!";

            if (!success)
            {
                MessageBox.Show("Something went wrong", "Fail");
                return;
            }
            MessageBox.Show(message, "Success");
            IsSaved = true;
            CurrentProduct = product;
            NewImagePath = null;
        }
    }
}
