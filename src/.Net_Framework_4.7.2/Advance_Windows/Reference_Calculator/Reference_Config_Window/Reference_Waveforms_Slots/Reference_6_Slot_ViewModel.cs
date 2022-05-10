using System.ComponentModel;
using System.Windows.Media;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : INotifyPropertyChanged
    {
        private string _Reference_6_Channel_Info = "null";
        public string Reference_6_Channel_Info
        {
            get
            {
                return _Reference_6_Channel_Info;
            }
            set
            {
                _Reference_6_Channel_Info = value;
                NotifyPropertyChanged("Reference_6_Channel_Info");
            }
        }

        private int _Reference_6_Data_Points = 0;
        public int Reference_6_Data_Points
        {
            get
            {
                return _Reference_6_Data_Points;
            }
            set
            {
                _Reference_6_Data_Points = value;
                NotifyPropertyChanged("Reference_6_Data_Points");
            }
        }

        private string _Reference_6_Total_Time_SI_Units = "null";
        public string Reference_6_Total_Time_SI_Units
        {
            get
            {
                return _Reference_6_Total_Time_SI_Units;
            }
            set
            {
                _Reference_6_Total_Time_SI_Units = value;
                NotifyPropertyChanged("Reference_6_Total_Time_SI_Units");
            }
        }
        private double _Reference_6_Total_Time = 0;
        public double Reference_6_Total_Time
        {
            get
            {
                return _Reference_6_Total_Time;
            }
            set
            {
                _Reference_6_Total_Time = value;
                Reference_6_Total_Time_SI_Units = Axis_Scale_Config.Value_SI_Prefix(value, 4) + "s";
                NotifyPropertyChanged();
            }
        }

        private string _Reference_6_Start_Time_SI_Units = "null";
        public string Reference_6_Start_Time_SI_Units
        {
            get
            {
                return _Reference_6_Start_Time_SI_Units;
            }
            set
            {
                _Reference_6_Start_Time_SI_Units = value;
                NotifyPropertyChanged("Reference_6_Start_Time_SI_Units");
            }
        }
        private double _Reference_6_Start_Time = 0;
        public double Reference_6_Start_Time
        {
            get
            {
                return _Reference_6_Start_Time;
            }
            set
            {
                _Reference_6_Start_Time = value;
                Reference_6_Start_Time_SI_Units = Axis_Scale_Config.Value_SI_Prefix(value, 4) + "s";
                NotifyPropertyChanged("Reference_6_Start_Time_SI_Units");
            }
        }

        private string _Reference_6_Stop_Time_SI_Units = "null";
        public string Reference_6_Stop_Time_SI_Units
        {
            get
            {
                return _Reference_6_Stop_Time_SI_Units;
            }
            set
            {
                _Reference_6_Stop_Time_SI_Units = value;
                NotifyPropertyChanged("Reference_6_Stop_Time_SI_Units");
            }
        }
        private double _Reference_6_Stop_Time = 0;
        public double Reference_6_Stop_Time
        {
            get
            {
                return _Reference_6_Stop_Time;
            }
            set
            {
                _Reference_6_Stop_Time = value;
                Reference_6_Stop_Time_SI_Units = Axis_Scale_Config.Value_SI_Prefix(value, 4) + "s";
                NotifyPropertyChanged("Reference_6_Stop_Time_SI_Units");
            }
        }

        private bool _Reference_6_Valid = false;
        public bool Reference_6_Valid
        {
            get
            {
                return _Reference_6_Valid;
            }
            set
            {
                _Reference_6_Valid = value;
                NotifyPropertyChanged("Reference_6_Valid");
            }
        }

        private Brush _Reference_6_Status = Brushes.White;
        public Brush Reference_6_Status
        {
            get
            {
                return _Reference_6_Status;
            }
            set
            {
                _Reference_6_Status = value;
                NotifyPropertyChanged("Reference_6_Status");
            }
        }
    }
}
