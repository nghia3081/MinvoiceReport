using MinvoiceReport.Extensions;
using MinvoiceReport.Models;
using Newtonsoft.Json.Linq;
using System.Data;
using System;
using System.Collections.Generic;

namespace MinvoiceReport.Utils
{
    public static class Constant
    {
        public static string TAXCODE { get; set; }
        public static string TOKEN { get; set; } = string.Empty;
        public static string BASE_URL = "https://{0}.minvoice.com.vn/api/";
        public static string BASE_URL_TEST = "http://localhost:18374/";
        public readonly static string LOGIN_URI = "Account/Login";
        public readonly static string GET_DVCS_URI = "System/GetAllDmDvcs";
        public readonly static string GET_REPORT_INFO_URI = "System/GetDataByWindowNo1";
        public readonly static string SYSTEM_GETDATA = "System/ExecuteCommand";
        public static string GET_REPORT_FILE_URI = "System/GetReport/{0}";
        public static string GET_DATA_REFERENCES_URI = "System/GetDataByReferencesId?id={0}";
        public static string GET_REPORT_DATA = "System/GetReportData/{0}?parameter={1}";
        public readonly static string APP_RESOURCE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MinvoiceReport";
        public static string RESOURE_FOLDER_PATH = APP_RESOURCE_PATH + "\\{0}";
        public readonly static string REPORT_TEMPLATE_PATH = RESOURE_FOLDER_PATH + "\\Template";
        public readonly static string EXPORTED_FILE_PATH = RESOURE_FOLDER_PATH + "\\Exported";

        public static DataSet REPORT_DATA { get; set; }
        public static ReportInfo SelectedReport { get; set; }
        public static List<ReportInfo> REPORT_INFO { get; set; }
        public readonly static JObject GET_REPORT_INFO_PARAM = new JObject()
       {
            { "command", "CM00016" },
            { "parameter",new JObject(){
                {"window_id", "WIN00022"},
                { "username", "ADMINISTRATOR" }  }
            }
        };

        public static ApiClient clientConnected { get; set; }
        public static string InitBaseUrl(string taxCode)
        {
            if (taxCode.IsNullOrEmpty()) throw new ArgumentNullException(nameof(taxCode));
            BASE_URL = string.Format(BASE_URL, taxCode);
            return BASE_URL;
        }
        public static ApiClient ChangeClient(ApiClient client)
        {
            clientConnected = client ?? throw new ArgumentNullException(nameof(client));
            return clientConnected;
        }
        public static void LogOut()
        {
            TAXCODE = string.Empty;
            TOKEN = string.Empty;
            clientConnected = null;
            BASE_URL = "https://{0}.minvoice.com.vn/api/";
            GET_REPORT_FILE_URI = "System/GetReport/{0}";
            GET_DATA_REFERENCES_URI = "System/GetDataByReferencesId?id={0}";
            GET_REPORT_DATA = "System/GetReportData/{0}?parameter={1}";
            RESOURE_FOLDER_PATH = APP_RESOURCE_PATH + "\\{0}";
        }
    }
}
