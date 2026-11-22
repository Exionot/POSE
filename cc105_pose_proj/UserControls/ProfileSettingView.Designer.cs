namespace cc105_pose_proj.UserControls
{
    partial class ProfileSettingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileSettingView));
            headerPanel = new Panel();
            saveBtn = new Krypton.Toolkit.KryptonButton();
            backBtn = new Krypton.Toolkit.KryptonButton();
            profilePictureBox = new PictureBox();
            panel1 = new Panel();
            nameField = new Krypton.Toolkit.KryptonTextBox();
            nameLabel = new Label();
            selectImgBtn = new Krypton.Toolkit.KryptonButton();
            panel2 = new Panel();
            showPasswordCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            editPasswordBtn = new Krypton.Toolkit.KryptonButton();
            passwordField = new Krypton.Toolkit.KryptonTextBox();
            passwordLabel = new Label();
            panel3 = new Panel();
            businessComboBox = new Krypton.Toolkit.KryptonComboBox();
            businessLabel = new Label();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profilePictureBox).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)businessComboBox).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = SystemColors.Control;
            headerPanel.Controls.Add(saveBtn);
            headerPanel.Controls.Add(backBtn);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(15);
            headerPanel.Size = new Size(359, 57);
            headerPanel.TabIndex = 1;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveBtn.Location = new Point(290, 15);
            saveBtn.Margin = new Padding(0);
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
            // 
            // backBtn
            // 
            backBtn.Location = new Point(15, 15);
            backBtn.Margin = new Padding(0);
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
            // profilePictureBox
            // 
            profilePictureBox.Image = (Image)resources.GetObject("profilePictureBox.Image");
            profilePictureBox.Location = new Point(102, 80);
            profilePictureBox.Margin = new Padding(0, 20, 0, 0);
            profilePictureBox.Name = "profilePictureBox";
            profilePictureBox.Size = new Size(150, 150);
            profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            profilePictureBox.TabIndex = 2;
            profilePictureBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(nameField);
            panel1.Controls.Add(nameLabel);
            panel1.Location = new Point(3, 273);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20, 10, 20, 10);
            panel1.Size = new Size(353, 80);
            panel1.TabIndex = 3;
            // 
            // nameField
            // 
            nameField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameField.Location = new Point(20, 32);
            nameField.Margin = new Padding(0);
            nameField.Name = "nameField";
            nameField.Size = new Size(313, 31);
            nameField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            nameField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            nameField.StateCommon.Border.Rounding = 5F;
            nameField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameField.StateCommon.Content.Padding = new Padding(5);
            nameField.TabIndex = 2;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Inter", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(20, 10);
            nameLabel.Margin = new Padding(0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(85, 22);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Username";
            // 
            // selectImgBtn
            // 
            selectImgBtn.Location = new Point(122, 235);
            selectImgBtn.Margin = new Padding(5);
            selectImgBtn.Name = "selectImgBtn";
            selectImgBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            selectImgBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            selectImgBtn.Size = new Size(113, 30);
            selectImgBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            selectImgBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            selectImgBtn.StateCommon.Border.Rounding = 5F;
            selectImgBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            selectImgBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectImgBtn.TabIndex = 4;
            selectImgBtn.Values.DropDownArrowColor = Color.Empty;
            selectImgBtn.Values.Text = "Select Image";
            // 
            // panel2
            // 
            panel2.Controls.Add(showPasswordCheckBox);
            panel2.Controls.Add(editPasswordBtn);
            panel2.Controls.Add(passwordField);
            panel2.Controls.Add(passwordLabel);
            panel2.Location = new Point(3, 359);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20, 10, 20, 10);
            panel2.Size = new Size(353, 106);
            panel2.TabIndex = 4;
            // 
            // showPasswordCheckBox
            // 
            showPasswordCheckBox.Location = new Point(25, 66);
            showPasswordCheckBox.Margin = new Padding(5, 3, 0, 0);
            showPasswordCheckBox.Name = "showPasswordCheckBox";
            showPasswordCheckBox.Size = new Size(117, 19);
            showPasswordCheckBox.StateCommon.ShortText.Color1 = SystemColors.ControlText;
            showPasswordCheckBox.StateCommon.ShortText.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPasswordCheckBox.TabIndex = 4;
            showPasswordCheckBox.Values.Text = "Show Password";
            // 
            // editPasswordBtn
            // 
            editPasswordBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editPasswordBtn.Location = new Point(236, 32);
            editPasswordBtn.Margin = new Padding(5, 0, 0, 0);
            editPasswordBtn.Name = "editPasswordBtn";
            editPasswordBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            editPasswordBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            editPasswordBtn.Size = new Size(97, 31);
            editPasswordBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            editPasswordBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            editPasswordBtn.StateCommon.Border.Rounding = 5F;
            editPasswordBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            editPasswordBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editPasswordBtn.StateCommon.Content.ShortText.MultiLineH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            editPasswordBtn.TabIndex = 3;
            editPasswordBtn.Values.DropDownArrowColor = Color.Empty;
            editPasswordBtn.Values.Text = "Change";
            // 
            // passwordField
            // 
            passwordField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            passwordField.Location = new Point(20, 32);
            passwordField.Margin = new Padding(0);
            passwordField.Name = "passwordField";
            passwordField.Size = new Size(211, 31);
            passwordField.StateCommon.Border.Color1 = SystemColors.ControlDark;
            passwordField.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            passwordField.StateCommon.Border.Rounding = 5F;
            passwordField.StateCommon.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordField.StateCommon.Content.Padding = new Padding(5);
            passwordField.TabIndex = 2;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Inter", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(20, 10);
            passwordLabel.Margin = new Padding(0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(82, 22);
            passwordLabel.TabIndex = 0;
            passwordLabel.Text = "Password";
            // 
            // panel3
            // 
            panel3.Controls.Add(businessComboBox);
            panel3.Controls.Add(businessLabel);
            panel3.Location = new Point(3, 471);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20, 10, 20, 10);
            panel3.Size = new Size(353, 80);
            panel3.TabIndex = 5;
            // 
            // businessComboBox
            // 
            businessComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            businessComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            businessComboBox.Location = new Point(20, 32);
            businessComboBox.Margin = new Padding(0);
            businessComboBox.MinimumSize = new Size(0, 30);
            businessComboBox.Name = "businessComboBox";
            businessComboBox.Size = new Size(313, 30);
            businessComboBox.StateCommon.ComboBox.Border.Rounding = 5F;
            businessComboBox.StateCommon.ComboBox.Content.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            businessComboBox.StateCommon.ComboBox.Content.Padding = new Padding(5, -1, 15, -1);
            businessComboBox.StateCommon.Item.Content.Padding = new Padding(5);
            businessComboBox.StateCommon.Item.Content.ShortText.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            businessComboBox.TabIndex = 5;
            // 
            // businessLabel
            // 
            businessLabel.AutoSize = true;
            businessLabel.Font = new Font("Inter", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            businessLabel.Location = new Point(20, 10);
            businessLabel.Margin = new Padding(0);
            businessLabel.Name = "businessLabel";
            businessLabel.Size = new Size(75, 22);
            businessLabel.TabIndex = 0;
            businessLabel.Text = "Business";
            // 
            // ProfileSettingView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(selectImgBtn);
            Controls.Add(panel1);
            Controls.Add(profilePictureBox);
            Controls.Add(headerPanel);
            Name = "ProfileSettingView";
            Size = new Size(359, 554);
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profilePictureBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)businessComboBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Krypton.Toolkit.KryptonButton saveBtn;
        private Krypton.Toolkit.KryptonButton backBtn;
        private PictureBox profilePictureBox;
        private Panel panel1;
        private Label nameLabel;
        private Krypton.Toolkit.KryptonTextBox nameField;
        private Krypton.Toolkit.KryptonButton selectImgBtn;
        private Panel panel2;
        private Krypton.Toolkit.KryptonTextBox passwordField;
        private Label passwordLabel;
        private Krypton.Toolkit.KryptonButton editPasswordBtn;
        private Panel panel3;
        private Label businessLabel;
        private Krypton.Toolkit.KryptonComboBox businessComboBox;
        private Krypton.Toolkit.KryptonCheckBox showPasswordCheckBox;
    }
}
