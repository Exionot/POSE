namespace cc105_pose_proj.Navigation
{
    public enum NavigationTarget
    {
        Login,
        Home,
        MainTransaction,
        Inventory,
        DiscountView
    }
    public class NavigationEventArgs : EventArgs
    {
        public NavigationTarget Target { get; }

        public NavigationEventArgs(NavigationTarget target) 
        { 
            Target = target; 
        }
    }
}
