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
    #region Lamination
    public class Lamination_Search : BaseSearchEntity
    {
        public int? RollId { get; set; }
    }
    public class Lamination_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public string? Size { get; set; }
        public string? Meter { get; set; }
        public string? GrossWeight { get; set; }
        public string? CurrentWeight { get; set; }
        public string? NetWeight { get; set; }
        public string? Average { get; set; }

        [DefaultValue(false)]
        public bool? IsCompleted { get; set; }
    }

    public class Lamination_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public string? Size { get; set; }
        public string? Meter { get; set; }
        public string? GrossWeight { get; set; }
        public string? CurrentWeight { get; set; }
        public string? NetWeight { get; set; }
        public string? Average { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletedDateTime { get; set; }
    }
    #endregion

    #region Consumption
    public class Consumption_Lamination_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
        public int ShiftType { get; set; }
    }

    public class Consumption_Lamination_Request : BaseEntity
    {
        public int? ShiftType { get; set; }
        public DateTime? ConsumptionDate { get; set; }
        public int? MaterialId { get; set; }
        public decimal? ConsumptionQty { get; set; }
        public decimal? TotalWeight { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Consumption_Lamination_Response : BaseResponseEntity
    {
        public int? ShiftType { get; set; }
        public DateTime? ConsumptionDate { get; set; }
        public int? MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public decimal? ConsumptionQty { get; set; }
        public decimal? TotalWeight { get; set; }
        public bool? IsActive { get; set; }
    }
    #endregion

    #region Waste Material
    public class WasteMaterial_Lamination_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int ShiftType { get; set; }
    }

    public class WasteMaterial_Lamination_Request : BaseEntity
    {
        public int? ShiftType { get; set; }
        public DateTime? WasteMaterialDate { get; set; }
        public int? MaterialId { get; set; }
        public decimal? WasteWeight { get; set; }
        public bool? IsActive { get; set; }
    }

    public class WasteMaterial_Lamination_Response : BaseResponseEntity
    {
        public int? ShiftType { get; set; }
        public DateTime? WasteMaterialDate { get; set; }
        public int? MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public decimal? WasteWeight { get; set; }
        public bool? IsActive { get; set; }
    }
    #endregion

    #region AvgGSM Entry
    public class AvgGSMEntry_Lamination_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int? RollId { get; set; }
    }
    public class AvgGSMEntry_Lamination_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public string? RequiredAvg { get; set; }
        public string? RequiredGSM { get; set; }
        public string? ActualAvg { get; set; }
        public string? ActualGSM { get; set; }
    }

    public class AvgGSMEntry_Lamination_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public string? RequiredAvg { get; set; }
        public string? RequiredGSM { get; set; }
        public string? ActualAvg { get; set; }
        public string? ActualGSM { get; set; }
    }
    #endregion

    #region Strength Entry
    public class StrengthEntry_Lamination_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int? RollId { get; set; }
    }
    public class StrengthEntry_Lamination_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public string? RequiredStrength { get; set; }
        public string? WARP { get; set; }
        public string? WARP_ELO { get; set; }
        public string? WEFT { get; set; }
        public string? WEFT_ELO { get; set; }
    }

    public class StrengthEntry_Lamination_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public string? RequiredStrength { get; set; }
        public string? WARP { get; set; }
        public string? WARP_ELO { get; set; }
        public string? WEFT { get; set; }
        public string? WEFT_ELO { get; set; }
    }
    #endregion
}
