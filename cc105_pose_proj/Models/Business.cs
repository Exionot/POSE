namespace cc105_pose_proj.Models
{
    public class Business
    {
        public int Id { get; init; }
        public required string Name { get; set; }

        public override string ToString() => Name;
    }
}
