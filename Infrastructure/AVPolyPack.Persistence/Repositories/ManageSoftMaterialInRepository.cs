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
    public class ManageSoftMaterialInRepository : GenericRepository, IManageSoftMaterialInRepository
    {
        private IConfiguration _configuration;

        public ManageSoftMaterialInRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Soft Material In
        public async Task<int> SaveSoftMaterialIn(SoftMaterialIn_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@InwardingId", parameters.InwardingId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@VehicleNumber", parameters.VehicleNumber);
            queryParameters.Add("@VendorId", parameters.VendorId);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@StatusId", parameters.StatusId);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveSoftMaterialIn", queryParameters);
        }

        public async Task<IEnumerable<SoftMaterialIn_Response>> GetSoftMaterialInList(SoftMaterialIn_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@StatusId", parameters.StatusId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<SoftMaterialIn_Response>("GetSoftMaterialInList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<SoftMaterialIn_Response?> GetSoftMaterialInById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<SoftMaterialIn_Response>("GetSoftMaterialInById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Soft Material In Details
        public async Task<int> SaveSoftMaterialInDetails(SoftMaterialInDetails_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@SoftMaterialInId", parameters.SoftMaterialInId);
            queryParameters.Add("@MaterialId", parameters.MaterialId);
            queryParameters.Add("@Quantity", parameters.Quantity);
            queryParameters.Add("@Weight", parameters.Weight);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveSoftMaterialInDetails", queryParameters);
        }

        public async Task<IEnumerable<SoftMaterialInDetails_Response>> GetSoftMaterialInDetailsList(SoftMaterialInDetails_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SoftMaterialInId", parameters.SoftMaterialInId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<SoftMaterialInDetails_Response>("GetSoftMaterialInDetailsList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<int> ReceivedSoftMaterialIn(ReceivedSoftMaterialInList_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@IsOk", parameters.IsOk);
            queryParameters.Add("@ReceivedQty", parameters.ReceivedQty);
            queryParameters.Add("@ReceivedWeight", parameters.ReceivedWeight);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("ReceivedSoftMaterialIn", queryParameters);
        }

        #endregion
    }
}
