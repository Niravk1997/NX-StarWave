using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Histogram_Panel
{
    public partial class Histogram_Panel : UserControl
    {
        private void Copy_Command(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                switch (e.Parameter)
                {
                    case "0":

                        break;
                    case "1":
                        Copy_Graph_to_Image();
                        break;
                    default:
                        break;
                }
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception)
            {

            }
        }

        private void Save_Command(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                Save_Graph_to_Image();
            }
            catch (Exception)
            {

            }
        }
    }
}
