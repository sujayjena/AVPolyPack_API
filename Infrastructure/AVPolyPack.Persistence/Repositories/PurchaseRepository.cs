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
    public class PurchaseRepository : GenericRepository, IPurchaseRepository
    {
        private IConfiguration _configuration;

        public PurchaseRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Purchase
        public async Task<int> SavePurchase(Purchase_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@PurchaseDate", parameters.PurchaseDate);
            queryParameters.Add("@PurchaseNumber", parameters.PurchaseNumber);
            queryParameters.Add("@PurchaseInvoiceNo", parameters.PurchaseInvoiceNo);
            queryParameters.Add("@PurchaseInvoiceDate", parameters.PurchaseInvoiceDate);
            queryParameters.Add("@InvoiceType", parameters.InvoiceType);
            queryParameters.Add("@SupplierId", parameters.SupplierId);
            queryParameters.Add("@VehicleNumber", parameters.VehicleNumber);
            queryParameters.Add("@SubTotal", parameters.SubTotal);
            queryParameters.Add("@TotalCGST", parameters.TotalCGST);
            queryParameters.Add("@TotalSGST", parameters.TotalSGST);
            queryParameters.Add("@TotalIGST", parameters.TotalIGST);
            queryParameters.Add("@RoundOff", parameters.RoundOff);
            queryParameters.Add("@TotalValue", parameters.TotalValue);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SavePurchase", queryParameters);
        }

        public async Task<IEnumerable<PurchaseList_Response>> GetPurchaseList(Purchase_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<PurchaseList_Response>("GetPurchaseList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Purchase_Response?> GetPurchaseById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Purchase_Response>("GetPurchaseById", queryParameters)).FirstOrDefault();
        }

        #endregion

        #region Purchase Details
        public async Task<int> SavePurchaseDetails(PurchaseDetails_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@PurchaseId", parameters.PurchaseId);
            queryParameters.Add("@MaterialTypeId", parameters.MaterialTypeId);
            queryParameters.Add("@MaterialDetailsId", parameters.MaterialDetailsId);
            queryParameters.Add("@OtherDetails", parameters.OtherDetails);
            queryParameters.Add("@Quantity", parameters.Quantity);
            queryParameters.Add("@Rate", parameters.Rate);
            queryParameters.Add("@Discount", parameters.Discount);
            queryParameters.Add("@ExtraCharge", parameters.ExtraCharge);
            queryParameters.Add("@Freight", parameters.Freight);
            queryParameters.Add("@TaxableValue", parameters.TaxableValue);
            queryParameters.Add("@IsCGST", parameters.IsCGST);
            queryParameters.Add("@CGSTPerct", parameters.CGSTPerct);
            queryParameters.Add("@CGSTAmt", parameters.CGSTAmt);
            queryParameters.Add("@IsSGST", parameters.IsSGST);
            queryParameters.Add("@SGSTPerct", parameters.SGSTPerct);
            queryParameters.Add("@SGSTAmt", parameters.SGSTAmt);
            queryParameters.Add("@IsIGST", parameters.IsIGST);
            queryParameters.Add("@IGSTPerct", parameters.IGSTPerct);
            queryParameters.Add("@IGSTAmt", parameters.IGSTAmt);
            queryParameters.Add("@RoundOff", parameters.RoundOff);
            queryParameters.Add("@BillEntryNo", parameters.BillEntryNo);
            queryParameters.Add("@BillEntryDate", parameters.BillEntryDate);
            queryParameters.Add("@AdvanceLicenseId", parameters.AdvanceLicenseId);
            queryParameters.Add("@Naration", parameters.Naration);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SavePurchaseDetails", queryParameters);
        }
        public async Task<IEnumerable<PurchaseDetails_Response>> GetPurchaseDetailsList(PurchaseDetails_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@PurchaseId", parameters.PurchaseId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<PurchaseDetails_Response>("GetPurchaseDetailsList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        public async Task<int> DeletePurchaseDetails(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return await SaveByStoredProcedure<int>("DeletePurchaseDetails", queryParameters);
        }
        #endregion
    }
}

