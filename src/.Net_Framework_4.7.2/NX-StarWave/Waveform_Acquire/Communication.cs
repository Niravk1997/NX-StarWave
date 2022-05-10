using MahApps.Metro.Controls;
using MathNet.Numerics.Statistics;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private Tektronix_Communication Tektronix;

        private System.Timers.Timer Communication_Timer;

        //All Serial Write Commands are stored in this queue, this queue can be accessed by any windows. warning it is static
        public static BlockingCollection<string> Tektronix_SendCommands_Queue = new BlockingCollection<string>();

        private int Get_CH1_Data = 0;

        private int Get_CH2_Data = 0;

        private int Get_CH3_Data = 0;

        private int Get_CH4_Data = 0;

        private int Acquire_Waveform_Data = 2;
        private bool Acquire_Run_Stop = false;
        private bool Acquire_Run_Stop_Disabled = false;

        private double Acquire_Interval_Value = 1000;
        private bool Acquire_Interval_Value_Changed = false;
        private Stopwatch Acquire_Interval;

        //Solid Colors
        private Brush Color_Status_Success = (SolidColorBrush)new BrushConverter().ConvertFromString("#00CE30");
        private Brush Color_Status_Error = Brushes.Red;
        private Brush Color_Status_Warning = Brushes.Yellow;
        private Brush Color_Status_Idle = Brushes.Black;
        private Brush Color_Status_NotSelected = Brushes.Transparent;

        //Benchmark Variables
        private List<double> Benchmark_Values = new List<double>();


        private void Initialize_GetDataTimer()
        {
            Acquire_Interval = new Stopwatch();
            Acquire_Interval.Start();

            Communication_Timer = new Timer();
            Communication_Timer.Interval = 1;
            Communication_Timer.Elapsed += Tektronix_Communicate_Timer;
            Communication_Timer.AutoReset = false;
            Communication_Timer.Enabled = false;

            Color_Status_Success.Freeze();
            Color_Status_Error.Freeze();
            Color_Status_Warning.Freeze();
            Color_Status_Idle.Freeze();
            Color_Status_NotSelected.Freeze();
        }

        private void Tektronix_Communicate_Timer(Object source, ElapsedEventArgs e)
        {
            do
            {
                Tektronix_SendCommands();

                if (Acquire_Interval.Elapsed.TotalMilliseconds >= Acquire_Interval_Value)
                {
                    Acquire_Interval.Restart();
                    if (Acquire_Waveform_Data == 1 || Acquire_Waveform_Data == 2)
                    {
                        int Waveform_Data_Collected_Counter = 0;

                        bool CH1_Valid = false;
                        string CH1_WFMPre = "";
                        List<byte> CH1_Curve = null;

                        bool CH2_Valid = false;
                        string CH2_WFMPre = "";
                        List<byte> CH2_Curve = null;

                        bool CH3_Valid = false;
                        string CH3_WFMPre = "";
                        List<byte> CH3_Curve = null;

                        bool CH4_Valid = false;
                        string CH4_WFMPre = "";
                        List<byte> CH4_Curve = null;

                        if (Acquire_Run_Stop == true)
                        {
                            try
                            {
                                Tektronix.WriteCommand("ACQuire:STATE STOP");
                            }
                            catch (Exception)
                            {
                                insert_Log("Failed to send Acquire State Stop Command, check connection.", 1);
                            }
                        }

                        if (Show_Benchmarks)
                        {
                            Benchmark_Timer.Start();
                        }

                        if (Get_CH1_Data == 1 || Get_CH1_Data == 2)
                        {
                            try
                            {
                                Tektronix.WriteCommand("DATa:SOUrce CH1");
                                if (Communication_Selected.VISA_GPIB_WFMPre_Curve_Method)
                                {
                                    (CH1_WFMPre, CH1_Curve, CH1_Valid) = Tektronix.Read_WFMPre_CURVE_VISA();
                                    if (CH1_Valid)
                                    {
                                        CH1_Status_Color = Color_Status_Success;
                                        Waveform_Data_Collected_Counter++;
                                        CH1_Counter_Value++;
                                    }
                                    else
                                    {
                                        CH1_Status_Color = Color_Status_Warning;
                                    }
                                }
                                else
                                {
                                    Tektronix.WriteCommand("WFMPre?");
                                    CH1_WFMPre = Tektronix.ReadASCII();
                                    if (CH1_WFMPre.Length < 100)
                                    {
                                        CH1_Status_Color = Color_Status_Warning;
                                        insert_Log("Channel 1: no waveform data received. Make sure channel 1 is enabled.", 2);
                                    }
                                    else
                                    {
                                        if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
                                        {
                                            CH1_Curve = Tektronix.Read_CURVE_VISA(Waveform_Data.Curve_Expected_Bytes_Quick(CH1_WFMPre));
                                        }
                                        else
                                        {
                                            CH1_Curve = Tektronix.Read_CURVE_AR488(Waveform_Data.Curve_Expected_Bytes_Quick(CH1_WFMPre));
                                        }
                                        CH1_Valid = true;
                                        CH1_Status_Color = Color_Status_Success;
                                        Waveform_Data_Collected_Counter++;
                                        CH1_Counter_Value++;
                                    }
                                }
                                if (Show_Captured_Waveform_Preamble)
                                {
                                    insert_Log(CH1_WFMPre, 8);
                                }
                            }
                            catch (Exception)
                            {
                                CH1_Status_Color = Color_Status_Error;
                                insert_Log("Channel 1: Communication failure. Check connection.", 1);
                            }
                            if (Get_CH1_Data == 1)
                            {
                                Get_CH1_Data = 0;
                                CH1_Acquire_Mode = 0;
                            }
                        }
                        else
                        {
                            CH1_Status_Color = Color_Status_Idle;
                        }

                        if (Get_CH2_Data == 1 || Get_CH2_Data == 2)
                        {

                            try
                            {
                                Tektronix.WriteCommand("DATa:SOUrce CH2");
                                if (Communication_Selected.VISA_GPIB_WFMPre_Curve_Method)
                                {
                                    (CH2_WFMPre, CH2_Curve, CH2_Valid) = Tektronix.Read_WFMPre_CURVE_VISA();
                                    if (CH2_Valid)
                                    {
                                        CH2_Status_Color = Color_Status_Success;
                                        Waveform_Data_Collected_Counter++;
                                        CH2_Counter_Value++;
                                    }
                                    else
                                    {
                                        CH2_Status_Color = Color_Status_Warning;
                                    }
                                }
                                else
                                {
                                    Tektronix.WriteCommand("WFMPre?");
                                    CH2_WFMPre = Tektronix.ReadASCII();
                                    if (CH2_WFMPre.Length < 100)
                                    {
                                        CH2_Status_Color = Color_Status_Warning;
                                        insert_Log("Channel 2: no waveform data received. Make sure channel 2 is enabled.", 2);
                                    }
                                    else
                                    {
                                        if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
                                        {
                                            CH2_Curve = Tektronix.Read_CURVE_VISA(Waveform_Data.Curve_Expected_Bytes_Quick(CH2_WFMPre));
                                        }
                                        else
                                        {
                                            CH2_Curve = Tektronix.Read_CURVE_AR488(Waveform_Data.Curve_Expected_Bytes_Quick(CH2_WFMPre));
                                        }
                                        CH2_Valid = true;
                                        CH2_Status_Color = Color_Status_Success;
                                        Waveform_Data_Collected_Counter++;
                                        CH2_Counter_Value++;
                                    }
                                }
                                if (Show_Captured_Waveform_Preamble)
                                {
                                    insert_Log(CH2_WFMPre, 8);
                                }
                            }
                            catch (Exception)
                            {
                                CH2_Status_Color = Color_Status_Error;
                                insert_Log("Channel 2: Communication failure. Check connection.", 1);
                            }
                            if (Get_CH2_Data == 1)
                            {
                                Get_CH2_Data = 0;
                                CH2_Acquire_Mode = 0;
                            }
                        }
                        else
                        {
                            CH2_Status_Color = Color_Status_Idle;
                        }

                        if (Get_CH3_Data == 1 || Get_CH3_Data == 2)
                        {

                            try
                            {
                                Tektronix.WriteCommand("DATa:SOUrce CH3");
                                if (Communication_Selected.VISA_GPIB_WFMPre_Curve_Method)
                                {
                                    (CH3_WFMPre, CH3_Curve, CH3_Valid) = Tektronix.Read_WFMPre_CURVE_VISA();
                                    if (CH3_Valid)
                                    {
                                        CH3_Status_Color = Color_Status_Success;
                                        Waveform_Data_Collected_Counter++;
                                        CH3_Counter_Value++;
                                    }
                                    else
                                    {
                                        CH3_Status_Color = Color_Status_Warning;
                                    }
                                }
                                else
                                {
                                    Tektronix.WriteCommand("WFMPre?");
                                    CH3_WFMPre = Tektronix.ReadASCII();
                                    if (CH3_WFMPre.Length < 100)
                                    {
                                        CH3_Status_Color = Color_Status_Warning;
                                        insert_Log("Channel 3: no waveform data received. Make sure channel 3 is enabled.", 2);
                                    }
                                    else
                                    {
                                        if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
                                        {
                                            CH3_Curve = Tektronix.Read_CURVE_VISA(Waveform_Data.Curve_Expected_Bytes_Quick(CH3_WFMPre));
                                        }
                                        else
                                        {
                                            CH3_Curve = Tektronix.Read_CURVE_AR488(Waveform_Data.Curve_Expected_Bytes_Quick(CH3_WFMPre));
                                        }
                                        CH3_Valid = true;
                                        CH3_Status_Color = Color_Status_Success;
                                        Waveform_Data_Collected_Counter++;
                                        CH3_Counter_Value++;
                                    }
                                }
                                if (Show_Captured_Waveform_Preamble)
                                {
                                    insert_Log(CH3_WFMPre, 8);
                                }
                            }
                            catch (Exception)
                            {
                                CH3_Status_Color = Color_Status_Error;
                                insert_Log("Channel 3: Communication failure. Check connection.", 1);
                            }
                            if (Get_CH3_Data == 1)
                            {
                                Get_CH3_Data = 0;
                                CH3_Acquire_Mode = 0;
                            }
                        }
                        else
                        {
                            CH3_Status_Color = Color_Status_Idle;
                        }

                        if (Get_CH4_Data == 1 || Get_CH4_Data == 2)
                        {

                            try
                            {
                                Tektronix.WriteCommand("DATa:SOUrce CH4");
                                if (Communication_Selected.VISA_GPIB_WFMPre_Curve_Method)
                                {
                                    (CH4_WFMPre, CH4_Curve, CH4_Valid) = Tektronix.Read_WFMPre_CURVE_VISA();
                                    if (CH4_Valid)
                                    {
                                        CH4_Status_Color = Color_Status_Success;
                                        Waveform_Data_Collected_Counter++;
                                        CH4_Counter_Value++;
                                    }
                                    else
                                    {
                                        CH4_Status_Color = Color_Status_Warning;
                                    }
                                }
                                else
                                {
                                    Tektronix.WriteCommand("WFMPre?");
                                    CH4_WFMPre = Tektronix.ReadASCII();
                                    if (CH4_WFMPre.Length < 100)
                                    {
                                        CH4_Status_Color = Color_Status_Warning;
                                        insert_Log("Channel 4: no waveform data received. Make sure channel 4 is enabled.", 2);
                                    }
                                    else
                                    {
                                        if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
                                        {
                                            CH4_Curve = Tektronix.Read_CURVE_VISA(Waveform_Data.Curve_Expected_Bytes_Quick(CH4_WFMPre));
                                        }
                                        else
                                        {
                                            CH4_Curve = Tektronix.Read_CURVE_AR488(Waveform_Data.Curve_Expected_Bytes_Quick(CH4_WFMPre));
                                        }
                                        CH4_Valid = true;
                                        CH4_Status_Color = Color_Status_Success;
                                        Waveform_Data_Collected_Counter++;
                                        CH4_Counter_Value++;
                                    }
                                }
                                if (Show_Captured_Waveform_Preamble)
                                {
                                    insert_Log(CH4_WFMPre, 8);
                                }
                            }
                            catch (Exception)
                            {
                                CH4_Status_Color = Color_Status_Error;
                                insert_Log("Channel 4: Communication failure. Check connection.", 1);
                            }
                            if (Get_CH4_Data == 1)
                            {
                                Get_CH4_Data = 0;
                                CH4_Acquire_Mode = 0;
                            }
                        }
                        else
                        {
                            CH4_Status_Color = Color_Status_Idle;
                        }

                        if (Show_Benchmarks)
                        {
                            if (Benchmark_Timer.Elapsed.TotalSeconds != 0)
                            {
                                Benchmark_Values.Add(Benchmark_Timer.Elapsed.TotalSeconds);
                                insert_Log("Waveforms Capture Established Time (s): " + Benchmark_Timer.Elapsed.TotalSeconds + " Min Time (s): " + Math.Round(Benchmark_Values.Minimum(), 5) + " Max Time (s): " + Math.Round(Benchmark_Values.Maximum(), 5) + " Mean Time (s): " + Math.Round(Benchmark_Values.Mean(), 5), 7);
                            }
                            Benchmark_Timer.Reset();
                        }

                        if (Stop_Benchmarks)
                        {
                            Benchmark_Values.Clear();
                            Show_Benchmarks = false;
                            Stop_Benchmarks = false;
                            Benchmark_Timer.Stop();
                            insert_Log("Waveforms Capture Benchmark Stopped.", 7);
                        }

                        if (Acquire_Run_Stop == true)
                        {
                            try
                            {
                                Tektronix.WriteCommand("ACQuire:STATE RUN");
                            }
                            catch (Exception)
                            {
                                insert_Log("Failed to send Acquire State Run Command, check connection.", 1);
                            }
                        }

                        if (Acquire_Run_Stop_Disabled == true)
                        {
                            Acquire_Run_Stop_Disabled = false;
                            try
                            {
                                Tektronix.WriteCommand("ACQuire:STATE RUN");
                            }
                            catch (Exception)
                            {
                                insert_Log("Failed to send Acquire State Run Command, check connection.", 1);
                            }
                        }

                        if (Acquire_Waveform_Data == 1)
                        {
                            Acquire_Waveform_Data = 0;
                            Acquire_Waveform_Option_Selected(Acquire_Waveform_Data);
                        }

                        if (Waveform_Data_Collected_Counter > 0)
                        {
                            Channels_Waveform_Data.Add(new All_Channels_Waveform_Data(new Waveform_Data(CH1_Valid, CH1_WFMPre, CH1_Curve), new Waveform_Data(CH2_Valid, CH2_WFMPre, CH2_Curve), new Waveform_Data(CH3_Valid, CH3_WFMPre, CH3_Curve), new Waveform_Data(CH4_Valid, CH4_WFMPre, CH4_Curve)));
                            DataProcess_Timer.Enabled = true;
                        }
                    }
                    else
                    {
                        CH1_Status_Color = Color_Status_Idle;
                        CH2_Status_Color = Color_Status_Idle;
                        CH3_Status_Color = Color_Status_Idle;
                        CH4_Status_Color = Color_Status_Idle;
                    }
                }

                if (Acquire_Interval_Value_Changed)
                {
                    insert_Log("Acquire Timer Value set to " + Math.Round(Acquire_Interval_Value / 1000, 3) + " seconds.", 0);
                    Acquire_Interval_Value_Changed = false;
                }
            }
            while (Loop_Lock);

            Communication_Timer.Enabled = true;
        }

        private void Tektronix_SendCommands()
        {
            try
            {
                while (Tektronix_SendCommands_Queue.Count != 0)
                {
                    string Command = Tektronix_SendCommands_Queue.Take();
                    Tektronix_SendCommand_Process(Command);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Tektronix_SendCommand_Process(string Command)
        {
            switch (Command)
            {
                case "HardCopy_MonoChrome":
                    Get_Monochrome_HardCopy();
                    break;
                case "HardCopy_Color":
                    Get_Color_HardCopy();
                    break;
                case "HardCopy_ColorCompress":
                    Get_Compress_Color_HardCopy();
                    break;
                case "LOCAL_EXIT":
                    if (Communication_Selected.is_VISA_GPIB_Communication_Selected == true)
                    {
                        Tektronix.GPIB_Close();
                    }
                    if (Communication_Selected.is_AR488_Communication_Selected == true)
                    {
                        Tektronix.Serial_Close();
                    }
                    Application.Current.Dispatcher.Invoke(() => { Application.Current.Shutdown(); }, DispatcherPriority.Send);
                    break;
                default:
                    Tektronix_SCPI_Read_Write(Command);
                    break;
            }
        }

        private void Tektronix_SCPI_Read_Write(string SCPI_Command)
        {
            if (SCPI_Command.Contains("?"))
            {
                //Query Command
                if (SCPI_Command.Contains("Query_Measurement"))
                {
                    string[] Command = SCPI_Command.Split(',');
                    if (Command[2].Contains("@"))
                    {
                        string[] SCPI_Setup_Commands = Command[2].Split('@');
                        string Query_Output = "";
                        for (int i = 0; i < SCPI_Setup_Commands.Length; i++)
                        {
                            Tektronix.WriteCommand(SCPI_Setup_Commands[i]);
                            if (SCPI_Setup_Commands[i].Contains("?"))
                            {
                                Query_Output = Tektronix.ReadASCII();
                            }
                        }
                        Query_Measurement_Windows_Data_Passthrough(SCPI_Command, Query_Output);
                    }
                    else
                    {
                        Tektronix.WriteCommand(Command[2]);
                        string Query_Output = Tektronix.ReadASCII();
                        Query_Measurement_Windows_Data_Passthrough(SCPI_Command, Query_Output);
                    }
                }
                else
                {
                    Tektronix.WriteCommand(SCPI_Command);
                    string Query_Output = Tektronix.ReadASCII();
                    insert_Log("[Send]: " + SCPI_Command, 5);
                    insert_Log("[Received]: " + Query_Output, 5);
                    Send_Query_to_SCPI_Communication(SCPI_Command, Query_Output);
                }
            }
            else
            {
                //Write Command
                Tektronix.WriteCommand(SCPI_Command);
                insert_Log("[Send]: " + SCPI_Command, 5);
            }
        }

        private void Send_Query_to_SCPI_Communication(string Write_Command, string Query_Output)
        {
            if (SCPI_Communication_Window != null & SCPI_Communication_Window_isOpen)
            {
                SCPI_Communication_Window.insert_Log("[Send]: " + Write_Command, 7);
                SCPI_Communication_Window.insert_Log("[Received]: " + Query_Output, 8);
            }
        }
    }
}
