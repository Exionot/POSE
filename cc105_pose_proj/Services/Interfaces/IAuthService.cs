using cc105_pose_proj.Models;

namespace cc105_pose_proj.Services.Interfaces
{
    public interface IAuthService
    {
        User? Authenticate(string username, string password);
        bool Login(string username, string password);
        void Logout();
    }
}
