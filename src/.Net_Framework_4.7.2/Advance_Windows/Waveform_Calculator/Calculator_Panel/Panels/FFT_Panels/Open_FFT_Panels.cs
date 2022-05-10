using AvalonDock.Layout;
using MahApps.Metro.Controls;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private LayoutAnchorable FFT_Layout_1;
        private LayoutAnchorable FFT_Layout_2;
        private LayoutAnchorable FFT_Layout_3;
        private LayoutAnchorable FFT_Layout_4;
        private LayoutAnchorable FFT_Layout_5;

        private FFT_Panel.FFT_Panel FFT_Panel_1;
        private FFT_Panel.FFT_Panel FFT_Panel_2;
        private FFT_Panel.FFT_Panel FFT_Panel_3;
        private FFT_Panel.FFT_Panel FFT_Panel_4;
        private FFT_Panel.FFT_Panel FFT_Panel_5;

        private double FFT_Panel_FloatingWidth = 450;
        private double FFT_Panel_FloatingHeight = 350;

        private void Open_FFT_Panel(Expression_Data Expression)
        {
            if (FFT_Layout_1 == null & FFT_Panel_1 == null)
            {
                FFT_Panel_1 = new FFT_Panel.FFT_Panel(Expression);
                FFT_Layout_1 = new LayoutAnchorable()
                {
                    Title = "FFT: " + Expression.Expression_Name,
                    Content = FFT_Panel_1,
                    FloatingWidth = FFT_Panel_FloatingWidth,
                    FloatingHeight = FFT_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                FFT_Layout_1.Closed += Close_FFT_Layout_1;
                FFT_Layout_1.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                FFT_Layout_1.Float();
                insert_Log("FFT Panel 1: " + Expression.Expression_Name, 5);
            }
            else if (FFT_Layout_2 == null & FFT_Panel_2 == null)
            {
                FFT_Panel_2 = new FFT_Panel.FFT_Panel(Expression);
                FFT_Layout_2 = new LayoutAnchorable()
                {
                    Title = "FFT: " + Expression.Expression_Name,
                    Content = FFT_Panel_2,
                    FloatingWidth = FFT_Panel_FloatingWidth,
                    FloatingHeight = FFT_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                FFT_Layout_2.Closed += Close_FFT_Layout_2;
                FFT_Layout_2.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                FFT_Layout_2.Float();
                insert_Log("FFT Panel 2: " + Expression.Expression_Name, 5);
            }
            else if (FFT_Layout_3 == null & FFT_Panel_3 == null)
            {
                FFT_Panel_3 = new FFT_Panel.FFT_Panel(Expression);
                FFT_Layout_3 = new LayoutAnchorable()
                {
                    Title = "FFT: " + Expression.Expression_Name,
                    Content = FFT_Panel_3,
                    FloatingWidth = FFT_Panel_FloatingWidth,
                    FloatingHeight = FFT_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                FFT_Layout_3.Closed += Close_FFT_Layout_3;
                FFT_Layout_3.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                FFT_Layout_3.Float();
                insert_Log("FFT Panel 3: " + Expression.Expression_Name, 5);
            }
            else if (FFT_Layout_4 == null & FFT_Panel_4 == null)
            {
                FFT_Panel_4 = new FFT_Panel.FFT_Panel(Expression);
                FFT_Layout_4 = new LayoutAnchorable()
                {
                    Title = "FFT: " + Expression.Expression_Name,
                    Content = FFT_Panel_4,
                    FloatingWidth = FFT_Panel_FloatingWidth,
                    FloatingHeight = FFT_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                FFT_Layout_4.Closed += Close_FFT_Layout_4;
                FFT_Layout_4.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                FFT_Layout_4.Float();
                insert_Log("FFT Panel 4: " + Expression.Expression_Name, 5);
            }
            else if (FFT_Layout_5 == null & FFT_Panel_5 == null)
            {
                FFT_Panel_5 = new FFT_Panel.FFT_Panel(Expression);
                FFT_Layout_5 = new LayoutAnchorable()
                {
                    Title = "FFT: " + Expression.Expression_Name,
                    Content = FFT_Panel_5,
                    FloatingWidth = FFT_Panel_FloatingWidth,
                    FloatingHeight = FFT_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                FFT_Layout_5.Closed += Close_FFT_Layout_5;
                FFT_Layout_5.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                FFT_Layout_5.Float();
                insert_Log("FFT Panel 5: " + Expression.Expression_Name, 5);
            }
            else
            {
                insert_Log("Expression could not be graphed. \n No FFT Panel is free. \n Close a FFT Panel to make room.", 6);
            }
        }
    }
}
