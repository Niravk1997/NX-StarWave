using MahApps.Metro.Controls;
using System;
using System.Threading;
using System.Windows;

namespace SCPI_Communication
{
    public partial class SCPI_Communication_Window : MetroWindow
    {
        private bool LoadSelected_isBusy = false;

        private void Load_Selected_SCPI_Expressions_Click(object sender, RoutedEventArgs e)
        {
            Load_Selected_SCPI_Expressions();
        }

        private void Load_Selected_SCPI_Expressions()
        {
            if (LoadSelected_isBusy == false)
            {
                LoadSelected_isBusy = true;
                ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        for (int i = 0; i < SCPI_Expression_Table.Count; i++)
                        {
                            SCPI_Expression_Data Expression = SCPI_Expression_Table[i];
                            if (Expression.SCPI_Expression_Selected & Expression_Verify(Expression.SCPI_Expression, false))
                            {
                                NX_StarWave.NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Expression.SCPI_Expression);
                                if (Expression.SCPI_Expression.Contains("?") == false)
                                {
                                    insert_Log("[Send]: " + Expression.SCPI_Expression, 7);
                                }
                            }
                        }
                        LoadSelected_isBusy = false;
                    }
                    catch (Exception Ex)
                    {
                        LoadSelected_isBusy = false;
                        insert_Log(Ex.Message, 1);
                    }
                }, null);
            }
            else
            {
                insert_Log("Load Selected Expressions is busy, please wait.", 2);
            }
        }
    }
}
