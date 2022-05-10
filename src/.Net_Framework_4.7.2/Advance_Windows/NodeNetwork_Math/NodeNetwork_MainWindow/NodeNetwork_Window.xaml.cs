using MahApps.Metro.Controls;
using Node_Model_Classes;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using Oscilloscope_Channel_Node;
using System;
using System.Collections.Concurrent;
using System.Windows.Data;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        //Waveform data is initially stored here unitl it is removed, processed and displayed on the graph window
        public BlockingCollection<All_Channels_Data> All_Channels_Data_Queue = new BlockingCollection<All_Channels_Data>();
        public BlockingCollection<Remote_Channel_Waveform_Model_Class> Remote_Channels_Data_Queue = new BlockingCollection<Remote_Channel_Waveform_Model_Class>();

        private NodeListViewModel ListViewModel { get; } = new NodeListViewModel();

        private NetworkViewModel NodeNetwork_Editor { get; } = new NetworkViewModel();

        private Helpful_Functions Functions = new Helpful_Functions();

        //These timers periodically check for any data inserted into Data_Queue, and processs it
        private System.Timers.Timer Waveform_Data_Process;

        private int ID_Counter = 0;

        public NodeNetwork_Window(string CH1_Color, string CH2_Color, string CH3_Color, string CH4_Color)
        {
            InitializeComponent();
            DataContext = this;
            networkEditorView.ViewModel = NodeNetwork_Editor;
            nodeList.ViewModel = ListViewModel;
            nodeList.CVS.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

            CH1_Color_string = CH1_Color;
            CH2_Color_string = CH2_Color;
            CH3_Color_string = CH3_Color;
            CH4_Color_string = CH4_Color;

            Initialize_NodeEditor_Layout_Helper();

            Add_Nodes_to_NodeList();
            Initialize_Timers();
            Initialize_Remote_Channels_Timers();

            Set_Initial_NodeEditor_Theme();

            AutoLoad_Load_File();
            AutoLoad_Remote_Channels_Config();
        }

        private void Initialize_Timers()
        {
            Waveform_Data_Process = new System.Timers.Timer(50);
            Waveform_Data_Process.Elapsed += Waveform_Data_Process_NodeNetwork;
            Waveform_Data_Process.AutoReset = false;
            Waveform_Data_Process.Enabled = true;
        }

        private void Waveform_Data_Process_NodeNetwork(object sender, EventArgs e)
        {

            while (All_Channels_Data_Queue.Count > 0)
            {
                try
                {
                    if (ID_Counter > 1000000)
                    {
                        ID_Counter = 0;
                    }

                    All_Channels_Data Channels_Data = All_Channels_Data_Queue.Take();

                    if (Channels_Data.CH1.Valid)
                    {
                        Channel_1_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Channels_Data.CH1.Data_Points, Channels_Data.CH1.Total_Time, Channels_Data.CH1.Start_Time, Channels_Data.CH1.Stop_Time, Channels_Data.CH1.X_Data, Channels_Data.CH1.Y_Data, Channels_Data.CH1.Channel_Info);
                    }

                    if (Channels_Data.CH2.Valid)
                    {
                        Channel_2_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Channels_Data.CH2.Data_Points, Channels_Data.CH2.Total_Time, Channels_Data.CH2.Start_Time, Channels_Data.CH2.Stop_Time, Channels_Data.CH2.X_Data, Channels_Data.CH2.Y_Data, Channels_Data.CH2.Channel_Info);
                    }

                    if (Channels_Data.CH3.Valid)
                    {
                        Channel_3_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Channels_Data.CH3.Data_Points, Channels_Data.CH3.Total_Time, Channels_Data.CH3.Start_Time, Channels_Data.CH3.Stop_Time, Channels_Data.CH3.X_Data, Channels_Data.CH3.Y_Data, Channels_Data.CH3.Channel_Info);
                    }

                    if (Channels_Data.CH4.Valid)
                    {
                        Channel_4_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Channels_Data.CH4.Data_Points, Channels_Data.CH4.Total_Time, Channels_Data.CH4.Start_Time, Channels_Data.CH4.Stop_Time, Channels_Data.CH4.X_Data, Channels_Data.CH4.Y_Data, Channels_Data.CH4.Channel_Info);
                    }
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Waveform Data could not be processed.", 1);
                }
            }

            while (Remote_Channels_Data_Queue.Count > 0)
            {
                try
                {
                    Remote_Channels_Data_Queue_Process(Remote_Channels_Data_Queue.Take());
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Remote Channels Waveform Data could not be processed.", 1);
                }
            }

            Waveform_Data_Process.Enabled = true;
        }

        private void Remote_Channels_Data_Queue_Process(Remote_Channel_Waveform_Model_Class Waveform_Data)
        {

            switch (Waveform_Data.Channel_ID)
            {
                case 5:
                    Channel_5_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Waveform_Data.Data_Points, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Waveform_X_Data, Waveform_Data.Waveform_Y_Data, Waveform_Data.Channel_Info);
                    break;
                case 6:
                    Channel_6_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Waveform_Data.Data_Points, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Waveform_X_Data, Waveform_Data.Waveform_Y_Data, Waveform_Data.Channel_Info);
                    break;
                case 7:
                    Channel_7_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Waveform_Data.Data_Points, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Waveform_X_Data, Waveform_Data.Waveform_Y_Data, Waveform_Data.Channel_Info);
                    break;
                case 8:
                    Channel_8_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Waveform_Data.Data_Points, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Waveform_X_Data, Waveform_Data.Waveform_Y_Data, Waveform_Data.Channel_Info);
                    break;
                case 9:
                    Channel_9_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Waveform_Data.Data_Points, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Waveform_X_Data, Waveform_Data.Waveform_Y_Data, Waveform_Data.Channel_Info);
                    break;
                case 10:
                    Channel_10_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Waveform_Data.Data_Points, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Waveform_X_Data, Waveform_Data.Waveform_Y_Data, Waveform_Data.Channel_Info);
                    break;
                case 11:
                    Channel_11_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Waveform_Data.Data_Points, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Waveform_X_Data, Waveform_Data.Waveform_Y_Data, Waveform_Data.Channel_Info);
                    break;
                case 12:
                    Channel_12_Node_ViewModel.Waveform_Data_Insert.Value = new Node_Waveform_Model(ID_Counter++, Waveform_Data.Data_Points, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Waveform_X_Data, Waveform_Data.Waveform_Y_Data, Waveform_Data.Channel_Info);
                    break;
            }
        }
    }
}
