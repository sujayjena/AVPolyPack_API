using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageLaminationRepository
    {
        #region Lamination
        Task<int> SaveLamination(Lamination_Request parameters);
        Task<IEnumerable<Lamination_Response>> GetLaminationList(Lamination_Search parameters);
        Task<Lamination_Response?> GetLaminationById(int Id);
        #endregion

        #region Consumption
        Task<int> SaveConsumption_Lamination(Consumption_Lamination_Request parameters);
        Task<IEnumerable<Consumption_Lamination_Response>> GetConsumption_LaminationList(Consumption_Lamination_Search parameters);
        Task<Consumption_Lamination_Response?> GetConsumption_LaminationById(int Id);
        #endregion

        #region Waste Material
        Task<int> SaveWasteMaterial_Lamination(WasteMaterial_Lamination_Request parameters);
        Task<IEnumerable<WasteMaterial_Lamination_Response>> GetWasteMaterial_LaminationList(WasteMaterial_Lamination_Search parameters);
        Task<WasteMaterial_Lamination_Response?> GetWasteMaterial_LaminationById(int Id);
        #endregion

        #region AvgGSM Entry
        Task<int> SaveAvgGSMEntry_Lamination(AvgGSMEntry_Lamination_Request parameters);
        Task<IEnumerable<AvgGSMEntry_Lamination_Response>> GetAvgGSMEntry_LaminationList(AvgGSMEntry_Lamination_Search parameters);
        Task<AvgGSMEntry_Lamination_Response?> GetAvgGSMEntry_LaminationById(int Id);
        #endregion

        #region Strength Entry
        Task<int> SaveStrengthEntry_Lamination(StrengthEntry_Lamination_Request parameters);
        Task<IEnumerable<StrengthEntry_Lamination_Response>> GetStrengthEntry_LaminationList(StrengthEntry_Lamination_Search parameters);
        Task<StrengthEntry_Lamination_Response?> GetStrengthEntry_LaminationById(int Id);
        #endregion
    }
}
