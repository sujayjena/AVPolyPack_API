using AVPolyPack.API.Controllers;
using AVPolyPack.Application.Enums;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using AVPolyPack.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace AVPolyPack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageReportController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IManageReportRepository _manageReportRepository;

        public ManageReportController(IManageReportRepository manageReportRepository)
        {
            _manageReportRepository = manageReportRepository;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Printing Report
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetPrintingReport(PrintingReport_Search parameters)
        {
            var objList = await _manageReportRepository.GetPrintingReport(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
        #endregion

        #region lamination report
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLaminationReport(LaminationReport_Search parameters)
        {
            var objList = await _manageReportRepository.GetLaminationReport(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
        #endregion

        #region Strength Report
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetStrengthReport(StrengthReport_Search parameters)
        {
            var objList = await _manageReportRepository.GetStrengthReport(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
        #endregion

        #region Employee Attendance Report
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmployeeAttendanceReport(EmployeeAttendanceReport_Search parameters)
        {
            var objList = await _manageReportRepository.GetEmployeeAttendanceReport(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ExportEmployeeAttendanceReportData(EmployeeAttendanceReport_Search parameters)
        {
            _response.IsSuccess = false;
            byte[] result;
            int recordIndex;
            ExcelWorksheet WorkSheet1;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var request = new BaseSearchEntity();

            IEnumerable<EmployeeAttendanceReport_Response> lstObj = await _manageReportRepository.GetEmployeeAttendanceReport(parameters);

            using (MemoryStream msExportDataFile = new MemoryStream())
            {
                using (ExcelPackage excelExportData = new ExcelPackage())
                {
                    WorkSheet1 = excelExportData.Workbook.Worksheets.Add("EmployeeAttendanceReport");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "Employye Id";
                    WorkSheet1.Cells[1, 2].Value = "Employye Name";
                    WorkSheet1.Cells[1, 3].Value = "Department";
                    WorkSheet1.Cells[1, 4].Value = "Shift";
                    WorkSheet1.Cells[1, 5].Value = "CheckIn";
                    WorkSheet1.Cells[1, 6].Value = "CheckOut";
                    WorkSheet1.Cells[1, 7].Value = "Hours";
                    WorkSheet1.Cells[1, 8].Value = "Effort name";

                    WorkSheet1.Cells[1, 9].Value = "CreatedDate";
                    WorkSheet1.Cells[1, 10].Value = "CreatedBy";


                    recordIndex = 2;

                    foreach (var items in lstObj)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Value = items.UserCode;
                        WorkSheet1.Cells[recordIndex, 2].Value = items.EmployeeName;
                        WorkSheet1.Cells[recordIndex, 3].Value = items.DepartmentName;
                        WorkSheet1.Cells[recordIndex, 4].Value = items.ShiftType == 1 ? "Shift A" : "";
                        WorkSheet1.Cells[recordIndex, 5].Value = Convert.ToDateTime(items.CheckedInDate).ToString("hh:mm tt");
                        WorkSheet1.Cells[recordIndex, 6].Value = Convert.ToDateTime(items.CheckedOutDate).ToString("hh:mm tt");
                        WorkSheet1.Cells[recordIndex, 7].Value = items.TotalHours;
                        WorkSheet1.Cells[recordIndex, 8].Value = items.EffortName;

                        WorkSheet1.Cells[recordIndex, 9].Value = Convert.ToDateTime(items.CreatedDate).ToString("dd/MM/yyyy");
                        WorkSheet1.Cells[recordIndex, 10].Value = items.CreatorName;

                        recordIndex += 1;
                    }

                    WorkSheet1.Columns.AutoFit();

                    excelExportData.SaveAs(msExportDataFile);
                    msExportDataFile.Position = 0;
                    result = msExportDataFile.ToArray();
                }
            }

            if (result != null)
            {
                _response.Data = result;
                _response.IsSuccess = true;
                _response.Message = "Exported successfully";
            }

            return _response;
        }
        #endregion

        #region Loom Report
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLoomReport(LoomReport_Search parameters)
        {
            var objList = await _manageReportRepository.GetLoomReport(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
        #endregion
    }
}
