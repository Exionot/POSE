using cc105_pose_proj.Util;

namespace cc105_pose_proj.Models
{
    public class Product
    {
        public int Id { get; init; }
        public required string Name { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
        public required Business Business { get; set; }
        public string Image { get; set; } = AppPaths.ResourceDir + "Default.png";
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
