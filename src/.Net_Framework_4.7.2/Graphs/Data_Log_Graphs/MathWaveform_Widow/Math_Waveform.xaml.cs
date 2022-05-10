using Axis_Scale_Config;
using MahApps.Metro.Controls;
using MathNet.Numerics.Statistics;
using NX_StarWave.Misc;
using System;
using System.Linq;

namespace Channel_DataLogger
{
    /// <summary>
    /// Interaction logic for Math_Waveform.xaml
    /// </summary>
    public partial class Math_Waveform : MetroWindow
    {
        //Set Window Title, helps determine which instrument owns this Graph Window
        private string Graph_Owner;

        //Needed to add the Plot to the graph
        private ScottPlot.Plottable.SignalPlot Measurement_Plot;
        private double[] Measurement_Data; //Waveform Array

        //Auto clear the output log after a specific amount of items inside the log has been reached.
        private int Auto_Clear_Output_Log_Count = 40; //This integer variable is thread safe, interlocked.exchange is used.

        // A counter that is incremented when a measurement is processed. Show how many measuremnet is displayed on the GUI window.
        private int Measurement_Count; //For testing set
        private int Start_Sample;
        private int End_Sample;

        private string Measurement_Unit;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();
        public Math_Waveform(string Graph_Owner, string Window_Title, double Value, int Start_Sample, int End_Sample, string Graph_Title, string Y_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count)
        {
            InitializeComponent();
            Graph_RightClick_Menu();
            this.Title = Graph_Owner + " " + Window_Title;
            this.Graph_Owner = Graph_Owner;

            if (Y_Axis_Label.Length > 3)
            {
                Measurement_Unit = Y_Axis_Label.Substring(0, 3);
            }
            else
            {
                Measurement_Unit = Y_Axis_Label;
            }
            Axis_Scale_Config.X_Axis_Units = "#";
            Axis_Scale_Config.Y_Axis_Units = Measurement_Unit;
            this.Measurement_Data = Measurement_Data;
            this.Measurement_Count = Measurement_Count;
            this.Start_Sample = Start_Sample;
            this.End_Sample = End_Sample;

            try
            {
                Add_Measurement_Waveform(Y_Axis_Label, Red, Green, Blue);
                Start_SampleNumber_Label.Content = this.Start_Sample;
                End_SampleNumber_Label.Content = this.End_Sample;
                Sample_Average_Label.Content = (decimal)Math.Round(this.Measurement_Data.Mean(), 6);
                Max_Recorded_Sample_Label.Content = (decimal)this.Measurement_Data.Maximum();
                Min_Recorded_Sample_Label.Content = (decimal)this.Measurement_Data.Minimum();
                Total_Samples_Label.Content = this.Measurement_Count;
                Positive_Samples_Label.Content = this.Measurement_Data.Where(x => x >= 0).Count();
                Negative_Samples_Label.Content = this.Measurement_Data.Where(x => x < 0).Count();
                Sample_Average_Label_Unit.Content = Measurement_Unit;
                Max_Recorded_Sample_Label_Unit.Content = Measurement_Unit;
                Min_Recorded_Sample_Label_Unit.Content = Measurement_Unit;
                if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
                {
                    Graph.Plot.Style(ScottPlot.Style.Black);
                    Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                    Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                }
                Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
                Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
                Graph.Plot.YLabel(Y_Axis_Label);
                Graph.Plot.XLabel("N Samples");
                Graph.Plot.Title(Graph_Title);
                Graph.Render();
                Set_Default_GraphColor_Math_AllSamples(Red, Green, Blue);
                Set_Default_GraphColor_Math_NSamples(Red, Green, Blue);
                Set_Default_Histogram_Color(Red, Green, Blue);
            }
            catch (Exception Ex)
            {
                Graph_Color_Menu.IsEnabled = false;
                Insert_Log(Ex.Message, 1);
                Insert_Log("Probably no data inside the Measurement Data Array", 1);
                Graph.Plot.AddAnnotation(Ex.Message, -10, -10);
                Graph.Plot.AddText("Failed to create an Math Waveform, try again.", 5, 0, size: 20, color: System.Drawing.Color.Red);
                Graph.Plot.AxisAuto();
                Graph.Render();
            }
        }

        private void Add_Measurement_Waveform(string Y_Axis_Label, int Red, int Green, int Blue)
        {
            Measurement_Plot = Graph.Plot.AddSignal(Measurement_Data, color: System.Drawing.Color.FromArgb(Red, Green, Blue), label: Y_Axis_Label);
            Measurement_Plot.UseParallel = true;
            Measurement_Plot.MarkerSize = 1;
            Graph.Render();
        }
    }
}
