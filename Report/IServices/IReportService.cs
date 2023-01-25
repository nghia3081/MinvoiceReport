using MinvoiceReport.Models;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Collections.Generic;
using System;

namespace MinvoiceReport.IServices
{
    public interface IReportService
    {
        List<ReportInfo> GetReportInfos();
        bool GetReportFile(Guid windowId);
        bool SaveAllReports(List<Guid> windowIds);
        List<ReferencesDataModel> GetReferencesData(Guid referencesId);
        DataSet GetReportData(Guid windowId, JObject parameter);
        byte[] PrintReport(Guid windowId, DataSet reportData, int type);
    }
}
