using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush Waveform_Calculator_Selected_ = Brushes.Transparent;
        public Brush Waveform_Calculator_Selected
        {
            get
            {
                return Waveform_Calculator_Selected_;
            }
            set
            {
                Waveform_Calculator_Selected_ = value;
                NotifyPropertyChanged();
            }
        }
    }
}
