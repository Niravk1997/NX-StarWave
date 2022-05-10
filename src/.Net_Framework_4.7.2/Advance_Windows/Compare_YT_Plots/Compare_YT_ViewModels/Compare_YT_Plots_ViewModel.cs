using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Compare_YT
{
    public partial class Compare_YT_Plots : INotifyPropertyChanged
    {
        private int Tab_Item_SelectedIndex_ = 0;
        public int Tab_Item_SelectedIndex
        {
            get { return Tab_Item_SelectedIndex_; }
            set
            {
                Tab_Item_SelectedIndex_ = value;
                NotifyPropertyChanged("Tab_Item_SelectedIndex");
            }
        }

        private string _Channel_Info = "null";
        public string Channel_Info
        {
            get
            {
                return _Channel_Info;
            }
            set
            {
                _Channel_Info = value;
                NotifyPropertyChanged("Channel_Info");
            }
        }

        private int _Data_Points = 0;
        public int Data_Points
        {
            get
            {
                return _Data_Points;
            }
            set
            {
                _Data_Points = value;
                NotifyPropertyChanged("Data_Points");
            }
        }

        private string _Total_Time_SI_Units = "null";
        public string Total_Time_SI_Units
        {
            get
            {
                return _Total_Time_SI_Units;
            }
            set
            {
                _Total_Time_SI_Units = value;
                NotifyPropertyChanged("Total_Time_SI_Units");
            }
        }
        private double _Total_Time = 0;
        public double Total_Time
        {
            get
            {
                return _Total_Time;
            }
            set
            {
                _Total_Time = value;
                Total_Time_SI_Units = Axis_Scale_Config.Value_SI_Prefix(value, 4) + "s";
                NotifyPropertyChanged();
            }
        }

        private string _Start_Time_SI_Units = "null";
        public string Start_Time_SI_Units
        {
            get
            {
                return _Start_Time_SI_Units;
            }
            set
            {
                _Start_Time_SI_Units = value;
                NotifyPropertyChanged("Start_Time_SI_Units");
            }
        }
        private double _Start_Time = 0;
        public double Start_Time
        {
            get
            {
                return _Start_Time;
            }
            set
            {
                _Start_Time = value;
                Start_Time_SI_Units = Axis_Scale_Config.Value_SI_Prefix(value, 4) + "s";
                NotifyPropertyChanged("Start_Time_SI_Units");
            }
        }

        private string _Stop_Time_SI_Units = "null";
        public string Stop_Time_SI_Units
        {
            get
            {
                return _Stop_Time_SI_Units;
            }
            set
            {
                _Stop_Time_SI_Units = value;
                NotifyPropertyChanged("Stop_Time_SI_Units");
            }
        }
        private double _Stop_Time = 0;
        public double Stop_Time
        {
            get
            {
                return _Stop_Time;
            }
            set
            {
                _Stop_Time = value;
                Stop_Time_SI_Units = Axis_Scale_Config.Value_SI_Prefix(value, 4) + "s";
                NotifyPropertyChanged("Stop_Time_SI_Units");
            }
        }

        private string _Waveform_Color = "#FF0072BD";
        public string Waveform_Color
        {
            get { return _Waveform_Color; }
            set
            {
                _Waveform_Color = value;
                NotifyPropertyChanged("Waveform_Color");
            }
        }

        private string Measurement_Unit_ = "V";
        public string Measurement_Unit
        {
            get { return Measurement_Unit_; }
            set
            {
                Measurement_Unit_ = value;
                Axis_Scale_Config.Y_Axis_Units = value;
                NotifyPropertyChanged("Measurement_Unit");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
