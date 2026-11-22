using cc105_pose_proj.Models;

namespace cc105_pose_proj.UserControls.Interfaces
{
    public interface IProfileSettingView
    {
        string Username { get; set; }
        string Password { get; set; }
        string SelectedImage { get; set; }
        Business? SelectedBusiness { get; set; }

        void Close(DialogResult dialogResult);
        void SetProfileImage(Image image);
        void SetBusinesses(List<Business> businesses);

        event EventHandler? ImageSelectRequest;
        event EventHandler? EditPasswordRequest;
        event EventHandler? SaveRequest;
        event EventHandler? ToggleShowPasswordRequest;
        event EventHandler? BackRequest;

    }
}
