using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MFCcontrol
{
    public partial class ConfigureMFCs : Form
    {
        internal Form1 parentForm;
        
        public ConfigureMFCs(Form1 parentFormIn)
        {
            InitializeComponent();
            parentForm = parentFormIn;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TextBox curMfcTypeBox;
            NumericUpDown curMfcMaxFlowUpDown;

            for (int i = 0; i < parentForm.mfcControlArray.Length; i++)
            {
                curMfcTypeBox = (TextBox) tableLayoutPanel1.Controls["mfcTypeBox" + (i + 1).ToString()];
                parentForm.mfcGasNames[i] = curMfcTypeBox.Text;
                curMfcMaxFlowUpDown = (NumericUpDown) tableLayoutPanel1.Controls["mfcMaxFlowUpDown" + (i + 1).ToString()];
                parentForm.maxFlowMFCs[i] = Convert.ToInt32(curMfcMaxFlowUpDown.Value);
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigureMFCs_Load(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                TextBox curMfcTypeBox;
                NumericUpDown curMfcMaxFlowUpDown;
                
                for (int i = 0; i < parentForm.mfcControlArray.Length; i++)
                {
                    curMfcTypeBox = (TextBox) tableLayoutPanel1.Controls["mfcTypeBox" + (i + 1).ToString("0")];
                    //Debug.WriteLine("mfcTypeBox" + (i + 1).ToString("0"));
                    curMfcTypeBox.Text = parentForm.mfcGasNames[i];
                    curMfcMaxFlowUpDown = (NumericUpDown) tableLayoutPanel1.Controls["mfcMaxFlowUpDown" + (i + 1).ToString()];
                    curMfcMaxFlowUpDown.Value = (parentForm.maxFlowMFCs[i]);
                }
                
                //mfcTypeBox1.Text = Properties.Settings.Default.MFC1Gas;
                //mfcMaxFlowBox1.Text = Properties.Settings.Default.MFC1maxRange;
                //mfcTypeBox2.Text = Properties.Settings.Default.MFC2Gas;
                //mfcMaxFlowBox2.Text = Properties.Settings.Default.MFC2maxRange;
                //mfcTypeBox3.Text = Properties.Settings.Default.MFC3Gas;
                //mfcMaxFlowBox3.Text = Properties.Settings.Default.MFC3maxRange;
                //mfcTypeBox4.Text = Properties.Settings.Default.MFC4Gas;
                //mfcMaxFlowBox4.Text = Properties.Settings.Default.MFC4maxRange;
            }

        }
    }
}
