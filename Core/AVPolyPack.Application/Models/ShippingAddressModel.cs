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
    public class ShippingAddress_Search : BaseSearchEntity
    {
        public long RefId { get; set; }

        [DefaultValue("Customer")]
        public string? RefType { get; set; }
    }

    public class ShippingAddress_Request : BaseEntity
    {
        //[JsonIgnore]
        public int? RefId { get; set; }

        [DefaultValue("Customer")]
        public string? RefType { get; set; }
        public int? IsNational_Or_International { get; set; }
        public string? Address1 { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public string? PinCode { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class ShippingAddress_Response : BaseResponseEntity
    {
        public int? RefId { get; set; }
        public string? RefType { get; set; }
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
        public string? PinCode { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
