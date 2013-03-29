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
using MFCcontrol.Properties;

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
        
        internal int curRow_ADoutTable;
        internal bool recipeRunning;
        internal bool AinGraphUpdateState;
        private int ADgraphUpdateCnt;
        private double[] presentMFCsetting;
        private static Ke648xGUI PicoammForm;
        static private Ke648xControl PicoammControl;

        // Array which contains all the individual MFC Controls on this form
        internal MFCcontrolTemplate[] mfcControlArray;

        // state of the MFCs for the recipe to be used
        // 0th in array corresponds to MFC 1, .., etc
        internal bool[] stateMFCs;

        internal bool[] mfcPlotEnableArray;

        internal string[] mfcGasNames = new string[Settings.Default.MFCcontrol_numMFCs];

        // maximum flow rate of the MFCs for the recipe to be used
        // 0th in array corresponds to MFC 1, .., etc
        internal int[] maxFlowMFCs;
        
        

        // TODO REMOVE
        //internal string[] mfcMaxRanges = new string[Settings.Default.MFCcontrol_numMFCs];

        private ConfigureMFCs MFCconfigure1;

        //used for closing file properly when stop or exit button is hit
        internal bool IsADoutfileOpen = false;

        public Form1()
        {
            InitializeComponent();

            //Used for Drawing Rows in MFC table
            //tableLayoutPanel1.CellPaint += tableLayoutPanel_CellPaint;
            tableLayoutPanel2.CellPaint += tableLayoutPanel_CellPaint;

            // Initialized Saved Settings Values Into Form

            graphMfcs1.samplesToResetUpDown.Value = Properties.Settings.Default.SamplesToGraphRst;
            AinGraphUpdateState = true;

            stateMFCs = new bool[Properties.Settings.Default.MFCcontrol_numMFCs];
            maxFlowMFCs = new int[Properties.Settings.Default.MFCcontrol_numMFCs];

            currentADin = new double[Properties.Settings.Default.MFCcontrol_numMFCs];
            presentMFCsetting = new double[Properties.Settings.Default.MFCcontrol_numMFCs];

            // Initialize mfcControlList

            mfcControlArray = new MFCcontrolTemplate[] { mfcControl1, mfcControl2, mfcControl3, mfcControl4, mfcControl5, mfcControl6, mfcControl7, mfcControl8 };

            stateMFCs = Util.StringToBoolArray(Settings.Default.MfcControlEnableList);

            mfcGasNames = Util.StringToStringArray(Settings.Default.MfcGasNamesList);

            maxFlowMFCs = Util.StringToIntArray(Settings.Default.MfcMaxRangeList);

            mfcPlotEnableArray = Util.StringToBoolArray(Settings.Default.MfcPlotEnableList);

            // Initialize Members of Form1 Class

            daqInput = new DaqAction();
            daqOutputMFC = new DaqAction();

            watch = new GenStopwatch();

            timerUI = new GenTimer();
            timerUI.SetInterval(Properties.Settings.Default.timerUI_ms);

            //timerADacquire = new HiResTimer();
            timerADacquire = new GenTimer();
            timerADacquire.SetInterval(Properties.Settings.Default.ADacquireTime_ms);

            timerADgraph = new GenTimer();
            timerADgraph.SetInterval(Properties.Settings.Default.GraphTimeUpdateMS);

            //Set NumericUpDown Control box for Graph Update Time to Saved Value
            graphMfcs1.graphUpdateUDbox.Value = Convert.ToDecimal(Properties.Settings.Default.GraphTimeUpdateMS) / 1000;

            timerADoutUpdate = new GenTimer();
            timerADoutUpdate.AutoResetEnable();
            timerADoutUpdate.SetInterval(Properties.Settings.Default.ADoutRefreshTime_ms);


        }

        internal void Form1_Load(object sender, EventArgs e)
        {

            //Make sure counters are at 0 (for DAQ output and Graph Reset count)
            curRow_ADoutTable = 0;
            ADgraphUpdateCnt = 0;

            graphMfcs1.timeElapsedBox.Text = (watch.GetMsElapsed() / 3600.0).ToString();

            //Let graph user control  know about parent form
            graphMfcs1.parentForm = this;

            //Let recipe control panel know about parent form
            mfcRecipeControl1.parentForm = this;

            //Let sensor bias user control know about parent form
            sensorBiasControl1.parentForm = this;

            // Let MFC Control Panels know that about parent form so they can interact with it
            for (int i = 0; i < mfcControlArray.Length; i++)
                mfcControlArray[i].parentForm = this;


            //Set MFC Main Control Check Box to saved Value
            mfcMainControlEnable.Checked = Properties.Settings.Default.mfcMainControlEnable;

            //Set MFC USer Controls to correct MFC
            for (int j = 0; j < mfcControlArray.Length; j++)
                mfcControlArray[j].SetMFCnumber(j+1);

            //Default MFC Control State is OFF
            for (int i = 0; i < mfcControlArray.Length; i++)
                mfcControlArray[i].DisableUserControl();


            // Picoammeter init stuff
            picoammSettingsButton.Enabled = false;
            PicoammControl = new Ke648xControl();
            controlPicoammBox.Checked = Properties.Settings.Default.PicoammeterControlEnable;

            //start StopWatch
            watch.StartStopwatch();

            //start UI Timer
            timerUI.TimerElapsed += UpdateUIhandler;


            //start AD timer (when to acquire from A/D)
            UpdateADacquireBusy = false;
            timerADacquire.TimerElapsed += UpdateADacquireHandlerAsync;

            //start AD graph timer (when to graph data from A/D)
            timerADgraph.TimerElapsed += UpdateADgraphHandler;

            //if (Properties.Settings.Default.mfcMainControlEnable == true)
            {
                timerADacquire.StartTimer();
                timerADgraph.StartTimer();
                timerUI.StartTimer();
                //Zero all AD outputs
                ZeroAllMFCOutputs();
                for (int i = 0; i < mfcControlArray.Length; i++)
                    mfcControlArray[i].EnableUserControl();
            }

           sensorBiasControl1.SensorBiasControlInit();

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

            graphMfcs1.timeElapsedBox.Text = text;

            for (int i = 0; i < mfcControlArray.Length; i++)
                mfcControlArray[i].UpdatePresFlowBox(DaqAction.GetMFCflowFromVolts(currentADin[i], i+1));

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

                for (int i = 0; i < mfcControlArray.Length; i++)
                    mfcControlArray[i].UpdateSetFlowValue(presentMFCsetting[i]);

            }
        }

        //delegate void UpdateADgraphDelegate();

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
                for (int i = 1; i <= Properties.Settings.Default.MFCcontrol_numMFCs; i++)
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
                daqOutputMFC.UpdateDaqOut(mfcNumber - 1, ADoutTable[curRow_ADoutTable][mfcNumber]);
                presentMFCsetting[mfcNumber - 1] = (ADoutTableValues_d[curRow_ADoutTable][mfcNumber]);

                //if (mfcNumber == 1)
                //{
                //    daqOutputMFC.UpdateDaqOut(0, ADoutTable[curRow_ADoutTable][1]);
                //    presentMFCsetting[0] = (ADoutTableValues_d[curRow_ADoutTable][1]);
                //}

                //else if (mfcNumber == 2)
                //{
                //    daqOutputMFC.UpdateDaqOut(1, ADoutTable[curRow_ADoutTable][2]);
                //    presentMFCsetting[1] = (ADoutTableValues_d[curRow_ADoutTable][2]);
                //}

                //else if (mfcNumber == 3)
                //{
                //    daqOutputMFC.UpdateDaqOut(2, ADoutTable[curRow_ADoutTable][3]);
                //    presentMFCsetting[2] = (ADoutTableValues_d[curRow_ADoutTable][3]);
                //}

                //else if (mfcNumber == 4)
                //{
                //    daqOutputMFC.UpdateDaqOut(3, ADoutTable[curRow_ADoutTable][4]);
                //    presentMFCsetting[3] = (ADoutTableValues_d[curRow_ADoutTable][4]);
                //}
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
                    Properties.Settings.Default.mfcMainControlEnable = false;
                    Properties.Settings.Default.Save();
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
                //BeginInvoke(new UpdateADgraphDelegate(UpdateADgraph));
                BeginInvoke((Action)UpdateADgraph);
                return;
            }


            double time = Math.Round(Convert.ToDouble(watch.GetMsElapsed()) / 1000.0 / 60.0, 2);

            for (int i = 0; i < mfcControlArray.Length; i++)
                graphMfcs1.chart1.Series[i].Points.AddXY(time, DaqAction.GetMFCflowFromVolts(currentADin[i], i+1));

            ADgraphUpdateCnt++;

            if (ADgraphUpdateCnt >= Properties.Settings.Default.SamplesToGraphRst)
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
            if (Properties.Settings.Default.mfcMainControlEnable == true)
                ZeroAllMFCOutputs();

            //Save all Settings
            Properties.Settings.Default.Save();

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
            Properties.Settings.Default.Save();
        }

        private void configMFCbuttonClick(object sender, EventArgs e)
        {
            MFCconfigure1 = new ConfigureMFCs();

            MFCconfigure1.ShowDialog();

            

            for (int i = 0; i < mfcControlArray.Length; i++)
            {
                mfcControlArray[i].UpdateConfig();
                graphMfcs1.chart1.Series[i].Name = mfcGasNames[i];
            }

        }

        public void MfcPlotCheck_CheckedChanged(int MFCnumber, bool checkState)
        {
            if (checkState == true)
                graphMfcs1.chart1.Series[MFCnumber - 1].Enabled = true;
            else
                graphMfcs1.chart1.Series[MFCnumber - 1].Enabled = false;

        }


        public void mfcTextBox_ValueChanged(int mfcNumber, decimal valueNew)
        {
            double inputValue = DaqAction.GetVoltsFromMFCflow(valueNew.ToString(), mfcNumber);
          
            if ( stateMFCs[mfcNumber-1] == true)
                daqOutputMFC.UpdateDaqOut(mfcNumber - 1, inputValue);

            //switch (mfcNumber)
            //{
            //    case 1:
            //        if (Properties.Settings.Default.MFC1enable == true)
            //            daqOutputMFC.UpdateDaqOut(mfcNumber - 1, inputValue);
            //        break;
            //    case 2:
            //        if (Properties.Settings.Default.MFC2enable == true)
            //            daqOutputMFC.UpdateDaqOut(mfcNumber - 1, inputValue);
            //        break;
            //    case 3:
            //        if (Properties.Settings.Default.MFC3enable == true)
            //            daqOutputMFC.UpdateDaqOut(mfcNumber - 1, inputValue);
            //        break;
            //    case 4:
            //        if (Properties.Settings.Default.MFC4enable == true)
            //            daqOutputMFC.UpdateDaqOut(mfcNumber - 1, inputValue);
            //        break;
            //}


        }

        // Needed for user control classes
        internal void resetGraphButton_Click(object sender, EventArgs e)
        {
            graphMfcs1.resetGraphButton_Click(sender, e);
        }


        private void ke648xStart_Click(object sender, EventArgs e)
        {
            if (PicoammForm == null)
                PicoammForm = new Ke648xGUI(this, PicoammControl);

            controlPicoammBox.Enabled = false;
            PicoammForm.Show();
        }


        //Helper Functions
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        internal void DaqOutputProblem()
        {
            string messageBoxText = "Do you want to exit?";
            string caption = "DAQ Output Problem";
            var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.mfcMainControlEnable = false;
                Properties.Settings.Default.sensorBiasEnable = false;
                Properties.Settings.Default.Save();
                Environment.Exit(0);
            }
        }

        //Used for Drawing Rows in MFC Table
        internal void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            //e.Graphics.DrawLine(Pens.Black, e.CellBounds.Location, new Point(e.CellBounds.Right, e.CellBounds.Top));
            e.Graphics.DrawLine(Pens.Black, new Point(e.CellBounds.Left, e.CellBounds.Bottom), new Point(e.CellBounds.Right, e.CellBounds.Bottom));
        }

        internal void ZeroAllMFCOutputs()
        {
            try
            {
                daqOutputMFC.ZeroDaqOuts();

                for (int i = 0; i < mfcControlArray.Length; i++)
                    mfcControlArray[i].ZeroControl();
            }
            catch
            {
                DaqOutputProblem();
            }
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void controlPicoammBox_CheckedChanged(object sender, EventArgs e)
        {
            if (controlPicoammBox.Checked == true)
            {
                PicoammControl.InitSession();
                PicoammControl.InitDevice();

                Properties.Settings.Default.PicoammeterControlEnable = controlPicoammBox.Checked;
                picoammSettingsButton.Enabled = true;

            }
            else
            {
                PicoammControl.EndSession();
                Properties.Settings.Default.PicoammeterControlEnable = controlPicoammBox.Checked;
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

                for (int i = 0; i < mfcControlArray.Length; i++)
                    mfcControlArray[i].EnableUserControl();
                timerADacquire.StartTimer();
                timerADgraph.StartTimer();
                timerADoutUpdate.StartTimer();
                timerUI.StartTimer();
                mfcRecipeControl1.loadFlowsButton.Enabled = true;
            }
            else
            {
                for (int i = 0; i < mfcControlArray.Length; i++)
                    mfcControlArray[i].DisableUserControl();
                timerADacquire.StopTimer();
                timerADgraph.StopTimer();
                timerADoutUpdate.StopTimer();
                timerUI.StopTimer();
                mfcRecipeControl1.loadFlowsButton.Enabled = false;
                mfcRecipeControl1.startButton.Enabled = false;
            }
            Properties.Settings.Default.mfcMainControlEnable = mfcMainControlEnable.Checked;
            graphMfcs1.AinGraphUpdateBox_CheckedChanged(this, EventArgs.Empty);
        }


    }



}
