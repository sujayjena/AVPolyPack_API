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
    public class LoomsController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly ILoomsRepository _loomsRepository;

        public LoomsController(ILoomsRepository loomsRepository)
        {
            _loomsRepository = loomsRepository;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLooms(Looms_Request parameters)
        {
            int result = await _loomsRepository.SaveLooms(parameters);

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
        public async Task<ResponseModel> GetLoomsList(Looms_Search parameters)
        {
            var objList = await _loomsRepository.GetLoomsList(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLoomsById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _loomsRepository.GetLoomsById(Id);

                _response.Data = vResultObj;
            }
            return _response;
        }

        #region Loom Assign

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLoomAssign(List<LoomAssign_Request> parameters)
        {
            int result = 0;
            foreach (var items in parameters)
            {
                result = await _loomsRepository.SaveLoomAssign(items);
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
                if (parameters.ToList().FirstOrDefault().Id == 0)
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
        public async Task<ResponseModel> GetLoomAssignList(LoomAssign_Search parameters)
        {
            var objList = await _loomsRepository.GetLoomAssignList(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLoomListForAssignOperator(LoomListForAssignOperator_Search parameters)
        {
            var objList = await _loomsRepository.GetLoomListForAssignOperator(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOperatorNameForSelectList(OperatorNameSelectList_Search parameters)
        {
            IEnumerable<OperatorNameSelectList_Response> lstResponse = await _loomsRepository.GetOperatorNameForSelectList(parameters);
            _response.Data = lstResponse.ToList();
            return _response;
        }
        #endregion

        #region Order Item Assign

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOrderItemNoForSelectList()
        {
            IEnumerable<SelectListResponse> lstResponse = await _loomsRepository.GetOrderItemNoForSelectList();
            _response.Data = lstResponse.ToList();
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveOrderItemAssign(OrderItemAssign_Request parameters)
        {
            int result = await _loomsRepository.SaveOrderItemAssign(parameters);

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
        public async Task<ResponseModel> GetOrderItemAssignList(OrderItemAssign_Search parameters)
        {
            var objList = await _loomsRepository.GetOrderItemAssignList(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> AssignOrderItemCompleted(AssignOrderItemCompleted_Request parameters)
        {
            int result = await _loomsRepository.AssignOrderItemCompleted(parameters);

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
                _response.Message = "Record Submitted successfully";
            }

            _response.Id = result;
            return _response;

        }

        #endregion

        #region Size Reading
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSizeReading(SizeReading_Request parameters)
        {
            int result = await _loomsRepository.SaveSizeReading(parameters);

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
        public async Task<ResponseModel> GetSizeReadingList(SizeReading_Search parameters)
        {
            var objList = await _loomsRepository.GetSizeReadingList(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
        #endregion

        #region Loom Reading
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLoomReading(LoomReading_Request parameters)
        {
            int result = await _loomsRepository.SaveLoomReading(parameters);

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
        public async Task<ResponseModel> GetLoomReadingList(LoomReading_Search parameters)
        {
            var objList = await _loomsRepository.GetLoomReadingList(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
        #endregion

        #region Loom Remark

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLoomRemarks(LoomRemarks_Request parameters)
        {
            int result = await _loomsRepository.SaveLoomRemarks(parameters);

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
        public async Task<ResponseModel> GetLoomRemarksList(LoomRemarks_Search parameters)
        {
            IEnumerable<LoomRemarks_Response> lstRoles = await _loomsRepository.GetLoomRemarksList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLoomRemarksById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _loomsRepository.GetLoomRemarksById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
        #endregion
    }
}
