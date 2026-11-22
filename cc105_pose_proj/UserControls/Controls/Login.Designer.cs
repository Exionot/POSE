using cc105_pose_proj.Controls;

namespace cc105_pose_proj.UserControls
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new cc105_pose_proj.Controls.RoundedKryptonPanel();
            exitBtn = new Krypton.Toolkit.KryptonButton();
            loginButton = new Krypton.Toolkit.KryptonButton();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            passwordField = new Krypton.Toolkit.KryptonTextBox();
            usernameField = new Krypton.Toolkit.KryptonTextBox();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)panel1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(exitBtn);
            panel1.Controls.Add(loginButton);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.CornerRadius = 20;
            panel1.Location = new Point(197, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 586);
            panel1.StateCommon.Color1 = SystemColors.Control;
            panel1.TabIndex = 15;
            // 
            // exitBtn
            // 
            exitBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exitBtn.Location = new Point(433, 13);
            exitBtn.Name = "exitBtn";
            exitBtn.OverrideDefault.Back.Color1 = Color.Brown;
            exitBtn.OverrideDefault.Back.Color2 = Color.Brown;
            exitBtn.OverrideDefault.Border.Rounding = 100F;
            exitBtn.Size = new Size(35, 35);
            exitBtn.StateCommon.Back.Color1 = Color.Brown;
            exitBtn.StateCommon.Back.Color2 = Color.Brown;
            exitBtn.StateCommon.Border.Rounding = 100F;
            exitBtn.StateNormal.Back.ImageAlign = Krypton.Toolkit.PaletteRectangleAlign.Control;
            exitBtn.StateNormal.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            exitBtn.TabIndex = 16;
            exitBtn.Values.DropDownArrowColor = Color.Empty;
            exitBtn.Values.Text = "";
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            loginButton.Location = new Point(175, 445);
            loginButton.Name = "loginButton";
            loginButton.OverrideDefault.Back.Color1 = Color.Goldenrod;
            loginButton.OverrideDefault.Back.Color2 = Color.Goldenrod;
            loginButton.Size = new Size(169, 48);
            loginButton.StateCommon.Back.Color1 = Color.Goldenrod;
            loginButton.StateCommon.Back.Color2 = Color.Goldenrod;
            loginButton.StateCommon.Border.Rounding = 5F;
            loginButton.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            loginButton.StateCommon.Content.ShortText.Color2 = SystemColors.Control;
            loginButton.StateCommon.Content.ShortText.Font = new Font("Inter", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginButton.TabIndex = 19;
            loginButton.Values.DropDownArrowColor = Color.Empty;
            loginButton.Values.Text = "Login";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Image = Properties.Resources.POSE_logo_noBG;
            pictureBox1.Location = new Point(250, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(148, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(passwordField);
            panel2.Controls.Add(usernameField);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(8, 219);
            panel2.Name = "panel2";
            panel2.Size = new Size(418, 210);
            panel2.TabIndex = 16;
            // 
            // passwordField
            // 
            passwordField.Location = new Point(30, 160);
            passwordField.Name = "passwordField";
            passwordField.PasswordChar = '*';
            passwordField.Size = new Size(360, 36);
            passwordField.StateCommon.Border.Rounding = 5F;
            passwordField.StateCommon.Content.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordField.StateCommon.Content.Padding = new Padding(5);
            passwordField.TabIndex = 9;
            // 
            // usernameField
            // 
            usernameField.Location = new Point(30, 81);
            usernameField.Name = "usernameField";
            usernameField.Size = new Size(360, 36);
            usernameField.StateCommon.Border.Rounding = 5F;
            usernameField.StateCommon.Content.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameField.StateCommon.Content.Padding = new Padding(5);
            usernameField.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 9.75F);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(30, 60);
            label1.Name = "label1";
            label1.Size = new Size(72, 18);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Inter", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 3);
            label3.Name = "label3";
            label3.Size = new Size(115, 45);
            label3.TabIndex = 17;
            label3.Text = "Log In";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 9.75F);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(30, 139);
            label2.Name = "label2";
            label2.Size = new Size(69, 18);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Enabled = false;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(841, 621);
            kryptonPanel1.StateCommon.Color1 = Color.FromArgb(192, 0, 0, 0);
            kryptonPanel1.TabIndex = 16;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(231, 217, 137);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panel1);
            Controls.Add(kryptonPanel1);
            DoubleBuffered = true;
            Name = "Login";
            Size = new Size(841, 621);
            Load += Login_Load;
            Resize += Login_Resize;
            ((System.ComponentModel.ISupportInitialize)panel1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundedKryptonPanel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Krypton.Toolkit.KryptonTextBox passwordField;
        private Krypton.Toolkit.KryptonTextBox usernameField;
        private Label label1;
        private Label label2;
        private Label label3;
        private Krypton.Toolkit.KryptonButton loginButton;
        private Krypton.Toolkit.KryptonButton exitBtn;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}
