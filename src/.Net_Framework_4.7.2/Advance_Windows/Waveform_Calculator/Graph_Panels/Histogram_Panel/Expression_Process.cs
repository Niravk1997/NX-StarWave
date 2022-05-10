using NX_StarWave.Waveform_Model_Classes;
using org.mariuszgromada.math.mxparser;
using System;
using System.Windows.Controls;
using Waveform_Calculator;

namespace Histogram_Panel
{
    public partial class Histogram_Panel : UserControl
    {
        private bool CH1_Data_Required;
        private bool CH2_Data_Required;
        private bool CH3_Data_Required;
        private bool CH4_Data_Required;
        private int Data_Required_Counter = 0;

        //Plot Y data arrays
        private double[] Y_Data;
        private double[] X_Data;

        //Continuous variables
        private int Continuous_Counter = 0;
        private int Max_Allowed_Samples = 1_000_000;


        //Math expression object
        private Expression_Data expression;

        //Determines if waveform data will be plotted continuously or not
        private bool isContinuous = false;

        //Histogram Variables
        private int Total_Buckets;
        private bool Continuous_Histogram_Initialized = false;
        private double[] values = { 0 };
        private double[] positions = { 0 };

        //Waveform Panel Axis Info
        private string Histogram_Color;
        private string Histogram_Title;
        private string X_Axis_units;
        private string X_Axis_Title;

        //Wavefrom Info, Current Waveform Only
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
            X_Axis_Title = Expression_Wavefrom_Config[2];
            X_Axis_units = Expression_Wavefrom_Config[3];
            Histogram_Title = Expression_Wavefrom_Config[4];
            Axis_Scale_Config.X_Axis_Units = X_Axis_units;
            Axis_Scale_Config.Y_Axis_Units = "";
            string[] Histogram_Config = expression.Expression_Histogram_Config.Split(',');
            Histogram_Color = Histogram_Config[1];
            Total_Buckets = int.Parse(Histogram_Config[2]);
            if (Histogram_Config[3] == "True")
            {
                isContinuous = true;
            }
            else
            {
                isContinuous = false;
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
                Y_Data = Calculate_Expression_Results;
                X_Data = Channel_Time_Data;
                Histogram_Data = new MathNet.Numerics.Statistics.Histogram(Y_Data, Total_Buckets);
                Histogram_Create();
            }
            else
            {
                if ((Continuous_Counter >= Max_Allowed_Samples) || (Max_Allowed_Samples - Continuous_Counter < Calculate_Expression_Results.Length))
                {
                    Max_Allowed_Samples = Max_Allowed_Samples + 1_000_000;
                    Array.Resize(ref Y_Data, Max_Allowed_Samples);
                }
                for (int i = 0; i < Calculate_Expression_Results.Length; i++)
                {
                    Y_Data[Continuous_Counter] = Calculate_Expression_Results[i];
                    Continuous_Counter++;
                }
                double[] Values = new double[Continuous_Counter];
                for (int i = 0; i < Continuous_Counter; i++)
                {
                    Values[i] = Y_Data[i];
                }
                if (Continuous_Histogram_Initialized)
                {
                    Histogram_Data.AddData(Values);
                    Histogram_Create();
                }
                else
                {
                    Histogram_Data = new MathNet.Numerics.Statistics.Histogram(Values, Total_Buckets);
                    Continuous_Histogram_Initialized = true;
                    Histogram_Create();
                }
            }
        }

        private void Histogram_Create()
        {
            values = new double[Histogram_Data.BucketCount];
            positions = new double[Histogram_Data.BucketCount];
            for (int i = 0; i < Histogram_Data.BucketCount; i++)
            {
                values[i] = Histogram_Data[i].Count;
                positions[i] = Histogram_Data[i].LowerBound;
                if (double.IsNaN(values[i]) || double.IsInfinity(values[i]))
                {
                    values[i] = 0;
                }
                if (double.IsNaN(positions[i]) || double.IsInfinity(positions[i]))
                {
                    positions[i] = 0;
                }
            }
        }
    }
}
