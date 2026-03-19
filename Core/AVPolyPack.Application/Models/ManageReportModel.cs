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
        public string? OperatorName { get; set; }
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
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string? CreatorName { get; set; }
    }

    public class LaminationReport_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
    public class LaminationReport_Response : BaseEntity
    {
        public string? RollCode { get; set; }
        public string? Size { get; set; }
        public string? Meter { get; set; }
        public string? GrossWeight { get; set; }
        public string? CurrentWeight { get; set; }
        public string? NetWeight { get; set; }
        public string? Average { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string? CreatorName { get; set; }
    }
    public class StrengthReport_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
    public class StrengthReport_Response : BaseEntity
    {
        public string? SpecificationName { get; set; }
        public string? LoomNumber { get; set; }
        public string? RollCode { get; set; }
        public string? RequiredSize { get; set; }
        public string? ActualSize { get; set; }
        public string? RequiredAvg { get; set; }
        public string? ActualAvg { get; set; }
        public string? RequiredMesh { get; set; }
        public string? ActualMesh { get; set; }
        public string? WARP { get; set; }
        public string? WARP_ELO { get; set; }
        public string? WEFT { get; set; }
        public string? WEFT_ELO { get; set; }
        public string? STime { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string? CreatorName { get; set; }
    }

    public class EmployeeAttendanceReport_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int? ShiftType { get; set; }
        public int? DepartmentId { get; set; }
    }
    public class EmployeeAttendanceReport_Response : BaseEntity
    {
        public string? UserCode { get; set; }
        public string? EmployeeName { get; set; }
        public string? DepartmentName { get; set; }
        public int? ShiftType { get; set; }
        public DateTime? CheckedInDate { get; set; }
        public DateTime? CheckedOutDate { get; set; }
        public string? TotalHours { get; set; }
        public string? TotalDays { get; set; }
        public string? EffortName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string? CreatorName { get; set; }
    }
    public class LoomReport_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int? ShiftType { get; set; }
    }
    public class LoomReport_Response : BaseEntity
    {
        public string? LoomNumber { get; set; }
        public string? OperatorName { get; set; }
        public string? OpeningReading { get; set; }
        public string? Reading_8_10 { get; set; }
        public string? Production_8_10 { get; set; }
        public string? Reading_10_12 { get; set; }
        public string? Production_10_12 { get; set; }
        public string? Reading_12_02 { get; set; }
        public string? Production_12_02 { get; set; }
        public string? Reading_02_04 { get; set; }
        public string? Production_02_04 { get; set; }
        public string? Reading_04_06 { get; set; }
        public string? Production_04_06 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatorName { get; set; }
    }
}
