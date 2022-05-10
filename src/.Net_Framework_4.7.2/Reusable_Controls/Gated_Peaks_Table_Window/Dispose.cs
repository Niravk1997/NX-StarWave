using MahApps.Metro.Controls;
using System;

namespace Gated_Peaks_Table
{
    public partial class Gated_Peaks_Table_Window : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
