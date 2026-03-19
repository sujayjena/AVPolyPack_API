using AVPolyPack.API.Controllers;
using AVPolyPack.Application.Enums;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ResponseModel> GetLaminationReport(LaminationReport_Search parameters)
        {
            var objList = await _manageReportRepository.GetLaminationReport(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

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
        public async Task<ResponseModel> GetEmployeeAttendanceReport(EmployeeAttendanceReport_Search parameters)
        {
            var objList = await _manageReportRepository.GetEmployeeAttendanceReport(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLoomReport(LoomReport_Search parameters)
        {
            var objList = await _manageReportRepository.GetLoomReport(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
    }
}
