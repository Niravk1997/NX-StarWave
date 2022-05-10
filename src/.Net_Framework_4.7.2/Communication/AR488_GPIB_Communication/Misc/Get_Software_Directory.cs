using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace NX_StarWave.Serial_Communication
{
    public partial class COM_Select_Window : MetroWindow
    {
        //Save Data Directory
        private string folder_Directory;

        private void getSoftwarePath()
        {
            try
            {
                folder_Directory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                insert_Log("Test Data will be saved inside the software directory.", 3);
                insert_Log(folder_Directory, 3);
                insert_Log("Click the Select button to select another directory.", 3);
            }
            catch (Exception)
            {
                insert_Log("Cannot get software directory path. Choose a new directory.", 1);
            }
        }

        private int folderCreation(string folderPath)
        {
            try
            {
                Directory.CreateDirectory(folderPath);
                return (0);
            }
            catch (Exception)
            {
                insert_Log("Cannot create test data folder. Choose another file directory.", 1);
                return (1);
            }
        }

        private void Select_Directory_Click(object sender, RoutedEventArgs e)
        {
            var Choose_Directory = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (Choose_Directory.ShowDialog() == true)
            {
                folder_Directory = Choose_Directory.SelectedPath;
            }
            insert_Log("Test Data will be saved here: " + folder_Directory, 3);
        }
    }
}
