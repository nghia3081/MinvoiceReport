using MinvoiceReport;
using System;
using System.Windows.Forms;
using Autofac;
using MinvoiceReport.Forms;
using MinvoiceReport.IServices;
using MinvoiceReport.Services;
using Report.Utils;
using System.Threading;

namespace Report
{
    internal static class Program
    {
        public static IContainer Container { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            var builder = new ContainerBuilder();
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<ReportService>().As<IReportService>().InstancePerLifetimeScope();
            builder.RegisterType<Login>();
            builder.RegisterType<ReportView>();
            builder.RegisterType<DataFilter>();
            Container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var loginForm = Container.Resolve<Login>();

            // Force all WinForms errors to go through handler
           
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadExceptionHandler);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler);
            Application.Run(loginForm);

        }
        static void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            LoadingUtils.HideProgress();
            Exception ex = (Exception)args.ExceptionObject;
            MessageBox.Show(ex.Message);
        }
        static void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs args)
        {
            LoadingUtils.HideProgress();
            Exception ex = args.Exception;
            MessageBox.Show(ex.Message);
        }

    }
}
