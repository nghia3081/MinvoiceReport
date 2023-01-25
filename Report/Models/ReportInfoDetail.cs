using Newtonsoft.Json;
using System;

namespace MinvoiceReport.Models
{
    public class ReportInfoDetail
    {
        [JsonProperty("wb_infoparam_id")]
        public Guid InfoParamId { get; set; }
        [JsonProperty("wb_infowindow_id")]
        public Guid InfoWindowId { get; set; }
        [JsonProperty("stt")]
        public int OrderNumber { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("caption")]
        public string Caption { get; set; }
        [JsonProperty("type_editor")]
        public string DataType { get; set; }
        [JsonProperty("ref_id")]
        public Guid? ReferenceDataId { get; set; }


    }
}
