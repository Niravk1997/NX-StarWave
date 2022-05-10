namespace NX_StarWave.Misc
{
    public class Helpful_Functions
    {
        //converts a string into a number
        internal (bool, double) Text_Num(string text, bool allowNegative, bool isInteger)
        {
            if (isInteger == true)
            {
                bool isValid = int.TryParse(text, out int value);
                if (isValid == true)
                {
                    if (allowNegative == false)
                    {
                        if (value < 0)
                        {
                            return (false, 0);
                        }
                        else
                        {
                            return (true, value);
                        }
                    }
                    else
                    {
                        return (true, value);
                    }
                }
                else
                {
                    return (false, 0);
                }
            }
            else
            {
                bool isValid = double.TryParse(text, out double value);
                if (isValid == true)
                {
                    if (allowNegative == false)
                    {
                        if (value < 0)
                        {
                            return (false, 0);
                        }
                        else
                        {
                            return (true, value);
                        }
                    }
                    else
                    {
                        return (true, value);
                    }
                }
                else
                {
                    return (false, 0);
                }
            }
        }

        internal double[] Copy_Array(double[] Old_Array, int Length)
        {
            double[] New_Array = new double[Length];
            System.Array.Copy(Old_Array, New_Array, Length);
            return New_Array;
        }

        internal double[] Linspace(double Start_Value, double Stop_Value, int Length)
        {
            double Step = (Stop_Value - Start_Value) / (Length - 1.00);
            double[] Array = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                Array[i] = Start_Value + Step * i;
            }
            return Array;
        }
    }
}
