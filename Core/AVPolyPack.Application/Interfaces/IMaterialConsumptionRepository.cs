using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IMaterialConsumptionRepository
    {
        #region Consumption
        Task<int> SaveConsumption(Consumption_Request parameters);
        Task<IEnumerable<Consumption_Response>> GetConsumptionList(Consumption_Search parameters);
        Task<Consumption_Response?> GetConsumptionById(int Id);
        #endregion

        #region Waste Material
        Task<int> SaveWasteMaterial(WasteMaterial_Request parameters);
        Task<IEnumerable<WasteMaterial_Response>> GetWasteMaterialList(WasteMaterial_Search parameters);
        Task<WasteMaterial_Response?> GetWasteMaterialById(int Id);
        #endregion
    }
}
