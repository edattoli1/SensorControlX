﻿using System;
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

            int deviceIterator = 0;

            DisplayPartSwitchMatrix(lbl, ref deviceIterator, 0, 10, 10);
            DisplayPartSwitchMatrix(lbl, ref deviceIterator, 34, 10, 80);
            DisplayPartSwitchMatrix(lbl, ref deviceIterator, 68, 10, 180);
            DisplayPartSwitchMatrix(lbl, ref deviceIterator, 102, 10, 280);
        }

        private void DisplayPartSwitchMatrix(Label[] lbl, ref int deviceIterator, int startSwitch, int originX, int originY)
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


                for (int i = 0; i < 1; i++)
                {
                    tb[deviceIterator] = new TextBox();
                    relayName = "r" + i.ToString() + "c" + j.ToString();
                    tb[deviceIterator].Name = "textBox" + relayName;
                    tb[deviceIterator].Width = 35;
                    tb[deviceIterator].Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    tb[deviceIterator].Height = 10;
                    tb[deviceIterator].Margin = new Padding(3);
                    tb[deviceIterator].Padding = new Padding(3);
                    tb[deviceIterator].Enabled = false;

                    ycoord += tb[deviceIterator].Height + 2;
                    tb[deviceIterator].Visible = true;
                    tb[deviceIterator].Location = new Point(xcoord, ycoord);

                    this.Controls.Add(tb[deviceIterator]);

                    deviceIterator++;
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
                        tb[j].Text = parentControl.parentForm.PicoammControl.GetReading().ToString("0.000");

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
