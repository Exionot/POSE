using cc105_pose_proj.Models;

namespace cc105_pose_proj.UserControls.Interfaces
{
    public interface IDiscountView
    {
        void SetDiscounts(List<Discount> discounts);
        bool OpenDiscountDialog(Discount? discount = null);

        event EventHandler? CreateDiscountRequest;
        event EventHandler<Discount> EditDiscountRequest;
        event EventHandler? BackRequest;
    }
}
