using cc105_pose_proj.Models;
using MySql.Data.MySqlClient;

namespace cc105_pose_proj.Data.Mappers
{
    public class ProductMapper
    {
        public static readonly string Columns = @"
            p.id as product_id,
            p.name as product_name,
            p.quantity as quantity,
            p.price as price,
            p.image as image,
            p.created_at as created_at,
            p.updated_at as updated_at,
            pb.id as product_business_id,
            pb.name as product_business_name
        ";

        public static Product CreateProduct(MySqlDataReader reader)
        {
            return new Product
            {
                Id = reader.GetInt32("product_id"),
                Name = reader.GetString("product_name"),
                Quantity = reader.GetInt32("quantity"),
                Price = reader.GetDecimal("price"),
                Business = new Business
                {
                    Id = reader.GetInt32("product_business_id"),
                    Name = reader.GetString("product_business_name")
                },
                Image = reader.GetString("image"),
                Created = reader.GetDateTime("product_created_at"),
                Updated = reader.GetDateTime("product_updated_at")
            };
        }

        public static bool IsPresent(MySqlDataReader reader)
        {
            return !reader.IsDBNull(reader.GetOrdinal("product_id"));
        }
    }
}
