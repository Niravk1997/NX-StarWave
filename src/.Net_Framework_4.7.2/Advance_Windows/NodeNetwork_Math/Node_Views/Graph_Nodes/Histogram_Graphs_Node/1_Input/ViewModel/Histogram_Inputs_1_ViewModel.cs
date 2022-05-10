using DynamicData;
using Node_Model_Classes;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork_Math;
using NX_StarWave.Waveform_Model_Classes;
using ReactiveUI;
using System;
using System.Reactive.Linq;
using System.Windows.Media;

namespace Histogram_Node
{
    public partial class Histogram_Inputs_1_ViewModel : Node_ViewModel
    {
        private int Input_1_Unique_Key = -1;

        public ValueNodeInputViewModel<Node_Waveform_Model> Input_1 { get; }

        private string Node_Name_ = "";
        public string Node_Name
        {
            get => Node_Name_;
            set
            {
                this.RaiseAndSetIfChanged(ref Node_Name_, value);
                this.Name = value;
            }
        }

        private string Units_ = "";
        public string Units
        {
            get => Units_;
            set => this.RaiseAndSetIfChanged(ref Units_, value);
        }

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

        private string Input_1_string_ = "Input 1";
        public string Input_1_string
        {
            get => Input_1_string_;
            set
            {
                this.RaiseAndSetIfChanged(ref Input_1_string_, value);
                if (Input_1 != null)
                {
                    this.Input_1.Name = value;
                }
            }
        }

        private int Input_1_Bucket_Count_ = 50;
        public int Input_1_Bucket_Count
        {
            get => Input_1_Bucket_Count_;
            set => this.RaiseAndSetIfChanged(ref Input_1_Bucket_Count_, value);
        }

        private string Input_1_Color_ = "#0072BD";
        public string Input_1_Color
        {
            get => Input_1_Color_;
            set => this.RaiseAndSetIfChanged(ref Input_1_Color_, value);
        }

        private System.Windows.Visibility Node_Config_Options_Visibility_ = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility Node_Config_Options_Visibility
        {
            get => Node_Config_Options_Visibility_;
            set => this.RaiseAndSetIfChanged(ref Node_Config_Options_Visibility_, value);
        }

        private NodeNetwork_Window NodeNetwork_MainWindow { get; set; }

        public Histogram_Inputs_1_ViewModel(object Parent_Window, string Name, bool IsCollapsed, NodeCategory Category, string Background_Color, string Foreground_Color, string Units, string Input_1_Name = "Input 1", string Input_1_Color = "#0072BD", int Input_1_Bucket_Count = 50)
        {
            NodeNetwork_MainWindow = Parent_Window as NodeNetwork_Window;

            this.Node_Name = Name;
            this.Category = Category;
            this.Units = Units;
            this.IsCollapsed = IsCollapsed;
            this.Input_1_string = Input_1_Name;
            this.Input_1_Color = Input_1_Color;
            this.Input_1_Bucket_Count = Input_1_Bucket_Count;

            Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(Background_Color);
            BG_Color.Freeze();
            this.Background_Color = BG_Color;

            Brush FG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(Foreground_Color);
            FG_Color.Freeze();
            this.Foreground_Color = FG_Color;

            Input_1 = new ValueNodeInputViewModel<Node_Waveform_Model>()
            {
                Name = Input_1_Name
            };
            this.Inputs.Add(Input_1);

            this.WhenAnyValue(vm => vm.Input_1.Value).Subscribe(value => { if (value != null) { Output_to_Histogram(value); } });

            Show_Config_Options_Command = ReactiveCommand.Create(() => { Show_Config_Options(); });
            Open_Histogram_Graph_Window_Command = ReactiveCommand.Create(() => { Open_Histogram_Graph_Window(); });
        }

        private void Output_to_Histogram(Node_Waveform_Model Input_1)
        {
            if (Input_1.Unique_ID != Input_1_Unique_Key)
            {
                Input_1_Unique_Key = Input_1.Unique_ID;
                Insert_New_Results_into_Graph(Input_1);
            }
        }

        private Channel_Waveform_Data Return_Current_Waveform_Data()
        {
            if (Input_1 != null)
            {
                if (Input_1.Value != null)
                {
                    return new Channel_Waveform_Data(true, Input_1.Value.X_Values, Input_1.Value.Y_Values, Input_1.Value.Total_Time, Input_1.Value.Start_Time, Input_1.Value.Stop_Time, Input_1.Value.Data_points, Input_1.Value.Units);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        static Histogram_Inputs_1_ViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new Histogram_Inputs_1_View(), typeof(IViewFor<Histogram_Inputs_1_ViewModel>));
        }
    }
}
