namespace cc105_pose_proj.UserControls.Interfaces
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }

        void ClearPassword();
        void FocusUsername();
        void FocusPassword();

        event EventHandler? LoginRequest;
        event EventHandler? ExitRequest;
    }
}
