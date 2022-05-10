using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private ObservableCollection<TextBlock> Output_Log_ = new ObservableCollection<TextBlock>();
        public ObservableCollection<TextBlock> Output_Log
        {
            get { return Output_Log_; }
            set { Output_Log_ = value; NotifyPropertyChanged(); }
        }

        private String _RunTime_Counter_Value = "00:00:00";
        public String RunTime_Counter_Value
        {
            get { return _RunTime_Counter_Value; }
            set
            {
                _RunTime_Counter_Value = value;
                NotifyPropertyChanged();
            }
        }

        private int _CH1_Counter_Value = 0;
        public int CH1_Counter_Value
        {
            get { return _CH1_Counter_Value; }
            set
            {
                _CH1_Counter_Value = value;
                NotifyPropertyChanged();
            }
        }

        private int _CH2_Counter_Value = 0;
        public int CH2_Counter_Value
        {
            get { return _CH2_Counter_Value; }
            set
            {
                _CH2_Counter_Value = value;
                NotifyPropertyChanged();
            }
        }

        private int _CH3_Counter_Value = 0;
        public int CH3_Counter_Value
        {
            get { return _CH3_Counter_Value; }
            set
            {
                _CH3_Counter_Value = value;
                NotifyPropertyChanged();
            }
        }

        private int _CH4_Counter_Value = 0;
        public int CH4_Counter_Value
        {
            get { return _CH4_Counter_Value; }
            set
            {
                _CH4_Counter_Value = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
