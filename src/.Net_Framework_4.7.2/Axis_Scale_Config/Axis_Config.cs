using System;

namespace Axis_Scale_Config
{
    public class Axis_Config
    {
        //Readonly char arrays required for Value_SI_Prefix() and Axis_SI_Prefix_Scale()
        private readonly char[] incPrefixes = new[] { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
        private readonly char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

        internal string X_Axis_Units = "s";
        internal string Y_Axis_Units = "V";

        internal string Value_SI_Prefix(double Value, int Round_Value)
        {
            if (Value == double.NaN || Value == double.PositiveInfinity || Value == double.NegativeInfinity)
            {
                return "NaN ";
            }
            else if (Value == 0)
            {
                return Value.ToString() + " ";
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
                    return Math.Round(scaled_Value, Round_Value).ToString() + " " + prefix;
                }
                else
                {
                    return Value.ToString("E2");
                }
            }
        }

        internal string Value_SI_Prefix_NoSafety_NoRounding(double Value)
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
                return scaled_Value.ToString() + prefix;
            }
            else
            {
                return Value.ToString();
            }
        }

        internal string X_Axis_Time_SI_Prefix_Scale(double Value)
        {
            if (Value == 0)
            {
                return "0 " + X_Axis_Units;
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
                    return Math.Round(scaled_Value, 10).ToString() + " " + prefix + X_Axis_Units;
                }
                else
                {
                    return Value.ToString("E2");
                }
            }
        }

        internal string Y_Axis_SI_Prefix_Scale(double Value)
        {
            if (Value == 0)
            {
                return "0 " + Y_Axis_Units;
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
                    return Math.Round(scaled_Value, 10).ToString() + " " + prefix + Y_Axis_Units;
                }
                else
                {
                    return Value.ToString("E2");
                }
            }
        }
    }
}
