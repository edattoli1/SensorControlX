using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFCcontrol
{
    public partial class GraphMfcs : UserControl
    {
        internal Form1 parentForm;
        
        public GraphMfcs()
        {
            InitializeComponent();
        }

        private void GraphMfcs_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].Axes[0].Title = "Time (min)";
            chart1.ChartAreas[0].Axes[1].Title = "MFC Flow (sccm)";
            chart1.Series[0].Name = Settings1.Default.MFC1Gas;
            chart1.Series[1].Name = Settings1.Default.MFC2Gas;
            chart1.Series[2].Name = Settings1.Default.MFC3Gas;
            chart1.Series[3].Name = Settings1.Default.MFC4Gas;

            chart1.Series[0].Enabled = Settings1.Default.MFC1PlotEnable;
            chart1.Series[1].Enabled = Settings1.Default.MFC2PlotEnable;
            chart1.Series[2].Enabled = Settings1.Default.MFC3PlotEnable;
            chart1.Series[3].Enabled = Settings1.Default.MFC4PlotEnable;
        }

        internal void resetGraphButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
        }

        internal void samplesToResetUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings1.Default.SamplesToGraphReset = Convert.ToInt32(samplesToResetUpDown.Value);
            Settings1.Default.Save();
        }

        private void graphUpdateUD_ValueChanged(object sender, EventArgs e)
        {
            //On Startup this value is 0, in this case don't overwritten saved GraphTimeUpdate value
            if (graphUpdateUDbox.Value != 0)
            {
                Settings1.Default.GraphTimeUpdateMS = Convert.ToInt32(graphUpdateUDbox.Value * 1000);
                Settings1.Default.ADacquireTime_ms = Convert.ToInt32(graphUpdateUDbox.Value * 1000);
            }

            //Only update timers if parentForm has been initialized (During startup)
            if (parentForm != null)
            {
                parentForm.timerADacquire.SetInterval(Settings1.Default.ADacquireTime_ms);
                parentForm.timerADgraph.SetInterval(Settings1.Default.GraphTimeUpdateMS);
            }
            Settings1.Default.Save();
        }

        internal void AinGraphUpdateBox_CheckedChanged(object sender, EventArgs e)
        {
            //Only Graph AD Input if both Update Box is Checked and MFC Control is enabled
            if ((AinGraphUpdateBox.Checked == true) && Settings1.Default.mfcMainControlEnable)
            {
                parentForm.AinGraphUpdateState = true;
                parentForm.timerADgraph.StartTimer();
            }
            else
            {
                parentForm.AinGraphUpdateState = false;
                parentForm.timerADgraph.StopTimer();
            }
        }

    }
}
