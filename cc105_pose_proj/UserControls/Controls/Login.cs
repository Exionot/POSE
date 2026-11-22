using cc105_pose_proj.Navigation;
using cc105_pose_proj.Presenters;
using cc105_pose_proj.Services;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.UserControls
{
    

    public partial class Login : UserControl, ILoginView
    {
        public event EventHandler? LoginRequest;
        public event EventHandler? ExitRequest;

        private readonly LoginPresenter _presenter;
        public Login(INavigator nav, IAuthService authService, IDialogService dialogService)
        {
            InitializeComponent();

            _presenter = new LoginPresenter(this, nav, authService, dialogService);

            loginButton.Click += (_, _) => LoginRequest?.Invoke(this, EventArgs.Empty);
            exitBtn.Click += (_, _) => ExitRequest?.Invoke(this, EventArgs.Empty);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Return || keyData == (Keys.Enter | Keys.Shift))
            {
                LoginRequest?.Invoke(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            exitBtn.FitIcon(Properties.Resources.image);
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

        public string Username => usernameField.Text;
        public string Password => passwordField.Text;

        public void ClearPassword() => passwordField.Clear();
        public void FocusUsername() => usernameField.Focus();
        public void FocusPassword() => passwordField.Focus();
    }
}
