using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NationalInstruments.ModularInstruments.NISwitch;
using System.Windows.Forms;
using MFCcontrol.Properties;
using System.IO;


namespace MFCcontrol
{
    public static class SwitchOperations
    {
        public static void OpenAllRelays(NISwitch switchSession)
        {
            // int switchIterator = 0;
            string relayName = "";

            for (int j = 0; j < Settings.Default.SwitchMatrixColsNum; j++)
            {
                for (int i = 0; i < Settings.Default.SwitchMatrixRowsNum; i++)
                {
                    relayName = "kr" + i.ToString() + "c" + j.ToString();
                    //cb[switchIterator].CheckedChanged -= SwitchStateForm_CheckedChanged;
                    try
                    {
                        switchSession.RelayOperations.RelayControl(relayName, SwitchRelayAction.OpenRelay);

                    }
                    catch (System.Exception ex)
                    {
                        ShowError(ex.Message);
                    }
                    // switchIterator++;
                }
            }
        }

        public static void CloseRow2Relays(NISwitch switchSession)
        {
            //int switchIterator = 0;
            string relayName = "";

            for (int j = 0; j < Settings.Default.SwitchMatrixColsNum; j++)
            {

                relayName = "kr" + 1.ToString() + "c" + j.ToString();
                // cb[switchIterator].CheckedChanged -= SwitchStateForm_CheckedChanged;
                try
                {
                    switchSession.RelayOperations.RelayControl(relayName, SwitchRelayAction.CloseRelay);
                }
                catch (System.Exception ex)
                {
                    ShowError(ex.Message);
                }
                //switchIterator++;

            }

        }

        public static double SwitchToDeviceMeasureCurrent(NISwitch switchSession, Ke648xControl PicoammControl, string relayNameRow0, string relayNameRow1)
        {
            double returnValue = 0;

            try
            {
            switchSession.RelayOperations.RelayControl(relayNameRow0, SwitchRelayAction.CloseRelay);
            switchSession.RelayOperations.RelayControl(relayNameRow1, SwitchRelayAction.OpenRelay);

            // TODO Need to wait for switch to stabilize? may need to add wait here
            // await Task.Delay(50);
            //Read Current
            returnValue = PicoammControl.GetReading();

            switchSession.RelayOperations.RelayControl(relayNameRow1, SwitchRelayAction.CloseRelay);
            switchSession.RelayOperations.RelayControl(relayNameRow0, SwitchRelayAction.OpenRelay);
            }
            catch (System.Exception ex)
            {
                ShowError(ex.Message);
            }

            return returnValue;
        }

        public static void  SweepAndMeasureDevices(NISwitch switchSession, Ke648xControl PicoammControl, StreamWriter sw, bool [] deviceList, GenStopwatch watch, CancellationToken ct)
        {
            double presCurrent;
            string outLine;

            while (! ct.IsCancellationRequested)
            {
                outLine = (string.Format("{0:F3}", watch.GetMsElapsed() * .001));
                

                for (int i = 0; i < deviceList.Length; i++)
                {
                    if (deviceList[i] == true)
                    {
                        string relayNameRow0 = "kr" + 0.ToString() + "c" + i.ToString();
                        string relayNameRow1 = "kr" + 1.ToString() + "c" + i.ToString();

                        presCurrent = SwitchToDeviceMeasureCurrent(switchSession, PicoammControl, relayNameRow0, relayNameRow1);
                        outLine += "\t" + presCurrent.ToString("0.000000e0");

                    }
                }
                //Task.Run(() => sw.Write(outLine + Environment.NewLine));
                sw.Write(outLine + Environment.NewLine);
            }
            //ct.ThrowIfCancellationRequested();
        }

        private static void ShowError(string message)
        {
            if (string.IsNullOrEmpty(message))
                message = "Unexpected Error";
            MessageBox.Show(message, "Error"); ;
        }
    }
}
