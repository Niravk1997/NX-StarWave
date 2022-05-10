using MahApps.Metro.Controls;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        private void Set_Initial_NodeEditor_Theme()
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                NodeEditor_Background_String = "#FF000000";
                NodeEditor_Grid_String = "#FF383838";
            }
        }
    }
}
