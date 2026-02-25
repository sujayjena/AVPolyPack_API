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
        Task<int> AssignOrderItemCompleted(AssignOrderItemCompleted_Request parameters);
        #endregion

        #region Size Reading
        Task<int> SaveSizeReading(SizeReading_Request parameters);
        Task<IEnumerable<SizeReading_Response>> GetSizeReadingList(SizeReading_Search parameters);
        #endregion

        #region Loom Reading
        Task<int> SaveLoomReading(LoomReading_Request parameters);
        Task<IEnumerable<LoomReading_Response>> GetLoomReadingList(LoomReading_Search parameters);
        #endregion

        #region Loom remarks
        Task<int> SaveLoomRemarks(LoomRemarks_Request parameters);
        Task<IEnumerable<LoomRemarks_Response>> GetLoomRemarksList(LoomRemarks_Search parameters);
        Task<LoomRemarks_Response?> GetLoomRemarksById(int Id);
        #endregion

        #region Roll
        Task<int> SaveRoll(Roll_Request parameters);
        Task<IEnumerable<Roll_Response>> GetRollList(Roll_Search parameters);
        Task<Roll_Response?> GetRollById(int Id);
        Task<int> RollCodeReset();
        Task<TrackingStatus_Response?> GetTrackingStatusById(int Id);
        Task<int> PickupRoll(PickupRoll_Request parameters);
        Task<IEnumerable<OutwardingStock_Response>> GetOutwardingStockList(OutwardingStock_Search parameters);
        #endregion
    }
}
