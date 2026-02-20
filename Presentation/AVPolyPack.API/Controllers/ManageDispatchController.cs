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
    public class ManageDispatchController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IManageDispatchRepository _manageDispatchRepository;
        private IFileManager _fileManager;

        public ManageDispatchController(IManageDispatchRepository manageDispatchRepository, IFileManager fileManager)
        {
            _manageDispatchRepository = manageDispatchRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveDispatch(Dispatch_Request parameters)
        {
            int result = await _manageDispatchRepository.SaveDispatch(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == -3)
            {
                _response.Message = "Email already exists";
            }
            else if (result == -4)
            {
                _response.Message = "Mobile # already exists";
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
        public async Task<ResponseModel> GetDispatchList(Dispatch_Search parameters)
        {
            IEnumerable<Dispatch_Response> lstDispatchs = await _manageDispatchRepository.GetDispatchList(parameters);
            _response.Data = lstDispatchs.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetDispatchById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageDispatchRepository.GetDispatchById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
