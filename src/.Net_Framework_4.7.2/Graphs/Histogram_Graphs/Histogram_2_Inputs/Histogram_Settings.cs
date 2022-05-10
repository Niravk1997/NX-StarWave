using MahApps.Metro.Controls;

namespace Histogram_2_Input
{
    public partial class Histogram_2_Input_Window : MetroWindow
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
