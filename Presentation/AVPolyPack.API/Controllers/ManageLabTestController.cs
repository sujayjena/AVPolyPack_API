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
    public class ManageLabTestController : CustomBaseController
    {
        private ResponseModel _response;
        private IFileManager _fileManager;

        private readonly IManageLabTestRepository _manageLabTestRepository;

        public ManageLabTestController(IFileManager fileManager, IManageLabTestRepository manageLabTestRepository)
        {
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
            _manageLabTestRepository = manageLabTestRepository;
        }

        #region Mesh Entry
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMeshEntry(MeshEntry_Request parameters)
        {
            int result = await _manageLabTestRepository.SaveMeshEntry(parameters);

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
        public async Task<ResponseModel> GetMeshEntryList(MeshEntry_Search parameters)
        {
            IEnumerable<MeshEntry_Response> lstRoles = await _manageLabTestRepository.GetMeshEntryList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMeshEntryById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageLabTestRepository.GetMeshEntryById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region AvgGSM Entry
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveAvgGSMEntry(AvgGSMEntry_Request parameters)
        {
            int result = await _manageLabTestRepository.SaveAvgGSMEntry(parameters);

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
        public async Task<ResponseModel> GetAvgGSMEntryList(AvgGSMEntry_Search parameters)
        {
            IEnumerable<AvgGSMEntry_Response> lstRoles = await _manageLabTestRepository.GetAvgGSMEntryList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetAvgGSMEntryById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageLabTestRepository.GetAvgGSMEntryById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Strength Entry
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveStrengthEntry(StrengthEntry_Request parameters)
        {
            int result = await _manageLabTestRepository.SaveStrengthEntry(parameters);

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
        public async Task<ResponseModel> GetStrengthEntryList(StrengthEntry_Search parameters)
        {
            IEnumerable<StrengthEntry_Response> lstRoles = await _manageLabTestRepository.GetStrengthEntryList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetStrengthEntryById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageLabTestRepository.GetStrengthEntryById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion
    }
}
