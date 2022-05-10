using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private void Expression_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Auto_Load)
            {
                try
                {
                    if (Selected_Expression_Data != null)
                    {
                        string[] Expression_Wavefrom_Config = Selected_Expression_Data.Expression_Waveform_Config.Split(',');
                        string[] Expression_Histogram_Config = Selected_Expression_Data.Expression_Histogram_Config.Split(',');
                        string[] Expression_FFT_Config = Selected_Expression_Data.Expression_FFT_Config.Split(',');
                        Expression_Name = Selected_Expression_Data.Expression_Name;
                        Expression = Selected_Expression_Data.Expression;

                        if (Expression_Wavefrom_Config[0] == "True") { Show_Waveform = true; } else { Show_Waveform = false; }
                        Waveform_Color = Expression_Wavefrom_Config[1];
                        Waveform_YAXIS = Expression_Wavefrom_Config[2];
                        Waveform_YAXIS_Units = Expression_Wavefrom_Config[3];
                        Waveform_Title = Expression_Wavefrom_Config[4];
                        if (Expression_Wavefrom_Config[5] == "True") { Waveform_Continuous = true; } else { Waveform_Continuous = false; }

                        if (Expression_Histogram_Config[0] == "True") { Show_Histogram = true; } else { Show_Histogram = false; }
                        Histogram_Color = Expression_Histogram_Config[1];
                        Histogram_Buckets = int.Parse(Expression_Histogram_Config[2]);
                        if (Expression_Histogram_Config[3] == "True") { Histogram_Continuous = true; } else { Histogram_Continuous = false; }

                        if (Expression_FFT_Config[0] == "True") { Show_FFT = true; } else { Show_FFT = false; }
                        FFT_Color = Expression_FFT_Config[1];
                        if (Expression_FFT_Config[2] == "True") { FFT_Units = true; } else { FFT_Units = false; }
                        FFT_Window = int.Parse(Expression_FFT_Config[3]);
                        if (Expression_FFT_Config[4] == "True") { FFT_Phase = true; } else { FFT_Phase = false; }
                        if (Expression_FFT_Config[5] == "True") { FFT_Phase_Units = true; } else { FFT_Phase_Units = false; }
                        FFT_Phase_Ignore = double.Parse(Expression_FFT_Config[6]);
                        if (Expression_FFT_Config[7] == "True") { FFT_Peaks = true; } else { FFT_Peaks = false; }
                        FFT_Peaks_Reference = double.Parse(Expression_FFT_Config[8]);
                        FFT_Peaks_Size = int.Parse(Expression_FFT_Config[9]);
                        if (Expression_FFT_Config[10] == "True") { FFT_Interpolation_Enable = true; } else { FFT_Interpolation_Enable = false; }
                        FFT_Interpolation_Type_Selected = int.Parse(Expression_FFT_Config[11]);
                        FFT_Interpolation_Factor = int.Parse(Expression_FFT_Config[12]);
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
                    string[] Expression_Wavefrom_Config = Selected_Expression_Data.Expression_Waveform_Config.Split(',');
                    string[] Expression_Histogram_Config = Selected_Expression_Data.Expression_Histogram_Config.Split(',');
                    string[] Expression_FFT_Config = Selected_Expression_Data.Expression_FFT_Config.Split(',');
                    Expression_Name = Selected_Expression_Data.Expression_Name;
                    Expression = Selected_Expression_Data.Expression;

                    if (Expression_Wavefrom_Config[0] == "True") { Show_Waveform = true; } else { Show_Waveform = false; }
                    Waveform_Color = Expression_Wavefrom_Config[1];
                    Waveform_YAXIS = Expression_Wavefrom_Config[2];
                    Waveform_YAXIS_Units = Expression_Wavefrom_Config[3];
                    Waveform_Title = Expression_Wavefrom_Config[4];
                    if (Expression_Wavefrom_Config[5] == "True") { Waveform_Continuous = true; } else { Waveform_Continuous = false; }

                    if (Expression_Histogram_Config[0] == "True") { Show_Histogram = true; } else { Show_Histogram = false; }
                    Histogram_Color = Expression_Histogram_Config[1];
                    Histogram_Buckets = int.Parse(Expression_Histogram_Config[2]);
                    if (Expression_Histogram_Config[3] == "True") { Histogram_Continuous = true; } else { Histogram_Continuous = false; }

                    if (Expression_FFT_Config[0] == "True") { Show_FFT = true; } else { Show_FFT = false; }
                    FFT_Color = Expression_FFT_Config[1];
                    if (Expression_FFT_Config[2] == "True") { FFT_Units = true; } else { FFT_Units = false; }
                    FFT_Window = int.Parse(Expression_FFT_Config[3]);
                    if (Expression_FFT_Config[4] == "True") { FFT_Phase = true; } else { FFT_Phase = false; }
                    if (Expression_FFT_Config[5] == "True") { FFT_Phase_Units = true; } else { FFT_Phase_Units = false; }
                    FFT_Phase_Ignore = double.Parse(Expression_FFT_Config[6]);
                    if (Expression_FFT_Config[7] == "True") { FFT_Peaks = true; } else { FFT_Peaks = false; }
                    FFT_Peaks_Reference = double.Parse(Expression_FFT_Config[8]);
                    FFT_Peaks_Size = int.Parse(Expression_FFT_Config[9]);
                    if (Expression_FFT_Config[10] == "True") { FFT_Interpolation_Enable = true; } else { FFT_Interpolation_Enable = false; }
                    FFT_Interpolation_Type_Selected = int.Parse(Expression_FFT_Config[11]);
                    FFT_Interpolation_Factor = int.Parse(Expression_FFT_Config[12]);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Expression_to_Table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Expression_Verify())
                {
                    Save_Expression_to_Table();
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Expression_to_Table()
        {
            string Expression_Wavefrom_Config = Show_Waveform + "," + Waveform_Color + "," + Waveform_YAXIS + "," + Waveform_YAXIS_Units + "," + Waveform_Title + "," + Waveform_Continuous;
            string Expression_Histogram_Config = Show_Histogram + "," + Histogram_Color + "," + Histogram_Buckets + "," + Histogram_Continuous;
            string Expression_FFT_Config = Show_FFT + "," + FFT_Color + "," + FFT_Units + "," + FFT_Window + "," + FFT_Phase + "," + FFT_Phase_Units + "," + FFT_Phase_Ignore + "," + FFT_Peaks + "," + FFT_Peaks_Reference + "," + FFT_Peaks_Size + "," + FFT_Interpolation_Enable + "," + FFT_Interpolation_Type_Selected + "," + FFT_Interpolation_Factor;
            Expression_Data.Add(new Expression_Data(false, Expression_Name, Expression, Expression_Wavefrom_Config, Expression_Histogram_Config, Expression_FFT_Config));
        }

        private void Update_Selected_Expression_from_Table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Selected_Expression_Data != null)
                {
                    Selected_Expression_Data.Expression_Name = Expression_Name;
                    Selected_Expression_Data.Expression = Expression;
                    Selected_Expression_Data.Expression_Waveform_Config = Show_Waveform + "," + Waveform_Color + "," + Waveform_YAXIS + "," + Waveform_YAXIS_Units + "," + Waveform_Title + "," + Waveform_Continuous;
                    Selected_Expression_Data.Expression_Histogram_Config = Show_Histogram + "," + Histogram_Color + "," + Histogram_Buckets + "," + Histogram_Continuous;
                    Selected_Expression_Data.Expression_FFT_Config = Show_FFT + "," + FFT_Color + "," + FFT_Units + "," + FFT_Window + "," + FFT_Phase + "," + FFT_Phase_Units + "," + FFT_Phase_Ignore + "," + FFT_Peaks + "," + FFT_Peaks_Reference + "," + FFT_Peaks_Size + "," + FFT_Interpolation_Enable + "," + FFT_Interpolation_Type_Selected + "," + FFT_Interpolation_Factor;
                    CollectionViewSource.GetDefaultView(Expression_Data).Refresh();
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        //Sets the Expression Config to default values
        private void Clear_Expression_Config_Click(object sender, RoutedEventArgs e)
        {
            Clear_Expression_Config();
        }

        private void Clear_Expression_Config()
        {
            try
            {
                Expression_Name = "";
                Expression = "";
                Show_Waveform = true;
                Waveform_Color = "#FF0072BD";
                Waveform_YAXIS = "Voltage (V)";
                Waveform_YAXIS_Units = "V";
                Waveform_Title = "Waveform";
                Waveform_Continuous = false;

                Show_Histogram = false;
                Histogram_Color = "#FF0072BD";
                Histogram_Buckets = 50;
                Histogram_Continuous = false;

                Show_FFT = false;
                FFT_Color = "#FF0072BD";
                FFT_Units = false;
                FFT_Window = 0;
                FFT_Phase = false;
                FFT_Phase_Units = false;
                FFT_Phase_Ignore = -35;
                FFT_Peaks = false;
                FFT_Peaks_Reference = -35;
                FFT_Peaks_Size = 2;
                FFT_Interpolation_Enable = false;
                FFT_Interpolation_Type_Selected = 1;
                FFT_Interpolation_Factor = 2;
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }
    }
}
