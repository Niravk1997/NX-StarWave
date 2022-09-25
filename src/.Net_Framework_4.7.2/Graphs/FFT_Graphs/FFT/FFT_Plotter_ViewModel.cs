using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FFT
{
    public partial class FFT_Plotter : INotifyPropertyChanged
    {
        private string _Window_Title;
        public string Window_Title
        {
            get { return _Window_Title; }
            set
            {
                _Window_Title = value;
                NotifyPropertyChanged();
            }
        }

        private string dB_Select_Menu_Header_ = "dBV rms";
        public string dB_Select_Menu_Header
        {
            get { return dB_Select_Menu_Header_; }
            set
            {
                dB_Select_Menu_Header_ = value;
                NotifyPropertyChanged();
            }
        }

        private string Linear_Select_Menu_Header_ = "Linear Vrms";
        public string Linear_Select_Menu_Header
        {
            get { return Linear_Select_Menu_Header_; }
            set
            {
                Linear_Select_Menu_Header_ = value;
                NotifyPropertyChanged();
            }
        }

        private bool _Calculate_Phase = false;
        public bool Calculate_Phase
        {
            get { return _Calculate_Phase; }
            set
            {
                _Calculate_Phase = value;
                NotifyPropertyChanged();
            }
        }

        private bool _Show_Peak_Feature = false;
        public bool Show_Peak_Feature
        {
            get { return _Show_Peak_Feature; }
            set
            {
                _Show_Peak_Feature = value;
                if (value)
                {
                    Initialize_Peaks_Reference_Level();
                }
                else
                {
                    Clear_Peaks_Reference_Level();
                }
                NotifyPropertyChanged();
            }
        }

        private bool _Show_Peak_Reference_Level = true;
        public bool Show_Peak_Reference_Level
        {
            get { return _Show_Peak_Reference_Level; }
            set
            {
                _Show_Peak_Reference_Level = value;
                Peaks_Reference_Level_Visibility();
                NotifyPropertyChanged();
            }
        }

        private double _Peak_Reference_Level = -50.0;
        public double Peak_Reference_Level
        {
            get { return _Peak_Reference_Level; }
            set
            {
                _Peak_Reference_Level = Math.Round(value, 5);
                if (Peak_Reference_Level_Marker != null)
                {
                    Peak_Reference_Level_Marker.Y = value;
                }
                NotifyPropertyChanged();
            }
        }

        private int _Peak_Window_Size = 2;
        public int Peak_Window_Size
        {
            get { return _Peak_Window_Size; }
            set
            {
                if (value >= 2)
                {
                    _Peak_Window_Size = value;
                }
                NotifyPropertyChanged();
            }
        }

        private bool _Apply_Interpolation = false;
        public bool Apply_Interpolation
        {
            get { return _Apply_Interpolation; }
            set
            {
                if (value == false) 
                {
                    Interpolation_isDisabled = true;
                }
                _Apply_Interpolation = value;
                NotifyPropertyChanged();
            }
        }

        private int _Interpolation_Resample_Factor = 2;
        public int Interpolation_Resample_Factor
        {
            get { return _Interpolation_Resample_Factor; }
            set
            {
                _Interpolation_Resample_Factor = value;
                NotifyPropertyChanged();
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

        private double Peak_Plot_Labels_Coordinates_X_ = -5;
        public double Peak_Plot_Labels_Coordinates_X
        {
            get { return Peak_Plot_Labels_Coordinates_X_; }
            set
            {
                Peak_Plot_Labels_Coordinates_X_ = value;
                Update_Peaks_Label_X_Coordiniates(value);
                NotifyPropertyChanged("Peak_Plot_Labels_Coordinates_X");
            }
        }

        private int _FFT_Average_Value = 10;
        public int FFT_Average_Value
        {
            get { return _FFT_Average_Value; }
            set
            {
                _FFT_Average_Value = value;
                NotifyPropertyChanged("FFT_Average_Value");
            }
        }

        private bool _FFT_Average_IsEnabled = false;
        public bool FFT_Average_IsEnabled
        {
            get { return _FFT_Average_IsEnabled; }
            set
            {
                _FFT_Average_IsEnabled = value;
                if (value == false)
                {
                    FFT_Average.Reset();
                }
                NotifyPropertyChanged("FFT_Average_IsEnabled");
            }
        }

        private int FFT_Size_ = 250;
        public int FFT_Size
        {
            get { return FFT_Size_; }
            set
            {
                if (FFT_Size_ != value)
                {
                    FFT_Size_ = value;
                    FFT_Size_String = Axis_Scale_Config.Value_SI_Prefix(value, 1) + "pts";
                    NotifyPropertyChanged("FFT_Size");
                }
            }
        }

        private string FFT_Size_String_ = "null";
        public string FFT_Size_String
        {
            get { return FFT_Size_String_; }
            set
            {
                FFT_Size_String_ = value;
                NotifyPropertyChanged("FFT_Size_String");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
