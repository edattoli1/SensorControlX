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
            vdsAOaddressTextbox.Text = Settings1.Default.sensorVdsDaqAO;
            vgsAOaddressTextbox.Text = Settings1.Default.sensorVgsDaqAO;
        }

        private void saveConfigBiasForm_Click(object sender, EventArgs e)
        {
            Settings1.Default.sensorVdsDaqAO = vdsAOaddressTextbox.Text;
            Settings1.Default.sensorVgsDaqAO = vgsAOaddressTextbox.Text;
            Settings1.Default.Save();
            this.Close();
        }

        private void cancelConfigBiasForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
