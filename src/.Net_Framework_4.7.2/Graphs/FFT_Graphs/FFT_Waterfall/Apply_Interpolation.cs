using Interpolations;
using MahApps.Metro.Controls;
using System.Windows;

namespace FFT_Waterfall
{
    public partial class FFT_Waterfall_Plotter : MetroWindow
    {
        private Waveform_Interpolations Interpolation;

        private int Interpolation_Resample_Factor_PastValue = 0;

        private void Setup_Interpolation()
        {
            Interpolation = new Waveform_Interpolations(1);
        }

        private void Apply_Selected_Interploation_Data()
        {
            int Interpolation_Resample_Factor_Local = Interpolation_Resample_Factor;
            if (Interpolation_Resample_Factor_PastValue != Interpolation_Resample_Factor_Local)
            {
                Interpolation_Resample_Factor_PastValue = Interpolation_Resample_Factor_Local;
                Initialize_Arrays(((int)Data_Points / 2) * Interpolation_Resample_Factor_Local);
                FFT_Size_Changed = true;
            }
            if (Calculate_Phase)
            {
                double[] X_Local;
                (X_Local, Phase) = Interpolation.Interpolation_Results(Frequency, Phase, Interpolation_Resample_Factor, Frequency[0], Frequency[((int)Data_Points / 2) - 1], (int)Data_Points / 2);
            }
            (Frequency, Magnitude) = Interpolation.Interpolation_Results(Frequency, Magnitude, Interpolation_Resample_Factor_Local, Frequency[0], Frequency[((int)Data_Points / 2) - 1], (int)Data_Points / 2);
            Data_Points = Data_Points * Interpolation_Resample_Factor;
        }

        private void Enable_Interpolation_Click(object sender, RoutedEventArgs e)
        {
            if (Apply_Interpolation == false)
            {
                //This will trigger the Waveform Data Process to ReInitialize the spectrogram.
                FFT_Size = 0;
                Interpolation_Resample_Factor_PastValue = 0;
            }
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
