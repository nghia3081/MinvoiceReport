using MinvoiceReport.IServices;
using MinvoiceReport.Utils;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System;

namespace MinvoiceReport.Services
{
    public class AccountService : IAccountService
    {
        public AccountService() { }
        public string GetMaDvcs(ApiClient client, string taxCode)
        {
            JArray getDvcsResponse = client.Get<JArray>(Constant.GET_DVCS_URI);
            JObject dvcs = JObject.FromObject(getDvcsResponse[0]);
            string MaDvcs = dvcs["ma_dvcs"].ToString();
            return MaDvcs;
        }
        public string Login(ApiClient client, string taxCode, string username, string password)
        {
            string maDvcs = GetMaDvcs(client, taxCode);
            JObject accountInfo = new JObject()
            {
                { "ma_dvcs" ,maDvcs },
                { "username", username},
                { "password", password}
            };
            JObject loginResponse = client.Post<JObject, JObject>(Constant.LOGIN_URI, accountInfo);
            if (loginResponse["token"] == null) throw new Exception("Thông tin đăng nhập không chính xác");
            MessageBox.Show("Đăng nhập thành công", "Đăng nhập");
            return loginResponse["token"].ToString();
        }
    }
}
