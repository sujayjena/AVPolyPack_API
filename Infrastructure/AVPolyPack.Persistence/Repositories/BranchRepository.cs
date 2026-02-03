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
    public class BranchRepository : GenericRepository, IBranchRepository
    {
        private IConfiguration _configuration;

        public BranchRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveBranch(Branch_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@BranchName", parameters.BranchName);
            queryParameters.Add("@CompanyId", parameters.CompanyId);
            queryParameters.Add("@MobileNo", parameters.MobileNo);
            queryParameters.Add("@EmailId", parameters.EmailId);
            queryParameters.Add("@GSTNumber", parameters.GSTNumber);
            if (SessionManager.LoggedInUserId == 1)
            {
                queryParameters.Add("@NoofUserAdd", parameters.NoofUserAdd);
            }
            queryParameters.Add("@AddressLine", parameters.AddressLine);
            queryParameters.Add("@CountryId", parameters.CountryId);
            queryParameters.Add("@StateId", parameters.StateId);
            queryParameters.Add("@DistrictId", parameters.DistrictId);
            queryParameters.Add("@CityId", parameters.CityId);
            queryParameters.Add("@Pincode", parameters.Pincode);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveBranch", queryParameters);
        }

        public async Task<IEnumerable<Branch_Response>> GetBranchList(BranchSearch_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@CompanyId", parameters.CompanyId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Branch_Response>("GetBranchList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Branch_Response?> GetBranchById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<Branch_Response>("GetBranchById", queryParameters)).FirstOrDefault();
        }
    }
}
