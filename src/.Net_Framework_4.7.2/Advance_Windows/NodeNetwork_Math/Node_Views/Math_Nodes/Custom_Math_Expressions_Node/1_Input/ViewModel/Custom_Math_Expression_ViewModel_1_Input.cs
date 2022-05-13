using Custom_Math_Expression_Class;
using DynamicData;
using Node_Model_Classes;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork_Math;
using NX_StarWave.Waveform_Model_Classes;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Media;

namespace Custom_Math_Expressions_Node
{
    public partial class Custom_Math_Expression_ViewModel_1_Input : Node_ViewModel
    {
        private int Input_1_Unique_Key = -1;

        public ValueNodeInputViewModel<Node_Waveform_Model> Input_1 { get; }

        public ValueNodeOutputViewModel<Node_Waveform_Model> Output { get; set; }

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

        private string Library_Speed_ = "Slow";
        public string Library_Speed
        {
            get => Library_Speed_;
            set => this.RaiseAndSetIfChanged(ref Library_Speed_, value);
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

        private Brush Status_Color_ = Brushes.LimeGreen;
        public Brush Status_Color
        {
            get => Status_Color_;
            set => this.RaiseAndSetIfChanged(ref Status_Color_, value);
        }

        private int Error_Count_Infinity_ = 0;
        public int Error_Count_Infinity
        {
            get => Error_Count_Infinity_;
            set => this.RaiseAndSetIfChanged(ref Error_Count_Infinity_, value);
        }

        private int Error_Count_NAN_ = 0;
        public int Error_Count_NAN
        {
            get => Error_Count_NAN_;
            set => this.RaiseAndSetIfChanged(ref Error_Count_NAN_, value);
        }

        private int Error_Count_Min_ = 0;
        public int Error_Count_Min
        {
            get => Error_Count_Min_;
            set => this.RaiseAndSetIfChanged(ref Error_Count_Min_, value);
        }

        private int Error_Count_Max_ = 0;
        public int Error_Count_Max
        {
            get => Error_Count_Max_;
            set => this.RaiseAndSetIfChanged(ref Error_Count_Max_, value);
        }

        private string Math_Expression_string_;
        public string Math_Expression_string
        {
            get => Math_Expression_string_;
            set => this.RaiseAndSetIfChanged(ref Math_Expression_string_, value);
        }

        private string Output_string_ = "Output";
        public string Output_string
        {
            get => Output_string_;
            set => this.RaiseAndSetIfChanged(ref Output_string_, value);
        }

        private string Input_1_string_ = "x1";
        public string Input_1_string
        {
            get => Input_1_string_;
            set => this.RaiseAndSetIfChanged(ref Input_1_string_, value);
        }

        private System.Windows.Visibility Node_Config_Options_Visibility_ = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility Node_Config_Options_Visibility
        {
            get => Node_Config_Options_Visibility_;
            set => this.RaiseAndSetIfChanged(ref Node_Config_Options_Visibility_, value);
        }

        private NodeNetwork_Window NodeNetwork_MainWindow { get; set; }

        private Custom_Math_Expression_Parse Math_Expression_Parse { get; set; }

        public Custom_Math_Expression_ViewModel_1_Input(object Parent_Window, string Name, bool IsCollapsed, NodeCategory Category, string Background_Color, string Foreground_Color, string Units, string Library_Type, string Math_Expression, string Output_Name = "Output", string Input_1_Name = "x1")
        {
            NodeNetwork_MainWindow = Parent_Window as NodeNetwork_Window;

            this.Node_Name = Name;
            this.Category = Category;
            this.Units = Units;
            this.IsCollapsed = IsCollapsed;
            this.Math_Expression_string = Math_Expression;
            this.Output_string = Output_Name;
            this.Input_1_string = Input_1_Name;

            if (Library_Type.Equals("Slow"))
            {
                Math_Expression_Parse = new mXparser_Expression_Parser(Math_Expression, Output_Name, Input_1_Name);
            }
            else
            {
                Math_Expression_Parse = new MathNET_Symbolics_Expression_Parser(Math_Expression, Output_Name, Input_1_Name);
                Library_Speed = "Fast";
            }

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

            Output = new ValueNodeOutputViewModel<Node_Waveform_Model>()
            {
                Name = Output_Name,
                Value = this.WhenAnyValue(vm => vm.Input_1.Value).Select(value => value != null ? Input_Verification(value) : Return_Old_Output())
            };
            this.Outputs.Add(Output);

            Show_Config_Options_Command = ReactiveCommand.Create(() => { Show_Config_Options(); });
            Open_YT_Graph_Window_Command = ReactiveCommand.Create(() => { Open_YT_Graph_Window(); });
            Open_Histogram_Graph_Window_Command = ReactiveCommand.Create(() => { Open_Histogram_Graph_Window(); });
            Open_FFT_Graph_Window_Command = ReactiveCommand.Create(() => { Open_FFT_Graph_Window(); });
        }

        private Node_Waveform_Model Input_Verification(Node_Waveform_Model Input_1)
        {

            if (Input_1.Unique_ID != Input_1_Unique_Key)
            {
                Input_1_Unique_Key = Input_1.Unique_ID;
                return Perform_Math_Operation(Input_1);
            }
            else if (NodeEditor_Global_Config.Update_When_Some_Inputs_Update == true)
            {
                if (Input_1.Unique_ID != Input_1_Unique_Key)
                {
                    Input_1_Unique_Key = Input_1.Unique_ID;
                    return Perform_Math_Operation(Input_1);
                }
                else
                {
                    return Return_Old_Output();
                }
            }
            else
            {
                return Return_Old_Output();
            }
        }

        private Node_Waveform_Model Perform_Math_Operation(Node_Waveform_Model Input_1)
        {
            (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) = Math_Expression_Parse.Compute_Expression(Input_1);

            Error_Count_Infinity = Infinity_Count;
            Error_Count_NAN = NAN_Count;
            Error_Count_Max = Max_Count;
            Error_Count_Min = Min_Count;

            if (isValid)
            {
                return Final_Results(Input_1, Results);
            }
            else
            {
                NodeNetwork_MainWindow.Insert_Log(Message, 1);
                Set_Status_Color(Status_Colors.Math_Operation_Failed);
                return null;
            }
        }

        private Node_Waveform_Model Final_Results(Node_Waveform_Model Input_1, double[] Results)
        {
            Set_Status_Color_if_Error();
            Node_Waveform_Model Waveform_Data = new Node_Waveform_Model(Input_1.Unique_ID, Input_1.Data_points, Input_1.Total_Time, Input_1.Start_Time, Input_1.Stop_Time, Input_1.X_Values, Results, Units);
            Insert_New_Results_into_Graph(Waveform_Data);
            return Waveform_Data;
        }

        private Node_Waveform_Model Return_Old_Output()
        {
            if (Output != null)
            {
                if (Output.CurrentValue != null)
                {
                    return Output.CurrentValue;
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

        private Channel_Waveform_Data Return_Current_Waveform_Data()
        {
            if (Output != null)
            {
                if (Output.CurrentValue != null)
                {
                    return new Channel_Waveform_Data(true, Output.CurrentValue.X_Values, Output.CurrentValue.Y_Values, Output.CurrentValue.Total_Time, Output.CurrentValue.Start_Time, Output.CurrentValue.Stop_Time, Output.CurrentValue.Data_points, Output.CurrentValue.Units);
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

        private void Set_Status_Color_if_Error()
        {
            if (Error_Count_NAN > 0 || Error_Count_Infinity > 0 || Error_Count_Max > 0 || Error_Count_Min > 0)
            {
                Set_Status_Color(Status_Colors.Error);
            }
            else
            {
                Set_Status_Color(Status_Colors.Success);
            }
        }

        private void Set_Status_Color(Status_Colors Status_Code)
        {
            switch (Status_Code)
            {
                case (Status_Colors)0:
                    Status_Color = Brushes.LimeGreen;
                    break;
                case (Status_Colors)1:
                    Status_Color = Brushes.Orange;
                    break;
                case (Status_Colors)2:
                    Status_Color = Brushes.Red;
                    break;
                case (Status_Colors)3:
                    Status_Color = Brushes.Yellow;
                    break;
                default:
                    Status_Color = Brushes.Black;
                    break;
            }
        }

        static Custom_Math_Expression_ViewModel_1_Input()
        {
            Splat.Locator.CurrentMutable.Register(() => new Custom_Math_Expression_View_1_Input(), typeof(IViewFor<Custom_Math_Expression_ViewModel_1_Input>));
        }
    }
}
