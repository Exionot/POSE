using cc105_pose_proj.Navigation;

namespace cc105_pose_proj.UserControls.Interfaces
{
    public interface IHomeView
    {
        string DisplayName { set; }
        Image? ProfileImage { set; }
        void OpenSettingsDialog();

        event EventHandler<NavigationEventArgs>? NavigationRequest;
        event EventHandler? SettingsRequest;

    }
}
