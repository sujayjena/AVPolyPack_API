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
    public class ManageInventoryController : CustomBaseController
    {
        private ResponseModel _response;
        private IFileManager _fileManager;
        private readonly IBarcodeRepository _barcodeRepository;
        private readonly IManageInventoryRepository _manageInventoryRepository;
        private readonly ILoomsRepository _loomsRepository;

        public ManageInventoryController(IFileManager fileManager, IManageInventoryRepository manageInventoryRepository, IBarcodeRepository barcodeRepository, ILoomsRepository loomsRepository)
        {
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
            _manageInventoryRepository = manageInventoryRepository;
            _barcodeRepository = barcodeRepository;
            _loomsRepository = loomsRepository;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveInventory(Inventory_Request parameters)
        {
            int result = await _manageInventoryRepository.SaveInventory(parameters);

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
        public async Task<ResponseModel> GetInventoryList(Inventory_Search parameters)
        {
            IEnumerable<Inventory_Response> lstRoles = await _manageInventoryRepository.GetInventoryList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetInventoryById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageInventoryRepository.GetInventoryById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #region Split Roll
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSplitList(Split_Search parameters)
        {
            IEnumerable<Split_Response> lstRoles = await _manageInventoryRepository.GetSplitList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSplitRoll(List<SplitRoll_Request> parameters)
        {
            int result = 0;

            foreach (var item in parameters)
            {
                var vSplitRoll_Request = new SplitRoll_Request()
                { 
                    Id = item.Id,
                    RollId = item.RollId,
                    SplitRollNo = item.SplitRollNo,
                    SplitRollLength = item.SplitRollLength,
                };
                result = await _manageInventoryRepository.SaveSplitRoll(vSplitRoll_Request);

                #region Generate Barcode
                if (vSplitRoll_Request.Id == 0 && result > 0)
                {
                    var vRoll = await _loomsRepository.GetRollById(result);
                    if (vRoll != null)
                    {
                        var vGenerateBarcode = _barcodeRepository.GenerateBarcode(vRoll.RollNo, "Roll");
                        if (vGenerateBarcode.Barcode_Unique_Id != "")
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
                    }
                }
                #endregion
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
        public async Task<ResponseModel> GetSplitRollList(SplitRoll_Search parameters)
        {
            IEnumerable<SplitRoll_Response> lstRoles = await _manageInventoryRepository.GetSplitRollList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
        #endregion
    }
}
