using Autofac;
using MinvoiceReport.Forms;
using MinvoiceReport.IServices;
using MinvoiceReport.Utils;
using System.Windows.Forms;
using System;
using System.Linq;
using Report;
using Report.Utils;

namespace MinvoiceReport
{
    public partial class Login : Form
    {
        private readonly IAccountService _accountService;
        private readonly IReportService _reportService;
        public Login(IAccountService accountService, IReportService reportService)
        {
            InitializeComponent();
            _accountService = accountService;
            _reportService = reportService;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.Enabled= true;
            LoadingUtils.ShowProgress();
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;
            string taxCode = taxCodeTxt.Text;
            if (StringUtils.IsAnyNullOrEmpty(username, password, taxCode)) throw new Exception("Giá trị không được để trống");
            Constant.InitBaseUrl(taxCode);
            ApiClient client = new ApiClient(Constant.InitBaseUrl(taxCode));
            Constant.TOKEN = _accountService.Login(client, taxCode, username, password);
            client.DefaultRequestHeaders.Add("Authorization", $"Bear {Constant.TOKEN};VP;vi");
            Constant.ChangeClient(client);
            Constant.TAXCODE = taxCode;
            Constant.REPORT_INFO = _reportService.GetReportInfos();
            _reportService.SaveAllReports(Constant.REPORT_INFO.Select(wd => wd.WindowId).ToList());
            var reportView = Program.Container.Resolve<ReportView>();
            LoadingUtils.HideProgress();
            reportView.Show();
            this.Hide();

        }
        private void onClose(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        private void logoPanel_Click(object sender, EventArgs e)
        {

        }
    }
}