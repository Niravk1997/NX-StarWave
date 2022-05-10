using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
    {
        private bool Persistence_Waveform_Process_Ready = false;

        private int Recorded_DataPoints = 0;
        private double Recorded_Total_Time = 0;

        private double[] Persistence_1_Plot_X;
        private double[] Persistence_1_Plot_Y;

        private ScottPlot.Plottable.SignalPlotXY Persistence_2_Plot = null;
        private double[] Persistence_2_Plot_X;
        private double[] Persistence_2_Plot_Y;

        private ScottPlot.Plottable.SignalPlotXY Persistence_3_Plot = null;
        private double[] Persistence_3_Plot_X;
        private double[] Persistence_3_Plot_Y;

        private ScottPlot.Plottable.SignalPlotXY Persistence_4_Plot = null;
        private double[] Persistence_4_Plot_X;
        private double[] Persistence_4_Plot_Y;

        private ScottPlot.Plottable.SignalPlotXY Persistence_5_Plot = null;
        private double[] Persistence_5_Plot_X;
        private double[] Persistence_5_Plot_Y;

        private ScottPlot.Plottable.SignalPlotXY Persistence_6_Plot = null;
        private double[] Persistence_6_Plot_X;
        private double[] Persistence_6_Plot_Y;

        private ScottPlot.Plottable.SignalPlotXY Persistence_7_Plot = null;
        private double[] Persistence_7_Plot_X;
        private double[] Persistence_7_Plot_Y;

        private ScottPlot.Plottable.SignalPlotXY Persistence_8_Plot = null;
        private double[] Persistence_8_Plot_X;
        private double[] Persistence_8_Plot_Y;

        private ScottPlot.Plottable.SignalPlotXY Persistence_9_Plot = null;
        private double[] Persistence_9_Plot_X;
        private double[] Persistence_9_Plot_Y;

        private ScottPlot.Plottable.SignalPlotXY Persistence_10_Plot = null;
        private double[] Persistence_10_Plot_X;
        private double[] Persistence_10_Plot_Y;

        private void Enable_Persistence_Effect_Click(object sender, RoutedEventArgs e)
        {
            if (Persistence_Effect_IsEnabled)
            {
                Recorded_DataPoints = 0;
                Recorded_Total_Time = 0;
                Initialize_Intensities_Array(1);
                Initialize_Persistence_Waveforms(Persistence_Color);
                Persistence_Waveforms_Visible(Visible_Persistence_Waveforms);
                Persistence_Waveform_Process_Ready = true;
            }
            else
            {
                Persistence_Waveform_Process_Ready = false;
                Remove_Persistence_Waveforms();
                Null_Intensities_Array();
            }
        }

        private void Set_Initial_Persistence_Color(string Color)
        {
            Persistence_Color = Color;
        }

        private void Set_Persistence_Color()
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(Persistence_Color);
            if (Persistence_Color_SelectedType == 0)
            {
                Set_Persistence_WaveformColors(new double[] { 255, 255, 255, 255, 255, 255, 255, 255, 255 }, color);
            }
            else
            {
                Set_Persistence_WaveformColors(new double[] { 230, 205, 180, 155, 130, 105, 80, 55, 30 }, color);
            }
        }

        private void Set_Persistence_WaveformColors(double[] Alpha, System.Drawing.Color color)
        {
            if (Persistence_2_Plot != null)
            {
                Persistence_2_Plot.Color = System.Drawing.Color.FromArgb((int)Alpha[0], color);
            }
            if (Persistence_3_Plot != null)
            {
                Persistence_3_Plot.Color = System.Drawing.Color.FromArgb((int)Alpha[1], color);
            }
            if (Persistence_4_Plot != null)
            {
                Persistence_4_Plot.Color = System.Drawing.Color.FromArgb((int)Alpha[2], color);
            }
            if (Persistence_5_Plot != null)
            {
                Persistence_5_Plot.Color = System.Drawing.Color.FromArgb((int)Alpha[3], color);
            }
            if (Persistence_6_Plot != null)
            {
                Persistence_6_Plot.Color = System.Drawing.Color.FromArgb((int)Alpha[4], color);
            }
            if (Persistence_7_Plot != null)
            {
                Persistence_7_Plot.Color = System.Drawing.Color.FromArgb((int)Alpha[5], color);
            }
            if (Persistence_8_Plot != null)
            {
                Persistence_8_Plot.Color = System.Drawing.Color.FromArgb((int)Alpha[6], color);
            }
            if (Persistence_9_Plot != null)
            {
                Persistence_9_Plot.Color = System.Drawing.Color.FromArgb((int)Alpha[7], color);
            }
            if (Persistence_10_Plot != null)
            {
                Persistence_10_Plot.Color = System.Drawing.Color.FromArgb((int)Alpha[8], color);
            }
        }

        private void Process_Persistence_Waveform_Data()
        {
            if (Data_Points == Recorded_DataPoints & Total_Time == Recorded_Total_Time)
            {
                Array_Level_Down();
            }
            else
            {
                Recorded_DataPoints = Data_Points;
                Recorded_Total_Time = Total_Time;
                Initialize_Intensities_Array(Data_Points);
                Array_Level_Down();
            }
        }

        public void Initialize_Intensities_Array(int N_Samples)
        {
            Persistence_1_Plot_X = new double[N_Samples];
            Persistence_1_Plot_Y = new double[N_Samples];

            Persistence_2_Plot_X = new double[N_Samples];
            Persistence_2_Plot_Y = new double[N_Samples];

            Persistence_3_Plot_X = new double[N_Samples];
            Persistence_3_Plot_Y = new double[N_Samples];

            Persistence_4_Plot_X = new double[N_Samples];
            Persistence_4_Plot_Y = new double[N_Samples];

            Persistence_5_Plot_X = new double[N_Samples];
            Persistence_5_Plot_Y = new double[N_Samples];

            Persistence_6_Plot_X = new double[N_Samples];
            Persistence_6_Plot_Y = new double[N_Samples];

            Persistence_7_Plot_X = new double[N_Samples];
            Persistence_7_Plot_Y = new double[N_Samples];

            Persistence_8_Plot_X = new double[N_Samples];
            Persistence_8_Plot_Y = new double[N_Samples];

            Persistence_9_Plot_X = new double[N_Samples];
            Persistence_9_Plot_Y = new double[N_Samples];

            Persistence_10_Plot_X = new double[N_Samples];
            Persistence_10_Plot_Y = new double[N_Samples];
        }

        public void Null_Intensities_Array()
        {
            Persistence_1_Plot_X = null;
            Persistence_1_Plot_Y = null;

            Persistence_2_Plot_X = null;
            Persistence_2_Plot_Y = null;

            Persistence_3_Plot_X = null;
            Persistence_3_Plot_Y = null;

            Persistence_4_Plot_X = null;
            Persistence_4_Plot_Y = null;

            Persistence_5_Plot_X = null;
            Persistence_5_Plot_Y = null;

            Persistence_6_Plot_X = null;
            Persistence_6_Plot_Y = null;

            Persistence_7_Plot_X = null;
            Persistence_7_Plot_Y = null;

            Persistence_8_Plot_X = null;
            Persistence_8_Plot_Y = null;

            Persistence_9_Plot_X = null;
            Persistence_9_Plot_Y = null;

            Persistence_10_Plot_X = null;
            Persistence_10_Plot_Y = null;
        }

        private void Initialize_Persistence_Waveforms(string Color)
        {
            Persistence_2_Plot = Graph.Plot.AddSignalXY(Persistence_2_Plot_X, Persistence_2_Plot_Y, color: System.Drawing.ColorTranslator.FromHtml(Color), label: null);
            Persistence_2_Plot.MarkerSize = 1;
            Persistence_2_Plot.MaxRenderIndex = 0;
            Persistence_2_Plot.IsVisible = false;
            Persistence_3_Plot = Graph.Plot.AddSignalXY(Persistence_3_Plot_X, Persistence_3_Plot_Y, color: System.Drawing.ColorTranslator.FromHtml(Color), label: null);
            Persistence_3_Plot.MarkerSize = 1;
            Persistence_3_Plot.MaxRenderIndex = 0;
            Persistence_3_Plot.IsVisible = false;
            Persistence_4_Plot = Graph.Plot.AddSignalXY(Persistence_4_Plot_X, Persistence_4_Plot_Y, color: System.Drawing.ColorTranslator.FromHtml(Color), label: null);
            Persistence_4_Plot.MarkerSize = 1;
            Persistence_4_Plot.MaxRenderIndex = 0;
            Persistence_4_Plot.IsVisible = false;
            Persistence_5_Plot = Graph.Plot.AddSignalXY(Persistence_5_Plot_X, Persistence_5_Plot_Y, color: System.Drawing.ColorTranslator.FromHtml(Color), label: null);
            Persistence_5_Plot.MarkerSize = 1;
            Persistence_5_Plot.MaxRenderIndex = 0;
            Persistence_5_Plot.IsVisible = false;
            Persistence_6_Plot = Graph.Plot.AddSignalXY(Persistence_6_Plot_X, Persistence_6_Plot_Y, color: System.Drawing.ColorTranslator.FromHtml(Color), label: null);
            Persistence_6_Plot.MarkerSize = 1;
            Persistence_6_Plot.MaxRenderIndex = 0;
            Persistence_6_Plot.IsVisible = false;
            Persistence_7_Plot = Graph.Plot.AddSignalXY(Persistence_7_Plot_X, Persistence_7_Plot_Y, color: System.Drawing.ColorTranslator.FromHtml(Color), label: null);
            Persistence_7_Plot.MarkerSize = 1;
            Persistence_7_Plot.MaxRenderIndex = 0;
            Persistence_7_Plot.IsVisible = false;
            Persistence_8_Plot = Graph.Plot.AddSignalXY(Persistence_8_Plot_X, Persistence_8_Plot_Y, color: System.Drawing.ColorTranslator.FromHtml(Color), label: null);
            Persistence_8_Plot.MarkerSize = 1;
            Persistence_8_Plot.MaxRenderIndex = 0;
            Persistence_8_Plot.IsVisible = false;
            Persistence_9_Plot = Graph.Plot.AddSignalXY(Persistence_9_Plot_X, Persistence_9_Plot_Y, color: System.Drawing.ColorTranslator.FromHtml(Color), label: null);
            Persistence_9_Plot.MarkerSize = 1;
            Persistence_9_Plot.MaxRenderIndex = 0;
            Persistence_9_Plot.IsVisible = false;
            Persistence_10_Plot = Graph.Plot.AddSignalXY(Persistence_10_Plot_X, Persistence_10_Plot_Y, color: System.Drawing.ColorTranslator.FromHtml(Color), label: null);
            Persistence_10_Plot.MarkerSize = 1;
            Persistence_10_Plot.MaxRenderIndex = 0;
            Persistence_10_Plot.IsVisible = false;
        }

        private void Update_Visible_Persistence_Waveforms()
        {
            if (Visible_Persistence_Waveforms >= 2)
            {
                Persistence_2_Plot.MaxRenderIndex = 0;
                Persistence_2_Plot.Xs = Persistence_2_Plot_X;
                Persistence_2_Plot.Ys = Persistence_2_Plot_Y;
                Persistence_2_Plot.MaxRenderIndex = Data_Points - 1;
            }
            if (Visible_Persistence_Waveforms >= 3)
            {
                Persistence_3_Plot.MaxRenderIndex = 0;
                Persistence_3_Plot.Xs = Persistence_3_Plot_X;
                Persistence_3_Plot.Ys = Persistence_3_Plot_Y;
                Persistence_3_Plot.MaxRenderIndex = Data_Points - 1;
            }
            if (Visible_Persistence_Waveforms >= 4)
            {
                Persistence_4_Plot.MaxRenderIndex = 0;
                Persistence_4_Plot.Xs = Persistence_4_Plot_X;
                Persistence_4_Plot.Ys = Persistence_4_Plot_Y;
                Persistence_4_Plot.MaxRenderIndex = Data_Points - 1;
            }
            if (Visible_Persistence_Waveforms >= 5)
            {
                Persistence_5_Plot.MaxRenderIndex = 0;
                Persistence_5_Plot.Xs = Persistence_5_Plot_X;
                Persistence_5_Plot.Ys = Persistence_5_Plot_Y;
                Persistence_5_Plot.MaxRenderIndex = Data_Points - 1;
            }
            if (Visible_Persistence_Waveforms >= 6)
            {
                Persistence_6_Plot.MaxRenderIndex = 0;
                Persistence_6_Plot.Xs = Persistence_6_Plot_X;
                Persistence_6_Plot.Ys = Persistence_6_Plot_Y;
                Persistence_6_Plot.MaxRenderIndex = Data_Points - 1;
            }
            if (Visible_Persistence_Waveforms >= 7)
            {
                Persistence_7_Plot.MaxRenderIndex = 0;
                Persistence_7_Plot.Xs = Persistence_7_Plot_X;
                Persistence_7_Plot.Ys = Persistence_7_Plot_Y;
                Persistence_7_Plot.MaxRenderIndex = Data_Points - 1;
            }
            if (Visible_Persistence_Waveforms >= 8)
            {
                Persistence_8_Plot.MaxRenderIndex = 0;
                Persistence_8_Plot.Xs = Persistence_8_Plot_X;
                Persistence_8_Plot.Ys = Persistence_8_Plot_Y;
                Persistence_8_Plot.MaxRenderIndex = Data_Points - 1;
            }
            if (Visible_Persistence_Waveforms >= 9)
            {
                Persistence_9_Plot.MaxRenderIndex = 0;
                Persistence_9_Plot.Xs = Persistence_9_Plot_X;
                Persistence_9_Plot.Ys = Persistence_9_Plot_Y;
                Persistence_9_Plot.MaxRenderIndex = Data_Points - 1;
            }
            if (Visible_Persistence_Waveforms >= 10)
            {
                Persistence_10_Plot.MaxRenderIndex = 0;
                Persistence_10_Plot.Xs = Persistence_10_Plot_X;
                Persistence_10_Plot.Ys = Persistence_10_Plot_Y;
                Persistence_10_Plot.MaxRenderIndex = Data_Points - 1;
            }
        }

        private void Array_Level_Down()
        {
            if (Visible_Persistence_Waveforms == 10)
            {
                Array_Copy(Persistence_9_Plot_X, Persistence_9_Plot_Y, Persistence_10_Plot_X, Persistence_10_Plot_Y, Data_Points);
                Array_Copy(Persistence_8_Plot_X, Persistence_8_Plot_Y, Persistence_9_Plot_X, Persistence_9_Plot_Y, Data_Points);
                Array_Copy(Persistence_7_Plot_X, Persistence_7_Plot_Y, Persistence_8_Plot_X, Persistence_8_Plot_Y, Data_Points);
                Array_Copy(Persistence_6_Plot_X, Persistence_6_Plot_Y, Persistence_7_Plot_X, Persistence_7_Plot_Y, Data_Points);
                Array_Copy(Persistence_5_Plot_X, Persistence_5_Plot_Y, Persistence_6_Plot_X, Persistence_6_Plot_Y, Data_Points);
                Array_Copy(Persistence_4_Plot_X, Persistence_4_Plot_Y, Persistence_5_Plot_X, Persistence_5_Plot_Y, Data_Points);
                Array_Copy(Persistence_3_Plot_X, Persistence_3_Plot_Y, Persistence_4_Plot_X, Persistence_4_Plot_Y, Data_Points);
                Array_Copy(Persistence_2_Plot_X, Persistence_2_Plot_Y, Persistence_3_Plot_X, Persistence_3_Plot_Y, Data_Points);
                Array_Copy(Persistence_1_Plot_X, Persistence_1_Plot_Y, Persistence_2_Plot_X, Persistence_2_Plot_Y, Data_Points);
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
            else if (Visible_Persistence_Waveforms == 9)
            {
                Array_Copy(Persistence_8_Plot_X, Persistence_8_Plot_Y, Persistence_9_Plot_X, Persistence_9_Plot_Y, Data_Points);
                Array_Copy(Persistence_7_Plot_X, Persistence_7_Plot_Y, Persistence_8_Plot_X, Persistence_8_Plot_Y, Data_Points);
                Array_Copy(Persistence_6_Plot_X, Persistence_6_Plot_Y, Persistence_7_Plot_X, Persistence_7_Plot_Y, Data_Points);
                Array_Copy(Persistence_5_Plot_X, Persistence_5_Plot_Y, Persistence_6_Plot_X, Persistence_6_Plot_Y, Data_Points);
                Array_Copy(Persistence_4_Plot_X, Persistence_4_Plot_Y, Persistence_5_Plot_X, Persistence_5_Plot_Y, Data_Points);
                Array_Copy(Persistence_3_Plot_X, Persistence_3_Plot_Y, Persistence_4_Plot_X, Persistence_4_Plot_Y, Data_Points);
                Array_Copy(Persistence_2_Plot_X, Persistence_2_Plot_Y, Persistence_3_Plot_X, Persistence_3_Plot_Y, Data_Points);
                Array_Copy(Persistence_1_Plot_X, Persistence_1_Plot_Y, Persistence_2_Plot_X, Persistence_2_Plot_Y, Data_Points);
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
            else if (Visible_Persistence_Waveforms == 8)
            {
                Array_Copy(Persistence_7_Plot_X, Persistence_7_Plot_Y, Persistence_8_Plot_X, Persistence_8_Plot_Y, Data_Points);
                Array_Copy(Persistence_6_Plot_X, Persistence_6_Plot_Y, Persistence_7_Plot_X, Persistence_7_Plot_Y, Data_Points);
                Array_Copy(Persistence_5_Plot_X, Persistence_5_Plot_Y, Persistence_6_Plot_X, Persistence_6_Plot_Y, Data_Points);
                Array_Copy(Persistence_4_Plot_X, Persistence_4_Plot_Y, Persistence_5_Plot_X, Persistence_5_Plot_Y, Data_Points);
                Array_Copy(Persistence_3_Plot_X, Persistence_3_Plot_Y, Persistence_4_Plot_X, Persistence_4_Plot_Y, Data_Points);
                Array_Copy(Persistence_2_Plot_X, Persistence_2_Plot_Y, Persistence_3_Plot_X, Persistence_3_Plot_Y, Data_Points);
                Array_Copy(Persistence_1_Plot_X, Persistence_1_Plot_Y, Persistence_2_Plot_X, Persistence_2_Plot_Y, Data_Points);
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
            else if (Visible_Persistence_Waveforms == 7)
            {
                Array_Copy(Persistence_6_Plot_X, Persistence_6_Plot_Y, Persistence_7_Plot_X, Persistence_7_Plot_Y, Data_Points);
                Array_Copy(Persistence_5_Plot_X, Persistence_5_Plot_Y, Persistence_6_Plot_X, Persistence_6_Plot_Y, Data_Points);
                Array_Copy(Persistence_4_Plot_X, Persistence_4_Plot_Y, Persistence_5_Plot_X, Persistence_5_Plot_Y, Data_Points);
                Array_Copy(Persistence_3_Plot_X, Persistence_3_Plot_Y, Persistence_4_Plot_X, Persistence_4_Plot_Y, Data_Points);
                Array_Copy(Persistence_2_Plot_X, Persistence_2_Plot_Y, Persistence_3_Plot_X, Persistence_3_Plot_Y, Data_Points);
                Array_Copy(Persistence_1_Plot_X, Persistence_1_Plot_Y, Persistence_2_Plot_X, Persistence_2_Plot_Y, Data_Points);
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
            else if (Visible_Persistence_Waveforms == 6)
            {
                Array_Copy(Persistence_5_Plot_X, Persistence_5_Plot_Y, Persistence_6_Plot_X, Persistence_6_Plot_Y, Data_Points);
                Array_Copy(Persistence_4_Plot_X, Persistence_4_Plot_Y, Persistence_5_Plot_X, Persistence_5_Plot_Y, Data_Points);
                Array_Copy(Persistence_3_Plot_X, Persistence_3_Plot_Y, Persistence_4_Plot_X, Persistence_4_Plot_Y, Data_Points);
                Array_Copy(Persistence_2_Plot_X, Persistence_2_Plot_Y, Persistence_3_Plot_X, Persistence_3_Plot_Y, Data_Points);
                Array_Copy(Persistence_1_Plot_X, Persistence_1_Plot_Y, Persistence_2_Plot_X, Persistence_2_Plot_Y, Data_Points);
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
            else if (Visible_Persistence_Waveforms == 5)
            {
                Array_Copy(Persistence_4_Plot_X, Persistence_4_Plot_Y, Persistence_5_Plot_X, Persistence_5_Plot_Y, Data_Points);
                Array_Copy(Persistence_3_Plot_X, Persistence_3_Plot_Y, Persistence_4_Plot_X, Persistence_4_Plot_Y, Data_Points);
                Array_Copy(Persistence_2_Plot_X, Persistence_2_Plot_Y, Persistence_3_Plot_X, Persistence_3_Plot_Y, Data_Points);
                Array_Copy(Persistence_1_Plot_X, Persistence_1_Plot_Y, Persistence_2_Plot_X, Persistence_2_Plot_Y, Data_Points);
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
            else if (Visible_Persistence_Waveforms == 4)
            {
                Array_Copy(Persistence_3_Plot_X, Persistence_3_Plot_Y, Persistence_4_Plot_X, Persistence_4_Plot_Y, Data_Points);
                Array_Copy(Persistence_2_Plot_X, Persistence_2_Plot_Y, Persistence_3_Plot_X, Persistence_3_Plot_Y, Data_Points);
                Array_Copy(Persistence_1_Plot_X, Persistence_1_Plot_Y, Persistence_2_Plot_X, Persistence_2_Plot_Y, Data_Points);
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
            else if (Visible_Persistence_Waveforms == 3)
            {
                Array_Copy(Persistence_2_Plot_X, Persistence_2_Plot_Y, Persistence_3_Plot_X, Persistence_3_Plot_Y, Data_Points);
                Array_Copy(Persistence_1_Plot_X, Persistence_1_Plot_Y, Persistence_2_Plot_X, Persistence_2_Plot_Y, Data_Points);
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
            else if (Visible_Persistence_Waveforms == 2)
            {
                Array_Copy(Persistence_1_Plot_X, Persistence_1_Plot_Y, Persistence_2_Plot_X, Persistence_2_Plot_Y, Data_Points);
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
            else if (Visible_Persistence_Waveforms == 1)
            {
                Array_Copy(X_Waveform_Values, Y_Waveform_Values, Persistence_1_Plot_X, Persistence_1_Plot_Y, Data_Points);
            }
        }

        private void Array_Copy(double[] Source_X_Array, double[] Source_Y_Array, double[] Destination_X_Array, double[] Destination_Y_Array, int Size)
        {
            Array.Copy(Source_X_Array, Destination_X_Array, Size);
            Array.Copy(Source_Y_Array, Destination_Y_Array, Size);
        }

        private void Remove_Persistence_Waveforms()
        {
            Graph.Plot.Remove(plottable: Persistence_2_Plot);
            Graph.Plot.Remove(plottable: Persistence_3_Plot);
            Graph.Plot.Remove(plottable: Persistence_4_Plot);
            Graph.Plot.Remove(plottable: Persistence_5_Plot);
            Graph.Plot.Remove(plottable: Persistence_6_Plot);
            Graph.Plot.Remove(plottable: Persistence_7_Plot);
            Graph.Plot.Remove(plottable: Persistence_8_Plot);
            Graph.Plot.Remove(plottable: Persistence_9_Plot);
            Graph.Plot.Remove(plottable: Persistence_10_Plot);
        }

        private void Persistence_Waveforms_Visible(int Select)
        {
            if (Select >= 2)
            {
                if (Persistence_2_Plot != null)
                {
                    Persistence_2_Plot.IsVisible = true;
                }
            }
            else
            {
                if (Persistence_2_Plot != null)
                {
                    Persistence_2_Plot.IsVisible = false;
                }
            }
            if (Select >= 3)
            {
                if (Persistence_3_Plot != null)
                {
                    Persistence_3_Plot.IsVisible = true;
                }
            }
            else
            {
                if (Persistence_3_Plot != null)
                {
                    Persistence_3_Plot.IsVisible = false;
                }
            }
            if (Select >= 4)
            {
                if (Persistence_4_Plot != null)
                {
                    Persistence_4_Plot.IsVisible = true;
                }
            }
            else
            {
                if (Persistence_4_Plot != null)
                {
                    Persistence_4_Plot.IsVisible = false;
                }
            }
            if (Select >= 5)
            {
                if (Persistence_5_Plot != null)
                {
                    Persistence_5_Plot.IsVisible = true;
                }
            }
            else
            {
                if (Persistence_5_Plot != null)
                {
                    Persistence_5_Plot.IsVisible = false;
                }
            }
            if (Select >= 6)
            {
                if (Persistence_6_Plot != null)
                {
                    Persistence_6_Plot.IsVisible = true;
                }
            }
            else
            {
                if (Persistence_6_Plot != null)
                {
                    Persistence_6_Plot.IsVisible = false;
                }
            }
            if (Select >= 7)
            {
                if (Persistence_7_Plot != null)
                {
                    Persistence_7_Plot.IsVisible = true;
                }
            }
            else
            {
                if (Persistence_7_Plot != null)
                {
                    Persistence_7_Plot.IsVisible = false;
                }
            }
            if (Select >= 8)
            {
                if (Persistence_8_Plot != null)
                {
                    Persistence_8_Plot.IsVisible = true;
                }
            }
            else
            {
                if (Persistence_8_Plot != null)
                {
                    Persistence_8_Plot.IsVisible = false;
                }
            }
            if (Select >= 9)
            {
                if (Persistence_9_Plot != null)
                {
                    Persistence_9_Plot.IsVisible = true;
                }
            }
            else
            {
                if (Persistence_9_Plot != null)
                {
                    Persistence_9_Plot.IsVisible = false;
                }
            }
            if (Select >= 10)
            {
                if (Persistence_10_Plot != null)
                {
                    Persistence_10_Plot.IsVisible = true;
                }
            }
            else
            {
                if (Persistence_10_Plot != null)
                {
                    Persistence_10_Plot.IsVisible = false;
                }
            }
        }
    }
}
