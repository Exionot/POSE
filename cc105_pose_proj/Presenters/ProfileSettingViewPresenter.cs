using cc105_pose_proj.Models;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.Presenters
{
    public class ProfileSettingViewPresenter
    {
        private readonly IProfileSettingView _view;
        private readonly IBusinessService _businessService;
        private readonly IDialogService _dialogService;
        private readonly IUserService _userService;
        private readonly User? _user;
        private bool IsCreate => _user is null;
        private string? _selectedImagePath;

        public ProfileSettingViewPresenter(
            IProfileSettingView view, 
            IBusinessService businessService,
            IDialogService dialogService,
            IUserService userService,
            User? user = null)
        {
            _view = view;
            _businessService = businessService;
            _dialogService = dialogService;
            _userService = userService;
            _user = user;
            _selectedImagePath = null;

            _view.BackRequest += BackRequest;
            _view.SaveRequest += SaveRequest;
            _view.ImageSelectRequest += ImageSelectRequest;
            _view.ToggleShowPasswordRequest += ToggleShowPasswordRequest;
            _view.EditPasswordRequest += EditPasswordRequest;

            LoadData();
        }

        private void LoadData()
        {
            var currentUser = Session.CurrentUser;

            _view.SelectedImage = LoadProfileImage();

            var businesses = _businessService.GetBusinesses();
            _view.SetBusinesses(businesses);
            _view.SelectedBusiness = businesses.FirstOrDefault(b => b.Id == _user?.Business?.Id);
            _view.Username = _user?.Username ?? string.Empty;

            _view.BusinessSelectionEnabled = CanEditBusiness(currentUser);
            _view.PasswordControlEnabled = _user == null;
        }

        private Image? LoadProfileImage()
        {
            if (_user is null || string.IsNullOrWhiteSpace(_user.Image)) return null;

            string path = Path.Combine(AppPaths.ResourceDir, _user.Image);
            if (!File.Exists(path)) return null;

            using var temp = Image.FromFile(path);
            return new Bitmap(temp);
        }

        private bool CanEditBusiness(User? current)
        {
            if (current is null || !current.IsAdmin) return false;
            if (_user is null) return true;    


            return current.Id != _user.Id && !_user.IsAdmin;
        }

        private bool HasUnsavedChanges() =>
            _view.Username.Trim() != (_user?.Username ?? string.Empty)
            || _view.SelectedBusiness?.Id != _user?.Business?.Id
            || _selectedImagePath != null
            || !string.IsNullOrEmpty(_view.Password);

        private void ImageSelectRequest(object? sender, EventArgs e)
        {
            string? imgPath = ImgUtil.SelectImage();
            if (imgPath == null) return;

            _selectedImagePath = imgPath;

            using var temp = Image.FromFile(imgPath);
            _view.SelectedImage = new Bitmap(temp);
        }

        private void ToggleShowPasswordRequest(object? sender, EventArgs e)
        {
            _view.PasswordChar = _view.IsPasswordShown ? '\0' : '●';
        }

        private void BackRequest(object? sender, EventArgs e)
        {
            if (!HasUnsavedChanges()
                || _dialogService.Confirm("Close this window? Unsaved changes will be lost!", "Exit"))
            {
                _view.Close(DialogResult.Cancel);
            }
        }

        private void EditPasswordRequest(object? sender, EventArgs e)
        {
            if (_user == null) return;
            _view.OpenEditPasswordDialog(_user);
        }

        private void SaveRequest(object? sender, EventArgs e)
        {
            string username = _view.Username.Trim();
            string password = _view.Password.Trim();

            if (string.IsNullOrEmpty(username))
            {
                _dialogService.ShowWarning("Username cannot be blank!", "Save");
                return;
            }

            if (IsCreate && string.IsNullOrEmpty(password))
            {
                _dialogService.ShowWarning("Password cannot be blank!", "Save");
                return;
            }

            if (IsCreate && string.IsNullOrEmpty(_selectedImagePath))
            {
                _dialogService.ShowWarning("Please select a profile image!", "Save");
                return;
            }

            if (!IsCreate && !HasUnsavedChanges()) { _view.Close(DialogResult.Cancel); return; }

            bool success;

            if (IsCreate)
            {
                var newUser = new User
                {
                    Username = username,
                    IsAdmin = false,
                    Business = _view.SelectedBusiness
                };

                success = _userService.CreateUser(newUser, password, _selectedImagePath!);
            }
            else
            {
                var updatedUser = new User
                {
                    Id = _user!.Id,
                    Username = username,
                    IsAdmin = _user.IsAdmin,
                    Business = _view.SelectedBusiness
                };

                success = _userService.UpdateUser(updatedUser, _selectedImagePath);
            }

            if (!success)
            {
                _dialogService.ShowError("Failed to save user. Please try again.", "Save");
                return;
            }

            _view.Close(DialogResult.OK);
        }
    }
}
