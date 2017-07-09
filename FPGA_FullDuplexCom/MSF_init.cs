using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTD2XX_NET;
using System.Windows.Forms;

namespace FPGA_FullDuplexCom
{
    class MSF_init
    {


        public int perfectFrames = 0;
        public int corruptedFrames = 0;
        public int skippedFrames = 0;
        public int allFrames = 0;

        //============================================
        bool started = false;
        FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
        UInt32 ftdiDeviceCount = 0;
        //Create new instance of the FTDI device class
        FTDI myFtdiDevice = new FTDI();
        //==============================================

        private int SignalCount;
        public MSF_init(int SignalCount)
        {
            fdti_init();
            this.SignalCount = SignalCount;

        }

        public void resetparams()
        {
            perfectFrames = 0;
            corruptedFrames = 0;
            skippedFrames = 0;
            allFrames = 0;
        }
        private bool FtdiInitISactive
        {
            get { return ftdiInitISactive; }
            set { ftdiInitISactive = value; }
        }

        public int[] readfromDevice()
        {
            UInt32 numBytesAvailable = 0;
            //ftStatus = myFtdiDevice.Purge(FTDI.FT_PURGE.FT_PURGE_RX);
            ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")");
                //return;
            }
            //lines = Int32.Parse(RealTimeSignal_number.EditValue.ToString());
            UInt32 numBytesRead = 0;
            byte[] buff = new byte[numBytesAvailable];
            ftStatus = myFtdiDevice.Read(buff, numBytesAvailable, ref numBytesRead);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to read data (error " + ftStatus.ToString() + ")");
                // return;
            }

            return processIntInput(buff);
        }


        bool rotated = false;
        int restvalue = 0;

        private int[] processIntInput(byte[] byteInput)
        {
            int k = 0;
            List<int> Buffer = new List<int>();
            int[] tempBuffer;
            for (int i = 0; i < byteInput.Length; i++)
            {

                if (rotated)
                {
                    if ((2 * restvalue) + 2 < byteInput.Length)
                    {


                        if (Convert.ToUInt16(byteInput[(2 * restvalue) + 1]) == 85)
                        {
                            if (Convert.ToUInt16(byteInput[(2 * restvalue) + 2]) == 170)
                            {
                                while (true)
                                {
                                    if (i < 2 * restvalue)
                                    {
                                        Buffer.Add(
                                            (int)
                                            BitConverter.ToInt16(
                                                new byte[2] { (byte)byteInput[k + 1], (byte)byteInput[k] }, 0));
                                        k += 2;
                                        i++;
                                    }
                                    else
                                    {
                                        rotated = false;
                                        i += 2;
                                        break;
                                    }
                                }

                            }
                        }

                    }

                }
                if (byteInput.Length >= i + 2)
                {
                    if (Convert.ToUInt16(byteInput[i]) == 170)
                    {

                        if (Convert.ToUInt16(byteInput[i + 1]) == 85)
                        {
                            int from = i + 2;
                            int line_count = 0;
                            i += 1;
                            allFrames++;

                            if (from + SignalCount * 2 + 2 > byteInput.Length)
                            {
                                //  rotated = true;
                                restvalue = SignalCount - line_count;
                                //rotated frame counting 
                                skippedFrames++;
                            }
                            else
                            {
                                if (Convert.ToUInt16(byteInput[i + SignalCount * 2 + 1]) == 85)
                                {
                                    if (Convert.ToUInt16(byteInput[i + SignalCount * 2 + 2]) == 170)
                                    {
                                        //XtraMessageBox.Show(Convert.ToUInt16(byteInput[i]).ToString());
                                        //XtraMessageBox.Show("Header found");
                                        Buffer.Add(43605);

                                        for (int j = 0; j < SignalCount; j++)
                                        {
                                            // string temp;
                                            //  temp = IntInput[from].ToString() + IntInput[from + 1].ToString();
                                            //temp = Convert.ToString(IntInput[from], 2).PadLeft(8, '0') + Convert.ToString(IntInput[from+1], 2).PadLeft(8, '0'); ;
                                            //XtraMessageBox.Show("???" + temp + "???");
                                            //XtraMessageBox.Show(Convert.ToUInt16(temp).ToString());

                                            //   XtraMessageBox.Show(BitConverter.ToUInt16(new byte[2] { (byte)byteInput[from], (byte)byteInput[from + 1] }, 0).ToString());
                                            //if (!(from + 2 > byteInput.Length))
                                            //{
                                            try
                                            {



                                                Buffer.Add(
                                                    (int)
                                                    BitConverter.ToInt16(
                                                        new byte[2] { (byte)byteInput[from + 1], (byte)byteInput[from] },
                                                        0));

                                                from += 2;

                                                line_count += 1;
                                            }
                                            catch (Exception e)
                                            {
                                                //Console.WriteLine(e.ToString());
                                                MessageBox.Show("Error modem");
                                            }
                                            //}
                                            //else
                                            //{
                                            //rotated = true;
                                            //  restvalue = SignalCount - line_count;
                                            //}



                                        }
                                        ///*************************
                                        // any problem in real time ploting is from here 
                                        //****************
                                        i += SignalCount * 2 + 2;

                                    }
                                    else
                                    {
                                        corruptedFrames++;
                                    }
                                }
                                else
                                {
                                    corruptedFrames++;
                                }

                            }


                        }
                    }
                }


            }
            tempBuffer = Buffer.ToArray();
            return tempBuffer;

        }

        public void mydeviceinitialiser()
        {
            fdti_init();
        }
        public bool ftdiInitISactive = false;
        private void fdti_init()
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
                //this.Close();
                //    return;
            }

            // If no devices available, return
            if (ftdiDeviceCount == 0)
            {
                // Wait for a key press
                MessageBox.Show("Failed to get number of devices (error " + ftStatus.ToString() + ")");
                //  this.Close();
                return;
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
                MessageBox.Show("FT_OK");
            }


            // Open first device in our list by serial number
            ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[0].SerialNumber);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to open device (error " + ftStatus.ToString() + ")");
                return;
            }



            ftStatus = myFtdiDevice.SetBitMode(0xFF, FTDI.FT_BIT_MODES.FT_BIT_MODE_RESET);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set Reset mode (error " + ftStatus.ToString() + ")");
                return;
            }
            // Thread.Sleep(10);


            ftStatus = myFtdiDevice.SetBitMode(0xFF, FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_FIFO);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set FIFO mode (error " + ftStatus.ToString() + ")");
                return;
            }
            // Set flow control - set RTS/CTS flow control

            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set flow control (error " + ftStatus.ToString() + ")");
                return;
            }
            //++++++++++++++++++++++++++++++++++++++++++
            ftStatus = myFtdiDevice.SetLatency(0);

            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to st latency (error " + ftStatus.ToString() + ")");
                return;
            }
            //++++++++++++++++++++++++++++++++++++++++++

            //++++++++++++++++++++++++++++++++++++++++++
            // Set read timeout to 5 seconds, write timeout to infinite
            ftStatus = myFtdiDevice.SetTimeouts(2000, 500);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                MessageBox.Show("Failed to set timeouts (error " + ftStatus.ToString() + ")");
                return;
            }
            ftdiInitISactive = true;
        }
    }
}
