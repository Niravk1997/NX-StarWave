using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AllChannels_YT
{
    public partial class AllChannels_YT_Plotter : INotifyPropertyChanged
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

        private string Draw_Mode_Custom_Selected_Color_ = "#ff8c00";
        public string Draw_Mode_Custom_Selected_Color
        {
            get { return Draw_Mode_Custom_Selected_Color_; }
            set
            {
                Draw_Mode_Custom_Selected_Color_ = value;
                Draw_Mode_Tool_Tip_Custom_Color_Set(value);
                NotifyPropertyChanged("Draw_Mode_Custom_Selected_Color");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
