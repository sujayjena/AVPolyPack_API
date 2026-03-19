using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageReportRepository
    {
        Task<IEnumerable<PrintingReport_Response>> GetPrintingReport(PrintingReport_Search parameters);
        Task<IEnumerable<LaminationReport_Response>> GetLaminationReport(LaminationReport_Search parameters);
        Task<IEnumerable<StrengthReport_Response>> GetStrengthReport(StrengthReport_Search parameters);
        Task<IEnumerable<EmployeeAttendanceReport_Response>> GetEmployeeAttendanceReport(EmployeeAttendanceReport_Search parameters);
        Task<IEnumerable<LoomReport_Response>> GetLoomReport(LoomReport_Search parameters);
    }
}
