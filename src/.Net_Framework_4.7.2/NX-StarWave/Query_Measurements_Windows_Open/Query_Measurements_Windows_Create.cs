using MahApps.Metro.Controls;
using Query_Measurement_Control;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Threading;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private Query_Measurement_Window Query_Measurement_Window_1;
        private Query_Measurement_Window Query_Measurement_Window_2;
        private Query_Measurement_Window Query_Measurement_Window_3;
        private Query_Measurement_Window Query_Measurement_Window_4;
        private Query_Measurement_Window Query_Measurement_Window_5;
        private Query_Measurement_Window Query_Measurement_Window_6;
        private Query_Measurement_Window Query_Measurement_Window_7;
        private Query_Measurement_Window Query_Measurement_Window_8;
        private Query_Measurement_Window Query_Measurement_Window_9;
        private Query_Measurement_Window Query_Measurement_Window_10;

        private bool Query_Measurement_Window_1_isOpen = false;
        private bool Query_Measurement_Window_2_isOpen = false;
        private bool Query_Measurement_Window_3_isOpen = false;
        private bool Query_Measurement_Window_4_isOpen = false;
        private bool Query_Measurement_Window_5_isOpen = false;
        private bool Query_Measurement_Window_6_isOpen = false;
        private bool Query_Measurement_Window_7_isOpen = false;
        private bool Query_Measurement_Window_8_isOpen = false;
        private bool Query_Measurement_Window_9_isOpen = false;
        private bool Query_Measurement_Window_10_isOpen = false;

        private int Query_Measurement_Windows_Open = 0;

        public void Open_Query_Measurement_Windows(string Window_Title, string SCPI_Command, string Output_Result_String_Cut_Start, string Output_Result_String_Cut_Stop, string Measurement_Units, double SCPI_Send_Delay, string Label_Colour, string Background_Color, bool isBackground_Transparent)
        {
            try
            {
                if (Query_Measurement_Window_1 == null & Query_Measurement_Window_1_isOpen == false)
                {
                    Query_Measurement_Window_1_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_1 = new Query_Measurement_Window(1, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_1.Show();
                        Query_Measurement_Window_1.Closed += Query_Measurement_Window_1_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else if (Query_Measurement_Window_2 == null & Query_Measurement_Window_2_isOpen == false)
                {
                    Query_Measurement_Window_2_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_2 = new Query_Measurement_Window(2, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_2.Show();
                        Query_Measurement_Window_2.Closed += Query_Measurement_Window_2_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else if (Query_Measurement_Window_3 == null & Query_Measurement_Window_3_isOpen == false)
                {
                    Query_Measurement_Window_3_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_3 = new Query_Measurement_Window(3, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_3.Show();
                        Query_Measurement_Window_3.Closed += Query_Measurement_Window_3_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else if (Query_Measurement_Window_4 == null & Query_Measurement_Window_4_isOpen == false)
                {
                    Query_Measurement_Window_4_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_4 = new Query_Measurement_Window(4, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_4.Show();
                        Query_Measurement_Window_4.Closed += Query_Measurement_Window_4_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else if (Query_Measurement_Window_5 == null & Query_Measurement_Window_5_isOpen == false)
                {
                    Query_Measurement_Window_5_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_5 = new Query_Measurement_Window(5, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_5.Show();
                        Query_Measurement_Window_5.Closed += Query_Measurement_Window_5_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else if (Query_Measurement_Window_6 == null & Query_Measurement_Window_6_isOpen == false)
                {
                    Query_Measurement_Window_6_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_6 = new Query_Measurement_Window(6, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_6.Show();
                        Query_Measurement_Window_6.Closed += Query_Measurement_Window_6_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else if (Query_Measurement_Window_7 == null & Query_Measurement_Window_7_isOpen == false)
                {
                    Query_Measurement_Window_7_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_7 = new Query_Measurement_Window(7, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_7.Show();
                        Query_Measurement_Window_7.Closed += Query_Measurement_Window_7_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else if (Query_Measurement_Window_8 == null & Query_Measurement_Window_8_isOpen == false)
                {
                    Query_Measurement_Window_8_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_8 = new Query_Measurement_Window(8, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_8.Show();
                        Query_Measurement_Window_8.Closed += Query_Measurement_Window_8_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else if (Query_Measurement_Window_9 == null & Query_Measurement_Window_9_isOpen == false)
                {
                    Query_Measurement_Window_9_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_9 = new Query_Measurement_Window(9, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_9.Show();
                        Query_Measurement_Window_9.Closed += Query_Measurement_Window_9_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else if (Query_Measurement_Window_10 == null & Query_Measurement_Window_10_isOpen == false)
                {
                    Query_Measurement_Window_10_isOpen = true;
                    Query_Measurement_Windows_Open++;
                    Thread Window_Thread = new Thread(new ThreadStart(() =>
                    {
                        Query_Measurement_Window_10 = new Query_Measurement_Window(10, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent, true);
                        Query_Measurement_Window_10.Show();
                        Query_Measurement_Window_10.Closed += Query_Measurement_Window_10_Close;
                        Dispatcher.Run();
                    }));
                    Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                    Window_Thread.SetApartmentState(ApartmentState.STA);
                    Window_Thread.IsBackground = true;
                    Window_Thread.Start();
                    insert_Log("Query Measurement Windows Opened (" + Query_Measurement_Windows_Open + " of 10).", 5);
                }
                else
                {
                    insert_Log("Could not create a Query Measurement Window, limit reached.", 2);
                    insert_Log("Close a Query Measurement window to create a new one.", 2);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Could not open a Query Measurement Window.", 1);
            }
        }

        private void Query_Measurement_Window_1_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_1.Closed -= Query_Measurement_Window_1_Close;
            Query_Measurement_Window_1.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_1 = null;
            Query_Measurement_Window_1_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 1 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);

        }

        private void Query_Measurement_Window_2_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_2.Closed -= Query_Measurement_Window_2_Close;
            Query_Measurement_Window_2.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_2 = null;
            Query_Measurement_Window_2_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 2 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);
        }

        private void Query_Measurement_Window_3_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_3.Closed -= Query_Measurement_Window_3_Close;
            Query_Measurement_Window_3.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_3 = null;
            Query_Measurement_Window_3_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 3 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);
        }

        private void Query_Measurement_Window_4_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_4.Closed -= Query_Measurement_Window_4_Close;
            Query_Measurement_Window_4.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_4 = null;
            Query_Measurement_Window_4_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 4 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);
        }

        private void Query_Measurement_Window_5_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_5.Closed -= Query_Measurement_Window_5_Close;
            Query_Measurement_Window_5.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_5 = null;
            Query_Measurement_Window_5_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 5 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);
        }

        private void Query_Measurement_Window_6_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_6.Closed -= Query_Measurement_Window_6_Close;
            Query_Measurement_Window_6.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_6 = null;
            Query_Measurement_Window_6_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 6 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);
        }

        private void Query_Measurement_Window_7_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_7.Closed -= Query_Measurement_Window_7_Close;
            Query_Measurement_Window_7.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_7 = null;
            Query_Measurement_Window_7_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 7 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);
        }

        private void Query_Measurement_Window_8_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_8.Closed -= Query_Measurement_Window_8_Close;
            Query_Measurement_Window_8.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_8 = null;
            Query_Measurement_Window_8_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 8 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);
        }

        private void Query_Measurement_Window_9_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_9.Closed -= Query_Measurement_Window_9_Close;
            Query_Measurement_Window_9.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_9 = null;
            Query_Measurement_Window_9_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 9 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);
        }

        private void Query_Measurement_Window_10_Close(object sender, EventArgs e)
        {
            Query_Measurement_Window_10.Closed -= Query_Measurement_Window_10_Close;
            Query_Measurement_Window_10.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Query_Measurement_Window_10 = null;
            Query_Measurement_Window_10_isOpen = false;
            Query_Measurement_Windows_Open--;
            insert_Log("Query Measurement Window 10 Closed", 0);
            insert_Log("Total Query Measurement Windows Active: " + Query_Measurement_Windows_Open, 5);
        }
    }
}
