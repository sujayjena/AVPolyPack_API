using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageAttendanceRepository
    {
        Task<int> SaveAttendance(Attendance_Request parameters);
        Task<IEnumerable<Attendance_Response>> GetAttendanceList(Attendance_Search parameters);
        Task<IEnumerable<EmployeeListForAttendance_Response>> GetEmployeeListForAttendance(EmployeeListForAttendance_Search parameters);
    }
}
