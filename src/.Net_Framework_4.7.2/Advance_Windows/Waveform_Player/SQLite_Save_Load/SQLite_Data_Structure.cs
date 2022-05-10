using MahApps.Metro.Controls;

namespace Waveform_Player
{
    public class SQLite_Waveform_Data_Structure
    {
        public SQLite_Waveform_Data_Structure(string Name, string Date_Time, double Total_Time, int Data_Points
            , bool CH1_Valid, double CH1_Start_Time, double CH1_Stop_Time, string CH1_YValues, string CH1_Info
            , bool CH2_Valid, double CH2_Start_Time, double CH2_Stop_Time, string CH2_YValues, string CH2_Info
            , bool CH3_Valid, double CH3_Start_Time, double CH3_Stop_Time, string CH3_YValues, string CH3_Info
            , bool CH4_Valid, double CH4_Start_Time, double CH4_Stop_Time, string CH4_YValues, string CH4_Info)
        {
            this.Name = Name;
            this.Date_Time = Date_Time;
            this.Total_Time = Total_Time;
            this.Data_Points = Data_Points;

            this.CH1_Valid = CH1_Valid;
            this.CH1_Start_Time = CH1_Start_Time;
            this.CH1_Stop_Time = CH1_Stop_Time;
            this.CH1_YValues = CH1_YValues;
            this.CH1_Info = CH1_Info;

            this.CH2_Valid = CH2_Valid;
            this.CH2_Start_Time = CH2_Start_Time;
            this.CH2_Stop_Time = CH2_Stop_Time;
            this.CH2_YValues = CH2_YValues;
            this.CH2_Info = CH2_Info;

            this.CH3_Valid = CH3_Valid;
            this.CH3_Start_Time = CH3_Start_Time;
            this.CH3_Stop_Time = CH3_Stop_Time;
            this.CH3_YValues = CH3_YValues;
            this.CH3_Info = CH3_Info;

            this.CH4_Valid = CH4_Valid;
            this.CH4_Start_Time = CH4_Start_Time;
            this.CH4_Stop_Time = CH4_Stop_Time;
            this.CH4_YValues = CH4_YValues;
            this.CH4_Info = CH4_Info;
        }

        public string Name { get; set; }
        public string Date_Time { get; set; }
        public double Total_Time { get; set; }
        public int Data_Points { get; set; }

        public bool CH1_Valid { get; set; }
        public double CH1_Start_Time { get; set; }
        public double CH1_Stop_Time { get; set; }
        public string CH1_YValues { get; set; }
        public string CH1_Info { get; set; }

        public bool CH2_Valid { get; set; }
        public double CH2_Start_Time { get; set; }
        public double CH2_Stop_Time { get; set; }
        public string CH2_YValues { get; set; }
        public string CH2_Info { get; set; }

        public bool CH3_Valid { get; set; }
        public double CH3_Start_Time { get; set; }
        public double CH3_Stop_Time { get; set; }
        public string CH3_YValues { get; set; }
        public string CH3_Info { get; set; }

        public bool CH4_Valid { get; set; }
        public double CH4_Start_Time { get; set; }
        public double CH4_Stop_Time { get; set; }
        public string CH4_YValues { get; set; }
        public string CH4_Info { get; set; }
    }

    public partial class Waveform_Player_Window : MetroWindow
    {
        private string Waveform_Create_Table = "CREATE TABLE Waveforms (Name TEXT, Date_Time DATETIME, Total_Time DOUBLE, Data_Points INTEGER, CH1_Valid BOOLEAN, CH1_Start_Time DOUBLE, CH1_Stop_Time DOUBLE, CH1_YValues TEXT, CH1_Info TEXT, CH2_Valid BOOLEAN, CH2_Start_Time DOUBLE, CH2_Stop_Time DOUBLE, CH2_YValues TEXT, CH2_Info TEXT, CH3_Valid BOOLEAN, CH3_Start_Time DOUBLE, CH3_Stop_Time DOUBLE, CH3_YValues TEXT, CH3_Info TEXT, CH4_Valid BOOLEAN, CH4_Start_Time DOUBLE, CH4_Stop_Time DOUBLE, CH4_YValues TEXT, CH4_Info TEXT)";
    }
}
