using NodeNetwork_Math;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : INotifyPropertyChanged
    {
        private bool Fast_Expression_Parsing_Library_ = false;
        public bool Fast_Expression_Parsing_Library
        {
            get { return Fast_Expression_Parsing_Library_; }
            set
            {
                Fast_Expression_Parsing_Library_ = value;
                NotifyPropertyChanged("Fast_Expression_Parsing_Library");
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

        private string Node_Background_Color_ = "#FF0095FF";
        public string Node_Background_Color
        {
            get { return Node_Background_Color_; }
            set
            {
                Node_Background_Color_ = value;
                NotifyPropertyChanged("Node_Background_Color");
            }
        }

        private string Node_Foreground_Color_ = "#FFFFFFFF";
        public string Node_Foreground_Color
        {
            get { return Node_Foreground_Color_; }
            set
            {
                Node_Foreground_Color_ = value;
                NotifyPropertyChanged("Node_Foreground_Color");
            }
        }

        private ObservableCollection<string> Node_Category_ = new ObservableCollection<string>(Enum.GetNames(typeof(NodeCategory)));
        public ObservableCollection<string> Node_Category
        {
            get
            {
                return Node_Category_;
            }
            set
            {
                Node_Category_ = value;
                NotifyPropertyChanged();
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
