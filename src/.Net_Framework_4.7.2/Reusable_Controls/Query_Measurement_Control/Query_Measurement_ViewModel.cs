using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Query_Measurement_Control
{
    public partial class Query_Measurement_Window : INotifyPropertyChanged
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

        private double Window_Height_ = 100;
        public double Window_Height
        {
            get { return Window_Height_; }
            set
            {
                Window_Height_ = value;
                NotifyPropertyChanged("Window_Height");
            }
        }

        private double Window_Width_ = 320;
        public double Window_Width
        {
            get { return Window_Width_; }
            set
            {
                Window_Width_ = value;
                NotifyPropertyChanged("Window_Width");
            }
        }

        private Brush Label_Foreground_ = new SolidColorBrush(Colors.Black);
        public Brush Label_Foreground
        {
            get { return Label_Foreground_; }
            set
            {
                Label_Foreground_ = value;
                NotifyPropertyChanged("Label_Foreground");
            }
        }

        private Brush Background_Color_ = new SolidColorBrush(Colors.White);
        public Brush Background_Color
        {
            get { return Background_Color_; }
            set
            {
                Background_Color_ = value;
                NotifyPropertyChanged("Background_Color");
            }
        }

        private double Progress_Complete_Value_ = 0;
        public double Progress_Complete_Value
        {
            get { return Progress_Complete_Value_; }
            set
            {
                Progress_Complete_Value_ = value;
                NotifyPropertyChanged("Progress_Complete_Value");
            }
        }

        private double Delay_Timer_Progress_ = 0;
        public double Delay_Timer_Progress
        {
            get { return Delay_Timer_Progress_; }
            set
            {
                Delay_Timer_Progress_ = value;
                NotifyPropertyChanged("Delay_Timer_Progress");
            }
        }

        private string Measurement_ = "Wait";
        public string Measurement
        {
            get { return Measurement_; }
            set
            {
                Measurement_ = value;
                NotifyPropertyChanged("Measurement");
            }
        }

        private string Measurement_Min_ = "Wait";
        public string Measurement_Min
        {
            get { return Measurement_Min_; }
            set
            {
                Measurement_Min_ = value;
                NotifyPropertyChanged("Measurement_Min");
            }
        }

        private string Measurement_Max_ = "Wait";
        public string Measurement_Max
        {
            get { return Measurement_Max_; }
            set
            {
                Measurement_Max_ = value;
                NotifyPropertyChanged("Measurement_Max");
            }
        }

        private bool Query_Measurement_Pause_ = false;
        public bool Query_Measurement_Pause
        {
            get { return Query_Measurement_Pause_; }
            set
            {
                Query_Measurement_Pause_ = value;
                NotifyPropertyChanged("Query_Measurement_Pause");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
