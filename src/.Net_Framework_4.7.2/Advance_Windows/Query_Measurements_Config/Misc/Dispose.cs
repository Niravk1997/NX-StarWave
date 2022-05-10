using MahApps.Metro.Controls;
using System;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Remove_Create_Theme_Change_EventHandler();
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
