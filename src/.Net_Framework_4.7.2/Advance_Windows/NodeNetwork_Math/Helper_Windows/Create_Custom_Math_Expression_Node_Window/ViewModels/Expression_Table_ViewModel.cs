using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Create_Custom_Math_Expression_Node
{
    public class Custom_Math_Expression_Node_Data
    {
        public Custom_Math_Expression_Node_Data(string Expression_Name, string Expression, int Category, string Units, string Background, string Foreground, int Total_Inputs, string Output, string X1, string X2, string X3, string X4, string X5, string X6, string X7)
        {
            this.Expression_Name = Expression_Name;
            this.Expression = Expression;
            this.Category = Category;
            this.Units = Units;
            this.Background = Background;
            this.Foreground = Foreground;
            this.Total_Inputs = Total_Inputs;
            this.Output = Output;
            this.X1 = X1;
            this.X2 = X2;
            this.X3 = X3;
            this.X4 = X4;
            this.X5 = X5;
            this.X6 = X6;
            this.X7 = X7;
        }

        public string Expression_Name { get; set; }
        public string Expression { get; set; }
        public int Category { get; set; }
        public string Units { get; set; }
        public string Background { get; set; }
        public string Foreground { get; set; }
        public int Total_Inputs { get; set; }
        public string Output { get; set; }
        public string X1 { get; set; }
        public string X2 { get; set; }
        public string X3 { get; set; }
        public string X4 { get; set; }
        public string X5 { get; set; }
        public string X6 { get; set; }
        public string X7 { get; set; }
    }

    public partial class Create_Custom_Math_Expression_Window : INotifyPropertyChanged
    {
        private ObservableCollection<Custom_Math_Expression_Node_Data> _Expression_Data = new ObservableCollection<Custom_Math_Expression_Node_Data>();
        public ObservableCollection<Custom_Math_Expression_Node_Data> Expression_Data
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

        private Custom_Math_Expression_Node_Data _Selected_Expression_Data;
        public Custom_Math_Expression_Node_Data Selected_Expression_Data
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
