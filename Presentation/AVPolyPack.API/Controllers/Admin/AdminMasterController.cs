using AVPolyPack.Application.Enums;
using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using AVPolyPack.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AVPolyPack.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMasterController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IAdminMasterRepository _adminMasterRepository;
        private IFileManager _fileManager;
        private readonly IConfigRefRepository _configRefRepository;

        public AdminMasterController(IAdminMasterRepository adminMasterRepository, IFileManager fileManager)
        {
            _adminMasterRepository = adminMasterRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Blood Group

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveBloodGroup(BloodGroup_Request parameters)
        {
            int result = await _adminMasterRepository.SaveBloodGroup(parameters);

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
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetBloodGroupList(BloodGroup_Search parameters)
        {
            IEnumerable<BloodGroup_Response> lstRoles = await _adminMasterRepository.GetBloodGroupList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetBloodGroupById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetBloodGroupById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Company Type

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveCompanyType(CompanyType_Request parameters)
        {
            int result = await _adminMasterRepository.SaveCompanyType(parameters);

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
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetCompanyTypeList(CompanyType_Search parameters)
        {
            IEnumerable<CompanyType_Response> lstRoles = await _adminMasterRepository.GetCompanyTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetCompanyTypeById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetCompanyTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Employee Level

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveEmployeeLevel(EmployeeLevel_Request parameters)
        {
            int result = await _adminMasterRepository.SaveEmployeeLevel(parameters);

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
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmployeeLevelList(EmployeeLevel_Search parameters)
        {
            IEnumerable<EmployeeLevel_Response> lstRoles = await _adminMasterRepository.GetEmployeeLevelList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmployeeLevelById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetEmployeeLevelById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Gender

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveGender(Gender_Request parameters)
        {
            int result = await _adminMasterRepository.SaveGender(parameters);

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
                if(parameters.Id == 0)
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
        public async Task<ResponseModel> GetGenderList(Gender_Search parameters)
        {
            IEnumerable<Gender_Response> lstRoles = await _adminMasterRepository.GetGenderList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetGenderById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetGenderById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Marital Status

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMaritalStatus(MaritalStatus_Request parameters)
        {
            int result = await _adminMasterRepository.SaveMaritalStatus(parameters);

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
        public async Task<ResponseModel> GetMaritalStatusList(MaritalStatus_Search parameters)
        {
            IEnumerable<MaritalStatus_Response> lstRoles = await _adminMasterRepository.GetMaritalStatusList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaritalStatusById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetMaritalStatusById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Loom

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLoom(Loom_Request parameters)
        {
            int result = await _adminMasterRepository.SaveLoom(parameters);

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
        public async Task<ResponseModel> GetLoomList(Loom_Search parameters)
        {
            IEnumerable<Loom_Response> lstRoles = await _adminMasterRepository.GetLoomList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLoomById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetLoomById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Size

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSize(Size_Request parameters)
        {
            int result = await _adminMasterRepository.SaveSize(parameters);

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
        public async Task<ResponseModel> GetSizeList(Size_Search parameters)
        {
            IEnumerable<Size_Response> lstRoles = await _adminMasterRepository.GetSizeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSizeById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetSizeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Gram

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveGram(Gram_Request parameters)
        {
            int result = await _adminMasterRepository.SaveGram(parameters);

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
        public async Task<ResponseModel> GetGramList(Gram_Search parameters)
        {
            IEnumerable<Gram_Response> lstRoles = await _adminMasterRepository.GetGramList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetGramById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetGramById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Mesh

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMesh(Mesh_Request parameters)
        {
            int result = await _adminMasterRepository.SaveMesh(parameters);

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
        public async Task<ResponseModel> GetMeshList(Mesh_Search parameters)
        {
            IEnumerable<Mesh_Response> lstRoles = await _adminMasterRepository.GetMeshList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMeshById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetMeshById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Specification

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSpecification(Specification_Request parameters)
        {
            int result = await _adminMasterRepository.SaveSpecification(parameters);

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
        public async Task<ResponseModel> GetSpecificationList(Specification_Search parameters)
        {
            IEnumerable<Specification_Response> lstRoles = await _adminMasterRepository.GetSpecificationList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSpecificationById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetSpecificationById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Type

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveType(Type_Request parameters)
        {
            int result = await _adminMasterRepository.SaveType(parameters);

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
        public async Task<ResponseModel> GetTypeList(Type_Search parameters)
        {
            IEnumerable<Type_Response> lstRoles = await _adminMasterRepository.GetTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetTypeById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region GSM

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveGSM(GSM_Request parameters)
        {
            int result = await _adminMasterRepository.SaveGSM(parameters);

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
        public async Task<ResponseModel> GetGSMList(GSM_Search parameters)
        {
            IEnumerable<GSM_Response> lstRoles = await _adminMasterRepository.GetGSMList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetGSMById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetGSMById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Strength

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveStrength(Strength_Request parameters)
        {
            int result = await _adminMasterRepository.SaveStrength(parameters);

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
        public async Task<ResponseModel> GetStrengthList(Strength_Search parameters)
        {
            IEnumerable<Strength_Response> lstRoles = await _adminMasterRepository.GetStrengthList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetStrengthById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetStrengthById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region LaminationType

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLaminationType(LaminationType_Request parameters)
        {
            int result = await _adminMasterRepository.SaveLaminationType(parameters);

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
        public async Task<ResponseModel> GetLaminationTypeList(LaminationType_Search parameters)
        {
            IEnumerable<LaminationType_Response> lstRoles = await _adminMasterRepository.GetLaminationTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLaminationTypeById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetLaminationTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Bank

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveBank(Bank_Request parameters)
        {
            int result = await _adminMasterRepository.SaveBank(parameters);

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
        public async Task<ResponseModel> GetBankList(Bank_Search parameters)
        {
            IEnumerable<Bank_Response> lstRoles = await _adminMasterRepository.GetBankList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetBankById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetBankById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Product

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveProduct(Product_Request parameters)
        {
            // Image Upload
            if (parameters! != null && !string.IsNullOrWhiteSpace(parameters.Image_Base64))
            {
                var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(parameters.Image_Base64, "\\Uploads\\Product\\", parameters.ImageOriginalFileName);

                if (!string.IsNullOrWhiteSpace(vUploadFile))
                {
                    parameters.ImageFileName = vUploadFile;
                }
            }

            int result = await _adminMasterRepository.SaveProduct(parameters);

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
        public async Task<ResponseModel> GetProductList(Product_Search parameters)
        {
            IEnumerable<Product_Response> lstRoles = await _adminMasterRepository.GetProductList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetProductById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetProductById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Cutting1

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveCutting1(Cutting1_Request parameters)
        {
            int result = await _adminMasterRepository.SaveCutting1(parameters);

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
        public async Task<ResponseModel> GetCutting1List(Cutting1_Search parameters)
        {
            IEnumerable<Cutting1_Response> lstRoles = await _adminMasterRepository.GetCutting1List(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetCutting1ById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetCutting1ById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Cutting2

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveCutting2(Cutting2_Request parameters)
        {
            int result = await _adminMasterRepository.SaveCutting2(parameters);

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
        public async Task<ResponseModel> GetCutting2List(Cutting2_Search parameters)
        {
            IEnumerable<Cutting2_Response> lstRoles = await _adminMasterRepository.GetCutting2List(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetCutting2ById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetCutting2ById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Liner

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLiner(Liner_Request parameters)
        {
            int result = await _adminMasterRepository.SaveLiner(parameters);

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
        public async Task<ResponseModel> GetLinerList(Liner_Search parameters)
        {
            IEnumerable<Liner_Response> lstRoles = await _adminMasterRepository.GetLinerList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLinerById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetLinerById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Guzzet

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveGuzzet(Guzzet_Request parameters)
        {
            int result = await _adminMasterRepository.SaveGuzzet(parameters);

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
        public async Task<ResponseModel> GetGuzzetList(Guzzet_Search parameters)
        {
            IEnumerable<Guzzet_Response> lstRoles = await _adminMasterRepository.GetGuzzetList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetGuzzetById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetGuzzetById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Bottom

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveBottom(Bottom_Request parameters)
        {
            int result = await _adminMasterRepository.SaveBottom(parameters);

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
        public async Task<ResponseModel> GetBottomList(Bottom_Search parameters)
        {
            IEnumerable<Bottom_Response> lstRoles = await _adminMasterRepository.GetBottomList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetBottomById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetBottomById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Stich

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveStich(Stich_Request parameters)
        {
            int result = await _adminMasterRepository.SaveStich(parameters);

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
        public async Task<ResponseModel> GetStichList(Stich_Search parameters)
        {
            IEnumerable<Stich_Response> lstRoles = await _adminMasterRepository.GetStichList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetStichById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetStichById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Color

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveColor(Color_Request parameters)
        {
            int result = await _adminMasterRepository.SaveColor(parameters);

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
        public async Task<ResponseModel> GetColorList(Color_Search parameters)
        {
            IEnumerable<Color_Response> lstRoles = await _adminMasterRepository.GetColorList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetColorById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetColorById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region ItemNumber

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveItemNumber(ItemNumber_Request parameters)
        {
            int result = await _adminMasterRepository.SaveItemNumber(parameters);

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
        public async Task<ResponseModel> GetItemNumberList(ItemNumber_Search parameters)
        {
            IEnumerable<ItemNumber_Response> lstRoles = await _adminMasterRepository.GetItemNumberList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetItemNumberById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetItemNumberById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion
    }
}
