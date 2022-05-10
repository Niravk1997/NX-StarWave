using Averaging;
using MahApps.Metro.Controls;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
    {
        private Waveform_Averaging Waveform_Average;

        private void Initialize_Waveform_Averaging()
        {
            Waveform_Average = new Waveform_Averaging();
        }
    }
}
