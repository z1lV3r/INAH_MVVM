using System;
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

        private static void HandleException(Exception exception, string source)
        {
            if (exception is BaseException e)
            {
                if (e.TargetSite.ReflectedType != null)
                    MessageBox.Show(Utils.GetWindowFromViewModelId(e.TargetSite.ReflectedType.GetField("viewId").), e.Message,
                        e.Tittle, MessageBoxButton.OK, getIcon(e.Severity));
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al tratar de realizar la operación.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private static MessageBoxImage getIcon(BaseException.SeverityType severity)
        {
            switch (severity)
            {
                case BaseException.SeverityType.Info:
                    return MessageBoxImage.Information;
                case BaseException.SeverityType.Warning:
                    return MessageBoxImage.Warning;
                default:
                    return MessageBoxImage.Error;
            }
        }
    }
}
