using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageWorkerRepository
    {
        Task<int> SaveWorker(Worker_Request parameters);
        Task<IEnumerable<Worker_Response>> GetWorkerList(Worker_Search parameters);
        Task<Worker_Response?> GetWorkerById(int Id);
    }
}
