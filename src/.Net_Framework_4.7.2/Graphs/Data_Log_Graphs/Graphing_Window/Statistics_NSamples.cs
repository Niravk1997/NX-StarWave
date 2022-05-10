using MahApps.Metro.Controls;
using MathNet.Numerics.Statistics;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Channel_DataLogger
{
    public partial class CH_DataLog_Graph_Window : MetroWindow
    {
        //--------------------------- Statistics (N Samples)----------------------

        private (bool, int, int) StatisticsNsamples_Range()
        {
            (bool isValid_Start, double Start_Value) = Functions.Text_Num(Start_Statistics_NSamples_TextBox.Text, false, true);
            (bool isValid_End, double End_Value) = Functions.Text_Num(End_Statistics_NSamples_TextBox.Text, false, true);
            if (isValid_Start == true & isValid_End == true)
            {
                if (Start_Value < End_Value)
                {
                    if (End_Value < Measurement_Count)
                    {
                        return (true, (int)Start_Value, (int)End_Value);
                    }
                    else
                    {
                        Insert_Log("Statistics N Samples End Value must be less than or equal to Total N Samples Captured.", 1);
                        return (false, 0, 0);
                    }
                }
                else
                {
                    Insert_Log("Statistics N Samples Start Value must be less than End Value.", 1);
                    return (false, 0, 0);
                }
            }
            else
            {
                if (isValid_Start == false)
                {
                    Insert_Log("Statistics N Samples Start Value is invalid. Value must be an positive integer.", 1);
                    Start_Statistics_NSamples_TextBox.Text = String.Empty;
                }
                if (isValid_End == false)
                {
                    Insert_Log("Statistics N Samples End Value is invalid. Value must be an positive integer.", 1);
                    End_Statistics_NSamples_TextBox.Text = String.Empty;
                }
                return (false, 0, 0);
            }
        }

        private void Mean_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double Mean = ArrayStatistics.Mean(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Mean (Average): " + Mean + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Mean (Average) for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Mean (Average) for N Samples. Try again.", 1);
            }
        }

        private void StdDeviation_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double StdDeviation = ArrayStatistics.StandardDeviation(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Standard Deviation: " + StdDeviation + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Standard Deviation for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Standard Deviation for N Samples. Try again.", 1);
            }
        }

        private void Max_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double Max = ArrayStatistics.Maximum(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Found Maximum Sample: " + Max + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not find Maximum Sample for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not find Maximum for N Samples. Try again.", 1);
            }
        }

        private void Min_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double Min = ArrayStatistics.Minimum(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Found Minimum Sample: " + Min + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not find Minimum Sample for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not find Minimum for N Samples. Try again.", 1);
            }
        }

        private void AbsMax_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double AbsMax = ArrayStatistics.MaximumAbsolute(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Absolute Maximum: " + AbsMax + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Absolute Maximum for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Absolute Maximum for N Samples. Try again.", 1);
            }
        }

        private void AbsMin_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double AbsMin = ArrayStatistics.MinimumAbsolute(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Absolute Minimum: " + AbsMin + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Absolute Minimum for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Absolute Minimum for N Samples. Try again.", 1);
            }
        }

        private void RMS_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double RMS = ArrayStatistics.RootMeanSquare(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Root Mean Square: " + RMS + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Root Mean Square for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Root Mean Square (RMS) for N Samples. Try again.", 1);
            }
        }

        private void Variance_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double Variance = ArrayStatistics.Variance(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Variance: " + Variance + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Variance for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Variance for N Samples. Try again.", 1);
            }
        }

        private void GeometricMean_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double GeometricMean = ArrayStatistics.GeometricMean(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Geometric Mean: " + GeometricMean + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Geometric Mean for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Geometric Mean for N Samples. Try again.", 1);
            }
        }

        private void HarmonicMean_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double HarmonicMean = ArrayStatistics.HarmonicMean(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Harmonic Mean: " + HarmonicMean + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Harmonic Mean for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Harmonic Mean for N Samples. Try again.", 1);
            }
        }

        private void PopulationVariance_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double PopulationVariance = ArrayStatistics.PopulationVariance(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Population Variance: " + PopulationVariance + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Population Variance for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Population Variance for N Samples. Try again.", 1);
            }
        }

        private void PopulationStdDeviation_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        double PopulationStandardDeviation = ArrayStatistics.PopulationStandardDeviation(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Calculated Population Standard Deviation: " + PopulationStandardDeviation + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Population Standard Deviation for All Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Population Standard Deviation for N Samples. Try again.", 1);
            }
        }

        private void MeanStdDeviation_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        (double ArithmeticSampleMean, double UnbiasedPopulationStandardDeviation) = ArrayStatistics.MeanStandardDeviation(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Arithmetic Sample Mean: " + ArithmeticSampleMean + " " + Measurement_Unit + "  Unbiased Pop Std Deviation: " + UnbiasedPopulationStandardDeviation + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Mean Standard Deviation for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Mean Standard Deviation for N Samples. Try again.", 1);
            }
        }

        private void MeanVariance_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = StatisticsNsamples_Range();
            if (IsValidRange == true)
            {
                Task.Run(() =>
                {
                    try
                    {
                        double[] Measurement_Data_Copy = new double[(EndValue - StartValue) + 1];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, (EndValue - StartValue) + 1);
                        (double ArithmeticSampleMean, double UnbiasedPopulationVariance) = ArrayStatistics.MeanVariance(Measurement_Data_Copy);
                        Insert_Log("[N Samples (" + StartValue + ", " + EndValue + ")]" + "  Arithmetic Sample Mean: " + ArithmeticSampleMean + " " + Measurement_Unit + "  Unbiased Pop Variance: " + UnbiasedPopulationVariance + " " + Measurement_Unit, 3);
                        Measurement_Data_Copy = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Could not calculate Mean Variance for N Samples. Try again.", 1);
                    }
                });
            }
            else
            {
                Insert_Log("Could not calculate Mean Variance for N Samples. Try again.", 1);
            }
        }

        //--------------------------- Statistics (N Samples)----------------------
    }
}
