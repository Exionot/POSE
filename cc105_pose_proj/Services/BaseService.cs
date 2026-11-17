using cc105_pose_proj.Models;
using cc105_pose_proj.Util;

namespace cc105_pose_proj.Services
{
    public abstract class BaseService
    {
        protected User? CurrentUser => Session.CurrentUser;
        protected Business? CurrentBusiness => Session.CurrentUser?.Business;
        protected int? CurrentBusinessId => Session.CurrentUser?.Business?.Id;
        protected bool IsAdmin => CurrentUser?.IsAdmin ?? false;
    }
}
