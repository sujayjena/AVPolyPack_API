using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface ITapeMachineRemarksRepository
    {
        Task<int> SaveTapeMachineRemarks(TapeMachineRemarks_Request parameters);
        Task<IEnumerable<TapeMachineRemarks_Response>> GetTapeMachineRemarksList(TapeMachineRemarks_Search parameters);
        Task<TapeMachineRemarks_Response?> GetTapeMachineRemarksById(int Id);
    }
}
