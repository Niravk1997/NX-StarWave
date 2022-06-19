using MahApps.Metro.Controls;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : MetroWindow
    {
        //Arrays are fixed sized, this variable determines the initial Array size. Its value will increase as Arrays get filled with measurement data
        private int Max_Allowed_Samples = 1_000_000;
        private double[] Measurement_Data = new double[1_000_000];
        private double[] Date_Time = new double[1_000_000];

        private string Measurement_Label = "";
        private string Measurement_Unit = "";
        private string Measurement_Color = "";

        private int Measurement_Round_Value = 4;

        private ScottPlot.Plottable.SignalPlotXY Measurement_Plot;

        private void Initialize_Variables(string Measurement_Label, string Measurement_Unit, string Measurement_Color)
        {
            this.Measurement_Label = Measurement_Label;
            Window_Title = Measurement_Label;
            this.Measurement_Unit = Measurement_Unit;
            this.Measurement_Color = Measurement_Color;
        }

        private void Initialize_Plot()
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Axis_Scale_Config.Y_Axis_Units = Measurement_Unit;
            Graph.Plot.XAxis.DateTimeFormat(true);
            Graph.Plot.YAxis.Label(Measurement_Label);
        }

        private void Initialize_Plot_Data(double[] Initial_Date_Time, double[] Initial_Measurement_Data)
        {
            int Initial_Date_Time_Count = Initial_Date_Time.Length;
            int Initial_Measurement_Data_Count = Initial_Measurement_Data.Length;
            int Data_Count = 0;

            if (Initial_Date_Time_Count > Initial_Measurement_Data_Count)
            {
                Data_Count = Initial_Measurement_Data_Count;
            }
            else
            {
                Data_Count = Initial_Date_Time_Count;
            }

            if (Data_Count >= Max_Allowed_Samples)
            {
                Max_Allowed_Samples = Max_Allowed_Samples + Data_Count;
                Measurement_Data = new double[Max_Allowed_Samples];
                Date_Time = new double[Max_Allowed_Samples];
            }

            double Measurement_Min_Local = double.MaxValue;
            double Measurement_Max_Local = double.MinValue;

            for (int i = 0; i < Data_Count; i++)
            {
                Date_Time[i] = Initial_Date_Time[i];
                Measurement_Data[i] = Initial_Measurement_Data[i];
                if (Initial_Measurement_Data[i] < Measurement_Min_Local)
                {
                    Measurement_Min_Local = Initial_Measurement_Data[i];
                }
                if (Initial_Measurement_Data[i] > Measurement_Max_Local)
                {
                    Measurement_Max_Local = Initial_Measurement_Data[i];
                }
                if (Initial_Measurement_Data[i] >= 0)
                {
                    Positive_Samples++;
                }
                else
                {
                    Negative_Samples++;
                }
                Measurement_Data_Count++;
            }

            for (int i = Data_Count; i < Max_Allowed_Samples; i++)
            {
                Date_Time[i] = Max_DateTime_Value;
            }

            Min_Recorded_Sample = Measurement_Min_Local;
            Max_Recorded_Sample = Measurement_Max_Local;
        }

        private void Initialize_Measurement_Plot()
        {
            Measurement_Plot = Graph.Plot.AddSignalXY(Date_Time, Measurement_Data, color: System.Drawing.ColorTranslator.FromHtml(Measurement_Color), Measurement_Label);
            Measurement_Plot.MarkerSize = 0;
            Measurement_Plot.MaxRenderIndex = Measurement_Data_Count - 1;
            Graph.Plot.AxisAuto();
            Graph.Render();
        }
    }
}
