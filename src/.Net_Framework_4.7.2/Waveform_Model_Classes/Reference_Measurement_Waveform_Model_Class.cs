namespace NX_StarWave.Waveform_Model_Classes
{
    public class Reference_Measurement_Waveform
    {
        public Reference_Measurement_Waveform(double[] Date_Time, double[] Measurement_Data, int Measurement_Data_Count, string Measurement_Label, string Measurement_Units, string Measurement_Color)
        {
            this.Date_Time = Date_Time;
            this.Measurement_Data = Measurement_Data;
            this.Measurement_Data_Count = Measurement_Data_Count;
            this.Measurement_Label = Measurement_Label;
            this.Measurement_Units = Measurement_Units;
            this.Measurement_Color = Measurement_Color;
        }

        public double[] Date_Time { get; set; }
        public double[] Measurement_Data { get; set; }
        public int Measurement_Data_Count { get; set; }
        public string Measurement_Label { get; set; }
        public string Measurement_Units { get; set; }
        public string Measurement_Color { get; set; }
    }
}
