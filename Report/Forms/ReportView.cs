using Autofac;
using MinvoiceReport.IServices;
using MinvoiceReport.Models;
using MinvoiceReport.Utils;
using Newtonsoft.Json;
using System.Data;
using System;
using System.Windows.Forms;
using Report;
using System.IO;
using System.Diagnostics;
using MinvoiceReport.Extensions;
using Report.Utils;

namespace MinvoiceReport.Forms
{
    public partial class ReportView : Form
    {
        private readonly IReportService _reportService;
        public ReportView(IReportService reportService)
        {
            InitializeComponent();
            _reportService = reportService;
            this.reportTypeCombo.ComboBox.ValueMember = "id";
            this.reportTypeCombo.ComboBox.DisplayMember = "name";
            this.reportTypeCombo.ComboBox.DataSource = Constant.REPORT_INFO;
        }
        private void RefreshOnClick(object sender, EventArgs e)
        {
            Constant.SelectedReport = (ReportInfo)this.reportTypeCombo.ComboBox.SelectedItem;
            DataFilter dtFil = Program.Container.Resolve<DataFilter>();
            dtFil.Show();
            this.Enabled = false;
            dtFil.FormClosed += LoadGridView;
        }
        private void OnClose(object sender, EventArgs e)
        {

            Constant.LogOut();
            var LoginForm = Program.Container.Resolve<Login>();
            LoginForm.Show();

        }
        private void LoadGridView(object sender, EventArgs e)
        {
            LoadingUtils.HideProgress();
            this.Enabled = true;
            this.reportDataGrid.DataSource = Constant.REPORT_DATA?.Tables?[0] ?? null;
        }
        private void ViewPdfOnclick(object sender, EventArgs e)
        {
            LoadingUtils.ShowProgress();
            if (Constant.REPORT_DATA.IsNull()) return;
            byte[] reportByte = _reportService.PrintReport(Constant.SelectedReport.WindowId, Constant.REPORT_DATA, 3);
            string filePath = string.Format(Constant.EXPORTED_FILE_PATH, Constant.TAXCODE);
            new FileInfo(filePath + "\\file.pdf").Directory.Create();
            File.WriteAllBytes(filePath + $"\\{Constant.SelectedReport.Name}_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.pdf", reportByte);
            Process.Start(filePath + $"\\{Constant.SelectedReport.Name}_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.pdf");
            LoadingUtils.HideProgress();
            Process.Start(filePath);

        }
        private void DownloadFileOnclick(object sender, EventArgs e)
        {
            LoadingUtils.ShowProgress();
            if (Constant.REPORT_DATA.IsNull()) return;
            byte[] reportByte = _reportService.PrintReport(Constant.SelectedReport.WindowId, Constant.REPORT_DATA, 2);
            string filePath = string.Format(Constant.EXPORTED_FILE_PATH, Constant.TAXCODE);
            new FileInfo(filePath + "\\file.xlsx").Directory.Create();
            File.WriteAllBytes(filePath + $"\\{Constant.SelectedReport.Name}_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.xlsx", reportByte);
            Process.Start(filePath + $"\\{Constant.SelectedReport.Name}_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.xlsx");
            LoadingUtils.HideProgress();
            Process.Start(filePath);
        }
    }
}
