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
    public class UserModel
    {
    }

    public class User_Request : BaseEntity
    {
        public User_Request()
        {
            UserDetailsList = new List<UserOtherDetails_Request>();
        }

        public string? UserCode { get; set; }
        public string? UserName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }
        public int? RoleId { get; set; }
        public int? ReportingTo { get; set; }

        [DefaultValue(1)]
        public int? CompanyId { get; set; }

        [DefaultValue(1)]
        public int? DepartmentId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int? BloodGroupId { get; set; }
        public int? GenderId { get; set; }
        public int? MaritalStatusId { get; set; }
        public string? Hours { get; set; }
        public decimal? Rate { get; set; }

        public string? AddressLine { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public int? Pincode { get; set; }

        [DefaultValue(false)]
        public bool? IsSameAsPermanent { get; set; }
        public string? TemporaryAddress { get; set; }
        public int? TemporaryStateId { get; set; }
        public int? TemporaryDistrictId { get; set; }
        public int? TemporaryCityId { get; set; }

        public int? TemporaryPincode { get; set; }
        public string? EmergencyName { get; set; }
        public string? EmergencyContactNumber { get; set; }
        public string? EmergencyRelation { get; set; }

        public string? MobileUniqueId { get; set; }
        public string? AadharNumber { get; set; }
        public string? AadharOriginalFileName { get; set; }
        public string? AadharImage { get; set; }
        public string? AadharImage_Base64 { get; set; }

        public string? PanNumber { get; set; }
        public string? PanCardOriginalFileName { get; set; }

        [JsonIgnore]
        public string? PanCardImage { get; set; }
        public string? PanCardImage_Base64 { get; set; }

        public string? ProfileOriginalFileName { get; set; }

        [JsonIgnore]
        public string? ProfileImage { get; set; }
        public string? ProfileImage_Base64 { get; set; }
       
        public string? OtherProof { get; set; }
        public string? OtherProofOriginalFileName { get; set; }

        [JsonIgnore]
        public string? OtherProofFileName { get; set; }
        public string? OtherProof_Base64 { get; set; }
        public int? BankId { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankIFSCCode { get; set; }
        public string? BankDetailsOriginalFileName { get; set; }

        [JsonIgnore]
        public string? BankDetailsFileName { get; set; }
        public string? BankDetails_Base64 { get; set; }

        [DefaultValue(false)]
        public bool? IsSupervisor { get; set; }
        public bool? IsMobileUser { get; set; }
        public bool? IsWebUser { get; set; }
        public bool? IsActive { get; set; }

        public List<UserOtherDetails_Request> UserDetailsList { get; set; }
    }

    public class User_Response : BaseResponseEntity
    {
        public User_Response()
        {
            UserDetailsList = new List<UserOtherDetails_Response>();
        }

        public string? UserCode { get; set; }
        public string? UserName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public int? EmployeeLevelId { get; set; }
        public string? EmployeeLevel { get; set; }
        public int? ReportingTo { get; set; }
        public string? ReportingToName { get; set; }
        public string? ReportingToMobileNo { get; set; }
    
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int? BloodGroupId { get; set; }
        public string? BloodGroupName { get; set; }
        public int? GenderId { get; set; }
        public string? Gender { get; set; }
        public int? MaritalStatusId { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Hours { get; set; }
        public decimal? Rate { get; set; }

        public string? AddressLine { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? StateId { get; set; }
        public string? StateName { get; set; }
        public int? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public int? Pincode { get; set; }
        public bool? IsSameAsPermanent { get; set; }
        public string? TemporaryAddress { get; set; }
        public int? TemporaryStateId { get; set; }
        public string? TemporaryStateName { get; set; }
        public int? TemporaryDistrictId { get; set; }
        public string? TemporaryDistrictName { get; set; }
        public int? TemporaryCityId { get; set; }
        public string? TemporaryCityName { get; set; }
        public int? TemporaryPincode { get; set; }

        public string? EmergencyName { get; set; }
        public string? EmergencyContactNumber { get; set; }
        public string? EmergencyRelation { get; set; }

        public string? MobileUniqueId { get; set; }
        public string? AadharNumber { get; set; }
        public string? AadharOriginalFileName { get; set; }
        public string? AadharImage { get; set; }
        public string? AadharImageURL { get; set; }

        public string? PanNumber { get; set; }
        public string? PanCardOriginalFileName { get; set; }
        public string? PanCardImage { get; set; }
        public string? PanCardImageURL { get; set; }

        public string? ProfileOriginalFileName { get; set; }
        public string? ProfileImage { get; set; }
        public string? ProfileImageURL { get; set; }

        public string? OtherProof { get; set; }
        public string? OtherProofOriginalFileName { get; set; }
        public string? OtherProofFileName { get; set; }
        public string? OtherProofURL { get; set; }

        public int? BankId { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankIFSCCode { get; set; }
        public string? BankDetailsOriginalFileName { get; set; }
        public string? BankDetailsFileName { get; set; }
        public string? BankDetailsURL { get; set; }
        public bool? IsSupervisor { get; set; }
        public bool? IsMobileUser { get; set; }
        public bool? IsWebUser { get; set; }
        public bool? IsActive { get; set; }

        public List<UserOtherDetails_Response> UserDetailsList { get; set; }
    }

    public class UserListByRole_Search
    {
        public int? CompanyId { get; set; }

        public string? RoleId { get; set; }
        public string? RoleName { get; set; }

        [DefaultValue(null)]
        public bool? IsActive { get; set; }
    }

    public class UserListByRole_Response
    {
        public int? UserId { get; set; }

        public string? UserName { get; set; }
    }

    public class ImportRequest
    {
        public IFormFile FileUpload { get; set; }
    }

    #region Import and Download

    public class User_ImportRequest
    {
        public IFormFile FileUpload { get; set; }
    }

    public class User_ImportData
    {
        public string? UserCode { get; set; }

        public string? UserName { get; set; }

        public string? MobileNumber { get; set; }

        public string? EmailId { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        public string? ReportingTo { get; set; }

        public string? Department { get; set; }

        public string? Company { get; set; }

        public string? Address { get; set; }

        public string? State { get; set; }

        public string? District { get; set; }

        public string? City { get; set; }

        public string? Pincode { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfJoining { get; set; }

        public string? EmergencyContactNumber { get; set; }

        public string? BloodGroup { get; set; }

        public string? AadharNumber { get; set; }

        public string? PanNumber { get; set; }

        public string? MobileUniqueId { get; set; }

        public string? IsMobileUser { get; set; }

        public string? IsWebUser { get; set; }

        public string? IsActive { get; set; }
    }

    public class User_ImportDataValidation
    {
        public string? UserCode { get; set; }

        public string? UserName { get; set; }

        public string? MobileNumber { get; set; }

        public string? EmailId { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        public string? ReportingTo { get; set; }

        public string? Department { get; set; }

        public string? Company { get; set; }

        public string? Address { get; set; }

        public string? State { get; set; }

        public string? District { get; set; }

        public string? City { get; set; }

        public string? Pincode { get; set; }

        public string? DateOfBirth { get; set; }

        public string? DateOfJoining { get; set; }

        public string? EmergencyContactNumber { get; set; }

        public string? BloodGroup { get; set; }

        public string? AadharNumber { get; set; }

        public string? PanNumber { get; set; }

        public string? MobileUniqueId { get; set; }

        public string? IsMobileUser { get; set; }

        public string? IsWebUser { get; set; }

        public string? IsActive { get; set; }

        public string ValidationMessage { get; set; }
    }

    public class UserOtherDetails_Request : BaseEntity
    {
        public int? EmployeeId { get; set; }
        public string? PastCompanyName { get; set; }
        public string? TotalExp { get; set; }
        public string? Remarks { get; set; }
    }

    public class UserOtherDetails_Search : BaseSearchEntity
    {
        public int? EmployeeId { get; set; }
    }

    public class UserOtherDetails_Response : BaseResponseEntity
    {
        public int? EmployeeId { get; set; }
        public string? PastCompanyName { get; set; }
        public string? TotalExp { get; set; }
        public string? Remarks { get; set; }
    }

    #endregion
}
