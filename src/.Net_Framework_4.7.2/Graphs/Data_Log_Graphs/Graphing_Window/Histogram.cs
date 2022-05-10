using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Channel_DataLogger
{
    public partial class CH_DataLog_Graph_Window : MetroWindow
    {
        //Creates Histogram Windows
        private void Create_Histogram_Window(string Window_Title, int Start_Sample, int End_Sample, string Graph_Title, string X_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count, int Buckets, double BarWidth, float BarBorder, bool Curve)
        {
            try
            {
                Thread Waveform_Thread = new Thread(new ThreadStart(() =>
                {
                    Histogram_Waveform Histogram_Waveform = new Histogram_Waveform(Graph_Owner, Window_Title, Start_Sample, End_Sample, Graph_Title, X_Axis_Label, Red, Green, Blue, Measurement_Data, Measurement_Count, Buckets, BarWidth, BarBorder, Curve);
                    Histogram_Waveform.Show();
                    Histogram_Waveform.Closed += (sender2, e2) => Histogram_Waveform.Dispatcher.InvokeShutdown();
                    Dispatcher.Run();

                }));
                Waveform_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.SetApartmentState(ApartmentState.STA);
                Waveform_Thread.IsBackground = true;
                Waveform_Thread.Start();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Insert_Log("Histogram Window creation failed.", 1);
            }
        }

        //--------------------------- Histogram (All Samples)----------------------
        private (bool, int, int) Histogram_Range()
        {
            (bool isValid_Start, double Start_Value) = Functions.Text_Num(Start_Histogram_NSamples_TextBox.Text, false, true);
            (bool isValid_End, double End_Value) = Functions.Text_Num(End_Histogram_NSamples_TextBox.Text, false, true);
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
                        Insert_Log("Histogram N Samples End Value must be less than or equal to Total N Samples Captured.", 1);
                        return (false, 0, 0);
                    }
                }
                else
                {
                    Insert_Log("Histogram N Samples Start Value must be less than End Value.", 1);
                    return (false, 0, 0);
                }
            }
            else
            {
                if (isValid_Start == false)
                {
                    Insert_Log("Histogram N Samples Start Value is invalid. Value must be an positive integer.", 1);
                    Start_Histogram_NSamples_TextBox.Text = String.Empty;
                }
                if (isValid_End == false)
                {
                    Insert_Log("Histogram N Samples End Value is invalid. Value must be an positive integer.", 1);
                    End_Histogram_NSamples_TextBox.Text = String.Empty;
                }
                return (false, 0, 0);
            }
        }

        private void Calculate_Histogram_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {

            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = Histogram_Color_Check();
            (bool isBuckets, double Buckets) = Functions.Text_Num(Buckets_TextBox_Histogram_NSamples.Text, false, true);
            (bool isBarWidth, double BarWidth) = Functions.Text_Num(BarWidth_TextBox_Histogram_NSamples.Text, false, false);
            (bool isBarThickness, double BarThickness) = Functions.Text_Num(BarBorder_TextBox_Histogram_NSamples.Text, false, false);
            if (isValidGraphColor == true & isBuckets == true & isBarWidth == true & isBarThickness)
            {
                if (Buckets > 0)
                {
                    bool Curve = false;
                    if (MeanCurve_CheckBox_Histogram_NSamples.IsChecked == true)
                    {
                        Curve = true;
                    }
                    else
                    {
                        Curve = false;
                    };
                    string Graph_Title = GraphTitle_TextBox_Histogram_NSamples.Text;
                    string X_Axis_Label = XAxisTitle_TextBox_Histogram_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            Create_Histogram_Window("Histogram Waveform [" + 0 + ", " + Measurement_Count_Copy + "]", 0, Measurement_Count_Copy, Graph_Title, X_Axis_Label, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, (int)Buckets, BarWidth, (float)BarThickness, Curve);
                            Measurement_Data_Copy = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Histogram Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    Insert_Log("Histogram [All Samples]: Buckets Value is invalid. Must be a positive integer number.", 1);
                }
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Histogram [All Samples]: Color is invalid. Set new Color.", 1);
                }
                if (isBuckets == false)
                {
                    Buckets_TextBox_Histogram_NSamples.Text = string.Empty;
                    Insert_Log("Histogram [All Samples]: Buckets Value is invalid. Must be a positive integer number.", 1);
                }
                if (isBarWidth == false)
                {
                    BarWidth_TextBox_Histogram_NSamples.Text = string.Empty;
                    Insert_Log("Histogram [All Samples]: Bar Width is invalid. Must be a positive number.", 1);
                }
                if (isBarThickness == false)
                {
                    BarBorder_TextBox_Histogram_NSamples.Text = string.Empty;
                    Insert_Log("Histogram [All Samples]: Bar Border thickness is invalid. Must be a positive number.", 1);
                }
            }
        }

        //--------------------------- Histogram (All Samples)----------------------

        //--------------------------- Histogram (N Samples)----------------------

        private void Calculate_Histogram_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = Histogram_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = Histogram_Color_Check();
            (bool isBuckets, double Buckets) = Functions.Text_Num(Buckets_TextBox_Histogram_NSamples.Text, false, true);
            (bool isBarWidth, double BarWidth) = Functions.Text_Num(BarWidth_TextBox_Histogram_NSamples.Text, false, false);
            (bool isBarThickness, double BarThickness) = Functions.Text_Num(BarBorder_TextBox_Histogram_NSamples.Text, false, false);
            if (IsValidRange == true & isValidGraphColor == true & isBuckets == true & isBarWidth == true & isBarThickness)
            {
                if (Buckets > 0)
                {
                    bool Curve = false;
                    if (MeanCurve_CheckBox_Histogram_NSamples.IsChecked == true)
                    {
                        Curve = true;
                    }
                    else
                    {
                        Curve = false;
                    };
                    string Graph_Title = GraphTitle_TextBox_Histogram_NSamples.Text;
                    string X_Axis_Label = XAxisTitle_TextBox_Histogram_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);

                            Create_Histogram_Window("Histogram Waveform [" + StartValue + ", " + EndValue + "]", StartValue, EndValue, Graph_Title, X_Axis_Label, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, (int)Buckets, BarWidth, (float)BarThickness, Curve);
                            Measurement_Data_Copy = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Histogram Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    Insert_Log("Histogram [N Samples]: Buckets Value is invalid. Must be a positive integer number.", 1);
                }
            }
            else
            {
                if (IsValidRange == false)
                {
                    Start_Histogram_NSamples_TextBox.Text = string.Empty;
                    End_Histogram_NSamples_TextBox.Text = string.Empty;
                    Insert_Log("Histogram [N Samples]: Start, End Range is invalid. Set new range and try again.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Histogram [N Samples]: Color is invalid. Set new Color.", 1);
                }
                if (isBuckets == false)
                {
                    Buckets_TextBox_Histogram_NSamples.Text = string.Empty;
                    Insert_Log("Histogram [N Samples]: Buckets Value is invalid. Must be a positive integer number.", 1);
                }
                if (isBarWidth == false)
                {
                    BarWidth_TextBox_Histogram_NSamples.Text = string.Empty;
                    Insert_Log("Histogram [N Samples]: Bar Width is invalid. Must be a positive number.", 1);
                }
                if (isBarThickness == false)
                {
                    BarBorder_TextBox_Histogram_NSamples.Text = string.Empty;
                    Insert_Log("Histogram [N Samples]: Bar Border thickness is invalid. Must be a positive number.", 1);
                }
            }
        }

        private void Set_Default_Histogram_Color(string Color)
        {
            GraphColor_Preview_Math_AllSamples.SelectedColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Color);
        }

        private (bool, int, int, int) Histogram_Color_Check()
        {
            try
            {
                System.Windows.Media.Color color = GraphColor_Histogram.SelectedColor;
                return (true, color.R, color.G, color.B);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                return (false, 0, 0, 0);
            }
        }

        private void Histogram_Color_RandomizeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random RGB_Value = new Random();
                int Value_Red = RGB_Value.Next(0, 255);
                int Value_Green = RGB_Value.Next(0, 255);
                int Value_Blue = RGB_Value.Next(0, 255);
                GraphColor_Histogram.SelectedColor = System.Windows.Media.Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue));
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        //--------------------------- Histogram (N Samples)----------------------
    }
}
