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
    #region Sale
    public class Sale_Search : BaseSearchEntity
    {
    }

    public class Sale_Request : BaseEntity
    {
        public Sale_Request()
        {
            purchaseDetailsList = new List<SaleDetails_Request>();
        }
        public DateTime? SaleInvoiceDate { get; set; }
        public string? SaleInvoiceNo { get; set; }
        public int? InvoiceType { get; set; }
        public int? CustomerId { get; set; }
        public string? VehicleNumber { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TotalCGST { get; set; }
        public decimal? TotalSGST { get; set; }
        public decimal? TotalIGST { get; set; }
        public decimal? RoundOff { get; set; }
        public decimal? TotalValue { get; set; }
        public bool? IsActive { get; set; }

        public List<SaleDetails_Request> purchaseDetailsList { get; set; }
    }

    public class SaleList_Response : BaseResponseEntity
    {
        public DateTime? SaleInvoiceDate { get; set; }
        public string? SaleInvoiceNo { get; set; }
        public int? InvoiceType { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? VehicleNumber { get; set; }
        public decimal? TotalValue { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Sale_Response : BaseResponseEntity
    {
        public Sale_Response()
        {
            saleDetailsList = new List<SaleDetails_Response>();
        }
        public DateTime? SaleInvoiceDate { get; set; }
        public string? SaleInvoiceNo { get; set; }
        public int? InvoiceType { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? VehicleNumber { get; set; }

        public decimal? SubTotal { get; set; }
        public decimal? TotalCGST { get; set; }
        public decimal? TotalSGST { get; set; }
        public decimal? TotalIGST { get; set; }
        public decimal? RoundOff { get; set; }
        public decimal? TotalValue { get; set; }
        public bool? IsActive { get; set; }
        public List<SaleDetails_Response> saleDetailsList { get; set; }
    }
    #endregion

    #region Sale Details
    public class SaleDetails_Search : BaseSearchEntity
    {
        public int? SaleId { get; set; }
    }
    public class SaleDetails_Request : BaseEntity
    {
        public int? SaleId { get; set; }
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


        public string? ShippingBillEntryNo { get; set; }
        public DateTime? ShippingBillEntryDate { get; set; }
        public int? AdvanceLicenseId { get; set; }
        public string? Naration { get; set; }
        public bool? IsActive { get; set; }
    }

    public class SaleDetails_Response : BaseResponseEntity
    {
        public int? SaleId { get; set; }
        public string? SaleInvoiceNo { get; set; }
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

        public string? ShippingBillEntryNo { get; set; }
        public DateTime? ShippingBillEntryDate { get; set; }
        public int? AdvanceLicenseId { get; set; }
        public string? AdvanceLicenseNo { get; set; }
        public string? Naration { get; set; }
        public bool? IsActive { get; set; }
    }
    #endregion
}
