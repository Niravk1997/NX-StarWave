using System.ComponentModel;
using System.Windows.Media;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private Brush Query_Measurement_Config_Window_Selected_ = Brushes.Transparent;
        public Brush Query_Measurement_Config_Window_Selected
        {
            get
            {
                return Query_Measurement_Config_Window_Selected_;
            }
            set
            {
                Query_Measurement_Config_Window_Selected_ = value;
                NotifyPropertyChanged("Query_Measurement_Config_Window_Selected");
            }
        }
    }
}
