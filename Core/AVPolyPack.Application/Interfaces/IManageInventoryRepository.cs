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

        #region Split Roll
        Task<IEnumerable<Split_Response>> GetSplitList(Split_Search parameters);
        Task<int> SaveSplitRoll(SplitRoll_Request parameters);
        Task<IEnumerable<SplitRoll_Response>> GetSplitRollList(SplitRoll_Search parameters);
        Task<SplitRoll_Response?> GetSplitRollById(int Id);
        #endregion
    }
}
