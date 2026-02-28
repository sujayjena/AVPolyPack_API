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
    public class MaterialConsumptionController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IMaterialConsumptionRepository _materialConsumptionRepository;
        private IFileManager _fileManager;

        public MaterialConsumptionController(IMaterialConsumptionRepository materialConsumptionRepository, IFileManager fileManager)
        {
            _materialConsumptionRepository = materialConsumptionRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Consumption

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveConsumption(List<Consumption_Request> parameters)
        {
            int result = 0;
            foreach(var item in parameters)
            {
                result = await _materialConsumptionRepository.SaveConsumption(item);
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
                if (parameters.FirstOrDefault().Id == 0)
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
        public async Task<ResponseModel> GetConsumptionHeaderList(Consumption_Search parameters)
        {
            IEnumerable<ConsumptionHeader_Response> lstRoles = await _materialConsumptionRepository.GetConsumptionHeaderList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetConsumptionList(Consumption_Search parameters)
        {
            IEnumerable<Consumption_Response> lstRoles = await _materialConsumptionRepository.GetConsumptionList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetConsumptionById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _materialConsumptionRepository.GetConsumptionById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
        #endregion

        #region Waste Material

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveWasteMaterial(List<WasteMaterial_Request> parameters)
        {
            int result = 0;
            foreach (var item in parameters)
            {
                result = await _materialConsumptionRepository.SaveWasteMaterial(item);
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
                if (parameters.FirstOrDefault().Id == 0)
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
        public async Task<ResponseModel> GetWasteMaterialHeaderList(WasteMaterial_Search parameters)
        {
            IEnumerable<WasteMaterialHeader_Response> lstRoles = await _materialConsumptionRepository.GetWasteMaterialHeaderList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetWasteMaterialList(WasteMaterial_Search parameters)
        {
            IEnumerable<WasteMaterial_Response> lstRoles = await _materialConsumptionRepository.GetWasteMaterialList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetWasteMaterialById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _materialConsumptionRepository.GetWasteMaterialById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
        #endregion
    }
}
