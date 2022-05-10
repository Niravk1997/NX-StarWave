using MahApps.Metro.Controls;
using System;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        public NX_StarWave_Window()
        {
            InitializeComponent();
            Initialize_Colors();
            DataContext = this;
            Set_Culture();
            Initialize_Graph_Open_EventHandlers();
            Initialize_GetDataTimer();
            Initialize_DataProcess_Timer();
            getSoftwarePath();
            AutoLoad_Selected_Waveform_Colors_File();
            Initialized_Set_Colors_Dialog();
            Create_Theme_Change_EventHandler();
            ScottPlot.Drawing.GDI.ClearType(true);
        }

        private void getSoftwarePath()
        {
            try
            {
                Communication_Selected.folder_Directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\";
            }
            catch (Exception)
            {
                insert_Log("Failed to get Software's Directory.", 1);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                if (Communication_Selected.is_Communication_Selected == true)
                {
                    if (Communication_Selected.is_VISA_GPIB_Communication_Selected == true)
                    {
                        Tektronix.GPIB_Close();
                    }
                    if (Communication_Selected.is_AR488_Communication_Selected == true)
                    {
                        Tektronix.Serial_Close();
                    }
                }
                System.Windows.Application.Current.Shutdown();
            }
            catch (Exception)
            {

            }
        }

        private void NX_StarWave_Exit(object sender, EventArgs e)
        {
            if (Communication_Selected.is_Communication_Selected == true)
            {
                insert_Log("Instrument is connected to this software. Exit by clicking the Local Exit button.", 2);
            }
            else
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
