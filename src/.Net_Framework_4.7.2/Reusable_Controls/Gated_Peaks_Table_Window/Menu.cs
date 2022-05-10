using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace Gated_Peaks_Table
{
    public partial class Gated_Peaks_Table_Window : MetroWindow
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
