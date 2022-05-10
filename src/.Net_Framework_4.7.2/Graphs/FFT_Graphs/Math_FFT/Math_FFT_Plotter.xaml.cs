using NX_StarWave.Waveform_Model_Classes;
using System.Collections.Concurrent;
using System.Windows;

namespace Math_FFT
{
    public partial class Math_FFT_Plotter : Window
    {
        //Waveform data is initially stored here unitl it is removed, processed and displayed on the graph window
        public BlockingCollection<All_Channels_Data> All_Channels_Data_Queue = new BlockingCollection<All_Channels_Data>();

        public Math_FFT_Plotter(string y, string x)
        {
            InitializeComponent();
        }
    }
}
