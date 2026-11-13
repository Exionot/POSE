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
            panel1 = new Panel();
            logoutBtn = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(logoutBtn);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(35, 181);
            panel1.Name = "panel1";
            panel1.Size = new Size(819, 480);
            panel1.TabIndex = 0;
            // 
            // logoutBtn
            // 
            logoutBtn.BackColor = Color.Brown;
            logoutBtn.FlatStyle = FlatStyle.Flat;
            logoutBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            logoutBtn.ForeColor = SystemColors.Control;
            logoutBtn.Location = new Point(485, 366);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(315, 98);
            logoutBtn.TabIndex = 3;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = false;
            logoutBtn.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Khaki;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ControlText;
            button3.Location = new Point(485, 196);
            button3.Name = "button3";
            button3.Size = new Size(315, 144);
            button3.TabIndex = 2;
            button3.Text = "View\r\nSales";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Khaki;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(485, 24);
            button2.Name = "button2";
            button2.Size = new Size(315, 144);
            button2.TabIndex = 1;
            button2.Text = "Manage\r\nStock";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Khaki;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(21, 24);
            button1.Name = "button1";
            button1.Size = new Size(440, 440);
            button1.TabIndex = 0;
            button1.Text = "New \r\nTransaction";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top;
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(330, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(271, 129);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(123, 41);
            label1.Name = "label1";
            label1.Size = new Size(147, 50);
            label1.TabIndex = 1;
            label1.Text = "P.O.S.E.";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.POSE_logo_noBG;
            pictureBox1.Location = new Point(17, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Home";
            Size = new Size(998, 697);
            Load += Home_Load;
            Resize += Home_Resize;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button logoutBtn;
        private PictureBox pictureBox1;
        private Label label1;
    }
}
