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
    public class Inventory_Search : BaseSearchEntity
    {
        public int? RollId { get; set; }
    }
    public class Inventory_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public int? ShiftType { get; set; }

        [DefaultValue(false)]
        public bool? IsCompleted { get; set; }
    }

    public class Inventory_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public int? ShiftType { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletedDateTime { get; set; }
    }

    #region Inventory Roll
    public class InventoryRoll_Search : BaseSearchEntity
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? TypeId { get; set; }
        public string? Size { get; set; }
        public string? RollLength { get; set; }
        public decimal? EstimatedWeight { get; set; }
        public string? GSM { get; set; }
        public string? Average { get; set; }
        public string? Gram { get; set; }
        public int? MeshId { get; set; }
        public string? Strength { get; set; }
        public string? Guzzet { get; set; }
        public string? FoldingSize { get; set; }

        [DefaultValue(false)]
        public bool? IsAntiSlip { get; set; }

        public int? OrderType { get; set; }
    }
    public class InventoryRoll_Response : BaseResponseEntity
    {
        public string? OrderItemNo { get; set; }
        public string? LoomNumber { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public string? Ageing { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? PaymentTermId { get; set; }
        public string? PaymentTerm { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Mixing { get; set; }
        public string? Size { get; set; }
        public string? GSM { get; set; }
        public string? Average { get; set; }
        public string? Gram { get; set; }
        public int? MeshId { get; set; }
        public string? MeshName { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int? SpecificationId { get; set; }
        public string? SpecificationName { get; set; }
        public string? Strength { get; set; }
        public string? Guzzet { get; set; }
        public decimal? Quantity { get; set; }
        public string? Meter { get; set; }
        public bool? IsLab { get; set; }
        public bool? IsLamination { get; set; }
        public string? LaminationCoatingGSM { get; set; }
        public int? LaminationTypeId { get; set; }
        public string? LaminationTypeName { get; set; }
        public bool? IsInventory { get; set; }
        public string? OrderRemarks { get; set; }
        public string? Remarks { get; set; }
        public string? RollLength { get; set; }
    }
    #endregion

    #region Split Roll
    public class SplitRoll_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public string? SplitRollNo { get; set; }
        public string? SplitRollLength { get; set; }
    }
    public class SplitRoll_Search : BaseSearchEntity
    {
        public int? RollId { get; set; }
    }
    public class SplitRoll_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? LoomNumber { get; set; }
        public string? SplitRollNo { get; set; }
        public string? SplitRollLength { get; set; }
        public decimal? TotalMeter { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? TareWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? CurrentAvg { get; set; }
        public decimal? CurrentGSM { get; set; }
        public decimal? AvgDiff { get; set; }
        public string? BarcodeOriginalFileName { get; set; }
        public string? BarcodeFileName { get; set; }
        public string? BarcodeURL { get; set; }

    }
    #endregion

    #region Merge Roll
    public class MergeRoll_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderItemId { get; set; }
        public string? MergeRollNo { get; set; }
        public string? MergeRollLength { get; set; }
    }
    public class MergeRoll_Search : BaseSearchEntity
    {
        public int? RollId { get; set; }
    }
    public class MergeRoll_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? LoomNumber { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? OrderItemId { get; set; }
        public string? OrderItemNo { get; set; }
        public string? MergeRollNo { get; set; }
        public string? MergeRollLength { get; set; }
        public decimal? TotalMeter { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? TareWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? CurrentAvg { get; set; }
        public decimal? CurrentGSM { get; set; }
        public decimal? AvgDiff { get; set; }
        public string? BarcodeOriginalFileName { get; set; }
        public string? BarcodeFileName { get; set; }
        public string? BarcodeURL { get; set; }

    }
    #endregion
}
