using cc105_pose_proj.Data;
using cc105_pose_proj.Models;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository? userRepo = null)
        {
            _userRepo = userRepo ?? new UserRepository();
        }

        public List<User> GetUsers()
        {
            if (CurrentUser == null)
                return [];

            var allUsers = _userRepo.GetAll();

            if (IsAdmin)
                return allUsers;

            return allUsers.Where(u => u.Id == CurrentUser.Id).ToList();
        }

        public User? GetUserById(int id)
        {
            if (CurrentUser == null) return null;

            if (!IsAdmin && CurrentUser.Id != id)
                return null;

            return _userRepo.GetById(id);
        }

        public bool CreateUser(User user, string password, string imageSourcePath)
        {
            if (CurrentUser == null || !IsAdmin) return false;

            if (string.IsNullOrWhiteSpace(password)) return false;

            string savedImageName = ImgUtil.SaveImg(imageSourcePath);
            user.Image = savedImageName;

            string passwordHash = PasswordUtils.hashPassword(password);

            try
            {
                bool success = _userRepo.AddWithPassword(user, passwordHash);

                if (!success)
                {
                    ImgUtil.DeleteImage(savedImageName);
                    return false;
                }

                return true;
            }
            catch
            {
                ImgUtil.DeleteImage(savedImageName);
                throw;
            }
        }

        public bool UpdateUser(User user, string? newImagePath = null)
        {
            if (CurrentUser == null) return false;

            var existing = GetUserById(user.Id);
            if (existing == null) return false;

            if (!IsAdmin)
                user.IsAdmin = existing.IsAdmin;

            if (!string.IsNullOrEmpty(newImagePath))
                user.Image = ImgUtil.ReplaceImage(existing.Image, newImagePath);
            else
                user.Image = existing.Image;

            bool success = _userRepo.Update(user);

            if (success && CurrentUser?.Id == user.Id)
                Session.SignIn(user);

            return success;
        }

        public bool DeleteUser(int id)
        {
            if (CurrentUser == null || !IsAdmin) return false;

            if (CurrentUser.Id == id) return false;

            var user = GetUserById(id);
            if (user == null) return false;

            return _userRepo.Delete(id);
        }

        public bool ChangePassword(int userId, string currentPassword, string newPassword)
        {
            if (CurrentUser == null) return false;

            if (!IsAdmin && CurrentUser.Id != userId) return false;

            if (string.IsNullOrWhiteSpace(newPassword)) return false;
            if (string.IsNullOrWhiteSpace(currentPassword)) return false;

            string? storedHash = _userRepo.GetPasswordHash(userId);
            if (storedHash == null) return false;

            if (!PasswordUtils.checkPassword(currentPassword, storedHash)) return false;

            string newHash = PasswordUtils.hashPassword(newPassword);
            return _userRepo.UpdatePassword(userId, newHash);
        }
    }
}

