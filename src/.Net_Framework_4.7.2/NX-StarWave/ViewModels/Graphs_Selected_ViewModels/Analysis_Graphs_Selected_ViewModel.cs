using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush Reference_Calculator_Graph_Selected_ = Brushes.Transparent;
        public Brush Reference_Calculator_Graph_Selected
        {
            get
            {
                return Reference_Calculator_Graph_Selected_;
            }
            set
            {
                Reference_Calculator_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush Waveform_Player_Selected_ = Brushes.Transparent;
        public Brush Waveform_Player_Selected
        {
            get
            {
                return Waveform_Player_Selected_;
            }
            set
            {
                Waveform_Player_Selected_ = value;
                NotifyPropertyChanged("Waveform_Player_Selected");
            }
        }

        private Brush Compare_YT_Plots_Selected_ = Brushes.Transparent;
        public Brush Compare_YT_Plots_Selected
        {
            get
            {
                return Compare_YT_Plots_Selected_;
            }
            set
            {
                Compare_YT_Plots_Selected_ = value;
                NotifyPropertyChanged("Compare_YT_Plots_Selected");
            }
        }
    }
}