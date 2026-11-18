using cc105_pose_proj.Data.Mappers;
using cc105_pose_proj.Models;
using MySql.Data.MySqlClient;

namespace cc105_pose_proj.Data
{
    public class ProductRepository : IRepository<Product>
    {
        private string BaseSelectQuery = $@"
            select {ProductMapper.Columns}
            from products as p 
            inner join business as pb
            on p.business_id = pb.id
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
                list.Add(ProductMapper.CreateProduct(reader));
            }

            return list;
        }

        public Product? GetById(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = $"{BaseSelectQuery} where p.id = @id limit 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return ProductMapper.CreateProduct(reader);
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
                    image = @image,
                    updated_at = now()
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
    }
}
