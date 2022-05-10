using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private string FileName = "NX_StarWave_Waveform_Calculator_Math_Expressions.config";
        private bool AutoLoad_isBusy = false;

        private bool AutoLoad_isFile_Exists()
        {
            return File.Exists(NX_StarWave.Communication_Selected.folder_Directory + FileName);
        }

        private void AutoLoad_Load_File()
        {
            try
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (AutoLoad_isFile_Exists() & AutoLoad_isBusy == false)
                    {
                        AutoLoad_isBusy = true;
                        IEnumerable<string> Lines = File.ReadLines(NX_StarWave.Communication_Selected.folder_Directory + FileName);
                        foreach (var Line in Lines)
                        {
                            try
                            {
                                string[] Expression = Line.Split('╦');
                                bool Expression_Selected = false;
                                if (Expression[0] == "True")
                                {
                                    Expression_Selected = true;
                                }
                                string Expression_Name = Expression[1];
                                string Expression_Math = Expression[2];
                                string Expression_Waveform_Config = Expression[3];
                                string Expression_Histogram_Config = Expression[4];
                                string Expression_FFT_Config = Expression[5];
                                Expression_Data.Add(new Expression_Data(Expression_Selected, Expression_Name, Expression_Math, Expression_Waveform_Config, Expression_Histogram_Config, Expression_FFT_Config));
                            }
                            catch (Exception Ex)
                            {
                                insert_Log(Ex.Message, 1);
                                insert_Log("Failed to read an expression from the file.", 1);
                            }
                        }
                        AutoLoad_isBusy = false;
                        insert_Log("Auto Loaded Expression File.", 0);
                    }
                    else
                    {
                        if (AutoLoad_isBusy)
                        {
                            insert_Log("Auto Load is busy. Please Wait.", 2);
                        }
                        else
                        {
                            insert_Log("Auto Load Expression File failed. Could not find the file.", 2);
                        }
                    }
                }));
            }
            catch (Exception Ex)
            {
                AutoLoad_isBusy = false;
                insert_Log(Ex.Message, 1);
            }
        }

        private void AutoLoad_Create_File()
        {
            try
            {
                if (AutoLoad_isBusy == false)
                {
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        try
                        {
                            AutoLoad_isBusy = true;
                            using (TextWriter writetext = new StreamWriter(NX_StarWave.Communication_Selected.folder_Directory + FileName))
                            {
                                foreach (var Expression in Expression_Data)
                                {
                                    string Expression_Data = Expression.Expression_Selected + "╦" + Expression.Expression_Name + "╦" + Expression.Expression + "╦" + Expression.Expression_Waveform_Config + "╦" + Expression.Expression_Histogram_Config + "╦" + Expression.Expression_FFT_Config;
                                    writetext.WriteLine(Expression_Data);
                                }
                            }
                            AutoLoad_isBusy = false;
                        }
                        catch (Exception Ex)
                        {
                            AutoLoad_isBusy = false;
                            insert_Log(Ex.Message, 1);
                            insert_Log("Could not Quick Save Expressions.", 1);
                        }
                    }));
                }
            }
            catch (Exception Ex)
            {
                AutoLoad_isBusy = false;
                insert_Log(Ex.Message, 1);
                insert_Log("Could not Quick Save Expressions.", 1);
            }
        }
    }
}
