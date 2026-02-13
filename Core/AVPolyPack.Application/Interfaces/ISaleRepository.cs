using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface ISaleRepository
    {
        #region Sale
        Task<int> SaveSale(Sale_Request parameters);
        Task<IEnumerable<SaleList_Response>> GetSaleList(Sale_Search parameters);
        Task<Sale_Response?> GetSaleById(int Id);

        #endregion

        #region Sale Details
        Task<int> SaveSaleDetails(SaleDetails_Request parameters);
        Task<IEnumerable<SaleDetails_Response>> GetSaleDetailsList(SaleDetails_Search parameters);
        Task<int> DeleteSaleDetails(int Id);
        #endregion
    }
}
