namespace NX_StarWave.Waveform_Model_Classes
{
    public class Channel_Waveform_Data
    {
        public Channel_Waveform_Data(bool Valid, double[] X_Data, double[] Y_Data, double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info)
        {
            this.Valid = Valid;
            this.X_Data = X_Data;
            this.Y_Data = Y_Data;
            this.Total_Time = Total_Time;
            this.Start_Time = Start_Time;
            this.Stop_Time = Stop_Time;
            this.Data_Points = Data_Points;
            this.Channel_Info = Channel_Info;
        }

        public bool Valid { get; set; }
        public double[] X_Data { get; set; }
        public double[] Y_Data { get; set; }
        public double Total_Time { get; set; }
        public double Start_Time { get; set; }
        public double Stop_Time { get; set; }
        public int Data_Points { get; set; }
        public string Channel_Info { get; set; }
    }
}
