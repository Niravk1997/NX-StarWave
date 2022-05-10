using NX_StarWave.Waveform_Model_Classes;
using System.Collections.Concurrent;
using System.Windows;

namespace Math_YT
{
    public partial class Math_YT_Plotter : Window
    {
        //Waveform data is initially stored here unitl it is removed, processed and displayed on the graph window
        public BlockingCollection<All_Channels_Data> All_Channels_Data_Queue = new BlockingCollection<All_Channels_Data>();

        public Math_YT_Plotter(string y, string x)
        {
            InitializeComponent();
        }
    }
}
