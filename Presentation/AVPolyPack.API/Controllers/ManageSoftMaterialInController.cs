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
    public class ManageSoftMaterialInController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IManageSoftMaterialInRepository _manageSoftMaterialInRepository;
        private IFileManager _fileManager;

        public ManageSoftMaterialInController(IManageSoftMaterialInRepository manageSoftMaterialInRepository, IFileManager fileManager)
        {
            _manageSoftMaterialInRepository = manageSoftMaterialInRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Soft Material In

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSoftMaterialIn(SoftMaterialIn_Request parameters)
        {
            int result = await _manageSoftMaterialInRepository.SaveSoftMaterialIn(parameters);

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

                foreach (var item in parameters.materialInList)
                {
                    item.SoftMaterialInId = result;

                    int resultOrderItem = await _manageSoftMaterialInRepository.SaveSoftMaterialInDetails(item);
                }
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSoftMaterialInList(SoftMaterialIn_Search parameters)
        {
            IEnumerable<SoftMaterialIn_Response> lstRoles = await _manageSoftMaterialInRepository.GetSoftMaterialInList(parameters);
            foreach(var item in lstRoles)
            {
                var vSoftMaterialInDetails_Search = new SoftMaterialInDetails_Search();
                vSoftMaterialInDetails_Search.SoftMaterialInId = item.Id;

                var vList = await _manageSoftMaterialInRepository.GetSoftMaterialInDetailsList(vSoftMaterialInDetails_Search);

                item.materialInList = vList.ToList();
            }
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSoftMaterialInById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageSoftMaterialInRepository.GetSoftMaterialInById(Id);
                if(vResultObj != null)
                {
                    var vSoftMaterialInDetails_Search = new SoftMaterialInDetails_Search();
                    vSoftMaterialInDetails_Search.SoftMaterialInId = vResultObj.Id;

                    var vList = await _manageSoftMaterialInRepository.GetSoftMaterialInDetailsList(vSoftMaterialInDetails_Search);

                    vResultObj.materialInList = vList.ToList();
                }
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ReceivedSoftMaterialIn(List<ReceivedSoftMaterialInList_Request> parameters)
        {
            int result = 0;
            foreach (var material in parameters)
            {
                result = await _manageSoftMaterialInRepository.ReceivedSoftMaterialIn(material);
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

        #endregion
    }
}
