using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Color_Graded_FFT
{
    public partial class Color_Graded_FFT_Plotter : INotifyPropertyChanged
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

        private bool _Apply_Interpolation = false;
        public bool Apply_Interpolation
        {
            get { return _Apply_Interpolation; }
            set
            {
                if (value == true)
                {
                    Reinitialize_FFT_Hitmap = true;
                }
                else
                {
                    Data_Points = 0;
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
                Reinitialize_FFT_Hitmap = true;
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
                Data_Points = 0;
                NotifyPropertyChanged("FFT_Average_IsEnabled");
            }
        }

        private bool Decay_Interval_Enable_ = false;
        public bool Decay_Interval_Enable
        {
            get { return Decay_Interval_Enable_; }
            set
            {
                if (value)
                {
                    Start_Decay_Interval();
                }
                else
                {
                    Stop_Decay_Interval();
                }
                Decay_Interval_Enable_ = value;
                NotifyPropertyChanged("Decay_Interval_Enable");
            }
        }

        private double Decay_Interval_Value_s_ = 1;
        public double Decay_Interval_Value_s
        {
            get { return Decay_Interval_Value_s_; }
            set
            {
                if (value < 0.01)
                {
                    Decay_Interval_Value_s_ = 0.01;
                }
                else
                {
                    Decay_Interval_Value_s_ = value;
                }
                NotifyPropertyChanged("Decay_Interval_Value_s");
            }
        }

        private double Decay_Factor_ = 0.72;
        public double Decay_Factor
        {
            get { return Decay_Factor_; }
            set
            {
                if (value <= 0.01)
                {
                    Decay_Factor_ = 0.01;
                }
                else if (value >= 1)
                {
                    Decay_Factor_ = 1;
                }
                else
                {
                    Decay_Factor_ = value;
                }
                NotifyPropertyChanged("Decay_Factor");
            }
        }


        private bool Allow_Null_FFT_HitMap_Value_below_ = false;
        public bool Allow_Null_FFT_HitMap_Value_below
        {
            get { return Allow_Null_FFT_HitMap_Value_below_; }
            set
            {
                Allow_Null_FFT_HitMap_Value_below_ = value;
                NotifyPropertyChanged("Allow_Null_FFT_HitMap_Value_below");
            }
        }

        private double Null_FFT_HitMap_Value_below_ = 0.01;
        public double Null_FFT_HitMap_Value_below
        {
            get { return Null_FFT_HitMap_Value_below_; }
            set
            {
                if (value <= 0.0001)
                {
                    Null_FFT_HitMap_Value_below_ = 0.0001;
                }
                else
                {
                    Null_FFT_HitMap_Value_below_ = value;
                }
                NotifyPropertyChanged("Null_FFT_HitMap_Value_below");
            }
        }

        private int _Theme_HeatMap_SelectedIndex = 30;
        public int Theme_HeatMap_SelectedIndex
        {
            get { return _Theme_HeatMap_SelectedIndex; }
            set
            {
                _Theme_HeatMap_SelectedIndex = value;
                NotifyPropertyChanged();
            }
        }

        private double FFT_Maximum_Frequency_ = 0;
        public double FFT_Maximum_Frequency
        {
            get { return FFT_Maximum_Frequency_; }
            set
            {
                FFT_Maximum_Frequency_ = value;
                NotifyPropertyChanged("FFT_Maximum_Frequency");
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

        private int FFT_Maximum_Hitmap_Columns_ = 100;
        public int FFT_Maximum_Hitmap_Columns
        {
            get { return FFT_Maximum_Hitmap_Columns_; }
            set
            {
                FFT_Maximum_Hitmap_Columns_ = value;
                NotifyPropertyChanged("FFT_Maximum_Hitmap_Columns");
            }
        }

        private bool Allow_Custom_FFT_Maximum_Magnitude_Value_ = false;
        public bool Allow_Custom_FFT_Maximum_Magnitude_Value
        {
            get { return Allow_Custom_FFT_Maximum_Magnitude_Value_; }
            set
            {
                Allow_Custom_FFT_Maximum_Magnitude_Value_ = value;
                NotifyPropertyChanged("Allow_Custom_FFT_Maximum_Magnitude_Value");
            }
        }

        private double FFT_Maximum_Magnitude_Value_ = 10;
        public double FFT_Maximum_Magnitude_Value
        {
            get { return FFT_Maximum_Magnitude_Value_; }
            set
            {
                FFT_Maximum_Magnitude_Value_ = value;
                NotifyPropertyChanged("FFT_Maximum_Magnitude_Value");
            }
        }

        private bool Allow_Custom_FFT_Minimum_Magnitude_Value_ = false;
        public bool Allow_Custom_FFT_Minimum_Magnitude_Value
        {
            get { return Allow_Custom_FFT_Minimum_Magnitude_Value_; }
            set
            {
                Allow_Custom_FFT_Minimum_Magnitude_Value_ = value;
                NotifyPropertyChanged("Allow_Custom_FFT_Minimum_Magnitude_Value");
            }
        }

        private double FFT_Minimum_Magnitude_Value_ = -110;
        public double FFT_Minimum_Magnitude_Value
        {
            get { return FFT_Minimum_Magnitude_Value_; }
            set
            {
                FFT_Minimum_Magnitude_Value_ = value;
                NotifyPropertyChanged("FFT_Minimum_Magnitude_Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
