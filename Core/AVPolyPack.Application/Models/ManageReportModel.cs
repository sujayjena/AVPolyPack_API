using AVPolyPack.Domain.Entities;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    public class PrintingReport_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
        public int? ShiftType { get; set; }
        public int? PrintingMachineId { get; set; }
    }
    public class PrintingReport_Response : BaseEntity
    {
        public string? LoomNumber { get; set; }
        public string? RollCode { get; set; }
        public string? Size { get; set; }
        public decimal? TotalMeter { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? AvgDiff { get; set; }
        public int? ShiftType { get; set; }
        public string? PrintingMachineName { get; set; }
        public string? PrintingName { get; set; }
        public string? PrintingSize { get; set; }
        public string? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string? CreatorName { get; set; }
    }
}
