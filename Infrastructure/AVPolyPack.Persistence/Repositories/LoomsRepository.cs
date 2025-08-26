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
    public class LoomsRepository : GenericRepository, ILoomsRepository
    {
        private IConfiguration _configuration;

        public LoomsRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveLooms(Looms_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@LoomNumber", parameters.LoomNumber);
            queryParameters.Add("@Average", parameters.Average);
            queryParameters.Add("@Denier", parameters.Denier);
            queryParameters.Add("@SizeId", parameters.SizeId);
            queryParameters.Add("@GramId", parameters.GramId);
            queryParameters.Add("@MeshId", parameters.MeshId);
            queryParameters.Add("@SpecificationId", parameters.SpecificationId);
            queryParameters.Add("@TypeId", parameters.TypeId);
            queryParameters.Add("@CustomerId", parameters.CustomerId);
            queryParameters.Add("@OrderId", parameters.OrderId);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveLooms", queryParameters);
        }

        public async Task<IEnumerable<Looms_Response>> GetLoomsList(Looms_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Looms_Response>("GetLoomsList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Looms_Response?> GetLoomsById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Looms_Response>("GetLoomsById", queryParameters)).FirstOrDefault();
        }

        #region Loom Assign
        public async Task<int> SaveLoomAssign(LoomAssign_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveLoomAssign", queryParameters);
        }

        public async Task<IEnumerable<LoomAssign_Response>> GetLoomAssignList(LoomAssign_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<LoomAssign_Response>("GetLoomAssignList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        public async Task<IEnumerable<LoomListForAssignOperator_Response>> GetLoomListForAssignOperator(LoomListForAssignOperator_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<LoomListForAssignOperator_Response>("GetLoomListForAssignOperator", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        public async Task<IEnumerable<OperatorNameSelectList_Response>> GetOperatorNameForSelectList()
        {
            DynamicParameters queryParameters = new DynamicParameters();

            return await ListByStoredProcedure<OperatorNameSelectList_Response>("GetOperatorNameForSelectList", queryParameters);
        }
        #endregion

        #region Order Item Assign
        public async Task<IEnumerable<SelectListResponse>> GetOrderItemNoForSelectList()
        {
            DynamicParameters queryParameters = new DynamicParameters();

            return await ListByStoredProcedure<SelectListResponse>("GetOrderItemNoForSelectList", queryParameters);
        }

        #endregion
    }
}
