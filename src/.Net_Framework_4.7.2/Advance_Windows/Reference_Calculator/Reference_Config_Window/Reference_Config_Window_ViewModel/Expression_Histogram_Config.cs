using System.ComponentModel;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : INotifyPropertyChanged
    {
        private bool _Show_Histogram = false;
        public bool Show_Histogram
        {
            get { return _Show_Histogram; }
            set
            {
                _Show_Histogram = value;
                NotifyPropertyChanged();
            }
        }

        private int _Histogram_Buckets = 50;
        public int Histogram_Buckets
        {
            get { return _Histogram_Buckets; }
            set
            {
                if (value > 0)
                {
                    _Histogram_Buckets = value;
                }
                else
                {
                    _Histogram_Buckets = 50;
                }
                NotifyPropertyChanged();
            }
        }

        private string _Histogram_Color = "#FF0072BD";
        public string Histogram_Color
        {
            get { return _Histogram_Color; }
            set
            {
                _Histogram_Color = value;
                NotifyPropertyChanged();
            }
        }

        private bool _Histogram_Continuous = false;
        public bool Histogram_Continuous
        {
            get { return _Histogram_Continuous; }
            set
            {
                _Histogram_Continuous = value;
                NotifyPropertyChanged();
            }
        }
    }
}
