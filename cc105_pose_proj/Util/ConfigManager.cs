using System.Text.Json;

namespace cc105_pose_proj.Util
{
    public class ConfigManager
    {
        public static JsonElement Config { get; }

        static ConfigManager()
        {
            if (!File.Exists(AppPaths.ConfigFile))
                throw new FileNotFoundException(
                    $"config.json not found. Expected at: {AppPaths.ConfigFile}");

            using JsonDocument doc = JsonDocument.Parse(File.ReadAllBytes(AppPaths.ConfigFile));
            Config = doc.RootElement.Clone();
        }
    }
}
