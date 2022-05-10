using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : MetroWindow
    {
        private void Expression_Save_to_Table_Click(object sender, RoutedEventArgs e)
        {
            Expression_Save_to_Table();
        }

        private void Expression_Save_to_Table()
        {
            if (Expression_Verify())
            {
                try
                {
                    Expression_Data.Add(new Custom_Math_Expression_Node_Data(Expression_Name, Expression, Category_Select_Index, Units_Text, Node_Background_Color, Node_Foreground_Color, Total_Input_Select_Index, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3, Input_Text_4, Input_Text_5, Input_Text_6, Input_Text_7));
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 1);
                }
            };
        }

        private void Expression_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Auto_Load)
            {
                try
                {
                    if (Selected_Expression_Data != null)
                    {
                        Expression = Selected_Expression_Data.Expression;
                        Expression_Name = Selected_Expression_Data.Expression_Name;
                        Category_Select_Index = Selected_Expression_Data.Category;
                        Units_Text = Selected_Expression_Data.Units;
                        Total_Input_Select_Index = Selected_Expression_Data.Total_Inputs;
                        Input_Text_1 = Selected_Expression_Data.X1;
                        Input_Text_2 = Selected_Expression_Data.X2;
                        Input_Text_3 = Selected_Expression_Data.X3;
                        Input_Text_4 = Selected_Expression_Data.X4;
                        Input_Text_5 = Selected_Expression_Data.X5;
                        Input_Text_6 = Selected_Expression_Data.X6;
                        Input_Text_7 = Selected_Expression_Data.X7;
                        Output_Text = Selected_Expression_Data.Output;
                        Node_Background_Color = Selected_Expression_Data.Background;
                        Node_Foreground_Color = Selected_Expression_Data.Foreground;
                    }
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 1);
                }
            }
        }

        private void Expression_Load_Selected_Mouse_Double_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Selected_Expression_Data != null)
                {
                    Expression = Selected_Expression_Data.Expression;
                    Expression_Name = Selected_Expression_Data.Expression_Name;
                    Category_Select_Index = Selected_Expression_Data.Category;
                    Units_Text = Selected_Expression_Data.Units;
                    Total_Input_Select_Index = Selected_Expression_Data.Total_Inputs;
                    Input_Text_1 = Selected_Expression_Data.X1;
                    Input_Text_2 = Selected_Expression_Data.X2;
                    Input_Text_3 = Selected_Expression_Data.X3;
                    Input_Text_4 = Selected_Expression_Data.X4;
                    Input_Text_5 = Selected_Expression_Data.X5;
                    Input_Text_6 = Selected_Expression_Data.X6;
                    Input_Text_7 = Selected_Expression_Data.X7;
                    Output_Text = Selected_Expression_Data.Output;
                    Node_Background_Color = Selected_Expression_Data.Background;
                    Node_Foreground_Color = Selected_Expression_Data.Foreground;
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Update_Selected_Expression_from_Table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Selected_Expression_Data != null)
                {
                    Selected_Expression_Data.Expression_Name = Expression_Name;
                    Selected_Expression_Data.Expression = Expression;
                    Selected_Expression_Data.Category = Category_Select_Index;
                    Selected_Expression_Data.Units = Units_Text;
                    Selected_Expression_Data.Background = Node_Background_Color;
                    Selected_Expression_Data.Foreground = Node_Foreground_Color;
                    Selected_Expression_Data.Total_Inputs = Total_Input_Select_Index;
                    Selected_Expression_Data.Output = Output_Text;
                    Selected_Expression_Data.X1 = Input_Text_1;
                    Selected_Expression_Data.X2 = Input_Text_2;
                    Selected_Expression_Data.X3 = Input_Text_3;
                    Selected_Expression_Data.X4 = Input_Text_4;
                    Selected_Expression_Data.X5 = Input_Text_5;
                    Selected_Expression_Data.X6 = Input_Text_6;
                    Selected_Expression_Data.X7 = Input_Text_7;
                    CollectionViewSource.GetDefaultView(Expression_Data).Refresh();
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }
    }
}
