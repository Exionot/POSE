using cc105_pose_proj.Models;
using MySql.Data.MySqlClient;

namespace cc105_pose_proj.Data
{
    public class DiscountRepository : IRepository<Discount>
    {
        private string DefaultSelectQuery = @"
            select
                d.id as discount_id,
                d.name as discount_name,
                d.value as value,
                d.type as type,
                d.buy_amount as buy_amount,
                d.get_amount as get_amount,
                d.is_active as is_active,
                d.created_by as business_id,
                d.created_at as created_at,
                d.updated_at as updated_at,
                b.name as business_name
            from discounts as d
            inner join business as b
            on created_by = b.id
        ";

        public List<Discount> GetAll()
        {
            var list = new List<Discount>();

            using var conn = DbConnector.GetConnection();
            conn.Open();

            using var cmd = new MySqlCommand(DefaultSelectQuery, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(CreateDiscount(reader));
            }

            return list;
        }

        public Discount? GetById(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = $"{DefaultSelectQuery} where d.id = @id limit 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return CreateDiscount(reader);
        }

        private Discount CreateDiscount(MySqlDataReader reader)
        {
            var business = new Business
            {
                Id = reader.GetInt32("business_id"),
                Name = reader.GetString("business_name")
            };
            string typeString = reader.GetString("type");
            Enum.TryParse<Discount.DiscountType>(typeString, true, out Discount.DiscountType type);

            return new Discount
            {
                Id = reader.GetInt32("discount_id"),
                Name = reader.GetString("discount_name"),
                Type = type,
                Value = reader.GetDecimal("value"),
                BuyAmount = reader.GetInt32("buy_amount"),
                GetAmount = reader.GetInt32("get_amount"),
                Active = reader.GetBoolean("is_active"),
                CreatedBy = business,
                CreatedAt = reader.GetDateTime("created_at"),
                UpdatedAt = reader.GetDateTime("updated_at")
            };
        }
    }
}
