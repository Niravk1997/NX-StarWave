using System.ComponentModel;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : INotifyPropertyChanged
    {
        private string RMS_Value_ = "null";
        public string RMS_Value
        {
            get { return RMS_Value_; }
            set
            {
                RMS_Value_ = value;
                NotifyPropertyChanged("RMS_Value");
            }
        }

        private string RMS_Mean_ = "null";
        public string RMS_Mean
        {
            get { return RMS_Mean_; }
            set
            {
                RMS_Mean_ = value;
                NotifyPropertyChanged("RMS_Mean");
            }
        }

        private string RMS_Min_ = "null";
        public string RMS_Min
        {
            get { return RMS_Min_; }
            set
            {
                RMS_Min_ = value;
                NotifyPropertyChanged("RMS_Min");
            }
        }

        private string RMS_Max_ = "null";
        public string RMS_Max
        {
            get { return RMS_Max_; }
            set
            {
                RMS_Max_ = value;
                NotifyPropertyChanged("RMS_Max");
            }
        }

        private string RMS_Stdev_ = "null";
        public string RMS_Stdev
        {
            get { return RMS_Stdev_; }
            set
            {
                RMS_Stdev_ = value;
                NotifyPropertyChanged("RMS_Stdev");
            }
        }

        private string RMS_Count_ = "null";
        public string RMS_Count
        {
            get { return RMS_Count_; }
            set
            {
                RMS_Count_ = value;
                NotifyPropertyChanged("RMS_Count");
            }
        }
    }
}
