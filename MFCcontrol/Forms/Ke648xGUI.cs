using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.NI4882;

namespace Ke648x
{
    public partial class Ke648xGUI : Form
    {

        private Ke648xControl pAmm;

        public Ke648xGUI(Ke648xControl pAmmIn)
        {
            InitializeComponent();
            pAmm = pAmmIn;


        }

        private void startGPIBbutton_Click(object sender, EventArgs e)
        {
            
            pAmm.InitSession();
            string stringRead = pAmm.GetIdentString();



        }


        private void initDeviceButton_Click(object sender, EventArgs e)
        {
            pAmm.InitDevice();

        }

        // Prevent this Form from being Disposed on its Form Close
        private void Ke648xGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hides the Form
            this.Visible = false;
            // This cancels the closing event, prevents Dispose of the Form
            e.Cancel = true;
            // Throw OnClosing event (normal behavior on Form Closing)
            base.OnClosing(e);
        }

        private void picoammRangeUpDown_ValueChanged(object sender, EventArgs e)
        {
            int newRange = Convert.ToInt32(picoammRangeUpDown.Value);

            pAmm.SetRange(newRange);

        }

    }
}
