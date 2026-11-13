using cc105_pose_proj.Util;

namespace cc105_pose_proj
{
    using cc105_pose_proj.Navigation;
    using Microsoft.Win32;

    public partial class MainForm : Form, INavigator
    {
        private readonly Form buyerForm = null!;
        public MainForm()
        {
            InitializeComponent();
            buyerForm = new Form1();
            buyerForm.Show();
            if (DisplayUtil.hasMultipleDisplay())
                DisplayUtil.changeScreen(buyerForm, Screen.AllScreens[1]);
            SystemEvents.DisplaySettingsChanged += NewDisplayListener;
        }

        public void NavigateTo(UserControl view)
        {
            mainPanel.Controls.Clear();

            view.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(view);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NavigateTo(new Login(this));
        }

        private void NewDisplayListener(object sender, EventArgs e)
        {
            if (DisplayUtil.hasMultipleDisplay()) 
                DisplayUtil.changeScreen(buyerForm, Screen.AllScreens[1]);
            else 
                DisplayUtil.changeScreen(buyerForm, Screen.PrimaryScreen!);
        }
    }
}
