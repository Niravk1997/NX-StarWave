using System.Windows.Controls;
using System.Windows.Input;

namespace FFT_Panel
{
    public partial class FFT_Panel : UserControl
    {
        private void Graph_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(this);
        }
    }
}
