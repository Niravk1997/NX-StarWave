using Interpolations;
using MahApps.Metro.Controls;
using System.Windows;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
    {
        private Waveform_Interpolations Interpolation;

        private void Setup_Interpolation()
        {
            Interpolation = new Waveform_Interpolations(1);
        }

        private void Apply_Selected_Interploation_Data()
        {
            int Interpolation_Resample_Factor_Local = Interpolation_Resample_Factor;
            (X_Waveform_Values, Y_Waveform_Values) = Interpolation.Interpolation_Results(X_Waveform_Values, Y_Waveform_Values, Interpolation_Resample_Factor_Local, Start_Time, Stop_Time, (int)Data_Points);
            Data_Points = (int)(Interpolation_Resample_Factor_Local * Data_Points);
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
