using System.ComponentModel;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : INotifyPropertyChanged
    {
        private string Min_Value_ = "null";
        public string Min_Value
        {
            get { return Min_Value_; }
            set
            {
                Min_Value_ = value;
                NotifyPropertyChanged("Min_Value");
            }
        }

        private string Min_Mean_ = "null";
        public string Min_Mean
        {
            get { return Min_Mean_; }
            set
            {
                Min_Mean_ = value;
                NotifyPropertyChanged("Min_Mean");
            }
        }

        private string Min_Min_ = "null";
        public string Min_Min
        {
            get { return Min_Min_; }
            set
            {
                Min_Min_ = value;
                NotifyPropertyChanged("Min_Min");
            }
        }

        private string Min_Max_ = "null";
        public string Min_Max
        {
            get { return Min_Max_; }
            set
            {
                Min_Max_ = value;
                NotifyPropertyChanged("Min_Max");
            }
        }

        private string Min_Stdev_ = "null";
        public string Min_Stdev
        {
            get { return Min_Stdev_; }
            set
            {
                Min_Stdev_ = value;
                NotifyPropertyChanged("Min_Stdev");
            }
        }

        private string Min_Count_ = "null";
        public string Min_Count
        {
            get { return Min_Count_; }
            set
            {
                Min_Count_ = value;
                NotifyPropertyChanged("Min_Count");
            }
        }
    }
}
