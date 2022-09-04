using System;
using System.Linq;

namespace Interpolations
{
    public partial class Waveform_Interpolations
    {
        //--------------------------------------------------------------------------
        // Sinc Interploation Implementation

        /* normalized sinc function */
        private double Sinc(double x)
        {
            if (x == 0.0)
            {
                return 1.0;
            }
            else
            {
                x = x * Math.PI;
                return (Math.Sin(x) / x);
            }
        }

        /* interpolate a function made of in samples at point x */
        private double Sinc_Approx(double[] input, int in_sz, double x)
        {
            double res = 0.0;
            for (int i = 0; i < in_sz; i++)
            {
                res += input[i] * Sinc(x - i);
            }
            return res;
        }

        // do the actual resampling
        //private (double[], double[]) Sinc_Interpolation(double[] X, double[] Y, int Resampling_Factor, double Start_Time, double Stop_Time, int Original_Data_Points)
        //{
        //    int Resample_Data_Length = (Original_Data_Points * Resampling_Factor);
        //    double[] New_X = Linspace(Start_Time, Stop_Time, Resample_Data_Length);
        //    double[] New_Y = new double[Resample_Data_Length];
        //    double dx = (double)(Original_Data_Points - 1) / (Resample_Data_Length - 1);
        //    for (int i = 0; i < Resample_Data_Length; i++)
        //    {
        //        New_Y[i] = Sinc_Approx(Y, Original_Data_Points, i * dx);
        //    }
        //    return (New_X, New_Y);
        //}

        private (double[], double[]) Sinc_Interpolation(double[] X, double[] Y, int Resampling_Factor, double Start_Time, double Stop_Time, int Original_Data_Points)
        {
            int Resample_Data_Length = (Original_Data_Points * Resampling_Factor);

            double[] New_X = Linspace(Start_Time, Stop_Time, Resample_Data_Length);
            double[] New_Y = new double[Resample_Data_Length];

            double[] U_Array = Linspace(1, Original_Data_Points, Resample_Data_Length);
            double[] X_Array = Linspace(1, Original_Data_Points, Original_Data_Points);

            double Summation_Value = 0;

            for (int i = 0; i < Resample_Data_Length; i++)
            {
                Summation_Value = 0;
                for (int j = 0; j < Original_Data_Points; j++)
                {
                    Summation_Value += Y[j] * Sinc(U_Array[i] - X_Array[j]);
                }

                New_Y[i] = Summation_Value;
            }

            return (New_X, New_Y);
        }
        //--------------------------------------------------------------------------
    }
}
