using MinvoiceReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using MinvoiceReport.Forms;
using MinvoiceReport.IServices;
using MinvoiceReport.Services;

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
            Application.Run(loginForm);
        }
    }
}
