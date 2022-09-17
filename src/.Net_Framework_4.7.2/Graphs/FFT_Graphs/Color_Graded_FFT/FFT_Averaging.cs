using Averaging;
using MahApps.Metro.Controls;

namespace Color_Graded_FFT
{
    public partial class Color_Graded_FFT_Plotter : MetroWindow
    {
        private Waveform_Averaging FFT_Average;

        private void Initialize_FFT_Averaging()
        {
            FFT_Average = new Waveform_Averaging();
        }
    }
}
