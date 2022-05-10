using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush XY_W1_Graph_Selected_ = Brushes.Transparent;
        public Brush XY_W1_Graph_Selected
        {
            get
            {
                return XY_W1_Graph_Selected_;
            }
            set
            {
                XY_W1_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush XY_W2_Graph_Selected_ = Brushes.Transparent;
        public Brush XY_W2_Graph_Selected
        {
            get
            {
                return XY_W2_Graph_Selected_;
            }
            set
            {
                XY_W2_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush XY_W3_Graph_Selected_ = Brushes.Transparent;
        public Brush XY_W3_Graph_Selected
        {
            get
            {
                return XY_W3_Graph_Selected_;
            }
            set
            {
                XY_W3_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush XY_W4_Graph_Selected_ = Brushes.Transparent;
        public Brush XY_W4_Graph_Selected
        {
            get
            {
                return XY_W4_Graph_Selected_;
            }
            set
            {
                XY_W4_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush XY_Waveform_W1_Graph_Selected_ = Brushes.Transparent;
        public Brush XY_Waveform_W1_Graph_Selected
        {
            get
            {
                return XY_Waveform_W1_Graph_Selected_;
            }
            set
            {
                XY_Waveform_W1_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush XY_Waveform_W2_Graph_Selected_ = Brushes.Transparent;
        public Brush XY_Waveform_W2_Graph_Selected
        {
            get
            {
                return XY_Waveform_W2_Graph_Selected_;
            }
            set
            {
                XY_Waveform_W2_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush XY_Waveform_W3_Graph_Selected_ = Brushes.Transparent;
        public Brush XY_Waveform_W3_Graph_Selected
        {
            get
            {
                return XY_Waveform_W3_Graph_Selected_;
            }
            set
            {
                XY_Waveform_W3_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush XY_Waveform_W4_Graph_Selected_ = Brushes.Transparent;
        public Brush XY_Waveform_W4_Graph_Selected
        {
            get
            {
                return XY_Waveform_W4_Graph_Selected_;
            }
            set
            {
                XY_Waveform_W4_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }
    }
}