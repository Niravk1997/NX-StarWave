using MahApps.Metro.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.IO;
using System.Windows;

namespace YT_All_Seperate_Axis
{
    public partial class YT_All_Seperate_Axis_Plotter : MetroWindow
    {
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_0;
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_1;
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_2;
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_3;
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_4;

        private void Copy_Reference_Data_Clipboard(int Select_Channel)
        {
            try
            {
                Clipboard.SetText(Get_Waveform_data_JSON(Select_Channel));
            }
            catch (Exception)
            {

            }
        }

        private void Save_Reference_Data_File(int Select_Channel)
        {
            try
            {
                string output = Get_Waveform_data_JSON(Select_Channel);

                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Reference Waveform" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        datatotxt.WriteLine(output);
                    }
                }
            }
            catch (Exception) { }
        }

        private string Get_Waveform_data_JSON(int Select_Channel)
        {
            try
            {
                Reference_Waveform Reference_Waveform;
                string Label = "Unknown";
                string output = "";
                switch (Select_Channel)
                {
                    case 0:
                        if (!string.IsNullOrEmpty(CH1_Channel_Info))
                        {
                            Label = CH1_Channel_Info;
                        }
                        Reference_Waveform = new Reference_Waveform(CH1_Y_Values, CH1_Data_Points, CH1_Total_Time, CH1_Start_Time, CH1_Stop_Time, Label, System.Drawing.ColorTranslator.ToHtml(Channel_1_Curve.Color));
                        output = JsonConvert.SerializeObject(Reference_Waveform);
                        break;
                    case 1:
                        if (!string.IsNullOrEmpty(CH2_Channel_Info))
                        {
                            Label = CH2_Channel_Info;
                        }
                        Reference_Waveform = new Reference_Waveform(CH2_Y_Values, CH2_Data_Points, CH2_Total_Time, CH2_Start_Time, CH2_Stop_Time, Label, System.Drawing.ColorTranslator.ToHtml(Channel_2_Curve.Color));
                        output = JsonConvert.SerializeObject(Reference_Waveform);
                        break;
                    case 2:
                        if (!string.IsNullOrEmpty(CH3_Channel_Info))
                        {
                            Label = CH3_Channel_Info;
                        }
                        Reference_Waveform = new Reference_Waveform(CH3_Y_Values, CH3_Data_Points, CH3_Total_Time, CH3_Start_Time, CH3_Stop_Time, Label, System.Drawing.ColorTranslator.ToHtml(Channel_3_Curve.Color));
                        output = JsonConvert.SerializeObject(Reference_Waveform);
                        break;
                    case 3:
                        if (!string.IsNullOrEmpty(CH4_Channel_Info))
                        {
                            Label = CH4_Channel_Info;
                        }
                        Reference_Waveform = new Reference_Waveform(CH4_Y_Values, CH4_Data_Points, CH4_Total_Time, CH4_Start_Time, CH4_Stop_Time, Label, System.Drawing.ColorTranslator.ToHtml(Channel_4_Curve.Color));
                        output = JsonConvert.SerializeObject(Reference_Waveform);
                        break;
                    default:
                        break;
                }
                return output;
            }
            catch (Exception) { return ""; }
        }

        private void Paste_Data_Clipboard(int Reference_Waveform_Slot)
        {
            try
            {
                string Reference_Data = Clipboard.GetText();
                Reference_Waveform Reference_Waveform_Data = JsonConvert.DeserializeObject<Reference_Waveform>(Reference_Data);
                switch (Reference_Waveform_Slot)
                {
                    case 0:
                        Graph.Plot.Remove(plottable: Reference_Waveform_0);
                        Reference_Waveform_0 = Graph.Plot.AddSignalXY(Functions.Linspace(Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points), Reference_Waveform_Data.Waveform_Y_Data, color: System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Waveform_Color), label: Reference_Waveform_Data.Channel_Info);
                        break;
                    case 1:
                        Graph.Plot.Remove(plottable: Reference_Waveform_1);
                        Reference_Waveform_1 = Graph.Plot.AddSignalXY(Functions.Linspace(Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points), Reference_Waveform_Data.Waveform_Y_Data, color: System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Waveform_Color), label: Reference_Waveform_Data.Channel_Info);
                        break;
                    case 2:
                        Graph.Plot.Remove(plottable: Reference_Waveform_2);
                        Reference_Waveform_2 = Graph.Plot.AddSignalXY(Functions.Linspace(Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points), Reference_Waveform_Data.Waveform_Y_Data, color: System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Waveform_Color), label: Reference_Waveform_Data.Channel_Info);
                        break;
                    case 3:
                        Graph.Plot.Remove(plottable: Reference_Waveform_3);
                        Reference_Waveform_3 = Graph.Plot.AddSignalXY(Functions.Linspace(Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points), Reference_Waveform_Data.Waveform_Y_Data, color: System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Waveform_Color), label: Reference_Waveform_Data.Channel_Info);
                        break;
                    case 4:
                        Graph.Plot.Remove(plottable: Reference_Waveform_4);
                        Reference_Waveform_4 = Graph.Plot.AddSignalXY(Functions.Linspace(Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points), Reference_Waveform_Data.Waveform_Y_Data, color: System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Waveform_Color), label: Reference_Waveform_Data.Channel_Info);
                        break;
                    default:
                        break;
                }
                Graph.Plot.Legend(true);
                Graph.Refresh();
            }
            catch (Exception) { }
        }

        private void Clear_Reference_Waveform(int Reference_Waveform_Slot)
        {
            try
            {
                switch (Reference_Waveform_Slot)
                {
                    case 0:
                        Graph.Plot.Remove(plottable: Reference_Waveform_0);
                        break;
                    case 1:
                        Graph.Plot.Remove(plottable: Reference_Waveform_1);
                        break;
                    case 2:
                        Graph.Plot.Remove(plottable: Reference_Waveform_2);
                        break;
                    case 3:
                        Graph.Plot.Remove(plottable: Reference_Waveform_3);
                        break;
                    case 4:
                        Graph.Plot.Remove(plottable: Reference_Waveform_4);
                        break;
                    default:
                        Graph.Plot.Remove(plottable: Reference_Waveform_0);
                        Graph.Plot.Remove(plottable: Reference_Waveform_1);
                        Graph.Plot.Remove(plottable: Reference_Waveform_2);
                        Graph.Plot.Remove(plottable: Reference_Waveform_3);
                        Graph.Plot.Remove(plottable: Reference_Waveform_4);
                        break;
                }
                Graph.Refresh();
            }
            catch (Exception) { }
        }
    }
}
