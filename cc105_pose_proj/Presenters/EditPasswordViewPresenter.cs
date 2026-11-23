using cc105_pose_proj.Models;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;

namespace cc105_pose_proj.Presenters
{
    public class EditPasswordViewPresenter
    {
        private IEditPasswordView _view;
        private readonly IDialogService _dialogService;
        private readonly IUserService _userService;
        private readonly User _user;

        public EditPasswordViewPresenter(
            IEditPasswordView view, 
            IDialogService dialogService, 
            IUserService userService, 
            User user)
        {
            _view = view;
            _dialogService = dialogService;
            _userService = userService;
            _user = user;

            _view.CancelRequest += CancelRequest;
            _view.ChangePasswordRequest += ChangePasswordRequest;
            _view.ToggleOldPasswordVisibility += ToggleOldPasswordVisibility;
            _view.ToggleNewPasswordVisibility += ToggleNewPasswordVisibility;
        }

        private void ChangePasswordRequest(object? sender, EventArgs e)
        {
            string oldPassword = _view.OldPassword.Trim();
            string newPassword = _view.NewPassword.Trim();

            if (string.IsNullOrWhiteSpace(oldPassword))
            {
                _dialogService.ShowError("Please enter your current password.");
                return;
            }
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                _dialogService.ShowError("New password cannot be blank.");
                return;
            }
            if (newPassword.Length < 8)
            {
                _dialogService.ShowError("New password must be at least 8 characters.");
                return;
            }
            if (oldPassword == newPassword)
            {
                _dialogService.ShowError("New password must be different from current password.");
                return;
            }

            bool success = _userService.ChangePassword(_user.Id, oldPassword, newPassword);
            if (!success)
            {
                _dialogService.ShowError("Changing password failed.");
                return;
            }

            _dialogService.ShowInfo("Password change success!");
            _view.Close(DialogResult.OK);
        }
        private void CancelRequest(object? sender, EventArgs e) => _view.Close(DialogResult.Cancel);
        private void ToggleOldPasswordVisibility(object? sender, EventArgs e) 
            => _view.OldPasswordChar = _view.IsOldPasswordShown ? '\0' : '●';

        private void ToggleNewPasswordVisibility(object? sender, EventArgs e) 
            => _view.NewPasswordChar = _view.IsNewPasswordShown ? '\0' : '●';

    }
}
