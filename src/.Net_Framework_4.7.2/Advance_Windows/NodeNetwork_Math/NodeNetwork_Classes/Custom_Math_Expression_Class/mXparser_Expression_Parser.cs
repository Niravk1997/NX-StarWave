using Node_Model_Classes;
using org.mariuszgromada.math.mxparser;
using System;

namespace Custom_Math_Expression_Class
{
    public class mXparser_Expression_Parser : Custom_Math_Expression_Parse
    {
        private Expression mXparser_Math_Expression;
        private Argument[] Math_Argument;

        public mXparser_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name, string Input_2_Name, string Input_3_Name, string Input_4_Name, string Input_5_Name, string Input_6_Name, string Input_7_Name)
        {
            Set_Expression_Variables(7, Math_Expression, Output_Name, Input_1_Name, Input_2_Name, Input_3_Name, Input_4_Name, Input_5_Name, Input_6_Name, Input_7_Name);
            Set_Math_Expression_and_Arguments();
        }

        public mXparser_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name, string Input_2_Name, string Input_3_Name, string Input_4_Name, string Input_5_Name, string Input_6_Name)
        {
            Set_Expression_Variables(6, Math_Expression, Output_Name, Input_1_Name, Input_2_Name, Input_3_Name, Input_4_Name, Input_5_Name, Input_6_Name);
            Set_Math_Expression_and_Arguments();
        }

        public mXparser_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name, string Input_2_Name, string Input_3_Name, string Input_4_Name, string Input_5_Name)
        {
            Set_Expression_Variables(5, Math_Expression, Output_Name, Input_1_Name, Input_2_Name, Input_3_Name, Input_4_Name, Input_5_Name);
            Set_Math_Expression_and_Arguments();
        }

        public mXparser_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name, string Input_2_Name, string Input_3_Name, string Input_4_Name)
        {
            Set_Expression_Variables(4, Math_Expression, Output_Name, Input_1_Name, Input_2_Name, Input_3_Name, Input_4_Name);
            Set_Math_Expression_and_Arguments();
        }

        public mXparser_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name, string Input_2_Name, string Input_3_Name)
        {
            Set_Expression_Variables(3, Math_Expression, Output_Name, Input_1_Name, Input_2_Name, Input_3_Name);
            Set_Math_Expression_and_Arguments();
        }

        public mXparser_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name, string Input_2_Name)
        {
            Set_Expression_Variables(2, Math_Expression, Output_Name, Input_1_Name, Input_2_Name);
            Set_Math_Expression_and_Arguments();
        }

        public mXparser_Expression_Parser(string Math_Expression, string Output_Name, string Input_1_Name)
        {
            Set_Expression_Variables(1, Math_Expression, Output_Name, Input_1_Name);
            Set_Math_Expression_and_Arguments();
        }

        public void Set_Math_Expression_and_Arguments()
        {
            Math_Argument = new Argument[Total_Inputs];

            if (Total_Inputs >= 1)
            {
                Math_Argument[0] = new Argument(Input_1_Name, 0);
            }

            if (Total_Inputs >= 2)
            {
                Math_Argument[1] = new Argument(Input_2_Name, 0);
            }

            if (Total_Inputs >= 3)
            {
                Math_Argument[2] = new Argument(Input_3_Name, 0);
            }

            if (Total_Inputs >= 4)
            {
                Math_Argument[3] = new Argument(Input_4_Name, 0);
            }

            if (Total_Inputs >= 5)
            {
                Math_Argument[4] = new Argument(Input_5_Name, 0);
            }

            if (Total_Inputs >= 6)
            {
                Math_Argument[5] = new Argument(Input_6_Name, 0);
            }

            if (Total_Inputs >= 7)
            {
                Math_Argument[6] = new Argument(Input_7_Name, 0);
            }

            mXparser_Math_Expression = new Expression(Math_Expression, Math_Argument);
        }

        public override (bool isValid, string Input_Message, string Output_Message, string Main_Message) Verify_Expression()
        {
            try
            {
                double[] Input_Data = new double[] { 1, 2, 3, 4 };
                double[] Output_Data = new double[Input_Data.Length];

                if (mXparser_Math_Expression.checkSyntax())
                {
                    for (int i = 0; i < Input_Data.Length; i++)
                    {
                        if (Total_Inputs >= 1)
                        {
                            Math_Argument[0].setArgumentValue(Input_Data[i]);
                        }

                        if (Total_Inputs >= 2)
                        {
                            Math_Argument[1].setArgumentValue(Input_Data[i]);
                        }

                        if (Total_Inputs >= 3)
                        {
                            Math_Argument[2].setArgumentValue(Input_Data[i]);
                        }

                        if (Total_Inputs >= 4)
                        {
                            Math_Argument[3].setArgumentValue(Input_Data[i]);
                        }

                        if (Total_Inputs >= 5)
                        {
                            Math_Argument[4].setArgumentValue(Input_Data[i]);
                        }

                        if (Total_Inputs >= 6)
                        {
                            Math_Argument[5].setArgumentValue(Input_Data[i]);
                        }

                        if (Total_Inputs >= 7)
                        {
                            Math_Argument[6].setArgumentValue(Input_Data[i]);
                        }
                        Output_Data[i] = mXparser_Math_Expression.calculate();
                        if (double.IsNaN(Output_Data[i]) || double.IsInfinity(Output_Data[i]))
                        {
                            return (false, $"Input Value: {Input_Data[i]}", "Output Value: " + (double.IsNaN(Output_Data[i]) ? "NAN" : "Infinity"), "Math Expression Verification failed. Check Input Names, Math Expression and Total Inputs.");
                        }
                    }
                    return (true, $"Input Value: {string.Join(",", Input_Data)}", $"Output Value: {string.Join(",", Output_Data)}", "Math Expression is Valid.");
                }
                else
                {
                    return (false, "Check Math Expression.", "It may not be valid.", "Math Expression Verification failed. Expression failed syntax check.");
                }
            }
            catch (Exception Ex)
            {
                return (false, Ex.Message, Ex.ToString(), "Math Expression Verification failed. Check Input Names, Math Expression and Total Inputs.");
            }
        }

        public override string Utilizing_Math_Parser_Library()
        {
            return "Using mXparser library.";
        }

        public override (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4, Node_Waveform_Model Input_5, Node_Waveform_Model Input_6, Node_Waveform_Model Input_7)
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
                    Math_Argument[0].setArgumentValue(Input_1.Y_Values[i]);
                    Math_Argument[1].setArgumentValue(Input_2.Y_Values[i]);
                    Math_Argument[2].setArgumentValue(Input_3.Y_Values[i]);
                    Math_Argument[3].setArgumentValue(Input_4.Y_Values[i]);
                    Math_Argument[4].setArgumentValue(Input_5.Y_Values[i]);
                    Math_Argument[5].setArgumentValue(Input_6.Y_Values[i]);
                    Math_Argument[6].setArgumentValue(Input_7.Y_Values[i]);
                    Results[i] = mXparser_Math_Expression.calculate();
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

        public override (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4, Node_Waveform_Model Input_5, Node_Waveform_Model Input_6)
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
                    Math_Argument[0].setArgumentValue(Input_1.Y_Values[i]);
                    Math_Argument[1].setArgumentValue(Input_2.Y_Values[i]);
                    Math_Argument[2].setArgumentValue(Input_3.Y_Values[i]);
                    Math_Argument[3].setArgumentValue(Input_4.Y_Values[i]);
                    Math_Argument[4].setArgumentValue(Input_5.Y_Values[i]);
                    Math_Argument[5].setArgumentValue(Input_6.Y_Values[i]);
                    Results[i] = mXparser_Math_Expression.calculate();
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

        public override (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4, Node_Waveform_Model Input_5)
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
                    Math_Argument[0].setArgumentValue(Input_1.Y_Values[i]);
                    Math_Argument[1].setArgumentValue(Input_2.Y_Values[i]);
                    Math_Argument[2].setArgumentValue(Input_3.Y_Values[i]);
                    Math_Argument[3].setArgumentValue(Input_4.Y_Values[i]);
                    Math_Argument[4].setArgumentValue(Input_5.Y_Values[i]);
                    Results[i] = mXparser_Math_Expression.calculate();
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
                    Math_Argument[0].setArgumentValue(Input_1.Y_Values[i]);
                    Math_Argument[1].setArgumentValue(Input_2.Y_Values[i]);
                    Math_Argument[2].setArgumentValue(Input_3.Y_Values[i]);
                    Math_Argument[3].setArgumentValue(Input_4.Y_Values[i]);
                    Results[i] = mXparser_Math_Expression.calculate();
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
                    Math_Argument[0].setArgumentValue(Input_1.Y_Values[i]);
                    Math_Argument[1].setArgumentValue(Input_2.Y_Values[i]);
                    Math_Argument[2].setArgumentValue(Input_3.Y_Values[i]);
                    Results[i] = mXparser_Math_Expression.calculate();
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
                    Math_Argument[0].setArgumentValue(Input_1.Y_Values[i]);
                    Math_Argument[1].setArgumentValue(Input_2.Y_Values[i]);
                    Results[i] = mXparser_Math_Expression.calculate();
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
                    Math_Argument[0].setArgumentValue(Input_1.Y_Values[i]);
                    Results[i] = mXparser_Math_Expression.calculate();
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
