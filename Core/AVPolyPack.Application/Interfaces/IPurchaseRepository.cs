using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IPurchaseRepository
    {
        #region Purchase
        Task<int> SavePurchase(Purchase_Request parameters);
        Task<IEnumerable<PurchaseList_Response>> GetPurchaseList(Purchase_Search parameters);
        Task<Purchase_Response?> GetPurchaseById(int Id);

        #endregion

        #region Purchase Details
        Task<int> SavePurchaseDetails(PurchaseDetails_Request parameters);
        Task<IEnumerable<PurchaseDetails_Response>> GetPurchaseDetailsList(PurchaseDetails_Search parameters);
        Task<int> DeletePurchaseDetails(int Id);
        #endregion
    }
}
