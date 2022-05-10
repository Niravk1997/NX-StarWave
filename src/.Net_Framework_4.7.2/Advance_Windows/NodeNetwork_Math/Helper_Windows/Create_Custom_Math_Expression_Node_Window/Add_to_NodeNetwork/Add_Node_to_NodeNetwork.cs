using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : MetroWindow
    {
        private void Add_Node_to_NodeNetwork_List_Click(object sender, RoutedEventArgs e)
        {
            if (Expression_Verify())
            {
                Add_Node_to_NodeNetwork_List();
                if (Auto_Save)
                {
                    Expression_Data.Add(new Custom_Math_Expression_Node_Data(Expression_Name, Expression, Category_Select_Index, Units_Text, Node_Background_Color, Node_Foreground_Color, Total_Input_Select_Index, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3, Input_Text_4, Input_Text_5, Input_Text_6, Input_Text_7));
                }

                if (Auto_Clear)
                {
                    Clear_Input_TextFields();
                }
            }
        }

        private void Add_Node_to_NodeNetwork_List()
        {
            try
            {
                NodeNetwork_MainWindow.Add_Custom_Math_Expression_Node_depending_on_Total_Inputs(new Custom_Math_Expression_Node_Data(Expression_Name, Expression, Category_Select_Index, Units_Text, Node_Background_Color, Node_Foreground_Color, Total_Input_Select_Index, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3, Input_Text_4, Input_Text_5, Input_Text_6, Input_Text_7));
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Could not add Node to the NodeNetwork List.", 1);
            }
        }

        private void Clear_Input_TextFields_Click(object sender, RoutedEventArgs e)
        {
            Clear_Input_TextFields();
        }

        private void Clear_Input_TextFields()
        {
            try
            {
                Expression_Name = "";
                Expression = "";
                Category_Select_Index = 3;
                Units_Text = "V";
                Node_Background_Color = "#FF0095FF";
                Node_Foreground_Color = "#FFFFFFFF";
                Total_Input_Select_Index = 0;
                Output_Text = "Output";
                Input_Text_1 = "X1";
                Input_Text_2 = "X2";
                Input_Text_3 = "X3";
                Input_Text_4 = "X4";
                Input_Text_5 = "X5";
                Input_Text_6 = "X6";
                Input_Text_7 = "X7";
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }
    }
}
