using cc105_pose_proj.Util;

namespace cc105_pose_proj.Forms
{
    using cc105_pose_proj.Navigation;
    using cc105_pose_proj.UserControls;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Win32;

    public partial class MainForm : Form, INavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly BuyerForm _buyerForm;

        public MainForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();

            _buyerForm = _serviceProvider.GetRequiredService<BuyerForm>();
            _buyerForm.Show();

            if (DisplayUtil.hasMultipleDisplay())
                DisplayUtil.changeScreen(_buyerForm, Screen.AllScreens[1]);
            SystemEvents.DisplaySettingsChanged += NewDisplayListener;
        }

        public void NavigateTo(UserControl view)
        {
            mainPanel.Controls.Clear();

            view.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(view);
        }

        public void NavigateTo<T>() where T : UserControl
        {
            T view = ActivatorUtilities.CreateInstance<T>(_serviceProvider, this);
            NavigateTo(view);
        }

        public void NavigateTo<T>(Action<T> action) where T : UserControl
        {
            T view = _serviceProvider.GetRequiredService<T>();
            action(view);
            NavigateTo(view);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NavigateTo<Login>();
        }

        private void NewDisplayListener(object? sender, EventArgs e)
        {
            if (DisplayUtil.hasMultipleDisplay()) 
                DisplayUtil.changeScreen(_buyerForm, Screen.AllScreens[1]);
            else 
                DisplayUtil.changeScreen(_buyerForm, Screen.PrimaryScreen!);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SystemEvents.DisplaySettingsChanged -= NewDisplayListener;
            if (!_buyerForm.IsDisposed)
                _buyerForm.Close();

            base.OnFormClosed(e);
        }
    }
}
