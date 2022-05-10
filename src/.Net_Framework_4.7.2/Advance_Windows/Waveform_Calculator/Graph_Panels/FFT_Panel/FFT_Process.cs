using MathNet.Numerics.IntegralTransforms;
using System;
using System.Linq;
using System.Numerics;
using System.Windows.Controls;

namespace FFT_Panel
{
    public partial class FFT_Panel : UserControl
    {
        private void Calculate_FFT()
        {
            double SampleRate = Data_Points / Total_Time;
            double FFT_Window_Gain_Correction = 1;

            (bool isWindow, double[] Window_data) = FFT_Window_Array_Generate();

            if (isWindow == true)
            {
                FFT_Window_Gain_Correction = Window_data.Length / Window_data.Sum();
                Apply_FFT_Window(Window_data);
            }

            Complex[] Samples = Create_Complex_Array();

            //Calculate FFT
            Fourier.Forward(Samples, options: FourierOptions.NoScaling);

            //Generate Arrays for Plotting
            Create_FFTs_Arrays(Samples, SampleRate, FFT_Window_Gain_Correction);
        }

        private void Apply_FFT_Window(double[] Window_data)
        {
            for (int i = 0; i < Y_Data.Length; i++)
            {
                Y_Data[i] = Y_Data[i] * Window_data[i];
            }
        }

        private Complex[] Create_Complex_Array()
        {
            Complex[] Samples = new Complex[(Data_Points)];
            for (int i = 0; i < Data_Points; i++)
            {
                Samples[i] = new Complex(Y_Data[i], 0.0);
            }
            return Samples;
        }

        private void Create_FFTs_Arrays(Complex[] Samples, double SampleRate, double FFT_Window_Gain_Correction)
        {
            double[] Magnitude = new double[Samples.Length / 2];
            double[] Frequency = new double[Samples.Length / 2];
            double[] Phase = { 0 };
            if (Show_Phase)
            {
                Phase = new double[Samples.Length / 2];
            }

            if (FFT_Units_dB)
            {
                for (int i = 0; i < (Samples.Length / 2); i++)
                {
                    double Magnitude_Value = 20 * Math.Log10(((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0));
                    Magnitude[i] = Magnitude_Value;
                    Frequency[i] = (SampleRate / Data_Points) * i;
                    if (Show_Phase)
                    {
                        if (Magnitude_Value < Phase_Ignore_Value)
                        {
                            Phase[i] = 0;
                        }
                        else
                        {
                            if (Phase_Units_Degree)
                            {
                                Phase[i] = Samples[i].Phase * (180 / Math.PI);
                            }
                            else
                            {
                                Phase[i] = Samples[i].Phase;
                            }
                        }
                    }
                }
                Phase[0] = 0; //Initial Phase value is set to 0
            }
            else
            {
                for (int i = 0; i < (Samples.Length / 2); i++)
                {
                    Magnitude[i] = ((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0);
                    Frequency[i] = (SampleRate / Data_Points) * i;
                    if (Show_Phase)
                    {
                        double Magnitude_Value = 20 * Math.Log10(((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0));
                        if (Magnitude_Value < Phase_Ignore_Value)
                        {
                            Phase[i] = 0;
                        }
                        else
                        {
                            if (Phase_Units_Degree)
                            {
                                Phase[i] = Samples[i].Phase * (180 / Math.PI);
                            }
                            else
                            {
                                Phase[i] = Samples[i].Phase;
                            }
                        }
                    }
                }
                Phase[0] = 0; //Initial Phase value is set to 0
            }

            //Apply Interpolation if enabled
            if (Apply_Interpolation)
            {
                if (Show_Phase)
                {
                    double[] Throwaway_Array;
                    (Throwaway_Array, Phase) = FFT_Interpolation.Interpolation_Results(Frequency, Phase, Interpolation_Factor, Frequency[0], Frequency[((int)Data_Points / 2) - 1], (int)Data_Points / 2);
                }
                (Frequency, Magnitude) = FFT_Interpolation.Interpolation_Results(Frequency, Magnitude, Interpolation_Factor, Frequency[0], Frequency[((int)Data_Points / 2) - 1], (int)Data_Points / 2);
            }

            this.Magnitude = Magnitude;
            this.Frequency = Frequency;
            if (Show_Phase)
            {
                this.Phase = Phase;
            }
        }

        private (bool, double[]) FFT_Window_Array_Generate()
        {
            switch (FFT_Window)
            {
                case 0:
                    return (false, new double[0]);
                case 1:
                    return (true, MathNet.Numerics.Window.Hamming(Data_Points));
                case 2:
                    return (true, MathNet.Numerics.Window.HammingPeriodic(Data_Points));
                case 3:
                    return (true, MathNet.Numerics.Window.Hann(Data_Points));
                case 4:
                    return (true, MathNet.Numerics.Window.HannPeriodic(Data_Points));
                case 5:
                    return (true, MathNet.Numerics.Window.BlackmanHarris(Data_Points));
                case 6:
                    return (true, MathNet.Numerics.Window.BlackmanNuttall(Data_Points));
                case 7:
                    return (true, MathNet.Numerics.Window.Lanczos(Data_Points));
                case 8:
                    return (true, MathNet.Numerics.Window.LanczosPeriodic(Data_Points));
                case 9:
                    return (true, MathNet.Numerics.Window.Cosine(Data_Points));
                case 10:
                    return (true, MathNet.Numerics.Window.CosinePeriodic(Data_Points));
                case 11:
                    return (true, MathNet.Numerics.Window.Triangular(Data_Points));
                default:
                    return (false, new double[0]);
            }
        }
    }
}
