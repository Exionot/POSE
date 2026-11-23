using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Presenters;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;
using cc105_pose_proj.Util;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace cc105_pose_proj.UserControls
{
    public partial class ProfileSettingView : UserControl, IDialogControl, IProfileSettingView
    {
        public event EventHandler<DialogResult>? RequestClose;
        public event EventHandler? ImageSelectRequest;
        public event EventHandler? EditPasswordRequest;
        public event EventHandler? SaveRequest;
        public event EventHandler? ToggleShowPasswordRequest;
        public event EventHandler? BackRequest;


        private readonly ProfileSettingViewPresenter _presenter;
        private string _selectedImage = string.Empty;
        public ProfileSettingView(
            IBusinessService businessService,
            IDialogService dialogService,
            IUserService userService,
            User? user = null)
        {
            InitializeComponent();
            _presenter = new ProfileSettingViewPresenter(
                this, 
                businessService,
                dialogService,
                userService,
                user);

            saveBtn.Click += (_, _) => SaveRequest?.Invoke(this, EventArgs.Empty);
            selectImgBtn.Click += (_, _) => ImageSelectRequest?.Invoke(this, EventArgs.Empty);
            editPasswordBtn.Click += (_, _) => EditPasswordRequest?.Invoke(this, EventArgs.Empty);
            backBtn.Click += (_, _) => BackRequest?.Invoke(this, EventArgs.Empty);
            showPasswordCheckBox.Click += (_, _) => ToggleShowPasswordRequest?.Invoke(this, EventArgs.Empty);
        }

        public void Close(DialogResult dialogResult) => RequestClose?.Invoke(this, dialogResult);
        public void SetBusinesses(List<Business> businesses) => businessComboBox.DataSource = businesses;

        public void OpenEditPasswordDialog(User user)
        {
            var dialog = ActivatorUtilities.CreateInstance<EditPasswordView>(
                Program.ServiceProvider, user);
            PopupForm.Open(this, dialog, "Edit Password", customSize: true);
        }

        private void ProfileSettingView_Resize(object sender, EventArgs e)
        {
            int pictureBoxSize = (int)(this.ClientSize.Width / 2);
            profilePictureBox.Size = new Size(pictureBoxSize, pictureBoxSize);
            profilePictureBox.Left = (this.ClientSize.Width - profilePictureBox.Width) / 2;

            selectImgBtn.Top = profilePictureBox.Bottom + selectImgBtn.Margin.Top;
            selectImgBtn.Left = (this.ClientSize.Width - selectImgBtn.Width) / 2;

            nameRowpanel.Top = selectImgBtn.Bottom + selectImgBtn.Margin.Bottom;
            passwordRowPanel.Top = nameRowpanel.Bottom;
            businessRowPanel.Top = passwordRowPanel.Bottom;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Username
        {
            get => nameField.Text;
            set => nameField.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string Password
        {
            get => passwordField.Text;
            set => passwordField.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public Image? SelectedImage
        {
            get => profilePictureBox.Image;
            set
            {
                var old = profilePictureBox.Image;
                profilePictureBox.Image = value;
                old?.Dispose();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Business? SelectedBusiness
        {
            get => businessComboBox.SelectedItem as Business;
            set => businessComboBox.SelectedItem = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BusinessSelectionEnabled
        {
            set => businessComboBox.Enabled = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PasswordControlEnabled
        {
            set 
            {
                passwordField.Enabled = value;
                showPasswordCheckBox.Enabled = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPasswordShown
        {
            get => showPasswordCheckBox.Checked;
            set => showPasswordCheckBox.Checked = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char PasswordChar
        {
            set => passwordField.PasswordChar = value;
        }
    }
}
