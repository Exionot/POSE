using cc105_pose_proj.Util;
using MySql.Data.MySqlClient;
using System.Text.Json;

namespace cc105_pose_proj.Data
{
    public class DbConnector
    {
        public static readonly string ConnectionString;
        
        static DbConnector()
        {
            JsonElement config = ConfigManager.Config.GetProperty("connection");

            string server = config.GetProperty("host").GetString();
            string database = config.GetProperty("database").GetString();
            string user = config.GetProperty("user").GetString();
            string password = config.GetProperty("password").GetString();
            
            ConnectionString = $"server={server};database={database};uid={user};pwd={password};";
        }

        public static MySqlConnection GetConnection() => new MySqlConnection(ConnectionString);
    }
}
