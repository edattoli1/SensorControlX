using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;

namespace MFCcontrol
{
    public class DaqAction
    {
        private NationalInstruments.DAQmx.Task myTask;
        private double daqOutputRangeMax;
        private double daqOutputRangeMin;

        public DaqAction()
        {
            daqOutputRangeMin = 0;
            daqOutputRangeMax = 5;
        }
        
        public DaqAction(double daqOutputRangeMinIn, double daqOutputRangeMaxIn)
        {
            daqOutputRangeMin = daqOutputRangeMinIn;
            daqOutputRangeMax = daqOutputRangeMaxIn;
        }


        // Reads input values from DAQ,
        // which DAQs to read from is controlled from Properties.Settings.Default.DAQ_CreateVoltageChannel_AI_chans
        public void Read(ref double[] currentValue)
        {
            try
            {
                //Create a new task
                using (myTask = new NationalInstruments.DAQmx.Task())
                {
                    //Create a virtual channel
                    
                    //"Dev1/ai0,Dev1/ai1"
                    myTask.AIChannels.CreateVoltageChannel(Properties.Settings.Default.DAQ_CreateVoltageChannel_AI_chans, "",
                        (AITerminalConfiguration.Rse), 0.0,
                        5.0, AIVoltageUnits.Volts);

                    AnalogMultiChannelReader reader = new AnalogMultiChannelReader(myTask.Stream);

                    //Verify the Task
                    myTask.Control(TaskAction.Verify);

                    //Initialize the table
                    //InitializeDataTable(myTask.AIChannels,ref dataTable); 
                    //acquisitionDataGrid.DataSource=dataTable;

                    //Plot Multiple Channels to the table
                    double[] data = reader.ReadSingleSample();
                    currentValue = data;
                    //dataToDataTable(data,ref dataTable);
                }
            }
            catch (DaqException exception)
            {
                System.Windows.Forms.MessageBox.Show(exception.Message);
                throw;
            }
        }

        //zeros all Daq Out Channels
        public void ZeroDaqOuts()
        {
            for (int i = 0; i < Properties.Settings.Default.MFCcontrol_numMFCs; i++)
            {
                    UpdateDaqOut(i, 0);
                
            }
        }


        public void UpdateDaqOut(int AOchannel, double voltOut)
        {
            string AOchannel_s = "Dev1/ao0";

            switch (AOchannel)
            {
                case 0:
                    AOchannel_s = "Dev1/ao0";
                    break;
                case 1:
                    AOchannel_s = "Dev1/ao1";
                    break;
                case 2:
                    //AOchannel_s = "Dev1/ao1";
                    AOchannel_s = "Dev1/ao0";
                    break;
                case 3:
                    //AOchannel_s = "Dev1/ao1";
                    AOchannel_s = "Dev1/ao1";
                    break;
            }
            
            try
            {
                using (myTask = new NationalInstruments.DAQmx.Task())
                {
                    myTask.AOChannels.CreateVoltageChannel(AOchannel_s, "aoChannel",
                        0.0, 5.0, AOVoltageUnits.Volts);
                    AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(myTask.Stream);
                    writer.WriteSingleSample(true, voltOut);
                }
            }
            catch (DaqException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
        }

        //Overloaded function, accepts string as AOchannel input
        public void UpdateDaqOut(string AOchannel_s, double voltOut)
        {
            try
            {
                using (myTask = new NationalInstruments.DAQmx.Task())
                {
                    myTask.AOChannels.CreateVoltageChannel(AOchannel_s, "aoChannel",
                        daqOutputRangeMin, daqOutputRangeMax, AOVoltageUnits.Volts);
                    AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(myTask.Stream);
                    writer.WriteSingleSample(true, voltOut);
                }
            }
            catch (DaqException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
        }


        static public double GetVoltsFromMFCflow(string inputFlow, int mfcNumber)
        {
            double inputFlow_d = Convert.ToDouble(inputFlow);

            switch (mfcNumber)
            {
                case 1:
                    return (inputFlow_d / Convert.ToDouble(Properties.Settings.Default.MFC1maxRange)) * 5;
                case 2:
                    return (inputFlow_d / Convert.ToDouble(Properties.Settings.Default.MFC2maxRange)) * 5;
                case 3:
                    return (inputFlow_d / Convert.ToDouble(Properties.Settings.Default.MFC3maxRange)) * 5;
                case 4:
                    return (inputFlow_d / Convert.ToDouble(Properties.Settings.Default.MFC4maxRange)) * 5;
                default:
                    return 0;
            }
        }

        static public double GetMFCflowFromVolts(double inputVolts, int mfcNumber)
        {
            switch (mfcNumber)
            {
                case 1:
                    return (inputVolts / 5) * Convert.ToDouble(Properties.Settings.Default.MFC1maxRange);
                case 2:
                    return (inputVolts / 5) * Convert.ToDouble(Properties.Settings.Default.MFC2maxRange);
                case 3:
                    return (inputVolts / 5) * Convert.ToDouble(Properties.Settings.Default.MFC3maxRange);
                case 4:
                    return (inputVolts / 5) * Convert.ToDouble(Properties.Settings.Default.MFC4maxRange);
                default:
                    return 0;
            }
        }


    }

}
