using AVPolyPack.Domain.Entities;
using AVPolyPack.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    public class Customer_Search : BaseSearchEntity
    {
        public int? ParentCustomerId { get; set; }
        public int? CountryId { get; set; }
        public int? CustomerId { get; set; }
    }

    public class Customer_Request : BaseEntity
    {
        public string? CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public string? LandLineNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? EmailId1 { get; set; }
        public int? ParentCustomerId { get; set; }
        public int? ReferenceId { get; set; }
        public string? Website { get; set; }
        public string? Remark { get; set; }
        public string? CustomerRemark { get; set; }
        public string? RefParty { get; set; }

        [DefaultValue(false)]
        public bool? IsGST { get; set; }
        public string? GSTNumber { get; set; }
        public string? GSTImageFileName { get; set; }
        public string? GSTImage_Base64 { get; set; }
        public string? GSTImageOriginalFileName { get; set; }
        public string? PanCardImageFileName { get; set; }
        public string? PanCardImage_Base64 { get; set; }
        public string? PanCardOriginalFileName { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? BankAccount { get; set; }
        public string? BankIFSCCode { get; set; }
        public bool? IsActive { get; set; }

        public ContactDetail_Request ContactDetail { get; set; }
        public Address_Request BillingDetail { get; set; }
        public ShippingAddress_Request ShippingDetail { get; set; }
    }

    public class CustomerList_Response : BaseResponseEntity
    {
        public string? CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public string? LandLineNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? EmailId1 { get; set; }
        public int? ParentCustomerId { get; set; }
        public string? ParentCustomerName { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceName { get; set; }
        public string? Website { get; set; }
        public string? Remark { get; set; }
        public string? CustomerRemark { get; set; }
        public string? RefParty { get; set; }
        public bool? IsGST { get; set; }
        public string? GSTNumber { get; set; }
        public string? GSTImage { get; set; }
        public string? GSTImageOriginalFileName { get; set; }
        public string? GSTImageURL { get; set; }
        public string? PanCardImage { get; set; }
        public string? PanCardOriginalFileName { get; set; }
        public string? PanCardImageURL { get; set; }
        public string? ContactName { get; set; }
        public string? ContactMobileNo { get; set; }
        public string? ContactEmailId { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? BankAccount { get; set; }
        public string? BankIFSCCode { get; set; }
        public int? IsNational_Or_International { get; set; }
        public string? Address1 { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? StateId { get; set; }
        public string? StateName { get; set; }
        public int? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CustomerDetail_Response : BaseResponseEntity
    {
        public CustomerDetail_Response()
        {
            ContactDetail = new ContactDetail_Response();
            BillingDetail = new Address_Response();
            ShippingDetail = new ShippingAddress_Response();
        }

        public string? CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public string? LandLineNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? EmailId1 { get; set; }
        public int? ParentCustomerId { get; set; }
        public string? ParentCustomerName { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceName { get; set; }
        public string? Website { get; set; }
        public string? Remark { get; set; }
        public string? CustomerRemark { get; set; }
        public string? RefParty { get; set; }
        public bool? IsGST { get; set; }
        public string? GSTNumber { get; set; }
        public string? GSTImage { get; set; }
        public string? GSTImageOriginalFileName { get; set; }
        public string? GSTImageURL { get; set; }
        public string? PanCardImage { get; set; }
        public string? PanCardOriginalFileName { get; set; }
        public string? PanCardImageURL { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? BankAccount { get; set; }
        public string? BankIFSCCode { get; set; }
        public bool? IsActive { get; set; }
        public ContactDetail_Response ContactDetail { get; set; }
        public Address_Response BillingDetail { get; set; }
        public ShippingAddress_Response ShippingDetail { get; set; }
    }

    #region Import and Download

    public class Customer_ImportRequest
    {
        public IFormFile FileUpload { get; set; }
    }

    public class Customer_ImportData
    {
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public string? ParentCustomer { get; set; }
	    public string? ReferenceFrom { get; set; }
	    public string? MobileNo1 { get; set; }
	    public string? MobileNo2 { get; set; }
	    public string? EmailId1 { get; set; }
	    public string? EmailId2 { get; set; }
	    public string? IsGST { get; set; }
	    public string? GSTNumber { get; set; }
	    public string? Website { get; set; }
	    public string? SpecialRemark { get; set; }
	    public string? CustomerRemark { get; set; }
	    public string? ContactName { get; set; }
	    public string? ContactPerson { get; set; }
	    public string? ContactMobileNo { get; set; }
	    public string? ContactEmailId { get; set; }
	    public string? BankName { get; set; }
	    public string? BankAddress { get; set; }
	    public string? BankAccount { get; set; }
	    public string? BankIFSCCode { get; set; }
	    public string? IsBillingNationalOrInternational { get; set; }	
	    public string? BillingAddress { get; set; }
	    public string? BillingCountry { get; set; }
	    public string? BillingState { get; set; }
	    public string? BillingDistrict { get; set; }
	    public string? BillingCity { get; set; }
	    public string? BillingPincode { get; set; }
	    public string? IsShippingNationalOrInternational { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCountry { get; set; }
	    public string? ShippingState { get; set; }
	    public string? ShippingDistrict { get; set; }
	    public string? ShippingCity { get; set; }
        public string? ShippingPincode { get; set; }
        public string? IsActive { get; set; }
    }

    public class Customer_ImportDataValidation
    {
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public string? ParentCustomer { get; set; }
        public string? ReferenceFrom { get; set; }
        public string? MobileNo1 { get; set; }
        public string? MobileNo2 { get; set; }
        public string? EmailId1 { get; set; }
        public string? EmailId2 { get; set; }
        public string? IsGST { get; set; }
        public string? GSTNumber { get; set; }
        public string? Website { get; set; }
        public string? SpecialRemark { get; set; }
        public string? CustomerRemark { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactMobileNo { get; set; }
        public string? ContactEmailId { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? BankAccount { get; set; }
        public string? BankIFSCCode { get; set; }
        public string? IsBillingNationalOrInternational { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingCountry { get; set; }
        public string? BillingState { get; set; }
        public string? BillingDistrict { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingPincode { get; set; }
        public string? IsShippingNationalOrInternational { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCountry { get; set; }
        public string? ShippingState { get; set; }
        public string? ShippingDistrict { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingPincode { get; set; }
        public string? IsActive { get; set; }
        public string ValidationMessage { get; set; }
    }

    #endregion
}
