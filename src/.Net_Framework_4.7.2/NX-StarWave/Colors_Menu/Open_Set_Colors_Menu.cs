using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Windows;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private CustomDialog Set_Colors_Dialog;

        private void Initialized_Set_Colors_Dialog()
        {
            try
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    Set_Colors_Dialog = new CustomDialog() { Content = Resources["Colors_Config_Dialog"] };
                }));
            }
            catch (Exception)
            {

            }
        }

        private async void Open_Set_Colors_Menu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Set_Colors_Dialog != null)
                {
                    await this.ShowMetroDialogAsync(Set_Colors_Dialog);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
