using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using SMART;

namespace SMARTService
{
    public partial class SMARTService : ServiceBase
    {
        System.Diagnostics.EventLog eventLog1;
        //static int count = 0;
        public SMARTService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string FileName = "smart.log";
            StreamWriter f = new StreamWriter(FileName, true);
            f.WriteLine("chay onstart day");
            f.Close();
            this.AutoLog = false;
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
            System.Timers.Timer GetInfoTimer = new System.Timers.Timer();
            GetInfoTimer.Interval = 6000; // 6 seconds
            GetInfoTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            GetInfoTimer.Start();
            SMART.Monitor.GetInfo();
            try
            {
                SMART.Monitor.ToSQL();
            }
            catch (Exception e)
            {
                eventLog1.WriteEntry("Hello: " + e.Message);
            }
        }

        protected override void OnStop()
        {
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            //EventLog.WriteEntry("OnTimer");
            //SMART.Monitor.GetInfo();
            //SMART.Monitor.ToSQL();
        }

    }
}
