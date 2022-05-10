using System.ComponentModel;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : INotifyPropertyChanged
    {
        private string PeakPeak_Value_ = "null";
        public string PeakPeak_Value
        {
            get { return PeakPeak_Value_; }
            set
            {
                PeakPeak_Value_ = value;
                NotifyPropertyChanged("PeakPeak_Value");
            }
        }

        private string PeakPeak_Mean_ = "null";
        public string PeakPeak_Mean
        {
            get { return PeakPeak_Mean_; }
            set
            {
                PeakPeak_Mean_ = value;
                NotifyPropertyChanged("PeakPeak_Mean");
            }
        }

        private string PeakPeak_Min_ = "null";
        public string PeakPeak_Min
        {
            get { return PeakPeak_Min_; }
            set
            {
                PeakPeak_Min_ = value;
                NotifyPropertyChanged("PeakPeak_Min");
            }
        }

        private string PeakPeak_Max_ = "null";
        public string PeakPeak_Max
        {
            get { return PeakPeak_Max_; }
            set
            {
                PeakPeak_Max_ = value;
                NotifyPropertyChanged("PeakPeak_Max");
            }
        }

        private string PeakPeak_Stdev_ = "null";
        public string PeakPeak_Stdev
        {
            get { return PeakPeak_Stdev_; }
            set
            {
                PeakPeak_Stdev_ = value;
                NotifyPropertyChanged("PeakPeak_Stdev");
            }
        }

        private string PeakPeak_Count_ = "null";
        public string PeakPeak_Count
        {
            get { return PeakPeak_Count_; }
            set
            {
                PeakPeak_Count_ = value;
                NotifyPropertyChanged("PeakPeak_Count");
            }
        }
    }
}
