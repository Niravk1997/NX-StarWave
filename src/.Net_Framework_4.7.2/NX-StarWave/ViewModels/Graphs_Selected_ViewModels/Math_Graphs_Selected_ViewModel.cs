using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush Math_YT_W1_Graph_Selected_ = Brushes.Transparent;
        public Brush Math_YT_W1_Graph_Selected
        {
            get
            {
                return Math_YT_W1_Graph_Selected_;
            }
            set
            {
                Math_YT_W1_Graph_Selected_ = value;
                NotifyPropertyChanged("Math_YT_W1_Graph_Selected");
            }
        }

        private Brush Math_YT_W2_Graph_Selected_ = Brushes.Transparent;
        public Brush Math_YT_W2_Graph_Selected
        {
            get
            {
                return Math_YT_W2_Graph_Selected_;
            }
            set
            {
                Math_YT_W2_Graph_Selected_ = value;
                NotifyPropertyChanged("Math_YT_W2_Graph_Selected");
            }
        }

        private Brush Math_YT_W3_Graph_Selected_ = Brushes.Transparent;
        public Brush Math_YT_W3_Graph_Selected
        {
            get
            {
                return Math_YT_W3_Graph_Selected_;
            }
            set
            {
                Math_YT_W3_Graph_Selected_ = value;
                NotifyPropertyChanged("Math_YT_W3_Graph_Selected");
            }
        }

        private Brush Math_YT_W4_Graph_Selected_ = Brushes.Transparent;
        public Brush Math_YT_W4_Graph_Selected
        {
            get
            {
                return Math_YT_W4_Graph_Selected_;
            }
            set
            {
                Math_YT_W4_Graph_Selected_ = value;
                NotifyPropertyChanged("Math_YT_W4_Graph_Selected");
            }
        }

        private Brush Math_FFT_W1_Graph_Selected_ = Brushes.Transparent;
        public Brush Math_FFT_W1_Graph_Selected
        {
            get
            {
                return Math_FFT_W1_Graph_Selected_;
            }
            set
            {
                Math_FFT_W1_Graph_Selected_ = value;
                NotifyPropertyChanged("Math_FFT_W1_Graph_Selected");
            }
        }

        private Brush Math_FFT_W2_Graph_Selected_ = Brushes.Transparent;
        public Brush Math_FFT_W2_Graph_Selected
        {
            get
            {
                return Math_FFT_W2_Graph_Selected_;
            }
            set
            {
                Math_FFT_W2_Graph_Selected_ = value;
                NotifyPropertyChanged("Math_FFT_W2_Graph_Selected");
            }
        }

        private Brush Math_FFT_W3_Graph_Selected_ = Brushes.Transparent;
        public Brush Math_FFT_W3_Graph_Selected
        {
            get
            {
                return Math_FFT_W3_Graph_Selected_;
            }
            set
            {
                Math_FFT_W3_Graph_Selected_ = value;
                NotifyPropertyChanged("Math_FFT_W3_Graph_Selected");
            }
        }

        private Brush Math_FFT_W4_Graph_Selected_ = Brushes.Transparent;
        public Brush Math_FFT_W4_Graph_Selected
        {
            get
            {
                return Math_FFT_W4_Graph_Selected_;
            }
            set
            {
                Math_FFT_W4_Graph_Selected_ = value;
                NotifyPropertyChanged("Math_FFT_W4_Graph_Selected");
            }
        }

        private Brush Waveform_Calculator_Graph_Selected_ = Brushes.Transparent;
        public Brush Waveform_Calculator_Graph_Selected
        {
            get
            {
                return Waveform_Calculator_Graph_Selected_;
            }
            set
            {
                Waveform_Calculator_Graph_Selected_ = value;
                NotifyPropertyChanged("Waveform_Calculator_Graph_Selected");
            }
        }

        private Brush NodeNetwork_Calculator_Graph_Selected_ = Brushes.Transparent;
        public Brush NodeNetwork_Calculator_Graph_Selected
        {
            get
            {
                return NodeNetwork_Calculator_Graph_Selected_;
            }
            set
            {
                NodeNetwork_Calculator_Graph_Selected_ = value;
                NotifyPropertyChanged("NodeNetwork_Calculator_Graph_Selected");
            }
        }
    }
}