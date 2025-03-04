using AVPolyPack.Domain.Entities;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    public class Rolls_Search : BaseSearchEntity
    {
    }

    public class Rolls_Request : BaseEntity
    {
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public string? RollNumber { get; set; }
        public int? LoomsId { get; set; }
        public DateTime? ProductionDate { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? TareWeight { get; set; }
        public decimal? Meter { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? Average { get; set; }
        public decimal? AverageDiff { get; set; }
        public string? Notes { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Rolls_Response : BaseResponseEntity
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public string? RollNumber { get; set; }
        public int? LoomsId { get; set; }
        public string? LoomNumber { get; set; }
        public DateTime? ProductionDate { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? TareWeight { get; set; }
        public decimal? Meter { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? Average { get; set; }
        public decimal? AverageDiff { get; set; }
        public string? Notes { get; set; }
        public bool? IsActive { get; set; }
    }
}
