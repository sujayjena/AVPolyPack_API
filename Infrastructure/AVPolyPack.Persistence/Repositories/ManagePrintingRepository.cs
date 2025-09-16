using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Persistence.Repositories
{
    public class ManagePrintingRepository : GenericRepository, IManagePrintingRepository
    {
        private IConfiguration _configuration;

        public ManagePrintingRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SavePrinting(Printing_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@ShiftType", parameters.ShiftType);
            queryParameters.Add("@PrintingMachineId", parameters.PrintingMachineId);
            queryParameters.Add("@PrintingName", parameters.PrintingName);
            queryParameters.Add("@PrintingSize", parameters.PrintingSize);
            queryParameters.Add("@IsCompleted", parameters.IsCompleted);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SavePrinting", queryParameters);
        }

        public async Task<IEnumerable<Printing_Response>> GetPrintingList(Printing_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@RollId", parameters.RollId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Printing_Response>("GetPrintingList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Printing_Response?> GetPrintingById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<Printing_Response>("GetPrintingById", queryParameters)).FirstOrDefault();
        }
    }
}
