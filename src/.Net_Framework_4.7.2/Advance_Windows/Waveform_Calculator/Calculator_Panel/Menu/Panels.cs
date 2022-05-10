using MahApps.Metro.Controls;
using System.Windows;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private void Close_All_Graph_Panels_Click(object sender, RoutedEventArgs e)
        {
            Close_All_Waveform_Panels();
            Close_All_Histogram_Panels();
            Close_All_FFT_Panels();
        }

        private void Close_All_Waveform_Panels_Click(object sender, RoutedEventArgs e)
        {
            Close_All_Waveform_Panels();
        }

        private void Close_All_Histogram_Panels_Click(object sender, RoutedEventArgs e)
        {
            Close_All_Histogram_Panels();
        }

        private void Close_All_FFT_Panels_Click(object sender, RoutedEventArgs e)
        {
            Close_All_FFT_Panels();
        }
    }
}
