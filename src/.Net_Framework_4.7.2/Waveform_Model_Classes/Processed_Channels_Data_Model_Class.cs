namespace NX_StarWave.Waveform_Model_Classes
{
    public class Processed_Channels_Data
    {
        public Processed_Channels_Data(bool CH1_Valid, bool CH2_Valid, bool CH3_Valid, bool CH4_Valid, double[] CH1_Data, double[] CH2_Data, double[] CH3_Data, double[] CH4_Data, double[] Time_Data, int Data_Points, double Total_Time, double Start_Time, double Stop_Time, string Channel_Info)
        {
            this.CH1_Valid = CH1_Valid;
            this.CH2_Valid = CH2_Valid;
            this.CH3_Valid = CH3_Valid;
            this.CH4_Valid = CH4_Valid;

            this.CH1_Data = CH1_Data;
            this.CH2_Data = CH2_Data;
            this.CH3_Data = CH3_Data;
            this.CH4_Data = CH4_Data;
            this.Time_Data = Time_Data;

            this.Data_Points = Data_Points;
            this.Total_Time = Total_Time;
            this.Start_Time = Start_Time;
            this.Stop_Time = Stop_Time;
            this.Channel_Info = Channel_Info;
        }

        public bool CH1_Valid { get; set; }
        public bool CH2_Valid { get; set; }
        public bool CH3_Valid { get; set; }
        public bool CH4_Valid { get; set; }

        public double[] CH1_Data { get; set; }
        public double[] CH2_Data { get; set; }
        public double[] CH3_Data { get; set; }
        public double[] CH4_Data { get; set; }
        public double[] Time_Data { get; set; }

        public int Data_Points { get; set; }
        public double Total_Time { get; set; }
        public double Start_Time { get; set; }
        public double Stop_Time { get; set; }
        public string Channel_Info { get; set; }
    }
}
