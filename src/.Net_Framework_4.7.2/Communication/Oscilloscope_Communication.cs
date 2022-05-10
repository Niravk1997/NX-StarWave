using Ivi.Visa;
using Ivi.Visa.FormattedIO;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace NX_StarWave
{
    public static class Communication_Selected
    {
        public static bool is_Communication_Selected = false;
        public static bool is_AR488_Communication_Selected = false;
        public static bool is_VISA_GPIB_Communication_Selected = false;
        public static bool VISA_GPIB_WFMPre_Curve_Method = false;

        public static string Company_Name = "";
        public static string Oscilloscope_Model = "";
        public static string Firmware_Version = "";

        public static string folder_Directory;
    }

    //AR488 Communication Info
    public static class AR488_GPIB_Info
    {
        //Serial COM Info
        public static string COM_Port;
        public static int COM_BaudRate;
        public static int COM_Parity;
        public static int COM_StopBits;
        public static int COM_DataBits;
        public static int COM_Handshake;
        public static int COM_WriteTimeout;
        public static int COM_ReadTimeout;
        public static bool COM_RtsEnable;
        public static int GPIB_Address;
    }

    //VISA GPIB Communication Info
    public static class VISA_GPIB_Info
    {
        //GPIB Device Info
        public static string GPIB_Address;
        public static int GPIB_Lock = 0;
        public static int GPIB_Timeout = 10000;
    }

    public class Tektronix_Communication
    {
        //AR488 Connection
        private SerialPort AR488_Interface;

        //VISA GPIB Connection
        private IMessageBasedSession GPIB_Connection;
        private MessageBasedFormattedIO GPIB_Interface;

        // Converts string to bytes array for Read_WFMPre_CURVE_VISA() method.
        private readonly byte[] CURVE_String_Bytes = Encoding.ASCII.GetBytes(":CURVE");
        private readonly int CURVE_String_Length = 6;

        internal Tektronix_Communication()
        {
            if (Communication_Selected.is_VISA_GPIB_Communication_Selected == true)
            {
                GPIB_Connection = GlobalResourceManager.Open(VISA_GPIB_Info.GPIB_Address, (AccessModes)VISA_GPIB_Info.GPIB_Lock, VISA_GPIB_Info.GPIB_Timeout) as IMessageBasedSession;
                GPIB_Connection.TimeoutMilliseconds = VISA_GPIB_Info.GPIB_Timeout;
                GPIB_Connection.TerminationCharacterEnabled = false;
                GPIB_Interface = new MessageBasedFormattedIO(GPIB_Connection);
                GPIB_Interface.ReadBufferSize = 8192;
                GPIB_Interface.WriteBufferSize = 8192;
                GPIB_Interface.BinaryEncoding = BinaryEncoding.RawBigEndian;
            }
            else if (Communication_Selected.is_AR488_Communication_Selected == true)
            {
                AR488_Interface = new SerialPort(AR488_GPIB_Info.COM_Port, AR488_GPIB_Info.COM_BaudRate, (Parity)AR488_GPIB_Info.COM_Parity, AR488_GPIB_Info.COM_DataBits, (StopBits)AR488_GPIB_Info.COM_StopBits);
                AR488_Interface.WriteTimeout = AR488_GPIB_Info.COM_WriteTimeout;
                AR488_Interface.ReadTimeout = AR488_GPIB_Info.COM_ReadTimeout;
                AR488_Interface.RtsEnable = AR488_GPIB_Info.COM_RtsEnable;
                AR488_Interface.DtrEnable = true;
                AR488_Interface.Handshake = (Handshake)AR488_GPIB_Info.COM_Handshake;
                AR488_Interface.Encoding = System.Text.Encoding.GetEncoding(28591);
                AR488_Interface.Open();
            }
            Initial_Commands();
        }

        private void Initial_Commands()
        {
            WriteCommand("HEADer ON");
            WriteCommand("VERBose ON");
            WriteCommand("DATa:ENCdg BIN");
            WriteCommand("DATa:ENCdg RPB");
            WriteCommand("DATa:WIDth 1");
            WriteCommand("DATa:STARt 1");
            WriteCommand("DATa:STOP 500");
        }

        public void WriteCommand(string Command)
        {
            if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
            {
                GPIB_Interface.WriteLine(Command);
            }
            else
            {
                AR488_Interface.WriteLine(Command);
            }
        }

        public string ReadASCII()
        {
            if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
            {
                return GPIB_Interface.ReadLine();
            }
            else
            {
                AR488_Interface.WriteLine("++read");
                return AR488_Interface.ReadLine();
            }
        }

        public List<byte> Read_CURVE_AR488(int Expected_CURVE_Bytes)
        {
            AR488_Interface.WriteLine("CURVE?");
            AR488_Interface.WriteLine("++read");
            List<byte> CURVE_Bytes = new List<byte>();
            System.Diagnostics.Stopwatch Timeout_Timer = new System.Diagnostics.Stopwatch();
            Timeout_Timer.Start();
            while (CURVE_Bytes.Count < Expected_CURVE_Bytes)
            {
                var BytesToRead = AR488_Interface.BytesToRead;
                var Bytes = new byte[BytesToRead];
                AR488_Interface.Read(Bytes, 0, BytesToRead);
                CURVE_Bytes.AddRange(Bytes);
                Thread.Sleep(1);
                if (BytesToRead != 0)
                {
                    Timeout_Timer.Restart();
                }
                if (Timeout_Timer.Elapsed.TotalSeconds > 4)
                {
                    break;
                }
            }
            Timeout_Timer.Stop();
            return CURVE_Bytes;
        }

        public List<byte> Read_CURVE_VISA(int Expected_CURVE_Bytes)
        {
            GPIB_Interface.WriteLine("CURVE?");
            byte[] WFMPre_Curve = new byte[Expected_CURVE_Bytes];
            GPIB_Interface.ReadBinaryBlockOfByte(WFMPre_Curve, 0, Expected_CURVE_Bytes);
            return WFMPre_Curve.ToList();
        }

        //This method gets the Waveform Preamble and Waveform Curve data with a single read command.
        public (string WFMPre, List<byte> Curve, bool isValid) Read_WFMPre_CURVE_VISA()
        {
            GPIB_Interface.WriteLine("WAVFRM?");
            byte[] WFMPre_Curve = GPIB_Interface.ReadBinaryBlockOfByte();
            int WFMPre_Curve_Length = WFMPre_Curve.Length;
            if (WFMPre_Curve_Length > 100)
            {
                int WFMPre_Stop_Index = Seperate_WFMPre_Curve_Data(WFMPre_Curve, WFMPre_Curve_Length);

                int WFMPre_Length = WFMPre_Stop_Index - 1;
                int Curve_Length = WFMPre_Curve_Length - WFMPre_Stop_Index;

                byte[] WFMPre = new byte[WFMPre_Length];
                byte[] Curve = new byte[Curve_Length];
                Array.Copy(WFMPre_Curve, WFMPre, WFMPre_Length);
                Array.Copy(WFMPre_Curve, WFMPre_Stop_Index, Curve, 0, Curve_Length);

                return (Encoding.UTF8.GetString(WFMPre), Curve.ToList(), true);
            }
            else
            {
                return (null, null, false);
            }
        }

        private int Seperate_WFMPre_Curve_Data(byte[] WFMPre_Curve, int WFMPre_Curve_Length)
        {
            int Max_First_Character_Slot = WFMPre_Curve_Length - CURVE_String_Length + 1;
            for (int i = 0; i < Max_First_Character_Slot; i++)
            {
                if (WFMPre_Curve[i] != CURVE_String_Bytes[0])
                    continue;

                for (int j = CURVE_String_Length - 1; j >= 1; j--)
                {
                    if (WFMPre_Curve[i + j] != CURVE_String_Bytes[j]) break;
                    if (j == 1) return i;
                }
            }
            return -1;
        }

        public string Query(string Command)
        {
            if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
            {
                GPIB_Interface.WriteLine(Command);
                return GPIB_Interface.ReadLine();
            }
            else
            {
                AR488_Interface.WriteLine(Command);
                AR488_Interface.WriteLine("++read");
                return AR488_Interface.ReadLine();
            }
        }

        public byte[] Get_HardCopy_AR488(int Expected_Bytes)
        {
            AR488_Interface.WriteLine("++read");
            List<byte> CURVE_Bytes = new List<byte>();
            System.Diagnostics.Stopwatch Timeout_Timer = new System.Diagnostics.Stopwatch();
            Timeout_Timer.Start();
            while (CURVE_Bytes.Count < Expected_Bytes)
            {
                var BytesToRead = AR488_Interface.BytesToRead;
                var Bytes = new byte[BytesToRead];
                AR488_Interface.Read(Bytes, 0, BytesToRead);
                CURVE_Bytes.AddRange(Bytes);
                Thread.Sleep(1);
                if (BytesToRead != 0)
                {
                    Timeout_Timer.Restart();
                }
                if (Timeout_Timer.Elapsed.TotalSeconds > 4)
                {
                    break;
                }
            }
            Timeout_Timer.Stop();
            return CURVE_Bytes.ToArray();
        }

        public byte[] Get_HardCopy_Visa()
        {
            return GPIB_Interface.ReadBinaryBlockOfByte();
        }

        public void Serial_Close()
        {
            AR488_Interface.Close();
            AR488_Interface.Dispose();
        }

        public void GPIB_Close()
        {
            GPIB_Interface = null;
            if (VISA_GPIB_Info.GPIB_Lock == 1)
            {
                GPIB_Connection.UnlockResource();
            }
            GPIB_Connection.Dispose();
        }
    }
}
