using System.Windows.Controls;
using System.Windows.Input;

namespace Histogram_Panel
{
    public partial class Histogram_Panel : UserControl
    {
        private void Graph_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(this);
        }
    }
}
