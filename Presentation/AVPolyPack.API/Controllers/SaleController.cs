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
    public class SaleController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly ISaleRepository _saleRepository;
        private IFileManager _fileManager;

        public SaleController(ISaleRepository purchaseRepository, IFileManager fileManager)
        {
            _saleRepository = purchaseRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Sale 

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSale(Sale_Request parameters)
        {
            int result = await _saleRepository.SaveSale(parameters);

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
                    item.SaleId = result;

                    int resultSaleDetails = await _saleRepository.SaveSaleDetails(item);
                }
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSaleList(Sale_Search parameters)
        {
            IEnumerable<SaleList_Response> lstSales = await _saleRepository.GetSaleList(parameters);
            _response.Data = lstSales.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSaleById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _saleRepository.GetSaleById(Id);
                if (vResultObj != null)
                {
                    var vSaleDetails_Search = new SaleDetails_Search();
                    vSaleDetails_Search.SaleId = vResultObj.Id;

                    var vList = await _saleRepository.GetSaleDetailsList(vSaleDetails_Search);

                    vResultObj.saleDetailsList = vList.ToList();
                }
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> DeleteSaleDetails(int Id)
        {
            int result = await _saleRepository.DeleteSaleDetails(Id);

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

