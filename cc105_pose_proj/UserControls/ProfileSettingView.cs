using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Presenters;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;
using cc105_pose_proj.Util;
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
        public ProfileSettingView(IAuthService authService, IDialogService dialogService)
        {
            InitializeComponent();
            _presenter = new ProfileSettingViewPresenter(this, authService, dialogService);

            saveBtn.Click += (_, _) => SaveRequest?.Invoke(this, EventArgs.Empty);
            selectImgBtn.Click += (_, _) => ImageSelectRequest?.Invoke(this, EventArgs.Empty);
            editPasswordBtn.Click += (_, _) => EditPasswordRequest?.Invoke(this, EventArgs.Empty);
            backBtn.Click += (_, _) => BackRequest?.Invoke(this, EventArgs.Empty);
            showPasswordCheckBox.CheckStateChanged += (_, _) => ToggleShowPasswordRequest?.Invoke(this, EventArgs.Empty);
        }

        public void Close(DialogResult dialogResult) => RequestClose?.Invoke(this, dialogResult);
        public void SetProfileImage(Image image) => profilePictureBox.Image = image;
        public void SetBusinesses(List<Business> businesses) => businessComboBox.DataSource = businesses;

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

        public string SelectedImage
        {
            get => _selectedImage;
            set => _selectedImage = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public Business? SelectedBusiness
        {
            get => businessComboBox.SelectedItem as Business;
            set => businessComboBox.SelectedItem = value;
        }
    }
}
