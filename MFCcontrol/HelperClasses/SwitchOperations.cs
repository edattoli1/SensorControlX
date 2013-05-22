﻿using System;
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
        static public Task currentTask;
        
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

        public static void CloseVoltBusRelays(NISwitch switchSession)
        {
            switchSession.RelayOperations.RelayControl("kr2c1", SwitchRelayAction.CloseRelay);
            switchSession.RelayOperations.RelayControl("kr2c66", SwitchRelayAction.CloseRelay);
            switchSession.RelayOperations.RelayControl("kr2c37", SwitchRelayAction.CloseRelay);
            switchSession.RelayOperations.RelayControl("kr2c39", SwitchRelayAction.CloseRelay);


        }


      public static void  SweepAndMeasureDevices(NISwitch switchSession, Ke648xControl PicoammControl, StreamWriter sw, bool [] deviceList, GenStopwatch watch, ref double[] presCurrentArray, CancellationToken ct)
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
                        presCurrentArray[i] = presCurrent;
                        outLine += "\t" + presCurrent.ToString("0.000000e0");

                    }
                }
                string stringBuffer = outLine;

                if (ct.IsCancellationRequested)
                    break;

                // Offload writing to disk onto new task to avoid slowing down the reading of device in case of disk access
                currentTask = Task.Run(() => sw.Write(stringBuffer + Environment.NewLine));
    //            currentTask = Task.Factory.StartNew( () => sw.Write(stringBuffer + Environment.NewLine), 
    //CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
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
