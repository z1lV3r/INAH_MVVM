using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace INAH.Exceptions
{
    public class ExceptionHandler
    {
        public void StartListeners()
        {
            //From all threads in the AppDomain.
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                HandleException((Exception)e.ExceptionObject, e);

            //From the main UI dispatcher thread in your WPF application.
            Application.Current.DispatcherUnhandledException += (s, e) =>
                HandleException(e.Exception, e);

            //from within each AppDomain that uses a task scheduler for asynchronous operations.
            TaskScheduler.UnobservedTaskException += (s, e) =>
                HandleException(e.Exception, e);
        }

        private static void HandleException(Exception exception, EventArgs args)
        {
            if (exception is BaseException e)
            {
                if (e.TargetSite.ReflectedType != null)
                {
                    var field = e.TargetSite.ReflectedType.GetField("viewId",
                        System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                    if (field != null)
                    {
                        MessageBox.Show(Utils.GetWindowFromViewModelId((Guid)field.GetValue(null)), e.Description,e.Tittle, MessageBoxButton.OK, getIcon(e.Severity));
                    }
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al tratar de realizar la operación.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

            if (args is DispatcherUnhandledExceptionEventArgs a)
            {
                a.Handled = true;
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
