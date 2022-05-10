using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Reference_Calculator
{
    public class Expression_Data
    {
        public Expression_Data(bool Expression_Selected, string Expression_Name, string Expression, string Expression_Waveform_Config, string Expression_Histogram_Config, string Expression_FFT_Config)
        {
            this.Expression_Selected = Expression_Selected;
            this.Expression_Name = Expression_Name;
            this.Expression = Expression;
            this.Expression_Waveform_Config = Expression_Waveform_Config;
            this.Expression_Histogram_Config = Expression_Histogram_Config;
            this.Expression_FFT_Config = Expression_FFT_Config;
        }

        public bool Expression_Selected { get; set; }
        public string Expression_Name { get; set; }
        public string Expression { get; set; }
        public string Expression_Waveform_Config { get; set; }
        public string Expression_Histogram_Config { get; set; }
        public string Expression_FFT_Config { get; set; }
    }

    public partial class Reference_Config_Panel : INotifyPropertyChanged
    {
        private ObservableCollection<Expression_Data> _Expression_Data = new ObservableCollection<Expression_Data>();
        public ObservableCollection<Expression_Data> Expression_Data
        {
            get
            {
                return _Expression_Data;
            }
            set
            {
                _Expression_Data = value;
                NotifyPropertyChanged();
            }
        }

        private Expression_Data _Selected_Expression_Data;
        public Expression_Data Selected_Expression_Data
        {
            get
            {
                return _Selected_Expression_Data;
            }
            set
            {
                _Selected_Expression_Data = value;
                NotifyPropertyChanged();

            }
        }
    }
}
