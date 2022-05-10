using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using System;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();
        public Reference_Config_Panel()
        {
            InitializeComponent();
            DataContext = this;
            Initialize_Reference_Slots();
            Initialize_Reference_Waveforms_Graph();
            Initialize_Timers();
            AutoLoad_Load_File();
            Create_Theme_Change_EventHandler();
        }

        private void Reference_Calculator_Closing(object sender, EventArgs e)
        {
            try
            {
                Math_Expression_Process.Stop();
                Math_Expression_Process.Dispose();
                Math_Expression_Process = null;
                Graph.Plot.Clear();
                Graph = null;
                Remove_Create_Theme_Change_EventHandler();
            }
            catch (Exception) { }
        }
    }
}
