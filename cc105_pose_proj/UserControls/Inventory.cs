using cc105_pose_proj.Data;
using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Services;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.UserControls
{
    public partial class Inventory : UserControl
    {
        private readonly INavigator _nav;
        private readonly ProductService _productService = new();
        private Product selectedProduct = null!;
        public Inventory(INavigator nav)
        {
            _nav = nav;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo(new Home(_nav));
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

        private void Inventory_Load(object sender, EventArgs e)
        {
            foreach (Panel panel in leftPanel.Controls.OfType<Panel>())
            {
                panel.Visible = false;
            }

            RefreshProducts();
        }

        private void RefreshProducts()
        {
            List<Product> productList = _productService.GetProducts();

            allProductPanel.Controls.Clear();
            foreach (Product p in productList)
            {
                Button btn = Buttons.CreateProductButton(new Button(), p);
                btn.Click += (s, ev) => ViewProduct(p);
                allProductPanel.Controls.Add(btn);
            }
        }

        private void ViewProduct(Product p)
        {
            selectedProduct = p;
            foreach (Panel panel in leftPanel.Controls.OfType<Panel>())
            {
                panel.Visible = true;
            }

            Image img = Image.FromFile(AppPaths.ResourceDir + p.Image);
            productPictureBox.Image = (Image)img.Clone();
            img?.Dispose();

            nameLabel.Text = p.Name;
            priceLabel.Text = p.Price.ToString("C2");
            productStockLabel.Text = p.Quantity.ToString();
            productBusinessLabel.Text = p.Business.Name;
            productCreatedLabel.Text = p.Created.ToString();
            productUpdatedLabel.Text = p.Updated.ToString();

            fixProductPanel();
        }

        private void EditProduct(Product p)
        {
            if (PopupForm.Open(this, new OpenProduct(p), p.Name) == DialogResult.OK)
            {
                RefreshProducts();
                ViewProduct(p);
            }
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

        private void newProductBtn_Click(object sender, EventArgs e)
        {

        }

        private void editProductBtn_Click_1(object sender, EventArgs e)
        {
            EditProduct(selectedProduct);
        }
    }
}
