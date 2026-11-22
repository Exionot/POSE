using Mysqlx.Crud;

namespace cc105_pose_proj.Forms
{
    public interface IDialogControl
    {
        event EventHandler<DialogResult> RequestClose;
    }
    public partial class PopupForm : Form
    {
        public PopupForm(UserControl control, string title, bool showExit, Form? owner = null)
        {
            InitializeComponent();
            this.Text = title;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = showExit;

            if (owner != null)
            {
                this.ClientSize = new Size(
                    (int)(owner.ClientSize.Width / 3.0),
                    (int)(owner.ClientSize.Height * 0.9)
                );
            }
            else
            {
                this.ClientSize = control.Size;
            }

            control.Dock = DockStyle.Fill;
            this.Controls.Add(control);

            if (control is IDialogControl dialogControl)
            {
                dialogControl.RequestClose += (_, result) =>
                {
                    this.DialogResult = result;
                    this.Close();
                };
            }
        }

        public static DialogResult Open(IWin32Window owner, UserControl content, string title, bool showExit = false)
        {
            Form? ownerForm = owner as Form ?? Form.ActiveForm;

            using var host = new PopupForm(content, title, showExit, ownerForm);
            return host.ShowDialog(owner);
        }
    }
}
