using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : INotifyPropertyChanged
    {
        private string _Window_Title;
        public string Window_Title
        {
            get { return _Window_Title; }
            set
            {
                _Window_Title = value;
                NotifyPropertyChanged("Window_Title");
            }
        }

        private int Measurement_Data_Count_ = 0;
        public int Measurement_Data_Count
        {
            get { return Measurement_Data_Count_; }
            set
            {
                Measurement_Data_Count_ = value;
                NotifyPropertyChanged("Measurement_Data_Count");
            }
        }

        private string Measurement_Min_String_ = "null";
        public string Measurement_Min_String
        {
            get { return Measurement_Min_String_; }
            set
            {
                Measurement_Min_String_ = value;
                NotifyPropertyChanged("Measurement_Min_String");
            }
        }

        private double Measurement_Min_ = double.MaxValue;
        public double Measurement_Min
        {
            get { return Measurement_Min_; }
            set
            {
                Measurement_Min_ = value;
                Measurement_Min_String = Axis_Scale_Config.Value_SI_Prefix(value, Measurement_Round_Value) + Measurement_Unit;
                NotifyPropertyChanged("Measurement_Min");
            }
        }

        private string Measurement_Max_String_ = "null";
        public string Measurement_Max_String
        {
            get { return Measurement_Max_String_; }
            set
            {
                Measurement_Max_String_ = value;
                NotifyPropertyChanged("Measurement_Max_String");
            }
        }

        private double Measurement_Max_ = double.MinValue;
        public double Measurement_Max
        {
            get { return Measurement_Max_; }
            set
            {
                Measurement_Max_ = value;
                Measurement_Max_String = Axis_Scale_Config.Value_SI_Prefix(value, Measurement_Round_Value) + Measurement_Unit;
                NotifyPropertyChanged("Measurement_Max");
            }
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
