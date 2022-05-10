using MahApps.Metro.Controls;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private Brush Graph_Selected = (SolidColorBrush)new BrushConverter().ConvertFromString("#00CE30");
        private Brush Graph_Not_Selected = Brushes.Transparent;

        private void Initialize_Colors()
        {
            Graph_Selected.Freeze();
            Graph_Not_Selected.Freeze();
        }
    }
}
