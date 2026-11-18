namespace cc105_pose_proj.Models
{
    public enum MovementType
    {
        STOCK_IN,
        SALE_OUT,
        ADJUST_IN,
        ADJUST_OUT,
        DAMAGE,
        SPOILAGE,
        LOST,
        RETURN,
        SCRAP
    }

    public class InventoryMovement
    {
        public int Id { get; init; }
        public required Product Product { get; set; }
        public required MovementType Type { get; set; }
        public required int Quantity { get; set; }
        public required User CreatedBy { get; set; }
        public DateTime CreatedAt { get; init; }
    }
}
