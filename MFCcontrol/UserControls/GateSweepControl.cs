using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFCcontrol.Properties;

namespace MFCcontrol.UserControls
{
    public partial class GateSweepControl : UserControl
    {
        
        internal Form1 parentForm;        

        public GateSweepControl()
        {
            InitializeComponent();
        }

        private void enableGateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableGateCheckBox.Checked == true)
            {
                parentForm.k617.InitSession();
                stepSweepUpDown.Enabled = true;
                hiSweepUpDown.Enabled = true;
                lowSweepUpDown.Enabled = true;
                manSetUpDown.Enabled = true;

            }
            else
            {
                parentForm.k617.EndSession();
                stepSweepUpDown.Enabled = false;
                hiSweepUpDown.Enabled = false;
                lowSweepUpDown.Enabled = false;
                manSetUpDown.Enabled = false;

            }

            Settings.Default.GateSweepEnable = enableGateCheckBox.Checked;

        }

        private void manSetUpDown_ValueChanged(object sender, EventArgs e)
        {
            parentForm.k617.ChangeVolt(Convert.ToDouble(manSetUpDown.Value));
        }

        private void GateSweepControl_Load(object sender, EventArgs e)
        {
            if (Settings.Default.GateSweepEnable == true)
                enableGateCheckBox.Checked = true;
            else
                enableGateCheckBox.Checked = false;


            

        }




    }
}
