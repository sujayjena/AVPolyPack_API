using AVPolyPack.Application.Enums;
using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using AVPolyPack.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVPolyPack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : CustomBaseController
    {
        private ResponseModel _response;
        private IFileManager _fileManager;

        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IFileManager fileManager, IDashboardRepository dashboardRepository)
        {
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
            _dashboardRepository = dashboardRepository;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetDashboard_OutwardingStockSummary(Dashboard_OutwardingStock_Search parameters)
        {
            IEnumerable<Dashboard_OutwardingStock_Response> lst = await _dashboardRepository.GetDashboard_OutwardingStockSummary(parameters);
            _response.Data = lst.ToList();
            _response.Total = parameters.Total;
            return _response;
        }
    }
}
