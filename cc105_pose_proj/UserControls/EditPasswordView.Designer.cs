namespace cc105_pose_proj.UserControls
{
    partial class EditPasswordView
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
            oldPasswordField = new Krypton.Toolkit.KryptonTextBox();
            oldPasswordLabel = new Label();
            newPasswordField = new Krypton.Toolkit.KryptonTextBox();
            newPasswordLabel = new Label();
            showOldPasswordCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            showNewPasswordCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            buttonPanel = new Panel();
            confirmBtn = new Krypton.Toolkit.KryptonButton();
            cancelBtn = new Krypton.Toolkit.KryptonButton();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // oldPasswordField
            // 
            oldPasswordField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            oldPasswordField.Location = new Point(20, 32);
            oldPasswordField.Margin = new Padding(0);
            oldPasswordField.Name = "oldPasswordField";
            oldPasswordField.Size = new Size(335, 31);
            oldPasswordField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            oldPasswordField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            oldPasswordField.StateCommon.Border.Rounding = 5F;
            oldPasswordField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            oldPasswordField.StateCommon.Content.Padding = new Padding(5);
            oldPasswordField.TabIndex = 7;
            // 
            // oldPasswordLabel
            // 
            oldPasswordLabel.AutoSize = true;
            oldPasswordLabel.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            oldPasswordLabel.Location = new Point(20, 10);
            oldPasswordLabel.Margin = new Padding(0);
            oldPasswordLabel.Name = "oldPasswordLabel";
            oldPasswordLabel.Size = new Size(141, 22);
            oldPasswordLabel.TabIndex = 6;
            oldPasswordLabel.Text = "Current Password";
            // 
            // newPasswordField
            // 
            newPasswordField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newPasswordField.Location = new Point(20, 114);
            newPasswordField.Margin = new Padding(0);
            newPasswordField.Name = "newPasswordField";
            newPasswordField.Size = new Size(329, 31);
            newPasswordField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            newPasswordField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            newPasswordField.StateCommon.Border.Rounding = 5F;
            newPasswordField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newPasswordField.StateCommon.Content.Padding = new Padding(5);
            newPasswordField.TabIndex = 9;
            // 
            // newPasswordLabel
            // 
            newPasswordLabel.AutoSize = true;
            newPasswordLabel.Font = new Font("Inter", 11.25F, FontStyle.Bold);
            newPasswordLabel.Location = new Point(20, 92);
            newPasswordLabel.Margin = new Padding(0);
            newPasswordLabel.Name = "newPasswordLabel";
            newPasswordLabel.Size = new Size(119, 22);
            newPasswordLabel.TabIndex = 8;
            newPasswordLabel.Text = "New Password";
            // 
            // showOldPasswordCheckBox
            // 
            showOldPasswordCheckBox.Location = new Point(25, 68);
            showOldPasswordCheckBox.Margin = new Padding(5);
            showOldPasswordCheckBox.Name = "showOldPasswordCheckBox";
            showOldPasswordCheckBox.Size = new Size(165, 19);
            showOldPasswordCheckBox.StateCommon.ShortText.Color1 = SystemColors.ControlText;
            showOldPasswordCheckBox.StateCommon.ShortText.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showOldPasswordCheckBox.TabIndex = 10;
            showOldPasswordCheckBox.Values.Text = "Show Current Password";
            // 
            // showNewPasswordCheckBox
            // 
            showNewPasswordCheckBox.Location = new Point(25, 150);
            showNewPasswordCheckBox.Margin = new Padding(5);
            showNewPasswordCheckBox.Name = "showNewPasswordCheckBox";
            showNewPasswordCheckBox.Size = new Size(147, 19);
            showNewPasswordCheckBox.StateCommon.ShortText.Color1 = SystemColors.ControlText;
            showNewPasswordCheckBox.StateCommon.ShortText.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showNewPasswordCheckBox.TabIndex = 11;
            showNewPasswordCheckBox.Values.Text = "Show New Password";
            // 
            // buttonPanel
            // 
            buttonPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonPanel.Controls.Add(confirmBtn);
            buttonPanel.Controls.Add(cancelBtn);
            buttonPanel.Location = new Point(78, 178);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(215, 42);
            buttonPanel.TabIndex = 12;
            // 
            // confirmBtn
            // 
            confirmBtn.Location = new Point(5, 5);
            confirmBtn.Margin = new Padding(5);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            confirmBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
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
            // EditPasswordView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonPanel);
            Controls.Add(showNewPasswordCheckBox);
            Controls.Add(showOldPasswordCheckBox);
            Controls.Add(newPasswordField);
            Controls.Add(newPasswordLabel);
            Controls.Add(oldPasswordField);
            Controls.Add(oldPasswordLabel);
            Name = "EditPasswordView";
            Padding = new Padding(20, 10, 20, 10);
            Size = new Size(375, 233);
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox oldPasswordField;
        private Label oldPasswordLabel;
        private Krypton.Toolkit.KryptonTextBox newPasswordField;
        private Label newPasswordLabel;
        private Krypton.Toolkit.KryptonCheckBox showOldPasswordCheckBox;
        private Krypton.Toolkit.KryptonCheckBox showNewPasswordCheckBox;
        private Panel buttonPanel;
        private Krypton.Toolkit.KryptonButton confirmBtn;
        private Krypton.Toolkit.KryptonButton cancelBtn;
    }
}
