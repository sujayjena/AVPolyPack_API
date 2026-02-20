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
    public class ManageDispatchRepository : GenericRepository, IManageDispatchRepository
    {
        private IConfiguration _configuration;

        public ManageDispatchRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveDispatch(Dispatch_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@DispatchNo", parameters.DispatchNo);
            queryParameters.Add("@DispatchDate", parameters.DispatchDate);
            queryParameters.Add("@CustomerId", parameters.CustomerId);
            queryParameters.Add("@OrderId", parameters.OrderId);
            queryParameters.Add("@OrderItemId", parameters.OrderItemId);
            queryParameters.Add("@VehicleNumber", parameters.VehicleNumber);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@IsDispatch", parameters.IsDispatch);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveDispatch", queryParameters);
        }

        public async Task<IEnumerable<Dispatch_Response>> GetDispatchList(Dispatch_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Dispatch_Response>("GetDispatchList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Dispatch_Response?> GetDispatchById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Dispatch_Response>("GetDispatchById", queryParameters)).FirstOrDefault();
        }

    }
}
