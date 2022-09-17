using System;

namespace Axis_Scale_Config
{
    public class Normalized_Axis_Config
    {
        //Readonly char arrays required for Value_SI_Prefix() and Axis_SI_Prefix_Scale()
        private readonly char[] incPrefixes = new[] { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
        private readonly char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

        internal string Axis_Units = "";

        public double Original_Data_Range_Maximum_Value { get; set; }
        public double Original_Data_Range_Minimum_Value { get; set; }

        public double Normalized_Data_Range_Maximum_Value { get; set; }
        public double Normalized_Data_Range_Minimum_Value { get; set; }

        public int Round_Value { get; set; }

        public Normalized_Axis_Config(string Axis_Units, int Round_Value)
        {
            this.Axis_Units = Axis_Units;
            this.Round_Value = Round_Value;
        }

        internal double Original_Value_to_Normalize_Value(double Value)
        {
            return (((Value - Original_Data_Range_Minimum_Value) / (Original_Data_Range_Maximum_Value - Original_Data_Range_Minimum_Value)) * (Normalized_Data_Range_Maximum_Value - Normalized_Data_Range_Minimum_Value)) + Normalized_Data_Range_Minimum_Value;
        }

        internal double Normalize_Value_to_Original_Value(double Value)
        {
            return (((Value - Normalized_Data_Range_Minimum_Value) / (Normalized_Data_Range_Maximum_Value - Normalized_Data_Range_Minimum_Value)) * (Original_Data_Range_Maximum_Value - Original_Data_Range_Minimum_Value)) + Original_Data_Range_Minimum_Value;
        }

        internal string SI_Prefix_Scale_Value(double Value, string Axis_Units)
        {
            if (Value == 0)
            {
                return "0 " + Axis_Units;
            }
            else
            {
                int degree = (int)Math.Floor(Math.Log10(Math.Abs(Value)) / 3);
                if (degree >= -8 & degree <= 8)
                {
                    double scaled_Value = Value * Math.Pow(1000, -degree);
                    char? prefix = null;
                    switch (Math.Sign(degree))
                    {
                        case 1: prefix = incPrefixes[degree - 1]; break;
                        case -1: prefix = decPrefixes[-degree - 1]; break;
                    }
                    return Math.Round(scaled_Value, Round_Value).ToString() + " " + prefix + Axis_Units;
                }
                else
                {
                    return Value.ToString("E2");
                }
            }
        }

        internal string Axis_SI_Prefix_Scale(double Value)
        {
            return SI_Prefix_Scale_Value(Normalize_Value_to_Original_Value(Value), Axis_Units);
        }
    }
}
