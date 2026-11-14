using cc105_pose_proj.Data;
using cc105_pose_proj.Models;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.Services
{
    public class DiscountService
    {
        private readonly IRepository<Discount> _discountRepo = new DiscountRepository();

        public DiscountService(IRepository<Discount>? repo) 
        {
            _discountRepo = repo ?? new DiscountRepository();
        }

        public List<Discount> GetDiscounts()
        {
            var allDiscounts = _discountRepo.GetAll();

            int? currentBusinessId = Session.CurrentUser?.Business?.Id;

            if (currentBusinessId == null)
                return allDiscounts;

            return allDiscounts.Where(d => d.CreatedBy.Id == currentBusinessId.Value).ToList();
        }

        public Discount? GetDiscountById(int id)
        {
            var discount = _discountRepo.GetById(id);

            if (discount == null) 
                return null;

            int? currentBusinessId = Session.CurrentUser?.Business?.Id;

            if (currentBusinessId != null && 
                discount.CreatedBy.Id != currentBusinessId.Value)
                return null;

            return discount;
        }

        public bool CreateDiscount(Discount discount)
        {
            var currentUserBusiness = Session.CurrentUser?.Business;
            if (currentUserBusiness != null)
                discount.CreatedBy = currentUserBusiness;
            return _discountRepo.Add(discount);
        }

        public bool UpdateDiscount(Discount discount)
        {
            if (GetDiscountById(discount.Id) == null) 
                return false;
            return _discountRepo.Update(discount);
        }

        public bool DeleteDiscount(int id)
        {
            if (GetDiscountById(id) == null) 
                return false;
            return _discountRepo.Delete(id);
        }
    }
}
