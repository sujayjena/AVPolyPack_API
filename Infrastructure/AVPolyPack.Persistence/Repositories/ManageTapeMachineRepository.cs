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
    public class ManageTapeMachineRepository : GenericRepository, IManageTapeMachineRepository
    {
        private IConfiguration _configuration;

        public ManageTapeMachineRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Machine Assign
        public async Task<int> SaveMachineAssign(MachineAssign_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@RefId", parameters.RefId);
            queryParameters.Add("@RefType", parameters.RefType);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveMachineAssign", queryParameters);
        }

        public async Task<IEnumerable<MachineAssign_Response>> GetMachineAssignList(MachineAssign_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<MachineAssign_Response>("GetMachineAssignList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        #endregion

        #region Machine Start Stop
        public async Task<int> SaveMachineStartStop(MachineStartStop_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@IsStart_Stop", parameters.IsStart_Stop);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveMachineStartStop", queryParameters);
        }

        public async Task<IEnumerable<MachineStartStop_Response>> GetMachineStartStopList(MachineStartStop_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@IsStart_Stop", parameters.IsStart_Stop);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<MachineStartStop_Response>("GetMachineStartStopList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        #endregion

        #region Machine Remarks
        public async Task<int> SaveTapeMachineRemarks(TapeMachineRemarks_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveTapeMachineRemarks", queryParameters);
        }

        public async Task<IEnumerable<TapeMachineRemarks_Response>> GetTapeMachineRemarksList(TapeMachineRemarks_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<TapeMachineRemarks_Response>("GetTapeMachineRemarksList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<TapeMachineRemarks_Response?> GetTapeMachineRemarksById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<TapeMachineRemarks_Response>("GetTapeMachineRemarksById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Employee List for Assign
        public async Task<IEnumerable<EmployeeListForAssignMachine_Response>> GetEmployeeListForAssignMachine(EmployeeListForAssignMachine_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@DepartmentId", parameters.DepartmentId);
            queryParameters.Add("@RoleId", parameters.RoleId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@RefType", parameters.RefType);
            queryParameters.Add("@RefId", parameters.RefId);
        
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<EmployeeListForAssignMachine_Response>("GetEmployeeListForAssignMachine", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        #endregion
    }
}
