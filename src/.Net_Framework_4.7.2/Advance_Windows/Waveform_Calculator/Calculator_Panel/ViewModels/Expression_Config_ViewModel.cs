using System.ComponentModel;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : INotifyPropertyChanged
    {
        private string _Expression = "";
        public string Expression
        {
            get { return _Expression; }
            set
            {
                _Expression = value;
                NotifyPropertyChanged();
            }
        }

        private string _Expression_Name = "";
        public string Expression_Name
        {
            get { return _Expression_Name; }
            set
            {
                _Expression_Name = value;
                NotifyPropertyChanged();
            }
        }
    }
}
