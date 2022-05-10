using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private bool Show_Benchmarks = false;
        private bool Stop_Benchmarks = false;
        private System.Diagnostics.Stopwatch Benchmark_Timer = new System.Diagnostics.Stopwatch();

        private bool Show_Captured_Waveform_Preamble = false;

        private void Open_Data_Folder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", Communication_Selected.folder_Directory);
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Show_Benchmarks_Click(object sender, RoutedEventArgs e)
        {
            if (Show_Benchmarks_MenuItem.IsChecked)
            {
                Show_Benchmarks = true;
            }
            else
            {
                Stop_Benchmarks = true;
            }
        }

        private void Show_Captured_Waveform_Preamble_Click(object sender, RoutedEventArgs e)
        {
            if (Show_Waveform_Preamble_MenuItem.IsChecked)
            {
                Show_Captured_Waveform_Preamble = true;
            }
            else
            {
                Show_Captured_Waveform_Preamble = false;
            }
        }

        private void Force_Collect_Garbage_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

    }
}
