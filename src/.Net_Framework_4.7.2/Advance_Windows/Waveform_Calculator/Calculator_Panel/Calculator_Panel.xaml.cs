using AvalonDock;
using MahApps.Metro.Controls;
using System;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        public Calculator_Panel()
        {
            InitializeComponent();
            DataContext = this;
            Initialize_Timers();
            AutoLoad_Load_File();
        }

        private DockingManager Docking_Manager = new DockingManager
        {
            Theme = new AvalonDock.Themes.Vs2013DarkTheme(),
            AnchorableContextMenu = null
        };

        private void Waveform_Calculator_Closing(object sender, EventArgs e)
        {
            Close_All_Waveform_Panels();
            Close_All_Histogram_Panels();
            Close_All_FFT_Panels();
            try
            {
                Math_Expression_Process.Stop();
                Waveform_Data_Process.Stop();
                Waveform_Data_Process.Dispose();
                Waveform_Data_Process = null;
                Math_Expression_Process = null;
            }
            catch (Exception) { }
        }
    }
}
