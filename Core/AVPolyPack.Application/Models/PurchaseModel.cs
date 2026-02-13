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
    #region Purchase
    public class Purchase_Search : BaseSearchEntity
    {
    }

    public class Purchase_Request : BaseEntity
    {
        public Purchase_Request()
        {
            purchaseDetailsList = new List<PurchaseDetails_Request>();
        }
        public DateTime? PurchaseDate { get; set; }
        public string? PurchaseNumber { get; set; }
        public string? PurchaseInvoiceNo { get; set; }
        public DateTime? PurchaseInvoiceDate { get; set; }
        public int? InvoiceType { get; set; }
        public int? SupplierId { get; set; }
        public string? VehicleNumber { get; set; }

        public decimal? SubTotal { get; set; }
        public decimal? TotalCGST { get; set; }
        public decimal? TotalSGST { get; set; }
        public decimal? TotalIGST { get; set; }
        public decimal? RoundOff { get; set; }
        public decimal? TotalValue { get; set; }
        public bool? IsActive { get; set; }

        public List<PurchaseDetails_Request> purchaseDetailsList { get; set; }
    }

    public class PurchaseList_Response : BaseResponseEntity
    {
        public DateTime? PurchaseDate { get; set; }
        public string? PurchaseNumber { get; set; }
        public string? PurchaseInvoiceNo { get; set; }
        public DateTime? PurchaseInvoiceDate { get; set; }
        public int? InvoiceType { get; set; }
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? VehicleNumber { get; set; }
        public decimal? TotalValue { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Purchase_Response : BaseResponseEntity
    {
        public Purchase_Response()
        {
            purchaseDetailsList = new List<PurchaseDetails_Response>();
        }
        public DateTime? PurchaseDate { get; set; }
        public string? PurchaseNumber { get; set; }
        public string? PurchaseInvoiceNo { get; set; }
        public DateTime? PurchaseInvoiceDate { get; set; }
        public int? InvoiceType { get; set; }
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? VehicleNumber { get; set; }

        public decimal? SubTotal { get; set; }
        public decimal? TotalCGST { get; set; }
        public decimal? TotalSGST { get; set; }
        public decimal? TotalIGST { get; set; }
        public decimal? RoundOff { get; set; }
        public decimal? TotalValue { get; set; }
        public bool? IsActive { get; set; }
        public List<PurchaseDetails_Response> purchaseDetailsList { get; set; }
    }
    #endregion

    #region Purchase Details
    public class PurchaseDetails_Search : BaseSearchEntity
    {
        public int? PurchaseId { get; set; }
    }
    public class PurchaseDetails_Request : BaseEntity
    {
        public int? PurchaseId { get; set; }
        public int? MaterialTypeId { get; set; }
        public int? MaterialDetailsId { get; set; }
        public string? OtherDetails { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? ExtraCharge { get; set; }
        public decimal? Freight { get; set; }
        public decimal? TaxableValue { get; set; }

        [DefaultValue(false)]
        public bool? IsCGST { get; set; }
        public decimal? CGSTPerct { get; set; }
        public decimal? CGSTAmt { get; set; }

        [DefaultValue(false)]
        public bool? IsSGST { get; set; }
        public decimal? SGSTPerct { get; set; }
        public decimal? SGSTAmt { get; set; }

        [DefaultValue(false)]
        public bool? IsIGST { get; set; }
        public decimal? IGSTPerct { get; set; }
        public decimal? IGSTAmt { get; set; }
        public decimal? RoundOff { get; set; }


        public string? BillEntryNo { get; set; }
        public DateTime? BillEntryDate { get; set; }
        public int? AdvanceLicenseId { get; set; }
        public string? Naration { get; set; }
        public bool? IsActive { get; set; }
    }

    public class PurchaseDetails_Response : BaseResponseEntity
    {
        public int? PurchaseId { get; set; }
        public string? PurchaseNumber { get; set; }
        public int? MaterialTypeId { get; set; }
        public string? MaterialType { get; set; }
        public int? MaterialDetailsId { get; set; }
        public int? MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public int? UOMId { get; set; }
        public string? UOMName { get; set; }
        public string? HSNCode { get; set; }
        public string? OtherDetails { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? ExtraCharge { get; set; }
        public decimal? Freight { get; set; }
        public decimal? TaxableValue { get; set; }

        public bool? IsCGST { get; set; }
        public decimal? CGSTPerct { get; set; }
        public decimal? CGSTAmt { get; set; }

        public bool? IsSGST { get; set; }
        public decimal? SGSTPerct { get; set; }
        public decimal? SGSTAmt { get; set; }

        public bool? IsIGST { get; set; }
        public decimal? IGSTPerct { get; set; }
        public decimal? IGSTAmt { get; set; }
        public decimal? RoundOff { get; set; }

        public string? BillEntryNo { get; set; }
        public DateTime? BillEntryDate { get; set; }
        public int? AdvanceLicenseId { get; set; }
        public string? AdvanceLicenseNo { get; set; }
        public string? Naration { get; set; }
        public bool? IsActive { get; set; }
    }
    #endregion

}
