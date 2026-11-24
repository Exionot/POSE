using cc105_pose_proj.Navigation;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls;
using cc105_pose_proj.UserControls.Interfaces;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.Presenters
{
    public class HomeViewPresenter
    {
        private readonly IHomeView _view;
        private readonly INavigator _nav;
        private readonly IDialogService _dialogService;

        public HomeViewPresenter(IHomeView view, INavigator nav, IDialogService dialogService)
        {
            _view = view;
            _nav = nav;
            _dialogService = dialogService;

            _view.NavigationRequest += NavigationRequest;
            _view.SettingsRequest += SettingsRequest;

            LoadUserData();
        }

        public void LoadUserData()
        {
            var user = Session.CurrentUser;
            if (user == null) return;

            _view.DisplayName = user.Business?.Name ?? user.Username;

            _view.ProfileImage = LoadProfileImage(user.Image);
        }

        private Image? LoadProfileImage(string? imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName)) return null;

            string fullPath = Path.Combine(AppPaths.ResourceDir, imageName);
            if (!File.Exists(fullPath)) return null;

            using var temp = Image.FromFile(fullPath);
            return new Bitmap(temp);
        }

        private void NavigationRequest(object? sender, NavigationEventArgs e)
        {
            switch (e.Target)
            {
                case NavigationTarget.MainTransaction:
                    _nav.NavigateTo<MainTransaction>();
                    break;

                case NavigationTarget.Inventory:
                    _nav.NavigateTo<Inventory>();
                    break;

                case NavigationTarget.DiscountView:
                    _nav.NavigateTo<DiscountView>();
                    break;

                case NavigationTarget.Login:
                    if (_dialogService.Confirm("Are you sure you want to logout?", "Log Out"))
                    {
                        Session.SignOut();
                        _nav.NavigateTo<Login>();
                    }
                    break;
            }
        }

        private void SettingsRequest(object? sender, EventArgs e)
        {
            _view.OpenSettingsDialog();
            LoadUserData(); 
        }
    }
}
