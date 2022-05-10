using System.Collections.Generic;

namespace NX_StarWave.Waveform_Model_Classes
{
    public class Waveform_Data
    {
        public Waveform_Data(bool data_valid, string WFMPre, List<byte> Curve)
        {
            this.data_valid = data_valid;
            this.WFMPre = WFMPre;
            this.Curve = Curve;
        }

        public bool data_valid { get; set; }
        public string WFMPre { get; set; }
        public List<byte> Curve { get; set; }
    }
}
