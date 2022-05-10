namespace SCPI_Commands
{
    public static partial class Oscilloscope_SCPI_Commands
    {
        public static string Acquire_Query = "ACQuire?";

        public static string Acquire_Mode_Sample = "ACQuire:MODe SAMple";
        public static string Acquire_Mode_PeakDetect = "ACQuire:MODe PEAKdetect";
        public static string Acquire_Mode_HIRes = "ACQuire:MODe HIRes";

        public static string Acquire_Mode_Envelope = "ACQuire:MODe ENVelope";
        public static string Acquire_Mode_Envelope_Count = "ACQuire:NUMEnv ";
        public static string Acquire_Mode_Envelope_Count_Query = "ACQuire:NUMEnv?";

        public static string Acquire_Mode_Average = "ACQuire:MODe AVErage";
        public static string Acquire_Mode_Average_Count = "ACQuire:NUMAVg ";
        public static string Acquire_Mode_Average_Count_Query = "ACQuire:NUMAVg?";

        public static string Acquire_Run = "ACQuire:STATE RUN";
        public static string Acquire_Stop = "ACQuire:STATE STOP";
    }
}
