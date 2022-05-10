using System.ComponentModel;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : INotifyPropertyChanged
    {
        private string Mean_Value_ = "null";
        public string Mean_Value
        {
            get { return Mean_Value_; }
            set
            {
                Mean_Value_ = value;
                NotifyPropertyChanged("Mean_Value");
            }
        }

        private string Mean_Mean_ = "null";
        public string Mean_Mean
        {
            get { return Mean_Mean_; }
            set
            {
                Mean_Mean_ = value;
                NotifyPropertyChanged("Mean_Mean");
            }
        }

        private string Mean_Min_ = "null";
        public string Mean_Min
        {
            get { return Mean_Min_; }
            set
            {
                Mean_Min_ = value;
                NotifyPropertyChanged("Mean_Min");
            }
        }

        private string Mean_Max_ = "null";
        public string Mean_Max
        {
            get { return Mean_Max_; }
            set
            {
                Mean_Max_ = value;
                NotifyPropertyChanged("Mean_Max");
            }
        }

        private string Mean_Stdev_ = "null";
        public string Mean_Stdev
        {
            get { return Mean_Stdev_; }
            set
            {
                Mean_Stdev_ = value;
                NotifyPropertyChanged("Mean_Stdev");
            }
        }

        private string Mean_Count_ = "null";
        public string Mean_Count
        {
            get { return Mean_Count_; }
            set
            {
                Mean_Count_ = value;
                NotifyPropertyChanged("Mean_Count");
            }
        }
    }
}
