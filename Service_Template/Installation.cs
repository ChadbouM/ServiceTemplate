using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Configuration.Install;
using System.Runtime;
using System.ServiceProcess;
using Service_Template.Properties;

namespace Service_Template
{
    [DesignerCategory("")]
    [RunInstaller(true)]
    public class Installation : Installer
    {
        string InstallUtilAddress = @"%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\InstallUtil ";
        string ProductAddress     = @" ..\" + AppDomain.CurrentDomain.FriendlyName;

        public Installation()
        {
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller        serviceInstaller        = new ServiceInstaller();

            //Account Information (null unless: Account == ServiceAccount.User)
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            //Service Information
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.DisplayName = Settings.Default.DisplayName;
            serviceInstaller.ServiceName = Settings.Default.ServiceName;

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            InstallAction("/i");
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            InstallAction("/u");
        }

        protected void InstallAction(string mode)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName               = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput  = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError  = true;
            cmd.StartInfo.CreateNoWindow         = true;
            cmd.StartInfo.UseShellExecute        = false;
            cmd.Start();

            // The Command to be run: [Installs/Uninstalls this service]
            cmd.StandardInput.WriteLine(InstallUtilAddress + mode + ProductAddress);
            cmd.StandardInput.Flush();

            cmd.StandardInput.Close();
            cmd.WaitForExit();

            System.IO.File.WriteAllText(@".\installLog.txt", cmd.StandardOutput.ReadToEnd() +
                                                             cmd.StandardError.ReadToEnd());
        }
    }
}
