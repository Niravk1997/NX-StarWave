using System.ComponentModel;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : INotifyPropertyChanged
    {
        private string Max_Value_ = "null";
        public string Max_Value
        {
            get { return Max_Value_; }
            set
            {
                Max_Value_ = value;
                NotifyPropertyChanged("Max_Value");
            }
        }

        private string Max_Mean_ = "null";
        public string Max_Mean
        {
            get { return Max_Mean_; }
            set
            {
                Max_Mean_ = value;
                NotifyPropertyChanged("Max_Mean");
            }
        }

        private string Max_Min_ = "null";
        public string Max_Min
        {
            get { return Max_Min_; }
            set
            {
                Max_Min_ = value;
                NotifyPropertyChanged("Max_Min");
            }
        }

        private string Max_Max_ = "null";
        public string Max_Max
        {
            get { return Max_Max_; }
            set
            {
                Max_Max_ = value;
                NotifyPropertyChanged("Max_Max");
            }
        }

        private string Max_Stdev_ = "null";
        public string Max_Stdev
        {
            get { return Max_Stdev_; }
            set
            {
                Max_Stdev_ = value;
                NotifyPropertyChanged("Max_Stdev");
            }
        }

        private string Max_Count_ = "null";
        public string Max_Count
        {
            get { return Max_Count_; }
            set
            {
                Max_Count_ = value;
                NotifyPropertyChanged("Max_Count");
            }
        }
    }
}
