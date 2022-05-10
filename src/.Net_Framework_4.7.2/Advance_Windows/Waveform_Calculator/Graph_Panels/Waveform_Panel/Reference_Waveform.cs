using Microsoft.Win32;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_0;
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_1;
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_2;
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_3;
        private ScottPlot.Plottable.SignalPlotXY Reference_Waveform_4;

        private void Copy_Reference_Data_Clipboard()
        {
            try
            {
                string Label = "Unknown";
                if (!string.IsNullOrEmpty(Waveform_Title))
                {
                    Label = Waveform_Title;
                }
                Reference_Waveform Reference_Waveform = new Reference_Waveform(Y_Data, Data_Points, Total_Time, Start_Time, Stop_Time, Label, Waveform_Color);
                string output = JsonConvert.SerializeObject(Reference_Waveform);
                Clipboard.SetText(output);
            }
            catch (Exception)
            {

            }
        }

        private void Save_Reference_Data_File()
        {
            try
            {
                string Label = "Unknown";
                if (!string.IsNullOrEmpty(Waveform_Title))
                {
                    Label = Waveform_Title;
                }
                Reference_Waveform Reference_Waveform = new Reference_Waveform(Y_Data, Data_Points, Total_Time, Start_Time, Stop_Time, Label, Waveform_Color);
                string output = JsonConvert.SerializeObject(Reference_Waveform);

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
