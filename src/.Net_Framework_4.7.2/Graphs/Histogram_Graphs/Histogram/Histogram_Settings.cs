using MahApps.Metro.Controls;

namespace Histogram
{
    public partial class Histogram_Plotter : MetroWindow
    {
        private string Histogram_Value_above_Bars_Format(double Value)
        {
            if (Value == 0)
            {
                return "";
            }
            else
            {
                return Axis_Scale_Config.Value_SI_Prefix_NoSafety_NoRounding(Value);
            }
        }
    }
}
