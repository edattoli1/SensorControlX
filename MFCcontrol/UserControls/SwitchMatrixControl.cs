using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.ModularInstruments.NISwitch;
using NationalInstruments.ModularInstruments.SystemServices.DeviceServices;
using MFCcontrol.Properties;

namespace MFCcontrol
{
    public partial class SwitchMatrixControl : UserControl
    {
        internal Form1 parentForm;
        internal NISwitch switchSession;
        static private ConfigureSwitchMatrix configSwitchMatrixForm1;

        public SwitchMatrixControl()
        {
            InitializeComponent();
        }

        private void InitializeSwitchSession()
        {
            switchSession = new NISwitch(Settings.Default.PxiResourceName, Settings.Default.SwitchTopologyName, false, true);
            switchSession.DriverOperation.Warning += new System.EventHandler<Ivi.Driver.WarningEventArgs>(DriverOperationWarning);
        }


        private void CloseSession()
        {
            if (switchSession != null)
            {
                try
                {
                    switchSession.Close();
                    switchSession = null;
                }
                catch (System.Exception ex)
                {
                    ShowError("Unable to Close Session, Reset the device.\n" + "Error : " + ex.Message);
                    Application.Exit();
                }
            }
        }

        private static void ShowError(string message)
        {
            if (string.IsNullOrEmpty(message))
                message = "Unexpected Error";
            MessageBox.Show(message, "Error"); ;
        }

        private void DriverOperationWarning(object sender, Ivi.Driver.WarningEventArgs e)
        {
            MessageBox.Show(e.ToString(), "Warning");
        }

        private void configureSwitchButton_Click(object sender, EventArgs e)
        {
            configSwitchMatrixForm1 = new ConfigureSwitchMatrix ();
            configSwitchMatrixForm1.ShowDialog();
        }

        private void enableSwitchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableSwitchCheckBox.Checked == true)
            {
                InitializeSwitchSession();
            }
            else
            {
                CloseSession();
            }

        }
    }
}
