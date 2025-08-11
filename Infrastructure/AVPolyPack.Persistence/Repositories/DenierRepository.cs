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
    public class DenierRepository : GenericRepository, IDenierRepository
    {
        private IConfiguration _configuration;

        public DenierRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveDenier(Denier_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@TapeMachineId", parameters.TapeMachineId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@Denier", parameters.Denier);
            queryParameters.Add("@TapeWidth", parameters.TapeWidth);
            queryParameters.Add("@Strength", parameters.Strength);
            queryParameters.Add("@Elongation", parameters.Elongation);
            queryParameters.Add("@RequiredQty", parameters.RequiredQty);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveDenier", queryParameters);
        }

        public async Task<IEnumerable<Denier_Response>> GetDenierList(Denier_Search parameters)
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

            var result = await ListByStoredProcedure<Denier_Response>("GetDenierList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Denier_Response?> GetDenierById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Denier_Response>("GetDenierById", queryParameters)).FirstOrDefault();
        }
    }
}
