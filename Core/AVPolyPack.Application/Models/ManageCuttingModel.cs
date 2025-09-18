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
    #region Cutting
    public class Cutting_Search : BaseSearchEntity
    {
        public int? RollId { get; set; }
    }
    public class Cutting_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
        public int? CuttingSize { get; set; }
        public int? TotalPcs { get; set; }
        public int? OpeningReading { get; set; }
        public int? ClosingReading { get; set; }
        public int? GoodPcs { get; set; }
        public int? WastePcs { get; set; }
        public int? DiffPcs { get; set; }

        [DefaultValue(false)]
        public bool? IsCompleted { get; set; }
    }

    public class Cutting_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
        public string? MachineName { get; set; }
        public string? Descriptions { get; set; }
        public int? CuttingSize { get; set; }
        public int? TotalPcs { get; set; }
        public int? OpeningReading { get; set; }
        public int? ClosingReading { get; set; }
        public int? GoodPcs { get; set; }
        public int? WastePcs { get; set; }
        public int? DiffPcs { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletedDateTime { get; set; }
    }
    #endregion

    #region Cutting Machine Reading
    public class CuttingMachineReading_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
    }
    public class CuttingMachineReading_Request : BaseEntity
    {
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
        public int? OpeningReading { get; set; }
        public int? ClosingReading { get; set; }
    }

    public class CuttingMachineReading_Response : BaseResponseEntity
    {
        public int? ShiftType { get; set; }
        public int? CuttingMachineId { get; set; }
        public string? MachineName { get; set; }
        public string? Descriptions { get; set; }
        public int? OpeningReading { get; set; }
        public int? ClosingReading { get; set; }
    }
    #endregion
}
