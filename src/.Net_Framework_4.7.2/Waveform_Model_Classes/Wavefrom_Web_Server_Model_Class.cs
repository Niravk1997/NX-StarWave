namespace NX_StarWave.Waveform_Model_Classes
{
    public class Wavefrom_Web_Server_Model_Class
    {
        public Wavefrom_Web_Server_Model_Class(bool Valid, int Counter, int Data_Points, double Total_Time, double Start_Time, double Stop_Time, string Channel_Info, double[] Waveform_Y_Data)
        {
            this.Valid = Valid;
            this.Counter = Counter;
            this.Data_Points = Data_Points;
            this.Total_Time = Total_Time;
            this.Start_Time = Start_Time;
            this.Stop_Time = Stop_Time;
            this.Channel_Info = Channel_Info;
            this.Waveform_Y_Data = Waveform_Y_Data;
        }

        public bool Valid { get; set; }
        public int Counter { get; set; }
        public int Data_Points { get; set; }
        public double Total_Time { get; set; }
        public double Start_Time { get; set; }
        public double Stop_Time { get; set; }
        public string Channel_Info { get; set; }
        public double[] Waveform_Y_Data { get; set; }
    }
}
