using cc105_pose_proj.Data.Mappers;
using cc105_pose_proj.Models;
using MySql.Data.MySqlClient;

namespace cc105_pose_proj.Data
{
    public class DiscountRepository : IRepository<Discount>
    {
        private readonly string BaseSelectQuery = $@"
            select
                d.id as discount_id,
                d.name as discount_name,    
                d.value as value,
                d.type as type,
                d.buy_quantity as buy_quantity,
                d.get_quantity as get_quantity,
                d.is_active as is_active,
                d.created_at as created_at,
                d.updated_at as updated_at,
                b.id as business_id,
                b.name as business_name,
                {ProductMapper.Columns}
            from discounts as d
            inner join business as b on d.created_by = b.id
            left join discount_items as di on di.discount_id = d.id
            left join products as p on di.product_id = p.id
            left join business as pb on p.business_id = pb.id
        ";

        public List<Discount> GetAll()
        {
            var list = new List<Discount>();

            using var conn = DbConnector.GetConnection();
            conn.Open();

            using var cmd = new MySqlCommand($"{BaseSelectQuery} order by d.id", conn);
            using var reader = cmd.ExecuteReader();

            return ReadDiscount(reader);
        }

        public Discount? GetById(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = $"{BaseSelectQuery} where d.id = @id limit 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            return ReadDiscount(reader).FirstOrDefault();
        }

        public bool Add(Discount entity)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            using var transaction = conn.BeginTransaction();
            try
            {
                string query = @"
                    insert into discounts(
                        name, type, value, buy_quantity, get_quantity, 
                        is_active, created_by)
                    values(
                        @name, @type, @value, @buy_quantity, @get_quantity,
                        @is_active, @created_by)
                ";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@type", entity.Type);
                cmd.Parameters.AddWithValue("@value", entity.Value);
                cmd.Parameters.AddWithValue("@buy_quantity", entity.BuyAmount);
                cmd.Parameters.AddWithValue("@get_quantity", entity.GetAmount);
                cmd.Parameters.AddWithValue("@is_active", entity.Active);
                cmd.Parameters.AddWithValue("@created_by", entity.CreatedBy.Id);

                if (cmd.ExecuteNonQuery() <= 0)
                {
                    transaction.Rollback();
                    return false;
                }

                int newDiscountId = (int)cmd.LastInsertedId;

                if (!InsertItems(newDiscountId, entity.EligibleItems, conn, transaction))
                {
                    transaction.Rollback();
                    return false;
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool Update(Discount entity)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            using var transaction = conn.BeginTransaction();
            try
            {
                string query = @"
                    update discounts
                    set
                        name = @name,
                        type = @type,
                        value = @value,
                        buy_quantity = @buy_quantity,
                        get_quantity = @get_quantity,
                        is_active = @is_active,
                        updated_at = now()
                    where id = @id
                ";
                using var cmd = new MySqlCommand(query, conn, transaction);
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@type", entity.Type.ToString());
                cmd.Parameters.AddWithValue("@value", entity.Value);
                cmd.Parameters.AddWithValue("@buy_quantity", entity.BuyAmount);
                cmd.Parameters.AddWithValue("@get_quantity", entity.GetAmount);
                cmd.Parameters.AddWithValue("@is_active", entity.Active);
                cmd.Parameters.AddWithValue("@id", entity.Id);

                int rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    transaction.Rollback();
                    return false;
                }

                string deleteQuery = "delete from discount_items where discount_id = @id";
                using var deleteCmd = new MySqlCommand(deleteQuery, conn, transaction);
                deleteCmd.Parameters.AddWithValue("@id", entity.Id);
                int deletedRows = deleteCmd.ExecuteNonQuery();

                if (!InsertItems(entity.Id, entity.EligibleItems, conn, transaction))
                {
                    transaction.Rollback();
                    return false;
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            } 
        }

        public bool Delete(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = "delete from discounts where id = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        private static bool InsertItems(
            int discountId, List<Product> items,
            MySqlConnection conn, MySqlTransaction transaction)
        {
            string itemQuery = @"
                insert into discount_items(discount_id, product_id) 
                values(@discount_id, @product_id)";
            using var itemCmd = new MySqlCommand(itemQuery, conn, transaction);
            var discountIdParam = itemCmd.Parameters.Add("@discount_id", MySqlDbType.Int32);
            var productIdParam = itemCmd.Parameters.Add("@product_id", MySqlDbType.Int32);

            foreach (var item in items)
            {
                discountIdParam.Value = discountId;
                productIdParam.Value = item.Id;
                if (itemCmd.ExecuteNonQuery() <= 0)
                    return false;
            }

            return true;
        }

        private static List<Discount> ReadDiscount(MySqlDataReader reader)
        {
            var discounts = new Dictionary<int, Discount>();

            while (reader.Read())
            {
                int discountId = reader.GetInt32("discount_id");

                if (!discounts.TryGetValue(discountId, out var discount))
                {
                    discount = CreateDiscount(reader);
                    discounts.Add(discountId, discount);
                }

                if (ProductMapper.IsPresent(reader))
                    discount.EligibleItems.Add(ProductMapper.CreateProduct(reader));
            }
            return discounts.Values.ToList();
        }

        private static Discount CreateDiscount(MySqlDataReader reader)
        {
            var business = new Business
            {
                Id = reader.GetInt32("business_id"),
                Name = reader.GetString("business_name")
            };
            string typeString = reader.GetString("type");
            if (!Enum.TryParse<DiscountType>(typeString, true, out var type))
                throw new InvalidOperationException($"Unknown discount type '{typeString}'");

            return new Discount
            {
                Id = reader.GetInt32("discount_id"),
                Name = reader.GetString("discount_name"),
                Type = type,
                Value = reader.GetDecimal("value"),
                BuyAmount = reader.GetInt32("buy_quantity"),
                GetAmount = reader.GetInt32("get_quantity"),
                Active = reader.GetBoolean("is_active"),
                CreatedBy = business,
                CreatedAt = reader.GetDateTime("created_at"),
                UpdatedAt = reader.GetDateTime("updated_at")
            };
        }
    }
}
