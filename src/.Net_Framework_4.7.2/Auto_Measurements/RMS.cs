using MathNet.Numerics.Statistics;

namespace Auto_Measurements
{
    public partial class Automatic_Measurements
    {
        internal double RMS(double[] Waveform)
        {
            return ArrayStatistics.RootMeanSquare(Waveform);
        }
    }
}
