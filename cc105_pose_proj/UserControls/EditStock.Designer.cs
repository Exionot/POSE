using cc105_pose_proj.Util;

namespace cc105_pose_proj.UserControls
{
    partial class EditStock
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
            stockField = new Krypton.Toolkit.KryptonTextBox();
            label3 = new Label();
            label1 = new Label();
            movementReasonComboBox = new Krypton.Toolkit.KryptonComboBox();
            buttonPanel = new Panel();
            confirmBtn = new Krypton.Toolkit.KryptonButton();
            cancelBtn = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)movementReasonComboBox).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // stockField
            // 
            stockField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            stockField.Location = new Point(23, 35);
            stockField.Margin = new Padding(3, 3, 3, 10);
            stockField.Name = "stockField";
            stockField.Size = new Size(293, 31);
            stockField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            stockField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            stockField.StateCommon.Border.Rounding = 5F;
            stockField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stockField.StateCommon.Content.Padding = new Padding(5);
            stockField.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label3.Location = new Point(23, 10);
            label3.Name = "label3";
            label3.Size = new Size(52, 22);
            label3.TabIndex = 4;
            label3.Text = "Stock";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            label1.Location = new Point(23, 76);
            label1.Name = "label1";
            label1.Size = new Size(64, 22);
            label1.TabIndex = 6;
            label1.Text = "Reason";
            // 
            // movementReasonComboBox
            // 
            movementReasonComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            movementReasonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            movementReasonComboBox.Location = new Point(23, 101);
            movementReasonComboBox.Margin = new Padding(3, 3, 3, 10);
            movementReasonComboBox.MinimumSize = new Size(0, 30);
            movementReasonComboBox.Name = "movementReasonComboBox";
            movementReasonComboBox.Size = new Size(293, 30);
            movementReasonComboBox.StateCommon.ComboBox.Border.Rounding = 5F;
            movementReasonComboBox.StateCommon.ComboBox.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            movementReasonComboBox.StateCommon.ComboBox.Content.Padding = new Padding(5, -1, 15, -1);
            movementReasonComboBox.StateCommon.Item.Content.Padding = new Padding(5);
            movementReasonComboBox.StateCommon.Item.Content.ShortText.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            movementReasonComboBox.TabIndex = 7;
            // 
            // buttonPanel
            // 
            buttonPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonPanel.Controls.Add(confirmBtn);
            buttonPanel.Controls.Add(cancelBtn);
            buttonPanel.Location = new Point(59, 142);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(215, 42);
            buttonPanel.TabIndex = 8;
            // 
            // confirmBtn
            // 
            confirmBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            confirmBtn.Enabled = false;
            confirmBtn.Location = new Point(6, 5);
            confirmBtn.Margin = new Padding(5);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(97, 31);
            confirmBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            confirmBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            confirmBtn.StateCommon.Border.Rounding = 5F;
            confirmBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            confirmBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmBtn.StateDisabled.Back.Color1 = Color.Khaki;
            confirmBtn.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            confirmBtn.TabIndex = 4;
            confirmBtn.Values.DropDownArrowColor = Color.Empty;
            confirmBtn.Values.Text = "Confirm";
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelBtn.Location = new Point(113, 5);
            cancelBtn.Margin = new Padding(5);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.OverrideDefault.Back.Color1 = SystemColors.ControlLight;
            cancelBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            cancelBtn.Size = new Size(97, 31);
            cancelBtn.StateCommon.Back.Color1 = SystemColors.ControlLight;
            cancelBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            cancelBtn.StateCommon.Border.Rounding = 5F;
            cancelBtn.StateCommon.Content.ShortText.Color1 = SystemColors.ControlText;
            cancelBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelBtn.TabIndex = 3;
            cancelBtn.Values.DropDownArrowColor = Color.Empty;
            cancelBtn.Values.Text = "Cancel";
            // 
            // EditStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonPanel);
            Controls.Add(movementReasonComboBox);
            Controls.Add(label1);
            Controls.Add(stockField);
            Controls.Add(label3);
            Name = "EditStock";
            Padding = new Padding(20, 10, 20, 10);
            Size = new Size(339, 197);
            Load += EditStock_Load;
            ((System.ComponentModel.ISupportInitialize)movementReasonComboBox).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox stockField;
        private Label label3;
        private Label label1;
        private Krypton.Toolkit.KryptonComboBox movementReasonComboBox;
        private Panel buttonPanel;
        private Krypton.Toolkit.KryptonButton confirmBtn;
        private Krypton.Toolkit.KryptonButton cancelBtn;
    }
}
