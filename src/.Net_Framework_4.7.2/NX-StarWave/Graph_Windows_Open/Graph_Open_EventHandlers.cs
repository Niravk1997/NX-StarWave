using MahApps.Metro.Controls;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private void Initialize_Graph_Open_EventHandlers()
        {
            Initialize_YT_EventHandler();
            Initialize_YT_All_EventHandler();
            Initialize_XY_EventHandler();
            Initialize_Math_YT_EventHandler();
            Initialize_Histogram_EventHandler();
            Initialize_FFT_Waterfall_EventHandler();
            Initialize_FFT_Waveform_EventHandler();
            Initialize_FFT_EventHandler();
            Initialize_Math_FFT_EventHandler();
            Initialize_DataLog_EventHandler();
            Initialize_Waveform_Calculator_EventHandler();
            Initialize_Analysis_Windows_Open_EventHandler();
            Initialize_SCPI_Communication_EventHandler();
            Initialize_Query_Measurement_Window_EventHandler();
            Initialize_Web_Server_EventHandler();
        }
    }
}
