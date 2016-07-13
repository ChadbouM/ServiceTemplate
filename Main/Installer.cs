using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime;
using System.ServiceProcess;
using Main.Properties;


namespace ServiceTemplate
{
    [RunInstaller(true)]
    public class TemplateInstaller : Installer
    {
        /// <summary> Constructor: 
        /// Performs thye initial setup for the installer
        /// </summary>
        public TemplateInstaller()
        {
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller        serviceInstaller        = new ServiceInstaller();

            //Account Information (null unless: Account == ServiceAccount.User)
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            //Service Information
            serviceInstaller.StartType   = ServiceStartMode.Automatic;
            serviceInstaller.DisplayName = Settings.Default.DisplayName;
            serviceInstaller.ServiceName = Settings.Default.ServiceName;

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }
    }
}