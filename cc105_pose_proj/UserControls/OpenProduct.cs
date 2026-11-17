using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.UserControls
{
    public partial class OpenProduct : UserControl, IDialogControl
    {
        public event EventHandler<DialogResult>? RequestClose;
        private readonly Product? _product;
        public OpenProduct(Product? product)
        {
            _product = product;
            InitializeComponent();
            ResizeControl();
        }

        private void ResizeControl()
        {
            MainForm? main = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (main == null)
                return;

            this.Size = new Size(
                (int)(main.ClientSize.Width / 3),
                (int)(main.ClientSize.Height * 0.9)
            );
        }

        private void OpenProduct_Load(object sender, EventArgs e)
        {
            if (_product == null)
                return;

        }

        private void OpenProduct_Resize(object sender, EventArgs e)
        {

        }
    }
}
