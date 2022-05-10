using MahApps.Metro.Controls;

namespace Anytime_FFT
{
    public partial class FFT : MetroWindow
    {
        //FFT Window Type Selected
        //private int FFT_Window_Type;

        //FFT Window Gain Correction
        private double FFT_Window_Gain_Correction = 1;

        //Selects if dBVrms is selected or not;
        //private bool Magnitude_dBVrms = true;

        private (bool, double[]) FFT_Window_Array_Generate(int Data_Points, int FFT_Window_Type)
        {
            switch (FFT_Window_Type)
            {
                case 0:
                    return (false, new double[0]);
                case 1:
                    return (true, MathNet.Numerics.Window.Hamming(Data_Points));
                case 2:
                    return (true, MathNet.Numerics.Window.HammingPeriodic(Data_Points));
                case 3:
                    return (true, MathNet.Numerics.Window.Hann(Data_Points));
                case 4:
                    return (true, MathNet.Numerics.Window.HannPeriodic(Data_Points));
                case 5:
                    return (true, MathNet.Numerics.Window.BlackmanHarris(Data_Points));
                case 6:
                    return (true, MathNet.Numerics.Window.BlackmanNuttall(Data_Points));
                case 7:
                    return (true, MathNet.Numerics.Window.Lanczos(Data_Points));
                case 8:
                    return (true, MathNet.Numerics.Window.LanczosPeriodic(Data_Points));
                case 9:
                    return (true, MathNet.Numerics.Window.Cosine(Data_Points));
                case 10:
                    return (true, MathNet.Numerics.Window.CosinePeriodic(Data_Points));
                case 11:
                    return (true, MathNet.Numerics.Window.Triangular(Data_Points));
                default:
                    return (false, new double[0]);
            }
        }
    }
}
