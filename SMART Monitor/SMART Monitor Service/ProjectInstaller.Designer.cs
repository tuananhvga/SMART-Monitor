namespace SMART_Monitor_Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SMARTProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SMARTMonitorServ = new System.ServiceProcess.ServiceInstaller();
            // 
            // SMARTProcessInstaller
            // 
            this.SMARTProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.SMARTProcessInstaller.Password = null;
            this.SMARTProcessInstaller.Username = null;
            this.SMARTProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.SMARTProcessInstaller_AfterInstall);
            // 
            // SMARTMonitorServ
            // 
            this.SMARTMonitorServ.Description = "Monitoring HDDs.";
            this.SMARTMonitorServ.DisplayName = "SMARTMonitorServ";
            this.SMARTMonitorServ.ServiceName = "SMARTMonitorServ";
            this.SMARTMonitorServ.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SMARTProcessInstaller,
            this.SMARTMonitorServ});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SMARTProcessInstaller;
        private System.ServiceProcess.ServiceInstaller SMARTMonitorServ;
    }
}