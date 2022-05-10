using MahApps.Metro.Controls;
using System;

namespace XY_Waveform
{
    public partial class XY_Waveform_Plotter : MetroWindow
    {
        private int Channel_1_Selected = 0;
        private int Channel_2_Selected = 1;

        private string Channel_1_Selected_String = "1";
        private string Channel_2_Selected_String = "2";

        private void Channel_1_Selector_ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Channel_1_Selected = Channel_1_Selector_ComboBox.SelectedIndex;
            Apply_Channel_1_Selection();
        }

        private void Channel_2_Selector_ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Channel_2_Selected = Channel_2_Selector_ComboBox.SelectedIndex;
            Apply_Channel_2_Selection();
        }

        private void Apply_Channel_1_Selection()
        {
            switch (Channel_1_Selected)
            {
                //Channel 1
                case 0:
                    Channel_1_Selected_String = "1";
                    break;
                //Channel 2
                case 1:
                    Channel_1_Selected_String = "2";
                    break;
                //Channel 3
                case 2:
                    Channel_1_Selected_String = "3";
                    break;
                //Channel 4
                case 3:
                    Channel_1_Selected_String = "4";
                    break;
            }
            Channel_1_Label_Updater(Channel_1_Selected_String);
        }

        private void Apply_Channel_2_Selection()
        {
            switch (Channel_2_Selected)
            {
                //Channel 1
                case 0:
                    Channel_2_Selected_String = "1";
                    break;
                //Channel 2
                case 1:
                    Channel_2_Selected_String = "2";
                    break;
                //Channel 3
                case 2:
                    Channel_2_Selected_String = "3";
                    break;
                //Channel 4
                case 3:
                    Channel_2_Selected_String = "4";
                    break;
            }
            Channel_2_Label_Updater(Channel_2_Selected_String);
        }
    }
}
