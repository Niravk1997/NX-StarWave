using Interpolations;
using MahApps.Metro.Controls;
using System.Windows;

namespace Color_Graded_FFT
{
    public partial class Color_Graded_FFT_Plotter : MetroWindow
    {
        private Waveform_Interpolations Interpolation;

        private void Setup_Interpolation()
        {
            Interpolation = new Waveform_Interpolations(1);
        }

        private void Apply_Selected_Interploation_Data()
        {
            (Frequency, Magnitude) = Interpolation.Interpolation_Results(Frequency, Magnitude, Interpolation_Resample_Factor, Frequency[0], Frequency[((int)Data_Points / 2) - 1], (int)Data_Points / 2);
            FFT_Size = (Data_Points * Interpolation_Resample_Factor) / 2;
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
