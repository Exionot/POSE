namespace cc105_pose_proj.Util
{
    public static class AppPaths
    {
        public static String RootDir { get; } = AppContext.BaseDirectory;
        public static string ResourceDir { get; } = Path.Combine(RootDir, @"Resources\");
        public static string ConfigFile { get; } = Path.Combine(RootDir, "config.json");

    }
}
