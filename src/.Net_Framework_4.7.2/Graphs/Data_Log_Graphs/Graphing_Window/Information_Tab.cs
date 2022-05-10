using MahApps.Metro.Controls;

namespace Channel_DataLogger
{
    public partial class CH_DataLog_Graph_Window : MetroWindow
    {
        //Information Tab Variables
        private int Total_Samples = 0;
        private int Positive_Samples = 0;
        private int Negative_Samples = 0;
        private double Latest_Sample = 0;
        private double Max_Recorded_Sample = double.MinValue;
        private double Min_Recorded_Sample = double.MaxValue;
        //Variables related to the moving average
        private double Moving_Average = 0;
        private int Moving_average_count = 0;
        private int Moving_average_factor = 50;
        private int Moving_average_resolution = 8;
    }
}
