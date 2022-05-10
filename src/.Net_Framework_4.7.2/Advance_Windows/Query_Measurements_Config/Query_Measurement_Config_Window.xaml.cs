using MahApps.Metro.Controls;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : MetroWindow
    {
        public Query_Measurement_Config_Window()
        {
            InitializeComponent();
            DataContext = this;
            AutoLoad_Load_File();
            Create_Theme_Change_EventHandler();
        }
    }
}
