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
    public class Supplier_Request : BaseEntity
    {
        public string? SupplierCode { get; set; }
        public string? SupplierName { get; set; }
        public string? PartyName { get; set; }
        public int? CustomerId { get; set; }
        public int? GroupNameId { get; set; }
        public int? ReferenceId { get; set; }
        public string? MobileNumber1 { get; set; }
        public string? MobileNumber2 { get; set; }
        public string? EmailId1 { get; set; }
        public string? EmailId2 { get; set; }
        public string? Website { get; set; }
        public string? SpecialRemarks { get; set; }
        public string? CompanyRemarks { get; set; }
        public string? PanCardNumber { get; set; }

        [DefaultValue("")]
        public string? PanCardOriginalFileName { get; set; }

        [DefaultValue("")]
        public string? PanCardFileName { get; set; }

        [DefaultValue("")]
        public string? PanCard_Base64 { get; set; }

        public string? GSTNumber { get; set; }

        [DefaultValue("")]
        public string? GSTOriginalFileName { get; set; }

        [DefaultValue("")]
        public string? GSTFileName { get; set; }

        [DefaultValue("")]
        public string? GST_Base64 { get; set; }

        public string? ContactPersonName { get; set; }
        public string? ContactPersonMobileNumber { get; set; }
        public string? ContactPersonEmailId { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankIFSCCode { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public string? PinCode { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Supplier_Search : BaseSearchEntity
    {
    }

    public class Supplier_Response : BaseResponseEntity
    {
        public string? SupplierCode { get; set; }
        public string? SupplierName { get; set; }
        public string? PartyName { get; set; }
        public string? CompanyCode { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public int? GroupNameId { get; set; }
        public string? GroupName { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceName { get; set; }
        public string? MobileNumber1 { get; set; }
        public string? MobileNumber2 { get; set; }
        public string? EmailId1 { get; set; }
        public string? EmailId2 { get; set; }
        public string? Website { get; set; }
        public string? SpecialRemarks { get; set; }
        public string? CompanyRemarks { get; set; }

        public string? PanCardNumber { get; set; }

        [DefaultValue("")]
        public string? PanCardOriginalFileName { get; set; }

        [DefaultValue("")]
        public string? PanCardFileName { get; set; }

        [DefaultValue("")]
        public string? PanCardUrl { get; set; }

        public string? GSTNumber { get; set; }

        [DefaultValue("")]
        public string? GSTOriginalFileName { get; set; }

        [DefaultValue("")]
        public string? GSTFileName { get; set; }

        [DefaultValue("")]
        public string? GSTUrl { get; set; }

        public string? ContactPersonName { get; set; }
        public string? ContactPersonMobileNumber { get; set; }
        public string? ContactPersonEmailId { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankIFSCCode { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? StateId { get; set; }
        public string? StateName { get; set; }
        public int? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public string? PinCode { get; set; }
        public bool? IsActive { get; set; }
    }
}
