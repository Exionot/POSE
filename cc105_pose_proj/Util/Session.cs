using cc105_pose_proj.Models;

namespace cc105_pose_proj.Util
{
    public static class Session
    {
        public static User? CurrentUser { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;

        public static void SignIn(User user) => CurrentUser = user;
        public static void SignOut() => CurrentUser = null;
    }
}
