using MahApps.Metro.Controls;

namespace SCPI_Communication
{
    public partial class SCPI_Communication_Window : MetroWindow
    {
        public SCPI_Communication_Window()
        {
            InitializeComponent();
            DataContext = this;
            AutoLoad_Load_File();
            Create_Theme_Change_EventHandler();
        }
    }
}
