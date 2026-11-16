using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cc105_pose_proj.Forms
{
    public interface IDialogControl
    {
        event EventHandler<DialogResult> RequestClose;
    }
    public partial class PopupForm : Form
    {
        public PopupForm(UserControl control, string title)
        {
            InitializeComponent();
            this.Text = title;

            this.ClientSize = control.Size;
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

        public static DialogResult Open(IWin32Window owner, UserControl content, string title)
        {
            using var host = new PopupForm(content, title);
            return host.ShowDialog(owner);
        }
    }
}
