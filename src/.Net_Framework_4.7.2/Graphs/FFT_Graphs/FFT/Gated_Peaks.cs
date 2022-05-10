using Gated_Peaks_Table;
using MahApps.Metro.Controls;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;

namespace FFT
{
    public partial class FFT_Plotter : MetroWindow
    {
        private ScottPlot.Plottable.VLine Gated_Peaks_Start_Plot_Marker;
        private ScottPlot.Plottable.VLine Gated_Peaks_Stop_Plot_Marker;

        private bool Gated_Peaks_IsEnabled = false;

        private double Gated_Peaks_Start_Value = 0;
        private double Gated_Peaks_Stop_Value = 0;

        private double Gated_Peaks_Panel_FloatingWidth = 208;
        private double Gated_Peaks_Panel_FloatingHeight = 208;

        private Gated_Peaks_Table_Window Gated_Peaks_Table;

        private ScottPlot.Plottable.Text G_P1;
        private ScottPlot.Plottable.Text G_P2;
        private ScottPlot.Plottable.Text G_P3;
        private ScottPlot.Plottable.Text G_P4;
        private ScottPlot.Plottable.Text G_P5;
        private ScottPlot.Plottable.Text G_P6;
        private ScottPlot.Plottable.Text G_P7;
        private ScottPlot.Plottable.Text G_P8;
        private ScottPlot.Plottable.Text G_P9;
        private ScottPlot.Plottable.Text G_P10;

        private void Enable_Disable_Gated_Peaks_Click(object sender, RoutedEventArgs e)
        {
            if (Gated_Peaks_EnableDisable_MenuItem.IsChecked)
            {
                Open_Gated_Peaks_Table_Panel();
                AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);

                Gated_Peaks_Start_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Peaks_Start_Plot_Marker = Graph.Plot.AddVerticalLine(Gated_Peaks_Start_Value, color: Color.DarkViolet, style: LineStyle.Dash, label: "Peak Start");
                Gated_Peaks_Start_Plot_Marker.PositionFormatter = x => "PS: " + Axis_Scale_Config.Value_SI_Prefix(x, 2) + "Hz";
                Gated_Peaks_Start_Plot_Marker.PositionLabelBackground = Color.DarkViolet;
                Gated_Peaks_Start_Plot_Marker.Dragged += Gated_Peaks_Marker_Start_Dragged_Event;
                Gated_Peaks_Start_Plot_Marker.PositionLabel = true;
                Gated_Peaks_Start_Plot_Marker.DragEnabled = true;

                Gated_Peaks_Stop_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Peaks_Stop_Plot_Marker = Graph.Plot.AddVerticalLine(Gated_Peaks_Stop_Value, color: Color.DarkViolet, style: LineStyle.Dash, label: "Peak End");
                Gated_Peaks_Stop_Plot_Marker.PositionFormatter = x => "PE: " + Axis_Scale_Config.Value_SI_Prefix(x, 2) + "Hz";
                Gated_Peaks_Stop_Plot_Marker.PositionLabelBackground = Color.DarkViolet;
                Gated_Peaks_Stop_Plot_Marker.Dragged += Gated_Peaks_Marker_Stop_Dragged_Event;
                Gated_Peaks_Stop_Plot_Marker.PositionLabel = true;
                Gated_Peaks_Stop_Plot_Marker.DragEnabled = true;

                G_Initialize_Plottable_Peaks();

                Graph.Refresh();
                Gated_Peaks_IsEnabled = true;

                if (Gated_Peaks_Table != null & Gated_Peaks_IsEnabled)
                {
                    try
                    {
                        Gated_Peaks_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Start_Value, 2) + "Hz";
                        Gated_Peaks_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Stop_Value, 2) + "Hz";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                Disable_Gated_Peaks();
            }
        }

        private void G_Initialize_Plottable_Peaks()
        {
            G_P1 = Graph.Plot.AddText("G_P1", 0, 0, 12, color: Color.DarkViolet);
            G_P1.Alignment = Alignment.MiddleCenter;
            G_P1.IsVisible = false;

            G_P2 = Graph.Plot.AddText("G_P2", 0, 0, 12, color: Color.DarkViolet);
            G_P2.Alignment = Alignment.MiddleCenter;
            G_P2.IsVisible = false;

            G_P3 = Graph.Plot.AddText("G_P3", 0, 0, 12, color: Color.DarkViolet);
            G_P3.Alignment = Alignment.MiddleCenter;
            G_P3.IsVisible = false;

            G_P4 = Graph.Plot.AddText("G_P4", 0, 0, 12, color: Color.DarkViolet);
            G_P4.Alignment = Alignment.MiddleCenter;
            G_P4.IsVisible = false;

            G_P5 = Graph.Plot.AddText("G_P5", 0, 0, 12, color: Color.DarkViolet);
            G_P5.Alignment = Alignment.MiddleCenter;
            G_P5.IsVisible = false;

            G_P6 = Graph.Plot.AddText("G_P6", 0, 0, 12, color: Color.DarkViolet);
            G_P6.Alignment = Alignment.MiddleCenter;
            G_P6.IsVisible = false;

            G_P7 = Graph.Plot.AddText("G_P7", 0, 0, 12, color: Color.DarkViolet);
            G_P7.Alignment = Alignment.MiddleCenter;
            G_P7.IsVisible = false;

            G_P8 = Graph.Plot.AddText("G_P8", 0, 0, 12, color: Color.DarkViolet);
            G_P8.Alignment = Alignment.MiddleCenter;
            G_P8.IsVisible = false;

            G_P9 = Graph.Plot.AddText("G_P9", 0, 0, 12, color: Color.DarkViolet);
            G_P9.Alignment = Alignment.MiddleCenter;
            G_P9.IsVisible = false;

            G_P10 = Graph.Plot.AddText("G_G_P10", 0, 0, 12, color: Color.DarkViolet);
            G_P10.Alignment = Alignment.MiddleCenter;
            G_P10.IsVisible = false;
        }

        private void Remove_Plottable_Peaks()
        {
            Graph.Plot.Remove(plottable: G_P1);
            Graph.Plot.Remove(plottable: G_P2);
            Graph.Plot.Remove(plottable: G_P3);
            Graph.Plot.Remove(plottable: G_P4);
            Graph.Plot.Remove(plottable: G_P5);
            Graph.Plot.Remove(plottable: G_P6);
            Graph.Plot.Remove(plottable: G_P7);
            Graph.Plot.Remove(plottable: G_P8);
            Graph.Plot.Remove(plottable: G_P9);
            Graph.Plot.Remove(plottable: G_P10);
        }

        private void Disable_Gated_Peaks()
        {
            Gated_Peaks_IsEnabled = false;
            Gated_Peaks_EnableDisable_MenuItem.IsChecked = false;
            Close_Gated_Peaks_Table_Window();
            Graph.Plot.Remove(plottable: Gated_Peaks_Start_Plot_Marker);
            Graph.Plot.Remove(plottable: Gated_Peaks_Stop_Plot_Marker);
            Remove_Plottable_Peaks();
            Graph.Refresh();
        }

        private void Open_Gated_Peaks_Table_Panel()
        {
            if (Gated_Peaks_Table == null)
            {
                Gated_Peaks_Table = new Gated_Peaks_Table_Window(Channel_Title + " FFT Gated Peaks ", FFT_Waveform.Color, "Magnitude", "Frequency (Hz)", Y_AXIS_Units, "Hz", Gated_Peaks_Panel_FloatingHeight, Gated_Peaks_Panel_FloatingWidth, true, true);
                Gated_Peaks_Table.Show();
                Gated_Peaks_Table.Closed += Close_Gated_Peaks_Table_Panel_Event;
                Insert_Log("Gated Peaks Table Opened", 5);
            }
        }

        private void Close_Gated_Peaks_Table_Panel_Event(object sender, EventArgs e)
        {
            try
            {
                Gated_Peaks_IsEnabled = false;
                Gated_Peaks_EnableDisable_MenuItem.IsChecked = false;

                Gated_Peaks_Table = null;
                Graph.Plot.Remove(plottable: Gated_Peaks_Start_Plot_Marker);
                Graph.Plot.Remove(plottable: Gated_Peaks_Stop_Plot_Marker);
                Remove_Plottable_Peaks();
                Graph.Refresh();
                Insert_Log("Gated Peaks Table Closed.", 5);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Gated_Peaks_Table_Window()
        {
            try
            {
                if (Gated_Peaks_Table != null)
                {
                    Gated_Peaks_Table.Close();
                    Gated_Peaks_Table = null;
                    Insert_Log("Gated Peaks Table Closed.", 5);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }

        }

        private void Gated_Peaks_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);
            double Gated_Start_Value = Gated_Peaks_Start_Plot_Marker.X;
            double Gated_Stop_Value = Gated_Peaks_Stop_Plot_Marker.X;
            if (Gated_Start_Value >= Gated_Stop_Value)
            {
                double New_Gated_Start_Plot_Marker_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Peaks_Start_Plot_Marker.X = New_Gated_Start_Plot_Marker_Value;
                this.Gated_Peaks_Start_Value = New_Gated_Start_Plot_Marker_Value;

                double New_Gated_Stop_Plot_Marker_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Peaks_Stop_Plot_Marker.X = New_Gated_Stop_Plot_Marker_Value;
                this.Gated_Peaks_Stop_Value = New_Gated_Stop_Plot_Marker_Value;
            }
            else
            {
                this.Gated_Peaks_Start_Value = Gated_Start_Value;
            }

            if (Gated_Peaks_Table != null & Gated_Peaks_IsEnabled)
            {
                try
                {
                    Gated_Peaks_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Start_Value, 2) + "Hz";
                    Gated_Peaks_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Stop_Value, 2) + "Hz";
                }
                catch (Exception) { }
            }
        }

        private void Gated_Peaks_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);
            double Gated_Start_Value = Gated_Peaks_Start_Plot_Marker.X;
            double Gated_Stop_Value = Gated_Peaks_Stop_Plot_Marker.X;
            if (Gated_Start_Value >= Gated_Stop_Value)
            {
                double New_Gated_Start_Plot_Marker_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Peaks_Start_Plot_Marker.X = New_Gated_Start_Plot_Marker_Value;
                this.Gated_Peaks_Start_Value = New_Gated_Start_Plot_Marker_Value;

                double New_Gated_Stop_Plot_Marker_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Peaks_Stop_Plot_Marker.X = New_Gated_Stop_Plot_Marker_Value;
                this.Gated_Peaks_Stop_Value = New_Gated_Stop_Plot_Marker_Value;
            }
            else
            {
                this.Gated_Peaks_Stop_Value = Gated_Stop_Value;
            }

            if (Gated_Peaks_Table != null & Gated_Peaks_IsEnabled)
            {
                try
                {
                    Gated_Peaks_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Start_Value, 2) + "Hz";
                    Gated_Peaks_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Stop_Value, 2) + "Hz";
                }
                catch (Exception) { }
            }
        }

        //Search Waveform Arrays for Gated Start and Stop Values and get their Array Index, Create Gated Array from Waveform Array
        private void Create_Gated_Peaks_Array(double[] X_Waveform_Values, double[] Y_Waveform_Values, int Data_Points)
        {
            double Gated_Start_Value = this.Gated_Peaks_Start_Value;
            double Gated_Stop_Value = this.Gated_Peaks_Stop_Value;

            int Gated_Start_Index = 0;
            int Gated_Stop_Index = 0;
            bool Gated_Start_Value_Found = false;
            bool Gated_Stop_Value_Found = false;
            for (int i = 0; i < Data_Points; i++)
            {
                if (Gated_Start_Value_Found != true)
                {
                    if (X_Waveform_Values[i] >= Gated_Start_Value)
                    {
                        Gated_Start_Index = i;
                        Gated_Start_Value_Found = true;
                    }
                }
                if (Gated_Stop_Value_Found != true)
                {
                    if (X_Waveform_Values[i] >= Gated_Stop_Value)
                    {
                        Gated_Stop_Index = i - 1;
                        Gated_Stop_Value_Found = true;
                        break;
                    }
                }
            }

            if (Gated_Start_Value_Found & Gated_Stop_Value_Found)
            {
                int Gated_Arrays_DataPoints_Count = (Gated_Stop_Index - Gated_Start_Index) + 1;
                if (Gated_Arrays_DataPoints_Count > 1)
                {
                    double[] Gated_X_Array = new double[Gated_Arrays_DataPoints_Count];
                    double[] Gated_Y_Array = new double[Gated_Arrays_DataPoints_Count];

                    Array.Copy(X_Waveform_Values, Gated_Start_Index, Gated_X_Array, 0, Gated_Arrays_DataPoints_Count);
                    Array.Copy(Y_Waveform_Values, Gated_Start_Index, Gated_Y_Array, 0, Gated_Arrays_DataPoints_Count);

                    IEnumerable<Tuple<int, double>> Peaks = G_LocalMaxima(Gated_Y_Array, Peak_Window_Size, Peak_Reference_Level);
                    Peaks.OrderByDescending(x => x.Item2);
                    int Total_Peaks_Found = Peaks.Count();

                    if (Total_Peaks_Found > 0)
                    {
                        double[] X_Values;
                        double[] Y_Values;

                        if (Total_Peaks_Found <= 10)
                        {
                            X_Values = new double[Total_Peaks_Found];
                            Y_Values = new double[Total_Peaks_Found];

                            int i = 0;
                            foreach (Tuple<int, double> Value in Peaks)
                            {
                                X_Values[i] = Gated_X_Array[Value.Item1];
                                Y_Values[i] = Value.Item2;
                                i++;
                                if (i >= Total_Peaks_Found)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            X_Values = new double[10];
                            Y_Values = new double[10];

                            int i = 0;
                            foreach (Tuple<int, double> Value in Peaks)
                            {
                                X_Values[i] = Gated_X_Array[Value.Item1];
                                Y_Values[i] = Value.Item2;
                                i++;
                                if (i >= 10)
                                {
                                    break;
                                }
                            }
                        }

                        if (Total_Peaks_Found >= 1)
                        {
                            G_P1.X = X_Values[0]; //X Value
                            G_P1.Y = Y_Values[0]; //Y Value
                        }
                        if (Total_Peaks_Found >= 2)
                        {
                            G_P2.X = X_Values[1]; //X Value
                            G_P2.Y = Y_Values[1]; //Y Value
                        }
                        if (Total_Peaks_Found >= 3)
                        {
                            G_P3.X = X_Values[2]; //X Value
                            G_P3.Y = Y_Values[2]; //Y Value
                        }
                        if (Total_Peaks_Found >= 4)
                        {
                            G_P4.X = X_Values[3]; //X Value
                            G_P4.Y = Y_Values[3]; //Y Value
                        }
                        if (Total_Peaks_Found >= 5)
                        {
                            G_P5.X = X_Values[4]; //X Value
                            G_P5.Y = Y_Values[4]; //Y Value
                        }
                        if (Total_Peaks_Found >= 6)
                        {
                            G_P6.X = X_Values[5]; //X Value
                            G_P6.Y = Y_Values[5]; //Y Value
                        }
                        if (Total_Peaks_Found >= 7)
                        {
                            G_P7.X = X_Values[6]; //X Value
                            G_P7.Y = Y_Values[6]; //Y Value
                        }
                        if (Total_Peaks_Found >= 8)
                        {
                            G_P8.X = X_Values[7]; //X Value
                            G_P8.Y = Y_Values[7]; //Y Value
                        }
                        if (Total_Peaks_Found >= 9)
                        {
                            G_P9.X = X_Values[8]; //X Value
                            G_P9.Y = Y_Values[8]; //Y Value
                        }
                        if (Total_Peaks_Found >= 10)
                        {
                            G_P10.X = X_Values[9]; //X Value
                            G_P10.Y = Y_Values[9]; //Y Value
                        }

                        G_Visible_Peaks(Total_Peaks_Found);

                        if (Gated_Peaks_IsEnabled)
                        {
                            Gated_Peaks_Table.Peaks_Table_Process_Data(Y_Values, X_Values, Total_Peaks_Found);
                        }
                    }
                    else
                    {
                        G_Visible_Peaks(0);
                        if (Gated_Peaks_IsEnabled)
                        {
                            Gated_Peaks_Table.Peaks_Table_Process_Data(null, null, 0);
                        }
                    }
                }
                else
                {
                    G_Visible_Peaks(0);
                    if (Gated_Peaks_IsEnabled)
                    {
                        Gated_Peaks_Table.Peaks_Table_Process_Data(null, null, 0);
                    }
                }
            }
            else
            {
                G_Visible_Peaks(0);
                if (Gated_Peaks_IsEnabled)
                {
                    Gated_Peaks_Table.Peaks_Table_Process_Data(null, null, 0);
                }
            }
        }

        public IEnumerable<Tuple<int, double>> G_LocalMaxima(IEnumerable<double> source, int windowSize, double Reference_Level)
        {
            //https://stackoverflow.com/questions/5269000/finding-local-maxima-over-a-dynamic-range Jeroen Cranendonk
            // Round up to nearest odd value
            windowSize = windowSize - windowSize % 2 + 1;
            int halfWindow = windowSize / 2;

            int index = 0;
            var before = new Queue<double>(Enumerable.Repeat(double.NegativeInfinity, halfWindow));
            var after = new Queue<double>(source.Take(halfWindow + 1));

            foreach (double d in source.Skip(halfWindow + 1).Concat(Enumerable.Repeat(double.NegativeInfinity, halfWindow + 1)))
            {
                double curVal = after.Dequeue();
                if (before.All(x => curVal > x) && after.All(x => curVal >= x) && curVal >= Reference_Level)
                {
                    yield return Tuple.Create(index, curVal);
                }

                before.Enqueue(curVal);
                before.Dequeue();
                after.Enqueue(d);
                index++;
            }
        }

        private void G_Visible_Peaks(int Selected)
        {
            if (Selected >= 1)
            {
                G_P1.IsVisible = true;
            }
            else
            {
                G_P1.IsVisible = false;
            }
            if (Selected >= 2)
            {
                G_P2.IsVisible = true;
            }
            else
            {
                G_P2.IsVisible = false;
            }
            if (Selected >= 3)
            {
                G_P3.IsVisible = true;
            }
            else
            {
                G_P3.IsVisible = false;
            }
            if (Selected >= 4)
            {
                G_P4.IsVisible = true;
            }
            else
            {
                G_P4.IsVisible = false;
            }
            if (Selected >= 5)
            {
                G_P5.IsVisible = true;
            }
            else
            {
                G_P5.IsVisible = false;
            }
            if (Selected >= 6)
            {
                G_P6.IsVisible = true;
            }
            else
            {
                G_P6.IsVisible = false;
            }
            if (Selected >= 7)
            {
                G_P7.IsVisible = true;
            }
            else
            {
                G_P7.IsVisible = false;
            }
            if (Selected >= 8)
            {
                G_P8.IsVisible = true;
            }
            else
            {
                G_P8.IsVisible = false;
            }
            if (Selected >= 9)
            {
                G_P9.IsVisible = true;
            }
            else
            {
                G_P9.IsVisible = false;
            }
            if (Selected >= 10)
            {
                G_P10.IsVisible = true;
            }
            else
            {
                G_P10.IsVisible = false;
            }
        }

        private void Set_Gated_Peaks_Units(string Units)
        {
            try
            {
                if (Gated_Peaks_IsEnabled || Gated_Peaks_Table != null)
                {
                    Gated_Peaks_Table.Y_Values_Units = Units;
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }
    }
}
