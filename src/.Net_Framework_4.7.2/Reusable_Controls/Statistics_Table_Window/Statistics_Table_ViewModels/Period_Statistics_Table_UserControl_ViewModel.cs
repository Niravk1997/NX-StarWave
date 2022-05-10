using System.ComponentModel;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : INotifyPropertyChanged
    {
        private string Period_Value_ = "null";
        public string Period_Value
        {
            get { return Period_Value_; }
            set
            {
                Period_Value_ = value;
                NotifyPropertyChanged("Period_Value");
            }
        }

        private string Period_Mean_ = "null";
        public string Period_Mean
        {
            get { return Period_Mean_; }
            set
            {
                Period_Mean_ = value;
                NotifyPropertyChanged("Period_Mean");
            }
        }

        private string Period_Min_ = "null";
        public string Period_Min
        {
            get { return Period_Min_; }
            set
            {
                Period_Min_ = value;
                NotifyPropertyChanged("Period_Min");
            }
        }

        private string Period_Max_ = "null";
        public string Period_Max
        {
            get { return Period_Max_; }
            set
            {
                Period_Max_ = value;
                NotifyPropertyChanged("Period_Max");
            }
        }

        private string Period_Stdev_ = "null";
        public string Period_Stdev
        {
            get { return Period_Stdev_; }
            set
            {
                Period_Stdev_ = value;
                NotifyPropertyChanged("Period_Stdev");
            }
        }

        private string Period_Count_ = "null";
        public string Period_Count
        {
            get { return Period_Count_; }
            set
            {
                Period_Count_ = value;
                NotifyPropertyChanged("Period_Count");
            }
        }
    }
}
