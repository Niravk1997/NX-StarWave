using System.Collections.Generic;
using System.Linq;

namespace Auto_Measurements
{
    public partial class Automatic_Measurements
    {
        internal double Frequency(double[] X_Waveform_Values, double[] Y_Waveform_Values, int Data_Points, double Waveform_Max, double Waveform_Min)
        {
            double Half_Wavefrom_MAX = (Waveform_Max + Waveform_Min) / 2.00;

            double Upper_Waveform_Threshold = Half_Wavefrom_MAX;
            double Lower_Waveform_Threshold = Half_Wavefrom_MAX;

            bool Value_Below_Threshold = true;
            double Number_of_Zero_Crossings = 0;

            List<double> Zero_Crossings = new List<double>();

            for (int i = 0; i < Data_Points; i++)
            {
                if (Value_Below_Threshold)
                {
                    if (Y_Waveform_Values[i] > Upper_Waveform_Threshold)
                    {
                        Number_of_Zero_Crossings++;
                        Zero_Crossings.Add(X_Waveform_Values[i]);
                        Value_Below_Threshold = false;
                    }
                }
                else
                {
                    if (Y_Waveform_Values[i] < Lower_Waveform_Threshold)
                    {
                        Value_Below_Threshold = true;
                    }
                }
            }

            int Zero_Crossings_Count = Zero_Crossings.Count;
            //Frequency and Period Measurement are more accurate when there are more than 2 zero crossings
            if (Zero_Crossings_Count > 2)
            {
                List<double> Time_Values_Zero_Crossings = new List<double>();
                for (int i = 2; i < Zero_Crossings_Count; i++)
                {
                    Time_Values_Zero_Crossings.Add(Zero_Crossings.ElementAt(i) - Zero_Crossings.ElementAt(i - 1));
                }
                double Waveform_Period = Time_Values_Zero_Crossings.Average();
                return 1.0 / Waveform_Period;
            }
            else if (Zero_Crossings_Count > 1)
            {
                double Waveform_Period = Zero_Crossings.ElementAt(1) - Zero_Crossings.ElementAt(0);
                return 1.0 / Waveform_Period;
            }
            else
            {
                return 0;
            }
        }

        internal double Frequency(double Period)
        {
            if (Period == 0)
            {
                return 0;
            }
            else
            {
                return 1 / Period;
            }
        }
    }
}
