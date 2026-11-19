using cc105_pose_proj.Navigation;
using cc105_pose_proj.Services;
using Krypton.Toolkit;
using Timer = System.Windows.Forms.Timer;

namespace cc105_pose_proj.UserControls
{
    public partial class Home : UserControl
    {
        private readonly INavigator _nav;
        public Home(INavigator nav)
        {
            _nav = nav;
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            foreach (var btn in mainButtonPanel.Controls.OfType<KryptonButton>())
            {
                int originalWidth = btn.Width;
                int originalHeight = btn.Height;

                int tWidth = originalWidth;
                int tHeight = originalHeight;

                int originalLeft = btn.Left;
                int originalTop = btn.Top;

                Timer btnAnimate = new ();
                int expandAmount = 20;
                btnAnimate.Interval = 15;

                btn.MouseEnter += (s, ev) =>
                {
                    tWidth = originalWidth + expandAmount;
                    tHeight = originalHeight + expandAmount;
                    btnAnimate.Start();
                };

                btn.MouseLeave += (s, ev) =>
                {
                    tWidth = originalWidth;
                    tHeight = originalHeight;
                    btnAnimate.Start();
                };

                btnAnimate.Tick += (s, ev) =>
                {
                    int speed = 2;

                    if (btn.Width < tWidth)
                        btn.Width = Math.Min(btn.Width + speed, tWidth);
                    else if (btn.Width > tWidth)
                        btn.Width = Math.Max(btn.Width - speed, tWidth);

                    if (btn.Height < tHeight)
                        btn.Height = Math.Min(btn.Height + speed, tHeight);
                    else if (btn.Height > tHeight)
                        btn.Height = Math.Max(btn.Height - speed, tHeight);

                    if (btn.Width == tWidth && btn.Height == tHeight)
                        btnAnimate.Stop();

                    btn.Left = originalLeft - (btn.Width - originalWidth) / 2;
                    btn.Top = originalTop - (btn.Height - originalHeight) / 2;
                };
            }
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            mainButtonPanel.Top = (this.ClientSize.Height - mainButtonPanel.Height) / 2;
            mainButtonPanel.Left = (this.ClientSize.Width - mainButtonPanel.Width) / 2;
            profilePanel.Top = profilePanel.Margin.Top;
            profilePanel.Left = (this.ClientSize.Width - profilePanel.Width) / 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo(new Inventory(_nav));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo(new MainTransaction(_nav));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to logout?";
            string caption = "Log Out";

            DialogResult result = MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                AuthService.Logout();
                _nav.NavigateTo(new Login(_nav));
            }
        }
    }
}
