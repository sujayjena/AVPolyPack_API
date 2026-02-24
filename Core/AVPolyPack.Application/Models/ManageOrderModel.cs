using AVPolyPack.Domain.Entities;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    #region Order
    public class Order_Search : BaseSearchEntity
    {
        public int? StatusId { get; set; }
        public int? OrderType { get; set; }
        public int? CustomerId { get; set; }
    }

    public class Order_Request : BaseEntity
    {
        public Order_Request()
        {
            orderItemList = new List<OrderItem_Request>();
        }
        public int? OrderType { get; set; }
        public int? CustomerId { get; set; }
        public string? PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public string? POAttachmentOriginalFileName { get; set; }
        public string? POAttachmentFileName { get; set; }
        public string? POAttachment_Base64 { get; set; }

        public string? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? PaymentTermId { get; set; }
        public int? StatusId { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }

        public List<OrderItem_Request> orderItemList { get; set; }
    }

    public class Order_Response : BaseResponseEntity
    {
        public Order_Response()
        {
            orderItemList = new List<OrderItem_Response>();
        }
        public int? OrderType { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public string? POAttachmentOriginalFileName { get; set; }
        public string? POAttachmentFileName { get; set; }
        public string? POAttachment_URL { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? SLAStatus { get; set; }
        public int? StatusId { get; set; }
        public int? BillingAddressId { get; set; }
        public int? BillingIsNational_Or_International { get; set; }
        public string? BillingAddress1 { get; set; }
        public int? BillingCountryId { get; set; }
        public string? BillingCountryName { get; set; }
        public int? BillingStateId { get; set; }
        public string? BillingStateName { get; set; }
        public int? BillingDistrictId { get; set; }
        public string? BillingDistrictName { get; set; }
        public int? BillingCityId { get; set; }
        public string? BillingCityName { get; set; }
        public string? BillingPinCode { get; set; }
        public int? ShippingAddressId { get; set; }
        public int? ShippingIsNational_Or_International { get; set; }
        public string? ShippingAddress1 { get; set; }
        public int? ShippingCountryId { get; set; }
        public string? ShippingCountryName { get; set; }
        public int? ShippingStateId { get; set; }
        public string? ShippingStateName { get; set; }
        public int? ShippingDistrictId { get; set; }
        public string? ShippingDistrictName { get; set; }
        public int? ShippingCityId { get; set; }
        public string? ShippingCityName { get; set; }
        public string? ShippingPinCode { get; set; }
        public List<OrderItem_Response> orderItemList { get; set; }
    }
    #endregion

    #region Order Item
    public class OrderItem_Search : BaseSearchEntity
    {
        public int? OrderId { get; set; }
        public int? OrderType { get; set; }
        public int? IsAssignLoom { get; set; }
        public int? CustomerId { get; set; }
    }
    public class OrderItem_Request : BaseEntity
    {
        public int? OrderId { get; set; }
        public string? OrderItemNo { get; set; }
        public int? ProductId { get; set; }
        public string? Mixing { get; set; }
        public string? PP { get; set; }
        public string? CC { get; set; }
        public string? UV { get; set; }
        public string? TPT { get; set; }
        public string? Brightner { get; set; }
        public string? Color { get; set; }
        public int? MeasurementType { get; set; }
        public string? Size { get; set; }
        public string? GSM { get; set; }
        public string? GPM { get; set; }
        public string? Average { get; set; }
        public string? Gram { get; set; }
        public int? MeshId { get; set; }
        public int? TypeId { get; set; }
        public int? SpecificationId { get; set; }
        public string? Strength { get; set; }

        [DefaultValue(false)]
        public bool? IsGuzzet { get; set; }
        public string? Guzzet { get; set; }
        public decimal? Quantity { get; set; }
        public string? Meter { get; set; }

        [DefaultValue(true)]
        public bool? IsLab { get; set; }

        [DefaultValue(false)]
        public bool? IsLamination { get; set; }
        public string? LaminationCoatingGSM { get; set; }
        public int? LaminationTypeId { get; set; }

        [DefaultValue(true)]
        public bool? IsInventory { get; set; }
        public string? OrderRemarks { get; set; }
        public string? Remarks { get; set; }
        public string? FabricColor { get; set; }
        public string? FabricInMeter { get; set; }
        public string? FabricAvg { get; set; }
        public string? FabricGram { get; set; }
        public string? FabricGSM { get; set; }
        public decimal? FabricQuantity { get; set; }
        public string? BagSizeWidth { get; set; }
        public string? BagSizeLength { get; set; }
        public string? BagWeight { get; set; }
        public decimal? BagQuantity { get; set; }
        public decimal? RatePerPcs { get; set; }

        [DefaultValue(false)]
        public bool? IsHemming { get; set; }
        public int? ButtomFold { get; set; }
        public int? ButtomStich { get; set; }
        public string? StichingYarnColor { get; set; }

        [DefaultValue(false)]
        public bool? IsBOPPBag { get; set; }
        public string? PrintingMatter { get; set; }

        [DefaultValue(false)]
        public bool? IsLiner { get; set; }
        public int? TypeOfLiner { get; set; }
        public int? LinerType { get; set; }
        public string? LinerWeight { get; set; }

        [DefaultValue(false)]
        public bool? IsLinerUV { get; set; }

        [DefaultValue(false)]
        public bool? IsLinerStiching { get; set; }
        public string? LinerSize { get; set; }

        [DefaultValue(false)]
        public bool? IsPrinting { get; set; }
        public int? TotalColor { get; set; }
        public int? PrintingSide { get; set; }

        [DefaultValue(false)]
        public bool? IsCutting { get; set; }
        public int? CuttingType { get; set; }
        public int? SubCuttingType { get; set; }

        [DefaultValue(false)]
        public bool? IsPacking { get; set; }
        public string? PerBallPcs { get; set; }
        public string? PerBallBundle { get; set; }
        public string? PerBundlePcs { get; set; }
        public string? PerBallWeight { get; set; }
        public string? FrontSideUploadOriginalFileName { get; set; }
        public string? FrontSideUploadFileName { get; set; }
        public string? FrontSideUpload_Base64 { get; set; }
        public string? BackSideUploadOriginalFileName { get; set; }
        public string? BackSideUploadFileName { get; set; }
        public string? BackSideUpload_Base64 { get; set; }
        public string? TopPhotoOriginalFileName { get; set; }
        public string? TopPhotoFileName { get; set; }
        public string? TopPhoto_Base64 { get; set; }
        public string? BottomPhotoOriginalFileName { get; set; }
        public string? BottomPhotoFileName { get; set; }
        public string? BottomPhoto_Base64 { get; set; }

        [DefaultValue(false)]
        public bool? IsUVStabilized { get; set; }
        public string? UVPercentage { get; set; }

        [DefaultValue(false)]
        public bool? IsFolding { get; set; }
        public string? FoldingSize { get; set; }

        [DefaultValue(false)]
        public bool? IsAntiSlip { get; set; }
        public int? RollPackingType { get; set; }
        public string? SpecialMarking { get; set; }
        public string? AdditionalInstruction { get; set; }
        public decimal? NetWeight { get; set; }
        public string? BagName { get; set; }
        public int? PackingType1 { get; set; }
        public int? PackingType2 { get; set; }
        public string? RollLength { get; set; }
        public decimal? EstimatedWeight { get; set; }

        [DefaultValue(false)]
        public bool? IsGSM { get; set; }
        public decimal? LaminationCoatingAvg { get; set; }
        public decimal? LaminationAvg { get; set; }
        public int? TopType { get; set; }
    }

    public class OrderItem_Response : BaseResponseEntity
    {
        public int? OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? PaymentTermId { get; set; }
        public string? PaymentTerm { get; set; }
        public string? OrderItemNo { get; set; }
        public string? LoomNumber { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Mixing { get; set; }
        public string? PP { get; set; }
        public string? CC { get; set; }
        public string? UV { get; set; }
        public string? TPT { get; set; }
        public string? Brightner { get; set; }
        public string? Color { get; set; }
        public int? MeasurementType { get; set; }
        public string? Size { get; set; }
        public string? GSM { get; set; }
        public string? GPM { get; set; }
        public string? Average { get; set; }
        public string? Gram { get; set; }
        public int? MeshId { get; set; }
        public string? MeshName { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int? SpecificationId { get; set; }
        public string? SpecificationName { get; set; }
        public string? Strength { get; set; }
        public bool? IsGuzzet { get; set; }
        public string? Guzzet { get; set; }
        public decimal? Quantity { get; set; }
        public string? Meter { get; set; }
        public bool? IsLab { get; set; }
        public bool? IsLamination { get; set; }
        public string? LaminationCoatingGSM { get; set; }
        public int? LaminationTypeId { get; set; }
        public string? LaminationTypeName { get; set; }
        public bool? IsInventory { get; set; }
        public string? OrderRemarks { get; set; }
        public string? Remarks { get; set; }
        public string? FabricColor { get; set; }
        public string? FabricInMeter { get; set; }
        public string? FabricAvg { get; set; }
        public string? FabricGram { get; set; }
        public string? FabricGSM { get; set; }
        public decimal? FabricQuantity { get; set; }
        public string? BagSizeWidth { get; set; }
        public string? BagSizeLength { get; set; }
        public string? BagWeight { get; set; }
        public decimal? BagQuantity { get; set; }
        public decimal? RatePerPcs { get; set; }
        public bool? IsHemming { get; set; }
        public int? ButtomFold { get; set; }
        public int? ButtomStich { get; set; }
        public string? StichingYarnColor { get; set; }
        public bool? IsBOPPBag { get; set; }
        public string? PrintingMatter { get; set; }
        public bool? IsLiner { get; set; }
        public int? TypeOfLiner { get; set; }
        public int? LinerType { get; set; }
        public string? LinerWeight { get; set; }
        public bool? IsLinerUV { get; set; }
        public bool? IsLinerStiching { get; set; }
        public string? LinerSize { get; set; }
        public bool? IsPrinting { get; set; }
        public int? TotalColor { get; set; }
        public int? PrintingSide { get; set; }
        public bool? IsCutting { get; set; }
        public int? CuttingType { get; set; }
        public int? SubCuttingType { get; set; }
        public bool? IsPacking { get; set; }
        public string? PerBallPcs { get; set; }
        public string? PerBallBundle { get; set; }
        public string? PerBundlePcs { get; set; }
        public string? PerBallWeight { get; set; }
        public string? FrontSideUploadOriginalFileName { get; set; }
        public string? FrontSideUploadFileName { get; set; }
        public string? FrontSideUpload_URL { get; set; }
        public string? BackSideUploadOriginalFileName { get; set; }
        public string? BackSideUploadFileName { get; set; }
        public string? BackSideUpload_URL { get; set; }
        public string? TopPhotoOriginalFileName { get; set; }
        public string? TopPhotoFileName { get; set; }
        public string? TopPhoto_URL { get; set; }
        public string? BottomPhotoOriginalFileName { get; set; }
        public string? BottomPhotoFileName { get; set; }
        public string? BottomPhoto_URL { get; set; }
        public bool? IsUVStabilized { get; set; }
        public string? UVPercentage { get; set; }
        public bool? IsFolding { get; set; }
        public string? FoldingSize { get; set; }
        public bool? IsAntiSlip { get; set; }
        public int? RollPackingType { get; set; }
        public string? SpecialMarking { get; set; }
        public string? AdditionalInstruction { get; set; }
        public decimal? NetWeight { get; set; }
        public string? BagName { get; set; }
        public int? PackingType1 { get; set; }
        public int? PackingType2 { get; set; }
        public string? RollLength { get; set; }
        public decimal? EstimatedWeight { get; set; }
        public bool? IsGSM { get; set; }
        public decimal? LaminationCoatingAvg { get; set; }
        public decimal? LaminationAvg { get; set; }
        public int? TopType { get; set; }
        public DateTime? OrderItemAssignDateTime { get; set; }
    }
    #endregion

    #region Order Item Looms
    public class OrderItem_Looms_Search : BaseSearchEntity
    {
        public int? Id { get; set; }
        public int? OrderItemId { get; set; }
    }

    public class OrderItem_Looms_List_Request
    {
        public OrderItem_Looms_List_Request()
        {
            OrderItem_Looms_List = new List<OrderItem_Looms_Request>();
        }
        public List<OrderItem_Looms_Request> OrderItem_Looms_List { get; set; }
    }

    public class OrderItem_Looms_Request : BaseEntity
    {
        public int? OrderItemId { get; set; }
        public string? LoomAssignNo { get; set; }
        public int? LoomId { get; set; }

        [DefaultValue(false)]
        public bool? IsCompletetd { get; set; }
    }

    public class OrderItem_Looms_Response : BaseResponseEntity
    {
        public int? OrderItemId { get; set; }
        public string? LoomAssignNo { get; set; }
        public int? LoomId { get; set; }
        public string? LoomName { get; set; }
        public bool? IsCompletetd { get; set; }
        public DateTime? CompletedDate { get; set; }
    }

    public class OrderItem_LoomsList_Search : BaseSearchEntity
    {
        public int? OrderItemId { get; set; }
        public int? OrderType { get; set; }

    }
    public class OrderItem_LoomsList_Response : BaseResponseEntity
    {
        public int? OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? PaymentTermId { get; set; }
        public string? PaymentTerm { get; set; }
        public string? OrderItemNo { get; set; }
        public int? LoomId { get; set; }
        public string? LoomName { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Mixing { get; set; }
        public string? PP { get; set; }
        public string? CC { get; set; }
        public string? UV { get; set; }
        public string? TPT { get; set; }
        public string? Brightner { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? GSM { get; set; }
        public string? GPM { get; set; }
        public string? Average { get; set; }
        public string? Gram { get; set; }
        public string? Mesh { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int? SpecificationId { get; set; }
        public string? SpecificationName { get; set; }
        public string? Strength { get; set; }
        public bool? IsGuzzet { get; set; }
        public string? Guzzet { get; set; }
        public decimal? Quantity { get; set; }
        public string? Meter { get; set; }
        public bool? IsLab { get; set; }
        public bool? IsLamination { get; set; }
        public string? LaminationCoatingGSM { get; set; }
        public int? LaminationTypeId { get; set; }
        public string? LaminationTypeName { get; set; }
        public bool? IsInventory { get; set; }
        public string? OrderRemarks { get; set; }
        public string? Remarks { get; set; }
        public string? FabricColor { get; set; }
        public string? FabricInMeter { get; set; }
        public string? FabricAvg { get; set; }
        public string? FabricGram { get; set; }
        public string? FabricGSM { get; set; }
        public decimal? FabricQuantity { get; set; }
        public string? BagSizeWidth { get; set; }
        public string? BagSizeLength { get; set; }
        public string? BagWeight { get; set; }
        public decimal? BagQuantity { get; set; }
        public decimal? RatePerPcs { get; set; }
        public bool? IsHemming { get; set; }
        public int? ButtomFold { get; set; }
        public int? ButtomStich { get; set; }
        public string? StichingYarnColor { get; set; }
        public bool? IsBOPPBag { get; set; }
        public string? PrintingMatter { get; set; }
        public bool? IsLiner { get; set; }
        public int? LinerType { get; set; }
        public string? LinerWeight { get; set; }
        public bool? IsLinerUV { get; set; }
        public bool? IsLinerStiching { get; set; }
        public string? LinerSize { get; set; }
        public bool? IsPrinting { get; set; }
        public int? TotalColor { get; set; }
        public int? PrintingSide { get; set; }
        public bool? IsCutting { get; set; }
        public int? CuttingType { get; set; }
        public int? SubCuttingType { get; set; }
        public bool? IsPacking { get; set; }
        public string? PerBallPcs { get; set; }
        public string? PerBallBundle { get; set; }
        public string? PerBundlePcs { get; set; }
        public string? PerBallWeight { get; set; }
        public string? FrontSideUploadOriginalFileName { get; set; }
        public string? FrontSideUploadFileName { get; set; }
        public string? FrontSideUpload_URL { get; set; }
        public string? BackSideUploadOriginalFileName { get; set; }
        public string? BackSideUploadFileName { get; set; }
        public string? BackSideUpload_URL { get; set; }
        public string? TopPhotoOriginalFileName { get; set; }
        public string? TopPhotoFileName { get; set; }
        public string? TopPhoto_URL { get; set; }
        public string? BottomPhotoOriginalFileName { get; set; }
        public string? BottomPhotoFileName { get; set; }
        public string? BottomPhoto_URL { get; set; }
    }
    #endregion

    #region Order Item Looms Rolls
    public class OrderItem_Looms_Rolls_Search : BaseSearchEntity
    {
        public int? Id { get; set; }
        public int? OrderItemId { get; set; }
    }
    public class OrderItem_Looms_Rolls_List_Request
    {
        public OrderItem_Looms_Rolls_List_Request()
        {
            OrderItem_Looms_Rolls_List = new List<OrderItem_Looms_Rolls_Request>();
        }
        public List<OrderItem_Looms_Rolls_Request> OrderItem_Looms_Rolls_List { get; set; }
    }
    public class OrderItem_Looms_Rolls_Request : BaseEntity
    {
        public int? OrderItem_LoomsId { get; set; }
        public string? RollNo { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? TareWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? StartReading { get; set; }
        public decimal? EndReading { get; set; }
        public decimal? Diff { get; set; }

        [DefaultValue(false)]
        public bool? IsCompletetd { get; set; }
    }

    public class OrderItem_Looms_Rolls_Response : BaseResponseEntity
    {
        public int? OrderItem_LoomsId { get; set; }
        public string? RollNo { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? TareWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? StartReading { get; set; }
        public decimal? EndReading { get; set; }
        public decimal? Diff { get; set; }
        public bool? IsCompletetd { get; set; }
        public DateTime? CompletedDate { get; set; }
    }

    public class OrderItem_Looms_Rolls_List_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }

        public int? OrderItemId { get; set; }
        public int? OrderType { get; set; }

    }
    public class OrderItem_Looms_Rolls_List_Response : BaseResponseEntity
    {
        public int? OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? PaymentTermId { get; set; }
        public string? PaymentTerm { get; set; }
        public string? OrderItemNo { get; set; }
        public int? LoomId { get; set; }
        public string? LoomName { get; set; }
        public string? RollNo { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Mixing { get; set; }
        public string? PP { get; set; }
        public string? CC { get; set; }
        public string? UV { get; set; }
        public string? TPT { get; set; }
        public string? Brightner { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? GSM { get; set; }
        public string? GPM { get; set; }
        public string? Average { get; set; }
        public string? Gram { get; set; }
        public string? Mesh { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int? SpecificationId { get; set; }
        public string? SpecificationName { get; set; }
        public string? Strength { get; set; }
        public bool? IsGuzzet { get; set; }
        public string? Guzzet { get; set; }
        public decimal? Quantity { get; set; }
        public string? Meter { get; set; }
        public bool? IsLab { get; set; }
        public bool? IsLamination { get; set; }
        public string? LaminationCoatingGSM { get; set; }
        public int? LaminationTypeId { get; set; }
        public string? LaminationTypeName { get; set; }
        public bool? IsInventory { get; set; }
        public string? OrderRemarks { get; set; }
        public string? Remarks { get; set; }
        public string? FabricColor { get; set; }
        public string? FabricInMeter { get; set; }
        public string? FabricAvg { get; set; }
        public string? FabricGram { get; set; }
        public string? FabricGSM { get; set; }
        public decimal? FabricQuantity { get; set; }
        public string? BagSizeWidth { get; set; }
        public string? BagSizeLength { get; set; }
        public string? BagWeight { get; set; }
        public decimal? BagQuantity { get; set; }
        public decimal? RatePerPcs { get; set; }
        public bool? IsHemming { get; set; }
        public int? ButtomFold { get; set; }
        public int? ButtomStich { get; set; }
        public string? StichingYarnColor { get; set; }
        public bool? IsBOPPBag { get; set; }
        public string? PrintingMatter { get; set; }
        public bool? IsLiner { get; set; }
        public int? LinerType { get; set; }
        public string? LinerWeight { get; set; }
        public bool? IsLinerUV { get; set; }
        public bool? IsLinerStiching { get; set; }
        public string? LinerSize { get; set; }
        public bool? IsPrinting { get; set; }
        public int? TotalColor { get; set; }
        public int? PrintingSide { get; set; }
        public bool? IsCutting { get; set; }
        public int? CuttingType { get; set; }
        public int? SubCuttingType { get; set; }
        public bool? IsPacking { get; set; }
        public string? PerBallPcs { get; set; }
        public string? PerBallBundle { get; set; }
        public string? PerBundlePcs { get; set; }
        public string? PerBallWeight { get; set; }
        public string? FrontSideUploadOriginalFileName { get; set; }
        public string? FrontSideUploadFileName { get; set; }
        public string? FrontSideUpload_URL { get; set; }
        public string? BackSideUploadOriginalFileName { get; set; }
        public string? BackSideUploadFileName { get; set; }
        public string? BackSideUpload_URL { get; set; }
        public string? TopPhotoOriginalFileName { get; set; }
        public string? TopPhotoFileName { get; set; }
        public string? TopPhoto_URL { get; set; }
        public string? BottomPhotoOriginalFileName { get; set; }
        public string? BottomPhotoFileName { get; set; }
        public string? BottomPhoto_URL { get; set; }
    }
    #endregion
}
