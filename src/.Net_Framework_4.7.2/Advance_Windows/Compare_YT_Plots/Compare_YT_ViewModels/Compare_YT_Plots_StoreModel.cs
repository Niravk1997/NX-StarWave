using ScottPlot.Plottable;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Compare_YT
{
    public class Checked_ListBox_Plottable
    {
        public Checked_ListBox_Plottable(string Name, bool IsChecked, IPlottable Plottable, double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Waveform_Color, double[] X_Values, double[] Y_Values)
        {
            this.Name = Name;
            this.Plottable = Plottable;
            this.IsChecked = IsChecked;
            this.Total_Time = Total_Time;
            this.Start_Time = Start_Time;
            this.Stop_Time = Stop_Time;
            this.Data_Points = Data_Points;
            this.Waveform_Color = Waveform_Color;
            this.X_Values = X_Values;
            this.Y_Values = Y_Values;
        }
        public string Name { get; set; }

        private bool IsChecked_;
        public bool IsChecked
        {
            get
            {
                return IsChecked_;
            }
            set
            {
                IsChecked_ = value;
                Plottable.IsVisible = value;
            }
        }

        public IPlottable Plottable { get; set; }
        public double Total_Time { get; set; }
        public double Start_Time { get; set; }
        public double Stop_Time { get; set; }
        public int Data_Points { get; set; }

        public string Waveform_Color_;
        public string Waveform_Color
        {
            get
            {
                return Waveform_Color_;
            }
            set
            {
                Waveform_Color_ = value;
            }
        }
        public double[] X_Values { get; set; }
        public double[] Y_Values { get; set; }
    }

    public partial class Compare_YT_Plots : INotifyPropertyChanged
    {
        private ObservableCollection<Checked_ListBox_Plottable> _Checked_ListBox_Plottable_Table = new ObservableCollection<Checked_ListBox_Plottable>();
        public ObservableCollection<Checked_ListBox_Plottable> Checked_ListBox_Plottable_Table
        {
            get
            {
                return _Checked_ListBox_Plottable_Table;
            }
            set
            {
                _Checked_ListBox_Plottable_Table = value;
                NotifyPropertyChanged("Checked_ListBox_Plottable_Table");
            }
        }

        private Checked_ListBox_Plottable _Selected_Checked_ListBox_Plottable_Data;
        public Checked_ListBox_Plottable Selected_Checked_ListBox_Plottable_Data
        {
            get
            {
                return _Selected_Checked_ListBox_Plottable_Data;
            }
            set
            {
                _Selected_Checked_ListBox_Plottable_Data = value;
                NotifyPropertyChanged("Selected_Checked_ListBox_Plottable_Data");

            }
        }
    }
}
