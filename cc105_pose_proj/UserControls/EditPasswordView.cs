using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Presenters;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;
using System.ComponentModel;

namespace cc105_pose_proj.UserControls
{
    public partial class EditPasswordView : UserControl, IDialogControl, IEditPasswordView
    {
        public event EventHandler<DialogResult>? RequestClose;
        public event EventHandler? ChangePasswordRequest;
        public event EventHandler? CancelRequest;
        public event EventHandler? ToggleOldPasswordVisibility;
        public event EventHandler? ToggleNewPasswordVisibility;

        private readonly EditPasswordViewPresenter _presenter;
        public EditPasswordView(
            IDialogService dialogService,
            IUserService userService,
            User user)
        {
            InitializeComponent();
            _presenter = new EditPasswordViewPresenter(
                this,
                dialogService,
                userService,
                user);

            OldPasswordChar = '●';
            NewPasswordChar = '●';

            confirmBtn.Click += (_, _) => ChangePasswordRequest?.Invoke(this, EventArgs.Empty);
            cancelBtn.Click += (_, _) => CancelRequest?.Invoke(this, EventArgs.Empty);
            showOldPasswordCheckBox.CheckedChanged += (_, _) => ToggleOldPasswordVisibility?.Invoke(this, EventArgs.Empty);
            showNewPasswordCheckBox.CheckedChanged += (_, _) => ToggleNewPasswordVisibility?.Invoke(this, EventArgs.Empty);
        }

        public string OldPassword => oldPasswordField.Text;
        public string NewPassword => newPasswordField.Text;
        public bool IsOldPasswordShown => showOldPasswordCheckBox.Checked;
        public bool IsNewPasswordShown => showNewPasswordCheckBox.Checked;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char OldPasswordChar { set => oldPasswordField.PasswordChar = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char NewPasswordChar { set => newPasswordField.PasswordChar = value; }

        

        public void Close(DialogResult dialogResult) => RequestClose?.Invoke(this, dialogResult);
    }
}
