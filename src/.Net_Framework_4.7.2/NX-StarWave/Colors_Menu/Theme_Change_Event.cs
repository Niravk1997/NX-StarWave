using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private void Create_Theme_Change_EventHandler()
        {
            ThemeManager.Current.ThemeChanged += Current_ThemeChanged;
        }

        private void Current_ThemeChanged(object sender, ThemeChangedEventArgs e)
        {
            try
            {
                if (ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Light"))
                {
                    NX_StarWave_dockManager.Theme = new AvalonDock.Themes.Vs2013LightTheme();
                }
                else
                {
                    NX_StarWave_dockManager.Theme = new AvalonDock.Themes.Vs2013DarkTheme();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
