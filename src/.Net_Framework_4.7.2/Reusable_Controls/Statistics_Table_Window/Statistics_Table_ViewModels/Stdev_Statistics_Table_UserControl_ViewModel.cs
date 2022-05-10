using System.ComponentModel;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : INotifyPropertyChanged
    {
        private string Stdev_Value_ = "null";
        public string Stdev_Value
        {
            get { return Stdev_Value_; }
            set
            {
                Stdev_Value_ = value;
                NotifyPropertyChanged("Stdev_Value");
            }
        }

        private string Stdev_Mean_ = "null";
        public string Stdev_Mean
        {
            get { return Stdev_Mean_; }
            set
            {
                Stdev_Mean_ = value;
                NotifyPropertyChanged("Stdev_Mean");
            }
        }

        private string Stdev_Min_ = "null";
        public string Stdev_Min
        {
            get { return Stdev_Min_; }
            set
            {
                Stdev_Min_ = value;
                NotifyPropertyChanged("Stdev_Min");
            }
        }

        private string Stdev_Max_ = "null";
        public string Stdev_Max
        {
            get { return Stdev_Max_; }
            set
            {
                Stdev_Max_ = value;
                NotifyPropertyChanged("Stdev_Max");
            }
        }

        private string Stdev_Stdev_ = "null";
        public string Stdev_Stdev
        {
            get { return Stdev_Stdev_; }
            set
            {
                Stdev_Stdev_ = value;
                NotifyPropertyChanged("Stdev_Stdev");
            }
        }

        private string Stdev_Count_ = "null";
        public string Stdev_Count
        {
            get { return Stdev_Count_; }
            set
            {
                Stdev_Count_ = value;
                NotifyPropertyChanged("Stdev_Count");
            }
        }
    }
}
