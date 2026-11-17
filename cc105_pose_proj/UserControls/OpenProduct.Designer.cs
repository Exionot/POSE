namespace cc105_pose_proj.UserControls
{
    partial class OpenProduct
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
            imagePanel = new Panel();
            selectImgBtn = new Krypton.Toolkit.KryptonButton();
            productPictureBox = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            infoPanel = new Panel();
            businessRowPanel = new Panel();
            businessComboBox = new Krypton.Toolkit.KryptonComboBox();
            stockRowPanel = new Panel();
            stockButtonPanel = new Panel();
            removeStockBtn = new Krypton.Toolkit.KryptonButton();
            addStockBtn = new Krypton.Toolkit.KryptonButton();
            stockField = new Krypton.Toolkit.KryptonTextBox();
            priceRowPanel = new Panel();
            priceField = new Krypton.Toolkit.KryptonTextBox();
            nameRowPanel = new Panel();
            nameField = new Krypton.Toolkit.KryptonTextBox();
            headerPanel.SuspendLayout();
            imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productPictureBox).BeginInit();
            infoPanel.SuspendLayout();
            businessRowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)businessComboBox).BeginInit();
            stockRowPanel.SuspendLayout();
            stockButtonPanel.SuspendLayout();
            priceRowPanel.SuspendLayout();
            nameRowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = SystemColors.Control;
            headerPanel.Controls.Add(backBtn);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(446, 59);
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
            backBtn.TabIndex = 2;
            backBtn.Values.DropDownArrowColor = Color.Empty;
            backBtn.Values.Text = "↩";
            // 
            // imagePanel
            // 
            imagePanel.BackColor = SystemColors.Control;
            imagePanel.Controls.Add(selectImgBtn);
            imagePanel.Controls.Add(productPictureBox);
            imagePanel.Dock = DockStyle.Top;
            imagePanel.Location = new Point(0, 59);
            imagePanel.Name = "imagePanel";
            imagePanel.Size = new Size(446, 227);
            imagePanel.TabIndex = 1;
            // 
            // selectImgBtn
            // 
            selectImgBtn.Location = new Point(178, 179);
            selectImgBtn.Margin = new Padding(5);
            selectImgBtn.Name = "selectImgBtn";
            selectImgBtn.Size = new Size(113, 30);
            selectImgBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            selectImgBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            selectImgBtn.StateCommon.Border.Rounding = 5F;
            selectImgBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            selectImgBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectImgBtn.TabIndex = 1;
            selectImgBtn.Values.DropDownArrowColor = Color.Empty;
            selectImgBtn.Values.Text = "Select Image";
            // 
            // productPictureBox
            // 
            productPictureBox.BackColor = SystemColors.ControlDark;
            productPictureBox.Location = new Point(141, 0);
            productPictureBox.Name = "productPictureBox";
            productPictureBox.Size = new Size(188, 171);
            productPictureBox.TabIndex = 0;
            productPictureBox.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label4.Location = new Point(13, 10);
            label4.Name = "label4";
            label4.Size = new Size(75, 22);
            label4.TabIndex = 3;
            label4.Text = "Business";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label3.Location = new Point(13, 10);
            label3.Name = "label3";
            label3.Size = new Size(52, 22);
            label3.TabIndex = 2;
            label3.Text = "Stock";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label2.Location = new Point(13, 10);
            label2.Name = "label2";
            label2.Size = new Size(48, 22);
            label2.TabIndex = 1;
            label2.Text = "Price";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(114, 22);
            label1.TabIndex = 0;
            label1.Text = "Product Name";
            // 
            // infoPanel
            // 
            infoPanel.BackColor = SystemColors.Control;
            infoPanel.Controls.Add(businessRowPanel);
            infoPanel.Controls.Add(stockRowPanel);
            infoPanel.Controls.Add(priceRowPanel);
            infoPanel.Controls.Add(nameRowPanel);
            infoPanel.Dock = DockStyle.Top;
            infoPanel.Location = new Point(0, 286);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(446, 458);
            infoPanel.TabIndex = 2;
            // 
            // businessRowPanel
            // 
            businessRowPanel.BackColor = SystemColors.Control;
            businessRowPanel.Controls.Add(businessComboBox);
            businessRowPanel.Controls.Add(label4);
            businessRowPanel.Location = new Point(3, 297);
            businessRowPanel.Name = "businessRowPanel";
            businessRowPanel.Padding = new Padding(10);
            businessRowPanel.Size = new Size(440, 100);
            businessRowPanel.TabIndex = 7;
            // 
            // businessComboBox
            // 
            businessComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            businessComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            businessComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            businessComboBox.Location = new Point(13, 35);
            businessComboBox.MinimumSize = new Size(0, 30);
            businessComboBox.Name = "businessComboBox";
            businessComboBox.Size = new Size(414, 30);
            businessComboBox.StateCommon.ComboBox.Border.Rounding = 5F;
            businessComboBox.StateCommon.ComboBox.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            businessComboBox.StateCommon.ComboBox.Content.Padding = new Padding(5, -1, 15, -1);
            businessComboBox.StateCommon.Item.Content.Padding = new Padding(5);
            businessComboBox.StateCommon.Item.Content.ShortText.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            businessComboBox.TabIndex = 4;
            // 
            // stockRowPanel
            // 
            stockRowPanel.BackColor = SystemColors.Control;
            stockRowPanel.Controls.Add(stockButtonPanel);
            stockRowPanel.Controls.Add(stockField);
            stockRowPanel.Controls.Add(label3);
            stockRowPanel.Location = new Point(3, 201);
            stockRowPanel.Name = "stockRowPanel";
            stockRowPanel.Padding = new Padding(10);
            stockRowPanel.Size = new Size(440, 90);
            stockRowPanel.TabIndex = 6;
            // 
            // stockButtonPanel
            // 
            stockButtonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stockButtonPanel.Controls.Add(removeStockBtn);
            stockButtonPanel.Controls.Add(addStockBtn);
            stockButtonPanel.Location = new Point(350, 31);
            stockButtonPanel.Name = "stockButtonPanel";
            stockButtonPanel.Size = new Size(77, 37);
            stockButtonPanel.TabIndex = 4;
            // 
            // removeStockBtn
            // 
            removeStockBtn.Location = new Point(41, 3);
            removeStockBtn.Name = "removeStockBtn";
            removeStockBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            removeStockBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            removeStockBtn.OverrideDefault.Border.Rounding = 5F;
            removeStockBtn.Size = new Size(33, 31);
            removeStockBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            removeStockBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            removeStockBtn.StateCommon.Border.Rounding = 5F;
            removeStockBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            removeStockBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 12F, FontStyle.Bold);
            removeStockBtn.TabIndex = 1;
            removeStockBtn.Values.DropDownArrowColor = Color.Empty;
            removeStockBtn.Values.Text = "-";
            // 
            // addStockBtn
            // 
            addStockBtn.Location = new Point(3, 3);
            addStockBtn.Name = "addStockBtn";
            addStockBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            addStockBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            addStockBtn.OverrideDefault.Border.Rounding = 5F;
            addStockBtn.Size = new Size(33, 31);
            addStockBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            addStockBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            addStockBtn.StateCommon.Border.Rounding = 5F;
            addStockBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            addStockBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 12F, FontStyle.Bold);
            addStockBtn.TabIndex = 0;
            addStockBtn.Values.DropDownArrowColor = Color.Empty;
            addStockBtn.Values.Text = "+";
            // 
            // stockField
            // 
            stockField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            stockField.Location = new Point(13, 35);
            stockField.Name = "stockField";
            stockField.Size = new Size(331, 33);
            stockField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            stockField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            stockField.StateCommon.Border.Rounding = 5F;
            stockField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stockField.StateCommon.Content.Padding = new Padding(5);
            stockField.TabIndex = 3;
            stockField.Text = "kryptonTextBox2";
            // 
            // priceRowPanel
            // 
            priceRowPanel.BackColor = SystemColors.Control;
            priceRowPanel.Controls.Add(priceField);
            priceRowPanel.Controls.Add(label2);
            priceRowPanel.Location = new Point(3, 109);
            priceRowPanel.Name = "priceRowPanel";
            priceRowPanel.Padding = new Padding(10);
            priceRowPanel.Size = new Size(440, 86);
            priceRowPanel.TabIndex = 5;
            // 
            // priceField
            // 
            priceField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            priceField.Location = new Point(13, 35);
            priceField.Name = "priceField";
            priceField.Size = new Size(414, 33);
            priceField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            priceField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            priceField.StateCommon.Border.Rounding = 5F;
            priceField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            priceField.StateCommon.Content.Padding = new Padding(5);
            priceField.TabIndex = 2;
            priceField.Text = "kryptonTextBox2";
            // 
            // nameRowPanel
            // 
            nameRowPanel.BackColor = SystemColors.Control;
            nameRowPanel.Controls.Add(nameField);
            nameRowPanel.Controls.Add(label1);
            nameRowPanel.Location = new Point(3, 3);
            nameRowPanel.Name = "nameRowPanel";
            nameRowPanel.Padding = new Padding(10);
            nameRowPanel.Size = new Size(440, 83);
            nameRowPanel.TabIndex = 4;
            // 
            // nameField
            // 
            nameField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameField.Location = new Point(13, 35);
            nameField.Name = "nameField";
            nameField.Size = new Size(414, 33);
            nameField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            nameField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            nameField.StateCommon.Border.Rounding = 5F;
            nameField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameField.StateCommon.Content.Padding = new Padding(5);
            nameField.TabIndex = 1;
            nameField.Text = "kryptonTextBox1";
            // 
            // OpenProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(infoPanel);
            Controls.Add(imagePanel);
            Controls.Add(headerPanel);
            Name = "OpenProduct";
            Size = new Size(446, 747);
            Load += OpenProduct_Load;
            Resize += OpenProduct_Resize;
            headerPanel.ResumeLayout(false);
            imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)productPictureBox).EndInit();
            infoPanel.ResumeLayout(false);
            businessRowPanel.ResumeLayout(false);
            businessRowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)businessComboBox).EndInit();
            stockRowPanel.ResumeLayout(false);
            stockRowPanel.PerformLayout();
            stockButtonPanel.ResumeLayout(false);
            priceRowPanel.ResumeLayout(false);
            priceRowPanel.PerformLayout();
            nameRowPanel.ResumeLayout(false);
            nameRowPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Panel imagePanel;
        private Krypton.Toolkit.KryptonButton backBtn;
        private PictureBox productPictureBox;
        private Krypton.Toolkit.KryptonButton selectImgBtn;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private Panel infoPanel;
        private Panel nameRowPanel;
        private Krypton.Toolkit.KryptonTextBox nameField;
        private Panel businessRowPanel;
        private Panel stockRowPanel;
        private Panel priceRowPanel;
        private Krypton.Toolkit.KryptonTextBox priceField;
        private Panel stockButtonPanel;
        private Krypton.Toolkit.KryptonButton removeStockBtn;
        private Krypton.Toolkit.KryptonButton addStockBtn;
        private Krypton.Toolkit.KryptonTextBox stockField;
        private Krypton.Toolkit.KryptonComboBox businessComboBox;
    }
}
