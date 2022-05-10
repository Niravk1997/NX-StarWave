using Axis_Scale_Config;
using NX_StarWave.Misc;
using System;
using System.Windows.Controls;
using Waveform_Calculator;

namespace FFT_Panel
{
    public partial class FFT_Panel : UserControl
    {
        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();
        public FFT_Panel(Expression_Data expression)
        {
            InitializeComponent();
            Process_Expression_Config(expression);
            FFT_Plot_Initialize();
            if (Show_Peaks)
            {
                Peaks_Initialize();
            }
            Graph_RightClick_Menu();
        }

        public void Close_Panel()
        {
            try
            {
                Graph.Plot.Clear();
            }
            catch (Exception)
            {

            }
        }

    }
}
