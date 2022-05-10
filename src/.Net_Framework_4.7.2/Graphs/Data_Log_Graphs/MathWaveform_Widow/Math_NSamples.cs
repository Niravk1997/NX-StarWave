using MahApps.Metro.Controls;
using System;
using System.Threading.Tasks;
using System.Windows;
namespace Channel_DataLogger
{
    public partial class Math_Waveform : MetroWindow
    {
        private (bool, int, int) MathNsamples_Range()
        {
            (bool isValid_Start, double Start_Value) = Functions.Text_Num(Start_Math_NSamples_TextBox.Text, false, true);
            (bool isValid_End, double End_Value) = Functions.Text_Num(End_Math_NSamples_TextBox.Text, false, true);
            if (isValid_Start == true & isValid_End == true)
            {
                if (Start_Value < End_Value)
                {
                    if (End_Value < Measurement_Count)
                    {
                        return (true, (int)Start_Value, (int)End_Value);
                    }
                    else
                    {
                        Insert_Log("Math N Samples End Value must be less than or equal to Total N Samples Captured.", 1);
                        return (false, 0, 0);
                    }
                }
                else
                {
                    Insert_Log("Math N Samples Start Value must be less than End Value.", 1);
                    return (false, 0, 0);
                }
            }
            else
            {
                if (isValid_Start == false)
                {
                    Insert_Log("Math N Samples Start Value is invalid. Value must be an positive integer.", 1);
                    Start_Math_NSamples_TextBox.Text = String.Empty;
                }
                if (isValid_End == false)
                {
                    Insert_Log("Math N Samples End Value is invalid. Value must be an positive integer.", 1);
                    End_Math_NSamples_TextBox.Text = String.Empty;
                }
                return (false, 0, 0);
            }
        }

        private void Addition_Button_Math_NSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValid, double Value) = Functions.Text_Num(Addition_TextBox_Math_NSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (IsValidRange == true & isValid == true & isValidGraphColor == true)
            {
                if (Addition_NSamples_Samples_Value.IsSelected == true)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Measurement_Data_Copy[i] + Value;
                            }
                            Create_Waveform_Window("Addition Math Waveform [" + StartValue + ", " + EndValue + "]: Samples + " + Value, Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Addition (N Samples) (Samples + Value) Math Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Value + Measurement_Data_Copy[i];
                            }
                            Create_Waveform_Window("Addition Math Waveform [" + StartValue + ", " + EndValue + "]: " + Value + " + Samples", Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Addition (N Samples) (Value + Samples) Math Waveform. Try again.", 1);
                        }
                    });
                }
            }
            else
            {
                if (isValid == false)
                {
                    Addition_TextBox_Math_NSamples.Text = string.Empty;
                    Insert_Log("Cannot create Addition (N Samples) Math Waveform. Value's input field must only have numbers, no text.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Addition (N Samples) Math Waveform.", 1);
                }
            }
        }

        private void Subtraction_Button_Math_NSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValid, double Value) = Functions.Text_Num(Subtraction_TextBox_Math_NSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (IsValidRange == true & isValid == true & isValidGraphColor == true)
            {
                if (Subtraction_NSamples_Samples_Value.IsSelected == true)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Measurement_Data_Copy[i] - Value;
                            }
                            Create_Waveform_Window("Subtraction Math Waveform [" + StartValue + ", " + EndValue + "]: Samples - " + Value, Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Subtraction (N Samples) (Samples - Value) Math Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Value - Measurement_Data_Copy[i];
                            }
                            Create_Waveform_Window("Subtraction Math Waveform [" + StartValue + ", " + EndValue + "]: " + Value + " - Samples", Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Subtraction (N Samples) (Value - Samples) Math Waveform. Try again.", 1);
                        }
                    });
                }
            }
            else
            {
                if (isValid == false)
                {
                    Subtraction_TextBox_Math_NSamples.Text = string.Empty;
                    Insert_Log("Cannot create Subtraction (N Samples) Math Waveform. Value's input field must only have numbers, no text.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Subtraction (N Samples) Math Waveform.", 1);
                }
            }
        }

        private void Multiplication_Button_Math_NSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValid, double Value) = Functions.Text_Num(Multiplication_TextBox_Math_NSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (IsValidRange == true & isValid == true & isValidGraphColor == true)
            {
                if (Multiplication_NSamples_Samples_Value.IsSelected == true)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Measurement_Data_Copy[i] * Value;
                            }
                            Create_Waveform_Window("Multiplication Math Waveform [" + StartValue + ", " + EndValue + "]: Samples * " + Value, Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Multiplication (N Samples) (Samples * Value) Math Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Value * Measurement_Data_Copy[i];
                            }
                            Create_Waveform_Window("Multiplication Math Waveform [" + StartValue + ", " + EndValue + "]: " + Value + " * Samples", Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Multiplication (N Samples) (Value * Samples) Math Waveform. Try again.", 1);
                        }
                    });
                }
            }
            else
            {
                if (isValid == false)
                {
                    Multiplication_TextBox_Math_NSamples.Text = string.Empty;
                    Insert_Log("Cannot create Multiplication (N Samples) Math Waveform. Value's input field must only have numbers.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Multiplication (N Samples) Math Waveform.", 1);
                }
            }
        }

        private void Division_Button_Math_NSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValid, double Value) = Functions.Text_Num(Division_TextBox_Math_NSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (IsValidRange == true & isValid == true & isValidGraphColor == true)
            {
                if (Value != 0)
                {
                    if (Division_NSamples_Samples_Value.IsSelected == true)
                    {
                        string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                        string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                        Task.Run(() =>
                        {
                            try
                            {
                                int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                                double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                                Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                                for (int i = 0; i < Measurement_Count_Copy; i++)
                                {
                                    Measurement_Data_Copy[i] = Measurement_Data_Copy[i] / Value;
                                }
                                Create_Waveform_Window("Division Math Waveform [" + StartValue + ", " + EndValue + "]: Samples / " + Value, Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                                Measurement_Data_Copy = null;

                            }
                            catch (Exception Ex)
                            {
                                Insert_Log(Ex.Message, 1);
                                Insert_Log("Cannot create Division (N Samples) (Samples / Value) Math Waveform. Try again.", 1);
                            }
                        });
                    }
                    else
                    {
                        string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                        string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                        Task.Run(() =>
                        {
                            try
                            {
                                int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                                double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                                Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                                for (int i = 0; i < Measurement_Count_Copy; i++)
                                {
                                    Measurement_Data_Copy[i] = Value / Measurement_Data_Copy[i];
                                    if (double.IsInfinity(Measurement_Data_Copy[i]) == true) //Check is answer is infinite, if yes then set it to 0
                                    {
                                        Measurement_Data_Copy[i] = 0;
                                    }
                                }
                                Create_Waveform_Window("Division Math Waveform [" + StartValue + ", " + EndValue + "]: " + Value + " / Samples", Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                                Measurement_Data_Copy = null;

                            }
                            catch (Exception Ex)
                            {
                                Insert_Log(Ex.Message, 1);
                                Insert_Log("Cannot create Division (N Samples) (Value / Samples) Math Waveform. Try again.", 1);
                            }
                        });
                    }
                }
                else
                {
                    Insert_Log("Cannot create Division (N Samples) (Value / Samples) Math Waveform." + " Cannot divide by " + Value, 1);
                }
            }
            else
            {
                if (isValid == false)
                {
                    Division_TextBox_Math_NSamples.Text = string.Empty;
                    Insert_Log("Cannot create Division (N Samples) Math Waveform. Value's input field must only have numbers, no text.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Division (N Samples) Math Waveform.", 1);
                }
            }
        }

        private void Percentage_Error_Button_NSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValid, double Value) = Functions.Text_Num(Percentage_Error_TextBox_NSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValid == true & isValidGraphColor == true & IsValidRange == true)
            {
                if (Value != 0)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Math.Abs((Measurement_Data_Copy[i] - Value) / Value) * 100;
                            }
                            Create_Waveform_Window("% Error Math Waveform [" + StartValue + ", " + EndValue + "]: |(Samples - " + Value + ") / " + Value + "| x 100", Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create % Error Math Waveform (N Samples). Try again.", 1);
                        }
                    });
                }
                else
                {
                    Insert_Log("Cannot create % Error Math Waveform (N Samples): Value must not be " + Value, 1);
                }
            }
            else
            {
                if (isValid == false)
                {
                    Insert_Log("Cannot create % Error Math Waveform (N Samples). Value must be a real number.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create % Error Math Waveform (N Samples). Graph Color values are not valid.", 1);
                }
                if (IsValidRange == false)
                {
                    Insert_Log("Cannot create % Error Math Waveform (N Samples). Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void DB_Button_Math_NSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValid_DB_1_Value, double DB_1_Value) = Functions.Text_Num(DB_1_Math_NSamples.Text, true, false);
            (bool isValid_DB_2_Value, double DB_2_Value) = Functions.Text_Num(DB_2_Math_NSamples.Text, false, false);
            (bool isValid_DB_3_Value, double DB_3_Value) = Functions.Text_Num(DB_3_Math_NSamples.Text, false, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValid_DB_1_Value == true & isValid_DB_2_Value == true & isValid_DB_3_Value == true & isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = (DB_1_Value) * (Math.Log(((Math.Abs(Measurement_Data_Copy[i])) / DB_3_Value), DB_2_Value));
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("DB (N Samples Math Waveform [" + StartValue + ", " + EndValue + "]): " + DB_1_Value + " x log" + DB_2_Value + " (Samples / " + DB_3_Value + ")", DB_3_Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create DB (N Samples) Math Waveform. Try again.", 1);
                    }
                });
            }
            else
            {
                if (IsValidRange == false)
                {
                    Insert_Log("Cannot create DB (N Samples) Math Waveform. Check N Samples Start and End input values.", 1);
                }
                if ((isValid_DB_1_Value == false) || (isValid_DB_2_Value == false) || (isValid_DB_3_Value == false))
                {
                    Insert_Log("Cannot create DB (N Samples) Math Waveform. The base and the argument of the logarithm must be positive. Check your inputted values.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create DB (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void DBM_Button_Math_NSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValid_DBM_1_Value, double DBM_1_Value) = Functions.Text_Num(DBM_1_Math_NSamples.Text, true, false);
            (bool isValid_DBM_2_Value, double DBM_2_Value) = Functions.Text_Num(DBM_2_Math_NSamples.Text, false, false);
            (bool isValid_DBM_3_Value, double DBM_3_Value) = Functions.Text_Num(DBM_3_Math_NSamples.Text, false, false);
            (bool isValid_DBM_4_Value, double DBM_4_Value) = Functions.Text_Num(DBM_4_Math_NSamples.Text, false, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValid_DBM_1_Value == true & isValid_DBM_2_Value == true & isValid_DBM_3_Value == true & isValid_DBM_4_Value == true & isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = (DBM_1_Value) * (Math.Log(((((Math.Pow(Measurement_Data_Copy[i], 2)) / DBM_3_Value)) / DBM_4_Value), DBM_2_Value));
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("DBM (N Samples Math Waveform [" + StartValue + ", " + EndValue + "]): " + DBM_1_Value + " x log" + DBM_2_Value + " ((Samples^2 / " + DBM_3_Value + ") / " + DBM_4_Value + ")", DBM_3_Value, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create DBM (N Samples) Math Waveform. Try again.", 1);
                    }
                });
            }
            else
            {
                if (IsValidRange == true)
                {
                    Insert_Log("Cannot create DBM (N Samples) Math Waveform. Check N Samples Start and End input values.", 1);
                }
                if ((isValid_DBM_1_Value == false) || (isValid_DBM_2_Value == false) || (isValid_DBM_3_Value == false) || (isValid_DBM_4_Value == false))
                {
                    Insert_Log("Cannot create DBM (N Samples) Math Waveform. The base and the argument of the logarithm must be positive. Check your inputted values.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create DBM (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Value_Power_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            (bool isValid, double Value) = Functions.Text_Num(Value_Power_NSample_Text.Text, true, false);
            if (isValidGraphColor == true & isValid == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Pow(Value, Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("(Value)^(Samples) Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create (Value)^(Samples) (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create (Value)^(Samples) (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (isValid == false)
                {
                    Insert_Log("Cannot create (Value)^(Samples) (N Samples) Math Waveform. Check your Value.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void NSample_Power_Value_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            (bool isValid, double Value) = Functions.Text_Num(NSample_Power_Value_Text.Text, true, false);
            if (isValidGraphColor == true & isValid == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Pow(Measurement_Data_Copy[i], Value);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("(Samples)^(Value) Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create (Samples)^(Value) (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create (Samples)^(Value) (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (isValid == false)
                {
                    Insert_Log("Cannot create (Samples)^(Value) (N Samples) Math Waveform. Check your Value.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Log_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Log10(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Logarithm Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Logarithm (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Logarithm (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Ln_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Log(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Natural Logarithm Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Natural Logarithm (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Natural Logarithm (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Square_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Sqrt(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Square Root Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Square Root (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Square Root (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Abs_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Abs(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Absolute Value Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Absolute Value (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Absolute Value (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Sine_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                bool inDegrees = Sine_NSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Sin(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Sin(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Sine Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Sine (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Sine (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Cosine_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                bool inDegrees = Cosine_NSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Cos(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Cos(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Cosine Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Cosine (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Cosine (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Tangent_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                bool inDegrees = Tangent_NSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Tan(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Tan(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Tangent Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Tangent (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Tangent (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Inverse_Sine_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                bool inDegrees = Inverse_Sine_NSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Asin(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Asin(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Inverse Sine Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Inverse Sine (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Inverse Sine (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Inverse_Cosine_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                bool inDegrees = Inverse_Cosine_NSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Acos(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Acos(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Inverse Cosine Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Inverse Cosine (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Inverse Cosine (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Inverse_Tangent_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                bool inDegrees = Inverse_Tangent_NSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Atan(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Atan(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Inverse Tangent Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Inverse Tangent (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Inverse Tangent (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Hyperbolic_Sine_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                bool inDegrees = Hyperbolic_Sine_NSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Sinh(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Sinh(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Hyperbolic Sine Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Hyperbolic Sine (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Hyperbolic Sine (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Hyperbolic_Cosine_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                bool inDegrees = Hyperbolic_Cosine_NSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Cosh(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Cosh(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Hyperbolic Cosine Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Hyperbolic Cosine (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Hyperbolic Cosine (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Hyperbolic_Tangent_NSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = MathNsamples_Range();
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_NSamples_Check();
            if (isValidGraphColor == true & IsValidRange == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_NSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_NSamples.Text;
                bool inDegrees = Hyperbolic_Tangent_NSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = (EndValue - StartValue) + 1;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, StartValue, Measurement_Data_Copy, 0, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Tanh(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Tanh(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Hyperbolic Tangent Math Waveform [" + StartValue + ", " + EndValue + "]", 0, StartValue, EndValue, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Hyperbolic Tangent (N Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Hyperbolic Tangent (N Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (IsValidRange == true)
                {
                    Insert_Log("Check N Samples Start and End input values.", 1);
                }
            }
        }

        private void Set_Default_GraphColor_Math_NSamples(int Red, int Green, int Blue)
        {
            GraphColor_Preview_Math_NSamples.SelectedColor = System.Windows.Media.Color.FromRgb((byte)Red, (byte)Green, (byte)Blue);
        }

        private (bool, int, int, int) GraphColor_Math_NSamples_Check()
        {
            try
            {
                System.Windows.Media.Color color = GraphColor_Preview_Math_NSamples.SelectedColor;
                return (true, color.R, color.G, color.B);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                return (false, 0, 0, 0);
            }
        }

        private void GraphColor_RandomizeButton_Math_NSamples_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random RGB_Value = new Random();
                int Value_Red = RGB_Value.Next(0, 255);
                int Value_Green = RGB_Value.Next(0, 255);
                int Value_Blue = RGB_Value.Next(0, 255);
                GraphColor_Preview_Math_NSamples.SelectedColor = System.Windows.Media.Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue));
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }
    }
}
