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
    public class ManageLaminationRepository : GenericRepository, IManageLaminationRepository
    {
        private IConfiguration _configuration;

        public ManageLaminationRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Lamination

        public async Task<int> SaveLamination(Lamination_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@Size", parameters.Size);
            queryParameters.Add("@Meter", parameters.Meter);
            queryParameters.Add("@GrossWeight", parameters.GrossWeight);
            queryParameters.Add("@CurrentWeight", parameters.CurrentWeight);
            queryParameters.Add("@NetWeight", parameters.NetWeight);
            queryParameters.Add("@Average", parameters.Average);
            queryParameters.Add("@IsCompleted", parameters.IsCompleted);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveLamination", queryParameters);
        }

        public async Task<IEnumerable<Lamination_Response>> GetLaminationList(Lamination_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Lamination_Response>("GetLaminationList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Lamination_Response?> GetLaminationById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<Lamination_Response>("GetLaminationById", queryParameters)).FirstOrDefault();
        }

        #endregion

        #region Consumption
        public async Task<int> SaveConsumption_Lamination(Consumption_Lamination_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@ConsumptionDate", parameters.ConsumptionDate);
            queryParameters.Add("@MaterialId", parameters.MaterialId);
            queryParameters.Add("@ConsumptionQty", parameters.ConsumptionQty);
            queryParameters.Add("@TotalWeight", parameters.TotalWeight);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveConsumption_Lamination", queryParameters);
        }

        public async Task<IEnumerable<Consumption_Lamination_Response>> GetConsumption_LaminationList(Consumption_Lamination_Search parameters)
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

            var result = await ListByStoredProcedure<Consumption_Lamination_Response>("GetConsumption_LaminationList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Consumption_Lamination_Response?> GetConsumption_LaminationById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Consumption_Lamination_Response>("GetConsumption_LaminationById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Waste Material
        public async Task<int> SaveWasteMaterial_Lamination(WasteMaterial_Lamination_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@WasteMaterialDate", parameters.WasteMaterialDate);
            queryParameters.Add("@MaterialId", parameters.MaterialId);
            queryParameters.Add("@WasteWeight", parameters.WasteWeight);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveWasteMaterial_Lamination", queryParameters);
        }

        public async Task<IEnumerable<WasteMaterial_Lamination_Response>> GetWasteMaterial_LaminationList(WasteMaterial_Lamination_Search parameters)
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

            var result = await ListByStoredProcedure<WasteMaterial_Lamination_Response>("GetWasteMaterial_LaminationList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<WasteMaterial_Lamination_Response?> GetWasteMaterial_LaminationById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<WasteMaterial_Lamination_Response>("GetWasteMaterial_LaminationById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region AvgGSM Entry 

        public async Task<int> SaveAvgGSMEntry_Lamination(AvgGSMEntry_Lamination_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@RequiredAvg", parameters.RequiredAvg);
            queryParameters.Add("@RequiredGSM", parameters.RequiredGSM);
            queryParameters.Add("@ActualAvg", parameters.ActualAvg);
            queryParameters.Add("@ActualGSM", parameters.ActualGSM);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveAvgGSMEntry_Lamination", queryParameters);
        }

        public async Task<IEnumerable<AvgGSMEntry_Lamination_Response>> GetAvgGSMEntry_LaminationList(AvgGSMEntry_Lamination_Search parameters)
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

            var result = await ListByStoredProcedure<AvgGSMEntry_Lamination_Response>("GetAvgGSMEntry_LaminationList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<AvgGSMEntry_Lamination_Response?> GetAvgGSMEntry_LaminationById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<AvgGSMEntry_Lamination_Response>("GetAvgGSMEntry_LaminationById", queryParameters)).FirstOrDefault();
        }

        #endregion

        #region Strength Entry 

        public async Task<int> SaveStrengthEntry_Lamination(StrengthEntry_Lamination_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@RequiredStrength", parameters.RequiredStrength);
            queryParameters.Add("@WARP", parameters.WARP);
            queryParameters.Add("@WARP_ELO", parameters.WARP_ELO);
            queryParameters.Add("@WEFT", parameters.WEFT);
            queryParameters.Add("@WEFT_ELO", parameters.WEFT_ELO);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveStrengthEntry_Lamination", queryParameters);
        }

        public async Task<IEnumerable<StrengthEntry_Lamination_Response>> GetStrengthEntry_LaminationList(StrengthEntry_Lamination_Search parameters)
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

            var result = await ListByStoredProcedure<StrengthEntry_Lamination_Response>("GetStrengthEntry_LaminationList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<StrengthEntry_Lamination_Response?> GetStrengthEntry_LaminationById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<StrengthEntry_Lamination_Response>("GetStrengthEntry_LaminationById", queryParameters)).FirstOrDefault();
        }

        #endregion
    }
}
