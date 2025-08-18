using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IManageTapeMachineRepository
    {
        #region Machine Assign
        Task<int> SaveMachineAssign(MachineAssign_Request parameters);
        Task<IEnumerable<MachineAssign_Response>> GetMachineAssignList(MachineAssign_Search parameters);

        #endregion

        #region Machine Start Stop
        Task<int> SaveMachineStartStop(MachineStartStop_Request parameters);
        Task<IEnumerable<MachineStartStop_Response>> GetMachineStartStopList(MachineStartStop_Search parameters);
        #endregion

        #region Machine remarks
        Task<int> SaveTapeMachineRemarks(TapeMachineRemarks_Request parameters);
        Task<IEnumerable<TapeMachineRemarks_Response>> GetTapeMachineRemarksList(TapeMachineRemarks_Search parameters);
        Task<TapeMachineRemarks_Response?> GetTapeMachineRemarksById(int Id);
        #endregion

        #region Employee List for Assign
        Task<IEnumerable<EmployeeListForAssignMachine_Response>> GetEmployeeListForAssignMachine(EmployeeListForAssignMachine_Search parameters);

        #endregion
    }
}
