using NX_StarWave.Waveform_Model_Classes;
using org.mariuszgromada.math.mxparser;
using System;
using System.Windows.Controls;
using Waveform_Calculator;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private bool CH1_Data_Required;
        private bool CH2_Data_Required;
        private bool CH3_Data_Required;
        private bool CH4_Data_Required;
        private int Data_Required_Counter = 0;

        //Plot X,Y data arrays
        private double[] Y_Data;
        private double[] X_Data;

        //Continuous variables
        private int Continuous_Counter = 0;
        private int Max_Allowed_Samples = 1_000_000;


        //Math expression object
        private Expression_Data expression;

        //Determines if waveform data will be plotted continuously or not
        private bool isContinuous = false;

        //Waveform Panel Axis Info
        private string Waveform_Color;
        private string Y_Axis_Title;
        private string Y_Axis_Units;
        private string Waveform_Title;
        private string X_Axis_units = "s";

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
            string[] Expression_Wavefrom_Config = expression.Expression_Waveform_Config.Split(',');
            Waveform_Color = Expression_Wavefrom_Config[1];
            Y_Axis_Title = Expression_Wavefrom_Config[2];
            Y_Axis_Units = Expression_Wavefrom_Config[3];
            if (!string.IsNullOrWhiteSpace(Y_Axis_Units))
            {
                Axis_Scale_Config.Y_Axis_Units = Y_Axis_Units;
            }
            Waveform_Title = Expression_Wavefrom_Config[4];
            if (Expression_Wavefrom_Config[5] == "True")
            {
                isContinuous = true;
                Axis_Scale_Config.X_Axis_Units = "N";
                X_Axis_units = "N";
            }
            else
            {
                isContinuous = false;
                Axis_Scale_Config.X_Axis_Units = "s";
            }
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
                Calculate_Statistics();

                this.Dispatcher.Invoke(() =>
                {
                    Plot_Waveform_Data();
                }, System.Windows.Threading.DispatcherPriority.Normal);
            }
        }

        private void Process_Array(double[] Channel_Time_Data, double[] Calculate_Expression_Results)
        {
            if (isContinuous == false)
            {
                X_Data = Channel_Time_Data;
                Y_Data = Calculate_Expression_Results;
            }
            else
            {
                if ((Continuous_Counter >= Max_Allowed_Samples) || (Max_Allowed_Samples - Continuous_Counter < Calculate_Expression_Results.Length))
                {
                    Max_Allowed_Samples = Max_Allowed_Samples + 1_000_000;
                    Array.Resize(ref Y_Data, Max_Allowed_Samples);
                    Expression_Waveform_Continuous.Ys = Y_Data;
                }
                for (int i = 0; i < Calculate_Expression_Results.Length; i++)
                {
                    Y_Data[Continuous_Counter] = Calculate_Expression_Results[i];
                    Expression_Waveform_Continuous.MaxRenderIndex = Continuous_Counter;
                    Continuous_Counter++;
                }
            }
        }
    }
}
