using MahApps.Metro.Controls;
using System;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Close_Graph_Panel();
                Reset_Measurements(100);
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
