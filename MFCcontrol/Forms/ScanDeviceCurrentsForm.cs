using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFCcontrol.Properties;
using NationalInstruments.ModularInstruments.NISwitch;
using System.Threading;


namespace MFCcontrol
{
    public partial class ScanDeviceCurrentsForm : Form
    {
        internal SwitchMatrixControl parentControl;
        internal TextBox[] tb;
        
        public ScanDeviceCurrentsForm()
        {
            InitializeComponent();
        }

        private void ScanDeviceCurrentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentControl.ScanDeviceCurrentsButton.Enabled = true;
            parentControl.loadDeviceListButton.Enabled = true;
            
        }

        private void ScanDeviceCurrentsForm_Load(object sender, EventArgs e)
        {
            tb = new TextBox[Settings.Default.SwitchMatrixRowsNum * Settings.Default.SwitchMatrixColsNum];
            Label[] lbl = new Label[Settings.Default.SwitchMatrixColsNum];

            int switchIterator = 0;

            DisplayPartSwitchMatrix( lbl, ref switchIterator, 0, 10, 10);
            DisplayPartSwitchMatrix( lbl, ref switchIterator, 34, 10, 160);
            DisplayPartSwitchMatrix( lbl, ref switchIterator, 68, 10, 310);
            DisplayPartSwitchMatrix( lbl, ref switchIterator, 102, 10, 460);
        }

        private void DisplayPartSwitchMatrix(Label[] lbl, ref int switchIterator, int startSwitch, int originX, int originY)
        {
            int xcoord = originX;
            int ycoord = originY;
            string relayName = "";

            for (int j = startSwitch; j < startSwitch + 34; j++)
            {
                ycoord = originY;

                lbl[j] = new Label();
                lbl[j].Text = j.ToString();
                lbl[j].Location = new Point(xcoord +3, ycoord);
                lbl[j].Visible = true;
                lbl[j].Width = 40;
                lbl[j].Height = 20;
                ycoord += 5;
                this.Controls.Add(lbl[j]);


                for (int i = 0; i < 4; i++)
                {
                    tb[switchIterator] = new TextBox();
                    relayName = "r" + i.ToString() + "c" + j.ToString();
                    tb[switchIterator].Name = "textBox" + relayName;
                    tb[switchIterator].Width = 35;
                    tb[switchIterator].Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    tb[switchIterator].Height = 10;
                    tb[switchIterator].Margin = new Padding(3);
                    tb[switchIterator].Padding = new Padding(3);
                    tb[switchIterator].Enabled = false;

                    ycoord += tb[switchIterator].Height + 2;
                    tb[switchIterator].Visible = true;
                    tb[switchIterator].Location = new Point(xcoord, ycoord);

                    //try
                    //{
                    //    if (switchSession.RelayOperations.GetRelayPosition("k" + relayName) == SwitchRelayPosition.Close)
                    //        cb[switchIterator].Checked = true;
                    //    else
                    //        cb[switchIterator].Checked = false;

                    //}
                    //catch (System.Exception ex)
                    //{
                    //    ShowError(ex.Message);
                    //}

                    this.Controls.Add(tb[switchIterator]);

                    switchIterator++;
                }
                xcoord += 40;
            }

        }

        private void scanCurrentsButton_Click(object sender, EventArgs e)
        {
            SwitchOperations.OpenAllRelays(parentControl.switchSession);
            SwitchOperations.CloseRow2Relays(parentControl.switchSession);
            
            string relayNameClose = "";
            string relayNameOpen = "";
            
            for (int j = 0; j < Settings.Default.SwitchMatrixColsNum; j++)
            {

                
                if (parentControl.parentForm.devicesToScan[j] == true)
                {
                    string relayNameRow0 = "kr" + 0.ToString() + "c" + j.ToString();
                    string relayNameRow1 = "kr" + 1.ToString() + "c" + j.ToString();
                        
                    try
                    {
                        parentControl.switchSession.RelayOperations.RelayControl(relayNameRow0, SwitchRelayAction.CloseRelay);
                        parentControl.switchSession.RelayOperations.RelayControl(relayNameRow1, SwitchRelayAction.OpenRelay);

                        //Read Current
                        Thread.Sleep(50);

                        parentControl.switchSession.RelayOperations.RelayControl(relayNameRow1, SwitchRelayAction.CloseRelay);
                        parentControl.switchSession.RelayOperations.RelayControl(relayNameRow0, SwitchRelayAction.OpenRelay);
                        

                    }
                    catch (System.Exception ex)
                    {
                        ShowError(ex.Message);
                    }

                    //switchIterator++;
                }
                
            }
        }

        private static void ShowError(string message)
        {
            if (string.IsNullOrEmpty(message))
                message = "Unexpected Error";
            MessageBox.Show(message, "Error"); ;
        }

    }
}
