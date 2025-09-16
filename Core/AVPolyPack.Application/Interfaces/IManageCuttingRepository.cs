using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageCuttingRepository
    {
        Task<int> SaveCutting(Cutting_Request parameters);
        Task<IEnumerable<Cutting_Response>> GetCuttingList(Cutting_Search parameters);
        Task<Cutting_Response?> GetCuttingById(int Id);
    }
}
