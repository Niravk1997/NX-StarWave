using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AllChannels_YT_Square
{
    public partial class AllChannels_YT_Square_Plotter : INotifyPropertyChanged
    {
        private String _Window_Title;
        public String Window_Title
        {
            get { return _Window_Title; }
            set
            {
                _Window_Title = value;
                NotifyPropertyChanged();
            }
        }

        private bool _Match_Axis = true;
        public bool Match_Axis
        {
            get { return _Match_Axis; }
            set
            {
                _Match_Axis = value;
                NotifyPropertyChanged();
            }
        }

        private string _Frequency_CH1 = "0";
        public string Frequency_CH1
        {
            get { return _Frequency_CH1; }
            set { _Frequency_CH1 = value; NotifyPropertyChanged("Frequency_CH1"); }
        }

        private string _Frequency_CH2 = "0";
        public string Frequency_CH2
        {
            get { return _Frequency_CH2; }
            set { _Frequency_CH2 = value; NotifyPropertyChanged("Frequency_CH2"); }
        }

        private string _Frequency_CH3 = "0";
        public string Frequency_CH3
        {
            get { return _Frequency_CH3; }
            set { _Frequency_CH3 = value; NotifyPropertyChanged("Frequency_CH3"); }
        }

        private string _Frequency_CH4 = "0";
        public string Frequency_CH4
        {
            get { return _Frequency_CH4; }
            set { _Frequency_CH4 = value; NotifyPropertyChanged("Frequency_CH4"); }
        }

        private string _Period_CH1 = "0";
        public string Period_CH1
        {
            get { return _Period_CH1; }
            set { _Period_CH1 = value; NotifyPropertyChanged("Period_CH1"); }
        }

        private string _Period_CH2 = "0";
        public string Period_CH2
        {
            get { return _Period_CH2; }
            set { _Period_CH2 = value; NotifyPropertyChanged("Period_CH2"); }
        }

        private string _Period_CH3 = "0";
        public string Period_CH3
        {
            get { return _Period_CH3; }
            set { _Period_CH3 = value; NotifyPropertyChanged("Period_CH3"); }
        }

        private string _Period_CH4 = "0";
        public string Period_CH4
        {
            get { return _Period_CH4; }
            set { _Period_CH4 = value; NotifyPropertyChanged("Period_CH4"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
