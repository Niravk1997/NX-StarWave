using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SCPI_Communication
{
    public class SCPI_Expression_Data
    {
        public SCPI_Expression_Data(bool SCPI_Expression_Selected, string SCPI_Expression_Description, string SCPI_Expression)
        {
            this.SCPI_Expression_Selected = SCPI_Expression_Selected;
            this.SCPI_Expression_Description = SCPI_Expression_Description;
            this.SCPI_Expression = SCPI_Expression;
        }

        public bool SCPI_Expression_Selected { get; set; }
        public string SCPI_Expression_Description { get; set; }
        public string SCPI_Expression { get; set; }
    }

    public partial class SCPI_Communication_Window : INotifyPropertyChanged
    {
        private ObservableCollection<SCPI_Expression_Data> _SCPI_Expression_Table = new ObservableCollection<SCPI_Expression_Data>();
        public ObservableCollection<SCPI_Expression_Data> SCPI_Expression_Table
        {
            get
            {
                return _SCPI_Expression_Table;
            }
            set
            {
                _SCPI_Expression_Table = value;
                NotifyPropertyChanged("SCPI_Expression_Table");
            }
        }

        private SCPI_Expression_Data _Selected_SCPI_Expression_Data;
        public SCPI_Expression_Data Selected_SCPI_Expression_Data
        {
            get
            {
                return _Selected_SCPI_Expression_Data;
            }
            set
            {
                _Selected_SCPI_Expression_Data = value;
                NotifyPropertyChanged("Selected_SCPI_Expression_Data");

            }
        }
    }
}
