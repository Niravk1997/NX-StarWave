using Axis_Scale_Config;
using DynamicData;
using Node_Model_Classes;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork_Math;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Media;

namespace Oscilloscope_Channel_Node
{
    public class Channel_5_Node_ViewModel : Node_ViewModel
    {
        public ValueNodeOutputViewModel<Node_Waveform_Model> Output { get; set; }

        public static ValueEditorViewModel<Node_Waveform_Model> Waveform_Data_Insert { get; set; } = new ValueEditorViewModel<Node_Waveform_Model>();

        private Brush Background_Color_;
        public Brush Background_Color
        {
            get => Background_Color_;
            set => this.RaiseAndSetIfChanged(ref Background_Color_, value);
        }

        private Brush Foreground_Color_;
        public Brush Foreground_Color
        {
            get => Foreground_Color_;
            set => this.RaiseAndSetIfChanged(ref Foreground_Color_, value);
        }

        private string Data_Points_String_ = "0";
        public string Data_Points_String
        {
            get => Data_Points_String_;
            set => this.RaiseAndSetIfChanged(ref Data_Points_String_, value);
        }

        private string Total_Time_String_ = "0";
        public string Total_Time_String
        {
            get => Total_Time_String_;
            set => this.RaiseAndSetIfChanged(ref Total_Time_String_, value);
        }

        private string Start_Time_String_ = "0";
        public string Start_Time_String
        {
            get => Start_Time_String_;
            set => this.RaiseAndSetIfChanged(ref Start_Time_String_, value);
        }

        private string Stop_Time_String_ = "0";
        public string Stop_Time_String
        {
            get => Stop_Time_String_;
            set => this.RaiseAndSetIfChanged(ref Stop_Time_String_, value);
        }

        private Axis_Config Axis_Config = new Axis_Config();

        private NodeNetwork_Window NodeNetwork_MainWindow { get; set; }

        public Channel_5_Node_ViewModel(object Parent_Window, string Name, bool IsCollapsed, NodeCategory Category, string Background_Color, string Foreground_Color)
        {
            NodeNetwork_MainWindow = Parent_Window as NodeNetwork_Window;

            this.Name = Name;
            this.Category = Category;
            this.IsCollapsed = IsCollapsed;

            Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(Background_Color);
            BG_Color.Freeze();
            this.Background_Color = BG_Color;

            Brush FG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(Foreground_Color);
            FG_Color.Freeze();
            this.Foreground_Color = FG_Color;

            Output = new ValueNodeOutputViewModel<Node_Waveform_Model>()
            {
                Name = "Output",
                Value = Waveform_Data_Insert.ValueChanged.Select(value => Waveform_Data_Insert.Value != null ? Waveform_Data_Process(Waveform_Data_Insert.Value) : null)
            };
            this.Outputs.Add(Output);
        }

        private Node_Waveform_Model Waveform_Data_Process(Node_Waveform_Model Waveform)
        {
            Data_Points_String = Waveform.Data_points.ToString();
            Total_Time_String = Axis_Config.Value_SI_Prefix(Waveform.Total_Time, 4) + "s";
            Start_Time_String = Axis_Config.Value_SI_Prefix(Waveform.Start_Time, 4) + "s";
            Stop_Time_String = Axis_Config.Value_SI_Prefix(Waveform.Stop_Time, 4) + "s";
            return Waveform;
        }

        static Channel_5_Node_ViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new Channel_5_Node_View(), typeof(IViewFor<Channel_5_Node_ViewModel>));
        }
    }
}
