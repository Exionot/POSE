using cc105_pose_proj.Data;
using cc105_pose_proj.Models;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.Services
{
    public class BusinessService
    {
        private readonly IRepository<Business> _businessRepo;

        public BusinessService(IRepository<Business> businessRepo)
        {
            _businessRepo = businessRepo;
        }

        public List<Business> GetBusinesses()
        {
            var allBusiness = _businessRepo.GetAll();
            var userBusiness = Session.CurrentUser?.Business;

            if (userBusiness == null)
                return allBusiness;

            return [userBusiness];
        }

        public Business? GetBusinessById(int id)
        {
            var userBusiness = Session.CurrentUser?.Business;

            if (userBusiness != null && userBusiness.Id != id)
                return null;

            return _businessRepo.GetById(id);
        }

        public bool CreateBusiness(Business business)
        {
            var currentUser = Session.CurrentUser;
            if (currentUser == null) return false;

            if (!currentUser.IsAdmin && currentUser.Business != null)
                return false;

            return _businessRepo.Add(business);
        }

        public bool UpdateBusiness(Business business)
        {
            var currentUser = Session.CurrentUser;
            if (currentUser == null) return false;

            if (!currentUser.IsAdmin && currentUser.Business?.Id != business.Id)
                return false;

            return _businessRepo.Update(business);
        }

        public bool DeleteBusiness(int id)
        {
            var currentUser = Session.CurrentUser;
            if (currentUser == null) return false;

            if (!currentUser.IsAdmin)
                return false;

            return _businessRepo.Delete(id);
        }
    }
}
