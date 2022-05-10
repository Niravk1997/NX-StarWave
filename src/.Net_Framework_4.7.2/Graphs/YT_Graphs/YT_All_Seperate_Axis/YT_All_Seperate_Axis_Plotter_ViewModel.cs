using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace YT_All_Seperate_Axis
{
    public partial class YT_All_Seperate_Axis_Plotter : INotifyPropertyChanged
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

        private string _Frequency_CH1 = "0";
        public string Frequency_CH1
        {
            get { return _Frequency_CH1; }
            set { _Frequency_CH1 = value; NotifyPropertyChanged("Frequency_CH1"); }
        }

        private string _Frequency_CH2 = "0";
        public string Frequency_CH2
        {
            get { return _Frequency_CH2; }
            set { _Frequency_CH2 = value; NotifyPropertyChanged("Frequency_CH2"); }
        }

        private string _Frequency_CH3 = "0";
        public string Frequency_CH3
        {
            get { return _Frequency_CH3; }
            set { _Frequency_CH3 = value; NotifyPropertyChanged("Frequency_CH3"); }
        }

        private string _Frequency_CH4 = "0";
        public string Frequency_CH4
        {
            get { return _Frequency_CH4; }
            set { _Frequency_CH4 = value; NotifyPropertyChanged("Frequency_CH4"); }
        }

        private string _Period_CH1 = "0";
        public string Period_CH1
        {
            get { return _Period_CH1; }
            set { _Period_CH1 = value; NotifyPropertyChanged("Period_CH1"); }
        }

        private string _Period_CH2 = "0";
        public string Period_CH2
        {
            get { return _Period_CH2; }
            set { _Period_CH2 = value; NotifyPropertyChanged("Period_CH2"); }
        }

        private string _Period_CH3 = "0";
        public string Period_CH3
        {
            get { return _Period_CH3; }
            set { _Period_CH3 = value; NotifyPropertyChanged("Period_CH3"); }
        }

        private string _Period_CH4 = "0";
        public string Period_CH4
        {
            get { return _Period_CH4; }
            set { _Period_CH4 = value; NotifyPropertyChanged("Period_CH4"); }
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

        private bool Axis_Lock_CH1_ = false;
        public bool Axis_Lock_CH1
        {
            get { return Axis_Lock_CH1_; }
            set { Axis_Lock_CH1_ = value; NotifyPropertyChanged("Axis_Lock_CH1"); Graph.Plot.YAxis.LockLimits(value); }
        }

        private bool Axis_Lock_CH2_ = false;
        public bool Axis_Lock_CH2
        {
            get { return Axis_Lock_CH2_; }
            set { Axis_Lock_CH2_ = value; NotifyPropertyChanged("Axis_Lock_CH2"); AxisLine_2.LockLimits(value); }
        }

        private bool Axis_Lock_CH3_ = false;
        public bool Axis_Lock_CH3
        {
            get { return Axis_Lock_CH3_; }
            set { Axis_Lock_CH3_ = value; NotifyPropertyChanged("Axis_Lock_CH3"); Graph.Plot.YAxis2.LockLimits(value); }
        }

        private bool Axis_Lock_CH4_ = false;
        public bool Axis_Lock_CH4
        {
            get { return Axis_Lock_CH4_; }
            set { Axis_Lock_CH4_ = value; NotifyPropertyChanged("Axis_Lock_CH4"); AxisLine_3.LockLimits(value); }
        }

        private Brush CH1_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#0072BD");
        public Brush CH1_Color
        {
            get { return CH1_Color_; }
            set { CH1_Color_ = value; NotifyPropertyChanged("CH1_Color"); }
        }

        private Brush CH2_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF8C00");
        public Brush CH2_Color
        {
            get { return CH2_Color_; }
            set { CH2_Color_ = value; NotifyPropertyChanged("CH2_Color"); }
        }

        private Brush CH3_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF1493");
        public Brush CH3_Color
        {
            get { return CH3_Color_; }
            set { CH3_Color_ = value; NotifyPropertyChanged("CH3_Color"); }
        }

        private Brush CH4_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#00b33c");
        public Brush CH4_Color
        {
            get { return CH4_Color_; }
            set { CH4_Color_ = value; NotifyPropertyChanged("CH4_Color"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
