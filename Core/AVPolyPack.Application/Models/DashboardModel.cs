using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    public class Dashboard_OutwardingStock_Search
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        [JsonIgnore]
        public int Total { get; set; }
    }

    public class Dashboard_OutwardingStock_Response
    {
        public int? TotalLabTestCount { get; set; }
        public int? TotalLaminationCount { get; set; }
        public int? TotalLaminationLabTestCount { get; set; }
        public int? TotalPrintingCount { get; set; }
        public int? TotalCuttingCount { get; set; }
        public int? TotalInventoryCount { get; set; }
        public int? TotalCount { get; set; }
    }
}
