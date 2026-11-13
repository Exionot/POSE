using cc105_pose_proj.Data;
using cc105_pose_proj.Models;
using cc105_pose_proj.Util;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pkix;

namespace cc105_pose_proj.Services
{
    public static class AuthService
    {
        public static User? Authenticate(string username, string password)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();
            string q = @"select 
                                u.id as user_id, 
                                u.password as password,
                                u.is_admin as is_admin, 
                                b.id as business_id, 
                                b.name as business_name 
                            from users as u left join business as b on u.id = b.user_id 
                            where u.username = @username
                            limit 1";
            using var cmd = new MySqlCommand(q, conn);

            cmd.Parameters.AddWithValue("@username", username);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            string hashPassword = reader.GetString("password");
            if (!PasswordUtils.checkPassword(password, hashPassword))
                return null;

            int userId = reader.GetInt32("user_id");
            bool isAdmin = reader.GetBoolean("is_admin");
            int? businessId = reader.IsDBNull(reader.GetOrdinal("business_id"))
                ? null
                : reader.GetInt32("business_id");

            string? businessName = reader.IsDBNull(reader.GetOrdinal("business_name"))
                ? null
                : reader.GetString("business_name");

            Business? business = null;
            if (businessId.HasValue)
                business = new Business 
                {
                    Id = businessId.Value,
                    Name = businessName!
                };

            return new User
            {
                Id = userId,
                Username = username,
                Business = business,
                IsAdmin = isAdmin
            }; 
        }

        public static bool Login(string username, string password)
        {
            User? user = AuthService.Authenticate(username, password);

            if (user == null)
                return false;

            Session.SignIn(user);
            return true;
        }

        public static void Logout()
        {
            Session.SignOut();
        }
    }
}
