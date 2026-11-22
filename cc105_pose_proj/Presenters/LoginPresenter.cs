using cc105_pose_proj.Navigation;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls;
using cc105_pose_proj.UserControls.Interfaces;

namespace cc105_pose_proj.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly IAuthService _authService;
        private readonly INavigator _nav;
        private readonly IDialogService _dialogService;

        public LoginPresenter(
            ILoginView view,
            INavigator nav,
            IAuthService authService,
            IDialogService dialogService)
        {
            _view = view;
            _authService = authService;
            _nav = nav;
            _dialogService = dialogService;

            _view.LoginRequest += LoginRequest;
            _view.ExitRequest += (_, _) => Application.Exit();
        }

        private void LoginRequest(object? sender, EventArgs args)
        {
            string username = _view.Username.Trim();
            string password = _view.Password.Trim();

            bool success = _authService.Login(username, password);

            if (!success)
            {
                _dialogService.ShowError("Incorrect Credentials.", "Login");

                if (string.IsNullOrWhiteSpace(username))
                    _view.FocusUsername();

                _view.ClearPassword();
                _view.FocusPassword();
                return;
            }
            _nav.NavigateTo<Home>();
        }
    }
}
