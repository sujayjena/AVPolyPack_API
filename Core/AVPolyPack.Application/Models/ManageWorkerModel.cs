using AVPolyPack.Domain.Entities;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    public class Worker_Search : BaseSearchEntity
    {
    }

    public class Worker_Request : BaseEntity
    {
        public string? WorkerId { get; set; }
        public string? WorkerName { get; set; }
        public string? MobileNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Worker_Response : BaseResponseEntity
    {
        public string? WorkerId { get; set; }
        public string? WorkerName { get; set; }
        public string? MobileNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public bool? IsActive { get; set; }
    }
}
