using Mysqlx.Crud;

namespace cc105_pose_proj.Forms
{
    public interface IDialogControl
    {
        event EventHandler<DialogResult> RequestClose;
    }
    public partial class PopupForm : Form
    {
        public PopupForm(UserControl control, string title, Form? owner = null)
        {
            InitializeComponent();
            this.Text = title;
            this.StartPosition = FormStartPosition.CenterParent;

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

        public static DialogResult Open(IWin32Window owner, UserControl content, string title)
        {
            Form? ownerForm = owner as Form ?? Form.ActiveForm;

            using var host = new PopupForm(content, title);
            return host.ShowDialog(owner);
        }
    }
}
