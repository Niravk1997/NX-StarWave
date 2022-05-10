using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush SCPI_Communication_Window_Selected_ = Brushes.Transparent;
        public Brush SCPI_Communication_Window_Selected
        {
            get
            {
                return SCPI_Communication_Window_Selected_;
            }
            set
            {
                SCPI_Communication_Window_Selected_ = value;
                NotifyPropertyChanged("SCPI_Communication_Window_Selected");
            }
        }
    }
}
