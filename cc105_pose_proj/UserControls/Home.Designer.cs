namespace cc105_pose_proj.UserControls
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            profilePanel = new cc105_pose_proj.Controls.RoundedKryptonPanel();
            userProfilePictureBox = new PictureBox();
            mainButtonPanel = new cc105_pose_proj.Controls.RoundedKryptonPanel();
            manageDiscountBtn = new Krypton.Toolkit.KryptonButton();
            viewMovementBtn = new Krypton.Toolkit.KryptonButton();
            viewSalesBtn = new Krypton.Toolkit.KryptonButton();
            manageProductBtn = new Krypton.Toolkit.KryptonButton();
            newTransactionBtn = new Krypton.Toolkit.KryptonButton();
            logoutBtn = new Krypton.Toolkit.KryptonButton();
            settingBtn = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profilePanel).BeginInit();
            profilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userProfilePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainButtonPanel).BeginInit();
            mainButtonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(profilePanel);
            kryptonPanel1.Controls.Add(mainButtonPanel);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(998, 697);
            kryptonPanel1.StateCommon.Color1 = Color.FromArgb(192, 0, 0, 0);
            kryptonPanel1.TabIndex = 0;
            // 
            // profilePanel
            // 
            profilePanel.Controls.Add(settingBtn);
            profilePanel.Controls.Add(logoutBtn);
            profilePanel.Controls.Add(userProfilePictureBox);
            profilePanel.CornerRadius = 20;
            profilePanel.Location = new Point(29, 68);
            profilePanel.Margin = new Padding(0, 30, 0, 0);
            profilePanel.Name = "profilePanel";
            profilePanel.Padding = new Padding(30, 5, 30, 5);
            profilePanel.Size = new Size(812, 70);
            profilePanel.StateCommon.Color1 = SystemColors.Control;
            profilePanel.TabIndex = 1;
            // 
            // userProfilePictureBox
            // 
            userProfilePictureBox.BackColor = SystemColors.ControlDark;
            userProfilePictureBox.Image = (Image)resources.GetObject("userProfilePictureBox.Image");
            userProfilePictureBox.Location = new Point(33, 8);
            userProfilePictureBox.Name = "userProfilePictureBox";
            userProfilePictureBox.Size = new Size(54, 54);
            userProfilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            userProfilePictureBox.TabIndex = 0;
            userProfilePictureBox.TabStop = false;
            // 
            // mainButtonPanel
            // 
            mainButtonPanel.Controls.Add(manageDiscountBtn);
            mainButtonPanel.Controls.Add(viewMovementBtn);
            mainButtonPanel.Controls.Add(viewSalesBtn);
            mainButtonPanel.Controls.Add(manageProductBtn);
            mainButtonPanel.Controls.Add(newTransactionBtn);
            mainButtonPanel.CornerRadius = 20;
            mainButtonPanel.Location = new Point(51, 245);
            mainButtonPanel.Margin = new Padding(0);
            mainButtonPanel.Name = "mainButtonPanel";
            mainButtonPanel.Padding = new Padding(30);
            mainButtonPanel.Size = new Size(809, 452);
            mainButtonPanel.StateCommon.Color1 = SystemColors.Control;
            mainButtonPanel.TabIndex = 0;
            // 
            // manageDiscountBtn
            // 
            manageDiscountBtn.Location = new Point(626, 309);
            manageDiscountBtn.Margin = new Padding(11, 5, 5, 5);
            manageDiscountBtn.Name = "manageDiscountBtn";
            manageDiscountBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            manageDiscountBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            manageDiscountBtn.OverrideFocus.Back.Color1 = Color.Khaki;
            manageDiscountBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            manageDiscountBtn.Size = new Size(148, 110);
            manageDiscountBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            manageDiscountBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            manageDiscountBtn.StateCommon.Border.Rounding = 10F;
            manageDiscountBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            manageDiscountBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 12F, FontStyle.Bold);
            manageDiscountBtn.StateCommon.Content.ShortText.MultiLineH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            manageDiscountBtn.TabIndex = 4;
            manageDiscountBtn.Values.DropDownArrowColor = Color.Empty;
            manageDiscountBtn.Values.Text = "View Product\r\nMovement";
            // 
            // viewMovementBtn
            // 
            viewMovementBtn.Location = new Point(454, 33);
            viewMovementBtn.Margin = new Padding(5);
            viewMovementBtn.Name = "viewMovementBtn";
            viewMovementBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            viewMovementBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            viewMovementBtn.OverrideFocus.Back.Color1 = Color.Khaki;
            viewMovementBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            viewMovementBtn.Size = new Size(320, 110);
            viewMovementBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            viewMovementBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            viewMovementBtn.StateCommon.Border.Rounding = 10F;
            viewMovementBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            viewMovementBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 12F, FontStyle.Bold);
            viewMovementBtn.TabIndex = 3;
            viewMovementBtn.Values.DropDownArrowColor = Color.Empty;
            viewMovementBtn.Values.Text = "Inventory";
            // 
            // viewSalesBtn
            // 
            viewSalesBtn.Location = new Point(454, 171);
            viewSalesBtn.Margin = new Padding(5, 23, 5, 23);
            viewSalesBtn.Name = "viewSalesBtn";
            viewSalesBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            viewSalesBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            viewSalesBtn.OverrideFocus.Back.Color1 = Color.Khaki;
            viewSalesBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            viewSalesBtn.Size = new Size(320, 110);
            viewSalesBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            viewSalesBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            viewSalesBtn.StateCommon.Border.Rounding = 10F;
            viewSalesBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            viewSalesBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 12F, FontStyle.Bold);
            viewSalesBtn.TabIndex = 2;
            viewSalesBtn.Values.DropDownArrowColor = Color.Empty;
            viewSalesBtn.Values.Text = "Manage Discounts";
            // 
            // manageProductBtn
            // 
            manageProductBtn.Location = new Point(454, 309);
            manageProductBtn.Margin = new Padding(5, 5, 11, 5);
            manageProductBtn.Name = "manageProductBtn";
            manageProductBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            manageProductBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            manageProductBtn.OverrideFocus.Back.Color1 = Color.Khaki;
            manageProductBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            manageProductBtn.Size = new Size(148, 110);
            manageProductBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            manageProductBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            manageProductBtn.StateCommon.Border.Rounding = 10F;
            manageProductBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            manageProductBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 12F, FontStyle.Bold);
            manageProductBtn.TabIndex = 1;
            manageProductBtn.Values.DropDownArrowColor = Color.Empty;
            manageProductBtn.Values.Text = "View Sales";
            // 
            // newTransactionBtn
            // 
            newTransactionBtn.Location = new Point(33, 33);
            newTransactionBtn.Margin = new Padding(3, 3, 30, 3);
            newTransactionBtn.Name = "newTransactionBtn";
            newTransactionBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            newTransactionBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            newTransactionBtn.OverrideFocus.Back.Color1 = Color.Khaki;
            newTransactionBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            newTransactionBtn.Size = new Size(386, 386);
            newTransactionBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            newTransactionBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            newTransactionBtn.StateCommon.Border.Rounding = 10F;
            newTransactionBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            newTransactionBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newTransactionBtn.StateCommon.Content.ShortText.MultiLineH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            newTransactionBtn.TabIndex = 0;
            newTransactionBtn.Values.DropDownArrowColor = Color.Empty;
            newTransactionBtn.Values.Text = "New\r\nTransaction\r\n";
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(702, 15);
            logoutBtn.Margin = new Padding(10, 10, 0, 10);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.OverrideDefault.Back.Color1 = Color.Brown;
            logoutBtn.Size = new Size(80, 40);
            logoutBtn.StateCommon.Back.Color1 = Color.Brown;
            logoutBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            logoutBtn.StateCommon.Border.Rounding = 10F;
            logoutBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            logoutBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 9F, FontStyle.Bold);
            logoutBtn.TabIndex = 1;
            logoutBtn.Values.DropDownArrowColor = Color.Empty;
            logoutBtn.Values.Text = "Logout";
            logoutBtn.Click += logoutBtn_Click;
            // 
            // settingBtn
            // 
            settingBtn.Location = new Point(652, 15);
            settingBtn.Margin = new Padding(0, 10, 0, 10);
            settingBtn.Name = "settingBtn";
            settingBtn.OverrideDefault.Back.Color1 = SystemColors.ControlDarkDark;
            settingBtn.Size = new Size(40, 40);
            settingBtn.StateCommon.Back.Color1 = SystemColors.ControlDarkDark;
            settingBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            settingBtn.StateCommon.Border.Rounding = 10F;
            settingBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            settingBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 9F, FontStyle.Bold);
            settingBtn.TabIndex = 2;
            settingBtn.Values.DropDownArrowColor = Color.Empty;
            settingBtn.Values.Text = "";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.home_bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(kryptonPanel1);
            DoubleBuffered = true;
            Name = "Home";
            Size = new Size(998, 697);
            Load += Home_Load;
            Resize += Home_Resize;
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profilePanel).EndInit();
            profilePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)userProfilePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainButtonPanel).EndInit();
            mainButtonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Controls.RoundedKryptonPanel mainButtonPanel;
        private Krypton.Toolkit.KryptonButton newTransactionBtn;
        private Krypton.Toolkit.KryptonButton viewMovementBtn;
        private Krypton.Toolkit.KryptonButton viewSalesBtn;
        private Krypton.Toolkit.KryptonButton manageProductBtn;
        private Krypton.Toolkit.KryptonButton manageDiscountBtn;
        private Controls.RoundedKryptonPanel profilePanel;
        private PictureBox userProfilePictureBox;
        private Krypton.Toolkit.KryptonButton logoutBtn;
        private Krypton.Toolkit.KryptonButton settingBtn;
    }
}
