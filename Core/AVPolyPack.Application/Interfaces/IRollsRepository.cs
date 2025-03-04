using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IRollsRepository
    {
        Task<int> SaveRolls(Rolls_Request parameters);
        Task<IEnumerable<Rolls_Response>> GetRollsList(Rolls_Search parameters);
        Task<Rolls_Response?> GetRollsById(int Id);
    }
}
