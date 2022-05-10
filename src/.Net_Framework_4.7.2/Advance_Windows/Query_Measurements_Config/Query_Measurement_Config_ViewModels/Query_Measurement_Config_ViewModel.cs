using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : INotifyPropertyChanged
    {
        private string Query_SCPI_Command_ = "";
        public string Query_SCPI_Command
        {
            get { return Query_SCPI_Command_; }
            set
            {
                Query_SCPI_Command_ = value;
                NotifyPropertyChanged("Query_SCPI_Command");
            }
        }

        private string Query_Result_Start_Cut_String_ = "";
        public string Query_Result_Start_Cut_String
        {
            get { return Query_Result_Start_Cut_String_; }
            set
            {
                Query_Result_Start_Cut_String_ = value;
                NotifyPropertyChanged("Query_Result_Start_Cut_String");
            }
        }

        private string Query_Result_Stop_Cut_String_ = "";
        public string Query_Result_Stop_Cut_String
        {
            get { return Query_Result_Stop_Cut_String_; }
            set
            {
                Query_Result_Stop_Cut_String_ = value;
                NotifyPropertyChanged("Query_Result_Stop_Cut_String");
            }
        }

        private double Query_SCPI_Delay_ = 1;
        public double Query_SCPI_Delay
        {
            get { return Query_SCPI_Delay_; }
            set
            {
                Query_SCPI_Delay_ = value;
                NotifyPropertyChanged("Query_SCPI_Delay");
            }
        }

        private string Query_SCPI_Measurement_Units_ = "";
        public string Query_SCPI_Measurement_Units
        {
            get { return Query_SCPI_Measurement_Units_; }
            set
            {
                Query_SCPI_Measurement_Units_ = value;
                NotifyPropertyChanged("Query_SCPI_Measurement_Units");
            }
        }

        private string Query_Measurement_Window_Title_ = "";
        public string Query_Measurement_Window_Title
        {
            get { return Query_Measurement_Window_Title_; }
            set
            {
                Query_Measurement_Window_Title_ = value;
                NotifyPropertyChanged("Query_Measurement_Window_Title");
            }
        }

        private string Query_Measurement_Window_Label_Color_ = "#FF1E90FF";
        public string Query_Measurement_Window_Label_Color
        {
            get { return Query_Measurement_Window_Label_Color_; }
            set
            {
                Query_Measurement_Window_Label_Color_ = value;
                NotifyPropertyChanged("Query_Measurement_Window_Label_Color");
            }
        }

        private bool Query_Measurement_Window_isBackground_Transparent_ = false;
        public bool Query_Measurement_Window_isBackground_Transparent
        {
            get { return Query_Measurement_Window_isBackground_Transparent_; }
            set
            {
                Query_Measurement_Window_isBackground_Transparent_ = value;
                NotifyPropertyChanged("Query_Measurement_Window_isBackground_Transparent");
            }
        }

        private string Query_Measurement_Window_Background_Color_ = "#FFFFFFFF";
        public string Query_Measurement_Window_Background_Color
        {
            get { return Query_Measurement_Window_Background_Color_; }
            set
            {
                Query_Measurement_Window_Background_Color_ = value;
                NotifyPropertyChanged("Query_Measurement_Window_Background_Color");
            }
        }

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
