using System.ComponentModel;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : INotifyPropertyChanged
    {
        private string _Expression = "";
        public string Expression
        {
            get { return _Expression; }
            set
            {
                _Expression = value;
                NotifyPropertyChanged("Expression");
            }
        }

        private string _Expression_Name = "";
        public string Expression_Name
        {
            get { return _Expression_Name; }
            set
            {
                _Expression_Name = value;
                NotifyPropertyChanged("Expression_Name");
            }
        }

        private string Units_Text_ = "V";
        public string Units_Text
        {
            get { return Units_Text_; }
            set
            {
                Units_Text_ = value;
                NotifyPropertyChanged("Units_Text");
            }
        }

        private string Output_Text_ = "Output";
        public string Output_Text
        {
            get { return Output_Text_; }
            set
            {
                Output_Text_ = value;
                NotifyPropertyChanged("Output_Text");
            }
        }

        private int Category_Select_Index_ = 3;
        public int Category_Select_Index
        {
            get { return Category_Select_Index_; }
            set
            {
                Category_Select_Index_ = value;
                NotifyPropertyChanged("Category_Select_Index");
            }
        }

        private int Total_Input_Select_Index_ = 0;
        public int Total_Input_Select_Index
        {
            get { return Total_Input_Select_Index_; }
            set
            {
                Total_Input_Select_Index_ = value;
                Inputs_Disable(value);
                NotifyPropertyChanged("Total_Input_Select_Index");
            }
        }

        private bool Enable_Write_to_Textfields_ = true;
        public bool Enable_Write_to_Textfields
        {
            get { return Enable_Write_to_Textfields_; }
            set
            {
                Enable_Write_to_Textfields_ = value;
                NotifyPropertyChanged("Enable__Write_to_Textfields");
            }
        }

        private bool Expression_Verify_in_Progress_ = false;
        public bool Expression_Verify_in_Progress
        {
            get { return Expression_Verify_in_Progress_; }
            set
            {
                Expression_Verify_in_Progress_ = value;
                if (value)
                {
                    Enable_Write_to_Textfields = false;
                }
                else
                {
                    Enable_Write_to_Textfields = true;
                }
                NotifyPropertyChanged("Expression_Verify_in_Progress");
            }
        }
    }
}
