using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface ILoomsRepository
    {
        Task<int> SaveLooms(Looms_Request parameters);
        Task<IEnumerable<Looms_Response>> GetLoomsList(Looms_Search parameters);
        Task<Looms_Response?> GetLoomsById(int Id);

        #region Loom Assign
        Task<int> SaveLoomAssign(LoomAssign_Request parameters);
        Task<IEnumerable<LoomAssign_Response>> GetLoomAssignList(LoomAssign_Search parameters);
        Task<IEnumerable<LoomListForAssignOperator_Response>> GetLoomListForAssignOperator(LoomListForAssignOperator_Search parameters);
        Task<IEnumerable<OperatorNameSelectList_Response>> GetOperatorNameForSelectList(OperatorNameSelectList_Search parameters);
        #endregion

        #region Order Item Assign
        Task<IEnumerable<SelectListResponse>> GetOrderItemNoForSelectList();
        Task<int> SaveOrderItemAssign(OrderItemAssign_Request parameters);
        Task<IEnumerable<OrderItemAssign_Response>> GetOrderItemAssignList(OrderItemAssign_Search parameters);
        #endregion
    }
}
