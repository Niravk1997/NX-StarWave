using System;

namespace Averaging
{
    public class Waveform_Averaging
    {
        private int Average_Value;
        private int Waveform_Length;
        private int Waveforms_Count;

        private double[,] X_Waveforms;
        private double[,] Y_Waveforms;

        private bool Waveform_Count_Reached = false;

        private void Waveform_2D_Array_Initialize(int Average_Value, int Waveform_Length)
        {
            X_Waveforms = new double[Average_Value, Waveform_Length];
            Y_Waveforms = new double[Average_Value, Waveform_Length];
        }

        public void Add_Waveform_to_Waveform_2D_Array(double[] Waveform_X_Values, double[] Waveform_Y_Values, int Waveform_Length, int Average_Value)
        {
            if (this.Waveform_Length != Waveform_Length || this.Average_Value != Average_Value)
            {
                this.Waveform_Length = Waveform_Length;
                this.Average_Value = Average_Value;
                Waveforms_Count = 0;
                Waveform_Count_Reached = false;
                Waveform_2D_Array_Initialize(this.Average_Value, this.Waveform_Length);
            }
            if (Waveforms_Count == this.Average_Value)
            {
                Waveform_Count_Reached = true;
                Waveforms_Count = 0;
            }
            for (int i = 0; i < this.Waveform_Length; i++)
            {
                X_Waveforms[Waveforms_Count, i] = Waveform_X_Values[i];
                Y_Waveforms[Waveforms_Count, i] = Waveform_Y_Values[i];
            }
            Waveforms_Count++;
        }

        public (double[] Waveform_X_Axis, double[] Waveform_Y_Axis) Averaged_Waveform()
        {
            int Total_Waveforms = 0;
            if (Waveform_Count_Reached)
            {
                Total_Waveforms = Average_Value;
            }
            else
            {
                Total_Waveforms = Waveforms_Count;
            }
            double[] X_Waveform_Averaged = new double[Waveform_Length];
            double[] Y_Waveform_Averaged = new double[Waveform_Length];
            double X_Average_Value = 0;
            double Y_Average_Value = 0;
            for (int i = 0; i < Waveform_Length; i++)
            {
                for (int j = 0; j < Total_Waveforms; j++)
                {
                    X_Average_Value += X_Waveforms[j, i];
                    Y_Average_Value += Y_Waveforms[j, i];
                }
                X_Waveform_Averaged[i] = (X_Average_Value / Total_Waveforms);
                Y_Waveform_Averaged[i] = (Y_Average_Value / Total_Waveforms);
                X_Average_Value = 0;
                Y_Average_Value = 0;
            }
            return (X_Waveform_Averaged, Y_Waveform_Averaged);
        }

        public void Reset()
        {
            try
            {
                Waveforms_Count = 0;
                Waveform_Length = 0;
                Average_Value = 0;
                Waveform_Count_Reached = false;
                X_Waveforms = null;
                Y_Waveforms = null;
            }
            catch (Exception)
            {

            }
        }
    }
}
