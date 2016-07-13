using System;
using System.Diagnostics;
using System.ServiceProcess;
using Main.Properties;

namespace ServiceTemplate
{
    class TemplateService : ServiceBase
    {
        /// <summary> Constructor:
        /// Performs the initial setup for the service
        /// </summary>
        public TemplateService()
        {
            this.ServiceName  = Settings.Default.ServiceName;
            this.EventLog.Log = Settings.Default.LogLevel;

            // Event Flags:
            this.CanHandlePowerEvent         = false;
            this.CanHandleSessionChangeEvent = false;
            this.CanPauseAndContinue         = false;
            this.CanShutdown                 = false;
            this.CanStop                     = false;
        }

        /// <summary> Main: 
        /// The start-point for the service
        /// </summary>
        static void Main()
        {
            ServiceBase.Run(new TemplateService());
        }

        /// <summary> Dispose: 
        /// Performs object disposal where neccessary
        /// </summary>
        /// <param name="disposing">True iff disposing</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        /// <summary> OnStart: 
        /// Performs startup activities
        /// </summary>
        /// <param name="args">Command line arguments</param>
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }

        /// <summary> OnStop: 
        /// Performs cleanup activities
        /// </summary>
        protected override void OnStop()
        {
            base.OnStop();
        }

        /// <summary> OnPause:
        /// Performs cleanup needed for pause
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
        }

        /// <summary> OnContinue: 
        /// Performs cleanup for unpausing
        /// </summary>
        protected override void OnContinue()
        {
            base.OnContinue();
        }

        /// <summary> OnShutdown: 
        /// Performs cleanup neccessary for a system-shutdown
        /// </summary>
        protected override void OnShutdown()
        {
            base.OnShutdown();
        }

        /// <summary> OnCustomCommand: 
        /// Command Pattern implementation
        /// </summary>
        /// <param name="command"></param>
        protected override void OnCustomCommand(int command)
        {
            // implementation should be limited to the 'command calue range of
            // [128 - 256]
            // USAGE:
            //#  ServiceController sc = new ServiceController(<string ServiceName>);
            //#  sc.ExecuteCommand(command);

            base.OnCustomCommand(command);
        }

        /// <summary> OnPowerEvent: 
        /// Performs activity surrounding going into system-suspend or
        /// system-low-battery
        /// </summary>
        /// <param name="powerStatus">Type of power event</param>
        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            return base.OnPowerEvent(powerStatus);
        }

        /// <summary> OnSessionChange: 
        /// Performs activity surrounding session events
        /// </summary>
        /// <param name="changeDescription">Type of session event</param>
        protected override void OnSessionChange( SessionChangeDescription changeDescription)
        {
            base.OnSessionChange(changeDescription);
        }
    }
}