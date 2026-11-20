using cc105_pose_proj.Models;

namespace cc105_pose_proj.Util
{
    public static class Buttons
    {
        private static readonly ToolTip ToolTip = new();
        public static Button CreateProductButton(Product p, int size = 100, bool displayName = true)
        {
            var btn = new Button();
            int btnSize = size;
            int txtAllowance = 20;
            btn.AutoSize = false;
            btn.Size = new Size(btnSize + txtAllowance, btnSize + txtAllowance);
            btn.Margin = new Padding(3);

            btn.Text = displayName ? p.Name : "";
            btn.TextAlign = ContentAlignment.BottomCenter;
            btn.Font = new Font("Inter", 9f, FontStyle.Bold);

            ToolTip.SetToolTip(btn, p.Name);

            Image img = Image.FromFile(AppPaths.ResourceDir + p.Image);

            double ratio = Math.Min((double)btnSize / img.Width, (double)btnSize / img.Height);

            int height = (int)(img.Height * ratio);
            int width = (int)(img.Width * ratio);

            btn.Image?.Dispose();
            btn.Image = new Bitmap(img, new Size(width, height));

            btn.ImageAlign = ContentAlignment.BottomCenter;
            btn.TextImageRelation = TextImageRelation.ImageAboveText;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = SystemColors.ControlDark;

            return btn;
        }

        public static bool ToggleButton(this Button btn)
        {
            bool toggled = !(btn.Tag is true);

            btn.Tag = toggled;

            btn.BackColor = toggled ? Color.Goldenrod : SystemColors.Control;
            btn.ForeColor = toggled ? Color.White : SystemColors.ControlText;

            return toggled;
        }
    }
}
