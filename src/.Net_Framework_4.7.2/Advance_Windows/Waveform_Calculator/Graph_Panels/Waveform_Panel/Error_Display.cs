using System.Windows.Controls;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private bool isError = false;
        private int Error_Count_Infinity = 0;
        private int Error_Count_NAN = 0;
        private int Error_Count_Min = 0;
        private int Error_Count_Max = 0;
        private ScottPlot.Plottable.Annotation Error_Annotation;

        private void Initialize_Error_Annotation()
        {
            Error_Annotation = Graph.Plot.AddAnnotation("Error: ", 5, 2);
            Error_Annotation.IsVisible = false;
            Error_Annotation.Font.Size = 14;
            Error_Annotation.Shadow = false;
            Error_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            Error_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            Error_Annotation.Font.Color = System.Drawing.Color.Red;
        }

        private void Show_Hide_Error_Annotation()
        {
            string Error_Messsage = "Error: ";
            if (Error_Count_NAN > 0)
            {
                Error_Messsage = Error_Messsage + "[NAN: " + Error_Count_NAN + "] ";
            }
            if (Error_Count_Infinity > 0)
            {
                Error_Messsage = Error_Messsage + "[Infinity: " + Error_Count_Infinity + "] ";
            }
            if (Error_Count_Min > 0)
            {
                Error_Messsage = Error_Messsage + "[Min: " + Error_Count_Min + "] ";
            }
            if (Error_Count_Max > 0)
            {
                Error_Messsage = Error_Messsage + "[Max: " + Error_Count_Max + "] ";
            }
            Error_Annotation.Label = Error_Messsage;
            Reset_Error_Counters();
            Error_Annotation.IsVisible = true;
        }

        private void Hide_Error_Annotation()
        {
            Error_Annotation.IsVisible = false;
        }

        private void Reset_Error_Counters()
        {
            Error_Count_NAN = 0;
            Error_Count_Infinity = 0;
            Error_Count_Min = 0;
            Error_Count_Max = 0;
        }
    }
}
