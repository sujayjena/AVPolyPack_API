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
    public class ManageCuttingRepository : GenericRepository, IManageCuttingRepository
    {
        private IConfiguration _configuration;

        public ManageCuttingRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Cutting
        public async Task<int> SaveCutting(Cutting_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@CuttingMachineId", parameters.CuttingMachineId);
            queryParameters.Add("@CuttingSize", parameters.CuttingSize);
            queryParameters.Add("@TotalPcs", parameters.TotalPcs);
            queryParameters.Add("@OpeningReading", parameters.OpeningReading);
            queryParameters.Add("@ClosingReading", parameters.ClosingReading);
            queryParameters.Add("@GoodPcs", parameters.GoodPcs);
            queryParameters.Add("@WastePcs", parameters.WastePcs);
            queryParameters.Add("@DiffPcs", parameters.DiffPcs);
            queryParameters.Add("@IsCompleted", parameters.IsCompleted);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveCutting", queryParameters);
        }

        public async Task<IEnumerable<Cutting_Response>> GetCuttingList(Cutting_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Cutting_Response>("GetCuttingList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Cutting_Response?> GetCuttingById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<Cutting_Response>("GetCuttingById", queryParameters)).FirstOrDefault();
        }

        #endregion

        #region Cutting Machine Reading
        public async Task<int> SaveCuttingMachineReading(CuttingMachineReading_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@CuttingMachineId", parameters.CuttingMachineId);
            queryParameters.Add("@OpeningReading", parameters.OpeningReading);
            queryParameters.Add("@ClosingReading", parameters.ClosingReading);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveCuttingMachineReading", queryParameters);
        }

        public async Task<IEnumerable<CuttingMachineReading_Response>> GetCuttingMachineReadingList(CuttingMachineReading_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@CuttingMachineId", parameters.CuttingMachineId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<CuttingMachineReading_Response>("GetCuttingMachineReadingList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<CuttingMachineReading_Response?> GetCuttingMachineReadingById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<CuttingMachineReading_Response>("GetCuttingMachineReadingById", queryParameters)).FirstOrDefault();
        }
        #endregion
    }
}
