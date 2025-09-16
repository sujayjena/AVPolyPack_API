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
    public class Printing_Search : BaseSearchEntity
    {
        public int? RollId { get; set; }
    }
    public class Printing_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public int? ShiftType { get; set; }
        public int? PrintingMachineId { get; set; }
        public string? PrintingName { get; set; }
        public string? PrintingSize { get; set; }

        [DefaultValue(false)]
        public bool? IsCompleted { get; set; }
    }

    public class Printing_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public int? ShiftType { get; set; }
        public int? PrintingMachineId { get; set; }
        public string? PrintingMachineName { get; set; }
        public string? PrintingName { get; set; }
        public string? PrintingSize { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletedDateTime { get; set; }
    }
}
