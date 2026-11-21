using cc105_pose_proj.Util;

namespace cc105_pose_proj.UserControls
{
    partial class EditDiscount
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
            deleteBtn = new Krypton.Toolkit.KryptonButton();
            saveBtn = new Krypton.Toolkit.KryptonButton();
            backBtn = new Krypton.Toolkit.KryptonButton();
            infoPanel = new Panel();
            panel1 = new Panel();
            businessComboBox = new Krypton.Toolkit.KryptonComboBox();
            label5 = new Label();
            itemsRowPanel = new Panel();
            productFlowPanel = new FlowLayoutPanel();
            label4 = new Label();
            panel2 = new Panel();
            getField = new Krypton.Toolkit.KryptonTextBox();
            getLabel = new Label();
            valueField = new Krypton.Toolkit.KryptonTextBox();
            valueLabel = new Label();
            panel4 = new Panel();
            discountTypeComboBox = new Krypton.Toolkit.KryptonComboBox();
            label2 = new Label();
            nameRowPanel = new Panel();
            nameField = new Krypton.Toolkit.KryptonTextBox();
            label1 = new Label();
            headerPanel.SuspendLayout();
            infoPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)businessComboBox).BeginInit();
            itemsRowPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)discountTypeComboBox).BeginInit();
            nameRowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = SystemColors.Control;
            headerPanel.Controls.Add(deleteBtn);
            headerPanel.Controls.Add(saveBtn);
            headerPanel.Controls.Add(backBtn);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(20, 15, 20, 15);
            headerPanel.Size = new Size(450, 59);
            headerPanel.TabIndex = 6;
            // 
            // deleteBtn
            // 
            deleteBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteBtn.Location = new Point(299, 15);
            deleteBtn.Margin = new Padding(0);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.OverrideDefault.Back.Color1 = Color.Brown;
            deleteBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            deleteBtn.Size = new Size(67, 30);
            deleteBtn.StateCommon.Back.Color1 = Color.Brown;
            deleteBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            deleteBtn.StateCommon.Border.Rounding = 5F;
            deleteBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            deleteBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteBtn.TabIndex = 3;
            deleteBtn.Values.DropDownArrowColor = Color.Empty;
            deleteBtn.Values.Text = "Delete";
            deleteBtn.Click += deleteBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveBtn.Location = new Point(376, 15);
            saveBtn.Margin = new Padding(10, 0, 0, 0);
            saveBtn.Name = "saveBtn";
            saveBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            saveBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            saveBtn.Size = new Size(54, 30);
            saveBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            saveBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            saveBtn.StateCommon.Border.Rounding = 5F;
            saveBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            saveBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveBtn.TabIndex = 2;
            saveBtn.Values.DropDownArrowColor = Color.Empty;
            saveBtn.Values.Text = "Save";
            saveBtn.Click += saveBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(20, 15);
            backBtn.Margin = new Padding(0);
            backBtn.Name = "backBtn";
            backBtn.OverrideDefault.Back.Color1 = Color.Brown;
            backBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            backBtn.Size = new Size(30, 29);
            backBtn.StateCommon.Back.Color1 = Color.Brown;
            backBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            backBtn.StateCommon.Border.Rounding = 5F;
            backBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            backBtn.StateCommon.Content.ShortText.Font = new Font("Inter Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backBtn.TabIndex = 2;
            backBtn.Values.DropDownArrowColor = Color.Empty;
            backBtn.Values.Text = "↩";
            backBtn.Click += backBtn_Click;
            // 
            // infoPanel
            // 
            infoPanel.Controls.Add(panel1);
            infoPanel.Controls.Add(itemsRowPanel);
            infoPanel.Controls.Add(panel2);
            infoPanel.Controls.Add(panel4);
            infoPanel.Controls.Add(nameRowPanel);
            infoPanel.Dock = DockStyle.Top;
            infoPanel.Location = new Point(0, 59);
            infoPanel.Margin = new Padding(0);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(450, 476);
            infoPanel.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(businessComboBox);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(7, 178);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20, 10, 20, 10);
            panel1.Size = new Size(440, 83);
            panel1.TabIndex = 10;
            // 
            // businessComboBox
            // 
            businessComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            businessComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            businessComboBox.Location = new Point(20, 40);
            businessComboBox.MinimumSize = new Size(0, 30);
            businessComboBox.Name = "businessComboBox";
            businessComboBox.Size = new Size(394, 30);
            businessComboBox.StateCommon.ComboBox.Border.Rounding = 5F;
            businessComboBox.StateCommon.ComboBox.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            businessComboBox.StateCommon.ComboBox.Content.Padding = new Padding(5, -1, 15, -1);
            businessComboBox.StateCommon.Item.Content.Padding = new Padding(5);
            businessComboBox.StateCommon.Item.Content.ShortText.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            businessComboBox.TabIndex = 5;
            businessComboBox.SelectedIndexChanged += businessComboBox_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label5.Location = new Point(20, 10);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 0, 0, 5);
            label5.Size = new Size(75, 27);
            label5.TabIndex = 0;
            label5.Text = "Business";
            // 
            // itemsRowPanel
            // 
            itemsRowPanel.BackColor = SystemColors.Control;
            itemsRowPanel.Controls.Add(productFlowPanel);
            itemsRowPanel.Controls.Add(label4);
            itemsRowPanel.Location = new Point(7, 370);
            itemsRowPanel.Margin = new Padding(0);
            itemsRowPanel.Name = "itemsRowPanel";
            itemsRowPanel.Padding = new Padding(20, 10, 20, 10);
            itemsRowPanel.Size = new Size(440, 104);
            itemsRowPanel.TabIndex = 12;
            // 
            // productFlowPanel
            // 
            productFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            productFlowPanel.AutoScroll = true;
            productFlowPanel.BackColor = SystemColors.Control;
            productFlowPanel.Location = new Point(20, 47);
            productFlowPanel.Margin = new Padding(0);
            productFlowPanel.Name = "productFlowPanel";
            productFlowPanel.Size = new Size(400, 47);
            productFlowPanel.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label4.Location = new Point(17, 20);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 0, 0, 5);
            label4.Size = new Size(131, 27);
            label4.TabIndex = 0;
            label4.Text = "Eligible Products";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(getField);
            panel2.Controls.Add(getLabel);
            panel2.Controls.Add(valueField);
            panel2.Controls.Add(valueLabel);
            panel2.Location = new Point(7, 271);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20, 10, 20, 10);
            panel2.Size = new Size(440, 83);
            panel2.TabIndex = 11;
            // 
            // getField
            // 
            getField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            getField.Location = new Point(230, 37);
            getField.Margin = new Padding(10, 0, 0, 0);
            getField.Name = "getField";
            getField.Size = new Size(184, 31);
            getField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            getField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            getField.StateCommon.Border.Rounding = 5F;
            getField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            getField.StateCommon.Content.Padding = new Padding(5);
            getField.TabIndex = 3;
            // 
            // getLabel
            // 
            getLabel.AutoSize = true;
            getLabel.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            getLabel.Location = new Point(230, 10);
            getLabel.Margin = new Padding(0);
            getLabel.Name = "getLabel";
            getLabel.Padding = new Padding(0, 0, 0, 5);
            getLabel.Size = new Size(35, 27);
            getLabel.TabIndex = 2;
            getLabel.Text = "Get";
            // 
            // valueField
            // 
            valueField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valueField.Location = new Point(20, 37);
            valueField.Margin = new Padding(0);
            valueField.Name = "valueField";
            valueField.Size = new Size(200, 31);
            valueField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            valueField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            valueField.StateCommon.Border.Rounding = 5F;
            valueField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valueField.StateCommon.Content.Padding = new Padding(5);
            valueField.TabIndex = 1;
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            valueLabel.Location = new Point(17, 10);
            valueLabel.Margin = new Padding(0);
            valueLabel.Name = "valueLabel";
            valueLabel.Padding = new Padding(0, 0, 0, 5);
            valueLabel.Size = new Size(51, 27);
            valueLabel.TabIndex = 0;
            valueLabel.Text = "Value";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(discountTypeComboBox);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(4, 91);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(20, 10, 20, 10);
            panel4.Size = new Size(440, 83);
            panel4.TabIndex = 9;
            // 
            // discountTypeComboBox
            // 
            discountTypeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            discountTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            discountTypeComboBox.Location = new Point(23, 40);
            discountTypeComboBox.MinimumSize = new Size(0, 30);
            discountTypeComboBox.Name = "discountTypeComboBox";
            discountTypeComboBox.Size = new Size(394, 30);
            discountTypeComboBox.StateCommon.ComboBox.Border.Rounding = 5F;
            discountTypeComboBox.StateCommon.ComboBox.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            discountTypeComboBox.StateCommon.ComboBox.Content.Padding = new Padding(5, -1, 15, -1);
            discountTypeComboBox.StateCommon.Item.Content.Padding = new Padding(5);
            discountTypeComboBox.StateCommon.Item.Content.ShortText.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            discountTypeComboBox.TabIndex = 5;
            discountTypeComboBox.SelectedIndexChanged += discountTypeComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label2.Location = new Point(17, 10);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 0, 5);
            label2.Size = new Size(46, 27);
            label2.TabIndex = 0;
            label2.Text = "Type";
            // 
            // nameRowPanel
            // 
            nameRowPanel.BackColor = SystemColors.Control;
            nameRowPanel.Controls.Add(nameField);
            nameRowPanel.Controls.Add(label1);
            nameRowPanel.Location = new Point(4, 2);
            nameRowPanel.Margin = new Padding(0);
            nameRowPanel.Name = "nameRowPanel";
            nameRowPanel.Padding = new Padding(20, 10, 20, 10);
            nameRowPanel.Size = new Size(440, 83);
            nameRowPanel.TabIndex = 8;
            // 
            // nameField
            // 
            nameField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameField.Location = new Point(20, 42);
            nameField.Margin = new Padding(0);
            nameField.Name = "nameField";
            nameField.Size = new Size(400, 31);
            nameField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            nameField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            nameField.StateCommon.Border.Rounding = 5F;
            nameField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameField.StateCommon.Content.Padding = new Padding(5);
            nameField.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label1.Location = new Point(20, 15);
            label1.Margin = new Padding(0, 0, 0, 5);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 5);
            label1.Size = new Size(121, 27);
            label1.TabIndex = 0;
            label1.Text = "Discount Name";
            // 
            // EditDiscount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(infoPanel);
            Controls.Add(headerPanel);
            Name = "EditDiscount";
            Size = new Size(450, 535);
            Load += EditDiscount_Load;
            Resize += EditDiscount_Resize;
            headerPanel.ResumeLayout(false);
            infoPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)businessComboBox).EndInit();
            itemsRowPanel.ResumeLayout(false);
            itemsRowPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)discountTypeComboBox).EndInit();
            nameRowPanel.ResumeLayout(false);
            nameRowPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel headerPanel;
        private Krypton.Toolkit.KryptonButton deleteBtn;
        private Krypton.Toolkit.KryptonButton saveBtn;
        private Krypton.Toolkit.KryptonButton backBtn;
        private Panel infoPanel;
        private Panel itemsRowPanel;
        private FlowLayoutPanel productFlowPanel;
        private Label label4;
        private Panel panel2;
        private Krypton.Toolkit.KryptonTextBox valueField;
        private Label valueLabel;
        private Panel panel4;
        private Krypton.Toolkit.KryptonComboBox discountTypeComboBox;
        private Label label2;
        private Panel nameRowPanel;
        private Krypton.Toolkit.KryptonTextBox nameField;
        private Label label1;
        private Panel panel1;
        private Krypton.Toolkit.KryptonComboBox businessComboBox;
        private Label label5;
        private Krypton.Toolkit.KryptonTextBox getField;
        private Label getLabel;
    }
}
