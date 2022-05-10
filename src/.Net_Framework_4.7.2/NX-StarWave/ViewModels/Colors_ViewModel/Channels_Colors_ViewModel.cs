using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush Channel_1_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#0072BD");
        public Brush Channel_1_Color
        {
            get { return Channel_1_Color_; }
            set
            {
                Channel_1_Color_ = value;
                NotifyPropertyChanged("Channel_1_Color");
            }
        }

        private string Channel_1_Color_String_ = "#0072BD";
        public string Channel_1_Color_String
        {
            get { return Channel_1_Color_String_; }
            set
            {
                Channel_1_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Channel_1_Color = Color;
                NotifyPropertyChanged("Channel_1_Color_String");
            }
        }

        private Brush Channel_2_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF8C00");
        public Brush Channel_2_Color
        {
            get { return Channel_2_Color_; }
            set
            {
                Channel_2_Color_ = value;
                NotifyPropertyChanged("Channel_2_Color");
            }
        }

        private string Channel_2_Color_String_ = "#FFFF8C00";
        public string Channel_2_Color_String
        {
            get { return Channel_2_Color_String_; }
            set
            {
                Channel_2_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Channel_2_Color = Color;
                NotifyPropertyChanged("Channel_2_Color_String");
            }
        }

        private Brush Channel_3_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF1493");
        public Brush Channel_3_Color
        {
            get { return Channel_3_Color_; }
            set
            {
                Channel_3_Color_ = value;
                NotifyPropertyChanged("Channel_3_Color");
            }
        }

        private string Channel_3_Color_String_ = "#FFFF1493";
        public string Channel_3_Color_String
        {
            get { return Channel_3_Color_String_; }
            set
            {
                Channel_3_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Channel_3_Color = Color;
                NotifyPropertyChanged("Channel_3_Color_String");
            }
        }

        private Brush Channel_4_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#00B33C");
        public Brush Channel_4_Color
        {
            get { return Channel_4_Color_; }
            set
            {
                Channel_4_Color_ = value;
                NotifyPropertyChanged("Channel_4_Color");
            }
        }

        private string Channel_4_Color_String_ = "#00B33C";
        public string Channel_4_Color_String
        {
            get { return Channel_4_Color_String_; }
            set
            {
                Channel_4_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Channel_4_Color = Color;
                NotifyPropertyChanged("Channel__Color_String");
            }
        }

        //Math Windows YT Colors
        private Brush Math_YT_Window_1_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#0072BD");
        public Brush Math_YT_Window_1_Color
        {
            get { return Math_YT_Window_1_Color_; }
            set
            {
                Math_YT_Window_1_Color_ = value;
                NotifyPropertyChanged("Math_YT_Window_1_Color");
            }
        }

        private string Math_YT_Window_1_Color_String_ = "#0072BD";
        public string Math_YT_Window_1_Color_String
        {
            get { return Math_YT_Window_1_Color_String_; }
            set
            {
                Math_YT_Window_1_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Math_YT_Window_1_Color = Color;
                NotifyPropertyChanged("Math_YT_Window_1_Color_String");
            }
        }

        private Brush Math_YT_Window_2_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF8C00");
        public Brush Math_YT_Window_2_Color
        {
            get { return Math_YT_Window_2_Color_; }
            set
            {
                Math_YT_Window_2_Color_ = value;
                NotifyPropertyChanged("Math_YT_Window_2_Color");
            }
        }

        private string Math_YT_Window_2_Color_String_ = "#FFFF8C00";
        public string Math_YT_Window_2_Color_String
        {
            get { return Math_YT_Window_2_Color_String_; }
            set
            {
                Math_YT_Window_2_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Math_YT_Window_2_Color = Color;
                NotifyPropertyChanged("Math_YT_Window_2_Color_String");
            }
        }

        private Brush Math_YT_Window_3_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF1493");
        public Brush Math_YT_Window_3_Color
        {
            get { return Math_YT_Window_3_Color_; }
            set
            {
                Math_YT_Window_3_Color_ = value;
                NotifyPropertyChanged("Math_YT_Window_3_Color");
            }
        }

        private string Math_YT_Window_3_Color_String_ = "#FFFF1493";
        public string Math_YT_Window_3_Color_String
        {
            get { return Math_YT_Window_3_Color_String_; }
            set
            {
                Math_YT_Window_3_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Math_YT_Window_3_Color = Color;
                NotifyPropertyChanged("Math_YT_Window_3_Color_String");
            }
        }

        private Brush Math_YT_Window_4_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#00B33C");
        public Brush Math_YT_Window_4_Color
        {
            get { return Math_YT_Window_4_Color_; }
            set
            {
                Math_YT_Window_4_Color_ = value;
                NotifyPropertyChanged("Math_YT_Window_4_Color");
            }
        }

        private string Math_YT_Window_4_Color_String_ = "#00B33C";
        public string Math_YT_Window_4_Color_String
        {
            get { return Math_YT_Window_4_Color_String_; }
            set
            {
                Math_YT_Window_4_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Math_YT_Window_4_Color = Color;
                NotifyPropertyChanged("Math_YT_Window_4_Color_String");
            }
        }

        //Math Windows FFT Colors
        private Brush Math_FFT_Window_1_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#0072BD");
        public Brush Math_FFT_Window_1_Color
        {
            get { return Math_FFT_Window_1_Color_; }
            set
            {
                Math_FFT_Window_1_Color_ = value;
                NotifyPropertyChanged("Math_FFT_Window_1_Color");
            }
        }

        private string Math_FFT_Window_1_Color_String_ = "#0072BD";
        public string Math_FFT_Window_1_Color_String
        {
            get { return Math_FFT_Window_1_Color_String_; }
            set
            {
                Math_FFT_Window_1_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Math_FFT_Window_1_Color = Color;
                NotifyPropertyChanged("Math_FFT_Window_1_Color_String");
            }
        }

        private Brush Math_FFT_Window_2_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF8C00");
        public Brush Math_FFT_Window_2_Color
        {
            get { return Math_FFT_Window_2_Color_; }
            set
            {
                Math_FFT_Window_2_Color_ = value;
                NotifyPropertyChanged("Math_FFT_Window_2_Color");
            }
        }

        private string Math_FFT_Window_2_Color_String_ = "#FFFF8C00";
        public string Math_FFT_Window_2_Color_String
        {
            get { return Math_FFT_Window_2_Color_String_; }
            set
            {
                Math_FFT_Window_2_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Math_FFT_Window_2_Color = Color;
                NotifyPropertyChanged("Math_FFT_Window_2_Color_String");
            }
        }

        private Brush Math_FFT_Window_3_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF1493");
        public Brush Math_FFT_Window_3_Color
        {
            get { return Math_FFT_Window_3_Color_; }
            set
            {
                Math_FFT_Window_3_Color_ = value;
                NotifyPropertyChanged("Math_FFT_Window_3_Color");
            }
        }

        private string Math_FFT_Window_3_Color_String_ = "#FFFF1493";
        public string Math_FFT_Window_3_Color_String
        {
            get { return Math_FFT_Window_3_Color_String_; }
            set
            {
                Math_FFT_Window_3_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Math_FFT_Window_3_Color = Color;
                NotifyPropertyChanged("Math_FFT_Window_3_Color_String");
            }
        }

        private Brush Math_FFT_Window_4_Color_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#00B33C");
        public Brush Math_FFT_Window_4_Color
        {
            get { return Math_FFT_Window_4_Color_; }
            set
            {
                Math_FFT_Window_4_Color_ = value;
                NotifyPropertyChanged("Math_FFT_Window_4_Color");
            }
        }

        private string Math_FFT_Window_4_Color_String_ = "#00B33C";
        public string Math_FFT_Window_4_Color_String
        {
            get { return Math_FFT_Window_4_Color_String_; }
            set
            {
                Math_FFT_Window_4_Color_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                Math_FFT_Window_4_Color = Color;
                NotifyPropertyChanged("Math_FFT_Window_4_Color_String");
            }
        }
    }
}
