using cc105_pose_proj.Models;
using cc105_pose_proj.Navigation;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls;
using cc105_pose_proj.UserControls.Interfaces;

namespace cc105_pose_proj.Presenters
{
    public class DiscountViewPresenter
    {
        private readonly IDiscountView _view;
        private readonly IDiscountService _discountService;
        private readonly INavigator _nav;

        public DiscountViewPresenter(
            IDiscountView view,
            IDiscountService discountService,
            INavigator nav)
        {
            _view = view;
            _discountService = discountService;
            _nav = nav;

            _view.CreateDiscountRequest += HandleAddDiscount;
            _view.EditDiscountRequest += HandleEditDiscount;
            _view.BackRequest += (_, _) => _nav.NavigateTo<Home>();

            LoadDiscounts();
        }

        private void LoadDiscounts()
        {
            var discounts = _discountService.GetDiscounts();
            _view.SetDiscounts(discounts);
        }

        private void HandleAddDiscount(object? sender, EventArgs e)
        {
            if (_view.OpenDiscountDialog(null))
            {
                LoadDiscounts();
            }
        }

        private void HandleEditDiscount(object? sender, Discount discount)
        {
            if (_view.OpenDiscountDialog(discount))
            {
                LoadDiscounts();
            }
        }
    }
}
