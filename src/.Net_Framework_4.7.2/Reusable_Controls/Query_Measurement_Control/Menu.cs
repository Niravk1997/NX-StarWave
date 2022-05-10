using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace Query_Measurement_Control
{
    public partial class Query_Measurement_Window : MetroWindow
    {
        private void MenuItem_ToggleAlwaysOnTop_Click(object sender, RoutedEventArgs e)
        {
            Topmost = ((MenuItem)sender).IsChecked;
        }

        private void MenuItem_ExitApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
