using AVPolyPack.Domain.Entities;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
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
}
