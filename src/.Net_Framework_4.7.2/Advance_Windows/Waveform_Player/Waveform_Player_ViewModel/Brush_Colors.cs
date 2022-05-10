using MahApps.Metro.Controls;
using System.Windows.Media;

namespace Waveform_Player
{
    public partial class Waveform_Player_Window : MetroWindow
    {
        private Brush Color_Status_Success = (SolidColorBrush)new BrushConverter().ConvertFromString("#00CE30");
        private Brush Color_Status_Error = Brushes.Red;
        private Brush Color_Status_Warning = Brushes.Yellow;
        private Brush Color_Status_Idle = Brushes.Transparent;
        private Brush Color_Status_Active = Brushes.Orange;

        private void Initialize_Brush_Colors()
        {
            Color_Status_Success.Freeze();
            Color_Status_Error.Freeze();
            Color_Status_Warning.Freeze();
            Color_Status_Idle.Freeze();
        }
    }
}
