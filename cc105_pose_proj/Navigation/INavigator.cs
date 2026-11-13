using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc105_pose_proj.Navigation
{
    public interface INavigator
    {
        void NavigateTo(UserControl view);
    }
}
