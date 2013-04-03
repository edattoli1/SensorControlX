﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime;
using System.Threading;


namespace MFCcontrol
{
    public partial class MfcRecipeControl : UserControl
    {
        public Form1 parentForm;
        private RecipeView RecipeView1;



        public MfcRecipeControl()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Create AD results text file, put headers in
            //Make sure writes are done asynchronously using FileStream to open file async

            FileStream sourceStream = new FileStream("adInput.txt",
                   FileMode.Create, FileAccess.Write, FileShare.Read,
                   bufferSize: 4096, useAsync: true);

            parentForm.swriter = new StreamWriter(sourceStream);
            parentForm.swriter.AutoFlush = true;

            string headerString = "Time (s)";


            int numActiveMFCs = 0;
            for (int i = 0; i < parentForm.stateMFCs.Length; i++)
            {
                if (parentForm.stateMFCs[i] == true)
                {
                    numActiveMFCs++;
                    //headerString += "\tMFC " + (i + 1).ToString() + " Flow (sccm)";
                    headerString += "\t"+ parentForm.mfcGasNames[i] + " Flow (sccm)";
                }
            }

            parentForm.swriter.Write(headerString + Environment.NewLine);

            parentForm.IsADoutfileOpen = true;
            

            // ///////////////////////  DO Prep Work if Sensor Matrix Sweeping is Enabled

            if (parentForm.switchMatrixControl1.sweepMatrixCheckBox.Checked == true)
            {
                FileStream sourceStream2 = new FileStream("currentMeasurements.txt",
                   FileMode.Create, FileAccess.Write, FileShare.Read,
                   bufferSize: 4096, useAsync: true);

                parentForm.swriter = new StreamWriter(sourceStream);
                parentForm.swriter.AutoFlush = true;

                string headerString2 = "Time (s)";

                for (int i = 0; i < parentForm.devicesToScan.Length; i++)
                {
                    if (parentForm.devicesToScan[i] == true)
                    {
                        headerString2 += "\t" + i.ToString();
                    }
                }
                parentForm.swriter.Write(headerString + Environment.NewLine);

            }

            // //////////////////////////////////////////////////////////////////////////


            //Go Into Low Latency Mode for Garbage Collector
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;

            //Output initial DAQ Output values
            for (int i = 1; i <= Properties.Settings.Default.MFCcontrol_numMFCs; i++)
            {
                if ( (parentForm.stateMFCs[i - 1] == true) && (parentForm.mfcAoutChannels[i-1] != "") )
                {
                    try
                    {
                        parentForm.daqOutputMFC.UpdateDaqOut(parentForm.mfcAoutChannels[i - 1], parentForm.ADoutTableVolts[0][i]);
                    }
                    catch
                    {
                        parentForm.DaqOutputProblem();
                    }

                }
            }

            parentForm.curRow_ADoutTable = 1;

            //start Program Stopwatch
            parentForm.watch.StopStopwatch();
            parentForm.watch.ResetStopwatch();
            parentForm.watch.StartStopwatch();

            //start AD output update timer (when to update output for A/D), units of ms
            parentForm.timerADoutUpdate.SetInterval(parentForm.ADoutTableVolts[1][0] * 60 * 1000);
            nextRecipeTimeEventBox.Text = parentForm.ADoutTableVolts[1][0].ToString();
            parentForm.timerADoutUpdate.StartTimer();
            parentForm.timerADoutUpdate.TimerElapsed += parentForm.UpdateADoutputHandler;

            // If Switch Sweeping is enabled, Start it, disable user from messing with the switch matrix control
            if (parentForm.switchMatrixControl1.sweepMatrixCheckBox.Checked == true)
            {


                parentForm.switchMatrixControl1.configureSwitchButton.Enabled = false;
                parentForm.switchMatrixControl1.sweepMatrixCheckBox.Enabled = false;
                parentForm.switchMatrixControl1.enableSwitchCheckBox.Enabled = false;
                parentForm.switchMatrixControl1.ScanDeviceCurrentsButton.Enabled = false;
            }


            //Clear Output Graph
            parentForm.resetGraphButton_Click(this, EventArgs.Empty);

            //Disable users from Changing MFC states
            parentForm.configMFCsButton.Enabled = false;
            recipePauseCheckbox.Enabled = true;


            parentForm.mfcControl1.DisableUserControl();
            parentForm.mfcControl2.DisableUserControl();
            parentForm.mfcControl3.DisableUserControl();
            parentForm.mfcControl4.DisableUserControl();

            startButton.Enabled = false;
            loadFlowsButton.Enabled = false;
            exitRecipeButton.Enabled = true;

            parentForm.recipeRunning = true;

            lastRecipeTimeEventBox.Text = "0";

        }

        private delegate DialogResult loadFlowBoxDel(string file);

        private void loadFlowsButton_Click(object sender, EventArgs e)
        {

            DialogResult diagResult = this.openFileDialog1.ShowDialog();

            if (diagResult == DialogResult.OK) // Test result.
            {
                if (FileInUse(this.openFileDialog1.FileName) == true)
                    return;

                SShtLoad sshtLoad1 = new SShtLoad();

                parentForm.stateMFCs = sshtLoad1.LoadMFCstate(this.openFileDialog1.FileName);

                parentForm.maxFlowMFCs = sshtLoad1.LoadMFCmaxFlows(this.openFileDialog1.FileName);

                parentForm.mfcControl1.SetMFCnumber(1);
                parentForm.mfcControl2.SetMFCnumber(2);
                parentForm.mfcControl3.SetMFCnumber(3);
                parentForm.mfcControl4.SetMFCnumber(4);

                // Load all rows of recipe Spreadsheet into ADoutTableValues_s
                // Empty cells are marked translated into -1 (means do nothing)
                // ADoutTableValues_d is in format of Flow (sccm)

                parentForm.ADoutTableValues_s = sshtLoad1.Load(this.openFileDialog1.FileName);

                parentForm.ADoutTableValues_d = new List<double[]>();
                double[] currentRow_d;
                foreach (string[] rowArray in parentForm.ADoutTableValues_s)
                {
                    currentRow_d = new double[Properties.Settings.Default.MFCcontrol_numMFCs + 1];
                    for (int i = 0; i < Properties.Settings.Default.MFCcontrol_numMFCs + 1; i++)
                    {
                        if (rowArray[i] == "")
                            currentRow_d[i] = -1.0;
                        else
                            currentRow_d[i] = Convert.ToDouble(rowArray[i]);
                    }
                    parentForm.ADoutTableValues_d.Add(currentRow_d);
                }

                // Convert ADoutTableValues_d (flow sccm) into ADoutTableVolts (volts)
                // column 1 is times, rest of columns are MFC voltage control values (1,2...)

                parentForm.ADoutTableVolts = new List<double[]>();

                foreach (string[] rowArray in parentForm.ADoutTableValues_s)
                {
                    currentRow_d = new double[Properties.Settings.Default.MFCcontrol_numMFCs + 1];

                    //Load times (column 1 into volts list of arrays
                    currentRow_d[0] = Convert.ToDouble(rowArray[0]);

                    for (int i = 1; i <= parentForm.stateMFCs.Length; i++)
                    {
                        if (rowArray[i] == "")
                            currentRow_d[i] = -1.0;
                        else
                            currentRow_d[i] = DaqAction.GetVoltsFromMFCflow(rowArray[i], i-1, parentForm.maxFlowMFCs);
                    }
                    parentForm.ADoutTableVolts.Add(currentRow_d);
                }

                startButton.Enabled = true;
                viewFlowRecipe.Enabled = true;
            }
        }



        private void viewFlowRecipe_Click(object sender, EventArgs e)
        {
            RecipeView1 = new RecipeView(this, parentForm.ADoutTableValues_s, parentForm.stateMFCs);

            RecipeView1.Show();
        }


        private void recipePauseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (recipePauseCheckbox.Checked == true)
            {
                parentForm.timerADoutUpdate.StopTimer();
                parentForm.recipeRunning = false;

            }
            else
            {
                parentForm.recipeRunning = true;
                parentForm.timerADoutUpdate.StartTimer();
            }
        }

        private void exitRecipe_Click(object sender, EventArgs e)
        {
            parentForm.watch.StopStopwatch();
            parentForm.watch.ResetStopwatch();

            parentForm.timerADoutUpdate.StopTimer();

            parentForm.recipeRunning = false;
            GCSettings.LatencyMode = GCLatencyMode.Interactive;
            //disable writing to disk for last AD acquire events due to last callbacks from HiResTimer class
            //UpdateADacquireBusy = true;


            //wait for disk writes, our timer handlers to finish before closing file
            while ((parentForm.saveADdataBusy == true) || (parentForm.UpdateADacquireBusy == true) || (parentForm.updateADoutputBusy == true))
                Thread.Sleep(200);

            if (parentForm.IsADoutfileOpen == true)
            {
                parentForm.swriter.Close();
                parentForm.IsADoutfileOpen = false;
            }

            startButton.Enabled = true;
            parentForm.configMFCsButton.Enabled = true;


            parentForm.mfcControl1.EnableUserControl();
            parentForm.mfcControl2.EnableUserControl();
            parentForm.mfcControl3.EnableUserControl();
            parentForm.mfcControl4.EnableUserControl();

            //Zero all AD outputs
            parentForm.ZeroAllMFCOutputs();

            parentForm.recipeRunning = false;
            recipePauseCheckbox.Enabled = false;
            parentForm.resetGraphButton_Click(this, EventArgs.Empty);
            parentForm.Form1_Load(this, EventArgs.Empty);
            startButton.Enabled = true;
            loadFlowsButton.Enabled = true;
            viewFlowRecipe.Enabled = true;


            // If Switch Sweeping is enabled, Stop it, renable user control of the switch matrix control
            if (parentForm.switchMatrixControl1.sweepMatrixCheckBox.Checked == true)
            {


                parentForm.switchMatrixControl1.configureSwitchButton.Enabled = true;
                parentForm.switchMatrixControl1.sweepMatrixCheckBox.Enabled = true;
                parentForm.switchMatrixControl1.enableSwitchCheckBox.Enabled = true;
                parentForm.switchMatrixControl1.ScanDeviceCurrentsButton.Enabled = true;
            }


        }


        static bool FileInUse(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    var test = fs.CanWrite;
                }
                return false;
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show("File Access Exception " + ex.Message);
                return true;
            }
        }

        private void MfcRecipeControl_Load(object sender, EventArgs e)
        {
            viewFlowRecipe.Enabled = false;
            startButton.Enabled = false;
            recipePauseCheckbox.Enabled = false;
            exitRecipeButton.Enabled = false;

            openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        }

        public void DisableViewFlowBtn()
        {
            this.viewFlowRecipe.Enabled = false;
        }

        public void EnableViewFlowBtn()
        {
            this.viewFlowRecipe.Enabled = true;
        }



    }
}
