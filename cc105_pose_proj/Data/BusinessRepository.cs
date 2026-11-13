using cc105_pose_proj.Models;
using MySql.Data.MySqlClient;

namespace cc105_pose_proj.Data
{
    public class BusinessRepository : IRepository<Business>
    {
        public List<Business> GetAll()
        {
            var list = new List<Business>();
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = "select id, name from business";
            using var cmd = new MySqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(
                        new Business
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name")
                        }
                    ); 
            }

            return list;
        }

        public Business? GetById(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = "select id, name from business where id = @id limit 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return new Business
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name")
            };
        }

        public bool Add(Business entity)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = "insert into business (name) values (@name)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", entity.Name);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Business entity)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = "update business set name = @name where id = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@id", entity.Id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = "delete from business where id = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
