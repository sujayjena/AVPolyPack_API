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
    #region Cutting
    public class Cutting_Search : BaseSearchEntity
    {
        public int? RollId { get; set; }
    }
    public class Cutting_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
        public int? CuttingSize { get; set; }
        public int? TotalPcs { get; set; }
        public int? OpeningReading { get; set; }
        public int? ClosingReading { get; set; }
        public int? GoodPcs { get; set; }
        public int? WastePcs { get; set; }
        public int? DiffPcs { get; set; }

        [DefaultValue(false)]
        public bool? IsCompleted { get; set; }
    }

    public class CuttingList_Response : BaseResponseEntity
    {
        public int? OrderItemId { get; set; }
        public string? OrderItemNo { get; set; }
        public int? LoomId { get; set; }
        public string? LoomName { get; set; }
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? PaymentTermId { get; set; }
        public string? PaymentTerm { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Mixing { get; set; }
        public string? ItemSize { get; set; }
        public string? GSM { get; set; }
        public string? GPM { get; set; }
        public string? ItemAverage { get; set; }
        public string? Gram { get; set; }
        public int? MeshId { get; set; }
        public string? MeshName { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int? SpecificationId { get; set; }
        public string? SpecificationName { get; set; }
        public string? Strength { get; set; }
        public bool? IsGuzzet { get; set; }
        public string? Guzzet { get; set; }
        public decimal? Quantity { get; set; }
        public string? ItemMeter { get; set; }
        public bool? IsLab { get; set; }
        public bool? IsLamination { get; set; }
        public string? LaminationCoatingGSM { get; set; }
        public int? LaminationTypeId { get; set; }
        public string? LaminationTypeName { get; set; }
        public bool? IsInventory { get; set; }
        public string? OrderRemarks { get; set; }
        public string? Remarks { get; set; }
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
        public string? MachineName { get; set; }
        public string? Descriptions { get; set; }
        public int? CuttingSize { get; set; }
        public int? TotalPcs { get; set; }
        public int? OpeningReading { get; set; }
        public int? ClosingReading { get; set; }
        public int? GoodPcs { get; set; }
        public int? WastePcs { get; set; }
        public int? DiffPcs { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletedDateTime { get; set; }
    }
    public class Cutting_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
        public string? MachineName { get; set; }
        public string? Descriptions { get; set; }
        public int? CuttingSize { get; set; }
        public int? TotalPcs { get; set; }
        public int? OpeningReading { get; set; }
        public int? ClosingReading { get; set; }
        public int? GoodPcs { get; set; }
        public int? WastePcs { get; set; }
        public int? DiffPcs { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletedDateTime { get; set; }
    }
    #endregion

    #region Cutting Machine Reading
    public class CuttingMachineReading_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
    }
    public class CuttingMachineReading_Request : BaseEntity
    {
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
        public int? OpeningReading { get; set; }
        public int? ClosingReading { get; set; }
    }

    public class CuttingMachineReading_Response : BaseResponseEntity
    {
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
        public string? MachineName { get; set; }
        public string? Descriptions { get; set; }
        public int? OpeningReading { get; set; }
        public int? ClosingReading { get; set; }
    }
    #endregion
}
