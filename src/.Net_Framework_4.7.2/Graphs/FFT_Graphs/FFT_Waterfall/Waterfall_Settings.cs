using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace FFT_Waterfall
{
    public partial class FFT_Waterfall_Plotter : MetroWindow
    {
        private ScottPlot.Drawing.Colormap Spectrogram_Heatmap_Process_Config()
        {
            switch (Theme_HeatMap_SelectedIndex)
            {
                case 0:
                    return ScottPlot.Drawing.Colormap.Grayscale;
                case 1:
                    return ScottPlot.Drawing.Colormap.GrayscaleR;
                case 2:
                    return ScottPlot.Drawing.Colormap.Greens;
                case 3:
                    return ScottPlot.Drawing.Colormap.Haline;
                case 4:
                    return ScottPlot.Drawing.Colormap.Ice;
                case 5:
                    return ScottPlot.Drawing.Colormap.Inferno;
                case 6:
                    return ScottPlot.Drawing.Colormap.Jet;
                case 7:
                    return ScottPlot.Drawing.Colormap.Magma;
                case 8:
                    return ScottPlot.Drawing.Colormap.Matter;
                case 9:
                    return ScottPlot.Drawing.Colormap.Oxy;
                case 10:
                    return ScottPlot.Drawing.Colormap.Phase;
                case 11:
                    return ScottPlot.Drawing.Colormap.Plasma;
                case 12:
                    return ScottPlot.Drawing.Colormap.Rain;
                case 13:
                    return ScottPlot.Drawing.Colormap.Solar;
                case 14:
                    return ScottPlot.Drawing.Colormap.Speed;
                case 15:
                    return ScottPlot.Drawing.Colormap.Tarn;
                case 16:
                    return ScottPlot.Drawing.Colormap.Tempo;
                case 17:
                    return ScottPlot.Drawing.Colormap.Thermal;
                case 18:
                    return ScottPlot.Drawing.Colormap.Topo;
                case 19:
                    return ScottPlot.Drawing.Colormap.Turbid;
                case 20:
                    return ScottPlot.Drawing.Colormap.Turbo;
                case 21:
                    return ScottPlot.Drawing.Colormap.Diff;
                case 22:
                    return ScottPlot.Drawing.Colormap.Dense;
                case 23:
                    return ScottPlot.Drawing.Colormap.Delta;
                case 24:
                    return ScottPlot.Drawing.Colormap.Deep;
                case 25:
                    return ScottPlot.Drawing.Colormap.Curl;
                case 26:
                    return ScottPlot.Drawing.Colormap.Blues;
                case 27:
                    return ScottPlot.Drawing.Colormap.Balance;
                case 28:
                    return ScottPlot.Drawing.Colormap.Amp;
                case 29:
                    return ScottPlot.Drawing.Colormap.Algae;
                case 30:
                    return ScottPlot.Drawing.Colormap.Viridis;
                default:
                    return ScottPlot.Drawing.Colormap.Viridis;
            }
        }

        private void Spectrogram_Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Waterfall_Colorbar.UpdateColormap(Spectrogram_Heatmap_Process_Config());
        }
    }
}
