using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Presenters;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls.Interfaces;

namespace cc105_pose_proj.UserControls
{
    public partial class DiscountView : UserControl, IDiscountView
    {
        public event EventHandler? CreateDiscountRequest;
        public event EventHandler<Discount>? EditDiscountRequest;
        public event EventHandler? BackRequest;

        private readonly DiscountViewPresenter _presenter;
        public DiscountView(INavigator nav, IDiscountService discountService)
        {
            InitializeComponent();
            _presenter = new DiscountViewPresenter(this, discountService, nav);

            addButton.Click += (_, _) => CreateDiscountRequest?.Invoke(this, EventArgs.Empty);
            backBtn.Click += (_, _) => BackRequest?.Invoke(this, EventArgs.Empty);
        }

        public void SetDiscounts(List<Discount> discounts)
        {
            discountTicketFlowPanel.Controls.Clear();
            foreach (Discount d in discounts)
            {
                var ticket = new DiscountTicket(d, 160);
                ticket.editBtn.Click += (_, _) => EditDiscountRequest?.Invoke(this, d);
                discountTicketFlowPanel.Controls.Add(ticket);
            }
        }

        public bool OpenDiscountDialog(Discount? discount = null)
        {
            string title = discount != null ? discount.Name : "New Discount";
            var content = discount != null ? new EditDiscount(discount) : new EditDiscount();

            DialogResult result = PopupForm.Open(this, content, title);
            return result == DialogResult.OK;
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
    }
}
