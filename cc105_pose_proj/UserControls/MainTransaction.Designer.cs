namespace cc105_pose_proj
{
    partial class MainTransaction
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
            productsPanel = new Krypton.Toolkit.KryptonPanel();
            productButtonPanel = new FlowLayoutPanel();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            transactionPanel = new Krypton.Toolkit.KryptonPanel();
            transactionGrid = new Krypton.Toolkit.KryptonDataGridView();
            totalPanel = new Krypton.Toolkit.KryptonPanel();
            totalListPanel = new Panel();
            subTotalRowPanel = new Panel();
            label3 = new Label();
            subTotalLabel = new Label();
            savedRowPanel = new Panel();
            label2 = new Label();
            discountLabel = new Label();
            totalRowPanel = new Panel();
            label1 = new Label();
            totalLabel = new Label();
            actionPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            removeOneBtn = new Krypton.Toolkit.KryptonButton();
            removeAllBtn = new Krypton.Toolkit.KryptonButton();
            clearTableBtn = new Krypton.Toolkit.KryptonButton();
            headerPanel = new Krypton.Toolkit.KryptonPanel();
            backBtn = new Krypton.Toolkit.KryptonButton();
            leftPanel = new Panel();
            rightPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)productsPanel).BeginInit();
            productsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)transactionPanel).BeginInit();
            transactionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)transactionGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)totalPanel).BeginInit();
            totalPanel.SuspendLayout();
            totalListPanel.SuspendLayout();
            subTotalRowPanel.SuspendLayout();
            savedRowPanel.SuspendLayout();
            totalRowPanel.SuspendLayout();
            actionPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)headerPanel).BeginInit();
            headerPanel.SuspendLayout();
            leftPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // productsPanel
            // 
            productsPanel.Controls.Add(productButtonPanel);
            productsPanel.Controls.Add(kryptonLabel1);
            productsPanel.Dock = DockStyle.Right;
            productsPanel.Location = new Point(-309, 0);
            productsPanel.Name = "productsPanel";
            productsPanel.Size = new Size(509, 538);
            productsPanel.StateCommon.Color1 = SystemColors.Control;
            productsPanel.TabIndex = 0;
            // 
            // productButtonPanel
            // 
            productButtonPanel.Location = new Point(15, 44);
            productButtonPanel.Margin = new Padding(15);
            productButtonPanel.Name = "productButtonPanel";
            productButtonPanel.Size = new Size(515, 513);
            productButtonPanel.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(0, 0);
            kryptonLabel1.Margin = new Padding(15);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(163, 45);
            kryptonLabel1.StateCommon.ShortText.Color1 = SystemColors.ControlText;
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Inter", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Products";
            // 
            // transactionPanel
            // 
            transactionPanel.Controls.Add(transactionGrid);
            transactionPanel.Dock = DockStyle.Top;
            transactionPanel.Location = new Point(0, 0);
            transactionPanel.Name = "transactionPanel";
            transactionPanel.Size = new Size(697, 190);
            transactionPanel.StateCommon.Color1 = SystemColors.Control;
            transactionPanel.TabIndex = 1;
            // 
            // transactionGrid
            // 
            transactionGrid.AllowUserToAddRows = false;
            transactionGrid.AllowUserToDeleteRows = false;
            transactionGrid.AllowUserToResizeRows = false;
            transactionGrid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            transactionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            transactionGrid.BorderStyle = BorderStyle.None;
            transactionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            transactionGrid.Location = new Point(0, -88);
            transactionGrid.Margin = new Padding(20);
            transactionGrid.MultiSelect = false;
            transactionGrid.Name = "transactionGrid";
            transactionGrid.ReadOnly = true;
            transactionGrid.RowHeadersVisible = false;
            transactionGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            transactionGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            transactionGrid.Size = new Size(654, 398);
            transactionGrid.StateCommon.Background.Color1 = SystemColors.ControlDark;
            transactionGrid.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            transactionGrid.StateCommon.DataCell.Content.Font = new Font("Inter", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            transactionGrid.StateCommon.HeaderColumn.Back.Color1 = Color.Goldenrod;
            transactionGrid.StateCommon.HeaderColumn.Back.Color2 = Color.Goldenrod;
            transactionGrid.StateCommon.HeaderColumn.Content.Color1 = SystemColors.Control;
            transactionGrid.StateCommon.HeaderColumn.Content.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            transactionGrid.StateCommon.HeaderRow.Back.Color1 = SystemColors.Control;
            transactionGrid.StateCommon.HeaderRow.Back.Color2 = SystemColors.Control;
            transactionGrid.TabIndex = 0;
            // 
            // totalPanel
            // 
            totalPanel.Controls.Add(totalListPanel);
            totalPanel.Controls.Add(actionPanel);
            totalPanel.Dock = DockStyle.Bottom;
            totalPanel.Location = new Point(0, 321);
            totalPanel.Name = "totalPanel";
            totalPanel.Size = new Size(697, 217);
            totalPanel.StateCommon.Color1 = Color.Lime;
            totalPanel.TabIndex = 2;
            // 
            // totalListPanel
            // 
            totalListPanel.BackColor = SystemColors.Control;
            totalListPanel.Controls.Add(subTotalRowPanel);
            totalListPanel.Controls.Add(savedRowPanel);
            totalListPanel.Controls.Add(totalRowPanel);
            totalListPanel.Dock = DockStyle.Left;
            totalListPanel.Location = new Point(0, 0);
            totalListPanel.Name = "totalListPanel";
            totalListPanel.Size = new Size(294, 217);
            totalListPanel.TabIndex = 1;
            // 
            // subTotalRowPanel
            // 
            subTotalRowPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            subTotalRowPanel.BackColor = SystemColors.Control;
            subTotalRowPanel.Controls.Add(label3);
            subTotalRowPanel.Controls.Add(subTotalLabel);
            subTotalRowPanel.Location = new Point(4, 15);
            subTotalRowPanel.Name = "subTotalRowPanel";
            subTotalRowPanel.Size = new Size(266, 66);
            subTotalRowPanel.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 14.25F);
            label3.Location = new Point(24, 19);
            label3.Name = "label3";
            label3.Size = new Size(91, 27);
            label3.TabIndex = 3;
            label3.Text = "Subtotal:";
            // 
            // subTotalLabel
            // 
            subTotalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            subTotalLabel.AutoSize = true;
            subTotalLabel.Font = new Font("Inter", 14.25F);
            subTotalLabel.Location = new Point(206, 17);
            subTotalLabel.Name = "subTotalLabel";
            subTotalLabel.Size = new Size(68, 27);
            subTotalLabel.TabIndex = 2;
            subTotalLabel.Text = "label2";
            subTotalLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // savedRowPanel
            // 
            savedRowPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            savedRowPanel.BackColor = SystemColors.Control;
            savedRowPanel.Controls.Add(label2);
            savedRowPanel.Controls.Add(discountLabel);
            savedRowPanel.Location = new Point(4, 87);
            savedRowPanel.Name = "savedRowPanel";
            savedRowPanel.Size = new Size(266, 58);
            savedRowPanel.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 14.25F);
            label2.Location = new Point(11, 25);
            label2.Name = "label2";
            label2.Size = new Size(123, 27);
            label2.TabIndex = 2;
            label2.Text = "Total Saved:";
            // 
            // discountLabel
            // 
            discountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            discountLabel.AutoSize = true;
            discountLabel.Font = new Font("Inter", 14.25F);
            discountLabel.Location = new Point(209, 17);
            discountLabel.Name = "discountLabel";
            discountLabel.Size = new Size(64, 27);
            discountLabel.TabIndex = 1;
            discountLabel.Text = "label1";
            discountLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // totalRowPanel
            // 
            totalRowPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            totalRowPanel.BackColor = SystemColors.Control;
            totalRowPanel.Controls.Add(label1);
            totalRowPanel.Controls.Add(totalLabel);
            totalRowPanel.Location = new Point(4, 151);
            totalRowPanel.Name = "totalRowPanel";
            totalRowPanel.Size = new Size(266, 51);
            totalRowPanel.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 18F, FontStyle.Bold);
            label1.Location = new Point(16, 12);
            label1.Name = "label1";
            label1.Size = new Size(82, 35);
            label1.TabIndex = 1;
            label1.Text = "Total:";
            // 
            // totalLabel
            // 
            totalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            totalLabel.AutoSize = true;
            totalLabel.Font = new Font("Inter", 18F, FontStyle.Bold);
            totalLabel.Location = new Point(108, 12);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(178, 35);
            totalLabel.TabIndex = 0;
            totalLabel.Text = "label1jhgjhgjg";
            totalLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // actionPanel
            // 
            actionPanel.BackColor = SystemColors.Control;
            actionPanel.Controls.Add(flowLayoutPanel1);
            actionPanel.Dock = DockStyle.Right;
            actionPanel.Location = new Point(340, 0);
            actionPanel.Name = "actionPanel";
            actionPanel.Size = new Size(357, 217);
            actionPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(removeOneBtn);
            flowLayoutPanel1.Controls.Add(removeAllBtn);
            flowLayoutPanel1.Controls.Add(clearTableBtn);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 0, 30, 0);
            flowLayoutPanel1.Size = new Size(357, 217);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // removeOneBtn
            // 
            removeOneBtn.Location = new Point(172, 5);
            removeOneBtn.Margin = new Padding(5);
            removeOneBtn.Name = "removeOneBtn";
            removeOneBtn.OverrideDefault.Back.Color1 = Color.Brown;
            removeOneBtn.OverrideDefault.Back.Color2 = Color.Brown;
            removeOneBtn.OverrideDefault.Content.ShortText.Color1 = SystemColors.Control;
            removeOneBtn.Size = new Size(150, 50);
            removeOneBtn.StateCommon.Back.Color1 = Color.Brown;
            removeOneBtn.StateCommon.Back.Color2 = Color.Brown;
            removeOneBtn.StateCommon.Border.Rounding = 5F;
            removeOneBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            removeOneBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 14.25F, FontStyle.Bold);
            removeOneBtn.TabIndex = 0;
            removeOneBtn.Values.DropDownArrowColor = Color.Empty;
            removeOneBtn.Values.Text = "Remove One";
            // 
            // removeAllBtn
            // 
            removeAllBtn.Location = new Point(12, 5);
            removeAllBtn.Margin = new Padding(5);
            removeAllBtn.Name = "removeAllBtn";
            removeAllBtn.OverrideDefault.Back.Color1 = Color.Brown;
            removeAllBtn.OverrideDefault.Back.Color2 = Color.Brown;
            removeAllBtn.OverrideDefault.Content.ShortText.Color1 = SystemColors.Control;
            removeAllBtn.Size = new Size(150, 50);
            removeAllBtn.StateCommon.Back.Color1 = Color.Brown;
            removeAllBtn.StateCommon.Back.Color2 = Color.Brown;
            removeAllBtn.StateCommon.Border.Rounding = 5F;
            removeAllBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            removeAllBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 14.25F, FontStyle.Bold);
            removeAllBtn.TabIndex = 1;
            removeAllBtn.Values.DropDownArrowColor = Color.Empty;
            removeAllBtn.Values.Text = "Remove All";
            // 
            // clearTableBtn
            // 
            clearTableBtn.Location = new Point(172, 65);
            clearTableBtn.Margin = new Padding(5);
            clearTableBtn.Name = "clearTableBtn";
            clearTableBtn.OverrideDefault.Back.Color1 = Color.Brown;
            clearTableBtn.OverrideDefault.Back.Color2 = Color.Brown;
            clearTableBtn.OverrideDefault.Content.ShortText.Color1 = SystemColors.Control;
            clearTableBtn.Size = new Size(150, 50);
            clearTableBtn.StateCommon.Back.Color1 = Color.Brown;
            clearTableBtn.StateCommon.Back.Color2 = Color.Brown;
            clearTableBtn.StateCommon.Border.Rounding = 5F;
            clearTableBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            clearTableBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 14.25F, FontStyle.Bold);
            clearTableBtn.TabIndex = 2;
            clearTableBtn.Values.DropDownArrowColor = Color.Empty;
            clearTableBtn.Values.Text = "Clear Table";
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(backBtn);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1101, 75);
            headerPanel.StateCommon.Color1 = SystemColors.Control;
            headerPanel.TabIndex = 3;
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
            backBtn.TabIndex = 0;
            backBtn.Values.DropDownArrowColor = Color.Empty;
            backBtn.Values.Text = "↩";
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(transactionPanel);
            leftPanel.Controls.Add(totalPanel);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 75);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(697, 538);
            leftPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(productsPanel);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(901, 75);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(200, 538);
            rightPanel.TabIndex = 1;
            // 
            // MainTransaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(leftPanel);
            Controls.Add(rightPanel);
            Controls.Add(headerPanel);
            Name = "MainTransaction";
            Size = new Size(1101, 613);
            Resize += MainTransaction_Resize;
            ((System.ComponentModel.ISupportInitialize)productsPanel).EndInit();
            productsPanel.ResumeLayout(false);
            productsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)transactionPanel).EndInit();
            transactionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)transactionGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)totalPanel).EndInit();
            totalPanel.ResumeLayout(false);
            totalListPanel.ResumeLayout(false);
            subTotalRowPanel.ResumeLayout(false);
            subTotalRowPanel.PerformLayout();
            savedRowPanel.ResumeLayout(false);
            savedRowPanel.PerformLayout();
            totalRowPanel.ResumeLayout(false);
            totalRowPanel.PerformLayout();
            actionPanel.ResumeLayout(false);
            actionPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel productsPanel;
        private Krypton.Toolkit.KryptonPanel transactionPanel;
        private Krypton.Toolkit.KryptonPanel totalPanel;
        private Krypton.Toolkit.KryptonDataGridView transactionGrid;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private FlowLayoutPanel productButtonPanel;
        private Krypton.Toolkit.KryptonPanel headerPanel;
        private Panel leftPanel;
        private Panel rightPanel;
        private Panel totalListPanel;
        private Panel actionPanel;
        private Krypton.Toolkit.KryptonButton removeOneBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private Krypton.Toolkit.KryptonButton removeAllBtn;
        private Label totalLabel;
        private Krypton.Toolkit.KryptonButton clearTableBtn;
        private Krypton.Toolkit.KryptonButton backBtn;
        private Label subTotalLabel;
        private Label discountLabel;
        private Panel savedRowPanel;
        private Label label2;
        private Panel totalRowPanel;
        private Label label1;
        private Panel subTotalRowPanel;
        private Label label3;
    }
}
