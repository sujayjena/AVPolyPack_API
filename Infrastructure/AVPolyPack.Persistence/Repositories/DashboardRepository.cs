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
    public class DashboardRepository : GenericRepository, IDashboardRepository
    {
        private IConfiguration _configuration;

        public DashboardRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Dashboard_OutwardingStock_Response>> GetDashboard_OutwardingStockSummary(Dashboard_OutwardingStock_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Dashboard_OutwardingStock_Response>("GetDashboard_OutwardingStockSummary", queryParameters);

            return result;
        }
    }
}
