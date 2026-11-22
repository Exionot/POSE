using cc105_pose_proj.Data;
using cc105_pose_proj.Models;
using cc105_pose_proj.Services.Interfaces;

namespace cc105_pose_proj.Services
{
    public class BusinessService : BaseService, IBusinessService
    {
        private readonly IRepository<Business> _businessRepo;

        public BusinessService(IRepository<Business>? businessRepo = null)
        {
            _businessRepo = businessRepo ?? new BusinessRepository();
        }

        public List<Business> GetBusinesses()
        {
            var allBusiness = _businessRepo.GetAll();

            if (CurrentBusiness == null)
                return allBusiness;

            return [CurrentBusiness];
        }

        public Business? GetBusinessById(int id)
        {
            if (CurrentBusiness != null && CurrentBusiness.Id != id)
                return null;

            return _businessRepo.GetById(id);
        }

        public bool CreateBusiness(Business business)
        {
            if (CurrentUser == null) return false;

            if (!IsAdmin && CurrentBusiness != null)
                return false;

            return _businessRepo.Add(business);
        }

        public bool UpdateBusiness(Business business)
        {
            if (CurrentUser == null) return false;

            if (!IsAdmin && CurrentBusiness?.Id != business.Id)
                return false;

            return _businessRepo.Update(business);
        }

        public bool DeleteBusiness(int id)
        {
            if (CurrentUser == null) return false;

            if (!IsAdmin)
                return false;

            return _businessRepo.Delete(id);
        }
    }
}
