using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Services;

namespace cc105_pose_proj.UserControls
{
    public partial class DiscountView : UserControl
    {
        private readonly DiscountService _discountService = new();
        private readonly INavigator _nav;
        public DiscountView(INavigator nav)
        {
            _nav = nav;
            InitializeComponent();
        }

        private void DiscountView_Load(object sender, EventArgs e)
        {
            RefreshDiscount();
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

            discountTicketFlowPanel.Width = mainViewPanel.Width - mainViewPanel.Padding.Left - mainViewPanel.Padding.Right;
            discountTicketFlowPanel.Height = mainViewPanel.Height - mainViewPanel.Padding.Top - mainViewPanel.Padding.Bottom;
            discountTicketFlowPanel.Top = mainViewPanel.Padding.Top;
            discountTicketFlowPanel.Left = mainViewPanel.Padding.Left;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo(new Home(_nav));
        }

        private void EditDiscount(Discount d)
        {
            var result = PopupForm.Open(this, new EditDiscount(d), d.Name);

            if (result == DialogResult.OK)
                RefreshDiscount();
        }

        private void RefreshDiscount()
        {
            discountTicketFlowPanel.Controls.Clear();
            foreach (Discount d in _discountService.GetDiscounts())
            {
                var ticket = new DiscountTicket(d, 160);
                ticket.editBtn.Click += (_, _) => EditDiscount(d);
                discountTicketFlowPanel.Controls.Add(ticket);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var result = PopupForm.Open(this, new EditDiscount(), "New Discount");

            if (result == DialogResult.OK)
                RefreshDiscount();
        }
    }
}
