using cc105_pose_proj.Data.Mappers;
using cc105_pose_proj.Models;
using MySql.Data.MySqlClient;
using System.Transactions;

namespace cc105_pose_proj.Data
{
    public class InventoryMovementRepository : IRepository<InventoryMovement>
    {
        string BaseSelectQuery = @$"
            select
                im.id as movement_id,
                im.type as movement_type,
                im.quantity as movement_quantity,
                im.created_at as movement_created_at,

                {ProductMapper.Columns},
                {UserMapper.Columns}

            from inventory_movement as im
            inner join products as p on im.product_id = p.id
            inner join business as pb on p.business_id = pb.id
            inner join users as u on im.created_by = u.id
            left join business as ub on u.id = ub.user_id
        ";

        public List<InventoryMovement> GetAll()
        {
            var list = new List<InventoryMovement>();
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = $"{BaseSelectQuery} order by im.created_at desc";
            using var cmd = new MySqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(CreateMovement(reader));
            }

            return list;
        }

        public InventoryMovement? GetById(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = $"{BaseSelectQuery} where im.id = @id limit 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return CreateMovement(reader);
        }

        public List<InventoryMovement> GetByProductId(int productId)
        {
            var list = new List<InventoryMovement>();
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = $"{BaseSelectQuery} where im.product_id = @productId order by im.created_at desc";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@productId", productId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(CreateMovement(reader));
            }

            return list;
        }

        public bool Add(InventoryMovement entity)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();
            return Add(entity, conn, null);
        }

        public bool Add(InventoryMovement entity, MySqlConnection conn, MySqlTransaction? transaction)
        {
            string query = @"
                insert into inventory_movement (product_id, type, quantity, created_by)
                values (@product_id, @type, @quantity, @created_by)";

            using var cmd = new MySqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@product_id", entity.Product.Id);
            cmd.Parameters.AddWithValue("@type", entity.Type.ToString());
            cmd.Parameters.AddWithValue("@quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@created_by", entity.CreatedBy.Id);

            entity.Id = Convert.ToInt32(cmd.ExecuteScalar());
            return true;
        }

        public bool Update(InventoryMovement entity)
        {
            throw new NotSupportedException("Inventory movements cannot be updated.");
        }

        public bool Delete(int id)
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string query = "delete from inventory_movement where id = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        private static InventoryMovement CreateMovement(MySqlDataReader reader)
        {
            string typeString = reader.GetString("movement_type");
            Enum.TryParse<MovementType>(typeString, true, out var movementType);

            return new InventoryMovement
            {
                Id = reader.GetInt32("movement_id"),
                Product = ProductMapper.CreateProduct(reader),
                CreatedBy = UserMapper.CreateUser(reader),
                Type = movementType,
                Quantity = reader.GetInt32("movement_quantity"),
                CreatedAt = reader.GetDateTime("movement_created_at")
            };
        }
    }
}
