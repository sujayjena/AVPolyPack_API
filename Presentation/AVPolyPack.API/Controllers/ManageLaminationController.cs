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
    public class ManageLaminationController : CustomBaseController
    {
        private ResponseModel _response;
        private IFileManager _fileManager;

        private readonly IManageLaminationRepository _manageLaminationRepository;

        public ManageLaminationController(IFileManager fileManager, IManageLaminationRepository manageLaminationRepository)
        {
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
            _manageLaminationRepository = manageLaminationRepository;
        }

        #region Lamination
        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLamination(Lamination_Request parameters)
        {
            int result = await _manageLaminationRepository.SaveLamination(parameters);

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
        public async Task<ResponseModel> GetLaminationList(Lamination_Search parameters)
        {
            IEnumerable<Lamination_Response> lstRoles = await _manageLaminationRepository.GetLaminationList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLaminationById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageLaminationRepository.GetLaminationById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Consumption

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveConsumption_Lamination(List<Consumption_Lamination_Request> parameters)
        {
            int result = 0;
            foreach (var item in parameters)
            {
                result = await _manageLaminationRepository.SaveConsumption_Lamination(item);
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
        public async Task<ResponseModel> GetConsumption_LaminationList(Consumption_Lamination_Search parameters)
        {
            IEnumerable<Consumption_Lamination_Response> lstRoles = await _manageLaminationRepository.GetConsumption_LaminationList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetConsumption_LaminationById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageLaminationRepository.GetConsumption_LaminationById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
        #endregion

        #region Waste Material

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveWasteMaterial_Lamination(List<WasteMaterial_Lamination_Request> parameters)
        {
            int result = 0;
            foreach (var item in parameters)
            {
                result = await _manageLaminationRepository.SaveWasteMaterial_Lamination(item);
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
        public async Task<ResponseModel> GetWasteMaterial_LaminationList(WasteMaterial_Lamination_Search parameters)
        {
            IEnumerable<WasteMaterial_Lamination_Response> lstRoles = await _manageLaminationRepository.GetWasteMaterial_LaminationList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetWasteMaterial_LaminationById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageLaminationRepository.GetWasteMaterial_LaminationById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
        #endregion
    }
}
