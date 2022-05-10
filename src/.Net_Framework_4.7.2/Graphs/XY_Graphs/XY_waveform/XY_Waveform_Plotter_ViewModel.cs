using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XY_Waveform
{
    public partial class XY_Waveform_Plotter : INotifyPropertyChanged
    {
        private String _Window_Title;
        public String Window_Title
        {
            get { return _Window_Title; }
            set
            {
                _Window_Title = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
