using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface ILoomsRepository
    {
        Task<int> SaveLooms(Looms_Request parameters);
        Task<IEnumerable<Looms_Response>> GetLoomsList(Looms_Search parameters);
        Task<Looms_Response?> GetLoomsById(int Id);
    }
}
