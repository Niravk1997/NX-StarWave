namespace Interpolations
{
    public partial class Waveform_Interpolations
    {
        internal int Interpolation_Type { get; set; }

        public Waveform_Interpolations(int Interpolation_Type)
        {
            this.Interpolation_Type = Interpolation_Type;
        }

        internal (double[], double[]) Interpolation_Results(double[] X, double[] Y, int Resampling_Factor, double Start_Time, double Stop_Time, int Original_Data_Points)
        {
            switch (Interpolation_Type)
            {
                case 0:
                    return LinearSpline_Interpolation(X, Y, Resampling_Factor, Start_Time, Stop_Time, Original_Data_Points);
                case 1:
                    return CubicSpline_Interpolation(X, Y, Resampling_Factor, Start_Time, Stop_Time, Original_Data_Points);
                case 2:
                    return Sinc_Interpolation(X, Y, Resampling_Factor, Start_Time, Stop_Time, Original_Data_Points);
                default:
                    return (null, null);
            }
        }

        private double[] Linspace(double Start_Value, double Stop_Value, int Length)
        {
            double Step = (Stop_Value - Start_Value) / (Length - 1.00);
            double[] Array = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                Array[i] = Start_Value + Step * i;
            }
            return Array;
        }
    }
}
