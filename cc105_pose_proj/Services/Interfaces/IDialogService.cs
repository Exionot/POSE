namespace cc105_pose_proj.Services.Interfaces
{
    public interface IDialogService
    {
        void ShowInfo(string message, string title = "Information");
        void ShowWarning(string message, string title = "Warning");
        void ShowError(string message, string title = "Error");
        bool Confirm(string message, string title = "Confirm");
    }
}
