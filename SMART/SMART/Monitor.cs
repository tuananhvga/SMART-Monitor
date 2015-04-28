using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Management;
using System.Data;

namespace SMART
{
    public class Monitor
    {
        static Dictionary<int, HDD> dDrives = new Dictionary<int, HDD>();

        static string connectionstring = "Data Source=VGA-PC\\SQLEXPRESS;"
        + "Integrated Security=SSPI;Initial Catalog=SMARTMonitor";

        public void setConnectionString(string s)
        {
            using (SqlConnection conn = new SqlConnection(s))
            {
                try
                {
                    conn.Open();
                    connectionstring = s;
                    conn.Close();
                }
                catch
                {
                    return;
                }
            }
        }
        public static int getTemp()
        {
            if (dDrives.Count == 0) return 0;
            return dDrives[0].Attributes[0xE7].Data;
        }

        public static Dictionary<int, HDD> getDrives()
        {
            return dDrives;
        }
        public static HDD getHDD(int index)
        {
            if (index >= dDrives.Count) return null;
            return dDrives[index];
        }
        public static void GetInfo()
        {
            dDrives.Clear();
            var ddSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            int iDriveIndex = 0;
            foreach (var drive in ddSearcher.Get())
            {
                var hdd = new HDD();
                hdd.Model = drive["Model"].ToString().Trim();
                hdd.Type = drive["InterfaceType"].ToString().Trim();
                try
                {
                    dDrives.Add(iDriveIndex,hdd);
                }
                catch 
                {
                	
                }
                iDriveIndex++;
            }

            var pmSearcher = new ManagementObjectSearcher ("SELECT * FROM Win32_PhysicalMedia");

            iDriveIndex = 0;
            foreach (var drive in pmSearcher.Get())
            {
                if (iDriveIndex >= dDrives.Count)
                    break;
                dDrives[iDriveIndex].Serial = drive["SerialNumber"] == null ? "None" : drive["SerialNumber"].ToString().Trim();
                iDriveIndex++;
            }

            //wmi
            var searcher = new ManagementObjectSearcher();
            searcher.Scope = new ManagementScope(@"\root\wmi");

            //status of HDD
            searcher.Query = new ObjectQuery ("SELECT * FROM MSStorageDriver_FailurePredictStatus");
            iDriveIndex = 0;
            foreach (ManagementObject drive in searcher.Get())
            {
                dDrives[iDriveIndex].IsOK = (bool)drive.Properties["PredictFailure"].Value == false;
                iDriveIndex++;
            }

            //SMART data
            searcher.Query = new ObjectQuery("SELECT * FROM MSStorageDriver_FailurePredictData");
            iDriveIndex = 0;
            foreach (ManagementObject data in searcher.Get())
            {
                Byte[] bytes = (Byte[])data.Properties["VendorSpecific"].Value;
                for (int i = 0;i<42;i++)
                {
                    try
                    {
                        int id = bytes[i*12+2];
                        if (id == 0) continue;

                        //failure predict
                        int flags = bytes[i*12+4];
                        bool failurepredict = (flags % 0x1) == 0x1;

                        var attr = dDrives[iDriveIndex].Attributes[id];
                        attr.Current = bytes[i*12+5];
                        attr.Worst = bytes[i*12+6];
                        attr.ID = id;
                        attr.Data = BitConverter.ToInt32(bytes,i*12+7);
                        attr.IsOK = failurepredict == false;
                    }
                    catch 
                    {
                    	
                    }
                }
                iDriveIndex++;
            }

            //threshold value

            searcher.Query = new ObjectQuery ("SELECT * FROM MSStorageDriver_FailurePredictThresholds");
            iDriveIndex = 0;
            foreach (var data in searcher.Get())
            {
                Byte[] bytes = (Byte[])data.Properties["VendorSpecific"].Value;
                for (int i = 0;i<42;i++)
                {
                    try
                    {
                        int id = bytes[i*12+2];
                        if (id == 0) continue;
                        var attr = dDrives[iDriveIndex].Attributes[id];
                        attr.Threshold = bytes[i*12+3];
                    }
                    catch 
                    {
                    	
                    }
                }
            }
        }
        
        /// <summary>
        ///    Thuc hien truy van SQL de ghi thong tin (lay boi ham GetInfo()) 
        /// </summary>
        /// <remarks>Co tra ve exception</remarks>
        public static void ToSQL()
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    Monitor.GetInfo();
                    SqlCommand cmd = new SqlCommand("Insert into RecordInfo (Serial,Type,Model," +
                                    "DeviceOK,RecordedTime) values (@Serial,@Type,@Model," +
                                    "@DvOK,@RTime);" +
                                    "SELECT SCOPE_IDENTITY();");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    HDD temp = SMART.Monitor.getHDD(0);
                    cmd.Parameters.AddWithValue("@Serial", temp.Serial);
                    cmd.Parameters.AddWithValue("@Type", temp.Type);
                    cmd.Parameters.AddWithValue("@Model", temp.Model);
                    cmd.Parameters.AddWithValue("@DvOK", temp.IsOK);
                    cmd.Parameters.AddWithValue("@RTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    conn.Open();
                    var id = cmd.ExecuteScalar();
                    cmd.CommandText = "Insert into RecordData (ID,[Current],Worst,Threshold,Data,IsOK,RecordID)" +
                                      " values (@ID,@Current,@Worst,@Threshold,@Data,@IsOK,@RecordID);";
                    cmd.Parameters.AddWithValue("@ID", null);
                    cmd.Parameters.AddWithValue("@Current", null);
                    cmd.Parameters.AddWithValue("@Worst", null);
                    cmd.Parameters.AddWithValue("@Threshold", null);
                    cmd.Parameters.AddWithValue("@Data", null);
                    cmd.Parameters.AddWithValue("@IsOK", null);
                    cmd.Parameters.AddWithValue("@RecordID", null);
                    foreach (var attr in temp.Attributes)
                    {
                        if (!attr.Value.HasData) continue;
                        cmd.Parameters["@ID"].Value = attr.Value.ID;
                        cmd.Parameters["@Current"].Value = attr.Value.Current;
                        cmd.Parameters["@Worst"].Value = attr.Value.Worst;
                        cmd.Parameters["@Threshold"].Value = attr.Value.Threshold;
                        cmd.Parameters["@Data"].Value = attr.Value.Data;
                        cmd.Parameters["@IsOK"].Value = attr.Value.IsOK;
                        cmd.Parameters["@RecordID"].Value = id;
                        cmd.ExecuteNonQuery();
                    }
                    //Console.WriteLine("State: {0}", conn.State);
                    //Console.WriteLine("String {0}", connectionstring);
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        // take most recent data from sqlserver

        //return the time when we get last record.
        public static string FromSQL()
        {
            string retval = null;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                HDD temp = new HDD();
                
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select top 1 * from RecordInfo order by RecordedTime DESC");
                    int RecordID = 0;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    dDrives.Clear();
                    dDrives.Add(0, temp);// write to the first one
                	SqlDataReader myReader = null;
	                myReader = cmd.ExecuteReader();
	                while (myReader.Read())
	                {
	                    //extract recordid, if can't return null
                        int.TryParse(myReader["RecordID"].ToString(),out RecordID);
                        temp.Type = myReader["Type"].ToString();
                        temp.Serial = myReader["Serial"].ToString();
                        temp.Model = myReader["Model"].ToString();
                        temp.IsOK = myReader["DeviceOK"].ToString().Equals("True");
                        retval = myReader["RecordedTime"].ToString();
	                }
                    cmd.CommandText = "Select * from RecordData where RecordID = " + RecordID.ToString();
                    myReader.Close();
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = 0;
                        int itemp = 0;
                        int.TryParse(myReader["ID"].ToString(), out id);
                        temp.Attributes[id].ID = id;
                        int.TryParse(myReader[1].ToString(), out itemp);
                        temp.Attributes[id].Current = itemp;
                        int.TryParse(myReader["Worst"].ToString(), out itemp);
                        temp.Attributes[id].Worst = itemp;
                        int.TryParse(myReader["Threshold"].ToString(), out itemp);
                        temp.Attributes[id].Threshold = itemp;
                        int.TryParse(myReader["Data"].ToString(), out itemp);
                        temp.Attributes[id].Data = itemp;
                        temp.Attributes[id].IsOK = myReader["IsOK"].ToString().Equals("True");
                    }
                }
                catch (System.Exception ex)
                {
                    return ex.ToString();
                }
                conn.Close();
            }
            return retval;
        }
    }
}
