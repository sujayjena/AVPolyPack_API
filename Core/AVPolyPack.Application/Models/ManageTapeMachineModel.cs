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
    #region Machine Assign
    public class MachineAssign_Request : BaseEntity
    {
        public int? TapeMachineId { get; set; }
        public int? ShiftType { get; set; }
        public int? RefId { get; set; }

        [DefaultValue("Employee")]
        public string? RefType { get; set; }
    }
    public class MachineAssign_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int TapeMachineId { get; set; }
        public int ShiftType { get; set; }
    }

    public class MachineAssign_Response : BaseResponseEntity
    {
        public int? TapeMachineId { get; set; }
        public string? TapeMachineName { get; set; }
        public int? ShiftType { get; set; }
        public int? RefId { get; set; }
        public string? RefType { get; set; }
        public string? RefName { get; set; }
    }

    #endregion

    #region Machine Start Stop
    public class MachineStartStop_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
        public int? TapeMachineId { get; set; }
        public int? ShiftType { get; set; }
        public int? IsStart_Stop { get; set; }
    }

    public class MachineStartStop_Request : BaseEntity
    {
        public int? TapeMachineId { get; set; }
        public int? ShiftType { get; set; }
        public int? IsStart_Stop { get; set; }
        public string? Remarks { get; set; }
    }

    public class MachineStartStop_Response
    {
        public int Id { get; set; }
        public int? TapeMachineId { get; set; }
        public string? TapeMachineName { get; set; }
        public int? ShiftType { get; set; }
        public int? StartBy { get; set; }
        public string? StartByName { get; set; }
        public DateTime? StartDate { get; set; }
        public string? StartRemarks { get; set; }
        public int? StopBy { get; set; }
        public string? StopByName { get; set; }
        public DateTime? StopDate { get; set; }
        public string? StopRemarks { get; set; }
    }
    #endregion

    #region Machine Remark
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
    #endregion

    #region Employee List for Assign
    public class EmployeeListForAssignMachine_Search : BaseSearchEntity
    {
        public int? DepartmentId { get; set; }
        public int? RoleId { get; set; }
        public int? ShiftType { get; set; }
        public int? TapeMachineId { get; set; }

        [DefaultValue("Employee")]
        public string? RefType { get; set; }
        public int? RefId { get; set; }
    }

    public class EmployeeListForAssignMachine_Response
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? UserCode { get; set; }
        public string? RefType { get; set; }
    }
    #endregion
}
