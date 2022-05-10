using MahApps.Metro.Controls;
using System.Windows;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private void Math_Expression_Calculate_Click(object sender, RoutedEventArgs e)
        {
            string Expression_Wavefrom_Config = Show_Waveform + "," + Waveform_Color + "," + Waveform_YAXIS + "," + Waveform_YAXIS_Units + "," + Waveform_Title + "," + Waveform_Continuous;
            string Expression_Histogram_Config = Show_Histogram + "," + Histogram_Color + "," + Histogram_Buckets + "," + Histogram_Continuous;
            string Expression_FFT_Config = Show_FFT + "," + FFT_Color + "," + FFT_Units + "," + FFT_Window + "," + FFT_Phase + "," + FFT_Phase_Units + "," + FFT_Phase_Ignore + "," + FFT_Peaks + "," + FFT_Peaks_Reference + "," + FFT_Peaks_Size + "," + FFT_Interpolation_Enable + "," + FFT_Interpolation_Type_Selected + "," + FFT_Interpolation_Factor;
            Expression_Data expression = new Expression_Data(false, Expression_Name, Expression, Expression_Wavefrom_Config, Expression_Histogram_Config, Expression_FFT_Config);
            if (Verify_Math_Expression(expression))
            {
                Math_Expressions_Stored.Add(expression);
                if (Auto_Save)
                {
                    Save_Expression_to_Table();
                }
                if (Auto_Clear)
                {
                    Clear_Expression_Config();
                }
            }
            else
            {
                insert_Log("Expression cannot be calculated.", 1);
            }
        }
    }
}
