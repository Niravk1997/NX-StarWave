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

namespace Basic_Math_Node
{
    public partial class Basic_Math_ViewModel : Node_ViewModel
    {
        private int Input_1_Unique_Key = -1;
        private int Input_2_Unique_Key = -1;

        public ValueNodeInputViewModel<Node_Waveform_Model> Input_1 { get; }
        public ValueNodeInputViewModel<Node_Waveform_Model> Input_2 { get; }
        public ValueNodeOutputViewModel<Node_Waveform_Model> Output { get; set; }

        public int Math_Type;

        private int Primary_Input_ = 1;
        public int Primary_Input
        {
            get => Primary_Input_;
            set => this.RaiseAndSetIfChanged(ref Primary_Input_, value);
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

        public Basic_Math_ViewModel(object Parent_Window, string Name, bool IsCollapsed, NodeCategory Category, Basic_Math_Type Math_Type, string Background_Color, string Foreground_Color, string Units)
        {
            NodeNetwork_MainWindow = Parent_Window as NodeNetwork_Window;

            this.Name = Node_Name = Set_Name(Math_Type);
            this.Category = Category;
            this.Math_Type = (int)Math_Type;
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

            Input_2 = new ValueNodeInputViewModel<Node_Waveform_Model>()
            {
                Name = "X2"
            };
            this.Inputs.Add(Input_2);

            Output = new ValueNodeOutputViewModel<Node_Waveform_Model>()
            {
                Name = "Output",
                Value = this.WhenAnyValue(vm => vm.Input_1.Value, vm => vm.Input_2.Value).Select(value => value.Item1 != null && value.Item2 != null ? Input_Verification(value.Item1, value.Item2) : Return_Old_Output())
            };
            this.Outputs.Add(Output);

            Show_Config_Options_Command = ReactiveCommand.Create(() => { Show_Config_Options(); });
            Open_YT_Graph_Window_Command = ReactiveCommand.Create(() => { Open_YT_Graph_Window(); });
            Open_Histogram_Graph_Window_Command = ReactiveCommand.Create(() => { Open_Histogram_Graph_Window(); });
            Open_FFT_Graph_Window_Command = ReactiveCommand.Create(() => { Open_FFT_Graph_Window(); });
        }

        private Node_Waveform_Model Input_Verification(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2)
        {
            if (Input_1.Data_points == Input_2.Data_points && Input_1.Total_Time == Input_2.Total_Time)
            {
                if (Input_1.Unique_ID != Input_1_Unique_Key && Input_2.Unique_ID != Input_2_Unique_Key)
                {
                    Input_1_Unique_Key = Input_1.Unique_ID;
                    Input_2_Unique_Key = Input_2.Unique_ID;
                    return Perform_Math_Operation(Input_1, Input_2);
                }
                else if (NodeEditor_Global_Config.Update_When_Some_Inputs_Update == true)
                {
                    if (Input_1.Unique_ID != Input_1_Unique_Key)
                    {
                        Input_1_Unique_Key = Input_1.Unique_ID;
                        return Perform_Math_Operation(Input_1, Input_2);
                    }
                    else if (Input_2.Unique_ID != Input_2_Unique_Key)
                    {
                        Input_2_Unique_Key = Input_2.Unique_ID;
                        return Perform_Math_Operation(Input_1, Input_2);
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
            else
            {
                Set_Status_Color(Status_Colors.Data_Point_Total_Time_Mismatch);
                return Return_Old_Output();
            }
        }

        private Node_Waveform_Model Perform_Math_Operation(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2)
        {
            Reset_Error_Counters();
            double[] Results = new double[Input_1.Data_points];
            try
            {
                switch (Math_Type)
                {
                    case 0:
                        // Add
                        for (int i = 0; i < Input_1.Data_points; i++)
                        {
                            Results[i] = Input_1.Y_Values[i] + Input_2.Y_Values[i];
                            if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]) || Results[i] >= NodeEditor_Global_Config.Max_Value_Allowed || Results[i] <= NodeEditor_Global_Config.Min_Value_Allowed)
                            {
                                Results[i] = Set_Error_Results_Zero(Results[i]);
                            }
                        }
                        return Final_Results(Input_1, Input_2, Results);
                    case 1:
                        // Subtract
                        for (int i = 0; i < Input_1.Data_points; i++)
                        {
                            Results[i] = Input_1.Y_Values[i] - Input_2.Y_Values[i];
                            if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]) || Results[i] >= NodeEditor_Global_Config.Max_Value_Allowed || Results[i] <= NodeEditor_Global_Config.Min_Value_Allowed)
                            {
                                Results[i] = Set_Error_Results_Zero(Results[i]);
                            }
                        }
                        return Final_Results(Input_1, Input_2, Results);
                    case 2:
                        // Multiply
                        for (int i = 0; i < Input_1.Data_points; i++)
                        {
                            Results[i] = Input_1.Y_Values[i] * Input_2.Y_Values[i];
                            if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]) || Results[i] >= NodeEditor_Global_Config.Max_Value_Allowed || Results[i] <= NodeEditor_Global_Config.Min_Value_Allowed)
                            {
                                Results[i] = Set_Error_Results_Zero(Results[i]);
                            }
                        }
                        return Final_Results(Input_1, Input_2, Results);
                    case 3:
                        // Divide
                        for (int i = 0; i < Input_1.Data_points; i++)
                        {
                            Results[i] = Input_1.Y_Values[i] / Input_2.Y_Values[i];
                            if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]) || Results[i] >= NodeEditor_Global_Config.Max_Value_Allowed || Results[i] <= NodeEditor_Global_Config.Min_Value_Allowed)
                            {
                                Results[i] = Set_Error_Results_Zero(Results[i]);
                            }
                        }
                        return Final_Results(Input_1, Input_2, Results);
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

        private Node_Waveform_Model Final_Results(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, double[] Results)
        {
            Set_Status_Color_if_Error();
            if (Primary_Input == 1)
            {
                Node_Waveform_Model Waveform_Data = new Node_Waveform_Model(Input_1.Unique_ID, Input_1.Data_points, Input_1.Total_Time, Input_1.Start_Time, Input_1.Stop_Time, Input_1.X_Values, Results, Units);
                Insert_New_Results_into_Graph(Waveform_Data);
                return Waveform_Data;
            }
            else
            {
                Node_Waveform_Model Waveform_Data = new Node_Waveform_Model(Input_2.Unique_ID, Input_2.Data_points, Input_2.Total_Time, Input_2.Start_Time, Input_2.Stop_Time, Input_2.X_Values, Results, Units);
                Insert_New_Results_into_Graph(Waveform_Data);
                return Waveform_Data;
            }
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

        private string Set_Name(Basic_Math_Type Math_Type)
        {
            switch (Math_Type)
            {
                case (Basic_Math_Type)0:
                    return "(X1 + X2)";
                case (Basic_Math_Type)1:
                    return "(X1 - X2)";
                case (Basic_Math_Type)2:
                    return "(X1 * X2)";
                case (Basic_Math_Type)3:
                    return "(X1 / X2)";
                default:
                    return "Unknown";
            }
        }

        static Basic_Math_ViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new Basic_Node_View(), typeof(IViewFor<Basic_Math_ViewModel>));
        }
    }
}
