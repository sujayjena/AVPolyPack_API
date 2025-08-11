using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IDenierRepository
    {
        Task<int> SaveDenier(Denier_Request parameters);
        Task<IEnumerable<Denier_Response>> GetDenierList(Denier_Search parameters);
        Task<Denier_Response?> GetDenierById(int Id);
    }
}
