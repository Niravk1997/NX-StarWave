using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : INotifyPropertyChanged
    {
        private bool _Auto_Clear = false;
        public bool Auto_Clear
        {
            get { return _Auto_Clear; }
            set
            {
                _Auto_Clear = value;
                NotifyPropertyChanged("Auto_Clear");
            }
        }

        private bool _Auto_Save = false;
        public bool Auto_Save
        {
            get { return _Auto_Save; }
            set
            {
                _Auto_Save = value;
                NotifyPropertyChanged("Auto_Save");
            }
        }

        private bool _Auto_Load = true;
        public bool Auto_Load
        {
            get { return _Auto_Load; }
            set
            {
                _Auto_Load = value;
                NotifyPropertyChanged("Auto_Load");
            }
        }

        private ObservableCollection<TextBlock> Output_Log_ = new ObservableCollection<TextBlock>();
        public ObservableCollection<TextBlock> Output_Log
        {
            get { return Output_Log_; }
            set { Output_Log_ = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
