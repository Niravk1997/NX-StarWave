using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush Histogram_CH1_Graph_Selected_ = Brushes.Transparent;
        public Brush Histogram_CH1_Graph_Selected
        {
            get
            {
                return Histogram_CH1_Graph_Selected_;
            }
            set
            {
                Histogram_CH1_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush Histogram_CH2_Graph_Selected_ = Brushes.Transparent;
        public Brush Histogram_CH2_Graph_Selected
        {
            get
            {
                return Histogram_CH2_Graph_Selected_;
            }
            set
            {
                Histogram_CH2_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush Histogram_CH3_Graph_Selected_ = Brushes.Transparent;
        public Brush Histogram_CH3_Graph_Selected
        {
            get
            {
                return Histogram_CH3_Graph_Selected_;
            }
            set
            {
                Histogram_CH3_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush Histogram_CH4_Graph_Selected_ = Brushes.Transparent;
        public Brush Histogram_CH4_Graph_Selected
        {
            get
            {
                return Histogram_CH4_Graph_Selected_;
            }
            set
            {
                Histogram_CH4_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }
    }
}