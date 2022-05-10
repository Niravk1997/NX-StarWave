using Auto_Measurements;
using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : MetroWindow
    {
        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();
        private Automatic_Measurements Waveform_Measurements = new Automatic_Measurements();

        public Statistics_Table_Window(string Long_Title, string Short_Title, string YAxis_Units, System.Drawing.Color Owner_Plot_Color, double Window_Height, double Window_Width, bool Measurement_Start_Stop_Text_Visible, bool isWindow_On_Top)
        {
            InitializeComponent();
            DataContext = this;
            this.Long_Title = Long_Title;
            this.Short_Title = Short_Title;
            this.YAxis_Units = YAxis_Units;
            this.Window_Height = Window_Height;
            this.Window_Width = Window_Width;
            if (isWindow_On_Top)
            {
                Window_On_Top_Menu_Option.IsChecked = true;
                Topmost = true;
            }
            if (Measurement_Start_Stop_Text_Visible)
            {
                Measurement_Start_Stop_Text_Visibility = Visibility.Visible;
            }
            Apply_Owner_Color(Owner_Plot_Color);
        }

        private void Apply_Owner_Color(System.Drawing.Color Owner_Plot_Color)
        {
            System.Windows.Media.Brush Owner_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(ColorTranslator.ToHtml(Owner_Plot_Color));
            Owner_Color.Freeze();
            Statistics_Table_Owner_Color = Owner_Color;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void MetroWindow_StateChanged(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Normal;
        }

        public void Close_Graph_Panel()
        {
            try
            {
                if (Frequency_Measurement_Plot_Enabled || Frequency_Measurement_Plot_Window != null)
                { try { Frequency_Measurement_Plot_Window.Close(); } catch (Exception) { } }

                if (Period_Measurement_Plot_Enabled || Period_Measurement_Plot_Window != null)
                { try { Period_Measurement_Plot_Window.Close(); } catch (Exception) { } }

                if (PeakPeak_Measurement_Plot_Enabled || PeakPeak_Measurement_Plot_Window != null)
                { try { PeakPeak_Measurement_Plot_Window.Close(); } catch (Exception) { } }

                if (Mean_Measurement_Plot_Enabled || Mean_Measurement_Plot_Window != null)
                { try { Mean_Measurement_Plot_Window.Close(); } catch (Exception) { } }

                if (RMS_Measurement_Plot_Enabled || RMS_Measurement_Plot_Window != null)
                { try { RMS_Measurement_Plot_Window.Close(); } catch (Exception) { } }

                if (Min_Measurement_Plot_Enabled || Min_Measurement_Plot_Window != null)
                { try { Min_Measurement_Plot_Window.Close(); } catch (Exception) { } }

                if (Max_Measurement_Plot_Enabled || Max_Measurement_Plot_Window != null)
                { try { Max_Measurement_Plot_Window.Close(); } catch (Exception) { } }

                if (Stdev_Measurement_Plot_Enabled || Stdev_Measurement_Plot_Window != null)
                { try { Stdev_Measurement_Plot_Window.Close(); } catch (Exception) { } }
            }
            catch (Exception)
            {

            }
        }
    }
}
