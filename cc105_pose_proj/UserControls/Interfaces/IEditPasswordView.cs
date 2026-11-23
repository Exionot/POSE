namespace cc105_pose_proj.UserControls.Interfaces
{
    public interface IEditPasswordView
    {
        string OldPassword { get; }
        string NewPassword { get; }
        bool IsOldPasswordShown { get; }
        bool IsNewPasswordShown { get; }
        char OldPasswordChar { set; }
        char NewPasswordChar { set; }

        void Close(DialogResult dialogResult);

        event EventHandler? ChangePasswordRequest;
        event EventHandler? CancelRequest;
        event EventHandler? ToggleOldPasswordVisibility;
        event EventHandler? ToggleNewPasswordVisibility;
    }
}
