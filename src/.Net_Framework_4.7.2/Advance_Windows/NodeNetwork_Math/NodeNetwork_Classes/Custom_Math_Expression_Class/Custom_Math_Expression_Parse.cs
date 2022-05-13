using Node_Model_Classes;
using System;

namespace Custom_Math_Expression_Class
{
    public class Custom_Math_Expression_Parse
    {
        public string Math_Expression { get; set; }

        public int Total_Inputs { get; set; }

        public string Output_Name { get; set; }
        public string Input_1_Name { get; set; }
        public string Input_2_Name { get; set; }
        public string Input_3_Name { get; set; }
        public string Input_4_Name { get; set; }
        public string Input_5_Name { get; set; }
        public string Input_6_Name { get; set; }
        public string Input_7_Name { get; set; }

        private double Max_Value_Allowed_ = 1E+9;
        public double Max_Value_Allowed
        {
            get { return Max_Value_Allowed_; }
            set { Max_Value_Allowed_ = value; }
        }

        private double Min_Value_Allowed_ = -1E+9;
        public double Min_Value_Allowed
        {
            get { return Min_Value_Allowed_; }
            set { Min_Value_Allowed_ = value; }
        }

        public void Set_Expression_Variables(int Total_Inputs, string Math_Expression, string Output_Name, string Input_1_Name = "x1", string Input_2_Name = "x2", string Input_3_Name = "x3", string Input_4_Name = "x4", string Input_5_Name = "x5", string Input_6_Name = "x6", string Input_7_Name = "x7")
        {
            this.Total_Inputs = Total_Inputs;
            this.Math_Expression = Math_Expression;
            this.Output_Name = Output_Name;

            if (Total_Inputs >= 1)
            {
                this.Input_1_Name = Input_1_Name;
            }

            if (Total_Inputs >= 2)
            {
                this.Input_2_Name = Input_2_Name;
            }

            if (Total_Inputs >= 3)
            {
                this.Input_3_Name = Input_3_Name;
            }

            if (Total_Inputs >= 4)
            {
                this.Input_4_Name = Input_4_Name;
            }

            if (Total_Inputs >= 5)
            {
                this.Input_5_Name = Input_5_Name;
            }

            if (Total_Inputs >= 6)
            {
                this.Input_6_Name = Input_6_Name;
            }

            if (Total_Inputs >= 7)
            {
                this.Input_7_Name = Input_7_Name;
            }
        }

        public virtual (bool isValid, string Input_Message, string Output_Message, string Main_Message) Verify_Expression()
        {
            throw new NotImplementedException();
        }

        public virtual string Utilizing_Math_Parser_Library()
        {
            throw new NotImplementedException();
        }

        public void Set_Max_Value_Allowed(double Value)
        {
            Max_Value_Allowed = Value;
        }

        public void Set_Min_Value_Allowed(double Value)
        {
            Min_Value_Allowed = Value;
        }

        public virtual (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4, Node_Waveform_Model Input_5, Node_Waveform_Model Input_6, Node_Waveform_Model Input_7)
        {
            throw new NotImplementedException();
        }

        public virtual (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4, Node_Waveform_Model Input_5, Node_Waveform_Model Input_6)
        {
            throw new NotImplementedException();
        }

        public virtual (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4, Node_Waveform_Model Input_5)
        {
            throw new NotImplementedException();
        }

        public virtual (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3, Node_Waveform_Model Input_4)
        {
            throw new NotImplementedException();
        }

        public virtual (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2, Node_Waveform_Model Input_3)
        {
            throw new NotImplementedException();
        }

        public virtual (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1, Node_Waveform_Model Input_2)
        {
            throw new NotImplementedException();
        }

        public virtual (bool isValid, int Infinity_Count, int NAN_Count, int Min_Count, int Max_Count, string Message, double[] Results) Compute_Expression(Node_Waveform_Model Input_1)
        {
            throw new NotImplementedException();
        }
    }
}
