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
        public async Task<ResponseModel> GetDashboard_OutwardingStockSummary()
        {
            var lst = await _dashboardRepository.GetDashboard_OutwardingStockSummary();
            _response.Data = lst;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetDashboard_RollSummary()
        {
            var lst = await _dashboardRepository.GetDashboard_RollSummary();
            _response.Data = lst;
            return _response;
        }
    }
}
