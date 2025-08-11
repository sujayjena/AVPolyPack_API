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
    public class Denier_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int TapeMachineId { get; set; }
        public int ShiftType { get; set; }
    }

    public class Denier_Request : BaseEntity
    {
        public int? TapeMachineId { get; set; }
        public int? ShiftType { get; set; }
        public string? Denier { get; set; }
        public decimal? TapeWidth { get; set; }
        public decimal? Strength { get; set; }
        public decimal? Elongation { get; set; }
        public string? RequiredQty { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Denier_Response : BaseResponseEntity
    {
        public int? TapeMachineId { get; set; }
        public string? TapeMachineName { get; set; }
        public int? ShiftType { get; set; }
        public string? Denier { get; set; }
        public decimal? TapeWidth { get; set; }
        public decimal? Strength { get; set; }
        public decimal? Elongation { get; set; }
        public string? RequiredQty { get; set; }
        public bool? IsActive { get; set; }
    }
}

