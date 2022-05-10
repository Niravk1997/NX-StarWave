using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
namespace Waveform_Player
{
    public partial class Waveform_Player_Window : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int Waveform_Play_Start_Index_ = 0;
        public int Waveform_Play_Start_Index
        {
            get { return Waveform_Play_Start_Index_; }
            set
            {
                Waveform_Play_Start_Index_ = value;
                NotifyPropertyChanged("Waveform_Play_Start_Index");
            }
        }

        private int Waveform_Play_Stop_Index_ = 0;
        public int Waveform_Play_Stop_Index
        {
            get { return Waveform_Play_Stop_Index_; }
            set
            {
                Waveform_Play_Stop_Index_ = value;
                NotifyPropertyChanged("Waveform_Play_Stop_Index");
            }
        }

        private int Waveform_Play_Delay_Interval_ = 200;
        public int Waveform_Play_Delay_Interval
        {
            get { return Waveform_Play_Delay_Interval_; }
            set
            {
                Waveform_Play_Delay_Interval_ = value;
                NotifyPropertyChanged("Waveform_Play_Delay_Interval");
            }
        }

        private bool Waveform_Play_Repeat_ = false;
        public bool Waveform_Play_Repeat
        {
            get { return Waveform_Play_Repeat_; }
            set
            {
                Waveform_Play_Repeat_ = value;
                NotifyPropertyChanged("Waveform_Play_Repeat");
            }
        }

        private Brush Waveform_Play_Repeat_Status_Color_ = Brushes.Transparent;
        public Brush Waveform_Play_Repeat_Status_Color
        {
            get
            {
                return Waveform_Play_Repeat_Status_Color_;
            }
            set
            {
                Waveform_Play_Repeat_Status_Color_ = value;
                NotifyPropertyChanged("Waveform_Play_Repeat_Status_Color");
            }
        }

        private int Table_Selected_Index_;
        public int Table_Selected_Index
        {
            get { return Table_Selected_Index_; }
            set
            {
                Table_Selected_Index_ = value;
                NotifyPropertyChanged("Table_Selected_Index");
            }
        }

        private int Tab_Item_SelectedIndex_ = 0;
        public int Tab_Item_SelectedIndex
        {
            get { return Tab_Item_SelectedIndex_; }
            set
            {
                Tab_Item_SelectedIndex_ = value;
                NotifyPropertyChanged("Tab_Item_SelectedIndex");
            }
        }

        private Brush SQLite_Databse_Connect_Status_ = Brushes.Red;
        public Brush SQLite_Databse_Connect_Status
        {
            get
            {
                return SQLite_Databse_Connect_Status_;
            }
            set
            {
                SQLite_Databse_Connect_Status_ = value;
                NotifyPropertyChanged("SQLite_Databse_Connect_Status");
            }
        }

        private Brush SQLite_Databse_Read_Write_Status_ = Brushes.Transparent;
        public Brush SQLite_Databse_Read_Write_Status
        {
            get
            {
                return SQLite_Databse_Read_Write_Status_;
            }
            set
            {
                SQLite_Databse_Read_Write_Status_ = value;
                NotifyPropertyChanged("SQLite_Databse_Read_Write_Status");
            }
        }

        private string Waveform_Name_ = "";
        public string Waveform_Name
        {
            get
            {
                return Waveform_Name_;
            }
            set
            {
                Waveform_Name_ = value;
                NotifyPropertyChanged("Waveform_Name");
            }
        }

        private bool SQLite_AutoSave_ = false;
        public bool SQLite_AutoSave
        {
            get { return SQLite_AutoSave_; }
            set
            {
                SQLite_AutoSave_ = value;
                NotifyPropertyChanged("SQLite_AutoSave");
            }
        }
    }
}
