using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFCcontrol
{
    public partial class ScanDeviceCurrentsForm : Form
    {
        internal SwitchMatrixControl parentControl;
        
        
        public ScanDeviceCurrentsForm()
        {
            InitializeComponent();
        }

        private void ScanDeviceCurrentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentControl.ScanDeviceCurrentsButton.Enabled = true;
            parentControl.loadDeviceListButton.Enabled = true;
            
        }
    }
}
