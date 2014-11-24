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
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace SMART_Monitor
{
    public partial class SMART_Monitor : Form
    {
        public SMART_Monitor()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void SMART_Monitor_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
	            var connectionString = "mongodb://localhost";
	            var client = new MongoClient (connectionString);
	            var server = client.GetServer();
	            var database = server.GetDatabase("test");
	            if (database.CollectionExists("SMART") == false)
	            {
	                database.CreateCollection("SMART");
	            }
	            var collection = database.GetCollection("SMART");
                foreach (var drive in dDrives)
                {
                    if (drive.Value.Serial.Length < 2) continue;
                    BsonDocument bsonHDD = new BsonDocument();
                    BsonArray SmartData = new BsonArray();
                    foreach (var attr in drive.Value.Attributes)
                    {
                        if (attr.Value.HasData == false) continue;
                        BsonDocument bsonSmart = new BsonDocument();
                        bsonSmart.Add("ID", attr.Value.ID);
                        bsonSmart.Add("Attribute", attr.Value.Attribute);
                        bsonSmart.Add("Current", attr.Value.Current);
                        bsonSmart.Add("Worst", attr.Value.Worst);
                        bsonSmart.Add("Threshold", attr.Value.Threshold);
                        bsonSmart.Add("Data", attr.Value.Data);
                        bsonSmart.Add("IsOK", attr.Value.IsOK);
                        SmartData.Add(bsonSmart);
                    }
                    bsonHDD.Add("Serial", drive.Value.Serial);
                    bsonHDD.Add("TimeGet", new BsonDateTime(DateTime.Now));
                    bsonHDD.Add("SmartData", SmartData);
                    collection.Insert(bsonHDD);
                }
                MessageBox.Show("Done");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var server = client.GetServer();
                var database = server.GetDatabase("test");
                if (database.CollectionExists("SMART") == false)
                {
                    GetBtn.Text = "0";
                    return;
                }
                var collection = database.GetCollection("SMART");
                GetBtn.Text = collection.Count().ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var server = client.GetServer();
                var database = server.GetDatabase("test");
                if (database.CollectionExists("SMART") == false)
                {
                    return;
                }
                if (GetBtn.Text == "Get")
                {
                    MessageBox.Show("Press Get button first!!!");
                    return;
                }
                if (GetBtn.Text == "0")
                {
                    MessageBox.Show("No record to view");
                    return;
                }

                int iRecordNo;
                int iIndex;
                try
                {
                    iRecordNo = Int32.Parse(GetBtn.Text);
                    iIndex = Int32.Parse(tbRecordNumber.Text);
                    if (iIndex >= iRecordNo)
                    {
                        MessageBox.Show("Index out of bound");
                        return;
                    }
                }
                catch
                {
                    return;
                }
                var collection = database.GetCollection("SMART");
                var cursor = collection.FindAll();
                var bsondoc = cursor.ElementAt(iIndex);
                lSmartView.Text = "Serial : ";
                lSmartView.Text += bsondoc["Serial"].AsString;
                lSmartView.Text += "\r\nTime get : ";
                lSmartView.Text += bsondoc["TimeGet"].ToUniversalTime().ToString("yyyy/MM/dd hh:mm:ss");

                dgvSmartView.Rows.Clear();
                foreach (var bsonsmart in bsondoc["SmartData"].AsBsonArray)
                {
                    dgvSmartView.Rows.Add(bsonsmart["ID"].AsInt32.ToString(),
                        bsonsmart["Attribute"].AsString,
                        bsonsmart["Current"].AsInt32.ToString(),
                        bsonsmart["Worst"].AsInt32.ToString(),
                        bsonsmart["Threshold"].AsInt32.ToString(),
                        bsonsmart["Data"].AsInt32.ToString(),
                        bsonsmart["IsOK"].AsBoolean ? "OK" : "Not OK");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}