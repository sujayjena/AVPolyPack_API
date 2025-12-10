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
    }
}
