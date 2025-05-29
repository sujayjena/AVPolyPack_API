using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
  
    public interface IManageOrderRepository
    {
        #region Order

        Task<int> SaveOrder(Order_Request parameters);
        Task<IEnumerable<Order_Response>> GetOrderList(Order_Search parameters);
        Task<Order_Response?> GetOrderById(int Id);

        #endregion

        #region Order Item

        Task<int> SaveOrderItem(OrderItem_Request parameters);
        Task<IEnumerable<OrderItem_Response>> GetOrderItemList(OrderItem_Search parameters);
        Task<OrderItem_Response?> GetOrderItemById(int Id);
        Task<int> DeleteOrderItem(int Id);
        #endregion
    }
}
