using cc105_pose_proj.Models;
using MySql.Data.MySqlClient;

namespace cc105_pose_proj.Data.Mappers
{
    public class UserMapper
    {
        public static readonly string Columns = @"
            u.id as user_id,
            u.username as username,
            u.is_admin as is_admin,
            ub.id as business_id,
            ub.name as business_name
        ";

        public static User CreateUser(MySqlDataReader reader)
        {
            Business? business = null;
            int businessIdOrdinal = reader.GetOrdinal("business_id");

            if (!reader.IsDBNull(businessIdOrdinal))
            {
                business = new Business
                {
                    Id = reader.GetInt32(businessIdOrdinal),
                    Name = reader.GetString("business_name")
                };
            }

            return new User
            {
                Id = reader.GetInt32("user_id"),
                Username = reader.GetString("username"),
                IsAdmin = reader.GetBoolean("is_admin"),
                Business = business
            };
        }

        public static bool IsPresent(MySqlDataReader reader)
        {
            return !reader.IsDBNull(reader.GetOrdinal("user_id"));
        }
    }
}
