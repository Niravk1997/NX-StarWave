using MahApps.Metro.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.IO;
using System.Windows;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : MetroWindow
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
                int Local_Measurement_Data_Count = Measurement_Data_Count;
                double[] Local_Date_Time = new double[Local_Measurement_Data_Count];
                double[] Local_Measurement_Data = new double[Local_Measurement_Data_Count];
                Array.Copy(Date_Time, Local_Date_Time, Local_Measurement_Data_Count);
                Array.Copy(Measurement_Data, Local_Measurement_Data, Local_Measurement_Data_Count);

                Reference_Measurement_Waveform Reference_Waveform = new Reference_Measurement_Waveform(Local_Date_Time, Local_Measurement_Data, Local_Measurement_Data_Count, Measurement_Label, Measurement_Unit, Measurement_Color);
                string output = JsonConvert.SerializeObject(Reference_Waveform);
                Clipboard.SetText(output);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Reference_Data_File()
        {
            try
            {
                int Local_Measurement_Data_Count = Measurement_Data_Count;
                double[] Local_Date_Time = new double[Local_Measurement_Data_Count];
                double[] Local_Measurement_Data = new double[Local_Measurement_Data_Count];
                Array.Copy(Date_Time, Local_Date_Time, Local_Measurement_Data_Count);
                Array.Copy(Measurement_Data, Local_Measurement_Data, Local_Measurement_Data_Count);

                Reference_Measurement_Waveform Reference_Waveform = new Reference_Measurement_Waveform(Local_Date_Time, Local_Measurement_Data, Local_Measurement_Data_Count, Measurement_Label, Measurement_Unit, Measurement_Color);
                string output = JsonConvert.SerializeObject(Reference_Waveform);

                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Reference Measurement Plot" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
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
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Paste_Data_Clipboard(int Reference_Waveform_Slot)
        {
            try
            {
                string Reference_Data = Clipboard.GetText();
                Reference_Measurement_Waveform Reference_Waveform_Data = JsonConvert.DeserializeObject<Reference_Measurement_Waveform>(Reference_Data);
                switch (Reference_Waveform_Slot)
                {
                    case 0:
                        Graph.Plot.Remove(plottable: Reference_Waveform_0);
                        Reference_Waveform_0 = Graph.Plot.AddSignalXY(Reference_Waveform_Data.Date_Time, Reference_Waveform_Data.Measurement_Data, System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Measurement_Color), label: Reference_Waveform_Data.Measurement_Label);
                        break;
                    case 1:
                        Graph.Plot.Remove(plottable: Reference_Waveform_1);
                        Reference_Waveform_1 = Graph.Plot.AddSignalXY(Reference_Waveform_Data.Date_Time, Reference_Waveform_Data.Measurement_Data, System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Measurement_Color), label: Reference_Waveform_Data.Measurement_Label);
                        break;
                    case 2:
                        Graph.Plot.Remove(plottable: Reference_Waveform_2);
                        Reference_Waveform_2 = Graph.Plot.AddSignalXY(Reference_Waveform_Data.Date_Time, Reference_Waveform_Data.Measurement_Data, System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Measurement_Color), label: Reference_Waveform_Data.Measurement_Label);
                        break;
                    case 3:
                        Graph.Plot.Remove(plottable: Reference_Waveform_3);
                        Reference_Waveform_3 = Graph.Plot.AddSignalXY(Reference_Waveform_Data.Date_Time, Reference_Waveform_Data.Measurement_Data, System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Measurement_Color), label: Reference_Waveform_Data.Measurement_Label);
                        break;
                    case 4:
                        Graph.Plot.Remove(plottable: Reference_Waveform_4);
                        Reference_Waveform_4 = Graph.Plot.AddSignalXY(Reference_Waveform_Data.Date_Time, Reference_Waveform_Data.Measurement_Data, System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Measurement_Color), label: Reference_Waveform_Data.Measurement_Label);
                        break;
                    default:
                        break;
                }
                Graph.Plot.Legend(true);
                Graph.Refresh();
            }
            catch (Exception Ex) { Insert_Log(Ex.Message, 1); }
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
            catch (Exception Ex) { Insert_Log(Ex.Message, 1); }
        }
    }
}
