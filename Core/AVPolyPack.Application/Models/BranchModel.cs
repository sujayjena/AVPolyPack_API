using AVPolyPack.Domain.Entities;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    public class Branch_Request : BaseEntity
    {
        public string? BranchName { get; set; }
        public int? CompanyId { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? GSTNumber { get; set; }
        public int? NoofUserAdd { get; set; }
        public string? AddressLine { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public string? Pincode { get; set; }
        public bool? IsActive { get; set; }
    }
    public class BranchSearch_Request : BaseSearchEntity
    {
        public int? CompanyId { get; set; }
    }
    public class Branch_Response : BaseResponseEntity
    {
        public string? BranchName { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? GSTNumber { get; set; }
        public int? NoofUserAdd { get; set; }
        public string? AddressLine { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? StateId { get; set; }
        public string? StateName { get; set; }
        public int? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public string? Pincode { get; set; }
        public bool? IsActive { get; set; }
    }
}
