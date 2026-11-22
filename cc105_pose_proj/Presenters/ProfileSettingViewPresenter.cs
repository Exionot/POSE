using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.Presenters
{
    public class ProfileSettingViewPresenter
    {
        private readonly IProfileSettingView _view;
        private readonly IAuthService _authService;
        private readonly IDialogService _dialogService;

        public ProfileSettingViewPresenter(
            IProfileSettingView view, 
            IAuthService authService, 
            IDialogService dialogService)
        {
            _view = view;
            _authService = authService;
            _dialogService = dialogService;

            _view.ImageSelectRequest += ImageSelectRequest;
        }

        private void ImageSelectRequest(object? sender, EventArgs e)
        {
            string? imgPath = ImgUtil.SelectImage();
            if (imgPath == null) return;

            _view.SelectedImage = imgPath;
            _view.SetProfileImage(Image.FromFile(_view.SelectedImage));
        }
    }
}
