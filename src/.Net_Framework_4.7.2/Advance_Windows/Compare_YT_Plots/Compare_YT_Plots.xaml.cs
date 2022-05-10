using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;

namespace Compare_YT
{
    public partial class Compare_YT_Plots : MetroWindow
    {
        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public Compare_YT_Plots()
        {
            InitializeComponent();
            DataContext = this;
            Graph_RightClick_Menu();
            Config_Graph();
        }

        private void Config_Graph()
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Graph.Plot.XAxis.Label("Time (s)");
            Graph.Plot.YAxis.Label("Voltage (V)");
            Graph.Plot.Legend(true);
            Graph.Refresh();
        }

        private void Waveform_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            Graph.Refresh();
        }

        private void Waveform_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            Graph.Refresh();
        }
    }
}
