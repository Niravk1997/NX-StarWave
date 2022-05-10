using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string Long_Title_ = "";
        public string Long_Title
        {
            get
            {
                return Long_Title_;
            }
            set
            {
                Long_Title_ = value;
                NotifyPropertyChanged("Long_Title");
            }
        }

        private string Short_Title_ = "";
        public string Short_Title
        {
            get
            {
                return Short_Title_;
            }
            set
            {
                Short_Title_ = value;
                NotifyPropertyChanged("Short_Title");
            }
        }

        private double Window_Width_ = 0;
        public double Window_Width
        {
            get
            {
                return Window_Width_;
            }
            set
            {
                Window_Width_ = value;
                NotifyPropertyChanged("Window_Width");
            }
        }

        private double Window_Height_ = 0;
        public double Window_Height
        {
            get
            {
                return Window_Height_;
            }
            set
            {
                Window_Height_ = value;
                NotifyPropertyChanged("Window_Height");
            }
        }

        private Brush Statistics_Table_Owner_Color_ = Brushes.Transparent;
        public Brush Statistics_Table_Owner_Color
        {
            get
            {
                return Statistics_Table_Owner_Color_;
            }
            set
            {
                Statistics_Table_Owner_Color_ = value;
                NotifyPropertyChanged("Statistics_Table_Owner_Color");
            }
        }

        private Visibility Measurement_Start_Stop_Text_Visibility_ = Visibility.Collapsed;
        public Visibility Measurement_Start_Stop_Text_Visibility
        {
            get
            {
                return Measurement_Start_Stop_Text_Visibility_;
            }
            set
            {
                Measurement_Start_Stop_Text_Visibility_ = value;

                NotifyPropertyChanged("Measurement_Start_Stop_Text_Visibility");
            }
        }

        private string Measurement_Start_ = "";
        public string Measurement_Start
        {
            get
            {
                return Measurement_Start_;
            }
            set
            {
                Measurement_Start_ = value;
                NotifyPropertyChanged("Measurement_Start");
            }
        }

        private string Measurement_Stop_ = "";
        public string Measurement_Stop
        {
            get
            {
                return Measurement_Stop_;
            }
            set
            {
                Measurement_Stop_ = value;
                NotifyPropertyChanged("Measurement_Stop");
            }
        }
    }
}
