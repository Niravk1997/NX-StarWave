using MahApps.Metro.Controls;
using System;
using System.Windows.Input;

namespace Compare_YT
{
    public partial class Compare_YT_Plots : MetroWindow
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
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Paste_Command(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                Paste_Reference_Waveform();
                System.Media.SystemSounds.Beep.Play();
                Graph.Plot.AxisAuto();
                Graph.Refresh();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Command(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                Save_Graph_to_Image();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }
    }
}
