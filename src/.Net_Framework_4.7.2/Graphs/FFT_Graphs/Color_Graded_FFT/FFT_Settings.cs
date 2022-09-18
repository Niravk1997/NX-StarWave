using MahApps.Metro.Controls;
using System.Windows;

namespace Color_Graded_FFT
{
    public partial class Color_Graded_FFT_Plotter : MetroWindow
    {
        //FFT Window Type Selected
        private int FFT_Window_Type;

        //FFT Window Gain Correction
        private double FFT_Window_Gain_Correction = 1;

        //Selects if dBVrms is selected or not;
        private bool Magnitude_dBVrms = true;

        private void Y_AXIS_dbV_Click(object sender, RoutedEventArgs e)
        {
            Magnitude_dBVrms = true;
            Y_AXIS_dbV.IsChecked = true;
            Y_AXIS_V.IsChecked = false;
            Y_AXIS_Units = "dB";
            Y_Axis_Normalized_Scale.Axis_Units = "dB";
            Graph.Plot.YAxis.Label("Magnitude (dB" + Y_AXIS_Units_Custom + "rms)");
            Reinitialize_FFT_Hitmap = true;
        }

        private void Y_AXIS_V_Click(object sender, RoutedEventArgs e)
        {
            Magnitude_dBVrms = false;
            Y_AXIS_dbV.IsChecked = false;
            Y_AXIS_V.IsChecked = true;
            Y_AXIS_Units = Y_AXIS_Units_Custom;
            Y_Axis_Normalized_Scale.Axis_Units = Y_AXIS_Units_Custom;
            Graph.Plot.YAxis.Label("Magnitude (Linear " + Y_AXIS_Units_Custom + "rms)");
            Reinitialize_FFT_Hitmap = true;
        }

        private (bool, double[]) FFT_Window_Array_Generate()
        {
            switch (FFT_Window_Type)
            {
                case 0:
                    return (false, new double[0]);
                case 1:
                    return (true, MathNet.Numerics.Window.Hamming((int)Data_Points));
                case 2:
                    return (true, MathNet.Numerics.Window.HammingPeriodic((int)Data_Points));
                case 3:
                    return (true, MathNet.Numerics.Window.Hann((int)Data_Points));
                case 4:
                    return (true, MathNet.Numerics.Window.HannPeriodic((int)Data_Points));
                case 5:
                    return (true, MathNet.Numerics.Window.BlackmanHarris((int)Data_Points));
                case 6:
                    return (true, MathNet.Numerics.Window.BlackmanNuttall((int)Data_Points));
                case 7:
                    return (true, MathNet.Numerics.Window.Lanczos((int)Data_Points));
                case 8:
                    return (true, MathNet.Numerics.Window.LanczosPeriodic((int)Data_Points));
                case 9:
                    return (true, MathNet.Numerics.Window.Cosine((int)Data_Points));
                case 10:
                    return (true, MathNet.Numerics.Window.CosinePeriodic((int)Data_Points));
                case 11:
                    return (true, MathNet.Numerics.Window.Triangular((int)Data_Points));
                default:
                    return (false, new double[0]);
            }
        }

        private void Rectangular_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 0;
            FFT_Window_Type_Selected(0);
            Window_Type_Label.Content = "Rectangular";
        }

        private void Hamming_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 1;
            FFT_Window_Type_Selected(1);
            Window_Type_Label.Content = "Hamming";
        }

        private void Hamming_Periodic_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 2;
            FFT_Window_Type_Selected(2);
            Window_Type_Label.Content = "Hamming Periodic";
        }

        private void Hanning_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 3;
            FFT_Window_Type_Selected(3);
            Window_Type_Label.Content = "Hanning";
        }

        private void Hanning_Periodic_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 4;
            FFT_Window_Type_Selected(4);
            Window_Type_Label.Content = "Hanning Periodic";
        }

        private void Blackman_Harris_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 5;
            FFT_Window_Type_Selected(5);
            Window_Type_Label.Content = "Blackman Harris";
        }

        private void Blackman_Nuttall_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 6;
            FFT_Window_Type_Selected(6);
            Window_Type_Label.Content = "Blackman Nuttall";
        }

        private void Lanczos_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 7;
            FFT_Window_Type_Selected(7);
            Window_Type_Label.Content = "Lanczos";
        }

        private void Lanczos_Periodic_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 8;
            FFT_Window_Type_Selected(8);
            Window_Type_Label.Content = "Lanczos Periodic";
        }

        private void Cosine_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 9;
            FFT_Window_Type_Selected(9);
            Window_Type_Label.Content = "Cosine";
        }

        private void Cosine_Periodic_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 10;
            FFT_Window_Type_Selected(10);
            Window_Type_Label.Content = "Cosine Periodic";
        }

        private void Triangular_FFT_Window_Type_Click(object sender, RoutedEventArgs e)
        {
            FFT_Window_Type = 11;
            FFT_Window_Type_Selected(11);
            Window_Type_Label.Content = "Triangular";
        }

        private void FFT_Window_Type_Selected(int Selected)
        {
            if (Selected == 0)
            {
                Rectangular_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Rectangular_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 1)
            {
                Hamming_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Hamming_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 2)
            {
                Hamming_Periodic_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Hamming_Periodic_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 3)
            {
                Hanning_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Hanning_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 4)
            {
                Hanning_Periodic_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Hanning_Periodic_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 5)
            {
                Blackman_Harris_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Blackman_Harris_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 6)
            {
                Blackman_Nuttall_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Blackman_Nuttall_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 7)
            {
                Lanczos_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Lanczos_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 8)
            {
                Lanczos_Periodic_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Lanczos_Periodic_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 9)
            {
                Cosine_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Cosine_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 10)
            {
                Cosine_Periodic_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Cosine_Periodic_FFT_Window_Type.IsChecked = false;
            }
            if (Selected == 11)
            {
                Triangular_FFT_Window_Type.IsChecked = true;
            }
            else
            {
                Triangular_FFT_Window_Type.IsChecked = false;
            }
            Reinitialize_FFT_Hitmap = true;
        }

        private void Reinitialize_FFT_Hitmap_Click(object sender, RoutedEventArgs e)
        {
            Reinitialize_FFT_Hitmap = true;
        }
    }
}
