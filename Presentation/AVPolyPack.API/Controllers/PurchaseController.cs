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
    public class PurchaseController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IPurchaseRepository _purchaseRepository;
        private IFileManager _fileManager;

        public PurchaseController(IPurchaseRepository purchaseRepository, IFileManager fileManager)
        {
            _purchaseRepository = purchaseRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Purchase 

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SavePurchase(Purchase_Request parameters)
        {
            int result = await _purchaseRepository.SavePurchase(parameters);

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

                foreach (var item in parameters.purchaseDetailsList)
                {
                    item.PurchaseId = result;

                    int resultPurchaseDetails = await _purchaseRepository.SavePurchaseDetails(item);
                }
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetPurchaseList(Purchase_Search parameters)
        {
            IEnumerable<PurchaseList_Response> lstPurchases = await _purchaseRepository.GetPurchaseList(parameters);
            _response.Data = lstPurchases.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetPurchaseById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _purchaseRepository.GetPurchaseById(Id);
                if (vResultObj != null)
                {
                    var vPurchaseDetails_Search = new PurchaseDetails_Search();
                    vPurchaseDetails_Search.PurchaseId = vResultObj.Id;

                    var vList = await _purchaseRepository.GetPurchaseDetailsList(vPurchaseDetails_Search);

                    vResultObj.purchaseDetailsList = vList.ToList();
                }
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> DeletePurchaseDetails(int Id)
        {
            int result = await _purchaseRepository.DeletePurchaseDetails(Id);

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
                _response.Message = "Record deleted successfully";
            }

            _response.Id = result;
            return _response;
        }
        #endregion
    }
}
