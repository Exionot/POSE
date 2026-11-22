using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc105_pose_proj.Navigation
{
    public interface INavigator
    {
        void NavigateTo<T>() where T : UserControl;
        void NavigateTo<T>(Action<T> action) where T : UserControl;
        void NavigateTo(UserControl view);
    }
}
