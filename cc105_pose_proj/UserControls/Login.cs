using cc105_pose_proj.UserControls;
using cc105_pose_proj.Util;
using Org.BouncyCastle.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cc105_pose_proj
{
    using cc105_pose_proj.Models;
    using cc105_pose_proj.Navigation;
    using cc105_pose_proj.Services;
    using Krypton.Toolkit;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    public partial class Login : UserControl
    {
        private readonly INavigator _nav;
        public Login(INavigator nav)
        {
            _nav = nav;
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Return || keyData == (Keys.Enter | Keys.Shift))
            {
                loginButton_Click(loginButton, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ImgUtil.FitIcon(exitBtn, Properties.Resources.image);
            usernameField.Focus();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            pictureBox1.Left = (panel1.Width - pictureBox1.Width) / 2;
            panel2.Left = (panel1.Width - panel2.Width) / 2;
            loginButton.Left = (panel1.Width - loginButton.Width) / 2;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string caption = "Log In";
            bool loginSuccess = AuthService.Login(usernameField.Text, passwordField.Text);

            if (!loginSuccess)
            {
                MessageBox.Show(
                    "Incorrect credentials.",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                if (string.IsNullOrEmpty(usernameField.Text))
                {
                    usernameField.Focus();
                }

                passwordField.Clear();
                passwordField.Focus();
                return;
            }

            _nav.NavigateTo(new Home(_nav));
        }
        
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
