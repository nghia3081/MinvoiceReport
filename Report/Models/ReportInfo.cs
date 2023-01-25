using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MinvoiceReport.Models
{
    public class ReportInfo
    {
        [JsonProperty("wb_infowindow_id")]
        public Guid WindowId { get; set; }  
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "report_name")]
        public string Name { get; set; }
        [JsonProperty("report_code")]
        public string SprocGetData { get; set; }
        public virtual ICollection<ReportInfoDetail> ReportInfoDetail { get; set; }
    }
    //public class ReportInfoGetModel
    //{
    //    [JsonProperty("data")]
    //    public List<ReportInfo> ReportInfos { get; set; }
    //    [JsonProperty("pos")]
    //    public int? pos { get; set; }
    //    [JsonProperty("total_count")]
    //    public int? total { get; set; }
    //}
}
