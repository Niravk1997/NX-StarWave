using MahApps.Metro.Controls;

namespace Histogram
{
    public partial class Histogram_Plotter : MetroWindow
    {
        private double Total_Time;
        private double Start_Time;
        private double Stop_Time;
        private int Data_Points;
        private string Channel_Info;

        private double Bucket_Count;
        private double Data_Count;
        private double LowerBound;
        private double UpperBound;

        private void Information_Tab_Updater()
        {
            Data_Points_Label.Content = Data_Points;
            Channel_Info_Label.Content = Channel_Info;

            DataCount_Label.Content = Data_Count;
            BucketCount_Label.Content = Bucket_Count;
            LowerBound_Label.Content = Axis_Scale_Config.Value_SI_Prefix(LowerBound, 4) + Y_AXIS_Units;
            UpperBound_Label.Content = Axis_Scale_Config.Value_SI_Prefix(UpperBound, 4) + Y_AXIS_Units;
        }
    }
}
