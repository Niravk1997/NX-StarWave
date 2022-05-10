namespace SCPI_Commands
{
    public static partial class Oscilloscope_SCPI_Commands
    {
        //All Vertical Commands relating to Channels.

        public static string CH1 = "CH1";
        public static string CH2 = "CH2";
        public static string CH3 = "CH3";
        public static string CH4 = "CH4";

        public static string CH_Status = "?";

        public static string Select = "SELect:";

        public static string CH_ON = " ON";
        public static string CH_OFF = " OFF";

        public static string Coupling_DC = ":COUPling DC";
        public static string Coupling_AC = ":COUPling AC";
        public static string Coupling_GND = ":COUPling GND";

        public static string Termination_1M = ":IMPedance MEG";
        public static string Termination_50 = ":IMPedance FIFty";

        public static string Bandwidth_Full = ":BANdwidth FULl";
        public static string Bandwidth_250MHz = ":BANdwidth TWOfifty";
        public static string Bandwidth_20MHz = ":BANdwidth TWEnty";

        public static string Vertical_Position = ":POSition ";//Needs a value
        public static string Vertical_Position_Query = ":POSition?";

        public static string Vertical_Offset = ":OFFSet ";//Needs a value
        public static string Vertical_Offset_Query = ":OFFSet?";
    }
}
