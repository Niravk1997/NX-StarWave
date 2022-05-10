using MathNet.Numerics.Statistics;

namespace Auto_Measurements
{
    public partial class Automatic_Measurements
    {
        internal double Maximum(double[] Waveform)
        {
            return ArrayStatistics.Maximum(Waveform);
        }
    }
}
