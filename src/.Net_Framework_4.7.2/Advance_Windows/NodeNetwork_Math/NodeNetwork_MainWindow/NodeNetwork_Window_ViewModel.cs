using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : INotifyPropertyChanged
    {
        private string CH1_Color_string_ = "#0072BD";
        public string CH1_Color_string
        {
            get { return CH1_Color_string_; }
            set
            {
                CH1_Color_string_ = value;
                NotifyPropertyChanged("CH1_Color_string");
            }
        }

        private string CH2_Color_string_ = "#FFFF8C00";
        public string CH2_Color_string
        {
            get { return CH2_Color_string_; }
            set
            {
                CH2_Color_string_ = value;
                NotifyPropertyChanged("CH2_Color_string");
            }
        }

        private string CH3_Color_string_ = "#FFFF1493";
        public string CH3_Color_string
        {
            get { return CH3_Color_string_; }
            set
            {
                CH3_Color_string_ = value;
                NotifyPropertyChanged("CH3_Color_string");
            }
        }

        private string CH4_Color_string_ = "#00B33C";
        public string CH4_Color_string
        {
            get { return CH4_Color_string_; }
            set
            {
                CH4_Color_string_ = value;
                NotifyPropertyChanged("CH4_Color_string");
            }
        }

        private Brush NodeEditor_Background_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFFFFFF");
        public Brush NodeEditor_Background
        {
            get { return NodeEditor_Background_; }
            set
            {
                NodeEditor_Background_ = value;
                NotifyPropertyChanged("NodeEditor_Background");
            }
        }

        private string NodeEditor_Background_String_ = "#FFFFFFFF";
        public string NodeEditor_Background_String
        {
            get { return NodeEditor_Background_String_; }
            set
            {
                NodeEditor_Background_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                NodeEditor_Background = Color;
                NotifyPropertyChanged("NodeEditor_Background_String");
            }
        }

        private Brush NodeEditor_Grid_ = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF87CEFA");
        public Brush NodeEditor_Grid
        {
            get { return NodeEditor_Grid_; }
            set
            {
                NodeEditor_Grid_ = value;
                NotifyPropertyChanged("NodeEditor_Grid");
            }
        }

        private string NodeEditor_Grid_String_ = "#FF87CEFA";
        public string NodeEditor_Grid_String
        {
            get { return NodeEditor_Grid_String_; }
            set
            {
                NodeEditor_Grid_String_ = value;
                Brush Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                Color.Freeze();
                NodeEditor_Grid = Color;
                NotifyPropertyChanged("NodeEditor_Grid_String");
            }
        }

        private bool NodeEditor_Enable_ = true;
        public bool NodeEditor_Enable
        {
            get { return NodeEditor_Enable_; }
            set
            {
                NodeEditor_Enable_ = value;
                NotifyPropertyChanged("NodeEditor_Enable");
            }
        }

        private string Draw_Mode_Custom_Selected_Color_ = "#ff8c00";
        public string Draw_Mode_Custom_Selected_Color
        {
            get { return Draw_Mode_Custom_Selected_Color_; }
            set
            {
                Draw_Mode_Custom_Selected_Color_ = value;
                Draw_Mode_Tool_Tip_Custom_Color_Set(value);
                NotifyPropertyChanged("Draw_Mode_Custom_Selected_Color");
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
