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
    public class MaterialConsumptionRepository : GenericRepository, IMaterialConsumptionRepository
    {
        private IConfiguration _configuration;

        public MaterialConsumptionRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Consumption
        public async Task<int> SaveConsumption(Consumption_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@ConsumptionDate", parameters.ConsumptionDate);
            queryParameters.Add("@MaterialId", parameters.MaterialId);
            queryParameters.Add("@ConsumptionQty", parameters.ConsumptionQty);
            queryParameters.Add("@TotalWeight", parameters.TotalWeight);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveConsumption", queryParameters);
        }

        public async Task<IEnumerable<ConsumptionHeader_Response>> GetConsumptionHeaderList(Consumption_Search parameters)
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

            var result = await ListByStoredProcedure<ConsumptionHeader_Response>("GetConsumptionHeaderList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<IEnumerable<Consumption_Response>> GetConsumptionList(Consumption_Search parameters)
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

            var result = await ListByStoredProcedure<Consumption_Response>("GetConsumptionList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Consumption_Response?> GetConsumptionById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Consumption_Response>("GetConsumptionById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Waste Material
        public async Task<int> SaveWasteMaterial(WasteMaterial_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@WasteMaterialDate", parameters.WasteMaterialDate);
            queryParameters.Add("@MaterialId", parameters.MaterialId);
            queryParameters.Add("@WasteWeight", parameters.WasteWeight);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveWasteMaterial", queryParameters);
        }
        public async Task<IEnumerable<WasteMaterialHeader_Response>> GetWasteMaterialHeaderList(WasteMaterial_Search parameters)
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

            var result = await ListByStoredProcedure<WasteMaterialHeader_Response>("GetWasteMaterialHeaderList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        public async Task<IEnumerable<WasteMaterial_Response>> GetWasteMaterialList(WasteMaterial_Search parameters)
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

            var result = await ListByStoredProcedure<WasteMaterial_Response>("GetWasteMaterialList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<WasteMaterial_Response?> GetWasteMaterialById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<WasteMaterial_Response>("GetWasteMaterialById", queryParameters)).FirstOrDefault();
        }
        #endregion
    }
}
