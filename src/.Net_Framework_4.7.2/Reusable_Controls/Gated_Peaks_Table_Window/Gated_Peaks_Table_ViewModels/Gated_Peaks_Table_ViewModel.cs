using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Gated_Peaks_Table
{
    public partial class Gated_Peaks_Table_Window : INotifyPropertyChanged
    {
        private string Window_Title_ = "";
        public string Window_Title
        {
            get
            {
                return Window_Title_;
            }
            set
            {
                Window_Title_ = value;
                NotifyPropertyChanged("Window_Title");
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

        private double Measurement_Start_Stop_Text_Row_Height_Value_ = 0;
        public double Measurement_Start_Stop_Text_Row_Height_Value
        {
            get
            {
                return Measurement_Start_Stop_Text_Row_Height_Value_;
            }
            set
            {
                Measurement_Start_Stop_Text_Row_Height_Value_ = value;
                NotifyPropertyChanged("Measurement_Start_Stop_Text_Row_Height_Value");
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
                if (value == Visibility.Visible)
                {
                    Measurement_Start_Stop_Text_Row_Height_Value = 15;
                }
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

        private Brush Gated_Peaks_Table_Owner_Color_ = Brushes.Transparent;
        public Brush Gated_Peaks_Table_Owner_Color
        {
            get
            {
                return Gated_Peaks_Table_Owner_Color_;
            }
            set
            {
                Gated_Peaks_Table_Owner_Color_ = value;
                NotifyPropertyChanged("Gated_Peaks_Table_Owner_Color");
            }
        }

        private string Y_Values_Title_ = "";
        public string Y_Values_Title
        {
            get
            {
                return Y_Values_Title_;
            }
            set
            {
                Y_Values_Title_ = value;
                NotifyPropertyChanged("Y_Values_Title");
            }
        }

        private string X_Values_Title_ = "";
        public string X_Values_Title
        {
            get
            {
                return X_Values_Title_;
            }
            set
            {
                X_Values_Title_ = value;
                NotifyPropertyChanged("X_Values_Title");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
