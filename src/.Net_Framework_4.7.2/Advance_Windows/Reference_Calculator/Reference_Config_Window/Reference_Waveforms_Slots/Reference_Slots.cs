using MahApps.Metro.Controls;
using System.Windows.Media;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private Brush Reference_Slot_Status_Valid = (SolidColorBrush)new BrushConverter().ConvertFromString("#00CE30");
        private Brush Reference_Slot_Status_InValid = Brushes.White;

        private void Initialize_Reference_Slots()
        {
            Reference_Slot_Status_Valid.Freeze();
            Reference_Slot_Status_InValid.Freeze();
        }
    }
}
