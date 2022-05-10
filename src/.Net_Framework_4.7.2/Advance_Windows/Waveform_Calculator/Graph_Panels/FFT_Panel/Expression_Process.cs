using Interpolations;
using NX_StarWave.Waveform_Model_Classes;
using org.mariuszgromada.math.mxparser;
using System.Windows.Controls;
using Waveform_Calculator;

namespace FFT_Panel
{
    public partial class FFT_Panel : UserControl
    {
        private bool CH1_Data_Required;
        private bool CH2_Data_Required;
        private bool CH3_Data_Required;
        private bool CH4_Data_Required;
        private int Data_Required_Counter = 0;

        //Plot X,Y data arrays
        private double[] Y_Data;
        private double[] X_Data;
        private double[] Magnitude = { 0 };
        private double[] Frequency = { 0 };
        private double[] Phase = { 0 };

        //Math expression object
        private Expression_Data expression;

        //FFT Info
        private string FFT_Color;
        private bool FFT_Units_dB;
        private int FFT_Window;
        private bool Show_Phase;
        private bool Phase_Units_Degree;
        private double Phase_Ignore_Value;
        private bool Show_Peaks;
        private double Peaks_Ignore_value;
        private int Peaks_Window_Size;

        //Interpolation Config
        Waveform_Interpolations FFT_Interpolation;
        private bool Apply_Interpolation;
        private int Interpolation_Type;
        private int Interpolation_Factor;

        private string FFT_Title;
        private string Y_Axis_Title;
        private string Y_Axis_units;

        private double Total_Time;
        private double Start_Time;
        private double Stop_Time;
        private int Data_Points;
        private string Channel_Info;

        private double Max_Value_Allowed = 1E+9;
        private double Min_Value_Allowed = -1E+9;

        private Argument[] Math_Argument = new Argument[4];
        private Expression Math_Expression;

        private void Process_Expression_Config(Expression_Data expression)
        {
            this.expression = expression;
            string[] FFT_Config = expression.Expression_FFT_Config.Split(',');
            FFT_Color = FFT_Config[1];
            if (FFT_Config[2] == "True")
            {
                FFT_Units_dB = false;
            }
            else
            {
                FFT_Units_dB = true;
            }
            FFT_Window = int.Parse(FFT_Config[3]);
            if (FFT_Config[4] == "True")
            {
                Show_Phase = true;
            }
            else
            {
                Show_Phase = false;
            }
            if (FFT_Config[5] == "True")
            {
                Phase_Units_Degree = false;
            }
            else
            {
                Phase_Units_Degree = true;
            }
            Phase_Ignore_Value = double.Parse(FFT_Config[6]);
            if (FFT_Config[7] == "True")
            {
                Show_Peaks = true;
            }
            else
            {
                Show_Peaks = false;
            }
            Peaks_Ignore_value = double.Parse(FFT_Config[8]);
            Peaks_Window_Size = int.Parse(FFT_Config[9]);

            Interpolation_Type = int.Parse(FFT_Config[11]);
            Interpolation_Factor = int.Parse(FFT_Config[12]);

            if (FFT_Config[10] == "True")
            {
                Apply_Interpolation = true;
                FFT_Interpolation = new Waveform_Interpolations(Interpolation_Type);
            }
            else
            {
                Apply_Interpolation = false;
            }

            string[] Waveform_Config = expression.Expression_Waveform_Config.Split(',');
            Y_Axis_Title = Waveform_Config[2];
            Y_Axis_units = Waveform_Config[3];
            FFT_Title = Waveform_Config[4];

            if (expression.Expression.Contains("x1")) { CH1_Data_Required = true; Data_Required_Counter++; } else { CH1_Data_Required = false; }
            if (expression.Expression.Contains("x2")) { CH2_Data_Required = true; Data_Required_Counter++; } else { CH2_Data_Required = false; }
            if (expression.Expression.Contains("x3")) { CH3_Data_Required = true; Data_Required_Counter++; } else { CH3_Data_Required = false; }
            if (expression.Expression.Contains("x4")) { CH4_Data_Required = true; Data_Required_Counter++; } else { CH4_Data_Required = false; }

            Math_Argument[0] = new Argument("x1", 0);
            Math_Argument[1] = new Argument("x2", 0);
            Math_Argument[2] = new Argument("x3", 0);
            Math_Argument[3] = new Argument("x4", 0);
            Math_Expression = new Expression(this.expression.Expression, Math_Argument);
        }

        public void Calculate_Math_Expression(Processed_Channels_Data Data)
        {
            int Data_Required_Counter = 0;
            if (CH1_Data_Required & Data.CH1_Valid) { Data_Required_Counter++; }
            if (CH2_Data_Required & Data.CH2_Valid) { Data_Required_Counter++; }
            if (CH3_Data_Required & Data.CH3_Valid) { Data_Required_Counter++; }
            if (CH4_Data_Required & Data.CH4_Valid) { Data_Required_Counter++; }

            if (this.Data_Required_Counter == Data_Required_Counter)
            {
                Total_Time = Data.Total_Time;
                Start_Time = Data.Start_Time;
                Stop_Time = Data.Stop_Time;
                Data_Points = Data.Data_Points;
                Channel_Info = Data.Channel_Info;

                double[] Calculate_Expression_Results = new double[Data.Data_Points];

                for (int i = 0; i < Data.Data_Points; i++)
                {
                    if (Data.CH1_Valid) { Math_Argument[0].setArgumentValue(Data.CH1_Data[i]); }
                    if (Data.CH2_Valid) { Math_Argument[1].setArgumentValue(Data.CH2_Data[i]); }
                    if (Data.CH3_Valid) { Math_Argument[2].setArgumentValue(Data.CH3_Data[i]); }
                    if (Data.CH4_Valid) { Math_Argument[3].setArgumentValue(Data.CH4_Data[i]); }
                    Calculate_Expression_Results[i] = Math_Expression.calculate();
                    if (double.IsNaN(Calculate_Expression_Results[i]) || double.IsInfinity(Calculate_Expression_Results[i]) || Calculate_Expression_Results[i] >= Max_Value_Allowed || Calculate_Expression_Results[i] <= Min_Value_Allowed)
                    {
                        isError = true;
                        if (double.IsNaN(Calculate_Expression_Results[i]))
                        {
                            Error_Count_NAN++;
                        }
                        if (double.IsInfinity(Calculate_Expression_Results[i]))
                        {
                            Error_Count_Infinity++;
                        }
                        if (Calculate_Expression_Results[i] >= Max_Value_Allowed)
                        {
                            Error_Count_Max++;
                        }
                        if (Calculate_Expression_Results[i] <= Min_Value_Allowed)
                        {
                            Error_Count_Min++;
                        }
                        Calculate_Expression_Results[i] = 0;
                    }
                }

                if (isError)
                {
                    Show_Hide_Error_Annotation();
                    isError = false;
                }
                else
                {
                    Hide_Error_Annotation();
                }

                Process_Array(Data.Time_Data, Calculate_Expression_Results);
            }
        }

        private void Process_Array(double[] Channel_Time_Data, double[] Calculate_Expression_Results)
        {
            Y_Data = Calculate_Expression_Results;
            X_Data = Channel_Time_Data;
            Calculate_FFT();
            if (Show_Peaks)
            {
                Peak_Finder();
                Update_Plottable_Peaks();
            }
            this.Dispatcher.Invoke(() =>
            {
                Plot_FFT_Data();
            }, System.Windows.Threading.DispatcherPriority.Normal);
        }
    }
}
