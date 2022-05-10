using System.ComponentModel;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : INotifyPropertyChanged
    {
        private bool _Show_Waveform = true;
        public bool Show_Waveform
        {
            get { return _Show_Waveform; }
            set
            {
                _Show_Waveform = value;
                NotifyPropertyChanged();
            }
        }

        private string _Waveform_Color = "#FF0072BD";
        public string Waveform_Color
        {
            get { return _Waveform_Color; }
            set
            {
                _Waveform_Color = value;
                NotifyPropertyChanged();
            }
        }

        private string _Waveform_YAXIS = "Voltage (V)";
        public string Waveform_YAXIS
        {
            get { return _Waveform_YAXIS; }
            set
            {
                _Waveform_YAXIS = value;
                NotifyPropertyChanged();
            }
        }

        private string _Waveform_YAXIS_Units = "V";
        public string Waveform_YAXIS_Units
        {
            get { return _Waveform_YAXIS_Units; }
            set
            {
                _Waveform_YAXIS_Units = value;
                NotifyPropertyChanged();
            }
        }

        private string _Waveform_Title = "Waveform";
        public string Waveform_Title
        {
            get { return _Waveform_Title; }
            set
            {
                _Waveform_Title = value;
                NotifyPropertyChanged();
            }
        }

        private bool _Waveform_Continuous = false;
        public bool Waveform_Continuous
        {
            get { return _Waveform_Continuous; }
            set
            {
                _Waveform_Continuous = value;
                NotifyPropertyChanged();
            }
        }
    }
}
