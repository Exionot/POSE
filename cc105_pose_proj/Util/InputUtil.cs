using Krypton.Toolkit;

namespace cc105_pose_proj.Util
{
    public class InputUtil
    {
        public static void DecimalOnly(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.')
            {
                string text = sender switch
                {
                    KryptonTextBox ktb => ktb.Text,
                    TextBoxBase tb => tb.Text,
                    _ => string.Empty
                };

                if (!text.Contains('.'))
                    return;
            }

            e.Handled = true;
        }

        public static void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
