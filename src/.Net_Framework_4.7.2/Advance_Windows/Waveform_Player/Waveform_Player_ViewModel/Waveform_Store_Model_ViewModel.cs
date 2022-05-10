using Axis_Scale_Config;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Waveform_Player
{
    public class Waveform_Store_Table_Model
    {
        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public Waveform_Store_Table_Model(string Name, string Date_Time, Channel_Waveform_Data CH1, Channel_Waveform_Data CH2, Channel_Waveform_Data CH3, Channel_Waveform_Data CH4)
        {
            this.CH1 = CH1;
            this.CH2 = CH2;
            this.CH3 = CH3;
            this.CH4 = CH4;

            CH1_Valid = CH1.Valid;
            CH2_Valid = CH2.Valid;
            CH3_Valid = CH3.Valid;
            CH4_Valid = CH4.Valid;

            if (CH1_Valid)
            {
                Total_Time = Axis_Scale_Config.Value_SI_Prefix(CH1.Total_Time, 4) + "s";
                Start_Time = Axis_Scale_Config.Value_SI_Prefix(CH1.Start_Time, 4) + "s";
                Stop_Time = Axis_Scale_Config.Value_SI_Prefix(CH1.Stop_Time, 4) + "s";
                Data_Points = (int)CH1.Data_Points;
                CH1_Info = CH1.Channel_Info;
            }
            else if (CH2_Valid)
            {
                Total_Time = Axis_Scale_Config.Value_SI_Prefix(CH2.Total_Time, 4) + "s";
                Start_Time = Axis_Scale_Config.Value_SI_Prefix(CH2.Start_Time, 4) + "s";
                Stop_Time = Axis_Scale_Config.Value_SI_Prefix(CH2.Stop_Time, 4) + "s";
                Data_Points = (int)CH2.Data_Points;
                CH2_Info = CH2.Channel_Info;
            }
            else if (CH3_Valid)
            {
                Total_Time = Axis_Scale_Config.Value_SI_Prefix(CH3.Total_Time, 4) + "s";
                Start_Time = Axis_Scale_Config.Value_SI_Prefix(CH3.Start_Time, 4) + "s";
                Stop_Time = Axis_Scale_Config.Value_SI_Prefix(CH3.Stop_Time, 4) + "s";
                Data_Points = (int)CH3.Data_Points;
                CH3_Info = CH3.Channel_Info;
            }
            else if (CH4_Valid)
            {
                Total_Time = Axis_Scale_Config.Value_SI_Prefix(CH4.Total_Time, 4) + "s";
                Start_Time = Axis_Scale_Config.Value_SI_Prefix(CH4.Start_Time, 4) + "s";
                Stop_Time = Axis_Scale_Config.Value_SI_Prefix(CH4.Stop_Time, 4) + "s";
                Data_Points = (int)CH4.Data_Points;
                CH4_Info = CH4.Channel_Info;
            }

            if (CH1_Valid)
            {
                CH1_Info = CH1.Channel_Info;
            }
            else
            {
                CH1_Info = "Empty";
            }

            if (CH2_Valid)
            {
                CH2_Info = CH2.Channel_Info;
            }
            else
            {
                CH2_Info = "Empty";
            }

            if (CH3_Valid)
            {
                CH3_Info = CH3.Channel_Info;
            }
            else
            {
                CH3_Info = "Empty";
            }

            if (CH4_Valid)
            {
                CH4_Info = CH4.Channel_Info;
            }
            else
            {
                CH4_Info = "Empty";
            }

            this.Name = Name;
            this.Date_Time = Date_Time;
        }
        public string Name { get; set; }
        public string Date_Time { get; set; }
        public string Total_Time { get; set; }
        public string Start_Time { get; set; }
        public string Stop_Time { get; set; }
        public int Data_Points { get; set; }
        public bool CH1_Valid { get; set; }
        public bool CH2_Valid { get; set; }
        public bool CH3_Valid { get; set; }
        public bool CH4_Valid { get; set; }

        public string CH1_Info { get; set; }
        public string CH2_Info { get; set; }
        public string CH3_Info { get; set; }
        public string CH4_Info { get; set; }


        public Channel_Waveform_Data CH1 { get; set; }
        public Channel_Waveform_Data CH2 { get; set; }
        public Channel_Waveform_Data CH3 { get; set; }
        public Channel_Waveform_Data CH4 { get; set; }
    }

    public partial class Waveform_Player_Window : INotifyPropertyChanged
    {
        private ObservableCollection<Waveform_Store_Table_Model> Waveform_Data_ = new ObservableCollection<Waveform_Store_Table_Model>();
        public ObservableCollection<Waveform_Store_Table_Model> Waveform_Data
        {
            get
            {
                return Waveform_Data_;
            }
            set
            {
                Waveform_Data_ = value;
                NotifyPropertyChanged("Waveform_Data");
            }
        }

        private Waveform_Store_Table_Model Selected_Waveform_Data_;
        public Waveform_Store_Table_Model Selected_Waveform_Data
        {
            get
            {
                return Selected_Waveform_Data_;
            }
            set
            {
                Selected_Waveform_Data_ = value;
                NotifyPropertyChanged("Selected_Waveform_Data");

            }
        }
    }
}
