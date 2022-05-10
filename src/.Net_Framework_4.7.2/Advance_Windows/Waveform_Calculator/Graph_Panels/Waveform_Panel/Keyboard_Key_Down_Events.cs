using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private void Copy_Command(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                switch (e.Parameter)
                {
                    case "0":
                        Copy_Reference_Data_Clipboard();
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

        private void Paste_Command(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                Paste_Data_Clipboard(0);
                System.Media.SystemSounds.Beep.Play();
                Graph.Plot.AxisAuto();
                Graph.Refresh();
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
