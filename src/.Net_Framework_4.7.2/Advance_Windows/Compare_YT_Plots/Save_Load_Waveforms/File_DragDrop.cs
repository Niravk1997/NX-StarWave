using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Compare_YT
{
    public partial class Compare_YT_Plots : MetroWindow
    {
        private void File_DargDrop_on_Graph(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                    for (int i = 0; i < file.Length; i++)
                    {
                        string filePath = System.IO.Path.GetFullPath(file[i]);
                        string fileExtension = System.IO.Path.GetExtension(file[i]);
                        string fileName = System.IO.Path.GetFileName(file[i]);
                        if (fileExtension == ".txt" || fileExtension == ".TXT" || fileExtension == ".csv" || fileExtension == ".CSV")
                        {
                            DragDrop_Load_Waveform(filePath);
                            DragDrop_Load_Reference_Waveform(filePath);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void DragDrop_Load_Waveform(string File_Path)
        {
            try
            {
                Read_Waveform_Data_TEXT_File(File_Path);
            }
            catch (Exception)
            {

            }
        }

        private void DragDrop_Load_Reference_Waveform(string File_Path)
        {
            try
            {
                Read_Reference_Waveform_Data_TEXT_File(File_Path);
            }
            catch (Exception)
            {

            }
        }
    }
}
