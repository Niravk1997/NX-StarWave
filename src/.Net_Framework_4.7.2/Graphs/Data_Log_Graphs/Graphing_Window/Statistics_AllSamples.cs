using MahApps.Metro.Controls;
using MathNet.Numerics.Statistics;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Channel_DataLogger
{
    public partial class CH_DataLog_Graph_Window : MetroWindow
    {
        //--------------------------- Statistics (All Samples)----------------------

        private void Mean_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double Mean = ArrayStatistics.Mean(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Mean (Average): " + Mean + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Mean (Average) for All Samples. Try again.", 1);
                }
            });
        }

        private void StdDeviation_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double StdDeviation = ArrayStatistics.StandardDeviation(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Standard Deviation: " + StdDeviation + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Standard Deviation for All Samples. Try again.", 1);
                }
            });
        }

        private void Max_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double Max = ArrayStatistics.Maximum(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Found Maximum Sample: " + Max + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not find Maximum Sample for All Samples. Try again.", 1);
                }
            });
        }

        private void Min_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double Min = ArrayStatistics.Minimum(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Found Minimum Sample: " + Min + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not find Minimum Sample for All Samples. Try again.", 1);
                }
            });
        }

        private void AbsMax_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double AbsMax = ArrayStatistics.MaximumAbsolute(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Absolute Maximum: " + AbsMax + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Absolute Maximum for All Samples. Try again.", 1);
                }
            });
        }

        private void AbsMin_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double AbsMin = ArrayStatistics.MinimumAbsolute(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Absolute Minimum: " + AbsMin + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Absolute Minimum for All Samples. Try again.", 1);
                }
            });
        }

        private void RMS_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double RMS = ArrayStatistics.RootMeanSquare(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Root Mean Square: " + RMS + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Root Mean Square for All Samples. Try again.", 1);
                }
            });
        }

        private void Variance_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double Variance = ArrayStatistics.Variance(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Variance: " + Variance + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Variance for All Samples. Try again.", 1);
                }
            });
        }

        private void GeometricMean_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double GeometricMean = ArrayStatistics.GeometricMean(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Geometric Mean: " + GeometricMean + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Geometric Mean for All Samples. Try again.", 1);
                }
            });
        }

        private void HarmonicMean_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double HarmonicMean = ArrayStatistics.HarmonicMean(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Harmonic Mean: " + HarmonicMean + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Harmonic Mean for All Samples. Try again.", 1);
                }
            });
        }

        private void PopulationVariance_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double PopulationVariance = ArrayStatistics.PopulationVariance(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Population Variance: " + PopulationVariance + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Population Variance for All Samples. Try again.", 1);
                }
            });
        }

        private void PopulationStdDeviation_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double PopulationStandardDeviation = ArrayStatistics.PopulationStandardDeviation(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Calculated Population Standard Deviation: " + PopulationStandardDeviation + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Population Standard Deviation for All Samples. Try again.", 1);
                }
            });
        }

        private void MeanStdDeviation_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    (double ArithmeticSampleMean, double UnbiasedPopulationStandardDeviation) = ArrayStatistics.MeanStandardDeviation(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Arithmetic Sample Mean: " + ArithmeticSampleMean + " " + Measurement_Unit + "  Unbiased Pop Std Deviation: " + UnbiasedPopulationStandardDeviation + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Mean Standard Deviation for All Samples. Try again.", 1);
                }
            });
        }

        private void MeanVariance_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    (double ArithmeticSampleMean, double UnbiasedPopulationVariance) = ArrayStatistics.MeanVariance(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + 0 + ", " + (Measurement_Count_Copy - 1) + ")]" + "  Arithmetic Sample Mean: " + ArithmeticSampleMean + " " + Measurement_Unit + "  Unbiased Pop Variance: " + UnbiasedPopulationVariance + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Mean Variance for All Samples. Try again.", 1);
                }
            });
        }

        //--------------------------- Statistics (All Samples)----------------------
    }
}
