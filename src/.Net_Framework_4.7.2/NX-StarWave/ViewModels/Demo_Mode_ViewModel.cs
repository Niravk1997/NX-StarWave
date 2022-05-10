using System.ComponentModel;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private double Demo_Mode_Speed_Value_ms_ = 300;
        public double Demo_Mode_Speed_Value_ms
        {
            get { return Demo_Mode_Speed_Value_ms_; }
            set
            {
                Demo_Mode_Speed_Value_ms_ = value;
                NotifyPropertyChanged("Demo_Mode_Speed_Value_ms");
            }
        }

        private bool Demo_Mode_Enable_ = false;
        public bool Demo_Mode_Enable
        {
            get { return Demo_Mode_Enable_; }
            set
            {
                Demo_Mode_Enable_ = value;
                NotifyPropertyChanged("Demo_Mode_Enable");
            }
        }
    }
}
