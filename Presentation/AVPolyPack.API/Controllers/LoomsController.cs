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
        private readonly IBarcodeRepository _barcodeRepository;

        public LoomsController(ILoomsRepository loomsRepository, IBarcodeRepository barcodeRepository)
        {
            _loomsRepository = loomsRepository;
            _barcodeRepository = barcodeRepository;

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
            IEnumerable<OrderItemNoSelectListResponse> lstResponse = await _loomsRepository.GetOrderItemNoForSelectList();
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
            else if (result == -3)
            {
                _response.Message = "Order item running in other loom";
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

        #region Roll
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveRoll(Roll_Request parameters)
        {
            int result = await _loomsRepository.SaveRoll(parameters);

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

                #region Generate Barcode
                if (parameters.Id == 0)
                {
                    var vVisitor = await _loomsRepository.GetRollById(result);
                    if (vVisitor != null)
                    {
                        var vGenerateBarcode = _barcodeRepository.GenerateBarcode(vVisitor.RollNo, "Roll");
                        if (!string.IsNullOrEmpty(vGenerateBarcode.Barcode_Unique_Id))
                        {
                            var vBarcode_Request = new Barcode_Request()
                            {
                                Id = 0,
                                BarcodeNo = vVisitor.RollNo,
                                BarcodeType = "Roll",
                                Barcode_Unique_Id = vGenerateBarcode.Barcode_Unique_Id,
                                BarcodeOriginalFileName = vGenerateBarcode.BarcodeOriginalFileName,
                                BarcodeFileName = vGenerateBarcode.BarcodeFileName,
                                RefId = vVisitor.Id
                            };
                            var resultBarcode = _barcodeRepository.SaveBarcode(vBarcode_Request);
                        }
                    }
                }
                #endregion
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetRollList(Roll_Search parameters)
        {
            IEnumerable<Roll_Response> lstRoles = await _loomsRepository.GetRollList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetRollById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _loomsRepository.GetRollById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetBarcodeById(string BarcodeNo)
        {
            if (BarcodeNo == "")
            {
                _response.Message = "Barcode No. is required";
            }
            else
            {
                var vResultObj = await _barcodeRepository.GetBarcodeById(BarcodeNo);
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> RollCodeReset()
        {
            int result = await _loomsRepository.RollCodeReset();

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

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetTrackingStatusById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _loomsRepository.GetTrackingStatusById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> PickupRoll(List<PickupRoll_Request> parameters)
        {
            int result = 0;
            foreach(var item in parameters)
            {
                result = await _loomsRepository.PickupRoll(item);
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
                _response.Message = "Record Submitted successfully";
            }

            _response.Id = result;
            return _response;

        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOutwardingStockList(OutwardingStock_Search parameters)
        {
            IEnumerable<OutwardingStock_Response> lstRoles = await _loomsRepository.GetOutwardingStockList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> BarcodeRegenerate(BarcodeRegenerate_Request parameters)
        {
            var vRoll = await _loomsRepository.GetRollById(Convert.ToInt32(parameters.RefId));
            if (vRoll != null)
            {
                var vGenerateBarcode = _barcodeRepository.GenerateBarcode(vRoll.RollNo, parameters.RefType);
                if (!string.IsNullOrEmpty(vGenerateBarcode.Barcode_Unique_Id))
                {
                    var vBarcode_Request = new Barcode_Request()
                    {
                        Id = 0,
                        BarcodeNo = vRoll.RollNo,
                        BarcodeType = "Roll",
                        Barcode_Unique_Id = vGenerateBarcode.Barcode_Unique_Id,
                        BarcodeOriginalFileName = vGenerateBarcode.BarcodeOriginalFileName,
                        BarcodeFileName = vGenerateBarcode.BarcodeFileName,
                        RefId = vRoll.Id
                    };
                    var resultBarcode = _barcodeRepository.SaveBarcode(vBarcode_Request);
                }

                if (string.IsNullOrEmpty(vGenerateBarcode.BarcodeFileName))
                {
                    _response.IsSuccess = false;
                    _response.Message = "Barcode is not generated";

                    return _response;
                }
            }
            else
            {
                _response.IsSuccess = false;
                _response.Message = "Roll is not exists.";

                return _response;
            }

            _response.IsSuccess = true;
            _response.Message = "Barcode Regenerate successfully";
            return _response;
        }
        #endregion

        #region Loom Release
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLoomRelease(LoomRelease_Request parameters)
        {
            int result = await _loomsRepository.SaveLoomRelease(parameters);

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
        #endregion

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLoomListByOrderItemId(LoomListByOrderItemId_Search parameters)
        {
            var objList = await _loomsRepository.GetLoomListByOrderItemId(parameters);
            _response.Data = objList.ToList();
            return _response;
        }
    }
}
