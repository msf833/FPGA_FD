using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTD2XX_NET;


namespace FPGA_FullDuplexCom
{
    public partial class Form1 : Form
    {
        //============================================
        bool started = false;
        FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
        FTDI.FT_STATUS ftStatus1 = FTDI.FT_STATUS.FT_OK;
        UInt32 ftdiDeviceCount = 0;
        //Create new instance of the FTDI device class
        FTDI myFtdiDevice = new FTDI();
        FTDI myFtdiDevice1 = new FTDI();

        //==============================================



        MSF_init MSFft = new MSF_init(32);

        string dataToWrite  = "Hello world!";

        public Form1()
        {
            InitializeComponent();
        }

        private void switch1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            //for first port
            fdti_init();
            // for seceond port
            ftdi_init2();
            
        }
        public void fdti_init()
        {
            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                // MessageBox.Show("Number of FTDI devices: " + ftdiDeviceCount.ToString());
                //  richTextBox1.AppendText("Number of FTDI devices: " + ftdiDeviceCount.ToString());
            }
            else
            {
                // Wait for a key press

                MessageBox.Show("Failed to get number of devices (error " + ftStatus.ToString() + ")");
                
                this.Close();
              
            }

            // If no devices available, return
            if (ftdiDeviceCount == 0)
            {
                // Wait for a key press
                MessageBox.Show("Failed to get number of devices (error " + ftStatus.ToString() + ")");
      
          
            }

            // Allocate storage for device info list
            FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

            // Populate our device list
            ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                //for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                //{
                //    // + Environment.NewLine
                //    richTextBox1.Text += ("Device Index: " + i.ToString());
                //    richTextBox1.Text += ("Flags: " + String.Format("{0:x}", ftdiDeviceList[i].Flags));
                //    richTextBox1.Text += ("Type: " + ftdiDeviceList[i].Type.ToString());
                //    richTextBox1.Text += ("ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID));
                //    richTextBox1.Text += ("Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId));
                //    richTextBox1.Text += ("Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString());
                //    richTextBox1.Text += ("Description: " + ftdiDeviceList[i].Description.ToString());
                //    richTextBox1.Text += ("");
                //}
                //toolStripStatusLabel2.Text += "FT_OK";
                statusLed.Value = true;

            }


            // Open first device in our list by serial number
            ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[0].SerialNumber);
           
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to open device (error " + ftStatus.ToString() + ")");
           
            }



            ftStatus = myFtdiDevice.SetBitMode(0xFF, FTDI.FT_BIT_MODES.FT_BIT_MODE_RESET);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set Reset mode (error " + ftStatus.ToString() + ")");
          
            }
            // Thread.Sleep(10);


            ftStatus = myFtdiDevice.SetBitMode(0xFF, FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_FIFO);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set FIFO mode (error " + ftStatus.ToString() + ")");
      
            }
            // Set flow control - set RTS/CTS flow control
            ftStatus = myFtdiDevice.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0x11, 0x13);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set flow control (error " + ftStatus.ToString() + ")");
              
            }
            //++++++++++++++++++++++++++++++++++++++++++
            ftStatus = myFtdiDevice.SetLatency(16);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to st latency (error " + ftStatus.ToString() + ")");
                return;
            }
            //++++++++++++++++++++++++++++++++++++++++++

            //++++++++++++++++++++++++++++++++++++++++++
            // Set read timeout to 5 seconds, write timeout to infinite
            ftStatus = myFtdiDevice.SetTimeouts(500, 0);
            
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set timeouts (error " + ftStatus.ToString() + ")");
             
            }
        }
        public void ftdi_init2()
        {
            // Determine the number of FTDI devices connected to the machine
            ftStatus1 = myFtdiDevice1.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus1 == FTDI.FT_STATUS.FT_OK)
            {
                // MessageBox.Show("Number of FTDI devices: " + ftdiDeviceCount.ToString());
                //  richTextBox1.AppendText("Number of FTDI devices: " + ftdiDeviceCount.ToString());
            }
            else
            {
                // Wait for a key press

                MessageBox.Show("Failed to get number of devices (error " + ftStatus1.ToString() + ")");

              

            }

            // If no devices available, return
            if (ftdiDeviceCount == 0)
            {
                // Wait for a key press
                MessageBox.Show("Failed to get number of devices (error " + ftStatus1.ToString() + ")");


            }

            // Allocate storage for device info list
            FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

            // Populate our device list
            ftStatus1 = myFtdiDevice1.GetDeviceList(ftdiDeviceList);

            if (ftStatus1 == FTDI.FT_STATUS.FT_OK)
            {
                //for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                //{
                //    // + Environment.NewLine
                //    richTextBox1.Text += ("Device Index: " + i.ToString());
                //    richTextBox1.Text += ("Flags: " + String.Format("{0:x}", ftdiDeviceList[i].Flags));
                //    richTextBox1.Text += ("Type: " + ftdiDeviceList[i].Type.ToString());
                //    richTextBox1.Text += ("ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID));
                //    richTextBox1.Text += ("Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId));
                //    richTextBox1.Text += ("Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString());
                //    richTextBox1.Text += ("Description: " + ftdiDeviceList[i].Description.ToString());
                //    richTextBox1.Text += ("");
                //}
                //toolStripStatusLabel2.Text += "FT_OK";
                statusLed.Value = true;

            }


            // Open first device in our list by serial number
            ftStatus1 = myFtdiDevice1.OpenBySerialNumber(ftdiDeviceList[1].SerialNumber);

            if (ftStatus1 != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to open device (error " + ftStatus1.ToString() + ")");

            }



            ftStatus1 = myFtdiDevice1.SetBitMode(0xFF, FTDI.FT_BIT_MODES.FT_BIT_MODE_RESET);
            if (ftStatus1 != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set Reset mode (error " + ftStatus1.ToString() + ")");

            }
            // Thread.Sleep(10);


            ftStatus1 = myFtdiDevice1.SetBitMode(0xFF, FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_FIFO);
            if (ftStatus1 != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set FIFO mode (error " + ftStatus1.ToString() + ")");

            }
            // Set flow control - set RTS/CTS flow control
            ftStatus1 = myFtdiDevice1.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0x11, 0x13);
            if (ftStatus1 != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set flow control (error " + ftStatus.ToString() + ")");

            }
            //++++++++++++++++++++++++++++++++++++++++++
            ftStatus1 = myFtdiDevice1.SetLatency(16);
            if (ftStatus1 != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to st latency (error " + ftStatus1.ToString() + ")");
                
            }
            //++++++++++++++++++++++++++++++++++++++++++

            //++++++++++++++++++++++++++++++++++++++++++
            // Set read timeout to 5 seconds, write timeout to infinite
            ftStatus1 = myFtdiDevice1.SetTimeouts(500, 0);

            if (ftStatus1 != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set timeouts (error " + ftStatus1.ToString() + ")");

            }
        }
        private void Reciever_DoWork(object sender, DoWorkEventArgs e)
        {
            
            UInt32 numBytesAvailable = 0;
            do
            {
                ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    // Wait for a key press
                    MessageBox.Show("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")");
                 
                    
                }
            } while (numBytesAvailable < dataToWrite.Length);

            // Now that we have the amount of data we want available, read it
            string readData;
            UInt32 numBytesRead = 0;
            // Note that the Read method is overloaded, so can read string or byte array data
            ftStatus = myFtdiDevice.Read(out readData, numBytesAvailable, ref numBytesRead);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to read data (error " + ftStatus.ToString() + ")");
                
            }
            textBox2.AppendText(readData);


        }

        private void btn_send_Click(object sender, EventArgs e)
        {
             dataToWrite = textBox1.Text;
            UInt32 numBytesWritten = 0;
            // Note that the Write method is overloaded, so can write string or byte array data
            ftStatus = myFtdiDevice.Write(dataToWrite, dataToWrite.Length, ref numBytesWritten);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {

                MessageBox.Show("Somthing wrong happend!");
            }
            Reciever.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void randomeGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            randomeGeneratorForm newMDIChild = new randomeGeneratorForm();
            // Set the Parent Form of the Child window.  
           // newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void refreshFTDIDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                // MessageBox.Show("Number of FTDI devices: " + ftdiDeviceCount.ToString());
                //  richTextBox1.AppendText("Number of FTDI devices: " + ftdiDeviceCount.ToString());
            }
            else
            {
                // Wait for a key press

                MessageBox.Show("Failed to get number of devices (error " + ftStatus.ToString() + ")");

            }

            // If no devices available, return
            if (ftdiDeviceCount == 0)
            {
                // Wait for a key press
                MessageBox.Show("Failed to get number of devices (error " + ftStatus.ToString() + ")");


            }

            // Allocate storage for device info list
            FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
            NuberOFFTDIDevieces.Text = "number of FT Devices :" + ftdiDeviceCount + "";
            // Populate our device list
            ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                //for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                //{
                //    // + Environment.NewLine
                //    richTextBox1.Text += ("Device Index: " + i.ToString());
                //    richTextBox1.Text += ("Flags: " + String.Format("{0:x}", ftdiDeviceList[i].Flags));
                //    richTextBox1.Text += ("Type: " + ftdiDeviceList[i].Type.ToString());
                //    richTextBox1.Text += ("ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID));
                //    richTextBox1.Text += ("Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId));
                //    richTextBox1.Text += ("Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString());
                //    richTextBox1.Text += ("Description: " + ftdiDeviceList[i].Description.ToString());
                //    richTextBox1.Text += ("");
                //}
                //toolStripStatusLabel2.Text += "FT_OK";
                statusLed.Value = true;

            }
        }








    }
}
