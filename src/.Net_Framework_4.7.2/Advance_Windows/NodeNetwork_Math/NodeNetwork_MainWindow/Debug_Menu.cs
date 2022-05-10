using MahApps.Metro.Controls;
using NodeNetwork.Toolkit.Layout.ForceDirected;
using NodeNetwork.ViewModels;
using System;
using System.Windows;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        private ForceDirectedLayouter NodeEditor_Layouter = new ForceDirectedLayouter();

        private void Collapse_all_Nodes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (is_NodeEditor_Save_Load_in_Progress == false)
                {
                    foreach (NodeViewModel Node in NodeNetwork_Editor.Nodes.Items)
                    {
                        Node.IsCollapsed = true;
                    }
                }
                else
                {
                    Insert_Log("NodeEditor Layout Save/Load in progress. Please wait.", 2);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Uncollapse_all_Nodes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (is_NodeEditor_Save_Load_in_Progress == false)
                {
                    foreach (NodeViewModel Node in NodeNetwork_Editor.Nodes.Items)
                    {
                        Node.IsCollapsed = false;
                    }
                }
                else
                {
                    Insert_Log("NodeEditor Layout Save/Load in progress. Please wait.", 2);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Auto_Layout_Nodes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (is_NodeEditor_Save_Load_in_Progress == false)
                {
                    NodeEditor_Layouter.Layout(new Configuration { Network = NodeNetwork_Editor }, 500);
                }
                else
                {
                    Insert_Log("NodeEditor Layout Save/Load in progress. Please wait.", 2);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }
    }
}
