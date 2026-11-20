using cc105_pose_proj.Navigation;

namespace cc105_pose_proj.UserControls
{
    public partial class DiscountView : UserControl
    {
        private readonly INavigator _nav;
        public DiscountView(INavigator nav)
        {
            _nav = nav;
            InitializeComponent();
        }

        private void DiscountView_Load(object sender, EventArgs e)
        {

        }

        private void DiscountView_Resize(object sender, EventArgs e)
        {
            headerPanel.Width = this.ClientSize.Width - headerPanel.Margin.Left - headerPanel.Margin.Right;
            headerPanel.Top = headerPanel.Margin.Top;
            headerPanel.Left = headerPanel.Margin.Left;

            mainViewPanel.Width = this.ClientSize.Width - mainViewPanel.Margin.Left - mainViewPanel.Margin.Right;
            mainViewPanel.Height =
                this.ClientSize.Height - headerPanel.Height -
                mainViewPanel.Margin.Bottom - mainViewPanel.Margin.Top -
                headerPanel.Margin.Bottom - headerPanel.Margin.Top;
            mainViewPanel.Top = headerPanel.Bottom + headerPanel.Margin.Bottom + mainViewPanel.Margin.Top;
            mainViewPanel.Left = mainViewPanel.Margin.Left;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo(new Home(_nav));
        }
    }
}
