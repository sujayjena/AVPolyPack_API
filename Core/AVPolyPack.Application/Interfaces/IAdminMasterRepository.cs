using AVPolyPack.Application.Models;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IAdminMasterRepository
    {
        #region Blood Group

        Task<int> SaveBloodGroup(BloodGroup_Request parameters);
        Task<IEnumerable<BloodGroup_Response>> GetBloodGroupList(BloodGroup_Search parameters);
        Task<BloodGroup_Response?> GetBloodGroupById(long Id);

        #endregion

        #region Company Type

        Task<int> SaveCompanyType(CompanyType_Request parameters);
        Task<IEnumerable<CompanyType_Response>> GetCompanyTypeList(CompanyType_Search parameters);
        Task<CompanyType_Response?> GetCompanyTypeById(long Id);

        #endregion

        #region Employee Level

        Task<int> SaveEmployeeLevel(EmployeeLevel_Request parameters);
        Task<IEnumerable<EmployeeLevel_Response>> GetEmployeeLevelList(EmployeeLevel_Search parameters);
        Task<EmployeeLevel_Response?> GetEmployeeLevelById(long Id);

        #endregion

        #region Gender

        Task<int> SaveGender(Gender_Request parameters);
        Task<IEnumerable<Gender_Response>> GetGenderList(Gender_Search parameters);
        Task<Gender_Response?> GetGenderById(long Id);

        #endregion

        #region Marital Status

        Task<int> SaveMaritalStatus(MaritalStatus_Request parameters);
        Task<IEnumerable<MaritalStatus_Response>> GetMaritalStatusList(MaritalStatus_Search parameters);
        Task<MaritalStatus_Response?> GetMaritalStatusById(long Id);

        #endregion

        #region Loom

        Task<int> SaveLoom(Loom_Request parameters);
        Task<IEnumerable<Loom_Response>> GetLoomList(Loom_Search parameters);
        Task<Loom_Response?> GetLoomById(long Id);

        #endregion

        #region Size

        Task<int> SaveSize(Size_Request parameters);
        Task<IEnumerable<Size_Response>> GetSizeList(Size_Search parameters);
        Task<Size_Response?> GetSizeById(long Id);

        #endregion

        #region Gram

        Task<int> SaveGram(Gram_Request parameters);
        Task<IEnumerable<Gram_Response>> GetGramList(Gram_Search parameters);
        Task<Gram_Response?> GetGramById(long Id);

        #endregion

        #region Mesh

        Task<int> SaveMesh(Mesh_Request parameters);
        Task<IEnumerable<Mesh_Response>> GetMeshList(Mesh_Search parameters);
        Task<Mesh_Response?> GetMeshById(long Id);

        #endregion

        #region Specification

        Task<int> SaveSpecification(Specification_Request parameters);
        Task<IEnumerable<Specification_Response>> GetSpecificationList(Specification_Search parameters);
        Task<Specification_Response?> GetSpecificationById(long Id);

        #endregion

        #region Type

        Task<int> SaveType(Type_Request parameters);
        Task<IEnumerable<Type_Response>> GetTypeList(Type_Search parameters);
        Task<Type_Response?> GetTypeById(long Id);

        #endregion

        #region GSM

        Task<int> SaveGSM(GSM_Request parameters);
        Task<IEnumerable<GSM_Response>> GetGSMList(GSM_Search parameters);
        Task<GSM_Response?> GetGSMById(long Id);

        #endregion

        #region Strength

        Task<int> SaveStrength(Strength_Request parameters);
        Task<IEnumerable<Strength_Response>> GetStrengthList(Strength_Search parameters);
        Task<Strength_Response?> GetStrengthById(long Id);

        #endregion

        #region LaminationType

        Task<int> SaveLaminationType(LaminationType_Request parameters);
        Task<IEnumerable<LaminationType_Response>> GetLaminationTypeList(LaminationType_Search parameters);
        Task<LaminationType_Response?> GetLaminationTypeById(long Id);

        #endregion

        #region Bank

        Task<int> SaveBank(Bank_Request parameters);
        Task<IEnumerable<Bank_Response>> GetBankList(Bank_Search parameters);
        Task<Bank_Response?> GetBankById(long Id);

        #endregion

        #region Product

        Task<int> SaveProduct(Product_Request parameters);
        Task<IEnumerable<Product_Response>> GetProductList(Product_Search parameters);
        Task<Product_Response?> GetProductById(long Id);

        #endregion

        #region Cutting1

        Task<int> SaveCutting1(Cutting1_Request parameters);
        Task<IEnumerable<Cutting1_Response>> GetCutting1List(Cutting1_Search parameters);
        Task<Cutting1_Response?> GetCutting1ById(long Id);

        #endregion

        #region Cutting2

        Task<int> SaveCutting2(Cutting2_Request parameters);
        Task<IEnumerable<Cutting2_Response>> GetCutting2List(Cutting2_Search parameters);
        Task<Cutting2_Response?> GetCutting2ById(long Id);

        #endregion

        #region Liner

        Task<int> SaveLiner(Liner_Request parameters);
        Task<IEnumerable<Liner_Response>> GetLinerList(Liner_Search parameters);
        Task<Liner_Response?> GetLinerById(long Id);

        #endregion

        #region Guzzet

        Task<int> SaveGuzzet(Guzzet_Request parameters);
        Task<IEnumerable<Guzzet_Response>> GetGuzzetList(Guzzet_Search parameters);
        Task<Guzzet_Response?> GetGuzzetById(long Id);

        #endregion
    }
}
