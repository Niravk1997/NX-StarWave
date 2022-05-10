using MathNet.Numerics.Statistics;

namespace Auto_Measurements
{
    public partial class Automatic_Measurements
    {
        internal double StandardDeviation(double[] Waveform)
        {
            return ArrayStatistics.StandardDeviation(Waveform);
        }
    }
}
