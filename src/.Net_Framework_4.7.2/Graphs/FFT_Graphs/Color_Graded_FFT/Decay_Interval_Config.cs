using MahApps.Metro.Controls;
using System.Diagnostics;

namespace Color_Graded_FFT
{
    public partial class Color_Graded_FFT_Plotter : MetroWindow
    {
        private Stopwatch Decay_Interval = new Stopwatch();

        private void Start_Decay_Interval()
        {
            Decay_Interval.Start();
        }

        private void Stop_Decay_Interval()
        {
            Decay_Interval.Stop();
        }
    }
}
