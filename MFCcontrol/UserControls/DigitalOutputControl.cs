using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using NationalInstruments.DAQmx;
using MFCcontrol.Properties;

namespace MFCcontrol
{
    public partial class DigitalOutputControl : UserControl
    {
        internal DaqAction digitalWrite;
        internal string[] digitalOutLineArray;
        internal bool [] digitalOutStates;
        
        public DigitalOutputControl()
        {
            digitalWrite = new DaqAction();

            digitalOutStates = new bool[Settings.Default.DigitalOutputNumLines];
            digitalOutLineArray = Util.StringToStringArray(Settings.Default.DigitalOutputLineNames);

            InitializeComponent();
        }

        private void enableDigitalOutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableDigitalOutCheckBox.Checked == true)
            {
                for (int i = 0; i < Settings.Default.DigitalOutputNumLines; i++)
                    digitalWrite.UpdateDigitalOutPort(digitalOutLineArray[i], digitalOutStates[i]);

            }
            else
            {
                for (int i = 0; i < Settings.Default.DigitalOutputNumLines; i++)
                    digitalWrite.UpdateDigitalOutPort(digitalOutLineArray[i], false);
            }
        }

        private void DigitalOutputControl_Load(object sender, EventArgs e)
        {
            if (Settings.Default.DigitalOutputEnable == true)
                enableDigitalOutCheckBox.Checked = true;
        }



    }
}
