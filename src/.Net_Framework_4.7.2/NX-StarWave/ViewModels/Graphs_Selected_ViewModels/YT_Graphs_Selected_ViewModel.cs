using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush YT_CH1_Graph_Selected_ = Brushes.Transparent;
        public Brush YT_CH1_Graph_Selected
        {
            get
            {
                return YT_CH1_Graph_Selected_;
            }
            set
            {
                YT_CH1_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush YT_CH2_Graph_Selected_ = Brushes.Transparent;
        public Brush YT_CH2_Graph_Selected
        {
            get
            {
                return YT_CH2_Graph_Selected_;
            }
            set
            {
                YT_CH2_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush YT_CH3_Graph_Selected_ = Brushes.Transparent;
        public Brush YT_CH3_Graph_Selected
        {
            get
            {
                return YT_CH3_Graph_Selected_;
            }
            set
            {
                YT_CH3_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush YT_CH4_Graph_Selected_ = Brushes.Transparent;
        public Brush YT_CH4_Graph_Selected
        {
            get
            {
                return YT_CH4_Graph_Selected_;
            }
            set
            {
                YT_CH4_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush YT_ALL_CH_Graph_Selected_ = Brushes.Transparent;
        public Brush YT_ALL_CH_Graph_Selected
        {
            get
            {
                return YT_ALL_CH_Graph_Selected_;
            }
            set
            {
                YT_ALL_CH_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush YT_ALL_CH_Square_Graph_Selected_ = Brushes.Transparent;
        public Brush YT_ALL_CH_Square_Graph_Selected
        {
            get
            {
                return YT_ALL_CH_Square_Graph_Selected_;
            }
            set
            {
                YT_ALL_CH_Square_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush YT_ALL_CH_Stack_Graph_Selected_ = Brushes.Transparent;
        public Brush YT_ALL_CH_Stack_Graph_Selected
        {
            get
            {
                return YT_ALL_CH_Stack_Graph_Selected_;
            }
            set
            {
                YT_ALL_CH_Stack_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush YT_ALL_CH_Seperate_Graph_Selected_ = Brushes.Transparent;
        public Brush YT_ALL_CH_Seperate_Graph_Selected
        {
            get
            {
                return YT_ALL_CH_Seperate_Graph_Selected_;
            }
            set
            {
                YT_ALL_CH_Seperate_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }
    }
}
