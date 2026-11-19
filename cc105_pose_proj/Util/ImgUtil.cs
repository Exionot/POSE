using Krypton.Toolkit;
using System.Windows.Forms;

namespace cc105_pose_proj.Util
{
    public static class ImgUtil
    {
        private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png", ".webp"];

        public static void ValidateImg(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                throw new FileNotFoundException("The selected image file does not exist.", path);
            }

            string extension = Path.GetExtension(path).ToLowerInvariant();
            if (Array.IndexOf(AllowedExtensions, extension) == -1)
            {
                throw new ArgumentException("Only JPG, PNG, and WebP images are allowed.");
            }
        }

        public static string SaveImg(string path)
        {
            ValidateImg(path);

            Directory.CreateDirectory(AppPaths.ResourceDir);

            string extension = Path.GetExtension(path).ToLowerInvariant();
            string uniqueFileName = $"{Guid.NewGuid()}{extension}";
            string destinationPath = Path.Combine(AppPaths.ResourceDir, uniqueFileName);

            File.Copy(path, destinationPath, true);

            return uniqueFileName;
        }

        public static string ReplaceImage(string? oldFileName, string newSourcePath)
        {
            string newFileName = SaveImg(newSourcePath);

            DeleteImage(oldFileName);

            return newFileName;
        }

        public static void DeleteImage(string? fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                string fullPath = Path.Combine(AppPaths.ResourceDir, fileName);
                FileUtil.SafeDelete(fullPath);
            }
        }

        public static void FitIcon(this KryptonButton btn, Image src, int padding = 0)
        {
            int box = Math.Max(1, Math.Min(btn.Width, btn.Height) - padding * 2);
            float s = Math.Min(
                (float)Math.Max(1, box) / src.Width,
                (float)Math.Max(1, box) / src.Height);
            int w = Math.Max(1, (int)(src.Width * s));
            int h = Math.Max(1, (int)(src.Height * s));

            btn.Values.Image = new Bitmap(src, w, h);
        }
    }
}
