using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace SCPI_Communication
{
    public partial class SCPI_Communication_Window : MetroWindow
    {
        private bool Send_isBusy = false;

        private void Send_SCPI_Commands_Click(object sender, RoutedEventArgs e)
        {
            if (Send_isBusy == false)
            {
                Send_isBusy = true;
                if (Expression_Verify(SCPI_Expression, false))
                {
                    try
                    {
                        string[] SCPI_Commands = SCPI_Expression.Split('@');
                        for (int i = 0; i < SCPI_Commands.Length; i++)
                        {
                            NX_StarWave.NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(SCPI_Commands[i]);
                            if (SCPI_Commands[i].Contains("?") == false)
                            {
                                insert_Log("[Send]: " + SCPI_Commands[i], 7);
                            }
                        }
                        if (Auto_Save)
                        {
                            Save_Expression_to_Table();
                        }
                        if (Auto_Clear)
                        {
                            Clear_Expression();
                        }
                    }
                    catch (Exception Ex)
                    {
                        Send_isBusy = false;
                        insert_Log(Ex.Message, 1);
                    }
                }
                Send_isBusy = false;
            }
            else
            {
                insert_Log("Send is busy, please wait.", 2);
            }
        }
    }
}
