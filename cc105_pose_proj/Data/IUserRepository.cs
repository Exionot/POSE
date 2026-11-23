using cc105_pose_proj.Models;

namespace cc105_pose_proj.Data
{
    public interface IUserRepository : IRepository<User>
    {
        bool AddWithPassword(User entity, string passwordHash);
        string? GetPasswordHash(int id);
        bool UpdatePassword(int id, string newHash);
    }
}
