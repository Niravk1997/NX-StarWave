using System.ComponentModel;
using System.Windows.Media;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : INotifyPropertyChanged
    {
        private string _Reference_5_Channel_Info = "null";
        public string Reference_5_Channel_Info
        {
            get
            {
                return _Reference_5_Channel_Info;
            }
            set
            {
                _Reference_5_Channel_Info = value;
                NotifyPropertyChanged("Reference_5_Channel_Info");
            }
        }

        private int _Reference_5_Data_Points = 0;
        public int Reference_5_Data_Points
        {
            get
            {
                return _Reference_5_Data_Points;
            }
            set
            {
                _Reference_5_Data_Points = value;
                NotifyPropertyChanged("Reference_5_Data_Points");
            }
        }

        private string _Reference_5_Total_Time_SI_Units = "null";
        public string Reference_5_Total_Time_SI_Units
        {
            get
            {
                return _Reference_5_Total_Time_SI_Units;
            }
            set
            {
                _Reference_5_Total_Time_SI_Units = value;
                NotifyPropertyChanged("Reference_5_Total_Time_SI_Units");
            }
        }
        private double _Reference_5_Total_Time = 0;
        public double Reference_5_Total_Time
        {
            get
            {
                return _Reference_5_Total_Time;
            }
            set
            {
                _Reference_5_Total_Time = value;
                Reference_5_Total_Time_SI_Units = Axis_Scale_Config.Value_SI_Prefix(value, 4) + "s";
                NotifyPropertyChanged();
            }
        }

        private string _Reference_5_Start_Time_SI_Units = "null";
        public string Reference_5_Start_Time_SI_Units
        {
            get
            {
                return _Reference_5_Start_Time_SI_Units;
            }
            set
            {
                _Reference_5_Start_Time_SI_Units = value;
                NotifyPropertyChanged("Reference_5_Start_Time_SI_Units");
            }
        }
        private double _Reference_5_Start_Time = 0;
        public double Reference_5_Start_Time
        {
            get
            {
                return _Reference_5_Start_Time;
            }
            set
            {
                _Reference_5_Start_Time = value;
                Reference_5_Start_Time_SI_Units = Axis_Scale_Config.Value_SI_Prefix(value, 4) + "s";
                NotifyPropertyChanged("Reference_5_Start_Time_SI_Units");
            }
        }

        private string _Reference_5_Stop_Time_SI_Units = "null";
        public string Reference_5_Stop_Time_SI_Units
        {
            get
            {
                return _Reference_5_Stop_Time_SI_Units;
            }
            set
            {
                _Reference_5_Stop_Time_SI_Units = value;
                NotifyPropertyChanged("Reference_5_Stop_Time_SI_Units");
            }
        }
        private double _Reference_5_Stop_Time = 0;
        public double Reference_5_Stop_Time
        {
            get
            {
                return _Reference_5_Stop_Time;
            }
            set
            {
                _Reference_5_Stop_Time = value;
                Reference_5_Stop_Time_SI_Units = Axis_Scale_Config.Value_SI_Prefix(value, 4) + "s";
                NotifyPropertyChanged("Reference_5_Stop_Time_SI_Units");
            }
        }

        private bool _Reference_5_Valid = false;
        public bool Reference_5_Valid
        {
            get
            {
                return _Reference_5_Valid;
            }
            set
            {
                _Reference_5_Valid = value;
                NotifyPropertyChanged("Reference_5_Valid");
            }
        }

        private Brush _Reference_5_Status = Brushes.White;
        public Brush Reference_5_Status
        {
            get
            {
                return _Reference_5_Status;
            }
            set
            {
                _Reference_5_Status = value;
                NotifyPropertyChanged("Reference_5_Status");
            }
        }
    }
}
