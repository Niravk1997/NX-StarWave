using Ivi.Visa;
using MahApps.Metro.Controls;
using System;

namespace NX_StarWave.VISA_GPIB_Communication
{
    public partial class VISA_GPIB_Select_Window : MetroWindow
    {
        private (bool, string) GPIB_Query(string Query_Command)
        {
            try
            {
                using (IVisaSession Instrument = GlobalResourceManager.Open(VISA_GPIB_Port.Text, AccessModes.None, 2000))
                {
                    if (Instrument is IMessageBasedSession session)
                    {
                        session.TerminationCharacterEnabled = true;
                        session.FormattedIO.WriteLine(Query_Command);
                        string Message_Data = session.FormattedIO.ReadLine();
                        Instrument.Dispose();
                        return (true, Message_Data.Trim());
                    }
                    else
                    {
                        insert_Log("Query not possible at this moment.", 1);
                        return (false, "Query Failed.");
                    }
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                return (false, "Query Failed.");
            }
        }

        private void GPIB_Write(string Write_Command)
        {
            try
            {
                using (IVisaSession Instrument = GlobalResourceManager.Open(VISA_GPIB_Port.Text, AccessModes.None, 2000))
                {
                    if (Instrument is IMessageBasedSession session)
                    {
                        session.TerminationCharacterEnabled = true;
                        session.FormattedIO.WriteLine(Write_Command);
                        Instrument.Dispose();
                    }
                    else
                    {
                        insert_Log("Write command not possible at this moment.", 1);
                    }
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }
    }
}
