using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using NX_StarWave.Misc;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private ICommand Colors_Config_Dialog_Default_;
        public ICommand Colors_Config_Dialog_Default
        {
            get
            {
                if (Colors_Config_Dialog_Default_ == null)
                {
                    Colors_Config_Dialog_Default_ = new RelayCommand(
                        param => Execute_Colors_Config_Dialog_Default(),
                        param => Can_Colors_Config_Dialog_Default());
                }
                return Colors_Config_Dialog_Default_;
            }
        }

        private bool Can_Colors_Config_Dialog_Default()
        {
            if (Set_Colors_Dialog != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Execute_Colors_Config_Dialog_Default()
        {
            try
            {
                try
                {
                    ThemeManager.Current.ChangeThemeBaseColor(Application.Current, "Light");
                }
                catch (Exception) { }

                try
                {
                    Accent_Selected_Index = 10;
                }
                catch (Exception) { }

                Channel_1_Color_String = "#0072BD";
                Channel_2_Color_String = "#FFFF8C00";
                Channel_3_Color_String = "#FFFF1493";
                Channel_4_Color_String = "#00B33C";

                Math_YT_Window_1_Color_String = "#0072BD";
                Math_YT_Window_2_Color_String = "#FFFF8C00";
                Math_YT_Window_3_Color_String = "#FFFF1493";
                Math_YT_Window_4_Color_String = "#00B33C";

                Math_FFT_Window_1_Color_String = "#0072BD";
                Math_FFT_Window_2_Color_String = "#FFFF8C00";
                Math_FFT_Window_3_Color_String = "#FFFF1493";
                Math_FFT_Window_4_Color_String = "#00B33C";

                Save_Selected_Waveform_Colors();
            }
            catch (Exception)
            {

            }
        }

        private ICommand Colors_Config_Dialog_Close_;
        public ICommand Colors_Config_Dialog_Close
        {
            get
            {
                if (Colors_Config_Dialog_Close_ == null)
                {
                    Colors_Config_Dialog_Close_ = new RelayCommand(
                        param => Execute_Colors_Config_Dialog_Close(),
                        param => Can_Colors_Config_Dialog_Close());
                }
                return Colors_Config_Dialog_Close_;
            }
        }

        private bool Can_Colors_Config_Dialog_Close()
        {
            if (Set_Colors_Dialog != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void Execute_Colors_Config_Dialog_Close()
        {
            await this.HideMetroDialogAsync(Set_Colors_Dialog);
        }

        private ICommand Colors_Config_Dialog_Apply_;
        public ICommand Colors_Config_Dialog_Apply
        {
            get
            {
                if (Colors_Config_Dialog_Apply_ == null)
                {
                    Colors_Config_Dialog_Apply_ = new RelayCommand(
                        param => Execute_Colors_Config_Dialog_Apply(),
                        param => Can_Colors_Config_Dialog_Apply());
                }
                return Colors_Config_Dialog_Apply_;
            }
        }

        private bool Can_Colors_Config_Dialog_Apply()
        {
            if (Set_Colors_Dialog != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void Execute_Colors_Config_Dialog_Apply()
        {
            await this.HideMetroDialogAsync(Set_Colors_Dialog);
            Save_Selected_Waveform_Colors();
        }
    }
}
