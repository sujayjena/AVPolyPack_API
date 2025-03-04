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
    public class RollsRepository : GenericRepository, IRollsRepository
    {
        private IConfiguration _configuration;

        public RollsRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveRolls(Rolls_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@CustomerId", parameters.CustomerId);
            queryParameters.Add("@OrderId", parameters.OrderId);
            queryParameters.Add("@RollNumber", parameters.RollNumber);
            queryParameters.Add("@LoomsId", parameters.LoomsId);
            queryParameters.Add("@ProductionDate", parameters.ProductionDate);
            queryParameters.Add("@GrossWeight", parameters.GrossWeight);
            queryParameters.Add("@TareWeight", parameters.TareWeight);
            queryParameters.Add("@Meter", parameters.Meter);
            queryParameters.Add("@NetWeight", parameters.NetWeight);
            queryParameters.Add("@Average", parameters.Average);
            queryParameters.Add("@AverageDiff", parameters.AverageDiff);
            queryParameters.Add("@Notes", parameters.Notes);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveRolls", queryParameters);
        }

        public async Task<IEnumerable<Rolls_Response>> GetRollsList(Rolls_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Rolls_Response>("GetRollsList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Rolls_Response?> GetRollsById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Rolls_Response>("GetRollsById", queryParameters)).FirstOrDefault();
        }
    }
}
