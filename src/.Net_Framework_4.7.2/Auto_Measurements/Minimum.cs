using MathNet.Numerics.Statistics;

namespace Auto_Measurements
{
    public partial class Automatic_Measurements
    {
        internal double Minimum(double[] Waveform)
        {
            return ArrayStatistics.Minimum(Waveform);
        }
    }
}
