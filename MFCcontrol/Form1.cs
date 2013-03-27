using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime;
using Ke648x;

namespace MFCcontrol
{
    public partial class Form1 : Form
    {
        internal GenStopwatch watch;
        private GenTimer timerUI;
        internal GenTimer timerADgraph;
        //private HiResTimer timerADacquire;
        internal GenTimer timerADacquire;
        internal GenTimer timerADoutUpdate;
        internal StreamWriter swriter;

        internal List<string[]> ADoutTableValues_s;
        internal List<double[]> ADoutTableValues_d;
        internal List<double[]> ADoutTableVolts;

        private static double[] currentADin;
        private DaqAction daqInput;
        public DaqAction daqOutputMFC;
        public DaqAction daqOutputBiases;
        internal int curRow_ADoutTable;
        internal bool recipeRunning;
        internal bool AinGraphUpdateState;
        private int ADgraphUpdateCnt;
        private double[] presentMFCsetting;
        private static Ke648xGUI PicoammForm;
        static private Ke648xControl PicoammControl;
        static private ConfigBiasOutForm configBiasForm1;

        // state of the MFCs for the recipe to be used
        // 0th in array corresponds to MFC 1, .., etc
        internal bool[] stateMFCs;

        // maximum flow rate of the MFCs for the recipe to be used
        // 0th in array corresponds to MFC 1, .., etc
        internal int[] maxFlowMFCs;

        //Helper Classes
        // TODO remove
        //private RecipeView RecipeView1;


        private ConfigureMFCs MFCconfigure1;

        //used for closing file properly when stop or exit button is hit
        internal bool IsADoutfileOpen = false;


        public Form1()
        {
            InitializeComponent();

            //Used for Drawing Rows in MFC table
            tableLayoutPanel1.CellPaint += tableLayoutPanel_CellPaint;
            tableLayoutPanel2.CellPaint += tableLayoutPanel_CellPaint;
            tableLayoutPanel3.CellPaint += tableLayoutPanel_CellPaint;

            // Initialized Saved Settings Values Into Form

            samplesToResetUpDown.Value = Settings1.Default.SamplesToGraphReset;
            AinGraphUpdateState = true;

            stateMFCs = new bool[Settings1.Default.MFCcontrol_numMFCs];
            maxFlowMFCs = new int[Settings1.Default.MFCcontrol_numMFCs];

            currentADin = new double[Settings1.Default.MFCcontrol_numMFCs];
            presentMFCsetting = new double[Settings1.Default.MFCcontrol_numMFCs];

            // Initialize Members of Form1 Class

            daqInput = new DaqAction();
            daqOutputMFC = new DaqAction();
            daqOutputBiases = new DaqAction(-1 * Settings1.Default.sensorBiasMaxRange, Settings1.Default.sensorBiasMaxRange);

            // Ready fields for Daq Bias Output
            VdsUpDown.Maximum = Convert.ToDecimal(Settings1.Default.sensorBiasMaxRange);
            VgsUpDown.Maximum = Convert.ToDecimal(Settings1.Default.sensorBiasMaxRange);
            VdsUpDown.Minimum = -1 * Convert.ToDecimal(Settings1.Default.sensorBiasMaxRange);
            VgsUpDown.Minimum = -1 * Convert.ToDecimal(Settings1.Default.sensorBiasMaxRange);

            watch = new GenStopwatch();

            timerUI = new GenTimer();
            timerUI.SetInterval(Settings1.Default.timerUI_ms);

            //timerADacquire = new HiResTimer();
            timerADacquire = new GenTimer();
            timerADacquire.SetInterval(Settings1.Default.ADacquireTime_ms);

            timerADgraph = new GenTimer();
            timerADgraph.SetInterval(Settings1.Default.GraphTimeUpdateMS);

            //Set NumericUpDown Control box for Graph Update Time to Saved Value
            graphUpdateUDbox.Value = Convert.ToDecimal(Settings1.Default.GraphTimeUpdateMS) / 1000;

            timerADoutUpdate = new GenTimer();
            timerADoutUpdate.AutoResetEnable();
            timerADoutUpdate.SetInterval(Settings1.Default.ADoutRefreshTime_ms);


        }

        internal void Form1_Load(object sender, EventArgs e)
        {

            //Make sure counters are at 0 (for DAQ output and Graph Reset count)
            curRow_ADoutTable = 0;
            ADgraphUpdateCnt = 0;

            timeElapsedBox.Text = (watch.GetMsElapsed() / 3600.0).ToString();

            //Let recipe control panel know about parent form
            mfcRecipeControl1.parentForm = this;

            // Let MFC Control Panels know that about parent form so they can interact with it
            mfcControl1.parentForm = this;
            mfcControl2.parentForm = this;
            mfcControl3.parentForm = this;
            mfcControl4.parentForm = this;

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

            //Set MFC Main Control Check Box to saved Value
            mfcMainControlEnable.Checked = Settings1.Default.mfcMainControlEnable;

            //Set MFC USer Controls to correct MFC
            mfcControl1.SetMFCnumber(1);
            mfcControl2.SetMFCnumber(2);
            mfcControl3.SetMFCnumber(3);
            mfcControl4.SetMFCnumber(4);

            //Default MFC Control State is OFF
            mfcControl1.DisableUserControl();
            mfcControl2.DisableUserControl();
            mfcControl3.DisableUserControl();
            mfcControl4.DisableUserControl();

            //Set whether recipe controls the following MFCs, stateMFC is logic control at runtime, Settings is permanent store
            stateMFCs[0] = Settings1.Default.MFC1enable;
            stateMFCs[1] = Settings1.Default.MFC2enable;
            stateMFCs[2] = Settings1.Default.MFC3enable;
            stateMFCs[3] = Settings1.Default.MFC4enable;

            // Picoammeter init stuff
            picoammSettingsButton.Enabled = false;
            PicoammControl = new Ke648xControl();
            controlPicoammBox.Checked = Settings1.Default.PicoammeterControlEnable;

            //start StopWatch
            watch.StartStopwatch();

            //start UI Timer
            timerUI.TimerElapsed += UpdateUIhandler;


            //start AD timer (when to acquire from A/D)
            UpdateADacquireBusy = false;
            timerADacquire.TimerElapsed += UpdateADacquireHandlerAsync;

            //start AD graph timer (when to graph data from A/D)
            timerADgraph.TimerElapsed += UpdateADgraphHandler;

            if (Settings1.Default.mfcMainControlEnable == true)
            {
                timerADacquire.StartTimer();
                timerADgraph.StartTimer();
                timerUI.StartTimer();
                //Zero all AD outputs
                ZeroAllMFCOutputs();
                mfcControl1.EnableUserControl();
                mfcControl2.EnableUserControl();
                mfcControl3.EnableUserControl();
                mfcControl4.EnableUserControl();
            }

            //If DAQ Analog Out is Enabled in Settings file, Update Checkmark and Zero Bias Outputs
            if (Settings1.Default.sensorBiasEnable == true)
            {
                biasOutsBox.Checked = Settings1.Default.sensorBiasEnable;
                ZeroAllBiasOutputs();
            }

        }


        private void UpdateUIhandler(object obj, EventArgs e)
        {
            UpdateUI((Convert.ToDouble(watch.GetMsElapsed()) * .001 / 60.0).ToString("0.00"));
        }

        void UpdateUI(string text)
        {
            //the GenTimer class operates the timer on a different thread than the UI
            //UI updates must though be executed on the UI thread, this code ensures that happens
            if (InvokeRequired)
            {
                BeginInvoke((Action<string>)UpdateUI, text);
                return;
            }

            timeElapsedBox.Text = text;
            mfcControl1.UpdatePresFlowBox(DaqAction.GetMFCflowFromVolts(currentADin[0], 1));
            mfcControl2.UpdatePresFlowBox(DaqAction.GetMFCflowFromVolts(currentADin[1], 2));
            mfcControl3.UpdatePresFlowBox(DaqAction.GetMFCflowFromVolts(currentADin[2], 3));
            mfcControl4.UpdatePresFlowBox(DaqAction.GetMFCflowFromVolts(currentADin[3], 4));

            if (recipeRunning == true)
            {

                //Update Next Time for Recipe Event on GUI in Recipe Section

                if (curRow_ADoutTable < ADoutTableVolts.Count)
                {
                    mfcRecipeControl1.nextRecipeTimeEventBox.Text = ADoutTableVolts[curRow_ADoutTable][0].ToString("0.00");
                    mfcRecipeControl1.lastRecipeTimeEventBox.Text = ADoutTableVolts[curRow_ADoutTable - 1][0].ToString("0.00");
                }
                else // Recipe is Over
                {
                    mfcRecipeControl1.lastRecipeTimeEventBox.Text = ADoutTableVolts[curRow_ADoutTable - 1][0].ToString("0.00");
                    mfcRecipeControl1.nextRecipeTimeEventBox.Text = "Recipe Over";
                }

                //Update Present Set Flow in GUI on MFC Control Section

                mfcControl1.UpdateSetFlowValue(presentMFCsetting[0]);
                mfcControl2.UpdateSetFlowValue(presentMFCsetting[1]);
                mfcControl3.UpdateSetFlowValue(presentMFCsetting[2]);
                mfcControl4.UpdateSetFlowValue(presentMFCsetting[3]);

            }
        }

        delegate void UpdateADgraphDelegate();

        private bool UpdateADgraphBusy = false;
        internal bool UpdateADacquireBusy = false;
        internal bool saveADdataBusy = false;
        internal bool updateADoutputBusy = false;

        internal void UpdateADoutputHandler(object obj, EventArgs e)
        {
            if (updateADoutputBusy == true)
                return;
            else if (curRow_ADoutTable >= ADoutTableVolts.Count)
            {
                updateADoutputBusy = false;
                return;
            }
            else
            {
                updateADoutputBusy = true;
                for (int i = 1; i <= Settings1.Default.MFCcontrol_numMFCs; i++)
                {
                    // check record of AD out values has a current output for the AD at this particular time (i.e., row)
                    // and check whether current MFC is enabled in the recipe
                    if ((ADoutTableVolts[curRow_ADoutTable][i] >= 0) && (stateMFCs[i - 1] == true))
                        UpdateADoutput(ADoutTableVolts, i);
                }
                curRow_ADoutTable++;
                timerADoutUpdate.StopTimer();

                //Check if at end of AO output recipe, if so, keep AO update timer off and just exit
                //if ((ADoutTableValues_d[curRow_ADoutTable][0]) < 0)
                if (curRow_ADoutTable >= ADoutTableVolts.Count)
                {
                    updateADoutputBusy = false;
                    return;
                }

                timerADoutUpdate.SetInterval(((ADoutTableVolts[curRow_ADoutTable][0]) - ADoutTableVolts[curRow_ADoutTable - 1][0]) * 60.0 * 1000.0);

                timerADoutUpdate.StartTimer();

                updateADoutputBusy = false;
            }
        }

        private void UpdateADoutput(List<double[]> ADoutTable, int mfcNumber)
        {
            try
            {
                if (mfcNumber == 1)
                {
                    daqOutputMFC.UpdateDaqOut(0, ADoutTable[curRow_ADoutTable][1]);
                    presentMFCsetting[0] = (ADoutTableValues_d[curRow_ADoutTable][1]);
                }

                else if (mfcNumber == 2)
                {
                    daqOutputMFC.UpdateDaqOut(1, ADoutTable[curRow_ADoutTable][2]);
                    presentMFCsetting[1] = (ADoutTableValues_d[curRow_ADoutTable][2]);
                }

                else if (mfcNumber == 3)
                {
                    daqOutputMFC.UpdateDaqOut(2, ADoutTable[curRow_ADoutTable][3]);
                    presentMFCsetting[2] = (ADoutTableValues_d[curRow_ADoutTable][3]);
                }

                else if (mfcNumber == 4)
                {
                    daqOutputMFC.UpdateDaqOut(3, ADoutTable[curRow_ADoutTable][4]);
                    presentMFCsetting[3] = (ADoutTableValues_d[curRow_ADoutTable][4]);
                }
            }
            catch
            {
                DaqOutputProblem();
            }

        }


        private void UpdateADgraphHandler(object obj, EventArgs e)
        {
            if (UpdateADgraphBusy == true)
                return;
            else
            {
                UpdateADgraph();
            }
        }

        private async void UpdateADacquireHandlerAsync(object obj, EventArgs e)
        {
            if (UpdateADacquireBusy == true)
                return;
            else
            {
                await UpdateADacquireAsync();
            }
        }

        private async void SaveADdataHandlerAsync(object obj, EventArgs e)
        {
            if (saveADdataBusy == true)
                return;
            else
            {
                await SaveADdataAsync();
            }
        }


        private async Task UpdateADacquireAsync()
        {
            //Record new A/D data input

            UpdateADacquireBusy = true;

            try
            {
                daqInput.Read(ref currentADin);
            }
            catch
            {
                string messageBoxText = "Do you want to exit?";
                string caption = "DAQ Input Problem";
                var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Settings1.Default.mfcMainControlEnable = false;
                    Settings1.Default.Save();
                    Environment.Exit(0);
                }
            }


            // Don't worry about saving AD data in or plotting it if recipe not runnin
            if (recipeRunning != true)
            {
                UpdateADacquireBusy = false;
                return;
            }


            await SaveADdataAsync();
            UpdateADacquireBusy = false;
        }

        private async Task SaveADdataAsync()
        {
            saveADdataBusy = true;
            //Open AD results text file, append data to it

            //ADinputSaveFormat_s += "\t{" + (numActiveMFCs).ToString() + ":F6}";

            //write time to File
            await swriter.WriteAsync(string.Format("{0:F3}", watch.GetMsElapsed() * .001));

            //Output active MFCs input information
            //int numActiveMFCs = 0;
            for (int i = 0; i < stateMFCs.Length; i++)
            {
                if (stateMFCs[i] == true)
                {
                    //numActiveMFCs++;
                    await swriter.WriteAsync(string.Format("\t{0:F6}", DaqAction.GetMFCflowFromVolts(currentADin[i], i + 1)));
                }
            }

            await swriter.WriteAsync(Environment.NewLine);

            saveADdataBusy = false;
        }

        private void UpdateADgraph()
        {
            //the GenTimer class operates the timer on a different thread than the UI
            //UI updates must though be executed on the UI thread, this code ensures that happens

            UpdateADgraphBusy = true;

            if (InvokeRequired)
            {
                BeginInvoke(new UpdateADgraphDelegate(UpdateADgraph));
                return;
            }


            double time = Math.Round(Convert.ToDouble(watch.GetMsElapsed()) / 1000.0 / 60.0, 2);

            chart1.Series[0].Points.AddXY(time, DaqAction.GetMFCflowFromVolts(currentADin[0], 1));
            chart1.Series[1].Points.AddXY(time, DaqAction.GetMFCflowFromVolts(currentADin[1], 2));
            chart1.Series[2].Points.AddXY(time, DaqAction.GetMFCflowFromVolts(currentADin[2], 3));
            chart1.Series[3].Points.AddXY(time, DaqAction.GetMFCflowFromVolts(currentADin[3], 4));

            ADgraphUpdateCnt++;
            if (ADgraphUpdateCnt >= Settings1.Default.SamplesToGraphReset)
            {
                resetGraphButton_Click(this, EventArgs.Empty);
                ADgraphUpdateCnt = 0;
            }

            UpdateADgraphBusy = false;
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //timerSaveADdata.StopTimer();

            GCSettings.LatencyMode = GCLatencyMode.Interactive;
            timerADgraph.StopTimer();
            timerADacquire.StopTimer();
            timerUI.StopTimer();
            watch.StopStopwatch();

            //Zero all AD outputs
            if (Settings1.Default.mfcMainControlEnable == true)
                ZeroAllMFCOutputs();

            //Save all Settings
            Settings1.Default.Save();

            //wait for disk writes, our timer handlers to finish before closing file
            while ((saveADdataBusy == true) || (UpdateADacquireBusy == true) || (updateADoutputBusy == true))
                Thread.Sleep(200);

            if (IsADoutfileOpen == true)
            {
                swriter.Close();
                IsADoutfileOpen = false;
            }

        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings1.Default.Save();
        }

        private void configMFCbuttonClick(object sender, EventArgs e)
        {
            MFCconfigure1 = new ConfigureMFCs();

            MFCconfigure1.ShowDialog();

            mfcControl1.UpdateConfig();
            mfcControl2.UpdateConfig();
            mfcControl3.UpdateConfig();
            mfcControl4.UpdateConfig();
            chart1.Series[0].Name = Settings1.Default.MFC1Gas;
            chart1.Series[1].Name = Settings1.Default.MFC2Gas;
            chart1.Series[2].Name = Settings1.Default.MFC3Gas;
            chart1.Series[3].Name = Settings1.Default.MFC4Gas;
        }

        public void MfcPlotCheck_CheckedChanged(int MFCnumber, bool checkState)
        {
            if (checkState == true)
                chart1.Series[MFCnumber - 1].Enabled = true;
            else
                chart1.Series[MFCnumber - 1].Enabled = false;

        }


        public void mfcTextBox_ValueChanged(int mfcNumber, decimal valueNew)
        {
            double inputValue = DaqAction.GetVoltsFromMFCflow(valueNew.ToString(), mfcNumber);

            switch (mfcNumber)
            {
                case 1:
                    if (Settings1.Default.MFC1enable == true)
                        daqOutputMFC.UpdateDaqOut(mfcNumber - 1, inputValue);
                    break;
                case 2:
                    if (Settings1.Default.MFC2enable == true)
                        daqOutputMFC.UpdateDaqOut(mfcNumber - 1, inputValue);
                    break;
                case 3:
                    if (Settings1.Default.MFC3enable == true)
                        daqOutputMFC.UpdateDaqOut(mfcNumber - 1, inputValue);
                    break;
                case 4:
                    if (Settings1.Default.MFC4enable == true)
                        daqOutputMFC.UpdateDaqOut(mfcNumber - 1, inputValue);
                    break;
            }


        }


        internal void resetGraphButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
        }

        private void graphUpdateUD_ValueChanged(object sender, EventArgs e)
        {
            //On Startup this value is 0, in this case don't overwritten saved GraphTimeUpdate value
            if (graphUpdateUDbox.Value != 0)
            {
                Settings1.Default.GraphTimeUpdateMS = Convert.ToInt32(graphUpdateUDbox.Value * 1000);
                Settings1.Default.ADacquireTime_ms = Convert.ToInt32(graphUpdateUDbox.Value * 1000);
            }

            timerADacquire.SetInterval(Settings1.Default.ADacquireTime_ms);
            timerADgraph.SetInterval(Settings1.Default.GraphTimeUpdateMS);
            Settings1.Default.Save();
        }

        // TODO Remove

        private void AinGraphUpdateBox_CheckedChanged(object sender, EventArgs e)
        {
            //Only Graph AD Input if both Update Box is Checked and MFC Control is enabled
            if ((AinGraphUpdateBox.Checked == true) && Settings1.Default.mfcMainControlEnable)
            {
                AinGraphUpdateState = true;
                timerADgraph.StartTimer();
            }
            else
            {
                AinGraphUpdateState = false;
                timerADgraph.StopTimer();
            }
        }

        private void samplesToResetUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings1.Default.SamplesToGraphReset = Convert.ToInt32(samplesToResetUpDown.Value);
            Settings1.Default.Save();
        }




        private void ke648xStart_Click(object sender, EventArgs e)
        {
            if (PicoammForm == null)
                PicoammForm = new Ke648xGUI(PicoammControl);

            PicoammForm.Show();
        }


        //Helper Functions

        internal void DaqOutputProblem()
        {
            string messageBoxText = "Do you want to exit?";
            string caption = "DAQ Output Problem";
            var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Settings1.Default.mfcMainControlEnable = false;
                Settings1.Default.sensorBiasEnable = false;
                Settings1.Default.Save();
                Environment.Exit(0);
            }
        }

        //Used for Drawing Rows in MFC Table
        private void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, e.CellBounds.Location, new Point(e.CellBounds.Right, e.CellBounds.Top));
        }

        internal void ZeroAllMFCOutputs()
        {
            try
            {
                daqOutputMFC.ZeroDaqOuts();
                mfcControl1.ZeroControl();
                mfcControl2.ZeroControl();
                mfcControl3.ZeroControl();
                mfcControl4.ZeroControl();
            }
            catch
            {
                DaqOutputProblem();
            }
        }

        private void ZeroAllBiasOutputs()
        {
            try
            {
                daqOutputBiases.UpdateDaqOut(Settings1.Default.sensorVgsDaqAO, Convert.ToDouble(0));
                daqOutputBiases.UpdateDaqOut(Settings1.Default.sensorVdsDaqAO, Convert.ToDouble(0));
            }
            catch
            {
                DaqOutputProblem();
            }
            vdsPresValTextBox.Text = "0.00";
            vgsPresValTextBox.Text = "0.00";
            VgsUpDown.Value = 0;
            VdsUpDown.Value = 0;
        }

        private void controlPicoammBox_CheckedChanged(object sender, EventArgs e)
        {
            if (controlPicoammBox.Checked == true)
            {
                PicoammControl.InitSession();
                PicoammControl.InitDevice();
                Settings1.Default.PicoammeterControlEnable = controlPicoammBox.Checked;
                picoammSettingsButton.Enabled = true;

            }
            else
            {
                PicoammControl.EndSession();
                Settings1.Default.PicoammeterControlEnable = controlPicoammBox.Checked;
                picoammSettingsButton.Enabled = false;

                //Hide Picoammeter window if Configuation window is open
                if (PicoammForm != null)
                    PicoammForm.Hide();
            }
        }

        private void mfcMainControlEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (mfcMainControlEnable.Checked == true)
            {
                mfcControl1.EnableUserControl();
                mfcControl2.EnableUserControl();
                mfcControl3.EnableUserControl();
                mfcControl4.EnableUserControl();
                timerADacquire.StartTimer();
                timerADgraph.StartTimer();
                timerADoutUpdate.StartTimer();
                timerUI.StartTimer();
                mfcRecipeControl1.loadFlowsButton.Enabled = true;
            }
            else
            {
                mfcControl1.DisableUserControl();
                mfcControl2.DisableUserControl();
                mfcControl3.DisableUserControl();
                mfcControl4.DisableUserControl();
                timerADacquire.StopTimer();
                timerADgraph.StopTimer();
                timerADoutUpdate.StopTimer();
                timerUI.StopTimer();
                mfcRecipeControl1.loadFlowsButton.Enabled = false;
                mfcRecipeControl1.startButton.Enabled = false;
            }
            Settings1.Default.mfcMainControlEnable = mfcMainControlEnable.Checked;
            AinGraphUpdateBox_CheckedChanged(this, EventArgs.Empty);
        }

        private void biasOutsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (biasOutsBox.Checked == true)
            {
                VgsUpDown.Enabled = true;
                VdsUpDown.Enabled = true;
                ZeroAllBiasOutputs();
            }
            else
            {
                VgsUpDown.Enabled = false;
                VdsUpDown.Enabled = false;
                ZeroAllBiasOutputs();
            }
            Settings1.Default.sensorBiasEnable = biasOutsBox.Checked;
        }

        private void vdsLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vdsLockCheckBox.Checked == true)
            {
                VdsUpDown.Enabled = false;
            }
            else if ((vdsLockCheckBox.Checked == false) && (Settings1.Default.sensorBiasEnable == true))
            {
                VdsUpDown.Enabled = true;
            }
            Settings1.Default.sensorVdsDaqLock = vdsLockCheckBox.Checked;
        }

        private void vgsLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vgsLockCheckBox.Checked == true)
            {
                VgsUpDown.Enabled = false;
            }
            else if ((vgsLockCheckBox.Checked == false) && (Settings1.Default.sensorBiasEnable == true))
            {
                VgsUpDown.Enabled = true;
            }
            Settings1.Default.sensorVgsDaqLock = vgsLockCheckBox.Checked;
        }

        private void VdsUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                daqOutputBiases.UpdateDaqOut(Settings1.Default.sensorVdsDaqAO, Convert.ToDouble(VdsUpDown.Value));
            }
            catch
            {
                DaqOutputProblem();
            }
            vdsPresValTextBox.Text = VdsUpDown.Value.ToString("0.00");
        }

        private void VgsUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                daqOutputBiases.UpdateDaqOut(Settings1.Default.sensorVgsDaqAO, Convert.ToDouble(VgsUpDown.Value));
            }
            catch
            {
                DaqOutputProblem();
            }
            vgsPresValTextBox.Text = VgsUpDown.Value.ToString("0.00");
        }

        private void configBiasOutputButton_Click(object sender, EventArgs e)
        {
            configBiasForm1 = new ConfigBiasOutForm();

            configBiasForm1.ShowDialog();
        }

    }



}
