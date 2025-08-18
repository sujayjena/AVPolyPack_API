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
    public class Attendance_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
        public int? DepartmentId { get; set; }
        public int? RoleId { get; set; }
        public int? ShiftType { get; set; }

        [DefaultValue(null)]
        public bool? IsPresent { get; set; }
        public int? IsCheckedIn_Out { get; set; }
    }

    public class Attendance_Request : BaseEntity
    {
        public int? ShiftType { get; set; }
        public int? RefId { get; set; }

        [DefaultValue("Employee")]
        public string? RefType { get; set; }
        public int? IsCheckedIn_Out { get; set; }
        public int? EffortId { get; set; }

        [DefaultValue(false)]
        public bool? IsPresent { get; set; }
    }

    public class Attendance_Response
    {
        public int Id { get; set; }
        public int? ShiftType { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public int? RefId { get; set; }
        public string? RefType { get; set; }
        public string? RefName { get; set; }
        public string? RefCode { get; set; }
        public int? CheckedInBy { get; set; }
        public DateTime? CheckedInDate { get; set; }
        public int? CheckedOutBy { get; set; }
        public DateTime? CheckedOutDate { get; set; }
        public int? EffortId { get; set; }
        public string? EffortName { get; set; }
        public bool? IsPresent { get; set; }
    }

    public class EmployeeListForAttendance_Search : BaseSearchEntity
    {
        public int? DepartmentId { get; set; }
        public int? RoleId { get; set; }
        public int? ShiftType { get; set; }

        [DefaultValue("Employee")]
        public string? RefType { get; set; }       
        public int? RefId { get; set; }

        [DefaultValue(null)]
        public bool? IsPresent { get; set; }       
    }

    public class EmployeeListForAttendance_Response
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
}
