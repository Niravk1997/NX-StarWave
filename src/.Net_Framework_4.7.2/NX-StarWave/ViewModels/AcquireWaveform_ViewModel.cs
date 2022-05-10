using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush _Acquire_Waveform_Disable_Button_BorderBrush = Brushes.Transparent;
        public Brush Acquire_Waveform_Disable_Button_BorderBrush
        {
            get
            {
                return _Acquire_Waveform_Disable_Button_BorderBrush;
            }
            set
            {
                _Acquire_Waveform_Disable_Button_BorderBrush = value;
                NotifyPropertyChanged("Acquire_Waveform_Disable_Button_BorderBrush");
            }
        }

        private Brush _Acquire_Waveform_Once_Button_BorderBrush = Brushes.Transparent;
        public Brush Acquire_Waveform_Once_Button_BorderBrush
        {
            get
            {
                return _Acquire_Waveform_Once_Button_BorderBrush;
            }
            set
            {
                _Acquire_Waveform_Once_Button_BorderBrush = value;
                NotifyPropertyChanged("Acquire_Waveform_Once_Button_BorderBrush");
            }
        }

        private Brush _Acquire_Waveform_Continuous_Button_BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#00CE30");
        public Brush Acquire_Waveform_Continuous_Button_BorderBrush
        {
            get
            {
                return _Acquire_Waveform_Continuous_Button_BorderBrush;
            }
            set
            {
                _Acquire_Waveform_Continuous_Button_BorderBrush = value;
                NotifyPropertyChanged("Acquire_Waveform_Continuous_Button_BorderBrush");
            }
        }

        private Brush _CH1_Status_Color = Brushes.Black;
        public Brush CH1_Status_Color
        {
            get
            {
                return _CH1_Status_Color;
            }
            set
            {
                _CH1_Status_Color = value;
                NotifyPropertyChanged("CH1_Status_Color");
            }
        }
        private int _CH1_Acquire_Mode = 0;
        public int CH1_Acquire_Mode { get { return _CH1_Acquire_Mode; } set { _CH1_Acquire_Mode = value; NotifyPropertyChanged("CH1_Acquire_Mode"); } }

        private Brush _CH2_Status_Color = Brushes.Black;
        public Brush CH2_Status_Color
        {
            get
            {
                return _CH2_Status_Color;
            }
            set
            {
                _CH2_Status_Color = value;
                NotifyPropertyChanged("CH2_Status_Color");
            }
        }
        private int _CH2_Acquire_Mode = 0;
        public int CH2_Acquire_Mode { get { return _CH2_Acquire_Mode; } set { _CH2_Acquire_Mode = value; NotifyPropertyChanged("CH2_Acquire_Mode"); } }

        private Brush _CH3_Status_Color = Brushes.Black;
        public Brush CH3_Status_Color
        {
            get
            {
                return _CH3_Status_Color;
            }
            set
            {
                _CH3_Status_Color = value;
                NotifyPropertyChanged("CH3_Status_Color");
            }
        }
        private int _CH3_Acquire_Mode = 0;
        public int CH3_Acquire_Mode { get { return _CH3_Acquire_Mode; } set { _CH3_Acquire_Mode = value; NotifyPropertyChanged("CH3_Acquire_Mode"); } }

        private Brush _CH4_Status_Color = Brushes.Black;
        public Brush CH4_Status_Color
        {
            get
            {
                return _CH4_Status_Color;
            }
            set
            {
                _CH4_Status_Color = value;
                NotifyPropertyChanged("CH4_Status_Color");
            }
        }
        private int _CH4_Acquire_Mode = 0;
        public int CH4_Acquire_Mode { get { return _CH4_Acquire_Mode; } set { _CH4_Acquire_Mode = value; NotifyPropertyChanged("CH4_Acquire_Mode"); } }

        private double _Acquire_Timer_Set_Value = 1;
        public double Acquire_Timer_Set_Value
        {
            get
            {
                return _Acquire_Timer_Set_Value;
            }
            set
            {
                _Acquire_Timer_Set_Value = value;
                Apply_Acquire_Interval_Value(true, value);
                NotifyPropertyChanged("Acquire_Timer_Set_Value");
            }
        }

        private string _DataStart_string = "1";
        public string DataStart_string
        {
            get
            {
                return _DataStart_string;
            }
            set
            {
                _DataStart_string = value;
                NotifyPropertyChanged("DataStart_string");
            }
        }

        private string _DataStop_string = "500";
        public string DataStop_string
        {
            get
            {
                return _DataStop_string;
            }
            set
            {
                _DataStop_string = value;
                NotifyPropertyChanged("DataStop_string");
            }
        }

        private bool _Loop_Lock = false;
        public bool Loop_Lock
        {
            get
            {
                return _Loop_Lock;
            }
            set
            {
                _Loop_Lock = value;
                if (value)
                {
                    insert_Log("Communication Code is now loop locked.", 2);
                }
                else
                {
                    insert_Log("Communication Code loop locked disabled.", 0);
                }
                NotifyPropertyChanged("Loop_Lock");
            }
        }
    }
}
