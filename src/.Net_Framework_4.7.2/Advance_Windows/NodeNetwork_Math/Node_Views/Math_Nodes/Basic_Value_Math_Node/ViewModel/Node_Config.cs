using NodeNetwork_Math;
using ReactiveUI;
using System.Windows.Input;
using System.Windows.Media;

namespace Basic_ValueMath_Node
{
    public partial class Basic_ValueMath_ViewModel : Node_ViewModel
    {
        private Brush Config_ICON_Background_Color_ = Brushes.Transparent;
        public Brush Config_ICON_Background_Color
        {
            get => Config_ICON_Background_Color_;
            set => this.RaiseAndSetIfChanged(ref Config_ICON_Background_Color_, value);
        }

        public ICommand Show_Config_Options_Command { get; private set; }

        private void Show_Config_Options()
        {
            if (Node_Config_Options_Visibility == System.Windows.Visibility.Visible)
            {
                Config_ICON_Background_Color = Brushes.Transparent;
                Node_Config_Options_Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                Config_ICON_Background_Color = Brushes.LimeGreen;
                Node_Config_Options_Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
