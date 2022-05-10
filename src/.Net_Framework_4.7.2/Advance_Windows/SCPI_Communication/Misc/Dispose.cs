using MahApps.Metro.Controls;
using System;

namespace SCPI_Communication
{
    public partial class SCPI_Communication_Window : MetroWindow
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
