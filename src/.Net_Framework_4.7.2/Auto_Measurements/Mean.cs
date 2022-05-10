using MathNet.Numerics.Statistics;

namespace Auto_Measurements
{
    public partial class Automatic_Measurements
    {
        internal double Mean(double[] Waveform)
        {
            return ArrayStatistics.Mean(Waveform);
        }
    }
}
