using MahApps.Metro.Controls;
using NodeNetwork_Math;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : MetroWindow
    {
        private NodeNetwork_Window NodeNetwork_MainWindow { get; set; }

        public Create_Custom_Math_Expression_Window()
        {
            InitializeComponent();
            DataContext = this;
            Inputs_Disable(0);
            AutoLoad_Load_File();
        }

        public void Set_Parent_MainWindow(object Parent_Window)
        {
            NodeNetwork_MainWindow = Parent_Window as NodeNetwork_Window;
        }
    }
}
