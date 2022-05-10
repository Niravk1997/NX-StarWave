using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private void Create_Theme_Change_EventHandler()
        {
            ThemeManager.Current.ThemeChanged += Current_ThemeChanged;

            try
            {
                if (ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Light"))
                {
                    Reference_Calculator_DockManager.Theme = new AvalonDock.Themes.Vs2013LightTheme();
                }
                else
                {
                    Reference_Calculator_DockManager.Theme = new AvalonDock.Themes.Vs2013DarkTheme();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Current_ThemeChanged(object sender, ThemeChangedEventArgs e)
        {
            try
            {
                if (ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Light"))
                {
                    Reference_Calculator_DockManager.Theme = new AvalonDock.Themes.Vs2013LightTheme();
                }
                else
                {
                    Reference_Calculator_DockManager.Theme = new AvalonDock.Themes.Vs2013DarkTheme();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Remove_Create_Theme_Change_EventHandler()
        {
            try
            {
                ThemeManager.Current.ThemeChanged -= Current_ThemeChanged;
            }
            catch (Exception)
            {

            }
        }
    }
}
