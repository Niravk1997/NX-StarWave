﻿using DynamicData;
using Node_Model_Classes;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork_Math;
using NX_StarWave.Waveform_Model_Classes;
using org.mariuszgromada.math.mxparser;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Media;

namespace Custom_Math_Expressions_Node
{
    public partial class Custom_Math_Expression_ViewModel_4_Input : Node_ViewModel
    {
        private int Input_1_Unique_Key = -1;
        private int Input_2_Unique_Key = -1;
        private int Input_3_Unique_Key = -1;
        private int Input_4_Unique_Key = -1;

        public ValueNodeInputViewModel<Node_Waveform_Model> Input_1 { get; }

        public ValueNodeInputViewModel<Node_Waveform_Model> Input_2 { get; }

        public ValueNodeInputViewModel<Node_Waveform_Model> Input_3 { get; }

        public ValueNodeInputViewModel<Node_Waveform_Model> Input_4 { get; }

        public ValueNodeOutputViewModel<Node_Waveform_Model> Output { get; set; }

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

        private string Input_2_string_ = "x2";
        public string Input_2_string
        {
            get => Input_2_string_;
            set => this.RaiseAndSetIfChanged(ref Input_2_string_, value);
        }

        private string Input_3_string_ = "x3";
        public string Input_3_string
        {
            get => Input_3_string_;
            set => this.RaiseAndSetIfChanged(ref Input_3_string_, value);
        }

        private string Input_4_string_ = "x4";
        public string Input_4_string
        {
            get => Input_4_string_;
            set => this.RaiseAndSetIfChanged(ref Input_4_string_, value);
        }

        private System.Windows.Visibility Node_Config_Options_Visibility_ = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility Node_Config_Options_Visibility
        {
            get => Node_Config_Options_Visibility_;
            set => this.RaiseAndSetIfChanged(ref Node_Config_Options_Visibility_, value);
        }

        private Argument[] Math_Argument = new Argument[4];
        private Expression Math_Expression;

        private NodeNetwork_Window NodeNetwork_MainWindow { get; set; }

        public Custom_Math_Expression_ViewModel_4_Input(object Parent_Window, string Name, bool IsCollapsed, NodeCategory Category, string Background_Color, string Foreground_Color, string Units, string Math_Expression, string Output_Name = "Output", string Input_1_Name = "x1", string Input_2_Name = "x2", string Input_3_Name = "x3", string Input_4_Name = "x4")
        {
            NodeNetwork_MainWindow = Parent_Window as NodeNetwork_Window;

            this.Node_Name = Name;
            this.Category = Category;
            this.Units = Units;
            this.IsCollapsed = IsCollapsed;
            this.Math_Expression_string = Math_Expression;
            this.Output_string = Output_Name;
            this.Input_1_string = Input_1_Name;
            this.Input_2_string = Input_2_Name;
            this.Input_3_string = Input_3_Name;
            this.Input_4_string = Input_4_Name;

            Math_Argument[0] = new Argument(Input_1_Name, 0);
            Math_Argument[1] = new Argument(Input_2_Name, 0);
            Math_Argument[2] = new Argument(Input_3_Name, 0);
            Math_Argument[3] = new Argument(Input_4_Name, 0);
            this.Math_Expression = new Expression(Math_Expression, Math_Argument);

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

            Input_2 = new ValueNodeInputViewModel<Node_Waveform_Model>()
            {
                Name = Input_2_Name
            };
            this.Inputs.Add(Input_2);

            Input_3 = new ValueNodeInputViewModel<Node_Waveform_Model>()
            {
                Name = Input_3_Name
            };
            this.Inputs.Add(Input_3);

            Input_4 = new ValueNodeInputViewModel<Node_Waveform_Model>()
            {
                Name = Input_4_Name
            };
            this.Inputs.Add(Input_4);

            Output = new ValueNodeOutputViewModel<Node_Waveform_Model>()
            {
                Name = Output_Name,
                Value = this.WhenAnyValue(vm => vm.Input_1.Value, vm => vm.Input_2.Value, vm => vm.Input_3.Value, vm => vm.Input_4.Value).Select(value => value.Item1 != null && value.Item2 != null && value.Item3 != null && value.Item4 != null ? Input_Verification(value.Item1, value.Item2, value.Item3, value.Item4) : Return_Old_Output())
            };
            this.Outputs.Add(Output);

            Show_Config_Options_Command = ReactiveCommand.Create(() => { Show_Config_Options(); });
            Open_YT_Graph_Window_Command = ReactiveCommand.Create(() => { Open_YT_Graph_Window(); });
            Open_Histogram_Graph_Window_Command = ReactiveCommand.Create(() => { Open_Histogram_Graph_Window(); });
            Open_FFT_Graph_Window_Command = ReactiveCommand.Create(() => { Open_FFT_Graph_Window(); });
        }

        private Node_Waveform_Model Input_Verification(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4)
        {
            if (Check_Data_Points_Match(Input_1, Input_2, Input_3, Input_4) && Check_Total_Time_Match(Input_1, Input_2, Input_3, Input_4))
            {
                if (Input_1.Unique_ID != Input_1_Unique_Key && Input_2.Unique_ID != Input_2_Unique_Key && Input_3.Unique_ID != Input_3_Unique_Key && Input_4.Unique_ID != Input_4_Unique_Key)
                {
                    Input_1_Unique_Key = Input_1.Unique_ID;
                    Input_2_Unique_Key = Input_2.Unique_ID;
                    Input_3_Unique_Key = Input_3.Unique_ID;
                    Input_4_Unique_Key = Input_4.Unique_ID;
                    return Perform_Math_Operation(Input_1, Input_2, Input_3, Input_4);
                }
                else if (NodeEditor_Global_Config.Update_When_Some_Inputs_Update == true)
                {
                    if (Input_1.Unique_ID != Input_1_Unique_Key)
                    {
                        Input_1_Unique_Key = Input_1.Unique_ID;
                        return Perform_Math_Operation(Input_1, Input_2, Input_3, Input_4);
                    }
                    else if (Input_2.Unique_ID != Input_2_Unique_Key)
                    {
                        Input_2_Unique_Key = Input_2.Unique_ID;
                        return Perform_Math_Operation(Input_1, Input_2, Input_3, Input_4);
                    }
                    else if (Input_3.Unique_ID != Input_3_Unique_Key)
                    {
                        Input_3_Unique_Key = Input_3.Unique_ID;
                        return Perform_Math_Operation(Input_1, Input_2, Input_3, Input_4);
                    }
                    else if (Input_4.Unique_ID != Input_4_Unique_Key)
                    {
                        Input_4_Unique_Key = Input_4.Unique_ID;
                        return Perform_Math_Operation(Input_1, Input_2, Input_3, Input_4);
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

        private bool Check_Data_Points_Match(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4)
        {
            if (Input_1.Data_points == Input_2.Data_points && Input_2.Data_points == Input_3.Data_points && Input_3.Data_points == Input_4.Data_points)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Check_Total_Time_Match(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4)
        {
            if (Input_1.Total_Time == Input_2.Total_Time && Input_2.Total_Time == Input_3.Total_Time && Input_3.Total_Time == Input_4.Total_Time)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Node_Waveform_Model Perform_Math_Operation(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4)
        {
            Reset_Error_Counters();
            double[] Results = new double[Input_1.Data_points];
            try
            {
                for (int i = 0; i < Input_1.Data_points; i++)
                {
                    Math_Argument[0].setArgumentValue(Input_1.Y_Values[i]);
                    Math_Argument[1].setArgumentValue(Input_2.Y_Values[i]);
                    Math_Argument[2].setArgumentValue(Input_3.Y_Values[i]);
                    Math_Argument[3].setArgumentValue(Input_4.Y_Values[i]);
                    Results[i] = Math_Expression.calculate();
                    if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]) || Results[i] >= NodeEditor_Global_Config.Max_Value_Allowed || Results[i] <= NodeEditor_Global_Config.Min_Value_Allowed)
                    {
                        Results[i] = Set_Error_Results_Zero(Results[i]);
                    }
                }
                return Final_Results(Input_1, Input_2, Input_3, Input_4, Results);
            }
            catch (Exception)
            {
                Set_Status_Color(Status_Colors.Math_Operation_Failed);
                return null;
            }
        }

        private Node_Waveform_Model Final_Results(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4, double[] Results)
        {
            Set_Status_Color_if_Error();
            Node_Waveform_Model Waveform_Data;
            switch (Primary_Input)
            {
                case 1:
                    Waveform_Data = new Node_Waveform_Model(Input_1.Unique_ID, Input_1.Data_points, Input_1.Total_Time, Input_1.Start_Time, Input_1.Stop_Time, Input_1.X_Values, Results, Units);
                    Insert_New_Results_into_Graph(Waveform_Data);
                    return Waveform_Data;
                case 2:
                    Waveform_Data = new Node_Waveform_Model(Input_2.Unique_ID, Input_2.Data_points, Input_2.Total_Time, Input_2.Start_Time, Input_2.Stop_Time, Input_2.X_Values, Results, Units);
                    Insert_New_Results_into_Graph(Waveform_Data);
                    return Waveform_Data;
                case 3:
                    Waveform_Data = new Node_Waveform_Model(Input_3.Unique_ID, Input_3.Data_points, Input_3.Total_Time, Input_3.Start_Time, Input_3.Stop_Time, Input_3.X_Values, Results, Units);
                    Insert_New_Results_into_Graph(Waveform_Data);
                    return Waveform_Data;
                case 4:
                    Waveform_Data = new Node_Waveform_Model(Input_4.Unique_ID, Input_4.Data_points, Input_4.Total_Time, Input_4.Start_Time, Input_4.Stop_Time, Input_4.X_Values, Results, Units);
                    Insert_New_Results_into_Graph(Waveform_Data);
                    return Waveform_Data;
                default:
                    Waveform_Data = new Node_Waveform_Model(Input_1.Unique_ID, Input_1.Data_points, Input_1.Total_Time, Input_1.Start_Time, Input_1.Stop_Time, Input_1.X_Values, Results, Units);
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

        static Custom_Math_Expression_ViewModel_4_Input()
        {
            Splat.Locator.CurrentMutable.Register(() => new Custom_Math_Expression_View_4_Input(), typeof(IViewFor<Custom_Math_Expression_ViewModel_4_Input>));
        }
    }
}