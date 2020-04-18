using PCParentConsole.Classes;
using PCParentConsole.Interfaces;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PCParentConsoleTests")]
namespace PCParentConsole
{
    class Program
    {
        private static ILoggerClass logger;
        private static IMailClientNotify notify;
        private static IBrowserSniffer sniffer;

        static void Main(string[] args)
        {
            OnStart(args);
            GetBrowserWindows();
            OnStop();

        }

        static Program()
        {
            logger = new LoggerClass();
            notify = new MailClientNotify();
            sniffer = new BrowserSniffer();
        }

        private static void OnStart(string[] args)
        {
            try
            {
                //creates a new Event Viewer Log 
                logger.CreateNewEventViewerLog();

                //log the login to event viewer
                logger.WriteLoginToEventViewer();

                //send notification on start of service.
                notify.SendEmailNotification(1);

            }
            catch (System.Exception ex)
            {
                logger.WriteExceptionToEventViewer(ex.Message);
            }
        }

        private static void GetBrowserWindows()
        {
            var getSniffer = sniffer.PrintBrowserTabName();
            foreach (var browser in getSniffer)
            {
                logger.WriteTransactionToEventViewer(string.Format("Detected Browser Window(s): {0} at {1} for user {2}", browser, DateTime.Now.Date, Environment.UserName));
            }
        }

        private static void OnStop()
        {
            try
            {
                logger.WriteLogoffToEventViewer();
            }
            catch (System.Exception ex)
            {
                logger.WriteExceptionToEventViewer(ex.Message);
            }

        }
    }
}
