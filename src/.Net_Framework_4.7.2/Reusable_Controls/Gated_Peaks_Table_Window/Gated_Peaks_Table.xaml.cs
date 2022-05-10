using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Gated_Peaks_Table
{
    public partial class Gated_Peaks_Table_Window : MetroWindow
    {
        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        private readonly int Y_Values_Round = 4;
        private readonly int X_Values_Round = 4;

        public string Y_Values_Units = "V";
        public string X_Values_Units = "s";

        public Gated_Peaks_Table_Window(string Owner_Title, System.Drawing.Color Owner_Plot_Color, string Y_Values_Title, string X_Values_Title, string Y_Values_Units, string X_Values_Units, double Window_Height, double Window_Width, bool Measurement_Start_Stop_Text_Visible, bool isWindow_On_Top)
        {
            InitializeComponent();
            DataContext = this;
            this.Window_Title = Owner_Title;
            this.Window_Height = Window_Height;
            this.Window_Width = Window_Width;
            Apply_Owner_Color(Owner_Plot_Color);
            this.Y_Values_Units = Y_Values_Units;
            this.X_Values_Units = X_Values_Units;
            this.Y_Values_Title = Y_Values_Title;
            this.X_Values_Title = X_Values_Title;
            if (isWindow_On_Top)
            {
                Window_On_Top_Menu_Option.IsChecked = true;
                Topmost = true;
            }
            if (Measurement_Start_Stop_Text_Visible)
            {
                Measurement_Start_Stop_Text_Visibility = Visibility.Visible;
            }
        }

        private void Apply_Owner_Color(System.Drawing.Color Owner_Plot_Color)
        {
            System.Windows.Media.Brush Owner_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(ColorTranslator.ToHtml(Owner_Plot_Color));
            Owner_Color.Freeze();
            Gated_Peaks_Table_Owner_Color = Owner_Color;
        }

        internal void Peaks_Table_Process_Data(double[] Y_Values, double[] X_Values, int Total_Peaks_Found)
        {
            if (Total_Peaks_Found >= 1)
            {
                P1_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[0], Y_Values_Round) + Y_Values_Units;
                P1_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[0], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P1_Value_Y = "null";
                P1_Value_X = "null";
            }
            if (Total_Peaks_Found >= 2)
            {
                P2_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[1], Y_Values_Round) + Y_Values_Units;
                P2_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[1], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P2_Value_Y = "null";
                P2_Value_X = "null";
            }
            if (Total_Peaks_Found >= 3)
            {
                P3_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[2], Y_Values_Round) + Y_Values_Units;
                P3_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[2], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P3_Value_Y = "null";
                P3_Value_X = "null";
            }
            if (Total_Peaks_Found >= 4)
            {
                P4_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[3], Y_Values_Round) + Y_Values_Units;
                P4_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[3], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P4_Value_Y = "null";
                P4_Value_X = "null";
            }
            if (Total_Peaks_Found >= 5)
            {
                P5_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[4], Y_Values_Round) + Y_Values_Units;
                P5_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[4], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P5_Value_Y = "null";
                P5_Value_X = "null";
            }
            if (Total_Peaks_Found >= 6)
            {
                P6_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[5], Y_Values_Round) + Y_Values_Units;
                P6_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[5], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P6_Value_Y = "null";
                P6_Value_X = "null";
            }
            if (Total_Peaks_Found >= 7)
            {
                P7_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[6], Y_Values_Round) + Y_Values_Units;
                P7_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[6], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P7_Value_Y = "null";
                P7_Value_X = "null";
            }
            if (Total_Peaks_Found >= 8)
            {
                P8_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[7], Y_Values_Round) + Y_Values_Units;
                P8_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[7], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P8_Value_Y = "null";
                P8_Value_X = "null";
            }
            if (Total_Peaks_Found >= 9)
            {
                P9_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[8], Y_Values_Round) + Y_Values_Units;
                P9_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[8], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P9_Value_Y = "null";
                P9_Value_X = "null";
            }
            if (Total_Peaks_Found >= 10)
            {
                P10_Value_Y = Axis_Scale_Config.Value_SI_Prefix(Y_Values[9], Y_Values_Round) + Y_Values_Units;
                P10_Value_X = Axis_Scale_Config.Value_SI_Prefix(X_Values[9], X_Values_Round) + X_Values_Units;
            }
            else
            {
                P10_Value_Y = "null";
                P10_Value_X = "null";
            }

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
    }
}
