using MahApps.Metro.Controls;
using System;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private void Close_Histogram_Layout_1(object sender, EventArgs e)
        {
            try
            {
                Histogram_Panel_1.Close_Panel();
                Histogram_Panel_1 = null;
                Histogram_Layout_1 = null;
                insert_Log("Histogram Panel 1 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Histogram_Panel_1 = null;
                Histogram_Layout_1 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Histogram_Layout_2(object sender, EventArgs e)
        {
            try
            {
                Histogram_Panel_2.Close_Panel();
                Histogram_Panel_2 = null;
                Histogram_Layout_2 = null;
                insert_Log("Histogram Panel 2 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Histogram_Panel_2 = null;
                Histogram_Layout_2 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Histogram_Layout_3(object sender, EventArgs e)
        {
            try
            {
                Histogram_Panel_3.Close_Panel();
                Histogram_Panel_3 = null;
                Histogram_Layout_3 = null;
                insert_Log("Histogram Panel 3 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Histogram_Panel_3 = null;
                Histogram_Layout_3 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Histogram_Layout_4(object sender, EventArgs e)
        {
            try
            {
                Histogram_Panel_4.Close_Panel();
                Histogram_Panel_4 = null;
                Histogram_Layout_4 = null;
                insert_Log("Histogram Panel 4 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Histogram_Panel_4 = null;
                Histogram_Layout_4 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Histogram_Layout_5(object sender, EventArgs e)
        {
            try
            {
                Histogram_Panel_5.Close_Panel();
                Histogram_Panel_5 = null;
                Histogram_Layout_5 = null;
                insert_Log("Histogram Panel 5 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Histogram_Panel_5 = null;
                Histogram_Layout_5 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_All_Histogram_Panels()
        {
            try { if (Histogram_Layout_1 != null || Histogram_Panel_1 != null) { Histogram_Panel_1.Close_Panel(); Histogram_Layout_1.Close(); Histogram_Layout_1 = null; Histogram_Panel_1 = null; } } catch (Exception) { }
            try { if (Histogram_Layout_2 != null || Histogram_Panel_2 != null) { Histogram_Panel_2.Close_Panel(); Histogram_Layout_2.Close(); Histogram_Layout_2 = null; Histogram_Panel_2 = null; } } catch (Exception) { }
            try { if (Histogram_Layout_3 != null || Histogram_Panel_3 != null) { Histogram_Panel_3.Close_Panel(); Histogram_Layout_3.Close(); Histogram_Layout_3 = null; Histogram_Panel_3 = null; } } catch (Exception) { }
            try { if (Histogram_Layout_4 != null || Histogram_Panel_4 != null) { Histogram_Panel_4.Close_Panel(); Histogram_Layout_4.Close(); Histogram_Layout_4 = null; Histogram_Panel_4 = null; } } catch (Exception) { }
            try { if (Histogram_Layout_5 != null || Histogram_Panel_5 != null) { Histogram_Panel_5.Close_Panel(); Histogram_Layout_5.Close(); Histogram_Layout_5 = null; Histogram_Panel_5 = null; } } catch (Exception) { }
        }
    }
}
