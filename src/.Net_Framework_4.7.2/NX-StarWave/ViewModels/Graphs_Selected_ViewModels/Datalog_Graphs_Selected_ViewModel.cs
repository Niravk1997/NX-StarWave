using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush Datalog_CH1_Graph_Selected_ = Brushes.Transparent;
        public Brush Datalog_CH1_Graph_Selected
        {
            get
            {
                return Datalog_CH1_Graph_Selected_;
            }
            set
            {
                Datalog_CH1_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush Datalog_CH2_Graph_Selected_ = Brushes.Transparent;
        public Brush Datalog_CH2_Graph_Selected
        {
            get
            {
                return Datalog_CH2_Graph_Selected_;
            }
            set
            {
                Datalog_CH2_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush Datalog_CH3_Graph_Selected_ = Brushes.Transparent;
        public Brush Datalog_CH3_Graph_Selected
        {
            get
            {
                return Datalog_CH3_Graph_Selected_;
            }
            set
            {
                Datalog_CH3_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }

        private Brush Datalog_CH4_Graph_Selected_ = Brushes.Transparent;
        public Brush Datalog_CH4_Graph_Selected
        {
            get
            {
                return Datalog_CH4_Graph_Selected_;
            }
            set
            {
                Datalog_CH4_Graph_Selected_ = value;
                NotifyPropertyChanged();
            }
        }
    }
}
