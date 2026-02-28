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
    public class ManageOrderRepository : GenericRepository, IManageOrderRepository
    {
        private IConfiguration _configuration;

        public ManageOrderRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Order
        public async Task<int> SaveOrder(Order_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderType", parameters.OrderType);
            queryParameters.Add("@CustomerId", parameters.CustomerId);
            queryParameters.Add("@PONumber", parameters.PONumber);
            queryParameters.Add("@PODate", parameters.PODate);
            queryParameters.Add("@POAttachmentOriginalFileName", parameters.POAttachmentOriginalFileName);
            queryParameters.Add("@POAttachmentFileName", parameters.POAttachmentFileName);
            queryParameters.Add("@OrderNumber", parameters.OrderNumber);
            queryParameters.Add("@OrderDate", parameters.OrderDate);
            queryParameters.Add("@DeliveryDate", parameters.DeliveryDate);
            queryParameters.Add("@PaymentTermId", parameters.PaymentTermId);
            queryParameters.Add("@StatusId", parameters.StatusId);
            queryParameters.Add("@BillingAddressId", parameters.BillingAddressId);
            queryParameters.Add("@ShippingAddressId", parameters.ShippingAddressId);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveOrder", queryParameters);
        }

        public async Task<IEnumerable<Order_Response>> GetOrderList(Order_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@StatusId", parameters.StatusId);
            queryParameters.Add("@OrderType", parameters.OrderType);
            queryParameters.Add("@CustomerId", parameters.CustomerId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Order_Response>("GetOrderList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Order_Response?> GetOrderById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Order_Response>("GetOrderById", queryParameters)).FirstOrDefault();
        }

        #endregion

        #region Order Item
        public async Task<int> SaveOrderItem(OrderItem_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderId", parameters.OrderId);
            queryParameters.Add("@OrderItemNo", parameters.OrderItemNo);
            queryParameters.Add("@ProductId", parameters.ProductId);
            queryParameters.Add("@Mixing", parameters.Mixing);
            queryParameters.Add("@PP", parameters.PP);
            queryParameters.Add("@CC", parameters.CC);
            queryParameters.Add("@UV", parameters.UV);
            queryParameters.Add("@TPT", parameters.TPT);
            queryParameters.Add("@Brightner", parameters.Brightner);
            queryParameters.Add("@Color", parameters.Color);
            queryParameters.Add("@MeasurementType", parameters.MeasurementType);
            queryParameters.Add("@Size", parameters.Size);
            queryParameters.Add("@GSM", parameters.GSM);
            queryParameters.Add("@GPM", parameters.GPM);
            queryParameters.Add("@Average", parameters.Average);
            queryParameters.Add("@Gram", parameters.Gram);
            queryParameters.Add("@MeshId", parameters.MeshId);
            queryParameters.Add("@TypeId", parameters.TypeId);
            queryParameters.Add("@SpecificationId", parameters.SpecificationId);
            queryParameters.Add("@Strength", parameters.Strength);
            queryParameters.Add("@IsGuzzet", parameters.IsGuzzet);
            queryParameters.Add("@Guzzet", parameters.Guzzet);
            queryParameters.Add("@Quantity", parameters.Quantity);
            queryParameters.Add("@Meter", parameters.Meter);
            queryParameters.Add("@IsLab", parameters.IsLab);
            queryParameters.Add("@IsLamination", parameters.IsLamination);
            queryParameters.Add("@LaminationCoatingGSM", parameters.LaminationCoatingGSM);
            queryParameters.Add("@LaminationTypeId", parameters.LaminationTypeId);
            queryParameters.Add("@IsInventory", parameters.IsInventory);
            queryParameters.Add("@OrderRemarks", parameters.OrderRemarks);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@FabricColor", parameters.FabricColor);
            queryParameters.Add("@FabricInMeter", parameters.FabricInMeter);
            queryParameters.Add("@FabricAvg", parameters.FabricAvg);
            queryParameters.Add("@FabricGram", parameters.FabricGram);
            queryParameters.Add("@FabricGSM", parameters.FabricGSM);
            queryParameters.Add("@FabricQuantity", parameters.FabricQuantity);
            queryParameters.Add("@BagSizeWidth", parameters.BagSizeWidth);
            queryParameters.Add("@BagSizeLength", parameters.BagSizeLength);
            queryParameters.Add("@BagWeight", parameters.BagWeight);
            queryParameters.Add("@BagQuantity", parameters.BagQuantity);
            queryParameters.Add("@RatePerPcs", parameters.RatePerPcs);
            queryParameters.Add("@IsHemming", parameters.IsHemming);
            queryParameters.Add("@ButtomFold", parameters.ButtomFold);
            queryParameters.Add("@ButtomStich", parameters.ButtomStich);
            queryParameters.Add("@StichingYarnColor", parameters.StichingYarnColor);
            queryParameters.Add("@IsBOPPBag", parameters.IsBOPPBag);
            queryParameters.Add("@PrintingMatter", parameters.PrintingMatter);
            queryParameters.Add("@IsLiner", parameters.IsLiner);
            queryParameters.Add("@TypeOfLiner", parameters.TypeOfLiner);
            queryParameters.Add("@LinerType", parameters.LinerType);
            queryParameters.Add("@LinerWeight", parameters.LinerWeight);
            queryParameters.Add("@IsLinerUV", parameters.IsLinerUV);
            queryParameters.Add("@IsLinerStiching", parameters.IsLinerStiching);
            queryParameters.Add("@LinerSize", parameters.LinerSize);
            queryParameters.Add("@IsPrinting", parameters.IsPrinting);
            queryParameters.Add("@TotalColor", parameters.TotalColor);
            queryParameters.Add("@PrintingSide", parameters.PrintingSide);
            queryParameters.Add("@IsCutting", parameters.IsCutting);
            queryParameters.Add("@CuttingType", parameters.CuttingType);
            queryParameters.Add("@SubCuttingType", parameters.SubCuttingType);
            queryParameters.Add("@IsPacking", parameters.IsPacking);
            queryParameters.Add("@PerBallPcs", parameters.PerBallPcs);
            queryParameters.Add("@PerBallBundle", parameters.PerBallBundle);
            queryParameters.Add("@PerBundlePcs", parameters.PerBundlePcs);
            queryParameters.Add("@PerBallWeight", parameters.PerBallWeight);
            queryParameters.Add("@FrontSideUploadOriginalFileName", parameters.FrontSideUploadOriginalFileName);
            queryParameters.Add("@FrontSideUploadFileName", parameters.FrontSideUploadFileName);
            queryParameters.Add("@BackSideUploadOriginalFileName", parameters.BackSideUploadOriginalFileName);
            queryParameters.Add("@BackSideUploadFileName", parameters.BackSideUploadFileName);
            queryParameters.Add("@TopPhotoOriginalFileName", parameters.TopPhotoOriginalFileName);
            queryParameters.Add("@TopPhotoFileName", parameters.TopPhotoFileName);
            queryParameters.Add("@BottomPhotoOriginalFileName", parameters.BottomPhotoOriginalFileName);
            queryParameters.Add("@BottomPhotoFileName", parameters.BottomPhotoFileName);
            queryParameters.Add("@IsUVStabilized", parameters.IsUVStabilized);
            queryParameters.Add("@UVPercentage", parameters.UVPercentage);
            queryParameters.Add("@IsFolding", parameters.IsFolding);
            queryParameters.Add("@FoldingSize", parameters.FoldingSize);
            queryParameters.Add("@IsAntiSlip", parameters.IsAntiSlip);
            queryParameters.Add("@RollPackingType", parameters.RollPackingType);
            queryParameters.Add("@SpecialMarking", parameters.SpecialMarking);
            queryParameters.Add("@AdditionalInstruction", parameters.AdditionalInstruction);
            queryParameters.Add("@NetWeight", parameters.NetWeight);
            queryParameters.Add("@BagName", parameters.BagName);
            queryParameters.Add("@PackingType1", parameters.PackingType1);
            queryParameters.Add("@PackingType2", parameters.PackingType2);
            queryParameters.Add("@RollLength", parameters.RollLength);
            queryParameters.Add("@EstimatedWeight", parameters.EstimatedWeight);
            queryParameters.Add("@IsGSM", parameters.IsGSM);
            queryParameters.Add("@LaminationCoatingAvg", parameters.LaminationCoatingAvg);
            queryParameters.Add("@LaminationAvg", parameters.LaminationAvg);
            queryParameters.Add("@TopType", parameters.TopType);
            queryParameters.Add("@TapeWidth", parameters.TapeWidth);
            queryParameters.Add("@ELongation", parameters.ELongation);
            queryParameters.Add("@MeterTarget", parameters.MeterTarget);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveOrderItem", queryParameters);
        }

        public async Task<IEnumerable<OrderItem_Response>> GetOrderItemList(OrderItem_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@OrderId", parameters.OrderId);
            queryParameters.Add("@OrderType", parameters.OrderType);
            queryParameters.Add("@IsAssignLoom", parameters.IsAssignLoom);
            queryParameters.Add("@CustomerId", parameters.CustomerId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<OrderItem_Response>("GetOrderItemList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<OrderItem_Response?> GetOrderItemById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<OrderItem_Response>("GetOrderItemById", queryParameters)).FirstOrDefault();
        }

        public async Task<int> DeleteOrderItem(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return await SaveByStoredProcedure<int>("DeleteOrderItem", queryParameters);
        }

        #endregion

        #region Order Item Looms
        public async Task<int> SaveOrderItem_Looms(OrderItem_Looms_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderItemId", parameters.OrderItemId);
            queryParameters.Add("@LoomAssignNo", parameters.LoomAssignNo);
            queryParameters.Add("@LoomId", parameters.LoomId);
            queryParameters.Add("@IsCompletetd", parameters.IsCompletetd);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveOrderItem_Looms", queryParameters);
        }

        public async Task<IEnumerable<OrderItem_LoomsList_Response>> GetOrderItem_LoomsList(OrderItem_LoomsList_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@OrderItemId", parameters.OrderItemId);
            queryParameters.Add("@OrderType", parameters.OrderType);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<OrderItem_LoomsList_Response>("GetOrderItem_LoomsList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<IEnumerable<OrderItem_Looms_Response>> GetOrderItem_LoomsById(OrderItem_Looms_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderItemId", parameters.OrderItemId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<OrderItem_Looms_Response>("GetOrderItem_LoomsById", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<int> DeleteOrderItem_Looms(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return await SaveByStoredProcedure<int>("DeleteOrderItem_Looms", queryParameters);
        }
        #endregion

        #region Order Item Looms Rolls
        public async Task<int> SaveOrderItem_Looms_Rolls(OrderItem_Looms_Rolls_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderItem_LoomsId", parameters.OrderItem_LoomsId);
            queryParameters.Add("@RollNo", parameters.RollNo);
            queryParameters.Add("@GrossWeight", parameters.GrossWeight);
            queryParameters.Add("@TareWeight", parameters.TareWeight);
            queryParameters.Add("@NetWeight", parameters.NetWeight);
            queryParameters.Add("@StartReading", parameters.StartReading);
            queryParameters.Add("@EndReading", parameters.EndReading);
            queryParameters.Add("@Diff", parameters.Diff);
            queryParameters.Add("@IsCompletetd", parameters.IsCompletetd);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveOrderItem_Looms_Rolls", queryParameters);
        }

        public async Task<IEnumerable<OrderItem_Looms_Rolls_List_Response>> GetOrderItem_Looms_Rolls_List(OrderItem_Looms_Rolls_List_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@OrderItemId", parameters.OrderItemId);
            queryParameters.Add("@OrderType", parameters.OrderType);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<OrderItem_Looms_Rolls_List_Response>("GetOrderItem_Looms_Rolls_List", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<IEnumerable<OrderItem_Looms_Rolls_Response>> GetOrderItem_Looms_Rolls_ById(OrderItem_Looms_Rolls_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderItemId", parameters.OrderItemId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<OrderItem_Looms_Rolls_Response>("GetOrderItem_Looms_Rolls_ById", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<int> DeleteOrderItem_Looms_Rolls(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return await SaveByStoredProcedure<int>("DeleteOrderItem_Looms_Rolls", queryParameters);
        }
        #endregion
    }
}
