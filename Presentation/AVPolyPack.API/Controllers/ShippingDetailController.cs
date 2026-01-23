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
    public class ShippingDetailController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IShippingAddressRepository _shippingAddressRepository;

        public ShippingDetailController(IShippingAddressRepository shippingAddressRepository)
        {
            _shippingAddressRepository = shippingAddressRepository;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveShippingAddress(ShippingAddress_Request parameters)
        {
            int result = await _shippingAddressRepository.SaveShippingAddress(parameters);

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
                _response.Message = "Record details saved sucessfully";
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetShippingAddressList(ShippingAddress_Search parameters)
        {
            var objList = await _shippingAddressRepository.GetShippingAddressList(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetShippingAddressById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _shippingAddressRepository.GetShippingAddressById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
