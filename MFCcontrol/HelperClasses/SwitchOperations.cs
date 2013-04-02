using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.ModularInstruments.NISwitch;
using System.Windows.Forms;
using MFCcontrol.Properties;


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

        private static void ShowError(string message)
        {
            if (string.IsNullOrEmpty(message))
                message = "Unexpected Error";
            MessageBox.Show(message, "Error"); ;
        }
    }
}
