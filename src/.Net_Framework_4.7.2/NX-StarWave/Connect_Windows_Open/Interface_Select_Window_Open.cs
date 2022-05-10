using MahApps.Metro.Controls;
using NX_StarWave.Serial_Communication;
using NX_StarWave.VISA_GPIB_Communication;
using System;
using System.Windows;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        //COM Select Window
        private COM_Select_Window COM_Select;
        private VISA_GPIB_Select_Window VISA_Select;

        private void AR488_Connect_Click(object sender, RoutedEventArgs e)
        {
            if (COM_Select == null)
            {
                COM_Select = new COM_Select_Window();
                COM_Select.Closed += COM_Select_Closed_Event;
                COM_Select.Owner = this;
                if (COM_Select.ShowDialog() == true)
                {

                }
            }
            else
            {
                COM_Select.Show();
                insert_Log("COM Select Window is already open.", 2);
            }
        }

        private void COM_Select_Closed_Event(object sender, EventArgs e)
        {
            COM_Select.Closed -= COM_Select_Closed_Event;
            COM_Select = null;
            Check_Tektronix_Oscilloscope_Connected();
        }

        private void VISA_Connect_Click(object sender, RoutedEventArgs e)
        {
            if (VISA_Select == null)
            {
                VISA_Select = new VISA_GPIB_Select_Window();
                VISA_Select.Closed += VISA_Select_Closed_Event;
                VISA_Select.Owner = this;
                if (VISA_Select.ShowDialog() == true)
                {

                }
            }
            else
            {
                VISA_Select.Show();
                insert_Log("COM Select Window is already open.", 2);
            }
        }

        private void VISA_Select_Closed_Event(object sender, EventArgs e)
        {
            VISA_Select.Closed -= VISA_Select_Closed_Event;
            VISA_Select = null;
            Check_Tektronix_Oscilloscope_Connected();
        }

        private void Check_Tektronix_Oscilloscope_Connected()
        {
            if (Communication_Selected.is_Communication_Selected == true)
            {
                if (Communication_Selected.is_VISA_GPIB_Communication_Selected == true)
                {
                    insert_Log("VISA GPIB Interface Selected.", 0);
                    Connection_Interface_Type = "Visa GPIB";
                    if (Communication_Selected.VISA_GPIB_WFMPre_Curve_Method == true)
                    {
                        insert_Log("Waveform Capture Method 2 Selected.", 0);
                        insert_Log("Waveform Preamble and Curve data will be retrieved using a single read command.", 0);
                        insert_Log("Waveform Capture Size must be 500K or less.", 0);
                    }
                }
                else if (Communication_Selected.is_AR488_Communication_Selected == true)
                {
                    insert_Log("AR488 Interface Selected.", 0);
                    Connection_Interface_Type = "AR488 GPIB";
                }
                Communication_Timer.Enabled = true;
                Connect_VISA.IsEnabled = false;
                Connect_AR488.IsEnabled = false;
                Company_Name = Communication_Selected.Company_Name;
                Oscilloscope_Model = Communication_Selected.Oscilloscope_Model;
                Oscilloscope_Firmware = Communication_Selected.Firmware_Version;
                insert_Log("Tektronix " + Communication_Selected.Oscilloscope_Model + " Oscilloscope Connected.", 0);
                Initialize_Runtime_Timer();
                Tektronix = new Tektronix_Communication();
            }
        }

    }
}
