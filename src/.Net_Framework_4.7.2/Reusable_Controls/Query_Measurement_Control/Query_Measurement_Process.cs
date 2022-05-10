using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;

namespace Query_Measurement_Control
{
    public partial class Query_Measurement_Window : MetroWindow
    {
        //All Measurements are stored here.
        private List<(double Measurement, double DateTime_Value)> Measurements = new List<(double Measurement, double DateTime_Value)>();

        private double Current_Measurement = 0;
        private double Min_Value = double.MaxValue;
        private double Max_Value = double.MinValue;

        private double Max_Value_Allowed = 1E+9;
        private double Min_Value_Allowed = -1E+9;

        private int Main_Measurement_RoundValue = 6;
        private int Measurement_RoundValue = 6;
        private string Measurement_Units = "";

        private string Output_Result_String_Cut_Start = "";
        private string Output_Result_String_Cut_Stop = "";
        private bool isRequired_Output_Result_String_Cut_Start = false;
        private bool isRequired_Output_Result_String_Cut_Stop = false;
        private int Output_Result_String_Cut_Start_Length = 0;
        private int Output_Result_String_Cut_Stop_Length = 0;

        public void SCPI_Measurement_Process(string SCPI_Data)
        {
            if (isRequired_Output_Result_String_Cut_Start & isRequired_Output_Result_String_Cut_Stop)
            {
                string Data = String_Search_Start_and_Stop(SCPI_Data);
                SCPI_String_to_Value(Data);
            }
            else if (isRequired_Output_Result_String_Cut_Start)
            {
                string Data = String_Search_Start_only(SCPI_Data);
                SCPI_String_to_Value(Data);
            }
            else if (isRequired_Output_Result_String_Cut_Stop)
            {
                string Data = String_Search_Stop_only(SCPI_Data);
                SCPI_String_to_Value(Data);
            }
            else
            {
                SCPI_String_to_Value(SCPI_Data);
            }
        }

        private string String_Search_Start_and_Stop(string String_Data)
        {
            int string_startIndex = String_Data.IndexOf(Output_Result_String_Cut_Start) + Output_Result_String_Cut_Start_Length;
            int string_stopIndex = String_Data.IndexOf(Output_Result_String_Cut_Stop, string_startIndex);
            return String_Data.Substring(string_startIndex, string_stopIndex - string_startIndex).Trim();
        }

        private string String_Search_Start_only(string String_Data)
        {
            int string_startIndex = String_Data.IndexOf(Output_Result_String_Cut_Start) + Output_Result_String_Cut_Start_Length;
            return String_Data.Substring(string_startIndex, String_Data.Length - string_startIndex).Trim();
        }

        private string String_Search_Stop_only(string String_Data)
        {
            int string_stopIndex = String_Data.IndexOf(Output_Result_String_Cut_Stop, 0);
            return String_Data.Substring(0, string_stopIndex).Trim();
        }

        private void SCPI_String_to_Value(string SCPI_Data)
        {
            bool isValid = double.TryParse(SCPI_Data, out double Measurement_Value);
            if (isValid)
            {
                if (double.IsNaN(Measurement_Value) || double.IsInfinity(Measurement_Value) || Measurement_Value <= Min_Value_Allowed || Measurement_Value >= Max_Value_Allowed)
                {
                    if (double.IsNaN(Measurement_Value))
                    {
                        Measurement = "Error, NAN";
                    }
                    else if (double.IsInfinity(Measurement_Value))
                    {
                        Measurement = "Error, Infinity";
                    }
                    else if (Measurement_Value < Min_Value_Allowed)
                    {
                        Measurement = "Error, Min Limit";
                    }
                    else if (Measurement_Value > Max_Value_Allowed)
                    {
                        Measurement = "Error, Max Limit";
                    }
                }
                else
                {
                    Measurements.Add((Measurement_Value, DateTime.Now.ToOADate()));
                    Current_Measurement = Measurement_Value;
                    Measurement = Axis_Scale_Config.Value_SI_Prefix(Measurement_Value, Main_Measurement_RoundValue) + Measurement_Units;
                    if (Measurement_Value < Min_Value)
                    {
                        Min_Value = Measurement_Value;
                        Measurement_Min = Axis_Scale_Config.Value_SI_Prefix(Min_Value, Measurement_RoundValue) + Measurement_Units;
                    }
                    if (Measurement_Value > Max_Value)
                    {
                        Max_Value = Measurement_Value;
                        Measurement_Max = Axis_Scale_Config.Value_SI_Prefix(Max_Value, Measurement_RoundValue) + Measurement_Units;
                    }
                }
            }
            else
            {
                Measurement = "Error, NAN";
            }
        }
    }
}
