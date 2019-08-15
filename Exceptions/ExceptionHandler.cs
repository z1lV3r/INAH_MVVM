using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace INAH.Exceptions
{
    public class ExceptionHandler
    {
        public void StartListeners()
        {
            //From all threads in the AppDomain.
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                HandleException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            //From the main UI dispatcher thread in your WPF application.
            Application.Current.DispatcherUnhandledException += (s, e) =>
                HandleException(e.Exception, "Application.Current.DispatcherUnhandledException");

            //from within each AppDomain that uses a task scheduler for asynchronous operations.
            TaskScheduler.UnobservedTaskException += (s, e) =>
                HandleException(e.Exception, "TaskScheduler.UnobservedTaskException");
        }

        private void HandleException(Exception exception, string source)
        {

        }
    }
}
