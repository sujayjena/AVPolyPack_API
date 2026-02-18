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
    public class SaleRepository : GenericRepository, ISaleRepository
    {
        private IConfiguration _configuration;

        public SaleRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Sale
        public async Task<int> SaveSale(Sale_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@SaleInvoiceDate", parameters.SaleInvoiceDate);
            queryParameters.Add("@SaleInvoiceNo", parameters.SaleInvoiceNo);
            queryParameters.Add("@InvoiceType", parameters.InvoiceType);
            queryParameters.Add("@CustomerId", parameters.CustomerId);
            queryParameters.Add("@VehicleNumber", parameters.VehicleNumber);
            queryParameters.Add("@SubTotal", parameters.SubTotal);
            queryParameters.Add("@TotalCGST", parameters.TotalCGST);
            queryParameters.Add("@TotalSGST", parameters.TotalSGST);
            queryParameters.Add("@TotalIGST", parameters.TotalIGST);
            queryParameters.Add("@RoundOff", parameters.RoundOff);
            queryParameters.Add("@TotalValue", parameters.TotalValue);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveSale", queryParameters);
        }

        public async Task<IEnumerable<SaleList_Response>> GetSaleList(Sale_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<SaleList_Response>("GetSaleList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Sale_Response?> GetSaleById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Sale_Response>("GetSaleById", queryParameters)).FirstOrDefault();
        }

        #endregion

        #region Sale Details
        public async Task<int> SaveSaleDetails(SaleDetails_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@SaleId", parameters.SaleId);
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
            queryParameters.Add("@ShippingBillEntryNo", parameters.ShippingBillEntryNo);
            queryParameters.Add("@ShippingBillEntryDate", parameters.ShippingBillEntryDate);
            queryParameters.Add("@AdvanceLicenseId", parameters.AdvanceLicenseId);
            queryParameters.Add("@Naration", parameters.Naration);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveSaleDetails", queryParameters);
        }
        public async Task<IEnumerable<SaleDetails_Response>> GetSaleDetailsList(SaleDetails_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SaleId", parameters.SaleId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<SaleDetails_Response>("GetSaleDetailsList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        public async Task<int> DeleteSaleDetails(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return await SaveByStoredProcedure<int>("DeleteSaleDetails", queryParameters);
        }
        #endregion
    }
}
