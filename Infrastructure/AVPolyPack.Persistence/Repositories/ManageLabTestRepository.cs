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
    public class ManageLabTestRepository : GenericRepository, IManageLabTestRepository
    {
        private IConfiguration _configuration;

        public ManageLabTestRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Mesh Entry 

        public async Task<int> SaveMeshEntry(MeshEntry_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@RequiredMesh", parameters.RequiredMesh);
            queryParameters.Add("@ActualMesh", parameters.ActualMesh);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveMeshEntry", queryParameters);
        }

        public async Task<IEnumerable<MeshEntry_Response>> GetMeshEntryList(MeshEntry_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<MeshEntry_Response>("GetMeshEntryList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<MeshEntry_Response?> GetMeshEntryById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<MeshEntry_Response>("GetMeshEntryById", queryParameters)).FirstOrDefault();
        }

        #endregion

        #region AvgGSM Entry 

        public async Task<int> SaveAvgGSMEntry(AvgGSMEntry_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@RequiredAvg", parameters.RequiredAvg);
            queryParameters.Add("@RequiredGSM", parameters.RequiredGSM);
            queryParameters.Add("@ActualAvg", parameters.ActualAvg);
            queryParameters.Add("@ActualGSM", parameters.ActualGSM);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveAvgGSMEntry", queryParameters);
        }

        public async Task<IEnumerable<AvgGSMEntry_Response>> GetAvgGSMEntryList(AvgGSMEntry_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<AvgGSMEntry_Response>("GetAvgGSMEntryList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<AvgGSMEntry_Response?> GetAvgGSMEntryById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<AvgGSMEntry_Response>("GetAvgGSMEntryById", queryParameters)).FirstOrDefault();
        }

        #endregion

        #region Strength Entry 

        public async Task<int> SaveStrengthEntry(StrengthEntry_Request parameters)
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

            return await SaveByStoredProcedure<int>("SaveStrengthEntry", queryParameters);
        }

        public async Task<IEnumerable<StrengthEntry_Response>> GetStrengthEntryList(StrengthEntry_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<StrengthEntry_Response>("GetStrengthEntryList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<StrengthEntry_Response?> GetStrengthEntryById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<StrengthEntry_Response>("GetStrengthEntryById", queryParameters)).FirstOrDefault();
        }

        #endregion
    }
}
