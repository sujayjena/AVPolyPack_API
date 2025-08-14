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
    public class TapeMachineRemarks_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int TapeMachineId { get; set; }
        public int ShiftType { get; set; }
    }

    public class TapeMachineRemarks_Request : BaseEntity
    {
        public int? TapeMachineId { get; set; }
        public int? ShiftType { get; set; }
        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
    }

    public class TapeMachineRemarks_Response : BaseResponseEntity
    {
        public int? TapeMachineId { get; set; }
        public string? TapeMachineName { get; set; }
        public int? ShiftType { get; set; }
        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
    }
}
