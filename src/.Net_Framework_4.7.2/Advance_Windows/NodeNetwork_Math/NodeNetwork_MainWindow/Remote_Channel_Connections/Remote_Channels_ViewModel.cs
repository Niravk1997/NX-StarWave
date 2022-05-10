using Oscilloscope_Channel_Node;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : INotifyPropertyChanged
    {
        private bool Get_Remote_Channels_Data_ = false;
        public bool Get_Remote_Channels_Data
        {
            get { return Get_Remote_Channels_Data_; }
            set
            {
                Get_Remote_Channels_Data_ = value;
                NotifyPropertyChanged("Get_Remote_Channels_Data");
            }
        }

        private bool Remote_CH_5_Node_Inserted_into_NodeList = false;
        private bool Remote_CH_5_Enable_ = false;
        public bool Remote_CH_5_Enable
        {
            get { return Remote_CH_5_Enable_; }
            set
            {
                Remote_CH_5_Enable_ = value;
                if (value)
                {
                    if (Remote_CH_5_Node_Inserted_into_NodeList == false)
                    {
                        Remote_CH_5_Node_Inserted_into_NodeList = true;
                        Insert_Remote_Channel_Node_into_NodeList(5);
                    }
                }
                NotifyPropertyChanged("Remote_CH_5_Enable");
            }
        }

        private string Remote_CH_5_Counter_String = "";
        private int Remote_CH_5_Counter_ = 0;
        public int Remote_CH_5_Counter
        {
            get { return Remote_CH_5_Counter_; }
            set
            {
                Remote_CH_5_Counter_ = value;
                NotifyPropertyChanged("Remote_CH_5_Counter");
            }
        }

        private string Remote_CH_5_GetCounter_URL_ = "";
        public string Remote_CH_5_GetCounter_URL
        {
            get { return Remote_CH_5_GetCounter_URL_; }
            set
            {
                Remote_CH_5_GetCounter_URL_ = value;
                NotifyPropertyChanged("Remote_CH_5_GetCounter_URL");
            }
        }

        private string Remote_CH_5_GetWaveform_URL_ = "";
        public string Remote_CH_5_GetWaveform_URL
        {
            get { return Remote_CH_5_GetWaveform_URL_; }
            set
            {
                Remote_CH_5_GetWaveform_URL_ = value;
                NotifyPropertyChanged("Remote_CH_5_GetWaveform_URL");
            }
        }

        private string Remote_CH_5_Name_ = "RChannel 5";
        public string Remote_CH_5_Name
        {
            get { return Remote_CH_5_Name_; }
            set
            {
                Remote_CH_5_Name_ = value;
                if (Remote_CH_5_Enable)
                {
                    try
                    {
                        foreach (Channel_5_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_5_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                        foreach (Channel_5_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_5_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                    }
                    catch (Exception) { }
                }
                NotifyPropertyChanged("Remote_CH_5_Name");
            }
        }

        private string Remote_CH_5_Color_ = "#FF9400D3";
        public string Remote_CH_5_Color
        {
            get { return Remote_CH_5_Color_; }
            set
            {
                Remote_CH_5_Color_ = value;
                try
                {
                    if (Remote_CH_5_Enable)
                    {
                        Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                        BG_Color.Freeze();

                        foreach (Channel_5_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_5_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }

                        foreach (Channel_5_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_5_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }
                    }
                }
                catch (Exception) { }
                NotifyPropertyChanged("Remote_CH_5_Color");
            }
        }

        private bool Remote_CH_6_Node_Inserted_into_NodeList = false;
        private bool Remote_CH_6_Enable_ = false;
        public bool Remote_CH_6_Enable
        {
            get { return Remote_CH_6_Enable_; }
            set
            {
                Remote_CH_6_Enable_ = value;
                if (Remote_CH_6_Node_Inserted_into_NodeList == false)
                {
                    Remote_CH_6_Node_Inserted_into_NodeList = true;
                    Insert_Remote_Channel_Node_into_NodeList(6);
                }
                NotifyPropertyChanged("Remote_CH_6_Enable");
            }
        }

        private string Remote_CH_6_Counter_String = "";
        private int Remote_CH_6_Counter_ = 0;
        public int Remote_CH_6_Counter
        {
            get { return Remote_CH_6_Counter_; }
            set
            {
                Remote_CH_6_Counter_ = value;
                NotifyPropertyChanged("Remote_CH_6_Counter");
            }
        }

        private string Remote_CH_6_GetCounter_URL_ = "";
        public string Remote_CH_6_GetCounter_URL
        {
            get { return Remote_CH_6_GetCounter_URL_; }
            set
            {
                Remote_CH_6_GetCounter_URL_ = value;
                NotifyPropertyChanged("Remote_CH_6_GetCounter_URL");
            }
        }

        private string Remote_CH_6_GetWaveform_URL_ = "";
        public string Remote_CH_6_GetWaveform_URL
        {
            get { return Remote_CH_6_GetWaveform_URL_; }
            set
            {
                Remote_CH_6_GetWaveform_URL_ = value;
                NotifyPropertyChanged("Remote_CH_6_GetWaveform_URL");
            }
        }

        private string Remote_CH_6_Name_ = "RChannel 6";
        public string Remote_CH_6_Name
        {
            get { return Remote_CH_6_Name_; }
            set
            {
                Remote_CH_6_Name_ = value;
                if (Remote_CH_6_Enable)
                {
                    try
                    {
                        foreach (Channel_6_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_6_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                        foreach (Channel_6_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_6_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                    }
                    catch (Exception) { }
                }
                NotifyPropertyChanged("Remote_CH_6_Name");
            }
        }

        private string Remote_CH_6_Color_ = "#FF9400D3";
        public string Remote_CH_6_Color
        {
            get { return Remote_CH_6_Color_; }
            set
            {
                Remote_CH_6_Color_ = value;
                try
                {
                    if (Remote_CH_6_Enable)
                    {
                        Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                        BG_Color.Freeze();

                        foreach (Channel_6_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_6_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }

                        foreach (Channel_6_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_6_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }
                    }
                }
                catch (Exception) { }
                NotifyPropertyChanged("Remote_CH_6_Color");
            }
        }

        private bool Remote_CH_7_Node_Inserted_into_NodeList = false;
        private bool Remote_CH_7_Enable_ = false;
        public bool Remote_CH_7_Enable
        {
            get { return Remote_CH_7_Enable_; }
            set
            {
                Remote_CH_7_Enable_ = value;
                if (Remote_CH_7_Node_Inserted_into_NodeList == false)
                {
                    Remote_CH_7_Node_Inserted_into_NodeList = true;
                    Insert_Remote_Channel_Node_into_NodeList(7);
                }
                NotifyPropertyChanged("Remote_CH_7_Enable");
            }
        }

        private string Remote_CH_7_Counter_String = "";
        private int Remote_CH_7_Counter_ = 0;
        public int Remote_CH_7_Counter
        {
            get { return Remote_CH_7_Counter_; }
            set
            {
                Remote_CH_7_Counter_ = value;
                NotifyPropertyChanged("Remote_CH_7_Counter");
            }
        }

        private string Remote_CH_7_GetCounter_URL_ = "";
        public string Remote_CH_7_GetCounter_URL
        {
            get { return Remote_CH_7_GetCounter_URL_; }
            set
            {
                Remote_CH_7_GetCounter_URL_ = value;
                NotifyPropertyChanged("Remote_CH_7_GetCounter_URL");
            }
        }

        private string Remote_CH_7_GetWaveform_URL_ = "";
        public string Remote_CH_7_GetWaveform_URL
        {
            get { return Remote_CH_7_GetWaveform_URL_; }
            set
            {
                Remote_CH_7_GetWaveform_URL_ = value;
                NotifyPropertyChanged("Remote_CH_7_GetWaveform_URL");
            }
        }

        private string Remote_CH_7_Name_ = "RChannel 7";
        public string Remote_CH_7_Name
        {
            get { return Remote_CH_7_Name_; }
            set
            {
                Remote_CH_7_Name_ = value;
                if (Remote_CH_7_Enable)
                {
                    try
                    {
                        foreach (Channel_7_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_7_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                        foreach (Channel_7_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_7_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                    }
                    catch (Exception) { }
                }
                NotifyPropertyChanged("Remote_CH_7_Name");
            }
        }

        private string Remote_CH_7_Color_ = "#FF9400D3";
        public string Remote_CH_7_Color
        {
            get { return Remote_CH_7_Color_; }
            set
            {
                Remote_CH_7_Color_ = value;
                try
                {
                    if (Remote_CH_7_Enable)
                    {
                        Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                        BG_Color.Freeze();

                        foreach (Channel_7_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_7_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }

                        foreach (Channel_7_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_7_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }
                    }
                }
                catch (Exception) { }
                NotifyPropertyChanged("Remote_CH_7_Color");
            }
        }

        private bool Remote_CH_8_Node_Inserted_into_NodeList = false;
        private bool Remote_CH_8_Enable_ = false;
        public bool Remote_CH_8_Enable
        {
            get { return Remote_CH_8_Enable_; }
            set
            {
                Remote_CH_8_Enable_ = value;
                if (Remote_CH_8_Node_Inserted_into_NodeList == false)
                {
                    Remote_CH_8_Node_Inserted_into_NodeList = true;
                    Insert_Remote_Channel_Node_into_NodeList(8);
                }
                NotifyPropertyChanged("Remote_CH_8_Enable");
            }
        }

        private string Remote_CH_8_Counter_String = "";
        private int Remote_CH_8_Counter_ = 0;
        public int Remote_CH_8_Counter
        {
            get { return Remote_CH_8_Counter_; }
            set
            {
                Remote_CH_8_Counter_ = value;
                NotifyPropertyChanged("Remote_CH_8_Counter");
            }
        }

        private string Remote_CH_8_GetCounter_URL_ = "";
        public string Remote_CH_8_GetCounter_URL
        {
            get { return Remote_CH_8_GetCounter_URL_; }
            set
            {
                Remote_CH_8_GetCounter_URL_ = value;
                NotifyPropertyChanged("Remote_CH_8_GetCounter_URL");
            }
        }

        private string Remote_CH_8_GetWaveform_URL_ = "";
        public string Remote_CH_8_GetWaveform_URL
        {
            get { return Remote_CH_8_GetWaveform_URL_; }
            set
            {
                Remote_CH_8_GetWaveform_URL_ = value;
                NotifyPropertyChanged("Remote_CH_8_GetWaveform_URL");
            }
        }

        private string Remote_CH_8_Name_ = "RChannel 8";
        public string Remote_CH_8_Name
        {
            get { return Remote_CH_8_Name_; }
            set
            {
                Remote_CH_8_Name_ = value;
                if (Remote_CH_8_Enable)
                {
                    try
                    {
                        foreach (Channel_8_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_8_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                        foreach (Channel_8_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_8_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                    }
                    catch (Exception) { }
                }
                NotifyPropertyChanged("Remote_CH_8_Name");
            }
        }

        private string Remote_CH_8_Color_ = "#FF9400D3";
        public string Remote_CH_8_Color
        {
            get { return Remote_CH_8_Color_; }
            set
            {
                Remote_CH_8_Color_ = value;
                try
                {
                    if (Remote_CH_8_Enable)
                    {
                        Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                        BG_Color.Freeze();

                        foreach (Channel_8_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_8_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }

                        foreach (Channel_8_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_8_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }
                    }
                }
                catch (Exception) { }
                NotifyPropertyChanged("Remote_CH_8_Color");
            }
        }

        private bool Remote_CH_9_Node_Inserted_into_NodeList = false;
        private bool Remote_CH_9_Enable_ = false;
        public bool Remote_CH_9_Enable
        {
            get { return Remote_CH_9_Enable_; }
            set
            {
                Remote_CH_9_Enable_ = value;
                if (Remote_CH_9_Node_Inserted_into_NodeList == false)
                {
                    Remote_CH_9_Node_Inserted_into_NodeList = true;
                    Insert_Remote_Channel_Node_into_NodeList(9);
                }
                NotifyPropertyChanged("Remote_CH_9_Enable");
            }
        }

        private string Remote_CH_9_GetCounter_URL_ = "";
        public string Remote_CH_9_GetCounter_URL
        {
            get { return Remote_CH_9_GetCounter_URL_; }
            set
            {
                Remote_CH_9_GetCounter_URL_ = value;
                NotifyPropertyChanged("Remote_CH_9_GetCounter_URL");
            }
        }

        private string Remote_CH_9_Counter_String = "";
        private int Remote_CH_9_Counter_ = 0;
        public int Remote_CH_9_Counter
        {
            get { return Remote_CH_9_Counter_; }
            set
            {
                Remote_CH_9_Counter_ = value;
                NotifyPropertyChanged("Remote_CH_9_Counter");
            }
        }

        private string Remote_CH_9_GetWaveform_URL_ = "";
        public string Remote_CH_9_GetWaveform_URL
        {
            get { return Remote_CH_9_GetWaveform_URL_; }
            set
            {
                Remote_CH_9_GetWaveform_URL_ = value;
                NotifyPropertyChanged("Remote_CH_9_GetWaveform_URL");
            }
        }

        private string Remote_CH_9_Name_ = "RChannel 9";
        public string Remote_CH_9_Name
        {
            get { return Remote_CH_9_Name_; }
            set
            {
                Remote_CH_9_Name_ = value;
                if (Remote_CH_9_Enable)
                {
                    try
                    {
                        foreach (Channel_9_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_9_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                        foreach (Channel_9_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_9_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                    }
                    catch (Exception) { }
                }
                NotifyPropertyChanged("Remote_CH_9_Name");
            }
        }

        private string Remote_CH_9_Color_ = "#FF9400D3";
        public string Remote_CH_9_Color
        {
            get { return Remote_CH_9_Color_; }
            set
            {
                Remote_CH_9_Color_ = value;
                try
                {
                    if (Remote_CH_9_Enable)
                    {
                        Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                        BG_Color.Freeze();

                        foreach (Channel_9_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_9_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }

                        foreach (Channel_9_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_9_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }
                    }
                }
                catch (Exception) { }
                NotifyPropertyChanged("Remote_CH_9_Color");
            }
        }

        private bool Remote_CH_10_Node_Inserted_into_NodeList = false;
        private bool Remote_CH_10_Enable_ = false;
        public bool Remote_CH_10_Enable
        {
            get { return Remote_CH_10_Enable_; }
            set
            {
                Remote_CH_10_Enable_ = value;
                if (Remote_CH_10_Node_Inserted_into_NodeList == false)
                {
                    Remote_CH_10_Node_Inserted_into_NodeList = true;
                    Insert_Remote_Channel_Node_into_NodeList(10);
                }
                NotifyPropertyChanged("Remote_CH_10_Enable");
            }
        }

        private string Remote_CH_10_Counter_String = "";
        private int Remote_CH_10_Counter_ = 0;
        public int Remote_CH_10_Counter
        {
            get { return Remote_CH_10_Counter_; }
            set
            {
                Remote_CH_10_Counter_ = value;
                NotifyPropertyChanged("Remote_CH_10_Counter");
            }
        }

        private string Remote_CH_10_GetCounter_URL_ = "";
        public string Remote_CH_10_GetCounter_URL
        {
            get { return Remote_CH_10_GetCounter_URL_; }
            set
            {
                Remote_CH_10_GetCounter_URL_ = value;
                NotifyPropertyChanged("Remote_CH_10_GetCounter_URL");
            }
        }

        private string Remote_CH_10_GetWaveform_URL_ = "";
        public string Remote_CH_10_GetWaveform_URL
        {
            get { return Remote_CH_10_GetWaveform_URL_; }
            set
            {
                Remote_CH_10_GetWaveform_URL_ = value;
                NotifyPropertyChanged("Remote_CH_10_GetWaveform_URL");
            }
        }

        private string Remote_CH_10_Name_ = "RChannel 10";
        public string Remote_CH_10_Name
        {
            get { return Remote_CH_10_Name_; }
            set
            {
                Remote_CH_10_Name_ = value;
                if (Remote_CH_10_Enable)
                {
                    try
                    {
                        foreach (Channel_10_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_10_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                        foreach (Channel_10_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_10_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                    }
                    catch (Exception) { }
                }
                NotifyPropertyChanged("Remote_CH_10_Name");
            }
        }

        private string Remote_CH_10_Color_ = "#FF9400D3";
        public string Remote_CH_10_Color
        {
            get { return Remote_CH_10_Color_; }
            set
            {
                Remote_CH_10_Color_ = value;
                try
                {
                    if (Remote_CH_10_Enable)
                    {
                        Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                        BG_Color.Freeze();

                        foreach (Channel_10_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_10_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }

                        foreach (Channel_10_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_10_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }
                    }
                }
                catch (Exception) { }
                NotifyPropertyChanged("Remote_CH_10_Color");
            }
        }

        private bool Remote_CH_11_Node_Inserted_into_NodeList = false;
        private bool Remote_CH_11_Enable_ = false;
        public bool Remote_CH_11_Enable
        {
            get { return Remote_CH_11_Enable_; }
            set
            {
                Remote_CH_11_Enable_ = value;
                if (Remote_CH_11_Node_Inserted_into_NodeList == false)
                {
                    Remote_CH_11_Node_Inserted_into_NodeList = true;
                    Insert_Remote_Channel_Node_into_NodeList(11);
                }
                NotifyPropertyChanged("Remote_CH_11_Enable");
            }
        }

        private string Remote_CH_11_Counter_String = "";
        private int Remote_CH_11_Counter_ = 0;
        public int Remote_CH_11_Counter
        {
            get { return Remote_CH_11_Counter_; }
            set
            {
                Remote_CH_11_Counter_ = value;
                NotifyPropertyChanged("Remote_CH_11_Counter");
            }
        }

        private string Remote_CH_11_GetCounter_URL_ = "";
        public string Remote_CH_11_GetCounter_URL
        {
            get { return Remote_CH_11_GetCounter_URL_; }
            set
            {
                Remote_CH_11_GetCounter_URL_ = value;
                NotifyPropertyChanged("Remote_CH_11_GetCounter_URL");
            }
        }

        private string Remote_CH_11_GetWaveform_URL_ = "";
        public string Remote_CH_11_GetWaveform_URL
        {
            get { return Remote_CH_11_GetWaveform_URL_; }
            set
            {
                Remote_CH_11_GetWaveform_URL_ = value;
                NotifyPropertyChanged("Remote_CH_11_GetWaveform_URL");
            }
        }

        private string Remote_CH_11_Name_ = "RChannel 11";
        public string Remote_CH_11_Name
        {
            get { return Remote_CH_11_Name_; }
            set
            {
                Remote_CH_11_Name_ = value;
                if (Remote_CH_11_Enable)
                {
                    try
                    {
                        foreach (Channel_11_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_11_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                        foreach (Channel_11_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_11_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                    }
                    catch (Exception) { }
                }
                NotifyPropertyChanged("Remote_CH_11_Name");
            }
        }

        private string Remote_CH_11_Color_ = "#FF9400D3";
        public string Remote_CH_11_Color
        {
            get { return Remote_CH_11_Color_; }
            set
            {
                Remote_CH_11_Color_ = value;
                try
                {
                    if (Remote_CH_11_Enable)
                    {
                        Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                        BG_Color.Freeze();

                        foreach (Channel_11_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_11_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }

                        foreach (Channel_11_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_11_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }
                    }
                }
                catch (Exception) { }
                NotifyPropertyChanged("Remote_CH_11_Color");
            }
        }

        private bool Remote_CH_12_Node_Inserted_into_NodeList = false;
        private bool Remote_CH_12_Enable_ = false;
        public bool Remote_CH_12_Enable
        {
            get { return Remote_CH_12_Enable_; }
            set
            {
                Remote_CH_12_Enable_ = value;
                if (Remote_CH_12_Node_Inserted_into_NodeList == false)
                {
                    Remote_CH_12_Node_Inserted_into_NodeList = true;
                    Insert_Remote_Channel_Node_into_NodeList(12);
                }
                NotifyPropertyChanged("Remote_CH_12_Enable");
            }
        }

        private string Remote_CH_12_Counter_String = "";
        private int Remote_CH_12_Counter_ = 0;
        public int Remote_CH_12_Counter
        {
            get { return Remote_CH_12_Counter_; }
            set
            {
                Remote_CH_12_Counter_ = value;
                NotifyPropertyChanged("Remote_CH_12_Counter");
            }
        }

        private string Remote_CH_12_GetCounter_URL_ = "";
        public string Remote_CH_12_GetCounter_URL
        {
            get { return Remote_CH_12_GetCounter_URL_; }
            set
            {
                Remote_CH_12_GetCounter_URL_ = value;
                NotifyPropertyChanged("Remote_CH_12_GetCounter_URL");
            }
        }

        private string Remote_CH_12_GetWaveform_URL_ = "";
        public string Remote_CH_12_GetWaveform_URL
        {
            get { return Remote_CH_12_GetWaveform_URL_; }
            set
            {
                Remote_CH_12_GetWaveform_URL_ = value;
                NotifyPropertyChanged("Remote_CH_12_GetWaveform_URL");
            }
        }

        private string Remote_CH_12_Name_ = "RChannel 12";
        public string Remote_CH_12_Name
        {
            get { return Remote_CH_12_Name_; }
            set
            {
                Remote_CH_12_Name_ = value;
                if (Remote_CH_12_Enable)
                {
                    try
                    {
                        foreach (Channel_12_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_12_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                        foreach (Channel_12_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_12_Node_ViewModel))
                        {
                            Node.Name = value;
                        }
                    }
                    catch (Exception) { }
                }
                NotifyPropertyChanged("Remote_CH_12_Name");
            }
        }

        private string Remote_CH_12_Color_ = "#FF9400D3";
        public string Remote_CH_12_Color
        {
            get { return Remote_CH_12_Color_; }
            set
            {
                Remote_CH_12_Color_ = value;
                try
                {
                    if (Remote_CH_12_Enable)
                    {
                        Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
                        BG_Color.Freeze();

                        foreach (Channel_12_Node_ViewModel Node in NodeNetwork_Editor.Nodes.Items.Where(Nodes => Nodes is Channel_12_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }

                        foreach (Channel_12_Node_ViewModel Node in ListViewModel.VisibleNodes.Items.Where(Nodes => Nodes is Channel_12_Node_ViewModel))
                        {
                            Node.Background_Color = BG_Color;
                        }
                    }
                }
                catch (Exception) { }
                NotifyPropertyChanged("Remote_CH_12_Color");
            }
        }
    }
}
