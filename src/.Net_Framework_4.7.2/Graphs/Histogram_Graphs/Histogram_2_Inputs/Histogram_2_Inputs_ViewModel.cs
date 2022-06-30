using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Histogram_2_Input
{
    public partial class Histogram_2_Input_Window : INotifyPropertyChanged
    {
        private string _Window_Title;
        public string Window_Title
        {
            get { return _Window_Title; }
            set
            {
                _Window_Title = value;
                NotifyPropertyChanged();
            }
        }

        private bool Axis_Auto_ = true;
        public bool Axis_Auto
        {
            get { return Axis_Auto_; }
            set
            {
                Axis_Auto_ = value;
                NotifyPropertyChanged("Axis_Auto");
            }
        }

        private bool Value_above_Bars_ = false;
        public bool Value_above_Bars
        {
            get { return Value_above_Bars_; }
            set
            {
                Value_above_Bars_ = value;
                try
                {
                    if (Histogram_Input_1 != null)
                    {
                        Histogram_Input_1.ShowValuesAboveBars = value;
                    }

                    if (Histogram_Input_2 != null)
                    {
                        Histogram_Input_2.ShowValuesAboveBars = value;
                    }

                    if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
                    {
                        Histogram_Input_1.Font.Color = System.Drawing.Color.White;
                        Histogram_Input_2.Font.Color = System.Drawing.Color.White;
                    }
                    else
                    {
                        Histogram_Input_1.Font.Color = System.Drawing.Color.Black;
                        Histogram_Input_2.Font.Color = System.Drawing.Color.Black;
                    }

                    Graph.Refresh();
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 2);
                }
                NotifyPropertyChanged("Value_above_Bars");
            }
        }

        private string Input_1_Title_;
        public string Input_1_Title
        {
            get { return Input_1_Title_; }
            set
            {
                Input_1_Title_ = value;
                NotifyPropertyChanged("Input_1_Title");
            }
        }

        private string Input_1_Upper_Bound_Text_;
        public string Input_1_Upper_Bound_Text
        {
            get { return Input_1_Upper_Bound_Text_; }
            set
            {
                Input_1_Upper_Bound_Text_ = value;
                NotifyPropertyChanged("Input_1_Upper_Bound_Text");
            }
        }

        private string Input_1_Lower_Bound_Text_;
        public string Input_1_Lower_Bound_Text
        {
            get { return Input_1_Lower_Bound_Text_; }
            set
            {
                Input_1_Lower_Bound_Text_ = value;
                NotifyPropertyChanged("Input_1_Lower_Bound_Text");
            }
        }

        private int Input_1_Bucket_Count_;
        public int Input_1_Bucket_Count
        {
            get { return Input_1_Bucket_Count_; }
            set
            {
                Input_1_Bucket_Count_ = value;
                NotifyPropertyChanged("Input_1_Bucket_Count");
            }
        }

        private string Input_1_Histogram_Color_ = "#ff8c00";
        public string Input_1_Histogram_Color
        {
            get { return Input_1_Histogram_Color_; }
            set
            {
                Input_1_Histogram_Color_ = value;
                try
                {
                    if (Histogram_Input_1 != null)
                    {
                        Histogram_Input_1.FillColor = System.Drawing.ColorTranslator.FromHtml(value);
                        Graph.Refresh();
                    }
                }
                catch (Exception)
                {

                }
                NotifyPropertyChanged("Input_1_Histogram_Color");
            }
        }

        private string Input_2_Title_;
        public string Input_2_Title
        {
            get { return Input_2_Title_; }
            set
            {
                Input_2_Title_ = value;
                NotifyPropertyChanged("Input_2_Title");
            }
        }

        private string Input_2_Upper_Bound_Text_;
        public string Input_2_Upper_Bound_Text
        {
            get { return Input_2_Upper_Bound_Text_; }
            set
            {
                Input_2_Upper_Bound_Text_ = value;

                NotifyPropertyChanged("Input_2_Upper_Bound_Text");
            }
        }

        private string Input_2_Lower_Bound_Text_;
        public string Input_2_Lower_Bound_Text
        {
            get { return Input_2_Lower_Bound_Text_; }
            set
            {
                Input_2_Lower_Bound_Text_ = value;
                NotifyPropertyChanged("Input_2_Lower_Bound_Text");
            }
        }

        private int Input_2_Bucket_Count_;
        public int Input_2_Bucket_Count
        {
            get { return Input_2_Bucket_Count_; }
            set
            {
                Input_2_Bucket_Count_ = value;
                NotifyPropertyChanged("Input_2_Bucket_Count");
            }
        }

        private string Input_2_Histogram_Color_ = "#ff8c00";
        public string Input_2_Histogram_Color
        {
            get { return Input_2_Histogram_Color_; }
            set
            {
                Input_2_Histogram_Color_ = value;
                try
                {
                    if (Histogram_Input_2 != null)
                    {
                        Histogram_Input_2.FillColor = System.Drawing.ColorTranslator.FromHtml(value);
                        Graph.Refresh();
                    }
                }
                catch (Exception)
                {

                }
                NotifyPropertyChanged("Input_2_Histogram_Color");
            }
        }

        private string Draw_Mode_Custom_Selected_Color_ = "#ff8c00";
        public string Draw_Mode_Custom_Selected_Color
        {
            get { return Draw_Mode_Custom_Selected_Color_; }
            set
            {
                Draw_Mode_Custom_Selected_Color_ = value;
                Draw_Mode_Tool_Tip_Custom_Color_Set(value);
                NotifyPropertyChanged("Draw_Mode_Custom_Selected_Color");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
