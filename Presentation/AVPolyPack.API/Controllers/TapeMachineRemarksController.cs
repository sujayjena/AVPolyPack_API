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
    public class TapeMachineRemarksController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly ITapeMachineRemarksRepository _tapeMachineRemarksRepository;
        private IFileManager _fileManager;

        public TapeMachineRemarksController(ITapeMachineRemarksRepository tapeMachineRemarksRepository, IFileManager fileManager)
        {
            _tapeMachineRemarksRepository = tapeMachineRemarksRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveTapeMachineRemarks(TapeMachineRemarks_Request parameters)
        {
            int result = await _tapeMachineRemarksRepository.SaveTapeMachineRemarks(parameters);

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
            IEnumerable<TapeMachineRemarks_Response> lstRoles = await _tapeMachineRemarksRepository.GetTapeMachineRemarksList(parameters);
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
                var vResultObj = await _tapeMachineRemarksRepository.GetTapeMachineRemarksById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
