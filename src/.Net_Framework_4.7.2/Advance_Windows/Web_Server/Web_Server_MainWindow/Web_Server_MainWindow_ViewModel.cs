using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace Waveform_Web_Server
{
    public partial class Web_Server_MainWindow : INotifyPropertyChanged
    {
        private string _Window_Title = "Waveform Web Server";
        public string Window_Title
        {
            get { return _Window_Title; }
            set
            {
                _Window_Title = value;
                NotifyPropertyChanged("Window_Title");
            }
        }

        private Brush Web_Server_Status_Brush_ = Brushes.Red;
        public Brush Web_Server_Status_Brush
        {
            get
            {
                return Web_Server_Status_Brush_;
            }
            set
            {
                Web_Server_Status_Brush_ = value;
                NotifyPropertyChanged("Web_Server_Status_Brush");
            }
        }

        private bool Read_Only_Input_TextFields_ = false;
        public bool Read_Only_Input_TextFields
        {
            get { return Read_Only_Input_TextFields_; }
            set
            {
                Read_Only_Input_TextFields_ = value;
                NotifyPropertyChanged("Read_Only_Input_TextFields");
            }
        }

        private string IP_Address_ = "";
        public string IP_Address
        {
            get { return IP_Address_; }
            set
            {
                IP_Address_ = value;
                NotifyPropertyChanged("IP_Address");
            }
        }

        private int Port_ = 22997;
        public int Port
        {
            get { return Port_; }
            set
            {
                Port_ = value;
                NotifyPropertyChanged("Port");
            }
        }

        private ObservableCollection<TextBox> Output_Log_ = new ObservableCollection<TextBox>();
        public ObservableCollection<TextBox> Output_Log
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
