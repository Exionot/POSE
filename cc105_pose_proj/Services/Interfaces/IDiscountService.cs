using cc105_pose_proj.Models;

namespace cc105_pose_proj.Services.Interfaces
{
    public interface IDiscountService
    {
        bool CreateDiscount(Discount discount);
        bool DeleteDiscount(int id);
        Discount? GetDiscountById(int id);
        List<Discount> GetDiscounts();
        bool UpdateDiscount(Discount discount);
    }
}