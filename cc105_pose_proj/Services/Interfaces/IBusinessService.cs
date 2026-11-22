using cc105_pose_proj.Models;

namespace cc105_pose_proj.Services.Interfaces
{
    public interface IBusinessService
    {
        bool CreateBusiness(Business business);
        bool DeleteBusiness(int id);
        Business? GetBusinessById(int id);
        List<Business> GetBusinesses();
        bool UpdateBusiness(Business business);
    }
}