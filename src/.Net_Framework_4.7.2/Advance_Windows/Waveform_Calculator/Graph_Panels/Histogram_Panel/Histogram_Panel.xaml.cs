using Axis_Scale_Config;
using NX_StarWave.Misc;
using System;
using System.Windows.Controls;
using Waveform_Calculator;

namespace Histogram_Panel
{
    public partial class Histogram_Panel : UserControl
    {
        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();
        public Histogram_Panel(Expression_Data expression)
        {
            InitializeComponent();
            Process_Expression_Config(expression);
            Graph_RightClick_Menu();
            Graph_Initialize();
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
