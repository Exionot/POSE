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
            discountTicketFlowPanel = new FlowLayoutPanel();
            headerPanel = new cc105_pose_proj.Controls.RoundedKryptonPanel();
            addButton = new Krypton.Toolkit.KryptonButton();
            backBtn = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainViewPanel).BeginInit();
            mainViewPanel.SuspendLayout();
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
            kryptonPanel1.Size = new Size(811, 517);
            kryptonPanel1.StateCommon.Color1 = Color.FromArgb(192, 0, 0, 0);
            kryptonPanel1.TabIndex = 0;
            // 
            // mainViewPanel
            // 
            mainViewPanel.Controls.Add(discountTicketFlowPanel);
            mainViewPanel.CornerRadius = 20;
            mainViewPanel.Location = new Point(30, 160);
            mainViewPanel.Margin = new Padding(60, 30, 60, 30);
            mainViewPanel.Name = "mainViewPanel";
            mainViewPanel.Padding = new Padding(30);
            mainViewPanel.Size = new Size(751, 310);
            mainViewPanel.StateCommon.Color1 = SystemColors.Control;
            mainViewPanel.TabIndex = 1;
            // 
            // discountTicketFlowPanel
            // 
            discountTicketFlowPanel.AutoScroll = true;
            discountTicketFlowPanel.BackColor = SystemColors.ControlDark;
            discountTicketFlowPanel.Location = new Point(18, 18);
            discountTicketFlowPanel.Name = "discountTicketFlowPanel";
            discountTicketFlowPanel.Padding = new Padding(10);
            discountTicketFlowPanel.Size = new Size(715, 274);
            discountTicketFlowPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(addButton);
            headerPanel.Controls.Add(backBtn);
            headerPanel.CornerRadius = 20;
            headerPanel.Location = new Point(30, 30);
            headerPanel.Margin = new Padding(60, 30, 60, 30);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(30, 15, 30, 15);
            headerPanel.Size = new Size(751, 70);
            headerPanel.StateCommon.Color1 = SystemColors.Control;
            headerPanel.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addButton.Location = new Point(681, 15);
            addButton.Margin = new Padding(0);
            addButton.Name = "addButton";
            addButton.OverrideDefault.Back.Color1 = Color.Goldenrod;
            addButton.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            addButton.Size = new Size(40, 40);
            addButton.StateCommon.Back.Color1 = Color.Goldenrod;
            addButton.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            addButton.StateCommon.Border.Rounding = 5F;
            addButton.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            addButton.StateCommon.Content.ShortText.Font = new Font("Inter Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addButton.TabIndex = 3;
            addButton.Values.DropDownArrowColor = Color.Empty;
            addButton.Values.Text = "+";
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
            Size = new Size(811, 517);
            Resize += DiscountView_Resize;
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainViewPanel).EndInit();
            mainViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Controls.RoundedKryptonPanel headerPanel;
        private Controls.RoundedKryptonPanel mainViewPanel;
        private Krypton.Toolkit.KryptonButton backBtn;
        private FlowLayoutPanel discountTicketFlowPanel;
        private Krypton.Toolkit.KryptonButton addButton;
    }
}
