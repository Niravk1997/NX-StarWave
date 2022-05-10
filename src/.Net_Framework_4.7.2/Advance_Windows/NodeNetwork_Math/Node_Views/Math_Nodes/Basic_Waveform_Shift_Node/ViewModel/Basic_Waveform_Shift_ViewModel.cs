using DynamicData;
using Node_Model_Classes;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork_Math;
using NX_StarWave.Waveform_Model_Classes;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Media;

namespace Basic_Waveform_Shift_Node
{
    public partial class Basic_Waveform_Shift_ViewModel : Node_ViewModel
    {
        private int Input_1_Unique_Key = -1;

        public ValueNodeInputViewModel<Node_Waveform_Model> Input_1 { get; }
        public ValueNodeOutputViewModel<Node_Waveform_Model> Output { get; set; }

        private int Shift_Value_ = 0;
        public int Shift_Value
        {
            get => Shift_Value_;
            set
            {
                this.RaiseAndSetIfChanged(ref Shift_Value_, value);
                Set_Node_Title();
            }
        }

        private int Direction_ = 0;
        public int Direction
        {
            get => Direction_;
            set
            {
                this.RaiseAndSetIfChanged(ref Direction_, value);
                Set_Node_Title();
            }
        }

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

        private Visibility Node_Config_Options_Visibility_ = Visibility.Collapsed;
        public Visibility Node_Config_Options_Visibility
        {
            get => Node_Config_Options_Visibility_;
            set => this.RaiseAndSetIfChanged(ref Node_Config_Options_Visibility_, value);
        }

        private NodeNetwork_Window NodeNetwork_MainWindow { get; set; }

        public Basic_Waveform_Shift_ViewModel(object Parent_Window, string Name, bool IsCollapsed, NodeCategory Category, int Direction, int Shift_Value, string Background_Color, string Foreground_Color, string Units)
        {
            NodeNetwork_MainWindow = Parent_Window as NodeNetwork_Window;

            this.Name = Name;
            this.Category = Category;
            this.Direction = Direction;
            this.Shift_Value = Shift_Value;
            this.Units = Units;
            this.IsCollapsed = IsCollapsed;

            Brush BG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(Background_Color);
            BG_Color.Freeze();
            this.Background_Color = BG_Color;

            Brush FG_Color = (SolidColorBrush)new BrushConverter().ConvertFromString(Foreground_Color);
            FG_Color.Freeze();
            this.Foreground_Color = FG_Color;

            Input_1 = new ValueNodeInputViewModel<Node_Waveform_Model>()
            {
                Name = "X1"
            };
            this.Inputs.Add(Input_1);

            Output = new ValueNodeOutputViewModel<Node_Waveform_Model>()
            {
                Name = "Output",
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
            else
            {
                return Return_Old_Output();
            }

        }

        private Node_Waveform_Model Perform_Math_Operation(Node_Waveform_Model Input_1)
        {
            Reset_Error_Counters();
            double[] Results = new double[Input_1.Data_points];
            int Difference = Shift_Value % Input_1.Data_points;
            try
            {
                switch (Direction)
                {
                    case 0:
                        // Right
                        Array.Copy(Input_1.Y_Values, 0, Results, Difference, Input_1.Data_points - Difference);
                        Array.Copy(Input_1.Y_Values, Input_1.Data_points - Difference, Results, 0, Difference);
                        return Final_Results(Input_1, Results);
                    case 1:
                        // Left
                        Array.Copy(Input_1.Y_Values, Difference, Results, 0, Input_1.Data_points - Difference);
                        Array.Copy(Input_1.Y_Values, 0, Results, Input_1.Data_points - Difference, Difference);
                        return Final_Results(Input_1, Results);
                    default:
                        return null;
                }
            }
            catch (Exception)
            {
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

        private void Reset_Error_Counters()
        {
            Error_Count_NAN = 0;
            Error_Count_Infinity = 0;
            Error_Count_Min = 0;
            Error_Count_Max = 0;
        }

        private double Set_Error_Results_Zero(double Value)
        {
            if (double.IsNaN(Value))
            {
                Error_Count_NAN++;
                return 0;
            }
            else if (double.IsInfinity(Value))
            {
                Error_Count_Infinity++;
                return 0;
            }
            else if (Value >= NodeEditor_Global_Config.Max_Value_Allowed)
            {
                Error_Count_Max++;
                return 0;
            }
            else if (Value <= NodeEditor_Global_Config.Min_Value_Allowed)
            {
                Error_Count_Min++;
                return 0;
            }
            else
            {
                return Value;
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

        private void Set_Node_Title()
        {
            if (Direction == 0)
            {
                Node_Name = $"Shift Right by {Shift_Value}";
            }
            else
            {
                Node_Name = $"Shift Left by {Shift_Value}";
            }
        }

        static Basic_Waveform_Shift_ViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new Basic_Node_View(), typeof(IViewFor<Basic_Waveform_Shift_ViewModel>));
        }
    }
}
