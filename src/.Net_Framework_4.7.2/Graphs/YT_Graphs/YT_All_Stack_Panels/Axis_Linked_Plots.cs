using MahApps.Metro.Controls;
using ScottPlot;
using System;

namespace AllChannels_YT_Stack
{
    public partial class AllChannels_YT_Stack_Plotter : MetroWindow
    {
        private readonly WpfPlot[] Graphs;

        private void AxesChanged(object sender, EventArgs e)
        {
            if (Match_Axis)
            {
                WpfPlot changedPlot = (WpfPlot)sender;
                var newAxisLimits = changedPlot.Plot.GetAxisLimits();

                foreach (WpfPlot wp in Graphs)
                {
                    if (wp == changedPlot)
                        continue;

                    // disable events briefly to prevent an infinite loop
                    wp.Configuration.AxesChangedEventEnabled = false;
                    wp.Plot.SetAxisLimits(newAxisLimits);
                    wp.Refresh();
                    wp.Configuration.AxesChangedEventEnabled = true;
                }
            }
        }
    }
}
