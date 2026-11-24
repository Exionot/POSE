using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Presenters;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.UserControls
{
    public partial class Inventory : UserControl, IInventoryView
    {
        public event EventHandler<Product>? ProductSelected;
        public event EventHandler? CreateProductRequest;
        public event EventHandler? EditProductRequest;
        public event EventHandler? BackRequest;

        private readonly InventoryViewPresenter _presenter;
        public Inventory(INavigator nav, IProductService productService)
        {
            InitializeComponent();
            _presenter = new InventoryViewPresenter(this, productService, nav);

            newProductBtn.Click += (_, _) => CreateProductRequest?.Invoke(this, EventArgs.Empty);
            editProductBtn.Click += (_, _) => EditProductRequest?.Invoke(this, EventArgs.Empty);
            backBtn.Click += (_, _) => BackRequest?.Invoke(this, EventArgs.Empty);
        }

        public void SetProducts(List<Product> products)
        {
            allProductPanel.Controls.Clear();
            foreach (Product p in products)
            {
                Button btn = Buttons.CreateProductButton(p);
                btn.Click += (_, _) => ProductSelected?.Invoke(this, p);
                allProductPanel.Controls.Add(btn);
            }
        }

        public void DisplayProductDetails(Product? p)
        {
            foreach (Panel panel in leftPanel.Controls.OfType<Panel>())
            {
                panel.Visible = p is not null;
            }

            if (p == null)
            {
                productPictureBox.Image?.Dispose();
                productPictureBox.Image = null;
                return;
            }

            string imgPath = Path.Combine(AppPaths.ResourceDir, p.Image);
            if (File.Exists(imgPath))
            {
                using var temp = Image.FromFile(imgPath);
                var oldImg = productPictureBox.Image;
                productPictureBox.Image = new Bitmap(temp);
                oldImg?.Dispose();
            }

            nameLabel.Text = p.Name;
            priceLabel.Text = p.Price.ToString("C2");
            productStockLabel.Text = p.Quantity.ToString();
            productBusinessLabel.Text = p.Business.Name;
            productCreatedLabel.Text = p.Created.ToString();
            productUpdatedLabel.Text = p.Updated.ToString();

            fixProductPanel();
        }

        public bool OpenProductDialog(Product? product = null)
        {
            string title = product != null ? product.Name : "New Product";
            var dialog = product != null ? new OpenProduct(product) : new OpenProduct();

            DialogResult result = PopupForm.Open(this, dialog, title);
            return result == DialogResult.OK;
        }

        private void Inventory_Resize(object sender, EventArgs e)
        {
            headerPanel.Height = (int)(this.Height * 0.1);

            int backButtonMargin = 30;
            int backButtonSize = headerPanel.Height - backButtonMargin;
            backBtn.Size = new Size(backButtonSize, backButtonSize);
            backBtn.Top = backButtonMargin;
            backBtn.Left = backButtonMargin;

            leftPanel.Width = (int)(this.Width * 0.45) + 5;
            productActionPanel.Height = (int)(leftPanel.Height * 0.1);
            productInfoPanel.Height = (int)(leftPanel.Height * 0.6);
            productExtraPanel.Height = (int)(leftPanel.Height * 0.3) + 5;

            fixProductPanel();

            rightPanel.Width = (int)(this.Width * 0.55);
            allProductPanel.Height = rightPanel.Height - productLabel.Height - productLabel.Margin.Top;
        }

        private void fixProductPanel()
        {
            int imgMargin = 15;
            int imgSize = productInfoPanel.Height - nameLabel.Height - priceLabel.Height - (imgMargin * 2);
            productPictureBox.Size = new Size(imgSize, imgSize);
            productPictureBox.Top = 0;
            productPictureBox.Left = (productInfoPanel.Width - productPictureBox.Width) / 2;

            nameLabel.Top = productPictureBox.Height + imgMargin;
            nameLabel.Left = (productInfoPanel.Width - nameLabel.Width) / 2;

            priceLabel.Top = nameLabel.Top + nameLabel.Height;
            priceLabel.Left = (productInfoPanel.Width - priceLabel.Width) / 2;

            int extraPanelPadding = 30;
            int rowGap = 10;
            fixRowPanel(stockRowPanel, productExtraPanel, extraPanelPadding, stockLabel);
            stockRowPanel.Top = rowGap;

            fixRowPanel(businessRowPanel, productExtraPanel, extraPanelPadding, businessLabel);
            businessRowPanel.Top = stockRowPanel.Bottom + rowGap;

            fixRowPanel(createdRowPanel, productExtraPanel, extraPanelPadding, createdLabel);
            createdRowPanel.Top = businessRowPanel.Bottom + rowGap;

            fixRowPanel(updatedRowPanel, productExtraPanel, extraPanelPadding, updatedLabel);
            updatedRowPanel.Top = createdRowPanel.Bottom + rowGap;
        }

        private void fixRowPanel(Panel panel, Panel parent, int padding, Label label)
        {
            panel.Size = new Size(parent.Width - (padding * 2), label.Height);
            panel.Left = (parent.Width - panel.Width) / 2;
        }

    }
}
