using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace cc105_pose_proj.Controls
{
    public class RoundedKryptonPanel : KryptonPanel
    {
        private int _cornerRadius = 15;

        [DefaultValue(15)]
        [Category("Appearance")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                if (value < 0) value = 0;
                if (_cornerRadius == value) return;
                _cornerRadius = value;
                UpdateRegion();
                Invalidate();
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0) return;

            Region oldRegion = Region;

            if (_cornerRadius == 0)
            {
                Region = null;
            }
            else
            {
                // Arc bounding box is the DIAMETER, so double the radius
                int d = Math.Min(_cornerRadius * 2, Math.Min(Width, Height));

                using (var path = new GraphicsPath())
                {
                    path.AddArc(0, 0, d, d, 180, 90);
                    path.AddArc(Width - d, 0, d, d, 270, 90);
                    path.AddArc(Width - d, Height - d, d, d, 0, 90);
                    path.AddArc(0, Height - d, d, d, 90, 90);
                    path.CloseFigure();

                    Region = new Region(path);
                }
            }

            oldRegion?.Dispose();
        }
    }
}