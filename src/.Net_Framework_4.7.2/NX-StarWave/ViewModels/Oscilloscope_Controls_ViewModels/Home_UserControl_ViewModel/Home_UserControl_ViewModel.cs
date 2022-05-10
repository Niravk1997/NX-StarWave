using System;
using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private String Company_Name_;
        public String Company_Name
        {
            get { return Company_Name_; }
            set
            {
                Company_Name_ = value;
                NotifyPropertyChanged("Company_Name");
            }
        }

        private String Oscilloscope_Model_;
        public String Oscilloscope_Model
        {
            get { return Oscilloscope_Model_; }
            set
            {
                Oscilloscope_Model_ = value;
                NotifyPropertyChanged("Oscilloscope_Model");
            }
        }

        private String Oscilloscope_Firmware_;
        public String Oscilloscope_Firmware
        {
            get { return Oscilloscope_Firmware_; }
            set
            {
                Oscilloscope_Firmware_ = value;
                NotifyPropertyChanged("Oscilloscope_Firmware");
            }
        }

        private String Connection_Interface_Type_ = "Not Connected";
        public String Connection_Interface_Type
        {
            get { return Connection_Interface_Type_; }
            set
            {
                Connection_Interface_Type_ = value;
                NotifyPropertyChanged("Connection_Interface_Type");
            }
        }

        private Brush Web_Server_Selected_ = Brushes.Transparent;
        public Brush Web_Server_Selected
        {
            get
            {
                return Web_Server_Selected_;
            }
            set
            {
                Web_Server_Selected_ = value;
                NotifyPropertyChanged("Web_Server_Selected");
            }
        }
    }
}
