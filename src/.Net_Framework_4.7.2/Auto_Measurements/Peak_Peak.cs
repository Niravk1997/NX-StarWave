using MathNet.Numerics.Statistics;

namespace Auto_Measurements
{
    public partial class Automatic_Measurements
    {
        internal double Peak_Peak(double Waveform_Max, double Waveform_Min)
        {
            return Waveform_Max - Waveform_Min;
        }

        internal double Peak_Peak(double[] Waveform)
        {
            return ArrayStatistics.Maximum(Waveform) - ArrayStatistics.Minimum(Waveform);
        }
    }
}
