using cc105_pose_proj.Models;
using MySql.Data.MySqlClient;

namespace cc105_pose_proj.Data
{
    public class ProductRepository : IRepository<Product>
    {
        private string BaseSelectQuery = @"
            select 
                p.id as product_id,
                p.name as product_name,
                p.quantity as quantity,
                p.price as price,
                p.image as image,
                p.created_at as created_at,
                p.updated_at as updated_at,
                b.id as business_id,
                b.name as business_name
            from products as p inner join business as b
            on p.business_id = b.id
        ";

        public List<Product> GetAll()
        {
            var list = new List<Product>();
            using var conn = DbConnector.GetConnection();
            conn.Open();

            using var cmd = new MySqlCommand(BaseSelectQuery, conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(CreateProduct(reader));
            }

            return list;
        }

        public Product? GetById(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = $"{BaseSelectQuery} where product_id = @id limit 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return CreateProduct(reader);
        }

        public bool Add(Product entity)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = @"
                insert into products (name, quantity, price, business_id, image)
                values (@name , @quantity, @price, @business_id, @image)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            cmd.Parameters.AddWithValue("@business_id", entity.Business.Id);
            cmd.Parameters.AddWithValue("@image", entity.Image);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Product entity)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = @"
                update products 
                set 
                    name = @name,
                    quantity = @quantity,
                    price = @price,
                    business_id = @business_id,
                    image = @image
                where id = @id";
            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            cmd.Parameters.AddWithValue("@business_id", entity.Business.Id);
            cmd.Parameters.AddWithValue("@image", entity.Image);
            cmd.Parameters.AddWithValue("@id", entity.Id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = "delete from products where id = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        private static Product CreateProduct(MySqlDataReader reader)
        {
            var business = new Business
            {
                Id = reader.GetInt32("business_id"),
                Name = reader.GetString("business_name")
            };

            return new Product 
            {
                Id = reader.GetInt32("product_id"),
                Name = reader.GetString("product_name"),
                Quantity = reader.GetInt32("quantity"),
                Price = reader.GetDecimal("price"),
                Business = business,
                Image = reader.GetString("image"),
                Created = reader.GetDateTime("created_at"),
                Updated = reader.GetDateTime("updated_at")
            };
        }
    }
}
