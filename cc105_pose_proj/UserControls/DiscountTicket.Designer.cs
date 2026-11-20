namespace cc105_pose_proj.UserControls
{
    partial class DiscountTicket
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
            nameLabel = new Label();
            typeLabel = new Label();
            valueLabel = new Label();
            appliedToLabel = new Label();
            itemsFlowPanel = new FlowLayoutPanel();
            editBtn = new Krypton.Toolkit.KryptonButton();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Inter", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(13, 10);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(170, 30);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Discount Name";
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Font = new Font("Inter", 9.75F);
            typeLabel.Location = new Point(13, 40);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(112, 18);
            typeLabel.TabIndex = 1;
            typeLabel.Text = "DISCOUNT_TYPE";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font("Inter", 9.75F);
            valueLabel.Location = new Point(13, 58);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(36, 18);
            valueLabel.TabIndex = 2;
            valueLabel.Text = "0.00";
            // 
            // appliedToLabel
            // 
            appliedToLabel.AutoSize = true;
            appliedToLabel.Font = new Font("Inter", 8.25F, FontStyle.Bold);
            appliedToLabel.Location = new Point(13, 87);
            appliedToLabel.Name = "appliedToLabel";
            appliedToLabel.Size = new Size(69, 16);
            appliedToLabel.TabIndex = 3;
            appliedToLabel.Text = "Applied To:";
            // 
            // itemsFlowPanel
            // 
            itemsFlowPanel.AutoScroll = true;
            itemsFlowPanel.Location = new Point(13, 106);
            itemsFlowPanel.Name = "itemsFlowPanel";
            itemsFlowPanel.Size = new Size(324, 31);
            itemsFlowPanel.TabIndex = 4;
            // 
            // editBtn
            // 
            editBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editBtn.Location = new Point(287, 13);
            editBtn.Name = "editBtn";
            editBtn.OverrideDefault.Back.Color1 = Color.Goldenrod;
            editBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            editBtn.Size = new Size(50, 30);
            editBtn.StateCommon.Back.Color1 = Color.Goldenrod;
            editBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            editBtn.StateCommon.Border.Rounding = 5F;
            editBtn.StateCommon.Content.ShortText.Color1 = SystemColors.Control;
            editBtn.StateCommon.Content.ShortText.Font = new Font("Inter", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editBtn.TabIndex = 5;
            editBtn.Values.DropDownArrowColor = Color.Empty;
            editBtn.Values.Text = "Edit";
            // 
            // DiscountTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(editBtn);
            Controls.Add(itemsFlowPanel);
            Controls.Add(appliedToLabel);
            Controls.Add(valueLabel);
            Controls.Add(typeLabel);
            Controls.Add(nameLabel);
            Margin = new Padding(7);
            Name = "DiscountTicket";
            Padding = new Padding(10);
            Size = new Size(350, 150);
            Load += DiscountTicket_Load;
            Resize += DiscountTicket_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Label typeLabel;
        private Label valueLabel;
        private Label appliedToLabel;
        private FlowLayoutPanel itemsFlowPanel;
        private Krypton.Toolkit.KryptonButton editBtn;
    }
}
