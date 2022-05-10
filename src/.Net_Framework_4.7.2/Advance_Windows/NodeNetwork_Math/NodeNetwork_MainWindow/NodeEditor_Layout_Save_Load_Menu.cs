using DynamicData;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using NodeEditor_Layout_Save_Load;
using NodeNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        private NodeEditor_Layout_Save NodeEditor_Layout_Helper;

        private bool is_NodeEditor_Save_Load_in_Progress = false;

        private void Initialize_NodeEditor_Layout_Helper() 
        {
            NodeEditor_Layout_Helper = new NodeEditor_Layout_Save(this);
        }

        private void Save_NodeEditor_Layout_Text_File_Click(object sender, RoutedEventArgs e)
        {
            if (is_NodeEditor_Save_Load_in_Progress == false)
            {
                is_NodeEditor_Save_Load_in_Progress = true;

                try
                {
                    if (NodeEditor_Layout_Helper.NodeEditor_Verify_Unique_Positions(NodeNetwork_Editor))
                    {
                        SaveFileDialog Save_Data_Text_Window = new SaveFileDialog
                        {
                            InitialDirectory = NX_StarWave.Communication_Selected.folder_Directory,
                            FileName = "NodeEditor_Layout_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                            Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                          "|All files (*.*)|*.*"
                        };

                        if (Save_Data_Text_Window.ShowDialog() is true)
                        {
                            Save_NodeEditor_Layout_Text_File(Save_Data_Text_Window.FileName);
                            is_NodeEditor_Save_Load_in_Progress = false;
                            Insert_Log("NodeEditor Layout saved to text file.", 0);
                            Insert_Log($"Saved to {Save_Data_Text_Window.FileName}.", 0);
                        }
                        else
                        {
                            is_NodeEditor_Save_Load_in_Progress = false;
                        }
                    }
                    else
                    {
                        Insert_Log("Could not save NodeEditor Layout, seems like some of the nodes may be exactly on top of each other.", 2);
                        Insert_Log("All Nodes' positions must be unique, no two nodes must have the exact same position on the grid.", 2);
                        Insert_Log("Click the Auto Layout option from the debug menu and try again.", 2);
                        is_NodeEditor_Save_Load_in_Progress = false;
                    }

                }
                catch (Exception Ex)
                {
                    NodeEditor_Enable = true;
                    is_NodeEditor_Save_Load_in_Progress = false;
                    Insert_Log("Could not save NodeEditor Layout to text file.", 1);
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("NodeEditor Layout Save in progress. Please wait.", 2);
            }
        }

        private void Save_NodeEditor_Layout_Text_File(string Text_File_Full_Path)
        {
            NodeEditor_Enable = false;
            (List<string> Nodes_List, List<string> Connection_List) = NodeEditor_Layout_Helper.NodeEditor_Save_Layout(NodeNetwork_Editor);

            int Node_List_Count = Nodes_List.Count;
            int Connection_List_Count = Connection_List.Count;

            using (TextWriter datatotxt = new StreamWriter(Text_File_Full_Path, false))
            {
                datatotxt.WriteLine("Total Nodes" + "," + $"{Node_List_Count}" + "," + "Total Connections" + "," + $"{Connection_List_Count}");

                for (int i = 0; i < Node_List_Count; i++)
                {
                    datatotxt.WriteLine(Nodes_List[i]);
                }

                for (int i = 0; i < Connection_List_Count; i++)
                {
                    datatotxt.WriteLine(Connection_List[i]);
                }
            }

            NodeEditor_Enable = true;

            Nodes_List.Clear();
            Connection_List.Clear();
            Nodes_List = null;
            Connection_List = null;
        }

        private void Load_NodeEditor_Layout_Text_File_Click(object sender, RoutedEventArgs e)
        {
            if (is_NodeEditor_Save_Load_in_Progress == false)
            {
                is_NodeEditor_Save_Load_in_Progress = true;

                try
                {
                    OpenFileDialog File_Dialog = new OpenFileDialog
                    {
                        InitialDirectory = NX_StarWave.Communication_Selected.folder_Directory,
                        Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                    };

                    if (File_Dialog.ShowDialog() is true)
                    {
                        Load_NodeEditor_Layout_Text_File(File_Dialog.FileName);
                        is_NodeEditor_Save_Load_in_Progress = false;
                        Insert_Log("NodeEditor Layout loaded from text file.", 0);
                        Insert_Log($"Loaded from {File_Dialog.FileName}.", 0);
                    }
                    else
                    {
                        is_NodeEditor_Save_Load_in_Progress = false;
                    }
                }
                catch (Exception Ex)
                {
                    NodeEditor_Enable = true;
                    is_NodeEditor_Save_Load_in_Progress = false;
                    Insert_Log("Could not load NodeEditor Layout from the text file.", 1);
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("NodeEditor Layout Load in progress. Please wait.", 2);
            }
        }

        private void Load_NodeEditor_Layout_Text_File(string Text_File_Full_Path)
        {
            NodeEditor_Enable = false;

            IDisposable NodeNetwork_Editor_Suppress_Changes_Notifications = NodeNetwork_Editor.SuppressChangeNotifications();

            NodeNetwork_Editor.Connections.Clear();
            NodeNetwork_Editor.Nodes.Clear();

            List<string> Nodes_List = new List<string>();
            List<string> Connection_List = new List<string>();

            string[] Node_Text_Data = File.ReadAllLines(Text_File_Full_Path);

            string[] Nodes_Connections_Info = Node_Text_Data[0].Split(',');

            int Node_Text_Data_Count = Node_Text_Data.Length;
            int Node_List_Count = int.Parse(Nodes_Connections_Info[1]) + 1;
            int Connection_List_Count = int.Parse(Nodes_Connections_Info[3]);

            for (int i = 1; i < Node_List_Count; i++)
            {
                Nodes_List.Add(Node_Text_Data[i]);
            }

            int Start_Reading_Connections_text_from = Node_List_Count;

            for (int i = Start_Reading_Connections_text_from; i < Node_Text_Data_Count; i++)
            {
                Connection_List.Add(Node_Text_Data[i]);
            }

            List<(Node_ViewModel, bool isCollapsed)> NodeEditor_Nodes = NodeEditor_Layout_Helper.NodeEditor_List_of_Nodes(Nodes_List);
            List<ConnectionViewModel> NodeEditor_Connections = NodeEditor_Layout_Helper.NodeEditor_List_of_Connections(NodeNetwork_Editor, NodeEditor_Nodes, Connection_List);

            foreach ((Node_ViewModel, bool isCollapsed) Node in NodeEditor_Nodes)
            {
                NodeNetwork_Editor.Nodes.Add(Node.Item1);
            }

            foreach (ConnectionViewModel Node_Connection in NodeEditor_Connections)
            {
                NodeNetwork_Editor.Connections.Add(Node_Connection);
            }

            int Count = 0;
            foreach (NodeViewModel Node in NodeNetwork_Editor.Nodes.Items)
            {
                if (NodeEditor_Nodes[Count].Item2 == true)
                {
                    Node.IsCollapsed = true;
                }
                Count++;
            }

            NodeNetwork_Editor_Suppress_Changes_Notifications.Dispose();

            NodeEditor_Enable = true;

            Nodes_List.Clear();
            Connection_List.Clear();
            Nodes_List = null;
            Connection_List = null;
            Node_Text_Data = null;

            NodeEditor_Nodes.Clear();
            NodeEditor_Nodes = null;
            NodeEditor_Connections.Clear();
            NodeEditor_Connections = null;
        }
    }
}
