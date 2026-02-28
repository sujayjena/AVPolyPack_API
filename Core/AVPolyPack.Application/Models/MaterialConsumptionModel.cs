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
    #region Consumption
    public class Consumption_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int TapeMachineId { get; set; }
        public int ShiftType { get; set; }
    }

    public class Consumption_Request : BaseEntity
    {
        public int? TapeMachineId { get; set; }
        public int? ShiftType { get; set; }
        public DateTime? ConsumptionDate { get; set; }
        public int? MaterialId { get; set; }
        public decimal? ConsumptionQty { get; set; }
        public decimal? TotalWeight { get; set; }
        public bool? IsActive { get; set; }
    }
    public class ConsumptionHeader_Response : BaseEntity
    {
        public int? TapeMachineId { get; set; }
        public string? TapeMachineName { get; set; }
        public int? ShiftType { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    public class Consumption_Response : BaseResponseEntity
    {
        public int? TapeMachineId { get; set; }
        public string? TapeMachineName { get; set; }
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
    public class WasteMaterial_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int TapeMachineId { get; set; }
        public int ShiftType { get; set; }
    }

    public class WasteMaterial_Request : BaseEntity
    {
        public int? TapeMachineId { get; set; }
        public int? ShiftType { get; set; }
        public DateTime? WasteMaterialDate { get; set; }
        public int? MaterialId { get; set; }
        public decimal? WasteWeight { get; set; }
        public bool? IsActive { get; set; }
    }
    public class WasteMaterialHeader_Response : BaseEntity
    {
        public int? TapeMachineId { get; set; }
        public string? TapeMachineName { get; set; }
        public int? ShiftType { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    public class WasteMaterial_Response : BaseResponseEntity
    {
        public int? TapeMachineId { get; set; }
        public string? TapeMachineName { get; set; }
        public int? ShiftType { get; set; }
        public DateTime? WasteMaterialDate { get; set; }
        public int? MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public decimal? WasteWeight { get; set; }
        public bool? IsActive { get; set; }
    }
    #endregion
}
