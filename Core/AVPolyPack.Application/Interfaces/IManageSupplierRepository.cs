using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageSupplierRepository
    {
        Task<int> SaveSupplier(Supplier_Request parameters);
        Task<IEnumerable<Supplier_Response>> GetSupplierList(Supplier_Search parameters);
        Task<Supplier_Response?> GetSupplierById(int Id);
    }
}
