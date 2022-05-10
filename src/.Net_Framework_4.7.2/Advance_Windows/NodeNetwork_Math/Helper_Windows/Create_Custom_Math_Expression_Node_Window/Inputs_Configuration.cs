using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : MetroWindow
    {
        private bool Check_if_Expression_contains_Proper_Inputs(int Total_Input)
        {
            List<string> Inputs = new List<string>();
            switch (Total_Input)
            {
                case 0:
                    Inputs.Add(Input_Text_1);
                    return Inputs.All(s => Expression.Contains(s));
                case 1:
                    Inputs.Add(Input_Text_1);
                    Inputs.Add(Input_Text_2);
                    return Inputs.All(s => Expression.Contains(s));
                case 2:
                    Inputs.Add(Input_Text_1);
                    Inputs.Add(Input_Text_2);
                    Inputs.Add(Input_Text_3);
                    return Inputs.All(s => Expression.Contains(s));
                case 3:
                    Inputs.Add(Input_Text_1);
                    Inputs.Add(Input_Text_2);
                    Inputs.Add(Input_Text_3);
                    Inputs.Add(Input_Text_4);
                    return Inputs.All(s => Expression.Contains(s));
                case 4:
                    Inputs.Add(Input_Text_1);
                    Inputs.Add(Input_Text_2);
                    Inputs.Add(Input_Text_3);
                    Inputs.Add(Input_Text_4);
                    Inputs.Add(Input_Text_5);
                    return Inputs.All(s => Expression.Contains(s));
                case 5:
                    Inputs.Add(Input_Text_1);
                    Inputs.Add(Input_Text_2);
                    Inputs.Add(Input_Text_3);
                    Inputs.Add(Input_Text_4);
                    Inputs.Add(Input_Text_5);
                    Inputs.Add(Input_Text_6);
                    return Inputs.All(s => Expression.Contains(s));
                case 6:
                    Inputs.Add(Input_Text_1);
                    Inputs.Add(Input_Text_2);
                    Inputs.Add(Input_Text_3);
                    Inputs.Add(Input_Text_4);
                    Inputs.Add(Input_Text_5);
                    Inputs.Add(Input_Text_6);
                    Inputs.Add(Input_Text_7);
                    return Inputs.All(s => Expression.Contains(s));
                default:
                    return false;
            }
        }

        private void Inputs_Disable(int Total_Inputs)
        {
            if (Total_Inputs >= 0)
            {
                Input_Text_1_IsEnabled = true;
            }
            else
            {
                Input_Text_1_IsEnabled = false;
            }

            if (Total_Inputs >= 1)
            {
                Input_Text_2_IsEnabled = true;
            }
            else
            {
                Input_Text_2_IsEnabled = false;
            }

            if (Total_Inputs >= 2)
            {
                Input_Text_3_IsEnabled = true;
            }
            else
            {
                Input_Text_3_IsEnabled = false;
            }

            if (Total_Inputs >= 3)
            {
                Input_Text_4_IsEnabled = true;
            }
            else
            {
                Input_Text_4_IsEnabled = false;
            }

            if (Total_Inputs >= 4)
            {
                Input_Text_5_IsEnabled = true;
            }
            else
            {
                Input_Text_5_IsEnabled = false;
            }

            if (Total_Inputs >= 5)
            {
                Input_Text_6_IsEnabled = true;
            }
            else
            {
                Input_Text_6_IsEnabled = false;
            }

            if (Total_Inputs >= 6)
            {
                Input_Text_7_IsEnabled = true;
            }
            else
            {
                Input_Text_7_IsEnabled = false;
            }
        }
    }
}
