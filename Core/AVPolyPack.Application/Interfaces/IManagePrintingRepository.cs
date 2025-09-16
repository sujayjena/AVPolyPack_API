using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManagePrintingRepository
    {
        Task<int> SavePrinting(Printing_Request parameters);
        Task<IEnumerable<Printing_Response>> GetPrintingList(Printing_Search parameters);
        Task<Printing_Response?> GetPrintingById(int Id);
    }
}
