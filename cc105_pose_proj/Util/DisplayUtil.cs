namespace cc105_pose_proj.Util
{
    public class DisplayUtil
    {
        public static void changeScreen(Form form, Screen screen)
        {
            if (screen == null) return;
            bool wasMaximized = (form.WindowState == FormWindowState.Maximized);
            if (wasMaximized) form.WindowState = FormWindowState.Normal;

            form.Location = screen.WorkingArea.Location;

            if (wasMaximized) form.WindowState = FormWindowState.Maximized;
        }

        public static bool hasMultipleDisplay()
        {
            return Screen.AllScreens.Length > 1;
        }
    }
}
