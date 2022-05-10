using System.Collections.Generic;

namespace Oscilloscope_Waveform_Data_Process
{
    public class Tektronix_TDS_Waveform_Data_Process
    {
        private int BYT_NR { get; set; } //Binary field data width. Can be 1 or 2
        private int BIT_NR { get; set; } //Number of bits per binary waveform point. Can be 8 or 16
        private string ENCDG { get; set; } //Type of encoding for waveform data transferred. Can be Binary or ASCII
        private string BN_FMT { get; set; } //Format of binary data. RI specifies signed integer data-point representation. RP specifies positive integer data - point representation.
        private string BYT_OR { get; set; } //Which byte of binary waveform data is transmitted first. LSB selects the least significant byte to be transmitted first. MSB selects the most significant bye to be transmitted first.
        private string CH_string { get; set; } //Channel #
        private string WFI_string { get; set; } //Channel # Information
        private int NR_P_data { get; set; } //Number of points in the curve
        private string PT_F_string { get; set; } //Format of curve points
        private string XUN_string { get; set; } //Horizontal units
        private double XIN_data { get; set; } //Horizontal sampling interval
        private double XZE_data { get; set; } //Horizontal origin offset
        private double PT_O_data { get; set; } //Trigger position
        private string YUN_string { get; set; } //Vertical units
        private double YMU_data { get; set; } //Vertical scale factor
        private double YOF_data { get; set; } //Vertical offset
        private double YZE_data { get; set; } //Offset voltage

        private int Unwanted_Query_CURVE_BYTES { get; set; }

        private const int CURVE_Query_CHARS = 9;

        private void Extract_WFMPre_Data(string WFMPre)
        {
            //Binary field data width. Can be 1 or 2
            BYT_NR = int.Parse(WFMPre_String_Search(WFMPre, "BYT_NR", 6, ";"));

            //Number of bits per binary waveform point. Can be 8 or 16
            BIT_NR = int.Parse(WFMPre_String_Search(WFMPre, "BIT_NR", 6, ";"));

            //Type of encoding for waveform data transferred. Can be Binary or ASCII
            ENCDG = WFMPre_String_Search(WFMPre, "ENCDG", 5, ";");

            //Format of binary data. RI specifies signed integer data-point representation. RP specifies positive integer data - point representation.
            BN_FMT = WFMPre_String_Search(WFMPre, "BN_FMT", 6, ";");

            //Which byte of binary waveform data is transmitted first. LSB selects the least significant byte to be transmitted first. MSB selects the most significant bye to be transmitted first.
            BYT_OR = WFMPre_String_Search(WFMPre, "BYT_OR", 6, ";");

            //Channel #
            CH_string = WFMPre_String_Search(WFMPre, ";CH", 1, ":");

            //Channel # Information
            WFI_string = WFMPre_String_Search(WFMPre, "WFID", 4, ";");

            //Number of points in the curve
            NR_P_data = int.Parse(WFMPre_String_Search(WFMPre, "NR_PT", 5, ";"));

            //Format of curve points
            PT_F_string = WFMPre_String_Search(WFMPre, "PT_FMT", 6, ";");

            //Horizontal units
            XUN_string = WFMPre_String_Search(WFMPre, "XUNIT", 5, ";");

            //Horizontal sampling interval
            XIN_data = double.Parse(WFMPre_String_Search(WFMPre, "XINCR", 5, ";"));

            //Horizontal origin offset
            XZE_data = double.Parse(WFMPre_String_Search(WFMPre, "XZERO", 5, ";"));

            //Trigger position
            PT_O_data = double.Parse(WFMPre_String_Search(WFMPre, "PT_OFF", 6, ";"));

            //Vertical units
            YUN_string = WFMPre_String_Search(WFMPre, "YUNIT", 5, ";");

            //Vertical scale factor
            YMU_data = double.Parse(WFMPre_String_Search(WFMPre, "YMULT", 5, ";"));

            //Vertical offset
            YOF_data = double.Parse(WFMPre_String_Search(WFMPre, "YOFF", 4, ";"));

            //Offset voltage, this is the last item in WFMPre query, does not have ";" at the end
            int YZE_Index = WFMPre.IndexOf("YZERO") + 5;
            YZE_data = double.Parse(WFMPre.Substring(YZE_Index, WFMPre.Length - YZE_Index));
        }

        private int Curve_Expected_Bytes()
        {
            if (BYT_NR == 1)
            {
                int Total_CURVE_BYTES = NR_P_data;
                Unwanted_Query_CURVE_BYTES = CURVE_Query_CHARS + Num_Digits(Total_CURVE_BYTES);
                return (Total_CURVE_BYTES + Unwanted_Query_CURVE_BYTES + 1);
            }
            else
            {
                int Total_CURVE_BYTES = NR_P_data * 2;
                Unwanted_Query_CURVE_BYTES = CURVE_Query_CHARS + Num_Digits(Total_CURVE_BYTES);
                return (Total_CURVE_BYTES + Unwanted_Query_CURVE_BYTES + 1);
            }
        }

        public int Curve_Expected_Bytes_Quick(string WFMPre)
        {
            int BYT_NR = int.Parse(WFMPre_String_Search(WFMPre, "BYT_NR", 6, ";"));
            int NR_P_data = int.Parse(WFMPre_String_Search(WFMPre, "NR_PT", 5, ";"));

            if (BYT_NR == 1)
            {
                int Total_CURVE_BYTES = NR_P_data;
                int Unwanted_Query_CURVE_BYTES = 9 + Num_Digits(Total_CURVE_BYTES);
                return (Total_CURVE_BYTES + Unwanted_Query_CURVE_BYTES + 1);
            }
            else
            {
                int Total_CURVE_BYTES = NR_P_data * 2;
                int Unwanted_Query_CURVE_BYTES = 9 + Num_Digits(Total_CURVE_BYTES);
                return (Total_CURVE_BYTES + Unwanted_Query_CURVE_BYTES + 1);
            }
        }

        public (double[], double[], double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info) Process_Waveform_Data(string WFMPre, List<byte> Waveform_Bytes)
        {
            Extract_WFMPre_Data(WFMPre);
            Curve_Expected_Bytes();

            double Total_Time = NR_P_data * XIN_data;
            double Time_Start = (-1.00 * PT_O_data * XIN_data) + XZE_data;
            double Time_Stop = Time_Start + Total_Time;

            double[] CURVE_data = new double[NR_P_data];

            Waveform_Bytes.RemoveRange(0, Unwanted_Query_CURVE_BYTES);

            if (BYT_NR == 1)
            {
                for (int i = 0; i < NR_P_data; i++)
                {
                    CURVE_data[i] = Waveform_Bytes[i];
                }
            }
            else
            {
                int X = 0; //Combine Two 8 bit bytes to get one 16 bit byte
                for (int i = 0; i < NR_P_data; i++)
                {
                    CURVE_data[i] = (((Waveform_Bytes[X] & 0xff) << 8) | (Waveform_Bytes[X + 1] & 0xff));
                    X += 2;
                }
            }

            for (int i = 0; i < CURVE_data.Length; i++)
            {
                CURVE_data[i] = ((CURVE_data[i] - YOF_data) * YMU_data) + YZE_data;
            }

            return (Linspace(Time_Start, Time_Stop, NR_P_data), CURVE_data, Total_Time, Time_Start, Time_Stop, NR_P_data, CH_string + "," + XUN_string + "," + YUN_string);
        }

        private string WFMPre_String_Search(string Waveform_Data, string Search_start_String, int Search_Start_Index_Value, string Search_stop_String)
        {
            int string_startIndex = Waveform_Data.IndexOf(Search_start_String) + Search_Start_Index_Value;
            int string_stopIndex = Waveform_Data.IndexOf(Search_stop_String, string_startIndex);
            return Waveform_Data.Substring(string_startIndex, string_stopIndex - string_startIndex).Trim();
        }

        private double[] Linspace(double Start_Value, double Stop_Value, int Length)
        {
            double Step = (Stop_Value - Start_Value) / (Length - 1.00);
            double[] Array = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                Array[i] = Start_Value + Step * i;
            }
            return Array;
        }

        private int Num_Digits(int Number) //This way of doing is much faster. Compared to Number.toString().Length
        {
            if (Number >= 0)
            {
                if (Number < 10) { return 1; }
                if (Number < 100) { return 2; }
                if (Number < 1000) { return 3; }
                if (Number < 10000) { return 4; }
                if (Number < 100000) { return 5; }
                if (Number < 1000000) { return 6; }
                if (Number < 10000000) { return 7; }
                if (Number < 100000000) { return 8; }
                if (Number < 1000000000) { return 9; }
                else { return 10; }
            }
            else { return 0; }
        }
    }
}
