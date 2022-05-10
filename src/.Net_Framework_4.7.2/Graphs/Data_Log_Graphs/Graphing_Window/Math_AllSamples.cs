using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Channel_DataLogger
{
    public partial class CH_DataLog_Graph_Window : MetroWindow
    {
        //Creates Math Waveform Windows
        private void Create_Waveform_Window(string Window_Title, double Value, int Start_Sample, int End_Sample, string Graph_Title, string Y_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count)
        {
            try
            {
                Thread Waveform_Thread = new Thread(new ThreadStart(() =>
                {
                    Math_Waveform Calculate_Waveform = new Math_Waveform(Graph_Owner, Window_Title, Value, Start_Sample, End_Sample, Graph_Title, Y_Axis_Label, Red, Green, Blue, Measurement_Data, Measurement_Count);
                    Calculate_Waveform.Show();
                    Calculate_Waveform.Closed += (sender2, e2) => Calculate_Waveform.Dispatcher.InvokeShutdown();
                    Dispatcher.Run();
                }));
                Waveform_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.SetApartmentState(ApartmentState.STA);
                Waveform_Thread.IsBackground = true;
                Waveform_Thread.Start();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Insert_Log("Math Waveform Window creation failed.", 1);
            }
        }

        //--------------------------- Math (All Samples)----------------------

        private void Addition_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Functions.Text_Num(Addition_TextBox_Math_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Addition_AllSamples_Samples_Value.IsSelected == true)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Measurement_Data_Copy[i] + Value;
                            }
                            Create_Waveform_Window("Addition Math Waveform [All Samples]: Samples + " + Value, Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Addition (All Samples) (Samples + Value) Math Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Value + Measurement_Data_Copy[i];
                            }
                            Create_Waveform_Window("Addition Math Waveform [All Samples]: " + Value + " + Samples", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Addition (All Samples) (Value + Samples) Math Waveform. Try again.", 1);
                        }
                    });
                }
            }
            else
            {
                if (isValid == false)
                {
                    Addition_TextBox_Math_AllSamples.Text = String.Empty;
                    Insert_Log("Cannot create Addition (All Samples) Math Waveform. Value's input field must only have numbers, no text.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Addition (All Samples) Math Waveform.", 1);
                }
            }
        }

        private void Subtraction_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Functions.Text_Num(Subtraction_TextBox_Math_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Subtraction_AllSamples_Samples_Value.IsSelected == true)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Measurement_Data_Copy[i] - Value;
                            }
                            Create_Waveform_Window("Subtraction Math Waveform [All Samples]: Samples - " + Value, Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Subtraction (All Samples) (Samples - Value) Math Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Value - Measurement_Data_Copy[i];
                            }
                            Create_Waveform_Window("Subtraction Math Waveform [All Samples]: " + Value + " - Samples", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Subtraction (All Samples) (Value - Samples) Math Waveform. Try again.", 1);
                        }
                    });
                }
            }
            else
            {
                if (isValid == false)
                {
                    Subtraction_TextBox_Math_AllSamples.Text = String.Empty;
                    Insert_Log("Cannot create Subtraction (All Samples) Math Waveform. Value's input field must only have numbers, no text.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Subtraction (All Samples) Math Waveform.", 1);
                }
            }
        }

        private void Multiplication_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Functions.Text_Num(Mutiplication_TextBox_Math_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Multiplication_AllSamples_Samples_Value.IsSelected == true)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Measurement_Data_Copy[i] * Value;
                            }
                            Create_Waveform_Window("Multiplication Math Waveform [All Samples]: Samples * " + Value, Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Multiplication (All Samples) (Samples * Value) Math Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Value * Measurement_Data_Copy[i];
                            }
                            Create_Waveform_Window("Multiplication Math Waveform [All Samples]: " + Value + " * Samples", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Multiplication (All Samples) (Value * Samples) Math Waveform. Try again.", 1);
                        }
                    });
                }
            }
            else
            {
                if (isValid == false)
                {
                    Mutiplication_TextBox_Math_AllSamples.Text = String.Empty;
                    Insert_Log("Cannot create Multiplication (All Samples) Math Waveform. Value's input field must only have numbers.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Multiplication (All Samples) Math Waveform.", 1);
                }
            }
        }

        private void Division_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Functions.Text_Num(Division_TextBox_Math_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Value != 0)
                {
                    if (Division_AllSamples_Samples_Value.IsSelected == true)
                    {
                        string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                        string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                        Task.Run(() =>
                        {
                            try
                            {
                                int Measurement_Count_Copy = Measurement_Count;
                                double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                                Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                                for (int i = 0; i < Measurement_Count_Copy; i++)
                                {
                                    Measurement_Data_Copy[i] = Measurement_Data_Copy[i] / Value;
                                }
                                Create_Waveform_Window("Division Math Waveform [All Samples]: Samples / " + Value, Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                                Measurement_Data_Copy = null;

                            }
                            catch (Exception Ex)
                            {
                                Insert_Log(Ex.Message, 1);
                                Insert_Log("Cannot create Division (All Samples) (Samples / Value) Math Waveform. Try again.", 1);
                            }
                        });
                    }
                    else
                    {
                        string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                        string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                        Task.Run(() =>
                        {
                            try
                            {
                                int Measurement_Count_Copy = Measurement_Count;
                                double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                                Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                                for (int i = 0; i < Measurement_Count_Copy; i++)
                                {
                                    Measurement_Data_Copy[i] = Value / Measurement_Data_Copy[i];
                                    if (double.IsInfinity(Measurement_Data_Copy[i]) == true) //Check is answer is infinite, if yes then set it to 0
                                    {
                                        Measurement_Data_Copy[i] = 0;
                                    }
                                }
                                Create_Waveform_Window("Division Math Waveform [All Samples]: " + Value + " / Samples", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                                Measurement_Data_Copy = null;

                            }
                            catch (Exception Ex)
                            {
                                Insert_Log(Ex.Message, 1);
                                Insert_Log("Cannot create Division (All Samples) (Value / Samples) Math Waveform. Try again.", 1);
                            }
                        });
                    }
                }
                else
                {
                    Insert_Log("Cannot create Division (All Samples) (Value / Samples) Math Waveform." + " Cannot divide by " + Value, 1);
                }
            }
            else
            {
                if (isValid == false)
                {
                    Division_TextBox_Math_AllSamples.Text = String.Empty;
                    Insert_Log("Cannot create Division (All Samples) Math Waveform. Value's input field must only have numbers, no text.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Division (All Samples) Math Waveform.", 1);
                }
            }
        }

        private void Percentage_Error_Button_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Functions.Text_Num(Percentage_Error_TextBox_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Value != 0)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Math.Abs((Measurement_Data_Copy[i] - Value) / Value) * 100;
                            }
                            Create_Waveform_Window("% Error Math Waveform [All Samples]: |(Samples - " + Value + ") / " + Value + "| x 100", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                            Measurement_Data_Copy = null;

                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create % Error Math Waveform (All Samples). Try again.", 1);
                        }
                    });
                }
                else
                {
                    Insert_Log("Cannot create % Error Math Waveform (All Samples): Value must not be " + Value, 1);
                }
            }
            else
            {
                if (isValid == false)
                {
                    Insert_Log("Cannot create % Error Math Waveform (All Samples). Value must be a real number.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create % Error Math Waveform (All Samples). Graph Color values are not valid.", 1);
                }
            }
        }

        private void DB_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid_DB_1_Value, double DB_1_Value) = Functions.Text_Num(DB_1_Math_AllSamples.Text, true, false);
            (bool isValid_DB_2_Value, double DB_2_Value) = Functions.Text_Num(DB_2_Math_AllSamples.Text, false, false);
            (bool isValid_DB_3_Value, double DB_3_Value) = Functions.Text_Num(DB_3_Math_AllSamples.Text, false, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid_DB_1_Value == true & isValid_DB_2_Value == true & isValid_DB_3_Value == true & isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = (DB_1_Value) * (Math.Log(((Math.Abs(Measurement_Data_Copy[i])) / DB_3_Value), DB_2_Value));
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("DB (All Samples Math Waveform): " + DB_1_Value + " x log" + DB_2_Value + " (Samples / " + DB_3_Value + ")", DB_3_Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create DB (All Samples) Math Waveform. Try again.", 1);
                    }
                });
            }
            else
            {
                if ((isValid_DB_1_Value == false) || (isValid_DB_2_Value == false) || (isValid_DB_3_Value == false))
                {
                    Insert_Log("Cannot create DB (All Samples) Math Waveform. The base and the argument of the logarithm must be positive. Check your inputted values.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create DB (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void DBM_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid_DBM_1_Value, double DBM_1_Value) = Functions.Text_Num(DBM_1_Math_AllSamples.Text, true, false);
            (bool isValid_DBM_2_Value, double DBM_2_Value) = Functions.Text_Num(DBM_2_Math_AllSamples.Text, false, false);
            (bool isValid_DBM_3_Value, double DBM_3_Value) = Functions.Text_Num(DBM_3_Math_AllSamples.Text, false, false);
            (bool isValid_DBM_4_Value, double DBM_4_Value) = Functions.Text_Num(DBM_4_Math_AllSamples.Text, false, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid_DBM_1_Value == true & isValid_DBM_2_Value == true & isValid_DBM_3_Value == true & isValid_DBM_4_Value == true & isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = (DBM_1_Value) * (Math.Log(((((Math.Pow(Measurement_Data_Copy[i], 2)) / DBM_3_Value)) / DBM_4_Value), DBM_2_Value));
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("DBM (All Samples Math Waveform): " + DBM_1_Value + " x log" + DBM_2_Value + " ((Samples^2 / " + DBM_3_Value + ") / " + DBM_4_Value + ")", DBM_3_Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create DBM (All Samples) Math Waveform. Try again.", 1);
                    }
                });
            }
            else
            {
                if ((isValid_DBM_1_Value == false) || (isValid_DBM_2_Value == false) || (isValid_DBM_3_Value == false) || (isValid_DBM_4_Value == false))
                {
                    Insert_Log("Cannot create DBM (All Samples) Math Waveform. The base and the argument of the logarithm must be positive. Check your inputted values.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create DBM (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Value_Power_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            (bool isValid, double Value) = Functions.Text_Num(Value_Power_AllSample_Text.Text, true, false);
            if (isValidGraphColor == true & isValid == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Pow(Value, Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("(Value)^(Samples) Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create (Value)^(Samples) (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create (Value)^(Samples) (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (isValid == false)
                {
                    Insert_Log("Cannot create (Value)^(Samples) (All Samples) Math Waveform. Check your Value.", 1);
                }
            }
        }

        private void AllSample_Power_Value_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            (bool isValid, double Value) = Functions.Text_Num(AllSample_Power_Value_Text.Text, true, false);
            if (isValidGraphColor == true & isValid == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Pow(Measurement_Data_Copy[i], Value);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("(Samples)^(Value) Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create (Samples)^(Value) (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create (Samples)^(Value) (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
                if (isValid == false)
                {
                    Insert_Log("Cannot create (Samples)^(Value) (All Samples) Math Waveform. Check your Value.", 1);
                }
            }
        }

        private void Log_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Log10(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Logarithm Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Logarithm (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Logarithm (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Ln_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Log(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Natural Logarithm Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Natural Logarithm (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Natural Logarithm (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Square_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Sqrt(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Square Root Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Square Root (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Square Root (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Abs_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Abs(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Absolute Value Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Absolute Value (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Absolute Value (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Sine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Sine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




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
                        Create_Waveform_Window("Sine Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Sine (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Sine (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Cosine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Cosine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




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
                        Create_Waveform_Window("Cosine Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Cosine (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Cosine (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Tangent_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Tangent_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




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
                        Create_Waveform_Window("Tangent Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Tangent (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Tangent (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Inverse_Sine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Inverse_Sine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




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
                        Create_Waveform_Window("Inverse Sine Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Inverse Sine (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Inverse Sine (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Inverse_Cosine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Inverse_Cosine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




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
                        Create_Waveform_Window("Inverse Cosine Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Inverse Cosine (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Inverse Cosine (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Inverse_Tangent_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Inverse_Tangent_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




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
                        Create_Waveform_Window("Inverse Tangent Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Inverse Tangent (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Inverse Tangent (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Hyperbolic_Sine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Hyperbolic_Sine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




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
                        Create_Waveform_Window("Hyperbolic Sine Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Hyperbolic Sine (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Hyperbolic Sine (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Hyperbolic_Cosine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Hyperbolic_Cosine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




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
                        Create_Waveform_Window("Hyperbolic Cosine Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Hyperbolic Cosine (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Hyperbolic Cosine (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Hyperbolic_Tangent_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Hyperbolic_Tangent_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);




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
                        Create_Waveform_Window("Hyperbolic Tangent Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy);
                        Measurement_Data_Copy = null;

                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Hyperbolic Tangent (All Samples) Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Hyperbolic Tangent (All Samples) Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Set_Default_GraphColor_Math_AllSamples(string Color)
        {
            GraphColor_Preview_Math_AllSamples.SelectedColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Color);
        }

        private (bool, int, int, int) GraphColor_Math_AllSamples_Check()
        {
            try
            {
                System.Windows.Media.Color color = GraphColor_Preview_Math_AllSamples.SelectedColor;
                return (true, color.R, color.G, color.B);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                return (false, 0, 0, 0);
            }
        }

        private void GraphColor_RandomizeButton_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random RGB_Value = new Random();
                int Value_Red = RGB_Value.Next(0, 255);
                int Value_Green = RGB_Value.Next(0, 255);
                int Value_Blue = RGB_Value.Next(0, 255);
                GraphColor_Preview_Math_AllSamples.SelectedColor = System.Windows.Media.Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue));
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        //--------------------------- Math (All Samples)----------------------
    }
}
