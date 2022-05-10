using Create_Custom_Math_Expression_Node;
using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        private Create_Custom_Math_Expression_Window Create_Custom_Math_Expression_Node_Window;
        private bool Create_Custom_Math_Expression_Node_Window_isOpen = false;

        private void Create_Custom_Math_Expression_Node_Window_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Create_Custom_Math_Expression_Node_Window == null && Create_Custom_Math_Expression_Node_Window_isOpen == false)
            {
                Create_Custom_Math_Expression_Node_Window_isOpen = true;
                Create_Custom_Math_Expression_Node_Window = new Create_Custom_Math_Expression_Window();
                Create_Custom_Math_Expression_Node_Window.Set_Parent_MainWindow(this);
                Create_Custom_Math_Expression_Node_Window.Show();
                Create_Custom_Math_Expression_Node_Window.Closed += Create_Custom_Math_Expression_Node_Window_Closed_Event;
                Insert_Log("Create Custom Math Expression Node Window is open.", 0);
            }
            else
            {
                Insert_Log("Create Custom Math Expression Node Window is already open.", 2);
            }
        }

        private void Create_Custom_Math_Expression_Node_Window_Closed_Event(object sender, EventArgs e)
        {
            Create_Custom_Math_Expression_Node_Window.Closed -= Create_Custom_Math_Expression_Node_Window_Closed_Event;
            Create_Custom_Math_Expression_Node_Window = null;
            Create_Custom_Math_Expression_Node_Window_isOpen = false;
            Insert_Log("Create Custom Math Expression Node Window is closed.", 0);
        }
    }
}
