using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using SMART;

namespace SMART_Monitor_Service
{
    public partial class SMARTMonitorServ : ServiceBase
    {
        System.Diagnostics.EventLog eventLog1;
        public SMARTMonitorServ()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("SMARTServSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "SMARTServSource", "SMARTServLog");
            }
            eventLog1.Source = "SMARTServSource";
            eventLog1.Log = "SMARTServLog";
            System.Timers.Timer GetInfoTimer = new System.Timers.Timer();
            GetInfoTimer.Interval = 300000; // 5 mins by default
            bool bManually = false;
            try
            {
                var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SMARTMonitor");
                GetInfoTimer.Interval = double.Parse(key.GetValue("Interval").ToString());
                bManually = (int.Parse(key.GetValue("Manually").ToString()) == 1);
            }
            catch
            {
                //use default value if can't get the interval
            }
            GetInfoTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            if (!bManually)
            {
                GetInfoTimer.Start();
            }
        }

        protected override void OnStop()
        {
        }


        /// <summary>
        /// OnTimer method, Get SMART info and write to database by interval.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            try
            {
                SMART.Monitor.GetInfo();
                SMART.Monitor.ToSQL();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("Exception : " + ex.Message);
            }
        }
    }
}
