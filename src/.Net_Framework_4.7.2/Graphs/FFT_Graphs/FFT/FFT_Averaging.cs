using Averaging;
using MahApps.Metro.Controls;

namespace FFT
{
    public partial class FFT_Plotter : MetroWindow
    {
        private Waveform_Averaging FFT_Average;

        private void Initialize_FFT_Averaging()
        {
            FFT_Average = new Waveform_Averaging();
        }
    }
}
