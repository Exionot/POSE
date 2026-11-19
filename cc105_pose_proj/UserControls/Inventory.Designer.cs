namespace cc105_pose_proj.UserControls
{
    partial class Inventory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerPanel = new Panel();
            backBtn = new Krypton.Toolkit.KryptonButton();
            leftPanel = new Panel();
            productExtraPanel = new Panel();
            updatedRowPanel = new Panel();
            productUpdatedLabel = new Label();
            updatedLabel = new Label();
            createdRowPanel = new Panel();
            productCreatedLabel = new Label();
            createdLabel = new Label();
            businessRowPanel = new Panel();
            productBusinessLabel = new Label();
            businessLabel = new Label();
            stockRowPanel = new Panel();
            productStockLabel = new Label();
            stockLabel = new Label();
            productInfoPanel = new Panel();
            priceLabel = new Label();
            nameLabel = new Label();
            productPictureBox = new PictureBox();
            productActionPanel = new Panel();
            editProductBtn = new Krypton.Toolkit.KryptonButton();
            rightPanel = new Panel();
            allProductPanel = new FlowLayoutPanel();
            newProductBtn = new Krypton.Toolkit.KryptonButton();
            productLabel = new Label();
            headerPanel.SuspendLayout();
            leftPanel.SuspendLayout();
            productExtraPanel.SuspendLayout();
            updatedRowPanel.SuspendLayout();
            createdRowPanel.SuspendLayout();
            businessRowPanel.SuspendLayout();
            stockRowPanel.SuspendLayout();
            productInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productPictureBox).BeginInit();
            productActionPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = SystemColors.Control;
            headerPanel.Controls.Add(backBtn);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(884, 80);
            headerPanel.TabIndex = 0;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(15, 15);
            backBtn.Margin = new Padding(15);
            backBtn.Name = "backBtn";
            backBtn.OverrideDefault.Back.Color1 = Color.Brown;
            backBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            backBtn.Size = new Size(30, 30);
            backBtn.StateCommon.Back.Color1 = Color.Brown;
            backBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            backBtn.StateCommon.Border.Rounding = 5F;
            backBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            backBtn.StateCommon.Content.ShortText.Font = new Font("Inter Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backBtn.TabIndex = 1;
            backBtn.Values.DropDownArrowColor = Color.Empty;
            backBtn.Values.Text = "↩";
            backBtn.Click += backBtn_Click;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = SystemColors.Control;
            leftPanel.Controls.Add(productExtraPanel);
            leftPanel.Controls.Add(productInfoPanel);
            leftPanel.Controls.Add(productActionPanel);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 80);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(416, 551);
            leftPanel.TabIndex = 1;
            // 
            // productExtraPanel
            // 
            productExtraPanel.BackColor = SystemColors.Control;
            productExtraPanel.Controls.Add(updatedRowPanel);
            productExtraPanel.Controls.Add(createdRowPanel);
            productExtraPanel.Controls.Add(businessRowPanel);
            productExtraPanel.Controls.Add(stockRowPanel);
            productExtraPanel.Dock = DockStyle.Bottom;
            productExtraPanel.Location = new Point(0, 326);
            productExtraPanel.Name = "productExtraPanel";
            productExtraPanel.Size = new Size(416, 225);
            productExtraPanel.TabIndex = 9;
            // 
            // updatedRowPanel
            // 
            updatedRowPanel.BackColor = SystemColors.Control;
            updatedRowPanel.Controls.Add(productUpdatedLabel);
            updatedRowPanel.Controls.Add(updatedLabel);
            updatedRowPanel.Location = new Point(0, 146);
            updatedRowPanel.Name = "updatedRowPanel";
            updatedRowPanel.Size = new Size(416, 43);
            updatedRowPanel.TabIndex = 15;
            // 
            // productUpdatedLabel
            // 
            productUpdatedLabel.AutoSize = true;
            productUpdatedLabel.Dock = DockStyle.Right;
            productUpdatedLabel.Font = new Font("Inter", 14F);
            productUpdatedLabel.Location = new Point(416, 0);
            productUpdatedLabel.Name = "productUpdatedLabel";
            productUpdatedLabel.Size = new Size(0, 27);
            productUpdatedLabel.TabIndex = 11;
            // 
            // updatedLabel
            // 
            updatedLabel.AutoSize = true;
            updatedLabel.Dock = DockStyle.Left;
            updatedLabel.Font = new Font("Inter", 14.25F, FontStyle.Bold);
            updatedLabel.Location = new Point(0, 0);
            updatedLabel.Name = "updatedLabel";
            updatedLabel.Size = new Size(116, 27);
            updatedLabel.TabIndex = 9;
            updatedLabel.Text = "Updated At";
            // 
            // createdRowPanel
            // 
            createdRowPanel.BackColor = SystemColors.Control;
            createdRowPanel.Controls.Add(productCreatedLabel);
            createdRowPanel.Controls.Add(createdLabel);
            createdRowPanel.Location = new Point(0, 97);
            createdRowPanel.Name = "createdRowPanel";
            createdRowPanel.Size = new Size(416, 43);
            createdRowPanel.TabIndex = 14;
            // 
            // productCreatedLabel
            // 
            productCreatedLabel.AutoSize = true;
            productCreatedLabel.Dock = DockStyle.Right;
            productCreatedLabel.Font = new Font("Inter", 14F);
            productCreatedLabel.Location = new Point(416, 0);
            productCreatedLabel.Name = "productCreatedLabel";
            productCreatedLabel.Size = new Size(0, 27);
            productCreatedLabel.TabIndex = 11;
            // 
            // createdLabel
            // 
            createdLabel.AutoSize = true;
            createdLabel.Dock = DockStyle.Left;
            createdLabel.Font = new Font("Inter", 14.25F, FontStyle.Bold);
            createdLabel.Location = new Point(0, 0);
            createdLabel.Name = "createdLabel";
            createdLabel.Size = new Size(111, 27);
            createdLabel.TabIndex = 9;
            createdLabel.Text = "Created At";
            // 
            // businessRowPanel
            // 
            businessRowPanel.BackColor = SystemColors.Control;
            businessRowPanel.Controls.Add(productBusinessLabel);
            businessRowPanel.Controls.Add(businessLabel);
            businessRowPanel.Location = new Point(0, 48);
            businessRowPanel.Name = "businessRowPanel";
            businessRowPanel.Size = new Size(416, 43);
            businessRowPanel.TabIndex = 13;
            // 
            // productBusinessLabel
            // 
            productBusinessLabel.AutoSize = true;
            productBusinessLabel.Dock = DockStyle.Right;
            productBusinessLabel.Font = new Font("Inter", 14F);
            productBusinessLabel.Location = new Point(416, 0);
            productBusinessLabel.Name = "productBusinessLabel";
            productBusinessLabel.Size = new Size(0, 27);
            productBusinessLabel.TabIndex = 11;
            // 
            // businessLabel
            // 
            businessLabel.AutoSize = true;
            businessLabel.Dock = DockStyle.Left;
            businessLabel.Font = new Font("Inter", 14.25F, FontStyle.Bold);
            businessLabel.Location = new Point(0, 0);
            businessLabel.Name = "businessLabel";
            businessLabel.Size = new Size(98, 27);
            businessLabel.TabIndex = 9;
            businessLabel.Text = "Business";
            // 
            // stockRowPanel
            // 
            stockRowPanel.BackColor = SystemColors.Control;
            stockRowPanel.Controls.Add(productStockLabel);
            stockRowPanel.Controls.Add(stockLabel);
            stockRowPanel.Location = new Point(0, 0);
            stockRowPanel.Name = "stockRowPanel";
            stockRowPanel.Size = new Size(416, 48);
            stockRowPanel.TabIndex = 12;
            // 
            // productStockLabel
            // 
            productStockLabel.AutoSize = true;
            productStockLabel.Dock = DockStyle.Right;
            productStockLabel.Font = new Font("Inter", 14F);
            productStockLabel.Location = new Point(416, 0);
            productStockLabel.Name = "productStockLabel";
            productStockLabel.Size = new Size(0, 27);
            productStockLabel.TabIndex = 10;
            // 
            // stockLabel
            // 
            stockLabel.AutoSize = true;
            stockLabel.Dock = DockStyle.Left;
            stockLabel.Font = new Font("Inter", 14.25F, FontStyle.Bold);
            stockLabel.Location = new Point(0, 0);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(65, 27);
            stockLabel.TabIndex = 8;
            stockLabel.Text = "Stock";
            // 
            // productInfoPanel
            // 
            productInfoPanel.BackColor = SystemColors.Control;
            productInfoPanel.Controls.Add(priceLabel);
            productInfoPanel.Controls.Add(nameLabel);
            productInfoPanel.Controls.Add(productPictureBox);
            productInfoPanel.Dock = DockStyle.Top;
            productInfoPanel.Location = new Point(0, 82);
            productInfoPanel.Name = "productInfoPanel";
            productInfoPanel.Size = new Size(416, 238);
            productInfoPanel.TabIndex = 8;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            priceLabel.Location = new Point(182, 198);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(0, 30);
            priceLabel.TabIndex = 8;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Inter", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(113, 161);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(0, 39);
            nameLabel.TabIndex = 7;
            // 
            // productPictureBox
            // 
            productPictureBox.BackColor = Color.Transparent;
            productPictureBox.Image = Properties.Resources.Redbloom_Cheesecake;
            productPictureBox.Location = new Point(129, -1);
            productPictureBox.Margin = new Padding(15);
            productPictureBox.Name = "productPictureBox";
            productPictureBox.Size = new Size(162, 152);
            productPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            productPictureBox.TabIndex = 6;
            productPictureBox.TabStop = false;
            // 
            // productActionPanel
            // 
            productActionPanel.BackColor = SystemColors.Control;
            productActionPanel.Controls.Add(editProductBtn);
            productActionPanel.Dock = DockStyle.Top;
            productActionPanel.Location = new Point(0, 0);
            productActionPanel.Name = "productActionPanel";
            productActionPanel.Size = new Size(416, 82);
            productActionPanel.TabIndex = 3;
            // 
            // editProductBtn
            // 
            editProductBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editProductBtn.Location = new Point(311, 15);
            editProductBtn.Name = "editProductBtn";
            editProductBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            editProductBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            editProductBtn.Size = new Size(97, 31);
            editProductBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            editProductBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            editProductBtn.StateCommon.Border.Rounding = 5F;
            editProductBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            editProductBtn.StateCommon.Content.ShortText.Font = new Font("Inter Black", 9F, FontStyle.Bold);
            editProductBtn.TabIndex = 4;
            editProductBtn.Values.DropDownArrowColor = Color.Empty;
            editProductBtn.Values.Text = "Edit";
            editProductBtn.Click += editProductBtn_Click_1;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = SystemColors.Control;
            rightPanel.Controls.Add(allProductPanel);
            rightPanel.Controls.Add(newProductBtn);
            rightPanel.Controls.Add(productLabel);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(414, 80);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(15, 0, 0, 0);
            rightPanel.Size = new Size(470, 551);
            rightPanel.TabIndex = 2;
            // 
            // allProductPanel
            // 
            allProductPanel.Dock = DockStyle.Bottom;
            allProductPanel.Location = new Point(15, 451);
            allProductPanel.Name = "allProductPanel";
            allProductPanel.Size = new Size(455, 100);
            allProductPanel.TabIndex = 3;
            // 
            // newProductBtn
            // 
            newProductBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newProductBtn.Location = new Point(421, 15);
            newProductBtn.Name = "newProductBtn";
            newProductBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            newProductBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            newProductBtn.Size = new Size(31, 31);
            newProductBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            newProductBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            newProductBtn.StateCommon.Border.Rounding = 5F;
            newProductBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            newProductBtn.StateCommon.Content.ShortText.Font = new Font("Inter Black", 9F, FontStyle.Bold);
            newProductBtn.TabIndex = 2;
            newProductBtn.Values.DropDownArrowColor = Color.Empty;
            newProductBtn.Values.Text = "+";
            newProductBtn.Click += newProductBtn_Click;
            // 
            // productLabel
            // 
            productLabel.AutoSize = true;
            productLabel.Font = new Font("Inter", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productLabel.Location = new Point(15, 15);
            productLabel.Margin = new Padding(0, 15, 0, 15);
            productLabel.Name = "productLabel";
            productLabel.Size = new Size(162, 45);
            productLabel.TabIndex = 0;
            productLabel.Text = "Products";
            // 
            // Inventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rightPanel);
            Controls.Add(leftPanel);
            Controls.Add(headerPanel);
            Name = "Inventory";
            Size = new Size(884, 631);
            Load += Inventory_Load;
            Resize += Inventory_Resize;
            headerPanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            productExtraPanel.ResumeLayout(false);
            updatedRowPanel.ResumeLayout(false);
            updatedRowPanel.PerformLayout();
            createdRowPanel.ResumeLayout(false);
            createdRowPanel.PerformLayout();
            businessRowPanel.ResumeLayout(false);
            businessRowPanel.PerformLayout();
            stockRowPanel.ResumeLayout(false);
            stockRowPanel.PerformLayout();
            productInfoPanel.ResumeLayout(false);
            productInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productPictureBox).EndInit();
            productActionPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Panel leftPanel;
        private Krypton.Toolkit.KryptonButton backBtn;
        private Panel rightPanel;
        private Label productLabel;
        private Panel productActionPanel;
        private Panel productExtraPanel;
        private Label businessLabel;
        private Label stockLabel;
        private Panel productInfoPanel;
        private Label priceLabel;
        private Label nameLabel;
        private PictureBox productPictureBox;
        private Label productBusinessLabel;
        private Label productStockLabel;
        private Panel stockRowPanel;
        private Panel businessRowPanel;
        private Krypton.Toolkit.KryptonButton newProductBtn;
        private FlowLayoutPanel allProductPanel;
        private Panel updatedRowPanel;
        private Label productUpdatedLabel;
        private Label updatedLabel;
        private Panel createdRowPanel;
        private Label productCreatedLabel;
        private Label createdLabel;
        private Krypton.Toolkit.KryptonButton editProductBtn;
    }
}
