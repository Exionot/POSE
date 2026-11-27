namespace cc105_pose_proj.Forms
{
    partial class BuyerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyerForm));
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            adPanel = new PictureBox();
            transactionPanel = new cc105_pose_proj.Controls.RoundedKryptonPanel();
            transactionGrid = new Krypton.Toolkit.KryptonDataGridView();
            totalsPanel = new Panel();
            changeRowPanel = new Panel();
            label4 = new Label();
            changeLabel = new Label();
            subTotalRowPanel = new Panel();
            label3 = new Label();
            subTotalLabel = new Label();
            totalRowPanel = new Panel();
            label1 = new Label();
            totalLabel = new Label();
            savedRowPanel = new Panel();
            label2 = new Label();
            discountLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)adPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transactionPanel).BeginInit();
            transactionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)transactionGrid).BeginInit();
            totalsPanel.SuspendLayout();
            changeRowPanel.SuspendLayout();
            subTotalRowPanel.SuspendLayout();
            totalRowPanel.SuspendLayout();
            savedRowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(adPanel);
            kryptonPanel1.Controls.Add(transactionPanel);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Margin = new Padding(0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(800, 450);
            kryptonPanel1.StateCommon.Color1 = Color.FromArgb(192, 0, 0, 0);
            kryptonPanel1.TabIndex = 0;
            // 
            // adPanel
            // 
            adPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            adPanel.BackColor = Color.Transparent;
            adPanel.Image = (Image)resources.GetObject("adPanel.Image");
            adPanel.Location = new Point(0, 0);
            adPanel.Margin = new Padding(30, 30, 15, 30);
            adPanel.Name = "adPanel";
            adPanel.Size = new Size(350, 450);
            adPanel.SizeMode = PictureBoxSizeMode.Zoom;
            adPanel.TabIndex = 1;
            adPanel.TabStop = false;
            // 
            // transactionPanel
            // 
            transactionPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            transactionPanel.Controls.Add(transactionGrid);
            transactionPanel.Controls.Add(totalsPanel);
            transactionPanel.CornerRadius = 20;
            transactionPanel.Location = new Point(380, 0);
            transactionPanel.Margin = new Padding(15, 30, 30, 30);
            transactionPanel.Name = "transactionPanel";
            transactionPanel.Padding = new Padding(30);
            transactionPanel.Size = new Size(360, 450);
            transactionPanel.StateCommon.Color1 = SystemColors.Control;
            transactionPanel.TabIndex = 0;
            // 
            // transactionGrid
            // 
            transactionGrid.AllowUserToAddRows = false;
            transactionGrid.AllowUserToDeleteRows = false;
            transactionGrid.AllowUserToResizeRows = false;
            transactionGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            transactionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            transactionGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            transactionGrid.BorderStyle = BorderStyle.None;
            transactionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            transactionGrid.Location = new Point(30, 30);
            transactionGrid.Margin = new Padding(0, 0, 0, 10);
            transactionGrid.MultiSelect = false;
            transactionGrid.Name = "transactionGrid";
            transactionGrid.ReadOnly = true;
            transactionGrid.RowHeadersVisible = false;
            transactionGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            transactionGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            transactionGrid.Size = new Size(300, 307);
            transactionGrid.StateCommon.Background.Color1 = SystemColors.Control;
            transactionGrid.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            transactionGrid.StateCommon.DataCell.Back.Color1 = SystemColors.Control;
            transactionGrid.StateCommon.DataCell.Border.Color1 = SystemColors.ActiveBorder;
            transactionGrid.StateCommon.DataCell.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom;
            transactionGrid.StateCommon.DataCell.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            transactionGrid.StateCommon.DataCell.Content.Padding = new Padding(5);
            transactionGrid.StateCommon.HeaderColumn.Back.Color1 = Color.Goldenrod;
            transactionGrid.StateCommon.HeaderColumn.Back.Color2 = Color.Goldenrod;
            transactionGrid.StateCommon.HeaderColumn.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            transactionGrid.StateCommon.HeaderColumn.Content.Color1 = SystemColors.Control;
            transactionGrid.StateCommon.HeaderColumn.Content.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            transactionGrid.StateCommon.HeaderRow.Back.Color1 = SystemColors.Control;
            transactionGrid.StateCommon.HeaderRow.Back.Color2 = SystemColors.Control;
            transactionGrid.TabIndex = 3;
            // 
            // totalsPanel
            // 
            totalsPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            totalsPanel.BackColor = SystemColors.Control;
            totalsPanel.Controls.Add(changeRowPanel);
            totalsPanel.Controls.Add(subTotalRowPanel);
            totalsPanel.Controls.Add(totalRowPanel);
            totalsPanel.Controls.Add(savedRowPanel);
            totalsPanel.Location = new Point(30, 337);
            totalsPanel.Margin = new Padding(0);
            totalsPanel.Name = "totalsPanel";
            totalsPanel.Size = new Size(300, 83);
            totalsPanel.TabIndex = 2;
            // 
            // changeRowPanel
            // 
            changeRowPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            changeRowPanel.BackColor = SystemColors.Control;
            changeRowPanel.Controls.Add(label4);
            changeRowPanel.Controls.Add(changeLabel);
            changeRowPanel.Location = new Point(0, 193);
            changeRowPanel.Name = "changeRowPanel";
            changeRowPanel.Size = new Size(266, 51);
            changeRowPanel.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Inter", 18F, FontStyle.Bold);
            label4.Location = new Point(16, 12);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(114, 35);
            label4.TabIndex = 1;
            label4.Text = "Change:";
            // 
            // changeLabel
            // 
            changeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            changeLabel.AutoSize = true;
            changeLabel.Font = new Font("Inter", 18F, FontStyle.Bold);
            changeLabel.Location = new Point(191, 12);
            changeLabel.Margin = new Padding(0);
            changeLabel.Name = "changeLabel";
            changeLabel.Size = new Size(72, 35);
            changeLabel.TabIndex = 0;
            changeLabel.Text = "label";
            changeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // subTotalRowPanel
            // 
            subTotalRowPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            subTotalRowPanel.BackColor = SystemColors.Control;
            subTotalRowPanel.Controls.Add(label3);
            subTotalRowPanel.Controls.Add(subTotalLabel);
            subTotalRowPanel.Location = new Point(0, 0);
            subTotalRowPanel.Margin = new Padding(0);
            subTotalRowPanel.Name = "subTotalRowPanel";
            subTotalRowPanel.Size = new Size(266, 66);
            subTotalRowPanel.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 14.25F);
            label3.Location = new Point(24, 19);
            label3.Margin = new Padding(0);
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
            subTotalLabel.Location = new Point(186, 19);
            subTotalLabel.Margin = new Padding(0);
            subTotalLabel.Name = "subTotalLabel";
            subTotalLabel.Size = new Size(68, 27);
            subTotalLabel.TabIndex = 2;
            subTotalLabel.Text = "label2";
            subTotalLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // totalRowPanel
            // 
            totalRowPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            totalRowPanel.BackColor = SystemColors.Control;
            totalRowPanel.Controls.Add(label1);
            totalRowPanel.Controls.Add(totalLabel);
            totalRowPanel.Location = new Point(0, 136);
            totalRowPanel.Name = "totalRowPanel";
            totalRowPanel.Size = new Size(266, 51);
            totalRowPanel.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 18F, FontStyle.Bold);
            label1.Location = new Point(16, 12);
            label1.Margin = new Padding(0);
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
            totalLabel.Location = new Point(191, 12);
            totalLabel.Margin = new Padding(0);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(72, 35);
            totalLabel.TabIndex = 0;
            totalLabel.Text = "label";
            totalLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // savedRowPanel
            // 
            savedRowPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            savedRowPanel.BackColor = SystemColors.Control;
            savedRowPanel.Controls.Add(label2);
            savedRowPanel.Controls.Add(discountLabel);
            savedRowPanel.Location = new Point(0, 72);
            savedRowPanel.Name = "savedRowPanel";
            savedRowPanel.Size = new Size(266, 58);
            savedRowPanel.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 14.25F);
            label2.Location = new Point(11, 25);
            label2.Margin = new Padding(0);
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
            discountLabel.Location = new Point(186, 25);
            discountLabel.Margin = new Padding(0);
            discountLabel.Name = "discountLabel";
            discountLabel.Size = new Size(64, 27);
            discountLabel.TabIndex = 1;
            discountLabel.Text = "label1";
            discountLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BuyerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(kryptonPanel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BuyerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuyerForm";
            WindowState = FormWindowState.Maximized;
            Resize += BuyerForm_Resize;
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)adPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)transactionPanel).EndInit();
            transactionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)transactionGrid).EndInit();
            totalsPanel.ResumeLayout(false);
            changeRowPanel.ResumeLayout(false);
            changeRowPanel.PerformLayout();
            subTotalRowPanel.ResumeLayout(false);
            subTotalRowPanel.PerformLayout();
            totalRowPanel.ResumeLayout(false);
            totalRowPanel.PerformLayout();
            savedRowPanel.ResumeLayout(false);
            savedRowPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Controls.RoundedKryptonPanel transactionPanel;
        private PictureBox adPanel;
        private Krypton.Toolkit.KryptonDataGridView transactionGrid;
        private Panel totalsPanel;
        private Panel subTotalRowPanel;
        private Label label3;
        private Label subTotalLabel;
        private Panel savedRowPanel;
        private Label label2;
        private Label discountLabel;
        private Panel totalRowPanel;
        private Label label1;
        private Label totalLabel;
        private Panel changeRowPanel;
        private Label label4;
        private Label changeLabel;
    }
}