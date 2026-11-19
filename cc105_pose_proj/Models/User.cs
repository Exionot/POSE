namespace cc105_pose_proj.Models
{
    public class User
    {
        public int Id { get; init; }
        public required string Username { get; set; }
        public Business? Business { get; set; }
        public required bool IsAdmin { get; set; }
        public string Image { get; set; } = "Default.png";
    }
}
