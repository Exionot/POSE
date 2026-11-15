using cc105_pose_proj.Models;

namespace cc105_pose_proj.Util
{
    public class Buttons
    {
        public static Button CreateProductButton(Button btn, Product p)
        {
            int btnSize = 100;
            int txtAllowance = 20;
            btn.AutoSize = false;
            btn.Size = new Size(btnSize + txtAllowance, btnSize + txtAllowance);
            btn.Margin = new Padding(0);

            btn.Text = p.Name;
            btn.TextAlign = ContentAlignment.BottomCenter;

            Image img = Image.FromFile(AppPaths.ResourceDir + p.Image);

            double ratio = Math.Min((double)btnSize / img.Width, (double)btnSize / img.Height);

            int height = (int)(img.Height * ratio);
            int width = (int)(img.Width * ratio);

            btn.Image?.Dispose();
            btn.Image = new Bitmap(img, new Size(width, height));

            btn.ImageAlign = ContentAlignment.BottomCenter;
            btn.TextImageRelation = TextImageRelation.ImageAboveText;

            return btn;
        }
    }
}
