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
            queryParameters.Add("@IsAssign", parameters.IsAssign);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@IsIdle", parameters.IsIdle);
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
        public async Task<IEnumerable<OperatorNameSelectList_Response>> GetOperatorNameForSelectList(OperatorNameSelectList_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@IsPresent", parameters.IsPresent);

            return await ListByStoredProcedure<OperatorNameSelectList_Response>("GetOperatorNameForSelectList", queryParameters);
        }
        #endregion

        #region Order Item Assign

        public async Task<IEnumerable<SelectListResponse>> GetOrderItemNoForSelectList()
        {
            DynamicParameters queryParameters = new DynamicParameters();

            return await ListByStoredProcedure<SelectListResponse>("GetOrderItemNoForSelectList", queryParameters);
        }

        public async Task<int> SaveOrderItemAssign(OrderItemAssign_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@OrderItemId", parameters.OrderItemId);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveOrderItemAssign", queryParameters);
        }

        public async Task<IEnumerable<OrderItemAssign_Response>> GetOrderItemAssignList(OrderItemAssign_Search parameters)
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

            var result = await ListByStoredProcedure<OrderItemAssign_Response>("GetOrderItemAssignList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        public async Task<int> AssignOrderItemCompleted(AssignOrderItemCompleted_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@IsCompleted", parameters.IsCompleted);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("AssignOrderItemCompleted", queryParameters);
        }
        #endregion

        #region Size reading
        public async Task<int> SaveSizeReading(SizeReading_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderItemAssignId", parameters.OrderItemAssignId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@RequiredSize", parameters.RequiredSize);
            queryParameters.Add("@Size", parameters.Size);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveSizeReading", queryParameters);
        }

        public async Task<IEnumerable<SizeReading_Response>> GetSizeReadingList(SizeReading_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<SizeReading_Response>("GetSizeReadingList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        #endregion

        #region Loom reading
        public async Task<int> SaveLoomReading(LoomReading_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderItemAssignId", parameters.OrderItemAssignId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@Reading", parameters.Reading);
            queryParameters.Add("@PrevReading", parameters.PrevReading);
            queryParameters.Add("@Production", parameters.Production);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveLoomReading", queryParameters);
        }

        public async Task<IEnumerable<LoomReading_Response>> GetLoomReadingList(LoomReading_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<LoomReading_Response>("GetLoomReadingList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        #endregion

        #region Loom Remarks
        public async Task<int> SaveLoomRemarks(LoomRemarks_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveLoomRemarks", queryParameters);
        }

        public async Task<IEnumerable<LoomRemarks_Response>> GetLoomRemarksList(LoomRemarks_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<LoomRemarks_Response>("GetLoomRemarksList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<LoomRemarks_Response?> GetLoomRemarksById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<LoomRemarks_Response>("GetLoomRemarksById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Roll
        public async Task<int> SaveRoll(Roll_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderItemAssignId", parameters.OrderItemAssignId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@StartMeter", parameters.StartMeter);
            queryParameters.Add("@EndMeter", parameters.EndMeter);
            queryParameters.Add("@TotalMeter", parameters.TotalMeter);
            queryParameters.Add("@GrossWeight", parameters.GrossWeight);
            queryParameters.Add("@TareWeight", parameters.TareWeight);
            queryParameters.Add("@NetWeight", parameters.NetWeight);
            queryParameters.Add("@CurrentAvg", parameters.CurrentAvg);
            queryParameters.Add("@CurrentGSM", parameters.CurrentGSM);
            queryParameters.Add("@GSMDiff", parameters.GSMDiff);
            queryParameters.Add("@AvgDiff", parameters.AvgDiff);
            queryParameters.Add("@IsCompleted", parameters.IsCompleted);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveRoll", queryParameters);
        }

        public async Task<IEnumerable<Roll_Response>> GetRollList(Roll_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@IsCompleted", parameters.IsCompleted);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Roll_Response>("GetRollList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Roll_Response?> GetRollById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Roll_Response>("GetRollById", queryParameters)).FirstOrDefault();
        }

        public async Task<int> RollCodeReset()
        {
            DynamicParameters queryParameters = new DynamicParameters();

            return await SaveByStoredProcedure<int>("RollCodeReset", queryParameters);
        }

        #endregion
    }
}
