using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Histogram
{
    public partial class Histogram_Plotter : INotifyPropertyChanged
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

        private int Total_Bucket_Count_ = 50;
        public int Total_Bucket_Count
        {
            get { return Total_Bucket_Count_; }
            set
            {
                Total_Bucket_Count_ = value;
                NotifyPropertyChanged("Total_Bucket_Count");
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
                    if (Histogram != null)
                    {
                        Histogram.ShowValuesAboveBars = value;
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
