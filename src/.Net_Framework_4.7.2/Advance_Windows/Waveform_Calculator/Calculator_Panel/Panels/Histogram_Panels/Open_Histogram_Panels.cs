using AvalonDock.Layout;
using MahApps.Metro.Controls;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private LayoutAnchorable Histogram_Layout_1;
        private LayoutAnchorable Histogram_Layout_2;
        private LayoutAnchorable Histogram_Layout_3;
        private LayoutAnchorable Histogram_Layout_4;
        private LayoutAnchorable Histogram_Layout_5;

        private Histogram_Panel.Histogram_Panel Histogram_Panel_1;
        private Histogram_Panel.Histogram_Panel Histogram_Panel_2;
        private Histogram_Panel.Histogram_Panel Histogram_Panel_3;
        private Histogram_Panel.Histogram_Panel Histogram_Panel_4;
        private Histogram_Panel.Histogram_Panel Histogram_Panel_5;

        private double Histogram_Panel_FloatingWidth = 450;
        private double Histogram_Panel_FloatingHeight = 350;

        private void Open_Histogram_Panel(Expression_Data Expression)
        {
            if (Histogram_Layout_1 == null & Histogram_Panel_1 == null)
            {
                Histogram_Panel_1 = new Histogram_Panel.Histogram_Panel(Expression);
                Histogram_Layout_1 = new LayoutAnchorable()
                {
                    Title = "Histogram: " + Expression.Expression_Name,
                    Content = Histogram_Panel_1,
                    FloatingWidth = Histogram_Panel_FloatingWidth,
                    FloatingHeight = Histogram_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Histogram_Layout_1.Closed += Close_Histogram_Layout_1;
                Histogram_Layout_1.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Histogram_Layout_1.Float();
                insert_Log("Histogram Panel 1: " + Expression.Expression_Name, 5);
            }
            else if (Histogram_Layout_2 == null & Histogram_Panel_2 == null)
            {
                Histogram_Panel_2 = new Histogram_Panel.Histogram_Panel(Expression);
                Histogram_Layout_2 = new LayoutAnchorable()
                {
                    Title = "Histogram: " + Expression.Expression_Name,
                    Content = Histogram_Panel_2,
                    FloatingWidth = Histogram_Panel_FloatingWidth,
                    FloatingHeight = Histogram_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Histogram_Layout_2.Closed += Close_Histogram_Layout_2;
                Histogram_Layout_2.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Histogram_Layout_2.Float();
                insert_Log("Histogram Panel 2: " + Expression.Expression_Name, 5);
            }
            else if (Histogram_Layout_3 == null & Histogram_Panel_3 == null)
            {
                Histogram_Panel_3 = new Histogram_Panel.Histogram_Panel(Expression);
                Histogram_Layout_3 = new LayoutAnchorable()
                {
                    Title = "Histogram: " + Expression.Expression_Name,
                    Content = Histogram_Panel_3,
                    FloatingWidth = Histogram_Panel_FloatingWidth,
                    FloatingHeight = Histogram_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Histogram_Layout_3.Closed += Close_Histogram_Layout_3;
                Histogram_Layout_3.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Histogram_Layout_3.Float();
                insert_Log("Histogram Panel 3: " + Expression.Expression_Name, 5);
            }
            else if (Histogram_Layout_4 == null & Histogram_Panel_4 == null)
            {
                Histogram_Panel_4 = new Histogram_Panel.Histogram_Panel(Expression);
                Histogram_Layout_4 = new LayoutAnchorable()
                {
                    Title = "Histogram: " + Expression.Expression_Name,
                    Content = Histogram_Panel_4,
                    FloatingWidth = Histogram_Panel_FloatingWidth,
                    FloatingHeight = Histogram_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Histogram_Layout_4.Closed += Close_Histogram_Layout_4;
                Histogram_Layout_4.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Histogram_Layout_4.Float();
                insert_Log("Histogram Panel 4: " + Expression.Expression_Name, 5);
            }
            else if (Histogram_Layout_5 == null & Histogram_Panel_5 == null)
            {
                Histogram_Panel_5 = new Histogram_Panel.Histogram_Panel(Expression);
                Histogram_Layout_5 = new LayoutAnchorable()
                {
                    Title = "Histogram: " + Expression.Expression_Name,
                    Content = Histogram_Panel_5,
                    FloatingWidth = Histogram_Panel_FloatingWidth,
                    FloatingHeight = Histogram_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Histogram_Layout_5.Closed += Close_Histogram_Layout_5;
                Histogram_Layout_5.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Histogram_Layout_5.Float();
                insert_Log("Histogram Panel 5: " + Expression.Expression_Name, 5);
            }
            else
            {
                insert_Log("Expression could not be graphed. \n No Histogram Panel is free. \n Close a Histogram Panel to make room.", 6);
            }

        }
    }
}
