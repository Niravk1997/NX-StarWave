using MahApps.Metro.Controls;
using System;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private void Close_Waveform_Layout_1(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_1.Close_Panel();
                Waveform_Panel_1 = null;
                Waveform_Layout_1 = null;
                insert_Log("Waveform Panel 1 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_1 = null;
                Waveform_Layout_1 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Waveform_Layout_2(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_2.Close_Panel();
                Waveform_Panel_2 = null;
                Waveform_Layout_2 = null;
                insert_Log("Waveform Panel 2 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_2 = null;
                Waveform_Layout_2 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Waveform_Layout_3(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_3.Close_Panel();
                Waveform_Panel_3 = null;
                Waveform_Layout_3 = null;
                insert_Log("Waveform Panel 3 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_3 = null;
                Waveform_Layout_3 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Waveform_Layout_4(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_4.Close_Panel();
                Waveform_Panel_4 = null;
                Waveform_Layout_4 = null;
                insert_Log("Waveform Panel 4 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_4 = null;
                Waveform_Layout_4 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Waveform_Layout_5(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_5.Close_Panel();
                Waveform_Panel_5 = null;
                Waveform_Layout_5 = null;
                insert_Log("Waveform Panel 5 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_5 = null;
                Waveform_Layout_5 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Waveform_Layout_6(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_6.Close_Panel();
                Waveform_Panel_6 = null;
                Waveform_Layout_6 = null;
                insert_Log("Waveform Panel 6 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_6 = null;
                Waveform_Layout_6 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Waveform_Layout_7(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_7.Close_Panel();
                Waveform_Panel_7 = null;
                Waveform_Layout_7 = null;
                insert_Log("Waveform Panel 7 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_7 = null;
                Waveform_Layout_7 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Waveform_Layout_8(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_8.Close_Panel();
                Waveform_Panel_8 = null;
                Waveform_Layout_8 = null;
                insert_Log("Waveform Panel 8 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_8 = null;
                Waveform_Layout_8 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Waveform_Layout_9(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_9.Close_Panel();
                Waveform_Panel_9 = null;
                Waveform_Layout_9 = null;
                insert_Log("Waveform Panel 9 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_9 = null;
                Waveform_Layout_9 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Waveform_Layout_10(object sender, EventArgs e)
        {
            try
            {
                Waveform_Panel_10.Close_Panel();
                Waveform_Panel_10 = null;
                Waveform_Layout_10 = null;
                insert_Log("Waveform Panel 10 Closed.", 5);
            }
            catch (Exception Ex)
            {
                Waveform_Panel_10 = null;
                Waveform_Layout_10 = null;
                insert_Log(Ex.Message, 1);
            }
        }

        private void Close_All_Waveform_Panels()
        {
            try { if (Waveform_Layout_1 != null || Waveform_Panel_1 != null) { Waveform_Panel_1.Close_Panel(); Waveform_Layout_1.Close(); Waveform_Layout_1 = null; Waveform_Panel_1 = null; } } catch (Exception) { }
            try { if (Waveform_Layout_2 != null || Waveform_Panel_2 != null) { Waveform_Panel_2.Close_Panel(); Waveform_Layout_2.Close(); Waveform_Layout_2 = null; Waveform_Panel_2 = null; } } catch (Exception) { }
            try { if (Waveform_Layout_3 != null || Waveform_Panel_3 != null) { Waveform_Panel_3.Close_Panel(); Waveform_Layout_3.Close(); Waveform_Layout_3 = null; Waveform_Panel_3 = null; } } catch (Exception) { }
            try { if (Waveform_Layout_4 != null || Waveform_Panel_4 != null) { Waveform_Panel_4.Close_Panel(); Waveform_Layout_4.Close(); Waveform_Layout_4 = null; Waveform_Panel_4 = null; } } catch (Exception) { }
            try { if (Waveform_Layout_5 != null || Waveform_Panel_5 != null) { Waveform_Panel_5.Close_Panel(); Waveform_Layout_5.Close(); Waveform_Layout_5 = null; Waveform_Panel_5 = null; } } catch (Exception) { }
            try { if (Waveform_Layout_6 != null || Waveform_Panel_6 != null) { Waveform_Panel_6.Close_Panel(); Waveform_Layout_6.Close(); Waveform_Layout_6 = null; Waveform_Panel_6 = null; } } catch (Exception) { }
            try { if (Waveform_Layout_7 != null || Waveform_Panel_7 != null) { Waveform_Panel_7.Close_Panel(); Waveform_Layout_7.Close(); Waveform_Layout_7 = null; Waveform_Panel_7 = null; } } catch (Exception) { }
            try { if (Waveform_Layout_8 != null || Waveform_Panel_8 != null) { Waveform_Panel_8.Close_Panel(); Waveform_Layout_8.Close(); Waveform_Layout_8 = null; Waveform_Panel_8 = null; } } catch (Exception) { }
            try { if (Waveform_Layout_9 != null || Waveform_Panel_9 != null) { Waveform_Panel_9.Close_Panel(); Waveform_Layout_9.Close(); Waveform_Layout_9 = null; Waveform_Panel_9 = null; } } catch (Exception) { }
            try { if (Waveform_Layout_10 != null || Waveform_Panel_10 != null) { Waveform_Panel_10.Close_Panel(); Waveform_Layout_10.Close(); Waveform_Layout_10 = null; Waveform_Panel_10 = null; } } catch (Exception) { }
        }
    }
}
