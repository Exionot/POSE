namespace cc105_pose_proj.UserControls
{
    partial class DiscountView
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
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            mainViewPanel = new cc105_pose_proj.Controls.RoundedKryptonPanel();
            headerPanel = new cc105_pose_proj.Controls.RoundedKryptonPanel();
            backBtn = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainViewPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)headerPanel).BeginInit();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(mainViewPanel);
            kryptonPanel1.Controls.Add(headerPanel);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(811, 456);
            kryptonPanel1.StateCommon.Color1 = Color.FromArgb(192, 0, 0, 0);
            kryptonPanel1.TabIndex = 0;
            // 
            // mainViewPanel
            // 
            mainViewPanel.CornerRadius = 20;
            mainViewPanel.Location = new Point(30, 160);
            mainViewPanel.Margin = new Padding(60, 30, 60, 60);
            mainViewPanel.Name = "mainViewPanel";
            mainViewPanel.Size = new Size(751, 310);
            mainViewPanel.StateCommon.Color1 = SystemColors.Control;
            mainViewPanel.TabIndex = 1;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(backBtn);
            headerPanel.CornerRadius = 20;
            headerPanel.Location = new Point(30, 30);
            headerPanel.Margin = new Padding(60, 60, 60, 30);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(30, 15, 30, 15);
            headerPanel.Size = new Size(751, 70);
            headerPanel.StateCommon.Color1 = SystemColors.Control;
            headerPanel.TabIndex = 0;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(30, 15);
            backBtn.Margin = new Padding(0);
            backBtn.Name = "backBtn";
            backBtn.OverrideDefault.Back.Color1 = Color.Brown;
            backBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            backBtn.Size = new Size(40, 40);
            backBtn.StateCommon.Back.Color1 = Color.Brown;
            backBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            backBtn.StateCommon.Border.Rounding = 5F;
            backBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            backBtn.StateCommon.Content.ShortText.Font = new Font("Inter Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backBtn.TabIndex = 2;
            backBtn.Values.DropDownArrowColor = Color.Empty;
            backBtn.Values.Text = "↩";
            backBtn.Click += backBtn_Click;
            // 
            // DiscountView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.home_bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(kryptonPanel1);
            DoubleBuffered = true;
            Name = "DiscountView";
            Size = new Size(811, 456);
            Load += DiscountView_Load;
            Resize += DiscountView_Resize;
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainViewPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Controls.RoundedKryptonPanel headerPanel;
        private Controls.RoundedKryptonPanel mainViewPanel;
        private Krypton.Toolkit.KryptonButton backBtn;
    }
}
