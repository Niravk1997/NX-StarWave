using Gated_Peaks_Table;
using MahApps.Metro.Controls;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;

namespace FFT_Waterfall
{
    public partial class FFT_Waterfall_Plotter : MetroWindow
    {
        private ScottPlot.Plottable.VLine Gated_HighestPoints_Start_Plot_Marker;
        private ScottPlot.Plottable.VLine Gated_HighestPoints_Stop_Plot_Marker;

        private bool Gated_HighestPoints_IsEnabled = false;

        private double Gated_HighestPoints_Start_Value = 0;
        private double Gated_HighestPoints_Stop_Value = 0;

        private double Gated_HighestPoints_Panel_FloatingWidth = 208;
        private double Gated_HighestPoints_Panel_FloatingHeight = 208;

        private Gated_Peaks_Table_Window Gated_HighestPoints_Table;

        private ScottPlot.Plottable.Text H1;
        private ScottPlot.Plottable.Text H2;
        private ScottPlot.Plottable.Text H3;
        private ScottPlot.Plottable.Text H4;
        private ScottPlot.Plottable.Text H5;
        private ScottPlot.Plottable.Text H6;
        private ScottPlot.Plottable.Text H7;
        private ScottPlot.Plottable.Text H8;
        private ScottPlot.Plottable.Text H9;
        private ScottPlot.Plottable.Text H10;

        private void Enable_Disable_Gated_HighestPoints_Click(object sender, RoutedEventArgs e)
        {
            if (Gated_HighestPoints_EnableDisable_MenuItem.IsChecked)
            {
                Open_Gated_HighestPoints_Table_Window();
                AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);

                Gated_HighestPoints_Start_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_HighestPoints_Start_Plot_Marker = Graph.Plot.AddVerticalLine(Gated_HighestPoints_Start_Value, color: Color.Magenta, style: LineStyle.Dash, label: "High Start");
                Gated_HighestPoints_Start_Plot_Marker.PositionFormatter = x => "HS: " + Axis_Scale_Config.Value_SI_Prefix(x, 2) + "Hz";
                Gated_HighestPoints_Start_Plot_Marker.PositionLabelBackground = Color.Magenta;
                Gated_HighestPoints_Start_Plot_Marker.Dragged += Gated_HighestPoints_Marker_Start_Dragged_Event;
                Gated_HighestPoints_Start_Plot_Marker.PositionLabel = true;
                Gated_HighestPoints_Start_Plot_Marker.DragEnabled = true;

                Gated_HighestPoints_Stop_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_HighestPoints_Stop_Plot_Marker = Graph.Plot.AddVerticalLine(Gated_HighestPoints_Stop_Value, color: Color.Magenta, style: LineStyle.Dash, label: "High End");
                Gated_HighestPoints_Stop_Plot_Marker.PositionFormatter = x => "HE: " + Axis_Scale_Config.Value_SI_Prefix(x, 2) + "Hz";
                Gated_HighestPoints_Stop_Plot_Marker.PositionLabelBackground = Color.Magenta;
                Gated_HighestPoints_Stop_Plot_Marker.Dragged += Gated_HighestPoints_Marker_Stop_Dragged_Event;
                Gated_HighestPoints_Stop_Plot_Marker.PositionLabel = true;
                Gated_HighestPoints_Stop_Plot_Marker.DragEnabled = true;

                Initialize_Plottable_HighestPoints();

                Gated_HighestPoints_IsEnabled = true;
                Graph.Refresh();

                if (Gated_HighestPoints_Table != null & Gated_HighestPoints_IsEnabled)
                {
                    try
                    {
                        Gated_HighestPoints_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_HighestPoints_Start_Value, 2) + "Hz";
                        Gated_HighestPoints_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_HighestPoints_Stop_Value, 2) + "Hz";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                Disable_Gated_HighestPoints();
            }
        }

        private void Initialize_Plottable_HighestPoints()
        {
            H1 = Graph.Plot.AddText("H1", 0, 0, 12, color: Color.Magenta);
            H1.YAxisIndex = 1;
            H1.Alignment = Alignment.MiddleCenter;
            H1.IsVisible = false;

            H2 = Graph.Plot.AddText("H2", 0, 0, 12, color: Color.Magenta);
            H2.YAxisIndex = 1;
            H2.Alignment = Alignment.MiddleCenter;
            H2.IsVisible = false;

            H3 = Graph.Plot.AddText("H3", 0, 0, 12, color: Color.Magenta);
            H3.YAxisIndex = 1;
            H3.Alignment = Alignment.MiddleCenter;
            H3.IsVisible = false;

            H4 = Graph.Plot.AddText("H4", 0, 0, 12, color: Color.Magenta);
            H4.YAxisIndex = 1;
            H4.Alignment = Alignment.MiddleCenter;
            H4.IsVisible = false;

            H5 = Graph.Plot.AddText("H5", 0, 0, 12, color: Color.Magenta);
            H5.YAxisIndex = 1;
            H5.Alignment = Alignment.MiddleCenter;
            H5.IsVisible = false;

            H6 = Graph.Plot.AddText("H6", 0, 0, 12, color: Color.Magenta);
            H6.YAxisIndex = 1;
            H6.Alignment = Alignment.MiddleCenter;
            H6.IsVisible = false;

            H7 = Graph.Plot.AddText("H7", 0, 0, 12, color: Color.Magenta);
            H7.YAxisIndex = 1;
            H7.Alignment = Alignment.MiddleCenter;
            H7.IsVisible = false;

            H8 = Graph.Plot.AddText("H8", 0, 0, 12, color: Color.Magenta);
            H8.YAxisIndex = 1;
            H8.Alignment = Alignment.MiddleCenter;
            H8.IsVisible = false;

            H9 = Graph.Plot.AddText("H9", 0, 0, 12, color: Color.Magenta);
            H9.YAxisIndex = 1;
            H9.Alignment = Alignment.MiddleCenter;
            H9.IsVisible = false;

            H10 = Graph.Plot.AddText("H10", 0, 0, 12, color: Color.Magenta);
            H10.YAxisIndex = 1;
            H10.Alignment = Alignment.MiddleCenter;
            H10.IsVisible = false;
        }

        private void Remove_Plottable_HighestPoints()
        {
            Graph.Plot.Remove(plottable: H1);
            Graph.Plot.Remove(plottable: H2);
            Graph.Plot.Remove(plottable: H3);
            Graph.Plot.Remove(plottable: H4);
            Graph.Plot.Remove(plottable: H5);
            Graph.Plot.Remove(plottable: H6);
            Graph.Plot.Remove(plottable: H7);
            Graph.Plot.Remove(plottable: H8);
            Graph.Plot.Remove(plottable: H9);
            Graph.Plot.Remove(plottable: H10);
        }

        private void Disable_Gated_HighestPoints()
        {
            Gated_HighestPoints_IsEnabled = false;
            Close_Gated_HighestPoints_Table_Panel();
            Graph.Plot.Remove(plottable: Gated_HighestPoints_Start_Plot_Marker);
            Graph.Plot.Remove(plottable: Gated_HighestPoints_Stop_Plot_Marker);
            Remove_Plottable_HighestPoints();
            Graph.Refresh();
        }

        private void Open_Gated_HighestPoints_Table_Window()
        {
            if (Gated_HighestPoints_Table == null)
            {
                Gated_HighestPoints_Table = new Gated_Peaks_Table_Window(Channel_Title + " FFT Gated Highest Points ", FFT_Waveform.Color, "Magnitude", "Frequency (Hz)", Y_AXIS_Units, "Hz", Gated_HighestPoints_Panel_FloatingHeight, Gated_HighestPoints_Panel_FloatingWidth, true, true);
                Gated_HighestPoints_Table.Show();
                Gated_HighestPoints_Table.Closed += Close_Gated_HighestPoints_Table_Panel_Event;
                Insert_Log("Gated Highest Points Table Opened", 5);
            }
        }

        private void Close_Gated_HighestPoints_Table_Panel_Event(object sender, EventArgs e)
        {
            try
            {
                Gated_HighestPoints_IsEnabled = false;
                Gated_HighestPoints_EnableDisable_MenuItem.IsChecked = false;

                Gated_HighestPoints_Table = null;
                Graph.Plot.Remove(plottable: Gated_HighestPoints_Start_Plot_Marker);
                Graph.Plot.Remove(plottable: Gated_HighestPoints_Stop_Plot_Marker);
                Remove_Plottable_HighestPoints();
                Graph.Refresh();
                Insert_Log("Gated Highest Points Table Closed.", 5);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Gated_HighestPoints_Table_Panel()
        {
            try
            {
                if (Gated_HighestPoints_Table != null)
                {
                    Gated_HighestPoints_Table.Close();
                    Gated_HighestPoints_Table = null;
                    Insert_Log("Gated Highest Points Table Closed.", 5);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }

        }

        private void Gated_HighestPoints_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);
            double Gated_Start_Value = Gated_HighestPoints_Start_Plot_Marker.X;
            double Gated_Stop_Value = Gated_HighestPoints_Stop_Plot_Marker.X;
            if (Gated_Start_Value >= Gated_Stop_Value)
            {
                double New_Gated_Start_Plot_Marker_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_HighestPoints_Start_Plot_Marker.X = New_Gated_Start_Plot_Marker_Value;
                this.Gated_HighestPoints_Start_Value = New_Gated_Start_Plot_Marker_Value;

                double New_Gated_Stop_Plot_Marker_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_HighestPoints_Stop_Plot_Marker.X = New_Gated_Stop_Plot_Marker_Value;
                this.Gated_HighestPoints_Stop_Value = New_Gated_Stop_Plot_Marker_Value;
            }
            else
            {
                this.Gated_HighestPoints_Start_Value = Gated_Start_Value;
            }

            if (Gated_HighestPoints_Table != null & Gated_HighestPoints_IsEnabled)
            {
                try
                {
                    Gated_HighestPoints_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_HighestPoints_Start_Value, 2) + "Hz";
                    Gated_HighestPoints_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_HighestPoints_Stop_Value, 2) + "Hz";
                }
                catch (Exception) { }
            }
        }

        private void Gated_HighestPoints_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);
            double Gated_Start_Value = Gated_HighestPoints_Start_Plot_Marker.X;
            double Gated_Stop_Value = Gated_HighestPoints_Stop_Plot_Marker.X;
            if (Gated_Start_Value >= Gated_Stop_Value)
            {
                double New_Gated_Start_Plot_Marker_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_HighestPoints_Start_Plot_Marker.X = New_Gated_Start_Plot_Marker_Value;
                this.Gated_HighestPoints_Start_Value = New_Gated_Start_Plot_Marker_Value;

                double New_Gated_Stop_Plot_Marker_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_HighestPoints_Stop_Plot_Marker.X = New_Gated_Stop_Plot_Marker_Value;
                this.Gated_HighestPoints_Stop_Value = New_Gated_Stop_Plot_Marker_Value;
            }
            else
            {
                this.Gated_HighestPoints_Stop_Value = Gated_Stop_Value;
            }

            if (Gated_HighestPoints_Table != null & Gated_HighestPoints_IsEnabled)
            {
                try
                {
                    Gated_HighestPoints_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_HighestPoints_Start_Value, 2) + "Hz";
                    Gated_HighestPoints_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_HighestPoints_Stop_Value, 2) + "Hz";
                }
                catch (Exception) { }
            }
        }

        //Search Waveform Arrays for Gated Start and Stop Values and get their Array Index, Create Gated Array from Waveform Array
        private void Create_Gated_HighestPoints_Array(double[] X_Waveform_Values, double[] Y_Waveform_Values, int Data_Points)
        {
            double Gated_Start_Value = this.Gated_HighestPoints_Start_Value;
            double Gated_Stop_Value = this.Gated_HighestPoints_Stop_Value;

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

                    int Total_HighestPoints_Found = Gated_Arrays_DataPoints_Count;

                    double[] X_HighestPoints_Value;
                    double[] Y_HighestPoints_Value;

                    IOrderedEnumerable<Tuple<double, double>> Highest_Points = HighestPoints_Finder(Gated_Y_Array, Gated_X_Array, Gated_Arrays_DataPoints_Count);

                    if (Gated_Arrays_DataPoints_Count <= 10)
                    {
                        X_HighestPoints_Value = new double[Gated_Arrays_DataPoints_Count];
                        Y_HighestPoints_Value = new double[Gated_Arrays_DataPoints_Count];
                        int i = 0;
                        foreach (Tuple<double, double> Value in Highest_Points)
                        {
                            X_HighestPoints_Value[i] = Value.Item1;
                            Y_HighestPoints_Value[i] = Value.Item2;
                            i++;
                            if (i >= Gated_Arrays_DataPoints_Count)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        X_HighestPoints_Value = new double[10];
                        Y_HighestPoints_Value = new double[10];
                        int i = 0;
                        foreach (Tuple<double, double> Value in Highest_Points)
                        {
                            X_HighestPoints_Value[i] = Value.Item1;
                            Y_HighestPoints_Value[i] = Value.Item2;
                            i++;
                            if (i >= 10)
                            {
                                break;
                            }
                        }
                    }
                    if (Total_HighestPoints_Found > 0)
                    {
                        if (Total_HighestPoints_Found >= 1)
                        {
                            H1.X = X_HighestPoints_Value[0]; //X Value
                            H1.Y = Y_HighestPoints_Value[0]; //Y Value
                        }
                        if (Total_HighestPoints_Found >= 2)
                        {
                            H2.X = X_HighestPoints_Value[1]; //X Value
                            H2.Y = Y_HighestPoints_Value[1]; //Y Value
                        }
                        if (Total_HighestPoints_Found >= 3)
                        {
                            H3.X = X_HighestPoints_Value[2]; //X Value
                            H3.Y = Y_HighestPoints_Value[2]; //Y Value
                        }
                        if (Total_HighestPoints_Found >= 4)
                        {
                            H4.X = X_HighestPoints_Value[3]; //X Value
                            H4.Y = Y_HighestPoints_Value[3]; //Y Value
                        }
                        if (Total_HighestPoints_Found >= 5)
                        {
                            H5.X = X_HighestPoints_Value[4]; //X Value
                            H5.Y = Y_HighestPoints_Value[4]; //Y Value
                        }
                        if (Total_HighestPoints_Found >= 6)
                        {
                            H6.X = X_HighestPoints_Value[5]; //X Value
                            H6.Y = Y_HighestPoints_Value[5]; //Y Value
                        }
                        if (Total_HighestPoints_Found >= 7)
                        {
                            H7.X = X_HighestPoints_Value[6]; //X Value
                            H7.Y = Y_HighestPoints_Value[6]; //Y Value
                        }
                        if (Total_HighestPoints_Found >= 8)
                        {
                            H8.X = X_HighestPoints_Value[7]; //X Value
                            H8.Y = Y_HighestPoints_Value[7]; //Y Value
                        }
                        if (Total_HighestPoints_Found >= 9)
                        {
                            H9.X = X_HighestPoints_Value[8]; //X Value
                            H9.Y = Y_HighestPoints_Value[8]; //Y Value
                        }
                        if (Total_HighestPoints_Found >= 10)
                        {
                            H10.X = X_HighestPoints_Value[9]; //X Value
                            H10.Y = Y_HighestPoints_Value[9]; //Y Value
                        }

                        Visible_HighestPoints(Total_HighestPoints_Found);

                        if (Gated_HighestPoints_IsEnabled)
                        {
                            Gated_HighestPoints_Table.Peaks_Table_Process_Data(Y_HighestPoints_Value, X_HighestPoints_Value, Total_HighestPoints_Found);
                        }
                    }
                    else
                    {
                        Visible_HighestPoints(0);
                        if (Gated_HighestPoints_IsEnabled)
                        {
                            Gated_HighestPoints_Table.Peaks_Table_Process_Data(null, null, 0);
                        }
                    }
                }
                else
                {
                    Visible_HighestPoints(0);
                    if (Gated_HighestPoints_IsEnabled)
                    {
                        Gated_HighestPoints_Table.Peaks_Table_Process_Data(null, null, 0);
                    }
                }
            }
            else
            {
                Visible_HighestPoints(0);
                if (Gated_HighestPoints_IsEnabled)
                {
                    Gated_HighestPoints_Table.Peaks_Table_Process_Data(null, null, 0);
                }
            }
        }

        private IOrderedEnumerable<Tuple<double, double>> HighestPoints_Finder(double[] Gated_Y_Array, double[] Gated_X_Array, int Gated_Arrays_DataPoints_Count)
        {
            List<Tuple<double, double>> Unsorted_Y_Array = new List<Tuple<double, double>>(Gated_Arrays_DataPoints_Count);
            for (int i = 0; i < Gated_Arrays_DataPoints_Count; i++)
            {
                Unsorted_Y_Array.Add(new Tuple<double, double>(Gated_X_Array[i], Gated_Y_Array[i]));
            }
            IOrderedEnumerable<Tuple<double, double>> Sorted_XY_Array = Unsorted_Y_Array.OrderByDescending(x => x.Item2);

            return Sorted_XY_Array;
        }

        private void Visible_HighestPoints(int Selected)
        {
            if (Selected >= 1)
            {
                H1.IsVisible = true;
            }
            else
            {
                H1.IsVisible = false;
            }
            if (Selected >= 2)
            {
                H2.IsVisible = true;
            }
            else
            {
                H2.IsVisible = false;
            }
            if (Selected >= 3)
            {
                H3.IsVisible = true;
            }
            else
            {
                H3.IsVisible = false;
            }
            if (Selected >= 4)
            {
                H4.IsVisible = true;
            }
            else
            {
                H4.IsVisible = false;
            }
            if (Selected >= 5)
            {
                H5.IsVisible = true;
            }
            else
            {
                H5.IsVisible = false;
            }
            if (Selected >= 6)
            {
                H6.IsVisible = true;
            }
            else
            {
                H6.IsVisible = false;
            }
            if (Selected >= 7)
            {
                H7.IsVisible = true;
            }
            else
            {
                H7.IsVisible = false;
            }
            if (Selected >= 8)
            {
                H8.IsVisible = true;
            }
            else
            {
                H8.IsVisible = false;
            }
            if (Selected >= 9)
            {
                H9.IsVisible = true;
            }
            else
            {
                H9.IsVisible = false;
            }
            if (Selected >= 10)
            {
                H10.IsVisible = true;
            }
            else
            {
                H10.IsVisible = false;
            }
        }

        private void Set_Gated_Highest_Points_Units(string Units)
        {
            try
            {
                if (Gated_HighestPoints_IsEnabled || Gated_HighestPoints_Table != null)
                {
                    Gated_HighestPoints_Table.Y_Values_Units = Units;
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }
    }
}
