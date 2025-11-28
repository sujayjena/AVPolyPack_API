using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Persistence.Repositories
{
    public class ManageSupplierRepository : GenericRepository, IManageSupplierRepository
    {
        private IConfiguration _configuration;

        public ManageSupplierRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveSupplier(Supplier_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@SupplierCode", parameters.SupplierCode);
            queryParameters.Add("@SupplierName", parameters.SupplierName);
            queryParameters.Add("@PartyName", parameters.PartyName);
            queryParameters.Add("@CustomerId", parameters.CustomerId);
            queryParameters.Add("@ReferenceId", parameters.ReferenceId);
            queryParameters.Add("@MobileNumber1", parameters.MobileNumber1);
            queryParameters.Add("@MobileNumber2", parameters.MobileNumber2);
            queryParameters.Add("@EmailId1", parameters.EmailId1);
            queryParameters.Add("@EmailId2", parameters.EmailId2);
            queryParameters.Add("@Website", parameters.Website);
            queryParameters.Add("@SpecialRemarks", parameters.SpecialRemarks);
            queryParameters.Add("@CompanyRemarks", parameters.CompanyRemarks);
            queryParameters.Add("@PanCardNumber", parameters.PanCardNumber);
            queryParameters.Add("@PanCardOriginalFileName", parameters.PanCardOriginalFileName);
            queryParameters.Add("@PanCardFileName", parameters.PanCardFileName);
            queryParameters.Add("@GSTNumber", parameters.GSTNumber);
            queryParameters.Add("@GSTOriginalFileName", parameters.GSTOriginalFileName);
            queryParameters.Add("@GSTFileName", parameters.GSTFileName);
            queryParameters.Add("@ContactPersonName", parameters.ContactPersonName);
            queryParameters.Add("@ContactPersonMobileNumber", parameters.ContactPersonMobileNumber);
            queryParameters.Add("@ContactPersonEmailId", parameters.ContactPersonEmailId);
            queryParameters.Add("@BankName", parameters.BankName);
            queryParameters.Add("@BankAddress", parameters.BankAddress);
            queryParameters.Add("@BankAccountNo", parameters.BankAccountNo);
            queryParameters.Add("@BankIFSCCode", parameters.BankIFSCCode);
            queryParameters.Add("@AddressLine1", parameters.AddressLine1);
            queryParameters.Add("@AddressLine2", parameters.AddressLine2);
            queryParameters.Add("@CountryId", parameters.CountryId);
            queryParameters.Add("@StateId", parameters.StateId);
            queryParameters.Add("@DistrictId", parameters.DistrictId);
            queryParameters.Add("@CityId", parameters.CityId);
            queryParameters.Add("@PinCode", parameters.PinCode);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveSupplier", queryParameters);
        }

        public async Task<IEnumerable<Supplier_Response>> GetSupplierList(Supplier_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Supplier_Response>("GetSupplierList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Supplier_Response?> GetSupplierById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<Supplier_Response>("GetSupplierById", queryParameters)).FirstOrDefault();
        }
    }
}
