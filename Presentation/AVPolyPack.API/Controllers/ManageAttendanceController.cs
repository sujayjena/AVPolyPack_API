using AVPolyPack.API.Controllers;
using AVPolyPack.Application.Enums;
using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVPolyPack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAttendanceController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IManageAttendanceRepository _manageAttendanceRepository;
        private IFileManager _fileManager;

        public ManageAttendanceController(IManageAttendanceRepository manageAttendanceRepository, IFileManager fileManager)
        {
            _manageAttendanceRepository = manageAttendanceRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveAttendance(List<Attendance_Request> parameters)
        {
            int result = 0;
            foreach(var item in parameters)
            {
                result = await _manageAttendanceRepository.SaveAttendance(item);
            }

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetAttendanceList(Attendance_Search parameters)
        {
            IEnumerable<Attendance_Response> lstRoles = await _manageAttendanceRepository.GetAttendanceList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
    }
}
