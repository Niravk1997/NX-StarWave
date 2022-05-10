namespace NX_StarWave.Waveform_Model_Classes
{
    public class Reference_Waveform
    {
        public Reference_Waveform(double[] Waveform_Y_Data, int Data_Points, double Total_Time, double Start_Time, double Stop_Time, string Channel_Info, string Waveform_Color)
        {
            this.Waveform_Y_Data = Waveform_Y_Data;
            this.Data_Points = Data_Points;
            this.Total_Time = Total_Time;
            this.Start_Time = Start_Time;
            this.Stop_Time = Stop_Time;
            this.Channel_Info = Channel_Info;
            this.Waveform_Color = Waveform_Color;
        }

        public double[] Waveform_Y_Data { get; set; }
        public int Data_Points { get; set; }
        public double Total_Time { get; set; }
        public double Start_Time { get; set; }
        public double Stop_Time { get; set; }
        public string Channel_Info { get; set; }
        public string Waveform_Color { get; set; }
    }
}
