using MahApps.Metro.Controls;
using ScottPlot;
using Statistics_Table;
using System;
using System.Drawing;
using System.Windows;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
    {
        private ScottPlot.Plottable.VLine Gated_Measurements_Start_Plot_Marker;
        private ScottPlot.Plottable.VLine Gated_Measurements_Stop_Plot_Marker;

        private bool Gated_Measurements_IsEnabled = false;

        private double Gated_Measurements_Start_Value = 0;
        private double Gated_Measurements_Stop_Value = 0;

        private double Gated_Measurements_Panel_FloatingWidth = 705;
        private double Gated_Measurements_Panel_FloatingHeight = 165;

        private Statistics_Table_Window Gated_Measurements_Table;

        private void Enable_Disable_Gated_Measurements_Click(object sender, RoutedEventArgs e)
        {
            if (Gated_Measurements_EnableDisable_MenuItem.IsChecked)
            {
                Open_Gated_Measurements_Table_Panel();

                AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);

                Gated_Measurements_Start_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Measurements_Start_Plot_Marker = Graph.Plot.AddVerticalLine(Gated_Measurements_Start_Value, color: Color.DarkTurquoise, style: LineStyle.Dash, label: "Gated Start");
                Gated_Measurements_Start_Plot_Marker.PositionFormatter = x => "GS: " + Axis_Scale_Config.Value_SI_Prefix(x, 2) + "s";
                Gated_Measurements_Start_Plot_Marker.PositionLabelBackground = Color.DarkTurquoise;
                Gated_Measurements_Start_Plot_Marker.Dragged += Gated_Measurements_Marker_Start_Dragged_Event;
                Gated_Measurements_Start_Plot_Marker.PositionLabel = true;
                Gated_Measurements_Start_Plot_Marker.DragEnabled = true;

                Gated_Measurements_Stop_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Measurements_Stop_Plot_Marker = Graph.Plot.AddVerticalLine(Gated_Measurements_Stop_Value, color: Color.DarkTurquoise, style: LineStyle.Dash, label: "Gated End");
                Gated_Measurements_Stop_Plot_Marker.PositionFormatter = x => "GE: " + Axis_Scale_Config.Value_SI_Prefix(x, 2) + "s";
                Gated_Measurements_Stop_Plot_Marker.PositionLabelBackground = Color.DarkTurquoise;
                Gated_Measurements_Stop_Plot_Marker.Dragged += Gated_Measurements_Marker_Stop_Dragged_Event;
                Gated_Measurements_Stop_Plot_Marker.PositionLabel = true;
                Gated_Measurements_Stop_Plot_Marker.DragEnabled = true;

                Gated_Measurements_IsEnabled = true;
                Graph.Refresh();

                if (Gated_Measurements_Table != null & Gated_Measurements_IsEnabled)
                {
                    try
                    {
                        Gated_Measurements_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Measurements_Start_Value, 2) + "s";
                        Gated_Measurements_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Measurements_Stop_Value, 2) + "s";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                Disable_Gated_Measurements();
            }
        }

        private void Disable_Gated_Measurements()
        {
            Gated_Measurements_IsEnabled = false;
            Close_Gated_Measurements_Table();
            Graph.Plot.Remove(plottable: Gated_Measurements_Start_Plot_Marker);
            Graph.Plot.Remove(plottable: Gated_Measurements_Stop_Plot_Marker);
            Graph.Refresh();
        }

        private void Open_Gated_Measurements_Table_Panel()
        {
            if (Gated_Measurements_Table == null & Gated_Measurements_IsEnabled == false)
            {
                Gated_Measurements_Table = new Statistics_Table_Window(Channel_Title + " Gated Measurements ", Channel_Title, Measurement_Unit, Waveform_Curve.Color, Gated_Measurements_Panel_FloatingHeight, Gated_Measurements_Panel_FloatingWidth, true, true);
                Gated_Measurements_Table.Show();
                Gated_Measurements_Table.Closed += Close_Gated_Measurements_Table_Panel_Event;
                Insert_Log("Gated Measurements Table Opened", 5);
            }
        }

        private void Close_Gated_Measurements_Table_Panel_Event(object sender, EventArgs e)
        {
            try
            {
                Gated_Measurements_IsEnabled = false;
                Gated_Measurements_EnableDisable_MenuItem.IsChecked = false;
                Gated_Measurements_Table = null;
                Graph.Plot.Remove(plottable: Gated_Measurements_Start_Plot_Marker);
                Graph.Plot.Remove(plottable: Gated_Measurements_Stop_Plot_Marker);
                Graph.Refresh();
                Insert_Log("Gated Measurements Table Closed.", 5);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Gated_Measurements_Table()
        {
            try
            {
                if (Gated_Measurements_Table != null)
                {
                    Gated_Measurements_Table.Close();
                    Gated_Measurements_Table = null;
                    Insert_Log("Gated Measurements Table Closed.", 5);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }

        }

        private void Gated_Measurements_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);
            double Gated_Start_Value = Gated_Measurements_Start_Plot_Marker.X;
            double Gated_Stop_Value = Gated_Measurements_Stop_Plot_Marker.X;
            if (Gated_Start_Value >= Gated_Stop_Value)
            {
                double New_Gated_Start_Plot_Marker_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Measurements_Start_Plot_Marker.X = New_Gated_Start_Plot_Marker_Value;
                this.Gated_Measurements_Start_Value = New_Gated_Start_Plot_Marker_Value;

                double New_Gated_Stop_Plot_Marker_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Measurements_Stop_Plot_Marker.X = New_Gated_Stop_Plot_Marker_Value;
                this.Gated_Measurements_Stop_Value = New_Gated_Stop_Plot_Marker_Value;
            }
            else
            {
                this.Gated_Measurements_Start_Value = Gated_Start_Value;
            }

            if (Gated_Measurements_Table != null & Gated_Measurements_IsEnabled)
            {
                try
                {
                    Gated_Measurements_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Measurements_Start_Value, 2) + "s";
                    Gated_Measurements_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Measurements_Stop_Value, 2) + "s";
                }
                catch (Exception) { }
            }
        }

        private void Gated_Measurements_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);
            double Gated_Start_Value = Gated_Measurements_Start_Plot_Marker.X;
            double Gated_Stop_Value = Gated_Measurements_Stop_Plot_Marker.X;
            if (Gated_Start_Value >= Gated_Stop_Value)
            {
                double New_Gated_Start_Plot_Marker_Value = (Graph_Axis_Limits.XMin + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Measurements_Start_Plot_Marker.X = New_Gated_Start_Plot_Marker_Value;
                this.Gated_Measurements_Start_Value = New_Gated_Start_Plot_Marker_Value;

                double New_Gated_Stop_Plot_Marker_Value = (Graph_Axis_Limits.XMax + Graph_Axis_Limits.XCenter) / 2.0;
                Gated_Measurements_Stop_Plot_Marker.X = New_Gated_Stop_Plot_Marker_Value;
                this.Gated_Measurements_Stop_Value = New_Gated_Stop_Plot_Marker_Value;
            }
            else
            {
                this.Gated_Measurements_Stop_Value = Gated_Stop_Value;
            }

            if (Gated_Measurements_Table != null & Gated_Measurements_IsEnabled)
            {
                try
                {
                    Gated_Measurements_Table.Measurement_Start = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Measurements_Start_Value, 2) + "s";
                    Gated_Measurements_Table.Measurement_Stop = Axis_Scale_Config.Value_SI_Prefix(this.Gated_Measurements_Stop_Value, 2) + "s";
                }
                catch (Exception) { }
            }
        }

        //Search Waveform Arrays for Gated Start and Stop Values and get their Array Index, Create Gated Array from Waveform Array
        private void Create_Gated_Measurements_Array(double[] X_Waveform_Values, double[] Y_Waveform_Values, int Data_Points)
        {
            double Gated_Start_Value = this.Gated_Measurements_Start_Value;
            double Gated_Stop_Value = this.Gated_Measurements_Stop_Value;

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

                    if (Gated_Measurements_IsEnabled)
                    {
                        Gated_Measurements_Table.Statistics_Table_Process_Data(Gated_X_Array, Gated_Y_Array, Gated_Arrays_DataPoints_Count);
                    }
                }
            }
        }
    }
}
