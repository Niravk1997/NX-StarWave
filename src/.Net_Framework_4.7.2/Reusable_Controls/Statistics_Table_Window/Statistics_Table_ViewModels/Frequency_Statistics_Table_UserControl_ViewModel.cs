using System.ComponentModel;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : INotifyPropertyChanged
    {
        private string Frequency_Value_ = "null";
        public string Frequency_Value
        {
            get { return Frequency_Value_; }
            set
            {
                Frequency_Value_ = value;
                NotifyPropertyChanged("Frequency_Value");
            }
        }

        private string Frequency_Mean_ = "null";
        public string Frequency_Mean
        {
            get { return Frequency_Mean_; }
            set
            {
                Frequency_Mean_ = value;
                NotifyPropertyChanged("Frequency_Mean");
            }
        }

        private string Frequency_Min_ = "null";
        public string Frequency_Min
        {
            get { return Frequency_Min_; }
            set
            {
                Frequency_Min_ = value;
                NotifyPropertyChanged("Frequency_Min");
            }
        }

        private string Frequency_Max_ = "null";
        public string Frequency_Max
        {
            get { return Frequency_Max_; }
            set
            {
                Frequency_Max_ = value;
                NotifyPropertyChanged("Frequency_Max");
            }
        }

        private string Frequency_Stdev_ = "null";
        public string Frequency_Stdev
        {
            get { return Frequency_Stdev_; }
            set
            {
                Frequency_Stdev_ = value;
                NotifyPropertyChanged("Frequency_Stdev");
            }
        }

        private string Frequency_Count_ = "null";
        public string Frequency_Count
        {
            get { return Frequency_Count_; }
            set
            {
                Frequency_Count_ = value;
                NotifyPropertyChanged("Frequency_Count");
            }
        }
    }
}
