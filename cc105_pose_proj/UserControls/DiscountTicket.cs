using cc105_pose_proj.Models;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.UserControls
{
    public partial class DiscountTicket : UserControl
    {
        private readonly Discount _discount;
        private readonly float _initialFormWidth;
        private readonly float _initialFormHeight;
        private readonly Dictionary<Label, float> _initialFontSizes = new();
        private readonly Size _initialButtonSize;
        private readonly float _initialButtonFontSize;
        public DiscountTicket(Discount discount, int height = 0)
        {
            _discount = discount;
            InitializeComponent();

            _initialFormWidth = this.ClientSize.Width;
            _initialFormHeight = this.ClientSize.Height;

            _initialButtonSize = editBtn.Size;
            _initialButtonFontSize = editBtn.StateCommon.Content.ShortText.Font!.Size;

            foreach (var label in this.Controls.OfType<Label>())
            {
                _initialFontSizes[label] = label.Font.Size;
            }

            if (height > 0)
            {
                float ratio = height / _initialFormHeight;
                int newWidth = (int)(_initialFormWidth * ratio);
                this.ClientSize = new Size(newWidth, height);
            }
        }


        private void DiscountTicket_Load(object sender, EventArgs e)
        {
            nameLabel.Text = _discount.Name;
            typeLabel.Text = _discount.Type.ToString();
            valueLabel.Text = _discount.Type switch
            {
                Discount.DiscountType.PERCENTAGE
                    => (_discount.Value / 100m).ToString("P2"),
                Discount.DiscountType.FIXED
                    => _discount.Value.ToString("C2"),
                Discount.DiscountType.BUY_X_GET_Y
                    => $"Buy {_discount.BuyAmount}, Get {_discount.GetAmount}",
                _ => "N/A"
            };

            itemsFlowPanel.Controls.Clear();
            foreach (var item in _discount.EligibleItems)
            {
                int size = itemsFlowPanel.Height;

                var pb = new PictureBox();
                pb.Size = new Size(size, size);

                Image img = Image.FromFile(AppPaths.ResourceDir + item.Image);

                double ratio = Math.Min((double)size / img.Width, (double)size / img.Height);

                int height = (int)(img.Height * ratio);
                int width = (int)(img.Width * ratio);

                pb.Image = new Bitmap(img, new Size(width, height));

                itemsFlowPanel.Controls.Add(pb);
            }
        }

        private void DiscountTicket_Resize(object sender, EventArgs e)
        {
            if (_initialFormWidth == 0 || _initialFormHeight == 0) 
                return;

            float widthRatio = this.ClientSize.Width / _initialFormWidth;
            float heightRatio = this.ClientSize.Height / _initialFormHeight;
            float scaleFactor = Math.Min(widthRatio, heightRatio);

            var oldPadding = this.Padding;
            this.Padding = new Padding((int)(oldPadding.All * scaleFactor));

            editBtn.Size = new Size(
                (int)(_initialButtonSize.Width * scaleFactor),
                (int)(_initialButtonSize.Height * scaleFactor));
            Font oldBtnFont = editBtn.StateCommon.Content.ShortText.Font!;
            float newBtnFontSize = Math.Max(8f, _initialButtonFontSize * scaleFactor);
            editBtn.StateCommon.Content.ShortText.Font = new Font(oldBtnFont.FontFamily, newBtnFontSize, oldBtnFont.Style);
            editBtn.Left = this.Right - this.Padding.Right - editBtn.Width;

            foreach (var label in this.Controls.OfType<Label>())
            {
                if (!_initialFontSizes.TryGetValue(label, out float baseFontSize))
                    continue;

                Font oldFont = label.Font;
                float newFontSize = Math.Max(8f, baseFontSize * scaleFactor);
                label.Font = new Font(oldFont.FontFamily, newFontSize, oldFont.Style);

                if (oldFont != this.Font)
                    oldFont.Dispose();
            }

            typeLabel.Top = nameLabel.Bottom;
            valueLabel.Top = typeLabel.Bottom;

            Size flowPanelSize = itemsFlowPanel.Size;
            itemsFlowPanel.Size = new Size(
                (int)(flowPanelSize.Width * scaleFactor),
                (int)(flowPanelSize.Height * scaleFactor));
            itemsFlowPanel.Top = this.Bottom - this.Padding.Bottom - itemsFlowPanel.Height;

            appliedToLabel.Top = itemsFlowPanel.Top - appliedToLabel.Height;
        }
    }
}
