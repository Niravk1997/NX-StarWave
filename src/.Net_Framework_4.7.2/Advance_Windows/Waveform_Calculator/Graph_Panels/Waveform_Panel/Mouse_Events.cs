using System.Windows.Controls;
using System.Windows.Input;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private void Graph_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(this);
        }
    }
}
