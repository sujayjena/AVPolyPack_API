using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageDispatchRepository
    {
        Task<int> SaveDispatch(Dispatch_Request parameters);
        Task<IEnumerable<Dispatch_Response>> GetDispatchList(Dispatch_Search parameters);
        Task<Dispatch_Response?> GetDispatchById(int Id);
    }
}
