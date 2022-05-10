using Gated_Peaks_Table;
using MahApps.Metro.Controls;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
    {
        private ScottPlot.Plottable.VLine Gated_Peaks_Start_Plot_Marker;
        private ScottPlot.Plottable.VLine Gated_Peaks_Stop_Plot_Marker;

        private bool Gated_Peaks_IsEnabled = false;

        private double Gated_Peaks_Start_Value = 0;
        private double Gated_Peaks_Stop_Value = 0;

        private double Gated_Peaks_Panel_FloatingWidth = 208;
        private double Gated_Peaks_Panel_FloatingHeight = 208;

        private Gated_Peaks_Table_Window Gated_Peaks_Table;

        private ScottPlot.Plottable.Text P1;
        private ScottPlot.Plottable.Text P2;
        private ScottPlot.Plottable.Text P3;
        private ScottPlot.Plottable.Text P4;
        private ScottPlot.Plottable.Text P5;
        private ScottPlot.Plottable.Text P6;
        private ScottPlot.Plottable.Text P7;
        private ScottPlot.Plottable.Text P8;
        private ScottPlot.Plottable.Text P9;
        private ScottPlot.Plottable.Text P10;

        private void Enable_Disable_Gated_Peaks_Click(object sender, RoutedEventArgs e)
        {
            if (Gated_Peaks_EnableDisable_MenuItem.IsChecked)
            {
                Open_Gated_Peaks_Table_Panel();
                AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);

                Gated_Peaks_Start_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Peaks_Start_Plot_Marker = Graph.Plot.AddVerticalLine(Gated_Peaks_Start_Value, color: Color.DarkViolet, style: LineStyle.Dash, label: "Peak Start");
                Gated_Peaks_Start_Plot_Marker.PositionFormatter = x => "PS: " + Axis_Scale_Config.Value_SI_Prefix(x, 2) + "s";
                Gated_Peaks_Start_Plot_Marker.PositionLabelBackground = Color.DarkViolet;
                Gated_Peaks_Start_Plot_Marker.Dragged += Gated_Peaks_Marker_Start_Dragged_Event;
                Gated_Peaks_Start_Plot_Marker.PositionLabel = true;
                Gated_Peaks_Start_Plot_Marker.DragEnabled = true;

                Gated_Peaks_Stop_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Peaks_Stop_Plot_Marker = Graph.Plot.AddVerticalLine(Gated_Peaks_Stop_Value, color: Color.DarkViolet, style: LineStyle.Dash, label: "Peak End");
                Gated_Peaks_Stop_Plot_Marker.PositionFormatter = x => "PE: " + Axis_Scale_Config.Value_SI_Prefix(x, 2) + "s";
                Gated_Peaks_Stop_Plot_Marker.PositionLabelBackground = Color.DarkViolet;
                Gated_Peaks_Stop_Plot_Marker.Dragged += Gated_Peaks_Marker_Stop_Dragged_Event;
                Gated_Peaks_Stop_Plot_Marker.PositionLabel = true;
                Gated_Peaks_Stop_Plot_Marker.DragEnabled = true;

                Initialize_Plottable_Peaks();

                Graph.Refresh();
                Gated_Peaks_IsEnabled = true;

                if (Gated_Peaks_Table != null & Gated_Peaks_IsEnabled)
                {
                    try
                    {
                        Gated_Peaks_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Start_Value, 2) + "s";
                        Gated_Peaks_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Stop_Value, 2) + "s";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                Disable_Gated_Peaks();
            }
        }

        private void Initialize_Plottable_Peaks()
        {
            P1 = Graph.Plot.AddText("P1", 0, 0, 12, color: Color.DarkViolet);
            P1.Alignment = Alignment.MiddleCenter;
            P1.IsVisible = false;

            P2 = Graph.Plot.AddText("P2", 0, 0, 12, color: Color.DarkViolet);
            P2.Alignment = Alignment.MiddleCenter;
            P2.IsVisible = false;

            P3 = Graph.Plot.AddText("P3", 0, 0, 12, color: Color.DarkViolet);
            P3.Alignment = Alignment.MiddleCenter;
            P3.IsVisible = false;

            P4 = Graph.Plot.AddText("P4", 0, 0, 12, color: Color.DarkViolet);
            P4.Alignment = Alignment.MiddleCenter;
            P4.IsVisible = false;

            P5 = Graph.Plot.AddText("P5", 0, 0, 12, color: Color.DarkViolet);
            P5.Alignment = Alignment.MiddleCenter;
            P5.IsVisible = false;

            P6 = Graph.Plot.AddText("P6", 0, 0, 12, color: Color.DarkViolet);
            P6.Alignment = Alignment.MiddleCenter;
            P6.IsVisible = false;

            P7 = Graph.Plot.AddText("P7", 0, 0, 12, color: Color.DarkViolet);
            P7.Alignment = Alignment.MiddleCenter;
            P7.IsVisible = false;

            P8 = Graph.Plot.AddText("P8", 0, 0, 12, color: Color.DarkViolet);
            P8.Alignment = Alignment.MiddleCenter;
            P8.IsVisible = false;

            P9 = Graph.Plot.AddText("P9", 0, 0, 12, color: Color.DarkViolet);
            P9.Alignment = Alignment.MiddleCenter;
            P9.IsVisible = false;

            P10 = Graph.Plot.AddText("P10", 0, 0, 12, color: Color.DarkViolet);
            P10.Alignment = Alignment.MiddleCenter;
            P10.IsVisible = false;
        }

        private void Remove_Plottable_Peaks()
        {
            Graph.Plot.Remove(plottable: P1);
            Graph.Plot.Remove(plottable: P2);
            Graph.Plot.Remove(plottable: P3);
            Graph.Plot.Remove(plottable: P4);
            Graph.Plot.Remove(plottable: P5);
            Graph.Plot.Remove(plottable: P6);
            Graph.Plot.Remove(plottable: P7);
            Graph.Plot.Remove(plottable: P8);
            Graph.Plot.Remove(plottable: P9);
            Graph.Plot.Remove(plottable: P10);
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
                Gated_Peaks_Table = new Gated_Peaks_Table_Window(Channel_Title + " YT Gated Peaks ", Waveform_Curve.Color, "Magnitude", "Time (s)", Measurement_Unit, "s", Gated_Peaks_Panel_FloatingHeight, Gated_Peaks_Panel_FloatingWidth, true, true);
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
                    Gated_Peaks_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Start_Value, 2) + "s";
                    Gated_Peaks_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Stop_Value, 2) + "s";
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
                    Gated_Peaks_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Start_Value, 2) + "s";
                    Gated_Peaks_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Peaks_Stop_Value, 2) + "s";
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

                    IEnumerable<Tuple<int, double>> Peaks = LocalMaxima(Gated_Y_Array, Gated_Peaks_Window_Size);
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
                            P1.X = X_Values[0]; //X Value
                            P1.Y = Y_Values[0]; //Y Value
                        }
                        if (Total_Peaks_Found >= 2)
                        {
                            P2.X = X_Values[1]; //X Value
                            P2.Y = Y_Values[1]; //Y Value
                        }
                        if (Total_Peaks_Found >= 3)
                        {
                            P3.X = X_Values[2]; //X Value
                            P3.Y = Y_Values[2]; //Y Value
                        }
                        if (Total_Peaks_Found >= 4)
                        {
                            P4.X = X_Values[3]; //X Value
                            P4.Y = Y_Values[3]; //Y Value
                        }
                        if (Total_Peaks_Found >= 5)
                        {
                            P5.X = X_Values[4]; //X Value
                            P5.Y = Y_Values[4]; //Y Value
                        }
                        if (Total_Peaks_Found >= 6)
                        {
                            P6.X = X_Values[5]; //X Value
                            P6.Y = Y_Values[5]; //Y Value
                        }
                        if (Total_Peaks_Found >= 7)
                        {
                            P7.X = X_Values[6]; //X Value
                            P7.Y = Y_Values[6]; //Y Value
                        }
                        if (Total_Peaks_Found >= 8)
                        {
                            P8.X = X_Values[7]; //X Value
                            P8.Y = Y_Values[7]; //Y Value
                        }
                        if (Total_Peaks_Found >= 9)
                        {
                            P9.X = X_Values[8]; //X Value
                            P9.Y = Y_Values[8]; //Y Value
                        }
                        if (Total_Peaks_Found >= 10)
                        {
                            P10.X = X_Values[9]; //X Value
                            P10.Y = Y_Values[9]; //Y Value
                        }

                        Visible_Peaks(Total_Peaks_Found);

                        if (Gated_Peaks_IsEnabled)
                        {
                            Gated_Peaks_Table.Peaks_Table_Process_Data(Y_Values, X_Values, Total_Peaks_Found);
                        }
                    }
                    else
                    {
                        Visible_Peaks(0);
                        if (Gated_Peaks_IsEnabled)
                        {
                            Gated_Peaks_Table.Peaks_Table_Process_Data(null, null, 0);
                        }
                    }
                }
                else
                {
                    Visible_Peaks(0);
                    if (Gated_Peaks_IsEnabled)
                    {
                        Gated_Peaks_Table.Peaks_Table_Process_Data(null, null, 0);
                    }
                }
            }
            else
            {
                Visible_Peaks(0);
                if (Gated_Peaks_IsEnabled)
                {
                    Gated_Peaks_Table.Peaks_Table_Process_Data(null, null, 0);
                }
            }
        }

        public IEnumerable<Tuple<int, double>> LocalMaxima(IEnumerable<double> source, int windowSize = 2)
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
                if (before.All(x => curVal > x) && after.All(x => curVal >= x))
                {
                    yield return Tuple.Create(index, curVal);
                }

                before.Enqueue(curVal);
                before.Dequeue();
                after.Enqueue(d);
                index++;
            }
        }

        private void Visible_Peaks(int Selected)
        {
            if (Selected >= 1)
            {
                P1.IsVisible = true;
            }
            else
            {
                P1.IsVisible = false;
            }
            if (Selected >= 2)
            {
                P2.IsVisible = true;
            }
            else
            {
                P2.IsVisible = false;
            }
            if (Selected >= 3)
            {
                P3.IsVisible = true;
            }
            else
            {
                P3.IsVisible = false;
            }
            if (Selected >= 4)
            {
                P4.IsVisible = true;
            }
            else
            {
                P4.IsVisible = false;
            }
            if (Selected >= 5)
            {
                P5.IsVisible = true;
            }
            else
            {
                P5.IsVisible = false;
            }
            if (Selected >= 6)
            {
                P6.IsVisible = true;
            }
            else
            {
                P6.IsVisible = false;
            }
            if (Selected >= 7)
            {
                P7.IsVisible = true;
            }
            else
            {
                P7.IsVisible = false;
            }
            if (Selected >= 8)
            {
                P8.IsVisible = true;
            }
            else
            {
                P8.IsVisible = false;
            }
            if (Selected >= 9)
            {
                P9.IsVisible = true;
            }
            else
            {
                P9.IsVisible = false;
            }
            if (Selected >= 10)
            {
                P10.IsVisible = true;
            }
            else
            {
                P10.IsVisible = false;
            }
        }
    }
}
