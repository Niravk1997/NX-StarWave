using Basic_Math_Node;
using Basic_ValueMath_Node;
using Basic_Waveform_Shift_Node;
using Custom_Math_Expressions_Node;
using FFT_Node;
using Histogram_Node;
using NodeNetwork.ViewModels;
using NodeNetwork_Math;
using Oscilloscope_Channel_Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using YT_Node;

namespace NodeEditor_Layout_Save_Load
{
    public class NodeEditor_Layout_Save
    {
        // String Split Character
        private readonly string split = "@@@";
        private readonly string[] split_array = new string[] { "@@@" };

        private NodeNetwork_Window NodeNetwork_MainWindow { get; set; }

        public NodeEditor_Layout_Save(NodeNetwork_Window NodeNetwork_MainWindow)
        {
            this.NodeNetwork_MainWindow = NodeNetwork_MainWindow;
        }

        public bool NodeEditor_Verify_Unique_Positions(NetworkViewModel NodeNetwork_Editor)
        {
            List<Point> Node_Positions = new List<Point>();
            foreach (NodeViewModel Node in NodeNetwork_Editor.Nodes.Items)
            {
                Node_Positions.Add(Node.Position);
            }
            var Difference_Check = new HashSet<Point>();
            bool All_Values_Unique = Node_Positions.All(Difference_Check.Add);
            return All_Values_Unique;
        }

        public (List<string> Nodes_List, List<string> Connection_List) NodeEditor_Save_Layout(NetworkViewModel NodeNetwork_Editor)
        {
            List<string> Nodes_List = new List<string>();
            List<string> Connection_List = new List<string>();

            foreach (Channel_1_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_1_Node_ViewModel))
            {
                string Node_Info = "Channel_1_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_2_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_2_Node_ViewModel))
            {
                string Node_Info = "Channel_2_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_3_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_3_Node_ViewModel))
            {
                string Node_Info = "Channel_3_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_4_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_4_Node_ViewModel))
            {
                string Node_Info = "Channel_4_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_5_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_5_Node_ViewModel))
            {
                string Node_Info = "Channel_5_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_6_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_6_Node_ViewModel))
            {
                string Node_Info = "Channel_6_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_7_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_7_Node_ViewModel))
            {
                string Node_Info = "Channel_7_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_8_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_8_Node_ViewModel))
            {
                string Node_Info = "Channel_8_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_9_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_9_Node_ViewModel))
            {
                string Node_Info = "Channel_9_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_10_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_10_Node_ViewModel))
            {
                string Node_Info = "Channel_10_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_11_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_11_Node_ViewModel))
            {
                string Node_Info = "Channel_11_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Channel_12_Node_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_12_Node_ViewModel))
            {
                string Node_Info = "Channel_12_Node_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Basic_Math_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Basic_Math_ViewModel))
            {
                string Node_Info = "Basic_Math_ViewModel" + split + node.Node_Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Math_Type + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Basic_ValueMath_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Basic_ValueMath_ViewModel))
            {
                string Node_Info = "Basic_ValueMath_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Math_Type + split + node.Math_Value + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Basic_Waveform_Shift_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Basic_Waveform_Shift_ViewModel))
            {
                string Node_Info = "Basic_Waveform_Shift_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Direction + split + node.Shift_Value + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed;
                Nodes_List.Add(Node_Info);
            }

            foreach (Custom_Math_Expression_ViewModel_1_Input node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Custom_Math_Expression_ViewModel_1_Input))
            {
                string Node_Info = "Custom_Math_Expression_ViewModel_1_Input" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Library_Speed +  split + node.Math_Expression_string + split + node.Output.Name + split + node.Input_1.Name;
                Nodes_List.Add(Node_Info);
            }

            foreach (Custom_Math_Expression_ViewModel_2_Input node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Custom_Math_Expression_ViewModel_2_Input))
            {
                string Node_Info = "Custom_Math_Expression_ViewModel_2_Input" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Library_Speed + split + node.Math_Expression_string + split + node.Output.Name + split + node.Input_1.Name + split + node.Input_2.Name;
                Nodes_List.Add(Node_Info);
            }

            foreach (Custom_Math_Expression_ViewModel_3_Input node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Custom_Math_Expression_ViewModel_3_Input))
            {
                string Node_Info = "Custom_Math_Expression_ViewModel_3_Input" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Library_Speed + split + node.Math_Expression_string + split + node.Output.Name + split + node.Input_1.Name + split + node.Input_2.Name + split + node.Input_3.Name;
                Nodes_List.Add(Node_Info);
            }

            foreach (Custom_Math_Expression_ViewModel_4_Input node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Custom_Math_Expression_ViewModel_4_Input))
            {
                string Node_Info = "Custom_Math_Expression_ViewModel_4_Input" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Library_Speed + split + node.Math_Expression_string + split + node.Output.Name + split + node.Input_1.Name + split + node.Input_2.Name + split + node.Input_3.Name + split + node.Input_4.Name;
                Nodes_List.Add(Node_Info);
            }

            foreach (Custom_Math_Expression_ViewModel_5_Input node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Custom_Math_Expression_ViewModel_5_Input))
            {
                string Node_Info = "Custom_Math_Expression_ViewModel_5_Input" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Library_Speed + split + node.Math_Expression_string + split + node.Output.Name + split + node.Input_1.Name + split + node.Input_2.Name + split + node.Input_3.Name + split + node.Input_4.Name + split + node.Input_5.Name;
                Nodes_List.Add(Node_Info);
            }

            foreach (Custom_Math_Expression_ViewModel_6_Input node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Custom_Math_Expression_ViewModel_6_Input))
            {
                string Node_Info = "Custom_Math_Expression_ViewModel_6_Input" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Library_Speed + split + node.Math_Expression_string + split + node.Output.Name + split + node.Input_1.Name + split + node.Input_2.Name + split + node.Input_3.Name + split + node.Input_4.Name + split + node.Input_5.Name + split + node.Input_6.Name;
                Nodes_List.Add(Node_Info);
            }

            foreach (Custom_Math_Expression_ViewModel_7_Input node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Custom_Math_Expression_ViewModel_7_Input))
            {
                string Node_Info = "Custom_Math_Expression_ViewModel_7_Input" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Library_Speed + split + node.Math_Expression_string + split + node.Output.Name + split + node.Input_1.Name + split + node.Input_2.Name + split + node.Input_3.Name + split + node.Input_4.Name + split + node.Input_5.Name + split + node.Input_6.Name + split + node.Input_7.Name;
                Nodes_List.Add(Node_Info);
            }

            foreach (YT_Inputs_1_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is YT_Inputs_1_ViewModel))
            {
                string Node_Info = "YT_Inputs_1_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Input_1.Name + split + node.Input_1_Color;
                Nodes_List.Add(Node_Info);
            }

            foreach (FFT_Inputs_1_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is FFT_Inputs_1_ViewModel))
            {
                string Node_Info = "FFT_Inputs_1_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Input_1.Name + split + node.Input_1_Color;
                Nodes_List.Add(Node_Info);
            }

            foreach (Histogram_Inputs_1_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Histogram_Inputs_1_ViewModel))
            {
                string Node_Info = "Histogram_Inputs_1_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Input_1.Name + split + node.Input_1_Color + split + node.Input_1_Bucket_Count;
                Nodes_List.Add(Node_Info);
            }

            foreach (Histogram_Inputs_2_ViewModel node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Histogram_Inputs_2_ViewModel))
            {
                string Node_Info = "Histogram_Inputs_2_ViewModel" + split + node.Name + split + node.Position.X + split + node.Position.Y + split + (int)node.Category + split + node.Background_Color + split + node.Foreground_Color + split + node.Units + split + node.IsCollapsed + split + node.Input_1.Name + split + node.Input_1_Color + split + node.Input_1_Bucket_Count + split + node.Input_2.Name + split + node.Input_2_Color + split + node.Input_2_Bucket_Count;
                Nodes_List.Add(Node_Info);
            }

            foreach (var connection in NodeNetwork_Editor.Connections.Items)
            {
                string Connection_Info = connection.Output.Parent.Name + split + connection.Output.Parent.Position.X + split + connection.Output.Parent.Position.Y + split + connection.Output.Name + split + connection.Input.Parent.Name + split + connection.Input.Parent.Position.X + split + connection.Input.Parent.Position.Y + split + connection.Input.Name;
                Connection_List.Add(Connection_Info);
            }

            return (Nodes_List, Connection_List);
        }

        public List<(Node_ViewModel, bool isCollapsed)> NodeEditor_List_of_Nodes(List<string> Nodes_List)
        {
            List<(Node_ViewModel, bool isCollapsed)> Math_Nodes_List = new List<(Node_ViewModel, bool isCollapsed)>();

            for (int i = 0; i < Nodes_List.Count; i++)
            {
                string[] Node_Info = Nodes_List[i].Split(split_array, StringSplitOptions.None);
                bool isCollapsed = false;
                switch (Node_Info[0])
                {
                    case "Channel_1_Node_ViewModel":
                        Channel_1_Node_ViewModel Channel_1_Node = new Channel_1_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_1_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_1_Node, isCollapsed));
                        break;
                    case "Channel_2_Node_ViewModel":
                        Channel_2_Node_ViewModel Channel_2_Node = new Channel_2_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_2_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_2_Node, isCollapsed));
                        break;
                    case "Channel_3_Node_ViewModel":
                        Channel_3_Node_ViewModel Channel_3_Node = new Channel_3_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_3_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True")
                        { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_3_Node, isCollapsed));
                        break;
                    case "Channel_4_Node_ViewModel":
                        Channel_4_Node_ViewModel Channel_4_Node = new Channel_4_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_4_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_4_Node, isCollapsed));
                        break;
                    case "Channel_5_Node_ViewModel":
                        Channel_5_Node_ViewModel Channel_5_Node = new Channel_5_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_5_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_5_Node, isCollapsed));
                        break;
                    case "Channel_6_Node_ViewModel":
                        Channel_6_Node_ViewModel Channel_6_Node = new Channel_6_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_6_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_6_Node, isCollapsed));
                        break;
                    case "Channel_7_Node_ViewModel":
                        Channel_7_Node_ViewModel Channel_7_Node = new Channel_7_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_7_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_7_Node, isCollapsed));
                        break;
                    case "Channel_8_Node_ViewModel":
                        Channel_8_Node_ViewModel Channel_8_Node = new Channel_8_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_8_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_8_Node, isCollapsed));
                        break;
                    case "Channel_9_Node_ViewModel":
                        Channel_9_Node_ViewModel Channel_9_Node = new Channel_9_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_9_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_9_Node, isCollapsed));
                        break;
                    case "Channel_10_Node_ViewModel":
                        Channel_10_Node_ViewModel Channel_10_Node = new Channel_10_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_10_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_10_Node, isCollapsed));
                        break;
                    case "Channel_11_Node_ViewModel":
                        Channel_11_Node_ViewModel Channel_11_Node = new Channel_11_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_11_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_11_Node, isCollapsed));
                        break;
                    case "Channel_12_Node_ViewModel":
                        Channel_12_Node_ViewModel Channel_12_Node = new Channel_12_Node_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6]);
                        Channel_12_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[7] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Channel_12_Node, isCollapsed));
                        break;
                    case "Basic_Math_ViewModel":
                        Basic_Math_ViewModel Basic_Math_Node = new Basic_Math_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), (Basic_Math_Type)int.Parse(Node_Info[5]), Node_Info[6], Node_Info[7], Node_Info[8]);
                        Basic_Math_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[9] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Basic_Math_Node, isCollapsed));
                        break;
                    case "Basic_ValueMath_ViewModel":
                        Basic_ValueMath_ViewModel Basic_ValueMath_Node = new Basic_ValueMath_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), int.Parse(Node_Info[5]), double.Parse(Node_Info[6]), Node_Info[7], Node_Info[8], Node_Info[9]);
                        Basic_ValueMath_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[10] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Basic_ValueMath_Node, isCollapsed));
                        break;
                    case "Basic_Waveform_Shift_ViewModel":
                        Basic_Waveform_Shift_ViewModel Basic_Waveform_Shift_Node = new Basic_Waveform_Shift_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), int.Parse(Node_Info[5]), int.Parse(Node_Info[6]), Node_Info[7], Node_Info[8], Node_Info[9]);
                        Basic_Waveform_Shift_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[10] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Basic_Waveform_Shift_Node, isCollapsed));
                        break;
                    case "Custom_Math_Expression_ViewModel_1_Input":
                        Custom_Math_Expression_ViewModel_1_Input Custom_Math_Expression_ViewModel_1_Input_Node = new Custom_Math_Expression_ViewModel_1_Input(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10], Node_Info[11], Node_Info[12]);
                        Custom_Math_Expression_ViewModel_1_Input_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Custom_Math_Expression_ViewModel_1_Input_Node, isCollapsed));
                        break;
                    case "Custom_Math_Expression_ViewModel_2_Input":
                        Custom_Math_Expression_ViewModel_2_Input Custom_Math_Expression_ViewModel_2_Input_Node = new Custom_Math_Expression_ViewModel_2_Input(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10], Node_Info[11], Node_Info[12], Node_Info[13]);
                        Custom_Math_Expression_ViewModel_2_Input_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Custom_Math_Expression_ViewModel_2_Input_Node, isCollapsed));
                        break;
                    case "Custom_Math_Expression_ViewModel_3_Input":
                        Custom_Math_Expression_ViewModel_3_Input Custom_Math_Expression_ViewModel_3_Input_Node = new Custom_Math_Expression_ViewModel_3_Input(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10], Node_Info[11], Node_Info[12], Node_Info[13], Node_Info[14]);
                        Custom_Math_Expression_ViewModel_3_Input_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Custom_Math_Expression_ViewModel_3_Input_Node, isCollapsed));
                        break;
                    case "Custom_Math_Expression_ViewModel_4_Input":
                        Custom_Math_Expression_ViewModel_4_Input Custom_Math_Expression_ViewModel_4_Input_Node = new Custom_Math_Expression_ViewModel_4_Input(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10], Node_Info[11], Node_Info[12], Node_Info[13], Node_Info[14], Node_Info[15]);
                        Custom_Math_Expression_ViewModel_4_Input_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Custom_Math_Expression_ViewModel_4_Input_Node, isCollapsed));
                        break;
                    case "Custom_Math_Expression_ViewModel_5_Input":
                        Custom_Math_Expression_ViewModel_5_Input Custom_Math_Expression_ViewModel_5_Input_Node = new Custom_Math_Expression_ViewModel_5_Input(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10], Node_Info[11], Node_Info[12], Node_Info[13], Node_Info[14], Node_Info[15], Node_Info[16]);
                        Custom_Math_Expression_ViewModel_5_Input_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Custom_Math_Expression_ViewModel_5_Input_Node, isCollapsed));
                        break;
                    case "Custom_Math_Expression_ViewModel_6_Input":
                        Custom_Math_Expression_ViewModel_6_Input Custom_Math_Expression_ViewModel_6_Input_Node = new Custom_Math_Expression_ViewModel_6_Input(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10], Node_Info[11], Node_Info[12], Node_Info[13], Node_Info[14], Node_Info[15], Node_Info[16], Node_Info[17]);
                        Custom_Math_Expression_ViewModel_6_Input_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Custom_Math_Expression_ViewModel_6_Input_Node, isCollapsed));
                        break;
                    case "Custom_Math_Expression_ViewModel_7_Input":
                        Custom_Math_Expression_ViewModel_7_Input Custom_Math_Expression_ViewModel_7_Input_Node = new Custom_Math_Expression_ViewModel_7_Input(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10], Node_Info[11], Node_Info[12], Node_Info[13], Node_Info[14], Node_Info[15], Node_Info[16], Node_Info[17], Node_Info[18]);
                        Custom_Math_Expression_ViewModel_7_Input_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Custom_Math_Expression_ViewModel_7_Input_Node, isCollapsed));
                        break;
                    case "YT_Inputs_1_ViewModel":
                        YT_Inputs_1_ViewModel YT_Inputs_1_ViewModel_Node = new YT_Inputs_1_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10]);
                        YT_Inputs_1_ViewModel_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((YT_Inputs_1_ViewModel_Node, isCollapsed));
                        break;
                    case "FFT_Inputs_1_ViewModel":
                        FFT_Inputs_1_ViewModel FFT_Inputs_1_ViewModel_Node = new FFT_Inputs_1_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10]);
                        FFT_Inputs_1_ViewModel_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((FFT_Inputs_1_ViewModel_Node, isCollapsed));
                        break;
                    case "Histogram_Inputs_1_ViewModel":
                        Histogram_Inputs_1_ViewModel Histogram_Inputs_1_ViewModel_Node = new Histogram_Inputs_1_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10], int.Parse(Node_Info[11]));
                        Histogram_Inputs_1_ViewModel_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Histogram_Inputs_1_ViewModel_Node, isCollapsed));
                        break;
                    case "Histogram_Inputs_2_ViewModel":
                        Histogram_Inputs_2_ViewModel Histogram_Inputs_2_ViewModel_Node = new Histogram_Inputs_2_ViewModel(NodeNetwork_MainWindow, Node_Info[1], false, (NodeCategory)int.Parse(Node_Info[4]), Node_Info[5], Node_Info[6], Node_Info[7], Node_Info[9], Node_Info[10], int.Parse(Node_Info[11]), Node_Info[12], Node_Info[13], int.Parse(Node_Info[14]));
                        Histogram_Inputs_2_ViewModel_Node.Position = new System.Windows.Point(double.Parse(Node_Info[2]), double.Parse(Node_Info[3]));
                        if (Node_Info[8] == "True") { isCollapsed = true; }
                        Math_Nodes_List.Add((Histogram_Inputs_2_ViewModel_Node, isCollapsed));
                        break;
                    default:
                        break;
                }
            }

            return Math_Nodes_List;
        }

        public List<ConnectionViewModel> NodeEditor_List_of_Connections(NetworkViewModel NodeNetwork_Editor, List<(Node_ViewModel, bool isCollapsed)> Math_Nodes_List, List<string> Connection_List)
        {
            List<ConnectionViewModel> Node_Connections = new List<ConnectionViewModel>();

            for (int i = 0; i < Connection_List.Count; i++)
            {
                string[] Connection_Info = Connection_List[i].Split(split_array, StringSplitOptions.None);

                string Output_Parent_Name = Connection_Info[0];
                double Output_Parent_Position_X = double.Parse(Connection_Info[1]);
                double Output_Parent_Position_Y = double.Parse(Connection_Info[2]);
                string Output_Name = Connection_Info[3];

                string Input_Parent_Name = Connection_Info[4];
                double Input_Parent_Position_X = double.Parse(Connection_Info[5]);
                double Input_Parent_Position_Y = double.Parse(Connection_Info[6]);
                string Input_Name = Connection_Info[7];

                Node_Connections.Add(NodeNetwork_Editor.ConnectionFactory(Math_Nodes_List.Single(Node => Node.Item1.Name == Input_Parent_Name && Node.Item1.Position.X == Input_Parent_Position_X && Node.Item1.Position.Y == Input_Parent_Position_Y).Item1.Inputs.Items.Single(Input => Input.Name == Input_Name), Math_Nodes_List.Single(Node => Node.Item1.Name == Output_Parent_Name && Node.Item1.Position.X == Output_Parent_Position_X && Node.Item1.Position.Y == Output_Parent_Position_Y).Item1.Outputs.Items.Single(Output => Output.Name == Output_Name)));
            }

            return Node_Connections;
        }
    }
}
