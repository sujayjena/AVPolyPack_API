using AVPolyPack.Domain.Entities;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    #region Soft Material In
    public class SoftMaterialIn_Search : BaseSearchEntity
    {
        public int? StatusId { get; set; }
    }

    public class SoftMaterialIn_Request : BaseEntity
    {
        public SoftMaterialIn_Request()
        {
            materialInList = new List<SoftMaterialInDetails_Request>();
        }
        public string? InwardingId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? VehicleNumber { get; set; }
        public int? VendorId { get; set; }
        public int? SupplierId { get; set; }
        public string? Remarks { get; set; }
        public int? StatusId { get; set; }
        public bool? IsActive { get; set; }
        public List<SoftMaterialInDetails_Request> materialInList { get; set; }
    }

    public class SoftMaterialIn_Response : BaseResponseEntity
    {
        public SoftMaterialIn_Response()
        {
            materialInList = new List<SoftMaterialInDetails_Response>();
        }
        public string? InwardingId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? VehicleNumber { get; set; }
        public int? VendorId { get; set; }
        public string? VendorName { get; set; }
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Remarks { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public bool? IsActive { get; set; }
        public List<SoftMaterialInDetails_Response> materialInList { get; set; }
    }
    #endregion

    #region Soft Material In Details
    public class SoftMaterialInDetails_Search : BaseSearchEntity
    {
        public int? SoftMaterialInId { get; set; }
    }

    public class SoftMaterialInDetails_Request : BaseEntity
    {
        [JsonIgnore]
        public int? SoftMaterialInId { get; set; }
        public int? MaterialId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Weight { get; set; }
        public bool? IsActive { get; set; }
    }

    public class SoftMaterialInDetails_Response : BaseResponseEntity
    {
        public int? SoftMaterialInId { get; set; }
        public int? MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public string? HSNCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Weight { get; set; }
        public int? IsOk { get; set; }
        public decimal? ReceivedQty { get; set; }
        public decimal? ReceivedWeight { get; set; }
        public bool? IsActive { get; set; }
    }
    public class ReceivedSoftMaterialInList_Request : BaseEntity
    {

        [DefaultValue(0)]
        public int? IsOk { get; set; }
        public decimal? ReceivedQty { get; set; }
        public decimal? ReceivedWeight { get; set; }
        public int? StatusId { get; set; }
    }
    #endregion
}
