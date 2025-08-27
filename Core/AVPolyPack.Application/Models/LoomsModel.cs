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
    public class Looms_Search : BaseSearchEntity
    {
    }

    public class Looms_Request : BaseEntity
    {
        public string? LoomNumber { get; set; }
        public decimal? Average { get; set; }
        public decimal? Denier { get; set; }
        public int? SizeId { get; set; }
        public int? GramId { get; set; }
        public int? MeshId { get; set; }
        public int? SpecificationId { get; set; }
        public int? TypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Looms_Response : BaseResponseEntity
    {
        public string? LoomNumber { get; set; }
        public decimal? Average { get; set; }
        public decimal? Denier { get; set; }
        public int? SizeId { get; set; }
        public string? SizeName { get; set; }
        public int? GramId { get; set; }
        public string? GramName { get; set; }
        public int? MeshId { get; set; }
        public string? MeshName { get; set; }
        public int? SpecificationId { get; set; }
        public string? SpecificationName { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
    }

    #region Loom Assign
    public class LoomAssign_Request : BaseEntity
    {
        public int? LoomId { get; set; }
        public int? ShiftType { get; set; }
        public int? EmployeeId { get; set; }
    }
    public class LoomAssign_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
        public int ShiftType { get; set; }
    }

    public class LoomAssign_Response : BaseResponseEntity
    {
        public int? LoomId { get; set; }
        public string? LoomName { get; set; }
        public int? ShiftType { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
    }

    public class LoomListForAssignOperator_Search : BaseSearchEntity
    {
        public int ShiftType { get; set; }
        public bool IsAssign { get; set; }
        public int EmployeeId { get; set; }

        [DefaultValue(false)]
        public bool IsIdle { get; set; }
    }

    public class LoomListForAssignOperator_Response
    {
        public int? Id { get; set; }
        public string? LoomName { get; set; }
    }
    public class OperatorNameSelectList_Search
    {
        public int? ShiftType { get; set; }

        [DefaultValue(null)]
        public bool? IsPresent { get; set; }
    }
    public class OperatorNameSelectList_Response
    {
        public long Value { get; set; }
        public string? Text { get; set; }
        public string? LoomName { get; set; }
        public bool? IsPresent { get; set; }
    }

    #endregion

    #region Order Item Assign

    public class OrderItemAssign_Request : BaseEntity
    {
        public int? LoomId { get; set; }
        public int? ShiftType { get; set; }
        public int? OrderItemId { get; set; }
    }
    public class OrderItemAssign_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
        public int ShiftType { get; set; }
    }

    public class OrderItemAssign_Response : BaseResponseEntity
    {
        public int? LoomId { get; set; }
        public string? LoomName { get; set; }
        public int? ShiftType { get; set; }
        public int? OrderItemId { get; set; }
        public string? OrderItemNo { get; set; }
    }

    #endregion
}
