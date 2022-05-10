using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Query_Measurements_Config
{
    public class SCPI_Command_Data
    {
        public SCPI_Command_Data(bool SCPI_Command_Selected, string SCPI_Command_Title, string SCPI_Command, string Result_Start_Cut_String, string Result_Stop_Cut_String, string Measurement_units, double Query_Delay, string Text_Color, bool isBackground_Transparent, string Background_Color)
        {
            this.SCPI_Command_Selected = SCPI_Command_Selected;
            this.SCPI_Command_Title = SCPI_Command_Title;
            this.SCPI_Command = SCPI_Command;
            this.Result_Start_Cut_String = Result_Start_Cut_String;
            this.Result_Stop_Cut_String = Result_Stop_Cut_String;
            this.Measurement_units = Measurement_units;
            this.Query_Delay = Query_Delay;
            this.Text_Color = Text_Color;
            this.isBackground_Transparent = isBackground_Transparent;
            this.Background_Color = Background_Color;
        }

        public bool SCPI_Command_Selected { get; set; }
        public string SCPI_Command_Title { get; set; }
        public string SCPI_Command { get; set; }
        public string Result_Start_Cut_String { get; set; }
        public string Result_Stop_Cut_String { get; set; }
        public string Measurement_units { get; set; }
        public double Query_Delay { get; set; }
        public string Text_Color { get; set; }
        public bool isBackground_Transparent { get; set; }
        public string Background_Color { get; set; }
    }

    public partial class Query_Measurement_Config_Window : INotifyPropertyChanged
    {
        private ObservableCollection<SCPI_Command_Data> _SCPI_Command_Table = new ObservableCollection<SCPI_Command_Data>();
        public ObservableCollection<SCPI_Command_Data> SCPI_Command_Table
        {
            get
            {
                return _SCPI_Command_Table;
            }
            set
            {
                _SCPI_Command_Table = value;
                NotifyPropertyChanged("SCPI_Command_Table");
            }
        }

        private SCPI_Command_Data _Selected_SCPI_Command_Data;
        public SCPI_Command_Data Selected_SCPI_Command_Data
        {
            get
            {
                return _Selected_SCPI_Command_Data;
            }
            set
            {
                _Selected_SCPI_Command_Data = value;
                NotifyPropertyChanged("Selected_SCPI_Command_Data");

            }
        }
    }
}
