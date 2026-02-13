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
    public class ManageInventoryRepository : GenericRepository, IManageInventoryRepository
    {
        private IConfiguration _configuration;

        public ManageInventoryRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveInventory(Inventory_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@IsCompleted", parameters.IsCompleted);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveInventory", queryParameters);
        }

        public async Task<IEnumerable<Inventory_Response>> GetInventoryList(Inventory_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Inventory_Response>("GetInventoryList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Inventory_Response?> GetInventoryById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<Inventory_Response>("GetInventoryById", queryParameters)).FirstOrDefault();
        }

        #region Split Roll
        public async Task<IEnumerable<Split_Response>> GetSplitList(Split_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@TypeId", parameters.TypeId);
            queryParameters.Add("@Size", parameters.Size);
            queryParameters.Add("@RollLength", parameters.RollLength);
            queryParameters.Add("@EstimatedWeight", parameters.EstimatedWeight);
            queryParameters.Add("@GSM", parameters.GSM);
            queryParameters.Add("@Average", parameters.Average);
            queryParameters.Add("@Gram", parameters.Gram);
            queryParameters.Add("@MeshId", parameters.MeshId);
            queryParameters.Add("@Strength", parameters.Strength);
            queryParameters.Add("@Guzzet", parameters.Guzzet);
            queryParameters.Add("@FoldingSize", parameters.FoldingSize);
            queryParameters.Add("@IsAntiSlip", parameters.IsAntiSlip);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Split_Response>("GetSplitList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        public async Task<int> SaveSplitRoll(SplitRoll_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@SplitRollNo", parameters.SplitRollNo);
            queryParameters.Add("@SplitRollLength", parameters.SplitRollLength);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveSplitRoll", queryParameters);
        }
        public async Task<IEnumerable<SplitRoll_Response>> GetSplitRollList(SplitRoll_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<SplitRoll_Response>("GetSplitRollList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        #endregion
    }
}
