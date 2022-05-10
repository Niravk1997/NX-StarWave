using MahApps.Metro.Controls;
using NX_StarWave;
using System;
using System.Windows;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : MetroWindow
    {
        private bool LoadSelected_isBusy = false;

        private void Load_Selected_SCPI_Commands_Click(object sender, RoutedEventArgs e)
        {
            Load_Selected_SCPI_Commands();
        }

        private void Load_Selected_SCPI_Commands()
        {
            if (LoadSelected_isBusy == false)
            {
                LoadSelected_isBusy = true;
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        foreach (SCPI_Command_Data Command in SCPI_Command_Table)
                        {
                            if (Command.SCPI_Command_Selected)
                            {
                                ((NX_StarWave_Window)Application.Current.MainWindow).Open_Query_Measurement_Windows(Command.SCPI_Command_Title, Command.SCPI_Command, Command.Result_Start_Cut_String, Command.Result_Stop_Cut_String, Command.Measurement_units, Command.Query_Delay, Command.Text_Color, Command.Background_Color, Command.isBackground_Transparent);
                            }
                        }
                        LoadSelected_isBusy = false;
                    }
                    catch (Exception Ex)
                    {
                        LoadSelected_isBusy = false;
                        insert_Log(Ex.Message, 1);
                    }
                }));
            }
            else
            {
                insert_Log("Load Selected Commands is busy, please wait.", 2);
            }
        }

        private void Clear_Table_Click(object sender, RoutedEventArgs e)
        {
            Clear_Table();
        }

        private void Clear_Table()
        {
            try
            {
                SCPI_Command_Table.Clear();
            }
            catch (Exception) { }
        }
    }
}
