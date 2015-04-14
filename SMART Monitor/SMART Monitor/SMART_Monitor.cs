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
using SMART;
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

        
        private void ShowInfo()
        {
            HDD drive = null;
            //add to combobox

            int iDriveIndex = 0;
            
            
            //clear all
            dgvSmart.Rows.Clear();
            try
            {
                iDriveIndex = cbDrives.SelectedIndex;
                drive = SMART.Monitor.getHDD(iDriveIndex);
            }
            catch 
            {
                return;
            }


            //extract basic info
            lInfo.Text = "Serial : " + drive.Serial +
                "\nType : " + drive.Type +
                "\nModel : " + drive.Model +
                "\nStatus : " + (drive.IsOK ? "OK" : "Not OK") ;

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
        
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            SMART.Monitor.GetInfo();
            try
            {
                cbDrives.Items.Clear();
                var dDrives = SMART.Monitor.getDrives();
                foreach (var d in dDrives)
                {
                    if (d.Value.Serial.Length < 2) continue;
                    cbDrives.Items.Add(d.Value.Serial);
                    cbDrives.SelectedIndex = 0;
                }
            }
            catch
            {

            }
            ShowInfo();
            SMART.Monitor.ToSQL();
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
        /* private void SaveData()
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
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
            
        } */
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadData()
        {
            string recordedtime = SMART.Monitor.FromSQL();
            var HDDtemp = SMART.Monitor.getHDD(0);
            lSmartView.Text = "Serial : ";
            lSmartView.Text += HDDtemp.Serial.ToString();
            lSmartView.Text += "\r\nTime get : ";
            lSmartView.Text += recordedtime;

            //to DGV
            try
            {
                dgvSmartView.Rows.Clear();
                foreach (var attr in HDDtemp.Attributes)
                {
                    if (attr.Value.HasData == false) continue;
                    dgvSmartView.Rows.Add(attr.Value.ID,
                       attr.Value.Attribute,
                       attr.Value.Current,
                       attr.Value.Worst,
                       attr.Value.Threshold,
                       attr.Value.Data,
                       attr.Value.IsOK);
                }
            }
            catch { }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}