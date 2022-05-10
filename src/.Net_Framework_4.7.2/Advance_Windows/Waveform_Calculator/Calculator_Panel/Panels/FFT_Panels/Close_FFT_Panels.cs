using MahApps.Metro.Controls;
using System;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private void Close_FFT_Layout_1(object sender, EventArgs e)
        {
            try
            {
                FFT_Panel_1.Close_Panel();
                FFT_Panel_1 = null;
                FFT_Layout_1 = null;
                insert_Log("FFT Panel 1 Closed.", 5);
            }
            catch (Exception Ex)
            {
                FFT_Panel_1 = null;
                FFT_Layout_1 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_FFT_Layout_2(object sender, EventArgs e)
        {
            try
            {
                FFT_Panel_2.Close_Panel();
                FFT_Panel_2 = null;
                FFT_Layout_2 = null;
                insert_Log("FFT Panel 2 Closed.", 5);
            }
            catch (Exception Ex)
            {
                FFT_Panel_2 = null;
                FFT_Layout_2 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_FFT_Layout_3(object sender, EventArgs e)
        {
            try
            {
                FFT_Panel_3.Close_Panel();
                FFT_Panel_3 = null;
                FFT_Layout_3 = null;
                insert_Log("FFT Panel 3 Closed.", 5);
            }
            catch (Exception Ex)
            {
                FFT_Panel_3 = null;
                FFT_Layout_3 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_FFT_Layout_4(object sender, EventArgs e)
        {
            try
            {
                FFT_Panel_4.Close_Panel();
                FFT_Panel_4 = null;
                FFT_Layout_4 = null;
                insert_Log("FFT Panel 4 Closed.", 5);
            }
            catch (Exception Ex)
            {
                FFT_Panel_4 = null;
                FFT_Layout_4 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_FFT_Layout_5(object sender, EventArgs e)
        {
            try
            {
                FFT_Panel_5.Close_Panel();
                FFT_Panel_5 = null;
                FFT_Layout_5 = null;
                insert_Log("FFT Panel 5 Closed.", 5);
            }
            catch (Exception Ex)
            {
                FFT_Panel_5 = null;
                FFT_Layout_5 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_All_FFT_Panels()
        {
            try { if (FFT_Layout_1 != null || FFT_Panel_1 != null) { FFT_Panel_1.Close_Panel(); FFT_Layout_1.Close(); FFT_Layout_1 = null; FFT_Panel_1 = null; } } catch (Exception) { }
            try { if (FFT_Layout_2 != null || FFT_Panel_2 != null) { FFT_Panel_2.Close_Panel(); FFT_Layout_2.Close(); FFT_Layout_2 = null; FFT_Panel_2 = null; } } catch (Exception) { }
            try { if (FFT_Layout_3 != null || FFT_Panel_3 != null) { FFT_Panel_3.Close_Panel(); FFT_Layout_3.Close(); FFT_Layout_3 = null; FFT_Panel_3 = null; } } catch (Exception) { }
            try { if (FFT_Layout_4 != null || FFT_Panel_4 != null) { FFT_Panel_4.Close_Panel(); FFT_Layout_4.Close(); FFT_Layout_4 = null; FFT_Panel_4 = null; } } catch (Exception) { }
            try { if (FFT_Layout_5 != null || FFT_Panel_5 != null) { FFT_Panel_5.Close_Panel(); FFT_Layout_5.Close(); FFT_Layout_5 = null; FFT_Panel_5 = null; } } catch (Exception) { }
        }
    }
}
