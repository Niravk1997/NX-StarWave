using MathNet.Symbolics;
using Node_Model_Classes;
using System;
using Expression = MathNet.Symbolics.SymbolicExpression;

namespace Custom_Math_Expression_Class
{
    public class MathNET_Symbolics_Expression_Parser : Custom_Math_Expression_Parse
    {
        private SymbolicExpression Symbolic_Math_Expression { get; set; }

        Func<double, double> Compiled_Expression_1_Inputs { get; set; }
        Func<double, double, double> Compiled_Expression_2_Inputs { get; set; }
        Func<double, double, double, double> Compiled_Expression_3_Inputs { get; set; }
        Func<double, double, double, double, double> Compiled_Expression_4_Inputs { get; set; }

        public MathNET_Symbolics_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name, string Input_2_Name, string Input_3_Name, string Input_4_Name)
        {
            Set_Expression_Variables(4, Math_Expression, Output_Name, Input_1_Name, Input_2_Name, Input_3_Name, Input_4_Name);
            Set_Math_Expression_and_Arguments();
        }

        public MathNET_Symbolics_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name, string Input_2_Name, string Input_3_Name)
        {
            Set_Expression_Variables(3, Math_Expression, Output_Name, Input_1_Name, Input_2_Name, Input_3_Name);
            Set_Math_Expression_and_Arguments();
        }

        public MathNET_Symbolics_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name, string Input_2_Name)
        {
            Set_Expression_Variables(2, Math_Expression, Output_Name, Input_1_Name, Input_2_Name);
            Set_Math_Expression_and_Arguments();
        }

        public MathNET_Symbolics_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name)
        {
            Set_Expression_Variables(1, Math_Expression, Output_Name, Input_1_Name);
            Set_Math_Expression_and_Arguments();
        }

        public void Set_Math_Expression_and_Arguments()
        {
            Symbolic_Math_Expression = Expression.Parse(Math_Expression);

            switch (Total_Inputs)
            {
                case 1:
                    Compiled_Expression_1_Inputs = Symbolic_Math_Expression.Compile(Input_1_Name);
                    break;
                case 2:
                    Compiled_Expression_2_Inputs = Symbolic_Math_Expression.Compile(Input_1_Name, Input_2_Name);
                    break;
                case 3:
                    Compiled_Expression_3_Inputs = Symbolic_Math_Expression.Compile(Input_1_Name, Input_2_Name, Input_3_Name);
                    break;
                case 4:
                    Compiled_Expression_4_Inputs = Symbolic_Math_Expression.Compile(Input_1_Name, Input_2_Name, Input_3_Name, Input_4_Name);
                    break;
            }
        }

        public override (bool isValid, string Input_Message, string Output_Message, string Main_Message) Verify_Expression()
        {
            try
            {
                double[] Input_Data = new double[] { 1, 2, 3, 4 };
                double[] Output_Data = new double[Input_Data.Length];

                switch (Total_Inputs)
                {
                    case 1:
                        for (int i = 0; i < Input_Data.Length; i++)
                        {
                            Output_Data[i] = Compiled_Expression_1_Inputs(Input_Data[i]);
                            if (double.IsNaN(Output_Data[i]) || double.IsInfinity(Output_Data[i]))
                            {
                                return (false, $"Input Value: {Input_Data[i]}", "Output Value: " + (double.IsNaN(Output_Data[i]) ? "NAN" : "Infinity"), "Math Expression Verification failed. Check Input Names, Math Expression and Total Inputs.");
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < Input_Data.Length; i++)
                        {
                            Output_Data[i] = Compiled_Expression_2_Inputs(Input_Data[i], Input_Data[i]);
                            if (double.IsNaN(Output_Data[i]) || double.IsInfinity(Output_Data[i]))
                            {
                                return (false, $"Input Value: {Input_Data[i]}", "Output Value: " + (double.IsNaN(Output_Data[i]) ? "NAN" : "Infinity"), "Math Expression Verification failed. Check Input Names, Math Expression and Total Inputs.");
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < Input_Data.Length; i++)
                        {
                            Output_Data[i] = Compiled_Expression_3_Inputs(Input_Data[i], Input_Data[i], Input_Data[i]);
                            if (double.IsNaN(Output_Data[i]) || double.IsInfinity(Output_Data[i]))
                            {
                                return (false, $"Input Value: {Input_Data[i]}", "Output Value: " + (double.IsNaN(Output_Data[i]) ? "NAN" : "Infinity"), "Math Expression Verification failed. Check Input Names, Math Expression and Total Inputs.");
                            }
                        }
                        break;
                    case 4:
                        for (int i = 0; i < Input_Data.Length; i++)
                        {
                            Output_Data[i] = Compiled_Expression_4_Inputs(Input_Data[i], Input_Data[i], Input_Data[i], Input_Data[i]);
                            if (double.IsNaN(Output_Data[i]) || double.IsInfinity(Output_Data[i]))
                            {
                                return (false, $"Input Value: {Input_Data[i]}", "Output Value: " + (double.IsNaN(Output_Data[i]) ? "NAN" : "Infinity"), "Math Expression Verification failed. Check Input Names, Math Expression and Total Inputs.");
                            }
                        }
                        break;
                }
                return (true, $"Input Value: {string.Join(",", Input_Data)}", $"Output Value: {string.Join(",", Output_Data)}", "Math Expression is Valid.");
            }
            catch (Exception Ex)
            {
                return (false, Ex.Message, Ex.ToString(), "Math Expression Verification failed. Check Input Names, Math Expression and Total Inputs.");
            }
        }

        public override string Utilizing_Math_Parser_Library()
        {
            return "Using MathNET Symbolics library.";
        }

        public override (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4)
        {
            try
            {
                int Infinity_Count = 0;
                int NAN_Count = 0;
                int Min_Count = 0;
                int Max_Count = 0;
                double[] Results = new double[Input_1.Data_points];

                for (int i = 0; i < Input_1.Data_points; i++)
                {
                    Results[i] = Compiled_Expression_4_Inputs(Input_1.Y_Values[i], Input_2.Y_Values[i], Input_3.Y_Values[i], Input_4.Y_Values[i]);
                    if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]) || Results[i] >= Max_Value_Allowed || Results[i] <= Min_Value_Allowed)
                    {
                        Results[i] = 0;

                        if (double.IsNaN(Results[i]))
                        {
                            NAN_Count++;
                        }

                        if (double.IsInfinity(Results[i]))
                        {
                            Infinity_Count++;
                        }

                        if (Results[i] >= Max_Value_Allowed)
                        {
                            Max_Count++;
                        }

                        if (Results[i] <= Min_Value_Allowed)
                        {
                            Min_Count++;
                        }
                    }
                }

                return (true, Infinity_Count, NAN_Count, Min_Count, Max_Count, "Expression Calculated", Results);
            }
            catch (Exception Ex)
            {
                return (false, 0, 0, 0, 0, Ex.Message, null);
            }
        }

        public override (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3)
        {
            try
            {
                int Infinity_Count = 0;
                int NAN_Count = 0;
                int Min_Count = 0;
                int Max_Count = 0;
                double[] Results = new double[Input_1.Data_points];

                for (int i = 0; i < Input_1.Data_points; i++)
                {
                    Results[i] = Compiled_Expression_3_Inputs(Input_1.Y_Values[i], Input_2.Y_Values[i], Input_3.Y_Values[i]);
                    if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]) || Results[i] >= Max_Value_Allowed || Results[i] <= Min_Value_Allowed)
                    {
                        Results[i] = 0;

                        if (double.IsNaN(Results[i]))
                        {
                            NAN_Count++;
                        }

                        if (double.IsInfinity(Results[i]))
                        {
                            Infinity_Count++;
                        }

                        if (Results[i] >= Max_Value_Allowed)
                        {
                            Max_Count++;
                        }

                        if (Results[i] <= Min_Value_Allowed)
                        {
                            Min_Count++;
                        }
                    }
                }

                return (true, Infinity_Count, NAN_Count, Min_Count, Max_Count, "Expression Calculated", Results);
            }
            catch (Exception Ex)
            {
                return (false, 0, 0, 0, 0, Ex.Message, null);
            }
        }

        public override (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2)
        {
            try
            {
                int Infinity_Count = 0;
                int NAN_Count = 0;
                int Min_Count = 0;
                int Max_Count = 0;
                double[] Results = new double[Input_1.Data_points];

                for (int i = 0; i < Input_1.Data_points; i++)
                {
                    Results[i] = Compiled_Expression_2_Inputs(Input_1.Y_Values[i], Input_2.Y_Values[i]);
                    if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]) || Results[i] >= Max_Value_Allowed || Results[i] <= Min_Value_Allowed)
                    {
                        Results[i] = 0;

                        if (double.IsNaN(Results[i]))
                        {
                            NAN_Count++;
                        }

                        if (double.IsInfinity(Results[i]))
                        {
                            Infinity_Count++;
                        }

                        if (Results[i] >= Max_Value_Allowed)
                        {
                            Max_Count++;
                        }

                        if (Results[i] <= Min_Value_Allowed)
                        {
                            Min_Count++;
                        }
                    }
                }

                return (true, Infinity_Count, NAN_Count, Min_Count, Max_Count, "Expression Calculated", Results);
            }
            catch (Exception Ex)
            {
                return (false, 0, 0, 0, 0, Ex.Message, null);
            }
        }

        public override (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1)
        {
            try
            {
                int Infinity_Count = 0;
                int NAN_Count = 0;
                int Min_Count = 0;
                int Max_Count = 0;
                double[] Results = new double[Input_1.Data_points];

                for (int i = 0; i < Input_1.Data_points; i++)
                {
                    Results[i] = Compiled_Expression_1_Inputs(Input_1.Y_Values[i]);
                    if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]) || Results[i] >= Max_Value_Allowed || Results[i] <= Min_Value_Allowed)
                    {
                        Results[i] = 0;

                        if (double.IsNaN(Results[i]))
                        {
                            NAN_Count++;
                        }

                        if (double.IsInfinity(Results[i]))
                        {
                            Infinity_Count++;
                        }

                        if (Results[i] >= Max_Value_Allowed)
                        {
                            Max_Count++;
                        }

                        if (Results[i] <= Min_Value_Allowed)
                        {
                            Min_Count++;
                        }
                    }
                }

                return (true, Infinity_Count, NAN_Count, Min_Count, Max_Count, "Expression Calculated", Results);
            }
            catch (Exception Ex)
            {
                return (false, 0, 0, 0, 0, Ex.Message, null);
            }
        }
    }
}
