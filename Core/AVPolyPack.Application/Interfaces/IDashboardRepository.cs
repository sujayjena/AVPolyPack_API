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
        Task<IEnumerable<Dashboard_OutwardingStock_Response>> GetDashboard_OutwardingStockSummary(Dashboard_OutwardingStock_Search parameters);
    }
}
