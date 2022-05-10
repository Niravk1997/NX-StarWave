using MahApps.Metro.Controls;
using System;
using System.Threading;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private int Monochrome_HardCopy_ByteSize = 38462;
        private int Color_HardCopy_ByteSize = 308278;

        private void HardCopy_Window_Open(byte[] HardCopy_Bytes)
        {
            this.Dispatcher.Invoke(() =>
            {
                HardCopy.HardCopy_Window HardCopy = new HardCopy.HardCopy_Window(HardCopy_Bytes);
                HardCopy.Show();
            });
        }

        private void Get_Monochrome_HardCopy()
        {
            try
            {
                Tektronix.WriteCommand("HARDCopy:FORMat BMP");
                Tektronix.WriteCommand("HARDCopy:LAYout PORTRAIT");
                Tektronix.WriteCommand("HARDCopy:PALEtte CURRent");
                Tektronix.WriteCommand("HARDCopy:PORT GPib");
                Tektronix.WriteCommand("HARDCopy STARt");
                Thread.Sleep(3000);
                if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
                {
                    byte[] HardCopy_Bytes = Tektronix.Get_HardCopy_Visa();
                    HardCopy_Window_Open(HardCopy_Bytes);
                }
                else if (Communication_Selected.is_AR488_Communication_Selected)
                {
                    byte[] HardCopy_Bytes = Tektronix.Get_HardCopy_AR488(Monochrome_HardCopy_ByteSize);
                    HardCopy_Window_Open(HardCopy_Bytes);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Get_Color_HardCopy()
        {
            try
            {
                Tektronix.WriteCommand("HARDCopy:FORMat BMPCOLOR");
                Tektronix.WriteCommand("HARDCopy:LAYout PORTRAIT");
                Tektronix.WriteCommand("HARDCopy:PALEtte CURRent");
                Tektronix.WriteCommand("HARDCopy:PORT GPib");
                Tektronix.WriteCommand("HARDCopy STARt");
                Thread.Sleep(3000);
                if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
                {
                    byte[] HardCopy_Bytes = Tektronix.Get_HardCopy_Visa();
                    HardCopy_Window_Open(HardCopy_Bytes);
                }
                else if (Communication_Selected.is_AR488_Communication_Selected)
                {
                    byte[] HardCopy_Bytes = Tektronix.Get_HardCopy_AR488(Color_HardCopy_ByteSize);
                    HardCopy_Window_Open(HardCopy_Bytes);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Get_Compress_Color_HardCopy()
        {
            try
            {
                if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
                {
                    Tektronix.WriteCommand("HARDCopy:FORMat RLE");
                    Tektronix.WriteCommand("HARDCopy:LAYout PORTRAIT");
                    Tektronix.WriteCommand("HARDCopy:PALEtte CURRent");
                    Tektronix.WriteCommand("HARDCopy:PORT GPib");
                    Tektronix.WriteCommand("HARDCopy STARt");
                    byte[] HardCopy_Bytes = Tektronix.Get_HardCopy_Visa();
                    HardCopy_Window_Open(HardCopy_Bytes);
                }
                else if (Communication_Selected.is_AR488_Communication_Selected)
                {
                    insert_Log("Compress BMP HardCopy option is not available for AR488.", 2);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }
    }
}
