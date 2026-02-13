using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageSoftMaterialInRepository
    {
        #region Soft Material In
        Task<int> SaveSoftMaterialIn(SoftMaterialIn_Request parameters);
        Task<IEnumerable<SoftMaterialIn_Response>> GetSoftMaterialInList(SoftMaterialIn_Search parameters);
        Task<SoftMaterialIn_Response?> GetSoftMaterialInById(int Id);
        #endregion

        #region Soft Material In Details
        Task<int> SaveSoftMaterialInDetails(SoftMaterialInDetails_Request parameters);
        Task<IEnumerable<SoftMaterialInDetails_Response>> GetSoftMaterialInDetailsList(SoftMaterialInDetails_Search parameters);
        Task<int> ReceivedSoftMaterialIn(ReceivedSoftMaterialInList_Request parameters);
        Task<int> DeleteSoftMaterialInDetails(int Id);
        #endregion
    }
}
