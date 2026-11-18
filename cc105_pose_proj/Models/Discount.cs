namespace cc105_pose_proj.Models
{
    public enum DiscountType
    {
        PERCENTAGE,
        FIXED,
        BUY_X_GET_Y
    }

    public class Discount
    {
        public int Id { get; init; }
        public required string Name { get; set; }
        public required DiscountType Type { get; set; }
        public required decimal Value { get; set; }
        public int BuyAmount { get; set; }
        public int GetAmount { get; set; }
        public bool Active { get; set; }
        public required Business CreatedBy { get; set; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
        public List<Product> EligibleItems { get; set; } = [];
    }

    
}
