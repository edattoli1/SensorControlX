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
    public partial class DigitalOutLineStatesForm : Form
    {
        internal DigitalOutputControl parentControl;
        
        public DigitalOutLineStatesForm()
        {
            InitializeComponent();
        }

        private void DigitalOutLineStatesForm_Load(object sender, EventArgs e)
        {
            CheckBox currentCheckBox;

            for (int i = 1; i <= 8; i++)
            {
                currentCheckBox = (CheckBox) tableLayoutPanel1.Controls["digitalOutCheckBox" + i.ToString("0")];

                if ((currentCheckBox.Checked == true) && (parentControl.digitalOutStates[i - 1] == false))
                    currentCheckBox.Checked = false;
                else if ((currentCheckBox.Checked == false) && (parentControl.digitalOutStates[i - 1] == true))
                    currentCheckBox.Checked = true;
               
                currentCheckBox.CheckedChanged += DigOutCheckedChanged;

            }

        }

        private void DigOutCheckedChanged(object sender, EventArgs e)
        {

        }

        private void DigitalOutLineStatesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentControl.viewDigitalOutStateButton.Enabled = true;
            parentControl.configureDigitalOutButton.Enabled = true;
            parentControl.enableDigitalOutCheckBox.Enabled = true;
        }
    }
}
