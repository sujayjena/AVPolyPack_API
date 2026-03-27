using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IDashboardRepository
    {
        Task<Dashboard_OutwardingStock_Response?> GetDashboard_OutwardingStockSummary();
        Task<Dashboard_Roll_Response?> GetDashboard_RollSummary(Dashboard_Roll_Search parameter);
        Task<IEnumerable<Dashboard_CountryWiseCustomerSummary_Response>> GetDashboard_CountryWiseCustomerSummary(Dashboard_CountryWiseCustomerSummary_Search parameter);
    }
}
