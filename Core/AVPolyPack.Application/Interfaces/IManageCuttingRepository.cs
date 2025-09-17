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
        #region Cutting
        Task<int> SaveCutting(Cutting_Request parameters);
        Task<IEnumerable<Cutting_Response>> GetCuttingList(Cutting_Search parameters);
        Task<Cutting_Response?> GetCuttingById(int Id);
        #endregion

        #region Cutting Machine Reading
        Task<int> SaveCuttingMachineReading(CuttingMachineReading_Request parameters);
        Task<IEnumerable<CuttingMachineReading_Response>> GetCuttingMachineReadingList(CuttingMachineReading_Search parameters);
        Task<CuttingMachineReading_Response?> GetCuttingMachineReadingById(int Id);
        #endregion
    }
}
