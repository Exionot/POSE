using cc105_pose_proj.Forms;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Presenters;
using cc105_pose_proj.Properties;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;
using cc105_pose_proj.Util;
using Krypton.Toolkit;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace cc105_pose_proj.UserControls
{
    public partial class Home : UserControl, IHomeView
    {
        public event EventHandler<NavigationEventArgs>? NavigationRequest;
        public event EventHandler? SettingsRequest;

        private readonly HomeViewPresenter _presenter;
        public Home(INavigator nav, IDialogService dialogService)
        {
            InitializeComponent();
            _presenter = new HomeViewPresenter(this, nav, dialogService);

            newTransactionBtn.Click += (_, _) =>
                NavigationRequest?.Invoke(this, new NavigationEventArgs(NavigationTarget.MainTransaction));

            viewMovementBtn.Click += (_, _) =>
                NavigationRequest?.Invoke(this, new NavigationEventArgs(NavigationTarget.Inventory));

            viewSalesBtn.Click += (_, _) =>
                NavigationRequest?.Invoke(this, new NavigationEventArgs(NavigationTarget.DiscountView));

            logoutBtn.Click += (_, _) =>
                NavigationRequest?.Invoke(this, new NavigationEventArgs(NavigationTarget.Login));

            settingBtn.Click += (_, _) =>
                SettingsRequest?.Invoke(this, EventArgs.Empty);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            settingBtn.FitIcon(Resources.setting_icon, 7);

            SetupButtonAnimations();
        }

        private void SetupButtonAnimations()
        {
            components ??= new System.ComponentModel.Container();

            foreach (var btn in mainButtonPanel.Controls.OfType<KryptonButton>())
            {
                int originalWidth = btn.Width;
                int originalHeight = btn.Height;

                int tWidth = originalWidth;
                int tHeight = originalHeight;

                int originalLeft = btn.Left;
                int originalTop = btn.Top;

                Timer btnAnimate = new(components);
                int expandAmount = 20;
                btnAnimate.Interval = 15;

                btn.MouseEnter += (s, ev) =>
                {
                    tWidth = originalWidth + expandAmount;
                    tHeight = originalHeight + expandAmount;
                    btnAnimate.Start();
                };

                btn.MouseLeave += (s, ev) =>
                {
                    tWidth = originalWidth;
                    tHeight = originalHeight;
                    btnAnimate.Start();
                };

                btnAnimate.Tick += (s, ev) =>
                {
                    int speed = 2;

                    if (btn.Width < tWidth)
                        btn.Width = Math.Min(btn.Width + speed, tWidth);
                    else if (btn.Width > tWidth)
                        btn.Width = Math.Max(btn.Width - speed, tWidth);

                    if (btn.Height < tHeight)
                        btn.Height = Math.Min(btn.Height + speed, tHeight);
                    else if (btn.Height > tHeight)
                        btn.Height = Math.Max(btn.Height - speed, tHeight);

                    if (btn.Width == tWidth && btn.Height == tHeight)
                        btnAnimate.Stop();

                    btn.Left = originalLeft - (btn.Width - originalWidth) / 2;
                    btn.Top = originalTop - (btn.Height - originalHeight) / 2;
                };
            }
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            mainButtonPanel.Top = (this.ClientSize.Height - mainButtonPanel.Height) / 2;
            mainButtonPanel.Left = (this.ClientSize.Width - mainButtonPanel.Width) / 2;
            profilePanel.Top = profilePanel.Margin.Top;
            profilePanel.Left = (this.ClientSize.Width - profilePanel.Width) / 2;
            businessNameLabel.Top = (profilePanel.Height - businessNameLabel.Height) / 2;
        }

        public void OpenSettingsDialog()
        {
            var view = ActivatorUtilities.CreateInstance<ProfileSettingView>(
                Program.ServiceProvider, Session.CurrentUser!);

            PopupForm.Open(this, view, "Settings", true);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayName
        {
            set => businessNameLabel.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image? ProfileImage
        {
            set => userProfilePictureBox.Image = value;
        }

        
    }
}
