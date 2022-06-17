using System.ComponentModel;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : INotifyPropertyChanged
    {
        private string Graph_Background_Color_;
        public string Graph_Background_Color
        {
            get { return Graph_Background_Color_; }
            set
            {
                Graph_Background_Color_ = value;
                NotifyPropertyChanged("Graph_Background_Color");
            }
        }

        private string Graph_Foreground_Color_;
        public string Graph_Foreground_Color
        {
            get { return Graph_Foreground_Color_; }
            set
            {
                Graph_Foreground_Color_ = value;
                NotifyPropertyChanged("Graph_Foreground_Color");
            }
        }

        private string Graph_XAxis_Color_;
        public string Graph_XAxis_Color
        {
            get { return Graph_XAxis_Color_; }
            set
            {
                Graph_XAxis_Color_ = value;
                NotifyPropertyChanged("Graph_XAxis_Color");
            }
        }

        private string Graph_YAxis_Color_;
        public string Graph_YAxis_Color
        {
            get { return Graph_YAxis_Color_; }
            set
            {
                Graph_YAxis_Color_ = value;
                NotifyPropertyChanged("Graph_YAxis_Color");
            }
        }

        private string Graph_Grid_Color_;
        public string Graph_Grid_Color
        {
            get { return Graph_Grid_Color_; }
            set
            {
                Graph_Grid_Color_ = value;
                NotifyPropertyChanged("Graph_Grid_Color");
            }
        }
    }
}
