using System.ComponentModel;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : INotifyPropertyChanged
    {
        private bool _Show_FFT = false;
        public bool Show_FFT
        {
            get { return _Show_FFT; }
            set
            {
                _Show_FFT = value;
                NotifyPropertyChanged();
            }
        }

        private string _FFT_Color = "#FF0072BD";
        public string FFT_Color
        {
            get { return _FFT_Color; }
            set
            {
                _FFT_Color = value;
                NotifyPropertyChanged();
            }
        }

        private bool _FFT_Units = false;
        public bool FFT_Units
        {
            get { return _FFT_Units; }
            set
            {
                _FFT_Units = value;
                NotifyPropertyChanged();
            }
        }

        private int _FFT_Window = 0;
        public int FFT_Window
        {
            get { return _FFT_Window; }
            set
            {
                _FFT_Window = value;
                NotifyPropertyChanged();
            }
        }

        private bool _FFT_Phase = false;
        public bool FFT_Phase
        {
            get { return _FFT_Phase; }
            set
            {
                _FFT_Phase = value;
                NotifyPropertyChanged();
            }
        }

        private bool _FFT_Phase_Units = false;
        public bool FFT_Phase_Units
        {
            get { return _FFT_Phase_Units; }
            set
            {
                _FFT_Phase_Units = value;
                NotifyPropertyChanged();
            }
        }

        private double _FFT_Phase_Ignore = -35;
        public double FFT_Phase_Ignore
        {
            get { return _FFT_Phase_Ignore; }
            set
            {
                _FFT_Phase_Ignore = value;
                NotifyPropertyChanged();
            }
        }

        private bool _FFT_Peaks = false;
        public bool FFT_Peaks
        {
            get { return _FFT_Peaks; }
            set
            {
                _FFT_Peaks = value;
                NotifyPropertyChanged();
            }
        }

        private double _FFT_Peaks_Reference = -35;
        public double FFT_Peaks_Reference
        {
            get { return _FFT_Peaks_Reference; }
            set
            {
                _FFT_Peaks_Reference = value;
                NotifyPropertyChanged();
            }
        }

        private int _FFT_Peaks_Size = 2;
        public int FFT_Peaks_Size
        {
            get { return _FFT_Peaks_Size; }
            set
            {
                if (value >= 2)
                {
                    _FFT_Peaks_Size = value;
                }
                else
                {
                    _FFT_Peaks_Size = 2;
                }
                NotifyPropertyChanged();
            }
        }

        private bool _FFT_Interpolation_Enable = false;
        public bool FFT_Interpolation_Enable
        {
            get { return _FFT_Interpolation_Enable; }
            set
            {
                _FFT_Interpolation_Enable = value;
                NotifyPropertyChanged("FFT_Interpolation_Enable");
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
    }
}
