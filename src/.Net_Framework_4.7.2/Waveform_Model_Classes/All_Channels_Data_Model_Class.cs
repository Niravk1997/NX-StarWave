namespace NX_StarWave.Waveform_Model_Classes
{
    public class All_Channels_Data
    {
        public All_Channels_Data(Channel_Waveform_Data CH1, Channel_Waveform_Data CH2, Channel_Waveform_Data CH3, Channel_Waveform_Data CH4)
        {
            this.CH1 = CH1;
            this.CH2 = CH2;
            this.CH3 = CH3;
            this.CH4 = CH4;
        }

        public Channel_Waveform_Data CH1 { get; set; }
        public Channel_Waveform_Data CH2 { get; set; }
        public Channel_Waveform_Data CH3 { get; set; }
        public Channel_Waveform_Data CH4 { get; set; }
    }
}
