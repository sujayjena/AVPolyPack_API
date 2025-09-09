using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageLabTestRepository
    {
        #region Mesh Entry
        Task<int> SaveMeshEntry(MeshEntry_Request parameters);
        Task<IEnumerable<MeshEntry_Response>> GetMeshEntryList(MeshEntry_Search parameters);
        Task<MeshEntry_Response?> GetMeshEntryById(int Id);
        #endregion

        #region AvgGSM Entry
        Task<int> SaveAvgGSMEntry(AvgGSMEntry_Request parameters);
        Task<IEnumerable<AvgGSMEntry_Response>> GetAvgGSMEntryList(AvgGSMEntry_Search parameters);
        Task<AvgGSMEntry_Response?> GetAvgGSMEntryById(int Id);
        #endregion

        #region Strength Entry
        Task<int> SaveStrengthEntry(StrengthEntry_Request parameters);
        Task<IEnumerable<StrengthEntry_Response>> GetStrengthEntryList(StrengthEntry_Search parameters);
        Task<StrengthEntry_Response?> GetStrengthEntryById(int Id);
        #endregion
    }
}
