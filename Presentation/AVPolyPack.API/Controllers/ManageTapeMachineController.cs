using AVPolyPack.API.Controllers;
using AVPolyPack.Application.Enums;
using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using AVPolyPack.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVPolyPack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageTapeMachineController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IManageTapeMachineRepository _manageTapeMachineRepository;
        private IFileManager _fileManager;

        public ManageTapeMachineController(IManageTapeMachineRepository manageTapeMachineRepository, IFileManager fileManager)
        {
            _manageTapeMachineRepository = manageTapeMachineRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Machine Assign

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMachineAssign(List<MachineAssign_Request> parameters)
        {
            int result = 0;
            foreach (var item in parameters)
            {
                result = await _manageTapeMachineRepository.SaveMachineAssign(item);
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
        public async Task<ResponseModel> GetMachineAssignList(MachineAssign_Search parameters)
        {
            IEnumerable<MachineAssign_Response> lstRoles = await _manageTapeMachineRepository.GetMachineAssignList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        #endregion

        #region Machine Start Stop

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMachineStartStop(MachineStartStop_Request parameters)
        {

            int result = await _manageTapeMachineRepository.SaveMachineStartStop(parameters);

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
                if(parameters.Id == 0)
                {
                    _response.Message = "Record details saved successfully";
                }
                else
                {
                    _response.Message = "Record Updated successfully";
                }
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMachineStartStopList(MachineStartStop_Search parameters)
        {
            IEnumerable<MachineStartStop_Response> lstRoles = await _manageTapeMachineRepository.GetMachineStartStopList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
        #endregion

        #region Machine Remarks
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveTapeMachineRemarks(TapeMachineRemarks_Request parameters)
        {
            int result = await _manageTapeMachineRepository.SaveTapeMachineRemarks(parameters);

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
                if (parameters.Id == 0)
                {
                    _response.Message = "Record Submitted successfully";
                }
                else
                {
                    _response.Message = "Record Updated successfully";
                }
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetTapeMachineRemarksList(TapeMachineRemarks_Search parameters)
        {
            IEnumerable<TapeMachineRemarks_Response> lstRoles = await _manageTapeMachineRepository.GetTapeMachineRemarksList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetTapeMachineRemarksById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageTapeMachineRepository.GetTapeMachineRemarksById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
        #endregion

        #region Employee List for Assign Machine

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmployeeListForAssignMachine(EmployeeListForAssignMachine_Search parameters)
        {
            IEnumerable<EmployeeListForAssignMachine_Response> lstRoles = await _manageTapeMachineRepository.GetEmployeeListForAssignMachine(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        #endregion
    }
}
