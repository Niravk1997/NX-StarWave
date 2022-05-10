namespace NX_StarWave.Waveform_Model_Classes
{
    public class Remote_Channel_Waveform_Model_Class
    {
        public Remote_Channel_Waveform_Model_Class(int Channel_ID, double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info, double[] Waveform_X_Data, double[] Waveform_Y_Data)
        {
            this.Channel_ID = Channel_ID;
            this.Total_Time = Total_Time;
            this.Start_Time = Start_Time;
            this.Stop_Time = Stop_Time;
            this.Data_Points = Data_Points;
            this.Channel_Info = Channel_Info;
            this.Waveform_Y_Data = Waveform_Y_Data;
            this.Waveform_X_Data = Waveform_X_Data;
        }

        public int Channel_ID { get; set; }
        public double Total_Time { get; set; }
        public double Start_Time { get; set; }
        public double Stop_Time { get; set; }
        public int Data_Points { get; set; }
        public string Channel_Info { get; set; }
        public double[] Waveform_X_Data { get; set; }
        public double[] Waveform_Y_Data { get; set; }
    }
}
