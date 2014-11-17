using System;
using System.Collections.Generic;
using System.Management;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace SMART_Monitor
{
    public partial class SMART_Monitor : Form
    {
        public SMART_Monitor()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            tTimer = new Thread(new ThreadStart(this.timerThread));
            tTimer.Start();
        }

        private void SMART_Monitor_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tTimer.Abort();
            this.Close();
        }

        private void getNextUpdateTime()
        {
            if (rbUpdateInterval.Checked)
            {
                switch (cbIntervalUnit.SelectedIndex)
                {
                    case 0:
                        dtNextUpdate = DateTime.Now.AddHours(Convert.ToDouble(nudInterval.Value));
                        break;
                    case 1:
                        dtNextUpdate = DateTime.Now.AddMinutes(Convert.ToDouble(nudInterval.Value));
                        break;
                    case 2:
                        dtNextUpdate = DateTime.Now.AddSeconds(Convert.ToDouble(nudInterval.Value));
                        break;
                }
                return;
            }
            if (rbUpdateSchedule.Checked)
            {
                //update later
                return;
            }
            if (rbUpdateManually.Checked)
            {
                dtNextUpdate = new DateTime(0);
            }
        }
        private void timerThread()
        {
            while (true)
            {
                DateTime execTime = DateTime.Now;
                this.Text = nudInterval.Value.ToString();
                if (dtNextUpdate.Ticks == 0)
                {
                    
                }
                else
                {
                    
                }
                //wait 1 sec
                Thread.Sleep(execTime.AddSeconds(1.0) - DateTime.Now);
            }
        }
        private void UpdateSMARTInfo()
        {
            dDrives.Clear(); // reset data

            var ddSearcher = new ManagementObjectSearcher("SELECT * from Win32_DiskDrive");
            int iDriveIndex = 0;
            foreach (ManagementObject drive in ddSearcher.Get())
            {
                var hdd = new HDD();
                hdd.Model = drive["Model"].ToString().Trim();
                hdd.Type = drive["InterfaceType"].ToString().Trim();
                try
                {
                    dDrives.Add(iDriveIndex, hdd);
                }
                catch 
                {
                	
                }
                iDriveIndex++;
            }

            //physical media searcher
            var pmSearcher = new ManagementObjectSearcher("SELECT * from Win32_PhysicalMedia");

            iDriveIndex = 0;
            foreach (ManagementObject drive in pmSearcher.Get())
            {
                //only hard drives
                if (iDriveIndex >= dDrives.Count())
                    break;
                dDrives[iDriveIndex].Serial = drive["SerialNumber"] == null ? "None" : drive["SerialNumber"].ToString().Trim();
                iDriveIndex++;
            }

            //wmi
            var searcher = new ManagementObjectSearcher();
            searcher.Scope = new ManagementScope(@"\root\wmi");

            //status of HDD
            searcher.Query = new ObjectQuery("SELECT * from MSStorageDriver_FailurePredictStatus");
            iDriveIndex = 0;
            foreach (ManagementObject drive in searcher.Get())
            {
                dDrives[iDriveIndex].IsOK = (bool)drive.Properties["PredictFailure"].Value == false;
                iDriveIndex++;
            }

            //data of SMART
            searcher.Query = new ObjectQuery("SELECT * from MSStorageDriver_FailurePredictData");
            iDriveIndex = 0;
            foreach (ManagementObject data in searcher.Get())
            {
                Byte[] bytes = (Byte[])data.Properties["VendorSpecific"].Value;
                for (int i = 0; i < 42; i++)
                {
                    try
                    {
                        int id = bytes[i * 12 + 2];
                        if (id == 0) continue;

                        //failurepredict
                        int flags = bytes[i * 12 + 4];
                        bool failurepredict = (flags & 0x1) == 0x1;

                        var attr = dDrives[iDriveIndex].Attributes[id];
                        attr.Current = bytes[i * 12 + 5];
                        attr.Worst = bytes[i * 12 + 6];
                        attr.ID = id;
                        attr.Data = BitConverter.ToInt32(bytes, i * 12 + 7);
                        attr.IsOK = failurepredict == false;
                    }
                    catch
                    {
                        //error handler
                    }
                }
                iDriveIndex++;
            }

            //threshold value retrieval
            searcher.Query = new ObjectQuery("SELECT * from MSStorageDriver_FailurePredictThresholds");
            iDriveIndex = 0;
            foreach (ManagementObject data in searcher.Get())
            {
                Byte[] bytes = (Byte[])data.Properties["VendorSpecific"].Value;
                for (int i = 0; i < 42; ++i)
                {
                    try
                    {

                        int id = bytes[i * 12 + 2];
                        if (id == 0) continue;

                        var attr = dDrives[iDriveIndex].Attributes[id];
                        attr.Threshold = bytes[i * 12 + 3];
                    }
                    catch
                    {
                        // error handler
                    }
                }
            }

            //update to combobox
            cbDrives.Items.Clear();

            foreach (var drive in dDrives)
            {
                if (drive.Value.Serial.Length < 2) continue;
                cbDrives.Items.Add(drive.Value.Serial);
                cbDrives.SelectedIndex = 0;
            }
        }

        
        private void ShowInfo()
        {
            //clear all
            dgvSmart.Rows.Clear();

            HDD drive;
            try
            {
                int iDriveIndex = cbDrives.SelectedIndex;
                drive = dDrives[iDriveIndex];
            }
            catch 
            {
                return;
            }


            //extract basic info
            lInfo.Text = "Serial : " + drive.Serial +
                "\nType : " + drive.Type +
                "\nModel : " + drive.Model +
                "\nStatus : " + drive.IsOK;

            //Attributes
            foreach (var attr in drive.Attributes)
            {
                if (attr.Value.HasData == false) continue;
                dgvSmart.Rows.Add(attr.Value.ID.ToString(),
                    attr.Value.Attribute,
                    attr.Value.Current.ToString(),
                    attr.Value.Worst.ToString(),
                    attr.Value.Threshold.ToString(),
                    attr.Value.Data.ToString(),
                    attr.Value.IsOK ? "OK" : "Not OK");
            }
        }
        #region (Local Variables)
        private Dictionary<int,HDD> dDrives = new Dictionary <int,HDD>();
        DateTime dtNextUpdate = new DateTime();
        Thread tTimer;
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateSMARTInfo();
            ShowInfo();
        }

        private void cbDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowInfo();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged();
        }

        private void CheckedChanged()
        {
            nudInterval.Enabled = cbIntervalUnit.Enabled = rbUpdateInterval.Checked;
            cbScheduleUnit.Enabled = mtbScheduleTime.Enabled = rbUpdateSchedule.Checked;
        }

        private void rbUpdateInterval_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged();
        }

        private void rbUpdateManually_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged();
        }
    }
}