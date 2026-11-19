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
        public int Id { get; set; }
        public required Product Product { get; set; }
        public required MovementType Type { get; set; }
        public required int Quantity { get; set; }
        public required User CreatedBy { get; set; }
        public DateTime CreatedAt { get; init; }
    }

    public record MovementReasonItem(MovementType Type, string DisplayText, bool IsAddition)
    {
        public override string ToString() => DisplayText;

        public static readonly List<MovementReasonItem> All =
        [
            new(MovementType.STOCK_IN, "Stock In (+)", true),
            new(MovementType.ADJUST_IN, "Adjustment (+)", true),
            new(MovementType.RETURN, "Customer Return (+)", true),
            new(MovementType.ADJUST_OUT, "Adjustment (-)", false),
            new(MovementType.DAMAGE, "Damaged / Broken (-)", false),
            new(MovementType.SPOILAGE, "Expired (-)", false),
            new(MovementType.LOST, "Lost (-)", false),
            new(MovementType.SCRAP, "Discarded (-)", false)
        ];
    }
}
