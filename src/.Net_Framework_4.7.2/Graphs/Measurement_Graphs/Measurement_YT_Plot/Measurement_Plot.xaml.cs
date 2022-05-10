using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : MetroWindow
    {
        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public Measurement_Plot_Window(double[] Date_Time, double[] Measurement_Data, string Measurement_Label, string Measurement_Unit, string Measurement_Color)
        {
            InitializeComponent();
            DataContext = this;
            Graph_RightClick_Menu();
            Initialize_Variables(Measurement_Label, Measurement_Unit, Measurement_Color);
            Initialize_Plot();
            Initialize_Plot_Data(Date_Time, Measurement_Data);
            Initialize_Measurement_Plot();
            Initialize_Timers();
        }
    }
}
