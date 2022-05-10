using Auto_Measurements;
using Axis_Scale_Config;
using NX_StarWave.Misc;
using System;
using System.Windows;
using System.Windows.Controls;
using Waveform_Calculator;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();
        private Automatic_Measurements Waveform_Measurements = new Automatic_Measurements();

        public Waveform_Panel(Expression_Data expression)
        {
            InitializeComponent();
            Process_Expression_Config(expression);
            Graph_RightClick_Menu();
            Graph_Initialize();
        }

        private void Waveform_Panel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Statistics_Enabled)
            {
                if (Measure_Frequency_Period)
                {
                    Annotation_Statistics.Y = Annotation_Statistics_Placement_Offset();
                }
                else
                {
                    Annotation_Statistics.Y = Annotation_Statistics_Placement_Offset();
                }
            }
        }

        private double Annotation_Statistics_Placement_Offset()
        {
            if (Measure_Frequency_Period)
            {
                return (Graph.ActualHeight - 220);
            }
            else
            {
                return (Graph.ActualHeight - 185);
            }
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
