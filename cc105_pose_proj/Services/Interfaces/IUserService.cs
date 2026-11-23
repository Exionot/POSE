using cc105_pose_proj.Models;

namespace cc105_pose_proj.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User? GetUserById(int id);
        bool CreateUser(User user, string password, string imageSourcePath);
        bool UpdateUser(User user, string? newImagePath = null);
        bool DeleteUser(int id);
        bool ChangePassword(int userId, string currentPassword, string newPassword);
    }
}
