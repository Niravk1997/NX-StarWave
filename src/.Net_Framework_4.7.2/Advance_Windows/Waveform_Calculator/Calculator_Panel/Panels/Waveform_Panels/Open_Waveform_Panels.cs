using AvalonDock.Layout;
using MahApps.Metro.Controls;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private LayoutAnchorable Waveform_Layout_1;
        private LayoutAnchorable Waveform_Layout_2;
        private LayoutAnchorable Waveform_Layout_3;
        private LayoutAnchorable Waveform_Layout_4;
        private LayoutAnchorable Waveform_Layout_5;
        private LayoutAnchorable Waveform_Layout_6;
        private LayoutAnchorable Waveform_Layout_7;
        private LayoutAnchorable Waveform_Layout_8;
        private LayoutAnchorable Waveform_Layout_9;
        private LayoutAnchorable Waveform_Layout_10;

        private Waveform_Panel.Waveform_Panel Waveform_Panel_1;
        private Waveform_Panel.Waveform_Panel Waveform_Panel_2;
        private Waveform_Panel.Waveform_Panel Waveform_Panel_3;
        private Waveform_Panel.Waveform_Panel Waveform_Panel_4;
        private Waveform_Panel.Waveform_Panel Waveform_Panel_5;
        private Waveform_Panel.Waveform_Panel Waveform_Panel_6;
        private Waveform_Panel.Waveform_Panel Waveform_Panel_7;
        private Waveform_Panel.Waveform_Panel Waveform_Panel_8;
        private Waveform_Panel.Waveform_Panel Waveform_Panel_9;
        private Waveform_Panel.Waveform_Panel Waveform_Panel_10;

        private double Waveform_Panel_FloatingWidth = 450;
        private double Waveform_Panel_FloatingHeight = 350;

        private void Open_Waveform_Panel(Expression_Data Expression)
        {
            if (Waveform_Layout_1 == null & Waveform_Panel_1 == null)
            {
                Waveform_Panel_1 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_1 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_1,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_1.Closed += Close_Waveform_Layout_1;
                Waveform_Layout_1.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_1.Float();
                insert_Log("Waveform Panel 1: " + Expression.Expression_Name, 5);
            }
            else if (Waveform_Layout_2 == null & Waveform_Panel_2 == null)
            {
                Waveform_Panel_2 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_2 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_2,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_2.Closed += Close_Waveform_Layout_2;
                Waveform_Layout_2.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_2.Float();
                insert_Log("Waveform Panel 2: " + Expression.Expression_Name, 5);
            }
            else if (Waveform_Layout_3 == null & Waveform_Panel_3 == null)
            {
                Waveform_Panel_3 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_3 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_3,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_3.Closed += Close_Waveform_Layout_3;
                Waveform_Layout_3.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_3.Float();
                insert_Log("Waveform Panel 3: " + Expression.Expression_Name, 5);
            }
            else if (Waveform_Layout_4 == null & Waveform_Panel_4 == null)
            {
                Waveform_Panel_4 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_4 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_4,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_4.Closed += Close_Waveform_Layout_4;
                Waveform_Layout_4.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_4.Float();
                insert_Log("Waveform Panel 4: " + Expression.Expression_Name, 5);
            }
            else if (Waveform_Layout_5 == null & Waveform_Panel_5 == null)
            {
                Waveform_Panel_5 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_5 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_5,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_5.Closed += Close_Waveform_Layout_5;
                Waveform_Layout_5.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_5.Float();
                insert_Log("Waveform Panel 5: " + Expression.Expression_Name, 5);
            }
            else if (Waveform_Layout_6 == null & Waveform_Panel_6 == null)
            {
                Waveform_Panel_6 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_6 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_6,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_6.Closed += Close_Waveform_Layout_6;
                Waveform_Layout_6.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_6.Float();
                insert_Log("Waveform Panel 6: " + Expression.Expression_Name, 5);
            }
            else if (Waveform_Layout_7 == null & Waveform_Panel_7 == null)
            {
                Waveform_Panel_7 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_7 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_7,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_7.Closed += Close_Waveform_Layout_7;
                Waveform_Layout_7.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_7.Float();
                insert_Log("Waveform Panel 7: " + Expression.Expression_Name, 5);
            }
            else if (Waveform_Layout_8 == null & Waveform_Panel_8 == null)
            {
                Waveform_Panel_8 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_8 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_8,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_8.Closed += Close_Waveform_Layout_8;
                Waveform_Layout_8.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_8.Float();
                insert_Log("Waveform Panel 8: " + Expression.Expression_Name, 5);
            }
            else if (Waveform_Layout_9 == null & Waveform_Panel_9 == null)
            {
                Waveform_Panel_9 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_9 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_9,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_9.Closed += Close_Waveform_Layout_9;
                Waveform_Layout_9.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_9.Float();
                insert_Log("Waveform Panel 9: " + Expression.Expression_Name, 5);
            }
            else if (Waveform_Layout_10 == null & Waveform_Panel_10 == null)
            {
                Waveform_Panel_10 = new Waveform_Panel.Waveform_Panel(Expression);
                Waveform_Layout_10 = new LayoutAnchorable()
                {
                    Title = "Waveform: " + Expression.Expression_Name,
                    Content = Waveform_Panel_10,
                    FloatingWidth = Waveform_Panel_FloatingWidth,
                    FloatingHeight = Waveform_Panel_FloatingHeight,
                    CanClose = true,
                    CanFloat = true,
                    CanHide = false,
                    CanAutoHide = false
                };
                Waveform_Layout_10.Closed += Close_Waveform_Layout_10;
                Waveform_Layout_10.AddToLayout(Docking_Manager, AnchorableShowStrategy.Most);
                Waveform_Layout_10.Float();
                insert_Log("Waveform Panel 10: " + Expression.Expression_Name, 5);
            }
            else
            {
                insert_Log("Expression could not be graphed. \n No Waveform Panel is free. \n Close a Waveform Panel to make room.", 6);
            }
        }
    }
}
