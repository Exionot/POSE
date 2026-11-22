using cc105_pose_proj.Data;
using cc105_pose_proj.Models;
using cc105_pose_proj.Services.Interfaces;

namespace cc105_pose_proj.Services
{
    public class DiscountService : BaseService, IDiscountService
    {
        private readonly IRepository<Discount> _discountRepo = new DiscountRepository();

        public DiscountService(IRepository<Discount>? repo = null)
        {
            _discountRepo = repo ?? new DiscountRepository();
        }

        public List<Discount> GetDiscounts()
        {
            if (CurrentUser == null) return [];
            var allDiscounts = _discountRepo.GetAll();

            if (IsAdmin)
                return allDiscounts;

            if (CurrentBusinessId == null)
                return [];

            return allDiscounts.Where(d => d.CreatedBy.Id == CurrentBusinessId.Value).ToList();
        }

        public Discount? GetDiscountById(int id)
        {
            if (CurrentUser == null) return null;

            var discount = _discountRepo.GetById(id);
            if (discount == null)
                return null;

            int? currentBusinessId = CurrentBusinessId;

            if (!IsAdmin && discount.CreatedBy.Id != CurrentBusinessId)
                return null;

            return discount;
        }

        public bool CreateDiscount(Discount discount)
        {
            if (CurrentUser == null) return false;
            if (!IsAdmin && CurrentBusiness == null) return false;

            if (CurrentBusiness != null)
                discount.CreatedBy = CurrentBusiness;
            if (discount.CreatedBy == null)
                return false;

            return _discountRepo.Add(discount);
        }

        public bool UpdateDiscount(Discount discount)
        {
            if (CurrentUser == null) return false;

            if (GetDiscountById(discount.Id) == null)
                return false;

            return _discountRepo.Update(discount);
        }

        public bool DeleteDiscount(int id)
        {
            if (CurrentUser == null) return false;

            if (GetDiscountById(id) == null)
                return false;

            return _discountRepo.Delete(id);
        }
    }
}
