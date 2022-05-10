using MahApps.Metro.Controls;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : MetroWindow
    {
        //Measurement Values are stored here
        private List<double> Frequency_Values = new List<double>();
        private List<double> Frequency_DateTime_Values = new List<double>();

        private List<double> Period_Values = new List<double>();
        private List<double> Period_DateTime_Values = new List<double>();

        private List<double> PeakPeak_Values = new List<double>();
        private List<double> PeakPeak_DateTime_Values = new List<double>();

        private List<double> Mean_Values = new List<double>();
        private List<double> Mean_DateTime_Values = new List<double>();

        private List<double> RMS_Values = new List<double>();
        private List<double> RMS_DateTime_Values = new List<double>();

        private List<double> Min_Values = new List<double>();
        private List<double> Min_DateTime_Values = new List<double>();

        private List<double> Max_Values = new List<double>();
        private List<double> Max_DateTime_Values = new List<double>();

        private List<double> Stdev_Values = new List<double>();
        private List<double> Stdev_DateTime_Values = new List<double>();

        public string YAxis_Units = "V";

        private readonly int Frequency_Value_Round = 4;
        private readonly int Period_Value_Round = 4;
        private readonly int PeakPeak_Value_Round = 4;
        private readonly int Mean_Value_Round = 4;
        private readonly int RMS_Value_Round = 4;
        private readonly int Min_Value_Round = 4;
        private readonly int Max_Value_Round = 4;
        private readonly int Stdev_Value_Round = 4;

        internal void Statistics_Table_Process_Data(double[] X_Waveform_Values, double[] Y_Waveform_Values, int Data_Points)
        {
            double Date_Time = DateTime.Now.ToOADate();

            double Mean_Value = Waveform_Measurements.Mean(Y_Waveform_Values);
            double RMS_Value = Waveform_Measurements.RMS(Y_Waveform_Values);
            double Min_Value = Waveform_Measurements.Minimum(Y_Waveform_Values);
            double Max_Value = Waveform_Measurements.Maximum(Y_Waveform_Values);
            double Stdev_Value = Waveform_Measurements.StandardDeviation(Y_Waveform_Values);
            double PeakPeak_Value = Waveform_Measurements.Peak_Peak(Max_Value, Min_Value);

            double Period = Waveform_Measurements.Period(X_Waveform_Values, Y_Waveform_Values, Data_Points, Max_Value, Min_Value);
            double Frequency = Waveform_Measurements.Frequency(Period);

            Frequency_Values.Add(Frequency);
            Period_Values.Add(Period);
            PeakPeak_Values.Add(PeakPeak_Value);
            Mean_Values.Add(Mean_Value);
            RMS_Values.Add(RMS_Value);
            Min_Values.Add(Min_Value);
            Max_Values.Add(Max_Value);
            Stdev_Values.Add(Stdev_Value);

            Frequency_DateTime_Values.Add(Date_Time);
            Period_DateTime_Values.Add(Date_Time);
            PeakPeak_DateTime_Values.Add(Date_Time);
            Mean_DateTime_Values.Add(Date_Time);
            RMS_DateTime_Values.Add(Date_Time);
            Min_DateTime_Values.Add(Date_Time);
            Max_DateTime_Values.Add(Date_Time);
            Stdev_DateTime_Values.Add(Date_Time);

            if (Frequency_Measurement_Plot_Enabled)
            { try { Frequency_Measurement_Plot_Window.Measurement_Data_Queue.Add((Date_Time, Frequency)); } catch (Exception) { } }

            if (Period_Measurement_Plot_Enabled)
            { try { Period_Measurement_Plot_Window.Measurement_Data_Queue.Add((Date_Time, Period)); } catch (Exception) { } }

            if (PeakPeak_Measurement_Plot_Enabled)
            { try { PeakPeak_Measurement_Plot_Window.Measurement_Data_Queue.Add((Date_Time, PeakPeak_Value)); } catch (Exception) { } }

            if (Mean_Measurement_Plot_Enabled)
            { try { Mean_Measurement_Plot_Window.Measurement_Data_Queue.Add((Date_Time, Mean_Value)); } catch (Exception) { } }

            if (RMS_Measurement_Plot_Enabled)
            { try { RMS_Measurement_Plot_Window.Measurement_Data_Queue.Add((Date_Time, RMS_Value)); } catch (Exception) { } }

            if (Min_Measurement_Plot_Enabled)
            { try { Min_Measurement_Plot_Window.Measurement_Data_Queue.Add((Date_Time, Min_Value)); } catch (Exception) { } }

            if (Max_Measurement_Plot_Enabled)
            { try { Max_Measurement_Plot_Window.Measurement_Data_Queue.Add((Date_Time, Max_Value)); } catch (Exception) { } }

            if (Stdev_Measurement_Plot_Enabled)
            { try { Stdev_Measurement_Plot_Window.Measurement_Data_Queue.Add((Date_Time, Stdev_Value)); } catch (Exception) { } }

            Update_Measurement_Table(Frequency, Period, PeakPeak_Value, Mean_Value, RMS_Value, Min_Value, Max_Value, Stdev_Value);
        }

        private void Update_Measurement_Table(double Frequency_Present, double Period_Present, double PeakPeak_Value_Present, double Mean_Value_Present, double RMS_Value_Present, double Min_Value_Present, double Max_Value_Present, double Stdev_Value_Present)
        {
            Frequency_Value = Axis_Scale_Config.Value_SI_Prefix(Frequency_Present, Frequency_Value_Round) + "Hz";
            Frequency_Mean = Axis_Scale_Config.Value_SI_Prefix(Frequency_Values.Mean(), Frequency_Value_Round) + "Hz";
            Frequency_Min = Axis_Scale_Config.Value_SI_Prefix(Frequency_Values.Min(), Frequency_Value_Round) + "Hz";
            Frequency_Max = Axis_Scale_Config.Value_SI_Prefix(Frequency_Values.Max(), Frequency_Value_Round) + "Hz";
            Frequency_Stdev = Axis_Scale_Config.Value_SI_Prefix(Frequency_Values.StandardDeviation(), Frequency_Value_Round) + "Hz";
            Frequency_Count = Frequency_Values.Count.ToString();

            Period_Value = Axis_Scale_Config.Value_SI_Prefix(Period_Present, Period_Value_Round) + "s";
            Period_Mean = Axis_Scale_Config.Value_SI_Prefix(Period_Values.Mean(), Period_Value_Round) + "s";
            Period_Min = Axis_Scale_Config.Value_SI_Prefix(Period_Values.Min(), Period_Value_Round) + "s";
            Period_Max = Axis_Scale_Config.Value_SI_Prefix(Period_Values.Max(), Period_Value_Round) + "s";
            Period_Stdev = Axis_Scale_Config.Value_SI_Prefix(Period_Values.StandardDeviation(), Period_Value_Round) + "s";
            Period_Count = Period_Values.Count.ToString();

            PeakPeak_Value = Axis_Scale_Config.Value_SI_Prefix(PeakPeak_Value_Present, PeakPeak_Value_Round) + YAxis_Units;
            PeakPeak_Mean = Axis_Scale_Config.Value_SI_Prefix(PeakPeak_Values.Mean(), PeakPeak_Value_Round) + YAxis_Units;
            PeakPeak_Min = Axis_Scale_Config.Value_SI_Prefix(PeakPeak_Values.Min(), PeakPeak_Value_Round) + YAxis_Units;
            PeakPeak_Max = Axis_Scale_Config.Value_SI_Prefix(PeakPeak_Values.Max(), PeakPeak_Value_Round) + YAxis_Units;
            PeakPeak_Stdev = Axis_Scale_Config.Value_SI_Prefix(PeakPeak_Values.StandardDeviation(), PeakPeak_Value_Round) + YAxis_Units;
            PeakPeak_Count = PeakPeak_Values.Count.ToString();

            Mean_Value = Axis_Scale_Config.Value_SI_Prefix(Mean_Value_Present, Mean_Value_Round) + YAxis_Units;
            Mean_Mean = Axis_Scale_Config.Value_SI_Prefix(Mean_Values.Mean(), Mean_Value_Round) + YAxis_Units;
            Mean_Min = Axis_Scale_Config.Value_SI_Prefix(Mean_Values.Min(), Mean_Value_Round) + YAxis_Units;
            Mean_Max = Axis_Scale_Config.Value_SI_Prefix(Mean_Values.Max(), Mean_Value_Round) + YAxis_Units;
            Mean_Stdev = Axis_Scale_Config.Value_SI_Prefix(Mean_Values.StandardDeviation(), Mean_Value_Round) + YAxis_Units;
            Mean_Count = Mean_Values.Count.ToString();

            RMS_Value = Axis_Scale_Config.Value_SI_Prefix(RMS_Value_Present, RMS_Value_Round) + YAxis_Units;
            RMS_Mean = Axis_Scale_Config.Value_SI_Prefix(RMS_Values.Mean(), RMS_Value_Round) + YAxis_Units;
            RMS_Min = Axis_Scale_Config.Value_SI_Prefix(RMS_Values.Min(), RMS_Value_Round) + YAxis_Units;
            RMS_Max = Axis_Scale_Config.Value_SI_Prefix(RMS_Values.Max(), RMS_Value_Round) + YAxis_Units;
            RMS_Stdev = Axis_Scale_Config.Value_SI_Prefix(RMS_Values.StandardDeviation(), RMS_Value_Round) + YAxis_Units;
            RMS_Count = RMS_Values.Count.ToString();

            Min_Value = Axis_Scale_Config.Value_SI_Prefix(Min_Value_Present, Min_Value_Round) + YAxis_Units;
            Min_Mean = Axis_Scale_Config.Value_SI_Prefix(Min_Values.Mean(), Min_Value_Round) + YAxis_Units;
            Min_Min = Axis_Scale_Config.Value_SI_Prefix(Min_Values.Min(), Min_Value_Round) + YAxis_Units;
            Min_Max = Axis_Scale_Config.Value_SI_Prefix(Min_Values.Max(), Min_Value_Round) + YAxis_Units;
            Min_Stdev = Axis_Scale_Config.Value_SI_Prefix(Min_Values.StandardDeviation(), Min_Value_Round) + YAxis_Units;
            Min_Count = Min_Values.Count.ToString();

            Max_Value = Axis_Scale_Config.Value_SI_Prefix(Max_Value_Present, Max_Value_Round) + YAxis_Units;
            Max_Mean = Axis_Scale_Config.Value_SI_Prefix(Max_Values.Mean(), Max_Value_Round) + YAxis_Units;
            Max_Min = Axis_Scale_Config.Value_SI_Prefix(Max_Values.Min(), Max_Value_Round) + YAxis_Units;
            Max_Max = Axis_Scale_Config.Value_SI_Prefix(Max_Values.Max(), Max_Value_Round) + YAxis_Units;
            Max_Stdev = Axis_Scale_Config.Value_SI_Prefix(Max_Values.StandardDeviation(), Max_Value_Round) + YAxis_Units;
            Max_Count = Max_Values.Count.ToString();

            Stdev_Value = Axis_Scale_Config.Value_SI_Prefix(Stdev_Value_Present, Stdev_Value_Round) + YAxis_Units;
            Stdev_Mean = Axis_Scale_Config.Value_SI_Prefix(Stdev_Values.Mean(), Stdev_Value_Round) + YAxis_Units;
            Stdev_Min = Axis_Scale_Config.Value_SI_Prefix(Stdev_Values.Min(), Stdev_Value_Round) + YAxis_Units;
            Stdev_Max = Axis_Scale_Config.Value_SI_Prefix(Stdev_Values.Max(), Stdev_Value_Round) + YAxis_Units;
            Stdev_Stdev = Axis_Scale_Config.Value_SI_Prefix(Stdev_Values.StandardDeviation(), Stdev_Value_Round) + YAxis_Units;
            Stdev_Count = Stdev_Values.Count.ToString();
        }
    }
}
