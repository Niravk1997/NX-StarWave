using Interpolations;
using MahApps.Metro.Controls;
using System.Windows;

namespace FFT
{
    public partial class FFT_Plotter : MetroWindow
    {
        private Waveform_Interpolations Interpolation;

        private bool Interpolation_isDisabled = false;

        private bool Interpolation_isEnabled = false;

        private void Setup_Interpolation()
        {
            Interpolation = new Waveform_Interpolations(1);
        }

        private void Apply_Selected_Interploation_Data()
        {
            if (Calculate_Phase)
            {
                double[] X_Local;
                (X_Local, Phase) = Interpolation.Interpolation_Results(Frequency, Phase, Interpolation_Resample_Factor, Frequency[0], Frequency[((int)Data_Points / 2) - 1], (int)Data_Points / 2);
            }
            (Frequency, Magnitude) = Interpolation.Interpolation_Results(Frequency, Magnitude, Interpolation_Resample_Factor, Frequency[0], Frequency[((int)Data_Points / 2) - 1], (int)Data_Points / 2);
            FFT_Size = (Data_Points / 2) * Interpolation_Resample_Factor;
        }

        private void Set_LinearSplineInterpolation_Click(object sender, RoutedEventArgs e)
        {
            Interpolation.Interpolation_Type = 0;
            Interpolation_Select(0);
        }

        private void Set_CubicSplineInterpolation_Click(object sender, RoutedEventArgs e)
        {
            Interpolation.Interpolation_Type = 1;
            Interpolation_Select(1);
        }

        private void Set_SincInterpolation_Click(object sender, RoutedEventArgs e)
        {
            Interpolation.Interpolation_Type = 2;
            Interpolation_Select(2);
        }

        private void Interpolation_Select(int Selected)
        {
            if (Selected == 0)
            {
                LinearSpline_Selected.IsChecked = true;
            }
            else
            {
                LinearSpline_Selected.IsChecked = false;
            }
            if (Selected == 1)
            {
                CubicSpline_Selected.IsChecked = true;
            }
            else
            {
                CubicSpline_Selected.IsChecked = false;
            }
            if (Selected == 2)
            {
                Sinc_Selected.IsChecked = true;
            }
            else
            {
                Sinc_Selected.IsChecked = false;
            }
        }
    }
}
