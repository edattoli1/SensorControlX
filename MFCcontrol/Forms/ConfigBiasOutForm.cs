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
    public partial class ConfigBiasOutForm : Form
    {
        public ConfigBiasOutForm()
        {
            InitializeComponent();
        }

        private void ConfigBiasOutForm_Load(object sender, EventArgs e)
        {
            vdsAOaddressTextbox.Text = Properties.Settings.Default.sensorVdsDaqAO;
            vgsAOaddressTextbox.Text = Properties.Settings.Default.sensorVgsDaqAO;
        }

        private void saveConfigBiasForm_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.sensorVdsDaqAO = vdsAOaddressTextbox.Text;
            Properties.Settings.Default.sensorVgsDaqAO = vgsAOaddressTextbox.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelConfigBiasForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
