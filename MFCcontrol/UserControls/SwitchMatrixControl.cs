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


namespace MFCcontrol
{
    public partial class SwitchMatrixControl : UserControl
    {
        internal Form1 parentForm;
        internal NISwitch switchSession;
        internal string resourceName, topologyName;
        static private ConfigureSwitchMatrix configSwitchMatrixForm1;

        public SwitchMatrixControl()
        {
            InitializeComponent();
            resourceName = "";
            topologyName = "";
        }

        private void InitializeSwitchSession()
        {
            switchSession = new NISwitch(resourceName, topologyName, false, true);
            switchSession.DriverOperation.Warning += new System.EventHandler<Ivi.Driver.WarningEventArgs>(DriverOperationWarning);
        }

        private void DriverOperationWarning(object sender, Ivi.Driver.WarningEventArgs e)
        {
            MessageBox.Show(e.ToString(), "Warning");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void configureSwitchButton_Click(object sender, EventArgs e)
        {
            configSwitchMatrixForm1 = new ConfigureSwitchMatrix ();
            configSwitchMatrixForm1.ShowDialog();
        }
    }
}
