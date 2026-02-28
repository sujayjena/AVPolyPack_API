using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageInventoryRepository
    {
        Task<int> SaveInventory(Inventory_Request parameters);
        Task<IEnumerable<Inventory_Response>> GetInventoryList(Inventory_Search parameters);
        Task<Inventory_Response?> GetInventoryById(int Id);

        #region Inventory Roll
        Task<IEnumerable<InventoryRoll_Response>> GetInventoryRollList(InventoryRoll_Search parameters);
        #endregion

        #region Split Roll
        Task<int> SaveSplitRequest(SplitRequest_Request parameters);
        Task<IEnumerable<SplitRequest_Response>> GetSplitRequestList(SplitRequest_Search parameters);

        Task<int> SaveSplitRoll(SplitRoll_Request parameters);
        Task<IEnumerable<SplitRoll_Response>> GetSplitRollList(SplitRoll_Search parameters);
        Task<SplitRoll_Response?> GetSplitRollById(int Id);
        #endregion

        #region Merge Roll
        Task<int> SaveMergeRequest(MergeRequest_Request parameters);
        Task<IEnumerable<MergeRequest_Response>> GetMergeRequestList(MergeRequest_Search parameters);

        Task<int> SaveMergeRoll(MergeRoll_Request parameters);
        Task<IEnumerable<MergeRoll_Response>> GetMergeRollList(MergeRoll_Search parameters);
        #endregion
    }
}
