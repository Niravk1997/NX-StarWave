using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Channel_DataLogger
{
    public partial class CH_DataLog_Graph_Window : INotifyPropertyChanged
    {
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
