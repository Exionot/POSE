using cc105_pose_proj.Data.Mappers;
using cc105_pose_proj.Models;
using MySql.Data.MySqlClient;

namespace cc105_pose_proj.Data
{
    public class UserRepository : IRepository<User>
    {
        private string BaseSelectQuery => $@"
            select {UserMapper.Columns}
            from users as u left join business as ub 
            on u.id = ub.user_id
        ";

        public List<User> GetAll()
        {
            var list = new List<User>();
            using var conn = DbConnector.GetConnection();
            conn.Open();

            using var cmd = new MySqlCommand(BaseSelectQuery, conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(UserMapper.CreateUser(reader));
            }

            return list;
        }

        public User? GetById(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = $"{BaseSelectQuery} where u.id = @id limit 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return UserMapper.CreateUser(reader);
        }

        public bool Add(User entity)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            using var transaction = conn.BeginTransaction();
            try
            {
                string query = @"
                    insert into users (username, is_admin)
                    values (@username, @is_admin)
                ";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", entity.Username);
                cmd.Parameters.AddWithValue("@is_admin", entity.IsAdmin);
                int rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    transaction.Rollback();
                    return false;
                }

                if (entity.Business != null)
                {
                    long newUserId = cmd.LastInsertedId;

                    string linkQuery = "update business set user_id = @user_id where id = @business_id";
                    using var linkCmd = new MySqlCommand(linkQuery, conn);
                    linkCmd.Parameters.AddWithValue("@user_id", newUserId);
                    linkCmd.Parameters.AddWithValue("@business_id", entity.Business.Id);
                    linkCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }

        }

        public bool Update(User entity)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            using var transaction = conn.BeginTransaction();
            try
            {
                string query = @"
                    update users 
                    set
                        username = @username, 
                        is_admin = @is_admin
                    where id = @id
                ";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", entity.Username);
                cmd.Parameters.AddWithValue("@is_admin", entity.IsAdmin);
                cmd.Parameters.AddWithValue("@id", entity.Id);

                int rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    transaction.Rollback();
                    return false;
                }

                if (entity.Business != null)
                {
                    string linkQuery = "update business set user_id = @user_id where id = @business_id";
                    using var linkCmd = new MySqlCommand(linkQuery, conn);
                    linkCmd.Parameters.AddWithValue("@user_id", entity.Id);
                    linkCmd.Parameters.AddWithValue("@business_id", entity.Business.Id);
                    linkCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool Delete(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = "delete from users where id = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
