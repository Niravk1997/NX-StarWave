namespace Node_Model_Classes
{
    public class Node_Waveform_Model
    {
        public Node_Waveform_Model(int Unique_ID, int Data_points, double Total_Time, double Start_Time, double Stop_Time, double[] X_Values, double[] Y_Values, string Units)
        {
            this.Unique_ID = Unique_ID;
            this.Data_points = Data_points;
            this.Total_Time = Total_Time;
            this.Start_Time = Start_Time;
            this.Stop_Time = Stop_Time;
            this.X_Values = X_Values;
            this.Y_Values = Y_Values;
            this.Units = Units;
        }

        public int Unique_ID { get; set; }
        public int Data_points { get; set; }
        public double Total_Time { get; set; }
        public double Start_Time { get; set; }
        public double Stop_Time { get; set; }
        public double[] X_Values { get; set; }
        public double[] Y_Values { get; set; }
        public string Units { get; set; }
    }
}
