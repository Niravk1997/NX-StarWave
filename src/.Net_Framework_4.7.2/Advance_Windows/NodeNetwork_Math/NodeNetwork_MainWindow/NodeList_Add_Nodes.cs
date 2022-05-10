using Basic_Math_Node;
using Basic_ValueMath_Node;
using Basic_Waveform_Shift_Node;
using Create_Custom_Math_Expression_Node;
using Custom_Math_Expressions_Node;
using FFT_Node;
using Histogram_Node;
using MahApps.Metro.Controls;
using Oscilloscope_Channel_Node;
using System;
using System.Windows.Threading;
using YT_Node;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        private void Add_Nodes_to_NodeList()
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                ListViewModel.AddNodeType(() => new Channel_1_Node_ViewModel(this, "Channel 1", true, NodeCategory.Oscilloscope_Channels, CH1_Color_string, "#FFFFFF"));
                ListViewModel.AddNodeType(() => new Channel_2_Node_ViewModel(this, "Channel 2", true, NodeCategory.Oscilloscope_Channels, CH2_Color_string, "#FFFFFF"));
                ListViewModel.AddNodeType(() => new Channel_3_Node_ViewModel(this, "Channel 3", true, NodeCategory.Oscilloscope_Channels, CH3_Color_string, "#FFFFFF"));
                ListViewModel.AddNodeType(() => new Channel_4_Node_ViewModel(this, "Channel 4", true, NodeCategory.Oscilloscope_Channels, CH4_Color_string, "#FFFFFF"));

                ListViewModel.AddNodeType(() => new Basic_Math_ViewModel(this, "Basic Math Node", true, NodeCategory.Basic_Math, Basic_Math_Type.Addition, "#FF00B7F4", "#FFFFFF", "V"));
                ListViewModel.AddNodeType(() => new Basic_Math_ViewModel(this, "Basic Math Node", true, NodeCategory.Basic_Math, Basic_Math_Type.Subtraction, "#FF00B7F4", "#FFFFFF", "V"));
                ListViewModel.AddNodeType(() => new Basic_Math_ViewModel(this, "Basic Math Node", true, NodeCategory.Basic_Math, Basic_Math_Type.Multiplication, "#FF00B7F4", "#FFFFFF", "V"));
                ListViewModel.AddNodeType(() => new Basic_Math_ViewModel(this, "Basic Math Node", true, NodeCategory.Basic_Math, Basic_Math_Type.Division, "#FF00B7F4", "#FFFFFF", "V"));
                ListViewModel.AddNodeType(() => new Basic_ValueMath_ViewModel(this, "X1 + Value", true, NodeCategory.Basic_Math, 0, 0, "#FF00B7F4", "#FFFFFF", "V"));
                ListViewModel.AddNodeType(() => new Basic_Waveform_Shift_ViewModel(this, "Waveform Shift", true, NodeCategory.Basic_Math, 0, 0, "#FF00B7F4", "#FFFFFF", "V"));

                ListViewModel.AddNodeType(() => new YT_Inputs_1_ViewModel(this, "1 Input", true, NodeCategory.YT_Graphs, "#FF7B68EE", "#FFFFFF", "V", "Input 1", "#0072BD"));

                ListViewModel.AddNodeType(() => new FFT_Inputs_1_ViewModel(this, "1 Input", true, NodeCategory.FFT_Graphs, "#FF7B68EE", "#FFFFFF", "V", "Input 1", "#0072BD"));

                ListViewModel.AddNodeType(() => new Histogram_Inputs_1_ViewModel(this, "1 Input", true, NodeCategory.Histogram_Graphs, "#FF7B68EE", "#FFFFFF", "V", "Input 1", "#0072BD", 50));
                ListViewModel.AddNodeType(() => new Histogram_Inputs_2_ViewModel(this, "2 Inputs", true, NodeCategory.Histogram_Graphs, "#FF7B68EE", "#FFFFFF", "V", "Input 1", "#6E00C9FF", 50, "Input 2", "#6F00FF1A", 50));
            }));
        }

        public void Add_Custom_Math_Expression_Node_depending_on_Total_Inputs(Custom_Math_Expression_Node_Data Custom_Math_Expression_Node)
        {
            switch (Custom_Math_Expression_Node.Total_Inputs)
            {
                case 0:
                    ListViewModel.AddNodeType(() => new Custom_Math_Expression_ViewModel_1_Input(this, Custom_Math_Expression_Node.Expression_Name, true, (NodeCategory)Custom_Math_Expression_Node.Category, Custom_Math_Expression_Node.Background, Custom_Math_Expression_Node.Foreground, Custom_Math_Expression_Node.Units, Custom_Math_Expression_Node.Expression, Custom_Math_Expression_Node.Output, Custom_Math_Expression_Node.X1));
                    break;
                case 1:
                    ListViewModel.AddNodeType(() => new Custom_Math_Expression_ViewModel_2_Input(this, Custom_Math_Expression_Node.Expression_Name, true, (NodeCategory)Custom_Math_Expression_Node.Category, Custom_Math_Expression_Node.Background, Custom_Math_Expression_Node.Foreground, Custom_Math_Expression_Node.Units, Custom_Math_Expression_Node.Expression, Custom_Math_Expression_Node.Output, Custom_Math_Expression_Node.X1, Custom_Math_Expression_Node.X2));
                    break;
                case 2:
                    ListViewModel.AddNodeType(() => new Custom_Math_Expression_ViewModel_3_Input(this, Custom_Math_Expression_Node.Expression_Name, true, (NodeCategory)Custom_Math_Expression_Node.Category, Custom_Math_Expression_Node.Background, Custom_Math_Expression_Node.Foreground, Custom_Math_Expression_Node.Units, Custom_Math_Expression_Node.Expression, Custom_Math_Expression_Node.Output, Custom_Math_Expression_Node.X1, Custom_Math_Expression_Node.X2, Custom_Math_Expression_Node.X3));
                    break;
                case 3:
                    ListViewModel.AddNodeType(() => new Custom_Math_Expression_ViewModel_4_Input(this, Custom_Math_Expression_Node.Expression_Name, true, (NodeCategory)Custom_Math_Expression_Node.Category, Custom_Math_Expression_Node.Background, Custom_Math_Expression_Node.Foreground, Custom_Math_Expression_Node.Units, Custom_Math_Expression_Node.Expression, Custom_Math_Expression_Node.Output, Custom_Math_Expression_Node.X1, Custom_Math_Expression_Node.X2, Custom_Math_Expression_Node.X3, Custom_Math_Expression_Node.X4));
                    break;
                case 4:
                    ListViewModel.AddNodeType(() => new Custom_Math_Expression_ViewModel_5_Input(this, Custom_Math_Expression_Node.Expression_Name, true, (NodeCategory)Custom_Math_Expression_Node.Category, Custom_Math_Expression_Node.Background, Custom_Math_Expression_Node.Foreground, Custom_Math_Expression_Node.Units, Custom_Math_Expression_Node.Expression, Custom_Math_Expression_Node.Output, Custom_Math_Expression_Node.X1, Custom_Math_Expression_Node.X2, Custom_Math_Expression_Node.X3, Custom_Math_Expression_Node.X4, Custom_Math_Expression_Node.X5));
                    break;
                case 5:
                    ListViewModel.AddNodeType(() => new Custom_Math_Expression_ViewModel_6_Input(this, Custom_Math_Expression_Node.Expression_Name, true, (NodeCategory)Custom_Math_Expression_Node.Category, Custom_Math_Expression_Node.Background, Custom_Math_Expression_Node.Foreground, Custom_Math_Expression_Node.Units, Custom_Math_Expression_Node.Expression, Custom_Math_Expression_Node.Output, Custom_Math_Expression_Node.X1, Custom_Math_Expression_Node.X2, Custom_Math_Expression_Node.X3, Custom_Math_Expression_Node.X4, Custom_Math_Expression_Node.X5, Custom_Math_Expression_Node.X6));
                    break;
                case 6:
                    ListViewModel.AddNodeType(() => new Custom_Math_Expression_ViewModel_7_Input(this, Custom_Math_Expression_Node.Expression_Name, true, (NodeCategory)Custom_Math_Expression_Node.Category, Custom_Math_Expression_Node.Background, Custom_Math_Expression_Node.Foreground, Custom_Math_Expression_Node.Units, Custom_Math_Expression_Node.Expression, Custom_Math_Expression_Node.Output, Custom_Math_Expression_Node.X1, Custom_Math_Expression_Node.X2, Custom_Math_Expression_Node.X3, Custom_Math_Expression_Node.X4, Custom_Math_Expression_Node.X5, Custom_Math_Expression_Node.X6, Custom_Math_Expression_Node.X7));
                    break;
                default:
                    Insert_Log("Something went wrong...", 1);
                    break;
            }
        }
    }
}
