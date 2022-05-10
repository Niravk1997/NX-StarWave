using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace Query_Measurement_Control
{
    public partial class Query_Measurement_Window : MetroWindow
    {
        private int Window_ID;
        private string SCPI_Command;
        private double SCPI_Send_Delay;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public Query_Measurement_Window(int ID, string Window_Title, string SCPI_Command, string Output_Result_String_Cut_Start, string Output_Result_String_Cut_Stop, string Measurement_Units, double SCPI_Send_Delay, string Label_Colour, string Background_Color, bool isBackground_Transparent, bool isWindow_On_Top)
        {
            InitializeComponent();
            DataContext = this;
            if (isWindow_On_Top)
            {
                Window_On_Top_Menu_Option.IsChecked = true;
                Topmost = true;
            }
            Initialize_Variables(ID, Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent);
            Initialize_Timers(SCPI_Send_Delay);
        }

        private void Initialize_Variables(int ID, string Window_Title, string SCPI_Command, string Output_Result_String_Cut_Start, string Output_Result_String_Cut_Stop, string Measurement_Units, double SCPI_Send_Delay, string Label_Colour, string Background_Color, bool isBackground_Transparent)
        {
            Window_ID = ID;
            this.Window_Title = Window_Title;
            this.SCPI_Command = SCPI_Command;
            this.Measurement_Units = Measurement_Units;

            if (Output_Result_String_Cut_Start == "" || Output_Result_String_Cut_Start == string.Empty)
            {
                isRequired_Output_Result_String_Cut_Start = false;
            }
            else
            {
                this.Output_Result_String_Cut_Start = Output_Result_String_Cut_Start;
                Output_Result_String_Cut_Start_Length = Output_Result_String_Cut_Start.Length;
                isRequired_Output_Result_String_Cut_Start = true;
            }

            if (Output_Result_String_Cut_Stop == "" || Output_Result_String_Cut_Stop == string.Empty)
            {
                isRequired_Output_Result_String_Cut_Stop = false;
            }
            else
            {
                this.Output_Result_String_Cut_Stop = Output_Result_String_Cut_Stop;
                Output_Result_String_Cut_Stop_Length = Output_Result_String_Cut_Stop.Length;
                isRequired_Output_Result_String_Cut_Stop = true;
            }

            this.SCPI_Send_Delay = SCPI_Send_Delay;

            Progress_Complete_Value = SCPI_Send_Delay;

            Brush Labels_Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Label_Colour));
            Labels_Color.Freeze();
            Label_Foreground = Labels_Color;

            if (isBackground_Transparent)
            {
                Brush Background_brush = new SolidColorBrush(Colors.Transparent);
                Background_brush.Freeze();
                this.Background_Color = Background_brush;
            }
            else
            {
                Brush Background_brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Background_Color));
                Background_brush.Freeze();
                this.Background_Color = Background_brush;
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
