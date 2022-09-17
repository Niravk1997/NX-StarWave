using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush FFT_CH1_Graph_Selected_ = Brushes.Transparent;
        public Brush FFT_CH1_Graph_Selected
        {
            get
            {
                return FFT_CH1_Graph_Selected_;
            }
            set
            {
                FFT_CH1_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush FFT_CH2_Graph_Selected_ = Brushes.Transparent;
        public Brush FFT_CH2_Graph_Selected
        {
            get
            {
                return FFT_CH2_Graph_Selected_;
            }
            set
            {
                FFT_CH2_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush FFT_CH3_Graph_Selected_ = Brushes.Transparent;
        public Brush FFT_CH3_Graph_Selected
        {
            get
            {
                return FFT_CH3_Graph_Selected_;
            }
            set
            {
                FFT_CH3_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush FFT_CH4_Graph_Selected_ = Brushes.Transparent;
        public Brush FFT_CH4_Graph_Selected
        {
            get
            {
                return FFT_CH4_Graph_Selected_;
            }
            set
            {
                FFT_CH4_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush FFTWaveform_CH1_Graph_Selected_ = Brushes.Transparent;
        public Brush FFTWaveform_CH1_Graph_Selected
        {
            get
            {
                return FFTWaveform_CH1_Graph_Selected_;
            }
            set
            {
                FFTWaveform_CH1_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush FFTWaveform_CH2_Graph_Selected_ = Brushes.Transparent;
        public Brush FFTWaveform_CH2_Graph_Selected
        {
            get
            {
                return FFTWaveform_CH2_Graph_Selected_;
            }
            set
            {
                FFTWaveform_CH2_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush FFTWaveform_CH3_Graph_Selected_ = Brushes.Transparent;
        public Brush FFTWaveform_CH3_Graph_Selected
        {
            get
            {
                return FFTWaveform_CH3_Graph_Selected_;
            }
            set
            {
                FFTWaveform_CH3_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush FFTWaveform_CH4_Graph_Selected_ = Brushes.Transparent;
        public Brush FFTWaveform_CH4_Graph_Selected
        {
            get
            {
                return FFTWaveform_CH4_Graph_Selected_;
            }
            set
            {
                FFTWaveform_CH4_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush FFTWaterfall_CH1_Graph_Selected_ = Brushes.Transparent;
        public Brush FFTWaterfall_CH1_Graph_Selected
        {
            get
            {
                return FFTWaterfall_CH1_Graph_Selected_;
            }
            set
            {
                FFTWaterfall_CH1_Graph_Selected_ = value;
                NotifyPropertyChanged("FFTWaterfall_CH1_Graph_Selected");
            }
        }

        private Brush FFTWaterfall_CH2_Graph_Selected_ = Brushes.Transparent;
        public Brush FFTWaterfall_CH2_Graph_Selected
        {
            get
            {
                return FFTWaterfall_CH2_Graph_Selected_;
            }
            set
            {
                FFTWaterfall_CH2_Graph_Selected_ = value;
                NotifyPropertyChanged("FFTWaterfall_CH2_Graph_Selected");
            }
        }

        private Brush FFTWaterfall_CH3_Graph_Selected_ = Brushes.Transparent;
        public Brush FFTWaterfall_CH3_Graph_Selected
        {
            get
            {
                return FFTWaterfall_CH3_Graph_Selected_;
            }
            set
            {
                FFTWaterfall_CH3_Graph_Selected_ = value;
                NotifyPropertyChanged("FFTWaterfall_CH3_Graph_Selected");
            }
        }

        private Brush FFTWaterfall_CH4_Graph_Selected_ = Brushes.Transparent;
        public Brush FFTWaterfall_CH4_Graph_Selected
        {
            get
            {
                return FFTWaterfall_CH4_Graph_Selected_;
            }
            set
            {
                FFTWaterfall_CH4_Graph_Selected_ = value;
                NotifyPropertyChanged("FFTWaterfall_CH4_Graph_Selected");
            }
        }

        private Brush ColorGradedFFT_CH1_Graph_Selected_ = Brushes.Transparent;
        public Brush ColorGradedFFT_CH1_Graph_Selected
        {
            get
            {
                return ColorGradedFFT_CH1_Graph_Selected_;
            }
            set
            {
                ColorGradedFFT_CH1_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush ColorGradedFFT_CH2_Graph_Selected_ = Brushes.Transparent;
        public Brush ColorGradedFFT_CH2_Graph_Selected
        {
            get
            {
                return ColorGradedFFT_CH2_Graph_Selected_;
            }
            set
            {
                ColorGradedFFT_CH2_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush ColorGradedFFT_CH3_Graph_Selected_ = Brushes.Transparent;
        public Brush ColorGradedFFT_CH3_Graph_Selected
        {
            get
            {
                return ColorGradedFFT_CH3_Graph_Selected_;
            }
            set
            {
                ColorGradedFFT_CH3_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush ColorGradedFFT_CH4_Graph_Selected_ = Brushes.Transparent;
        public Brush ColorGradedFFT_CH4_Graph_Selected
        {
            get
            {
                return ColorGradedFFT_CH4_Graph_Selected_;
            }
            set
            {
                ColorGradedFFT_CH4_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }
    }
}