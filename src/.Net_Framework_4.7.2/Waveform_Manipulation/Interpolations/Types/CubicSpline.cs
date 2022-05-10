using MathNet.Numerics.Interpolation;

namespace Interpolations
{
    public partial class Waveform_Interpolations
    {
        private (double[], double[]) CubicSpline_Interpolation(double[] X, double[] Y, int Resampling_Factor, double Start_Time, double Stop_Time, int Original_Data_Points)
        {
            int Resample_Data_Length = (Original_Data_Points * Resampling_Factor);
            CubicSpline CubicSpline_Data = CubicSpline.InterpolateNaturalSorted(X, Y);
            double[] New_X = Linspace(Start_Time, Stop_Time, Resample_Data_Length);
            double[] New_Y = new double[Resample_Data_Length];
            for (int i = 0; i < Resample_Data_Length; i++)
            {
                New_Y[i] = CubicSpline_Data.Interpolate(New_X[i]);
            }
            return (New_X, New_Y);
        }
    }
}
