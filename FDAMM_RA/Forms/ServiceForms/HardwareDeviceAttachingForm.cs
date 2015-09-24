using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using Resources;

using FTD2XX_NET;

namespace FDAMM_RA
{
    public partial class HardwareDeviceAttachingForm : Form
    {
        internal MainForm mForm;
        UInt32 ftdiDeviceCount = 0;
        public FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
        public FTDI ftdiDevice;
        public FTDI.FT_STATUS STATUS_OK = FTDI.FT_STATUS.FT_OK;

        private System.Windows.Forms.Button Button_HardwareDevic_Unit;

        public HardwareDeviceAttachingForm(MainForm mainForm)
        {
            mForm = mainForm;
            InitializeComponent();
        }

        private void HardwareDeviceAttaching_Load(object sender, EventArgs e)
        {
            refreshDevices();
        }

        private void button1_HardwareDeviceAttaching_Refresh_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(this);
            refreshDevices();
        }

        private void refreshDevices()
        {
            ftdiDevice = new FTDI();

            // Determine the number of FTDI devices connected to the machine
            ftStatus = ftdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                // If no devices available, return
                if (ftdiDeviceCount > 0)
                {
                    // Allocate storage for device info list
                    FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
                    // Populate our device list

                    ftStatus = ftdiDevice.GetDeviceList(ftdiDeviceList);
                    if (ftStatus == FTDI.FT_STATUS.FT_OK)
                    {
                        for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                        {
                            this.Button_HardwareDevic_Unit = new System.Windows.Forms.Button();
                            // 
                            // textBox_HardwareDevic_Unit
                            // 
                            //this.Button_HardwareDevic_Unit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
                            this.Button_HardwareDevic_Unit.ForeColor = System.Drawing.Color.Black;
                            //this.Button_HardwareDevic_Unit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            //this.Button_HardwareDevic_Unit.Enabled = false;
                            this.Button_HardwareDevic_Unit.Location = new System.Drawing.Point(10, (int)(10 + 50 + 10 + i * 110));
                            //this.Button_HardwareDevic_Unit.Multiline = true;
                            this.Button_HardwareDevic_Unit.Name = "textBox" + i.ToString();
                            this.Button_HardwareDevic_Unit.Text =                       
                                "Device Index: " + i.ToString() + Environment.NewLine +
                                "Flags: " + String.Format("{0:x}", ftdiDeviceList[i].Flags) + Environment.NewLine +
                                "Type: " + ftdiDeviceList[i].Type.ToString() + Environment.NewLine +
                                "ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID) + Environment.NewLine +
                                "Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId) + Environment.NewLine +
                                "Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString() + Environment.NewLine +
                                "Description: " + ftdiDeviceList[i].Description.ToString();
                            this.Button_HardwareDevic_Unit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                            this.Button_HardwareDevic_Unit.Size = new System.Drawing.Size(280, 100);
                            this.Button_HardwareDevic_Unit.TabIndex = (int)(i + 1);
                            this.SuspendLayout();
                            this.Controls.Add(this.Button_HardwareDevic_Unit);
                            this.Button_HardwareDevic_Unit.Click += new System.EventHandler(this.button_HardwareDeviceChoose_Click);
                            this.Button_HardwareDevic_Unit.Tag = ftdiDeviceList[i].SerialNumber;
                        }

                    }

                    this.ClientSize = new System.Drawing.Size(300, (int)(10 + 50 + ftdiDeviceCount * 110 + 10));

                }
            }
        }

        private void button_HardwareDeviceChoose_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Open first device in our list by serial number
            ftStatus = ftdiDevice.OpenBySerialNumber(btn.Tag.ToString());
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                MessageBox.Show("Connection failed.", "Attention!");
                return;
            }
            else
            {
                // Set up device data parameters
                // Set Baud rate to 9600
                ftStatus = ftdiDevice.SetBaudRate(9600);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                    mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                    MessageBox.Show("SetBaudRate failed.", "Attention!");
                    ftdiDevice.Close(); 
                    return;
                }
                else
                {
                    // Set data characteristics - Data bits, Stop bits, Parity
                    ftStatus = ftdiDevice.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_1, FTDI.FT_PARITY.FT_PARITY_NONE);
                    if (ftStatus != FTDI.FT_STATUS.FT_OK)
                    {
                        mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                        mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                        MessageBox.Show("SetDataCharacteristics failed.", "Attention!");
                        ftdiDevice.Close();
                        return;
                    }
                    else
                    {
                        // Set flow control - set RTS/CTS flow control
                        ftStatus = ftdiDevice.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0x11, 0x13);
                        if (ftStatus != FTDI.FT_STATUS.FT_OK)
                        {
                            mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                            mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                            MessageBox.Show("SetFlowControl failed.", "Attention!");
                            ftdiDevice.Close(); 
                            return;
                        }
                        else
                        {
                            // Set read timeout to 5 seconds, write timeout to infinite
                            ftStatus = ftdiDevice.SetTimeouts(5000, 0);
                            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                            {
                                mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                                mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                                MessageBox.Show("SetTimeouts failed.", "Attention!");
                                ftdiDevice.Close(); 
                                return;
                            }
                            else
                            {
                                
                                string dataToWrite;
                                dataToWrite = "l";
                                UInt32 numBytesWritten = 0;
                                // Note that the Write method is overloaded, so can write string or byte array data
                                ftStatus = ftdiDevice.Write(dataToWrite, dataToWrite.Length, ref numBytesWritten);
                                //ftStatus = myFtdiDevice.Write(bytes, bytes.Length, ref numBytesWritten);
                                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                                {
                                    // Wait for a key press
                                    mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                                    mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                                    MessageBox.Show("Failed to write to device (error " + ftStatus.ToString() + ")", "Attention!");
                                    ftdiDevice.Close();
                                    return;
                                }
                                else
                                {
                                    // Check the amount of data available to read
                                    // In this case we know how much data we are expecting, 
                                    // so wait until we have all of the bytes we have sent.
                                    UInt32 numBytesAvailable = 0;
                                    do
                                    {
                                        ftStatus = ftdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
                                        if (ftStatus != FTDI.FT_STATUS.FT_OK)
                                        {
                                            mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                                            mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                                            MessageBox.Show("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")");
                                            ftdiDevice.Close();
                                            return;
                                        }
                                        Thread.Sleep(10);
                                    } while (numBytesAvailable < dataToWrite.Length);

                                    // Now that we have the amount of data we want available, read it
                                    string readData;
                                    UInt32 numBytesRead = 0;
                                    // Note that the Read method is overloaded, so can read string or byte array data
                                    ftStatus = ftdiDevice.Read(out readData, numBytesAvailable, ref numBytesRead);
                                    if (ftStatus != FTDI.FT_STATUS.FT_OK)
                                    {
                                        mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                                        mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                                        MessageBox.Show("Failed to read data (error " + ftStatus.ToString() + ")");
                                        ftdiDevice.Close();
                                        return;

                                    }
                                    else
                                    {
                                        if (readData.Length > 1)
                                        {
                                            readData = readData.Remove(0, (readData.Length - 1));                              
                                        }
                                        
                                        if (readData == "m")
                                        {
                                            MessageBox.Show("Connection complete", "Success!");
                                            this.Hide();
                                            return;
                                        }
                                        else
                                        {
                                            mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                                            mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                                            MessageBox.Show("Connection failed. Invalid answer", "Attention!");
                                            ftdiDevice.Close();
                                            this.Hide();
                                            return;
                                        
                                        }
                                    
                                    }
                                
                                }

                            }
                        
                        
                        }

                    }

                }

            }

        }

        private void HardwareDeviceAttachingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ftdiDevice.IsOpen)
            {
                mForm.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                mForm.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
            }
        }
       
    }
}
