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

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ExportPrintingReportData(PrintingReport_Search parameters)
        {
            _response.IsSuccess = false;
            byte[] result;
            int recordIndex;
            ExcelWorksheet WorkSheet1;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var request = new BaseSearchEntity();

            IEnumerable<PrintingReport_Response> lstObj = await _manageReportRepository.GetPrintingReport(parameters);

            using (MemoryStream msExportDataFile = new MemoryStream())
            {
                using (ExcelPackage excelExportData = new ExcelPackage())
                {
                    WorkSheet1 = excelExportData.Workbook.Worksheets.Add("PrintingReport");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "Operator Name";
                    WorkSheet1.Cells[1, 2].Value = "Loom Number";
                    WorkSheet1.Cells[1, 3].Value = "Roll Number";
                    WorkSheet1.Cells[1, 4].Value = "Size";
                    WorkSheet1.Cells[1, 5].Value = "Meter";
                    WorkSheet1.Cells[1, 6].Value = "Gross Weight";
                    WorkSheet1.Cells[1, 7].Value = "Net Weight";
                    WorkSheet1.Cells[1, 8].Value = "Average";
                    WorkSheet1.Cells[1, 9].Value = "Shift Time";
                    WorkSheet1.Cells[1, 10].Value = "Printing Machine";
                    WorkSheet1.Cells[1, 11].Value = "Printing Name";
                    WorkSheet1.Cells[1, 12].Value = "Printing Size";

                    WorkSheet1.Cells[1, 13].Value = "CreatedDate";
                    WorkSheet1.Cells[1, 14].Value = "CreatedBy";

                    recordIndex = 2;

                    foreach (var items in lstObj)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Value = items.OperatorName;
                        WorkSheet1.Cells[recordIndex, 2].Value = items.LoomNumber;
                        WorkSheet1.Cells[recordIndex, 3].Value = items.RollCode;
                        WorkSheet1.Cells[recordIndex, 4].Value = items.Size;
                        WorkSheet1.Cells[recordIndex, 5].Value = items.TotalMeter;
                        WorkSheet1.Cells[recordIndex, 6].Value = items.GrossWeight;
                        WorkSheet1.Cells[recordIndex, 7].Value = items.NetWeight;
                        WorkSheet1.Cells[recordIndex, 8].Value = items.AvgDiff;
                        WorkSheet1.Cells[recordIndex, 9].Value = items.ShiftType == 1 ? "Shift A" : "";
                        WorkSheet1.Cells[recordIndex, 10].Value = items.PrintingMachineName;
                        WorkSheet1.Cells[recordIndex, 11].Value = items.PrintingName;
                        WorkSheet1.Cells[recordIndex, 12].Value = items.PrintingSize;

                        WorkSheet1.Cells[recordIndex, 13].Value = Convert.ToDateTime(items.CreatedDate).ToString("dd/MM/yyyy");
                        WorkSheet1.Cells[recordIndex, 14].Value = items.CreatorName;

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

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ExportLaminationReportData(LaminationReport_Search parameters)
        {
            _response.IsSuccess = false;
            byte[] result;
            int recordIndex;
            ExcelWorksheet WorkSheet1;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var request = new BaseSearchEntity();

            IEnumerable<LaminationReport_Response> lstObj = await _manageReportRepository.GetLaminationReport(parameters);

            using (MemoryStream msExportDataFile = new MemoryStream())
            {
                using (ExcelPackage excelExportData = new ExcelPackage())
                {
                    WorkSheet1 = excelExportData.Workbook.Worksheets.Add("LaminationReport");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "Roll #";
                    WorkSheet1.Cells[1, 2].Value = "Size";
                    WorkSheet1.Cells[1, 3].Value = "Meter";
                    WorkSheet1.Cells[1, 4].Value = "Gross Weight";
                    WorkSheet1.Cells[1, 5].Value = "C.W";
                    WorkSheet1.Cells[1, 6].Value = "Net Weight";
                    WorkSheet1.Cells[1, 7].Value = "Average";                   

                    WorkSheet1.Cells[1, 8].Value = "CreatedDate";
                    WorkSheet1.Cells[1, 9].Value = "CreatedBy";

                    recordIndex = 2;

                    foreach (var items in lstObj)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Value = items.RollCode;
                        WorkSheet1.Cells[recordIndex, 2].Value = items.Size;
                        WorkSheet1.Cells[recordIndex, 3].Value = items.Meter;
                        WorkSheet1.Cells[recordIndex, 4].Value = items.GrossWeight;
                        WorkSheet1.Cells[recordIndex, 5].Value = items.CurrentWeight;
                        WorkSheet1.Cells[recordIndex, 6].Value = items.NetWeight;
                        WorkSheet1.Cells[recordIndex, 7].Value = items.Average;

                        WorkSheet1.Cells[recordIndex, 8].Value = Convert.ToDateTime(items.CreatedDate).ToString("dd/MM/yyyy");
                        WorkSheet1.Cells[recordIndex, 9].Value = items.CreatorName;

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

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ExportStrengthReportData(StrengthReport_Search parameters)
        {
            _response.IsSuccess = false;
            byte[] result;
            int recordIndex;
            ExcelWorksheet WorkSheet1;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var request = new BaseSearchEntity();

            IEnumerable<StrengthReport_Response> lstObj = await _manageReportRepository.GetStrengthReport(parameters);

            using (MemoryStream msExportDataFile = new MemoryStream())
            {
                using (ExcelPackage excelExportData = new ExcelPackage())
                {
                    WorkSheet1 = excelExportData.Workbook.Worksheets.Add("StrengthReport");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "Specification";
                    WorkSheet1.Cells[1, 2].Value = "Loom Number";
                    WorkSheet1.Cells[1, 3].Value = "Roll Number";
                    WorkSheet1.Cells[1, 4].Value = "Required Size";
                    WorkSheet1.Cells[1, 5].Value = "Actual Size";
                    WorkSheet1.Cells[1, 6].Value = "Required Average";
                    WorkSheet1.Cells[1, 7].Value = "Actual Average";
                    WorkSheet1.Cells[1, 8].Value = "Required Mesh";
                    WorkSheet1.Cells[1, 9].Value = "Actual Mesh";
                    WorkSheet1.Cells[1, 10].Value = "WARP";
                    WorkSheet1.Cells[1, 11].Value = "WARP ELO";
                    WorkSheet1.Cells[1, 12].Value = "WEFT";
                    WorkSheet1.Cells[1, 13].Value = "WEFT ELO";
                    WorkSheet1.Cells[1, 14].Value = "Time";
                    WorkSheet1.Cells[1, 15].Value = "Remarks";

                    WorkSheet1.Cells[1, 16].Value = "CreatedDate";
                    WorkSheet1.Cells[1, 17].Value = "CreatedBy";

                    recordIndex = 2;

                    foreach (var items in lstObj)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Value = items.SpecificationName;
                        WorkSheet1.Cells[recordIndex, 2].Value = items.LoomNumber;
                        WorkSheet1.Cells[recordIndex, 3].Value = items.RollCode;
                        WorkSheet1.Cells[recordIndex, 4].Value = items.RequiredSize;
                        WorkSheet1.Cells[recordIndex, 5].Value = items.ActualSize;
                        WorkSheet1.Cells[recordIndex, 6].Value = items.RequiredAvg;
                        WorkSheet1.Cells[recordIndex, 7].Value = items.ActualAvg;
                        WorkSheet1.Cells[recordIndex, 8].Value = items.RequiredMesh;
                        WorkSheet1.Cells[recordIndex, 9].Value = items.ActualMesh;
                        WorkSheet1.Cells[recordIndex, 10].Value = items.WARP;
                        WorkSheet1.Cells[recordIndex, 11].Value = items.WARP_ELO;
                        WorkSheet1.Cells[recordIndex, 12].Value = items.WEFT;
                        WorkSheet1.Cells[recordIndex, 13].Value = items.WEFT_ELO;
                        WorkSheet1.Cells[recordIndex, 14].Value = items.STime;
                        WorkSheet1.Cells[recordIndex, 15].Value = items.Remarks;

                        WorkSheet1.Cells[recordIndex, 16].Value = Convert.ToDateTime(items.CreatedDate).ToString("dd/MM/yyyy");
                        WorkSheet1.Cells[recordIndex, 17].Value = items.CreatorName;

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

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ExportLoomReportData(LoomReport_Search parameters)
        {
            _response.IsSuccess = false;
            byte[] result;
            int recordIndex;
            ExcelWorksheet WorkSheet1;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var request = new BaseSearchEntity();

            IEnumerable<LoomReport_Response> lstObj = await _manageReportRepository.GetLoomReport(parameters);

            using (MemoryStream msExportDataFile = new MemoryStream())
            {
                using (ExcelPackage excelExportData = new ExcelPackage())
                {
                    WorkSheet1 = excelExportData.Workbook.Worksheets.Add("LoomReport");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "Loom Number";
                    WorkSheet1.Cells[1, 2].Value = "Operator Name";
                    WorkSheet1.Cells[1, 3].Value = "Shift Type";
                    WorkSheet1.Cells[1, 4].Value = "Opening Reading";
                    WorkSheet1.Cells[1, 5].Value = "8 To 10-Reading";
                    WorkSheet1.Cells[1, 6].Value = "8 To 10-Production";
                    WorkSheet1.Cells[1, 7].Value = "10 To 12-Reading";
                    WorkSheet1.Cells[1, 8].Value = "10 To 12-Production";
                    WorkSheet1.Cells[1, 9].Value = "12 To 2-Reading";
                    WorkSheet1.Cells[1, 10].Value = "12 To 2-Production";
                    WorkSheet1.Cells[1, 11].Value = "2 To 4-Reading";
                    WorkSheet1.Cells[1, 12].Value = "2 To 4-Production";
                    WorkSheet1.Cells[1, 13].Value = "4 To 6-Reading";
                    WorkSheet1.Cells[1, 14].Value = "4 To 6-Production";

                    WorkSheet1.Cells[1, 15].Value = "CreatedDate";
                    WorkSheet1.Cells[1, 16].Value = "CreatedBy";

                    recordIndex = 2;

                    foreach (var items in lstObj)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Value = items.LoomNumber;
                        WorkSheet1.Cells[recordIndex, 2].Value = items.OperatorName;
                        WorkSheet1.Cells[recordIndex, 3].Value = items.ShiftType == 1 ? "Shift A" : items.ShiftType == 2 ? "Shift B" : "";
                        WorkSheet1.Cells[recordIndex, 4].Value = items.OpeningReading;
                        WorkSheet1.Cells[recordIndex, 5].Value = items.Reading_8_10;
                        WorkSheet1.Cells[recordIndex, 6].Value = items.Production_8_10;
                        WorkSheet1.Cells[recordIndex, 7].Value = items.Reading_10_12;
                        WorkSheet1.Cells[recordIndex, 8].Value = items.Production_10_12;
                        WorkSheet1.Cells[recordIndex, 9].Value = items.Reading_12_02;
                        WorkSheet1.Cells[recordIndex, 10].Value = items.Production_12_02;
                        WorkSheet1.Cells[recordIndex, 11].Value = items.Reading_02_04;
                        WorkSheet1.Cells[recordIndex, 12].Value = items.Production_02_04;
                        WorkSheet1.Cells[recordIndex, 13].Value = items.Reading_04_06;
                        WorkSheet1.Cells[recordIndex, 14].Value = items.Production_04_06;

                        WorkSheet1.Cells[recordIndex, 15].Value = Convert.ToDateTime(items.CreatedDate).ToString("dd/MM/yyyy");
                        WorkSheet1.Cells[recordIndex, 16].Value = items.CreatorName;

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
    }
}
