using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XY
{
    public partial class XY_Plotter : INotifyPropertyChanged
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
