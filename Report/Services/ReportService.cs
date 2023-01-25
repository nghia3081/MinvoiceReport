using MinvoiceReport.Extensions;
using MinvoiceReport.IServices;
using MinvoiceReport.Models;
using MinvoiceReport.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using DevExpress.Pdf;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System;
using System.IO;

namespace MinvoiceReport.Services
{
    public class ReportService : IReportService
    {
        private readonly ApiClient _apiClient = Constant.clientConnected;
        public List<ReportInfo> GetReportInfos()
        {
            var urlGet = Constant.SYSTEM_GETDATA;
            var postData = Constant.GET_REPORT_INFO_PARAM;
            var result = Constant.clientConnected.Post<JObject, List<ReportInfo>>(urlGet, postData);
            return result;
        }
        public bool GetReportFile(Guid windowId)
        {
            var urlGet = string.Format(Constant.GET_REPORT_FILE_URI, windowId);
            try
            {
                var result = Constant.clientConnected.GetFile(urlGet);
                string fileSavePath = string.Format(Constant.REPORT_TEMPLATE_PATH, Constant.TAXCODE)+ $"\\{windowId}.repx";
                new FileInfo(fileSavePath).Directory.Create();
                File.WriteAllBytes(fileSavePath, result);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool GetReportInfoDetail(Guid windowId)
        {
            string Url = Constant.SYSTEM_GETDATA;
            JObject dataPost = new JObject()
             {
            { "command", "CM00013" },
            { "parameter", new JObject(){ { "wb_infowindow_id", windowId } } }
              };
            int index = Constant.REPORT_INFO.FindIndex(rp => rp.WindowId.Equals(windowId));
            Constant.REPORT_INFO[index].ReportInfoDetail = Constant.clientConnected.Post<JObject, List<ReportInfoDetail>>(Url, dataPost);
            return true;
        }
        public bool SaveAllReports(List<Guid> windowIds)
        {
            foreach (Guid id in windowIds)
            {
                GetReportFile(id);
                GetReportInfoDetail(id);
            }
            //new FileInfo(Constant.RESOURE_FOLDER_PATH + "\\data.json").Directory.Create();
            //File.WriteAllText(Constant.RESOURE_FOLDER_PATH + "\\data.json", JsonConvert.SerializeObject(Constant.REPORT_INFO));
            return true;
        }
        public List<ReferencesDataModel> GetReferencesData(Guid referencesId)
        {
            string url = string.Format(Constant.GET_DATA_REFERENCES_URI, referencesId);
            try
            {
                return Constant.clientConnected.Get<List<ReferencesDataModel>>(url);
            }
            catch (Exception)
            {
                List<ReferencesDataModel> lst = new List<ReferencesDataModel>();
                var data = Constant.clientConnected.Get<JArray>(url);
                foreach (var dt in data)
                {
                    lst.Add(new ReferencesDataModel() { id = dt.ToString(), value = dt.ToString() });
                }
                return lst;
            }

        }
        public DataSet GetReportData(Guid windowId, JObject parameter)
        {
            string url = string.Format(Constant.GET_REPORT_DATA, windowId, parameter.ToString());
            var dataResponse = Constant.clientConnected.Get<JObject>(url);
            if (dataResponse == null || !(dataResponse?["message"]?.ToString() ?? "").IsNullOrEmpty()) return null;
            string reportDataJArray = dataResponse?["data"]?.ToString() ?? "[]";
            DataTable reportDt = JsonConvert.DeserializeObject<DataTable>(reportDataJArray);
            DataSet ds = new DataSet();
            ds.Tables.Add(reportDt);
            return ds;
        }
        public byte[] PrintReport(Guid windowId, DataSet reportData, int type)
        {
            string filePath = string.Format(Constant.REPORT_TEMPLATE_PATH, Constant.TAXCODE) + "\\" + windowId.ToString() + ".repx";
            XtraReport report = XtraReport.FromFile(filePath, true);
            report.DataSource = reportData;
            report.DataMember = reportData.Tables[0].TableName;
            report.CreateDocument();
            using (MemoryStream ms = new MemoryStream())
            {
                switch (type)
                {
                    case 1: report.ExportToHtml(ms); break;
                    case 2: report.ExportToXlsx(ms); break;
                    case 3: report.ExportToPdf(ms); break;
                    case 4: report.ExportToText(ms); break;
                }
                return ms.ToArray();
            }

        }
    }

}
