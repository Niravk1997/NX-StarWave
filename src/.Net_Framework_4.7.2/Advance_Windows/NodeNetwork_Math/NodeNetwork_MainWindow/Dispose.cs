﻿using DynamicData;
using MahApps.Metro.Controls;
using System;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Waveform_Data_Process.Stop();
                Waveform_Data_Process.Dispose();

                All_Channels_Data_Queue.Dispose();
                All_Channels_Data_Queue = null;

                NodeNetwork_Editor.Nodes.Clear();
                NodeNetwork_Editor.Nodes.Dispose();
                NodeNetwork_Editor.Connections.Clear();
                NodeNetwork_Editor.Connections.Dispose();
                ListViewModel.VisibleNodes.Dispose();

                networkEditorView = null;
                nodeList = null;

                if (Create_Custom_Math_Expression_Node_Window != null)
                {
                    Create_Custom_Math_Expression_Node_Window.Close();
                }

                Remote_Channels_Data_Process.Stop();
                Remote_Channels_Data_Process.Dispose();

                Remote_Channels_Client.Dispose();

                Remote_Channels_GetStringAsync_Task_List.Clear();
                Remote_Channels_GetStringAsync_Task_List = null;

                Remote_Channels_Data_Queue.Dispose();

                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
