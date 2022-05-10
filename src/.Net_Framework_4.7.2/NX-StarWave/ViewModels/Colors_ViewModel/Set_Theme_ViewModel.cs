using ControlzEx.Theming;
using NX_StarWave.Misc;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : INotifyPropertyChanged
    {
        private ICommand Set_Light_Theme_;
        public ICommand Set_Light_Theme
        {
            get
            {
                if (Set_Light_Theme_ == null)
                {
                    Set_Light_Theme_ = new RelayCommand(
                        param => Execute_Set_Light_Theme(),
                        param => Can_Set_Light_Theme());
                }
                return Set_Light_Theme_;
            }
        }

        private bool Can_Set_Light_Theme()
        {
            if (ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Light"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Execute_Set_Light_Theme()
        {
            try
            {
                ThemeManager.Current.ChangeThemeBaseColor(Application.Current, "Light");
            }
            catch (Exception)
            {

            }
        }

        private ICommand Set_Dark_Theme_;
        public ICommand Set_Dark_Theme
        {
            get
            {
                if (Set_Dark_Theme_ == null)
                {
                    Set_Dark_Theme_ = new RelayCommand(
                        param => Execute_Set_Dark_Theme(),
                        param => Can_Set_Dark_Theme());
                }
                return Set_Dark_Theme_;
            }
        }

        private bool Can_Set_Dark_Theme()
        {
            if (ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Execute_Set_Dark_Theme()
        {
            try
            {
                ThemeManager.Current.ChangeThemeBaseColor(Application.Current, "Dark");
            }
            catch (Exception)
            {

            }
        }

        private int Accent_Selected_Index_ = 10;
        public int Accent_Selected_Index
        {
            get { return Accent_Selected_Index_; }
            set
            {
                Accent_Selected_Index_ = value;
                try
                {
                    ThemeManager.Current.ChangeThemeColorScheme(Application.Current, ThemeManager.Current.ColorSchemes[value]);
                }
                catch (Exception)
                {

                }
                NotifyPropertyChanged("Accent_Selected_Index");
            }
        }
    }
}
