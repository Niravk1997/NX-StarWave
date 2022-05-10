using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YT
{
    public partial class YT_Plotter : INotifyPropertyChanged
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

        private bool _Apply_Interpolation = false;
        public bool Apply_Interpolation
        {
            get { return _Apply_Interpolation; }
            set
            {
                _Apply_Interpolation = value;
                NotifyPropertyChanged("Apply_Interpolation");
            }
        }

        private int _Interpolation_Resample_Factor = 2;
        public int Interpolation_Resample_Factor
        {
            get { return _Interpolation_Resample_Factor; }
            set
            {
                _Interpolation_Resample_Factor = value;
                NotifyPropertyChanged("Interpolation_Resample_Factor");
            }
        }

        private string _Total_Time_Label = "null";
        public string Total_Time_Label
        {
            get { return _Total_Time_Label; }
            set
            {
                _Total_Time_Label = value;
                NotifyPropertyChanged("Total_Time_Label");
            }
        }

        private string _Start_Time_Label = "null";
        public string Start_Time_Label
        {
            get { return _Start_Time_Label; }
            set
            {
                _Start_Time_Label = value;
                NotifyPropertyChanged("Start_Time_Label");
            }
        }

        private string _Stop_Time_Label = "null";
        public string Stop_Time_Label
        {
            get { return _Stop_Time_Label; }
            set
            {
                _Stop_Time_Label = value;
                NotifyPropertyChanged("Stop_Time_Label");
            }
        }

        private double _Data_Points_Label = 0;
        public double Data_Points_Label
        {
            get { return _Data_Points_Label; }
            set
            {
                _Data_Points_Label = value;
                NotifyPropertyChanged("Data_Points_Label");
            }
        }

        private string _Channel_Info_Label = "null";
        public string Channel_Info_Label
        {
            get { return _Channel_Info_Label; }
            set
            {
                _Channel_Info_Label = value;
                NotifyPropertyChanged("Channel_Info_Label");
            }
        }

        private string _Frequency_Label = "null";
        public string Frequency_Label
        {
            get { return _Frequency_Label; }
            set
            {
                _Frequency_Label = value;
                NotifyPropertyChanged("Frequency_Label");
            }
        }

        private string _Period_Label = "null";
        public string Period_Label
        {
            get { return _Period_Label; }
            set
            {
                _Period_Label = value;
                NotifyPropertyChanged("Period_Label");
            }
        }

        private string _PKPK_Label = "null";
        public string PKPK_Label
        {
            get { return _PKPK_Label; }
            set
            {
                _PKPK_Label = value;
                NotifyPropertyChanged("PKPK_Label");
            }
        }

        private string _Mean_Label = "null";
        public string Mean_Label
        {
            get { return _Mean_Label; }
            set
            {
                _Mean_Label = value;
                NotifyPropertyChanged("Mean_Label");
            }
        }

        private string _RMS_Label = "null";
        public string RMS_Label
        {
            get { return _RMS_Label; }
            set
            {
                _RMS_Label = value;
                NotifyPropertyChanged("RMS_Label");
            }
        }

        private string _Max_Label = "null";
        public string Max_Label
        {
            get { return _Max_Label; }
            set
            {
                _Max_Label = value;
                NotifyPropertyChanged("Max_Label");
            }
        }

        private string _Min_Label = "null";
        public string Min_Label
        {
            get { return _Min_Label; }
            set
            {
                _Min_Label = value;
                NotifyPropertyChanged("Min_Label");
            }
        }

        private int _FFT_Interpolation_Factor = 2;
        public int FFT_Interpolation_Factor
        {
            get { return _FFT_Interpolation_Factor; }
            set
            {
                _FFT_Interpolation_Factor = value;
                NotifyPropertyChanged("FFT_Interpolation_Factor");
            }
        }

        private int _FFT_Interpolation_Type_Selected = 1;
        public int FFT_Interpolation_Type_Selected
        {
            get { return _FFT_Interpolation_Type_Selected; }
            set
            {
                _FFT_Interpolation_Type_Selected = value;
                NotifyPropertyChanged("FFT_Interpolation_Type_Selected");
            }
        }

        private bool _Persistence_Effect_IsEnabled = false;
        public bool Persistence_Effect_IsEnabled
        {
            get { return _Persistence_Effect_IsEnabled; }
            set
            {
                _Persistence_Effect_IsEnabled = value;
                NotifyPropertyChanged("Persistence_Effect_IsEnabled");
            }
        }

        private int _Visible_Persistence_Waveforms = 5;
        public int Visible_Persistence_Waveforms
        {
            get { return _Visible_Persistence_Waveforms; }
            set
            {
                _Visible_Persistence_Waveforms = value;
                Persistence_Waveforms_Visible(value);
                NotifyPropertyChanged("Visible_Persistence_Waveforms");
            }
        }

        private int _Persistence_Color_SelectedType = 0;
        public int Persistence_Color_SelectedType
        {
            get { return _Persistence_Color_SelectedType; }
            set
            {
                _Persistence_Color_SelectedType = value;
                Set_Persistence_Color();
                NotifyPropertyChanged("Persistence_Color_SelectedType");
            }
        }

        private string _Persistence_Color = "";
        public string Persistence_Color
        {
            get { return _Persistence_Color; }
            set
            {
                _Persistence_Color = value;
                Set_Persistence_Color();
                NotifyPropertyChanged("Persistence_Color");
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

        private int _Waveform_Average_Value = 10;
        public int Waveform_Average_Value
        {
            get { return _Waveform_Average_Value; }
            set
            {
                _Waveform_Average_Value = value;
                NotifyPropertyChanged("Waveform_Average_Value");
            }
        }

        private bool _Waveform_Average_IsEnabled = false;
        public bool Waveform_Average_IsEnabled
        {
            get { return _Waveform_Average_IsEnabled; }
            set
            {
                _Waveform_Average_IsEnabled = value;
                if (value == false)
                {
                    Waveform_Average.Reset();
                }
                NotifyPropertyChanged("Waveform_Average_IsEnabled");
            }
        }

        private int Gated_Peaks_Window_Size_ = 2;
        public int Gated_Peaks_Window_Size
        {
            get { return Gated_Peaks_Window_Size_; }
            set
            {
                Gated_Peaks_Window_Size_ = value;
                NotifyPropertyChanged("Gated_Peaks_Window_Size");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
