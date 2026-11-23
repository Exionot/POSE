namespace cc105_pose_proj.UserControls.Interfaces
{
    public interface IEditPasswordView
    {
        string OldPassword { get; }
        string NewPassword { get; }

        event EventHandler? ChangePasswordRequest;
        event EventHandler? BackRequest;
    }
}
