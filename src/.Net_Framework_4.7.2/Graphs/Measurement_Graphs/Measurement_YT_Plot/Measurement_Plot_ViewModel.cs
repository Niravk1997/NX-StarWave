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

        private bool Axis_Auto_ = true;
        public bool Axis_Auto
        {
            get { return Axis_Auto_; }
            set
            {
                Axis_Auto_ = value;
                NotifyPropertyChanged("Axis_Auto");
            }
        }

        private bool Vertical_Markers_Active_ = false;
        public bool Vertical_Markers_Active
        {
            get { return Vertical_Markers_Active_; }
            set
            {
                Vertical_Markers_Active_ = value;
                NotifyPropertyChanged("Vertical_Markers_Active");
            }
        }

        private bool Horizontal_Markers_Active_ = false;
        public bool Horizontal_Markers_Active
        {
            get { return Horizontal_Markers_Active_; }
            set
            {
                Horizontal_Markers_Active_ = value;
                NotifyPropertyChanged("Horizontal_Markers_Active");
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

        private int Positive_Samples_ = 0;
        public int Positive_Samples
        {
            get { return Positive_Samples_; }
            set
            {
                Positive_Samples_ = value;
                NotifyPropertyChanged("Positive_Samples");
            }
        }

        private int Negative_Samples_ = 0;
        public int Negative_Samples
        {
            get { return Negative_Samples_; }
            set
            {
                Negative_Samples_ = value;
                NotifyPropertyChanged("Negative_Samples");
            }
        }

        private string Moving_Average_String_ = "null";
        public string Moving_Average_String
        {
            get { return Moving_Average_String_; }
            set
            {
                Moving_Average_String_ = value;
                NotifyPropertyChanged("Moving_Average_String");
            }
        }

        private double Moving_Average_ = 0;
        public double Moving_Average
        {
            get { return Moving_Average_; }
            set
            {
                Moving_Average_ = value;
                Moving_Average_String = Axis_Scale_Config.Value_SI_Prefix(value, Measurement_Round_Value) + Measurement_Unit;
                NotifyPropertyChanged("Moving_Average");
            }
        }

        private string Max_Recorded_Sample_String_ = "null";
        public string Max_Recorded_Sample_String
        {
            get { return Max_Recorded_Sample_String_; }
            set
            {
                Max_Recorded_Sample_String_ = value;
                NotifyPropertyChanged("Max_Recorded_Sample_String");
            }
        }

        private double Max_Recorded_Sample_ = 0;
        public double Max_Recorded_Sample
        {
            get { return Max_Recorded_Sample_; }
            set
            {
                Max_Recorded_Sample_ = value;
                Max_Recorded_Sample_String = Axis_Scale_Config.Value_SI_Prefix(value, Measurement_Round_Value) + Measurement_Unit;
                NotifyPropertyChanged("Max_Recorded_Sample");
            }
        }

        private string Min_Recorded_Sample_String_ = "null";
        public string Min_Recorded_Sample_String
        {
            get { return Min_Recorded_Sample_String_; }
            set
            {
                Min_Recorded_Sample_String_ = value;
                NotifyPropertyChanged("Min_Recorded_Sample_String");
            }
        }

        private double Min_Recorded_Sample_ = 0;
        public double Min_Recorded_Sample
        {
            get { return Min_Recorded_Sample_; }
            set
            {
                Min_Recorded_Sample_ = value;
                Min_Recorded_Sample_String = Axis_Scale_Config.Value_SI_Prefix(value, Measurement_Round_Value) + Measurement_Unit;
                NotifyPropertyChanged("Min_Recorded_Sample");
            }
        }

        private string Vertical_Marker_Start_String_ = "null";
        public string Vertical_Marker_Start_String
        {
            get { return Vertical_Marker_Start_String_; }
            set
            {
                Vertical_Marker_Start_String_ = value;
                NotifyPropertyChanged("Vertical_Marker_Start_String");
            }
        }

        private double Vertical_Marker_Start_Value_;
        public double Vertical_Marker_Start_Value
        {
            get { return Vertical_Marker_Start_Value_; }
            set
            {
                Vertical_Marker_Start_Value_ = value;
                NotifyPropertyChanged("Vertical_Marker_Start_Value_");
            }
        }

        private string Vertical_Marker_Stop_String_ = "null";
        public string Vertical_Marker_Stop_String
        {
            get { return Vertical_Marker_Stop_String_; }
            set
            {
                Vertical_Marker_Stop_String_ = value;
                NotifyPropertyChanged("Vertical_Marker_Stop_String");
            }
        }

        private double Vertical_Marker_Stop_Value_;
        public double Vertical_Marker_Stop_Value
        {
            get { return Vertical_Marker_Stop_Value_; }
            set
            {
                Vertical_Marker_Stop_Value_ = value;
                NotifyPropertyChanged("Vertical_Marker_Stop_Value");
            }
        }

        private bool _Zoom_Control_Window_MenuItem_IsEnabled = false;
        public bool Zoom_Control_Window_MenuItem_IsEnabled
        {
            get { return _Zoom_Control_Window_MenuItem_IsEnabled; }
            set
            {
                _Zoom_Control_Window_MenuItem_IsEnabled = value;
                NotifyPropertyChanged("Zoom_Control_Window_MenuItem_IsEnabled");
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
