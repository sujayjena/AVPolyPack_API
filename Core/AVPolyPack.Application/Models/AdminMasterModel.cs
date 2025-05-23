﻿using AVPolyPack.Domain.Entities;
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
    #region Blood Group
    public class BloodGroup_Search : BaseSearchEntity
    {
    }

    public class BloodGroup_Request : BaseEntity
    {
        public string? BloodGroup { get; set; }
        public bool? IsActive { get; set; }
    }

    public class BloodGroup_Response : BaseResponseEntity
    {
        public string? BloodGroup { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Company Type

    public class CompanyType_Search : BaseSearchEntity
    {
    }

    public class CompanyType_Request : BaseEntity
    {
        public string? CompanyType { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CompanyType_Response : BaseResponseEntity
    {
        public string? CompanyType { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Employee Level
    public class EmployeeLevel_Search : BaseSearchEntity
    {
    }

    public class EmployeeLevel_Request : BaseEntity
    {
        public string? EmployeeLevel { get; set; }
        public bool? IsActive { get; set; }
    }

    public class EmployeeLevel_Response : BaseResponseEntity
    {
        public string? EmployeeLevel { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Gender
    public class Gender_Search : BaseSearchEntity
    {
    }

    public class Gender_Request : BaseEntity
    {
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Gender_Response : BaseResponseEntity
    {
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region MaritalStatus
    public class MaritalStatus_Search : BaseSearchEntity
    {
    }

    public class MaritalStatus_Request : BaseEntity
    {
        public string? MaritalStatus { get; set; }
        public bool? IsActive { get; set; }
    }

    public class MaritalStatus_Response : BaseResponseEntity
    {
        public string? MaritalStatus { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Loom
    public class Loom_Search : BaseSearchEntity
    {
    }

    public class Loom_Request : BaseEntity
    {
        public string? LoomName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Loom_Response : BaseResponseEntity
    {
        public string? LoomName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Size
    public class Size_Search : BaseSearchEntity
    {
    }

    public class Size_Request : BaseEntity
    {
        public int? SizeType { get; set; }
        public string? SizeName { get; set; }
        public decimal? SizeInInch { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Size_Response : BaseResponseEntity
    {
        public int? SizeType { get; set; }
        public string? SizeName { get; set; }
        public decimal? SizeInInch { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Gram
    public class Gram_Search : BaseSearchEntity
    {
    }

    public class Gram_Request : BaseEntity
    {
        public string? GramName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Gram_Response : BaseResponseEntity
    {
        public string? GramName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Mesh
    public class Mesh_Search : BaseSearchEntity
    {
    }

    public class Mesh_Request : BaseEntity
    {
        public string? MeshName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Mesh_Response : BaseResponseEntity
    {
        public string? MeshName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Specification
    public class Specification_Search : BaseSearchEntity
    {
    }

    public class Specification_Request : BaseEntity
    {
        public string? SpecificationName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Specification_Response : BaseResponseEntity
    {
        public string? SpecificationName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Type
    public class Type_Search : BaseSearchEntity
    {
    }

    public class Type_Request : BaseEntity
    {
        public string? TypeName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Type_Response : BaseResponseEntity
    {
        public string? TypeName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region GSM
    public class GSM_Search : BaseSearchEntity
    {
    }

    public class GSM_Request : BaseEntity
    {
        public string? GSMName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class GSM_Response : BaseResponseEntity
    {
        public string? GSMName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Strength
    public class Strength_Search : BaseSearchEntity
    {
    }

    public class Strength_Request : BaseEntity
    {
        public string? StrengthName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Strength_Response : BaseResponseEntity
    {
        public string? StrengthName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region LaminationType
    public class LaminationType_Search : BaseSearchEntity
    {
    }

    public class LaminationType_Request : BaseEntity
    {
        public string? LaminationTypeName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class LaminationType_Response : BaseResponseEntity
    {
        public string? LaminationTypeName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Bank
    public class Bank_Search : BaseSearchEntity
    {
    }

    public class Bank_Request : BaseEntity
    {
        public string? BankName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Bank_Response : BaseResponseEntity
    {
        public string? BankName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Product
    public class Product_Search : BaseSearchEntity
    {
    }

    public class Product_Request : BaseEntity
    {
        public string? ProductName { get; set; }
        public int? ProductTypeId { get; set; }
        public bool? IsImage { get; set; }
        public string? ImageOriginalFileName { get; set; }

        [JsonIgnore]
        public string? ImageFileName { get; set; }
        public string? Image_Base64 { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Product_Response : BaseResponseEntity
    {
        public string? ProductName { get; set; }
        public int? ProductTypeId { get; set; }
        public string? ProductType { get; set; }
        public bool? IsImage { get; set; }
        public string? ImageOriginalFileName { get; set; }
        public string? ImageFileName { get; set; }
        public string? ImageFileURL { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Cutting Machine
    public class CuttingMachine_Search : BaseSearchEntity
    {
    }

    public class CuttingMachine_Request : BaseEntity
    {
        public string? MachineName { get; set; }
        public string? Descriptions { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CuttingMachine_Response : BaseResponseEntity
    {
        public string? MachineName { get; set; }
        public string? Descriptions { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Cutting2
    public class Cutting2_Search : BaseSearchEntity
    {
    }

    public class Cutting2_Request : BaseEntity
    {
        public string? Cutting2Name { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Cutting2_Response : BaseResponseEntity
    {
        public string? Cutting2Name { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Liner
    public class Liner_Search : BaseSearchEntity
    {
    }

    public class Liner_Request : BaseEntity
    {
        public string? LinerName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Liner_Response : BaseResponseEntity
    {
        public string? LinerName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Guzzet
    public class Guzzet_Search : BaseSearchEntity
    {
    }

    public class Guzzet_Request : BaseEntity
    {
        public string? GuzzetName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Guzzet_Response : BaseResponseEntity
    {
        public string? GuzzetName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Bottom
    public class Bottom_Search : BaseSearchEntity
    {
    }

    public class Bottom_Request : BaseEntity
    {
        public string? BottomName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Bottom_Response : BaseResponseEntity
    {
        public string? BottomName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Stich
    public class Stich_Search : BaseSearchEntity
    {
    }

    public class Stich_Request : BaseEntity
    {
        public string? StichName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Stich_Response : BaseResponseEntity
    {
        public string? StichName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Color
    public class Color_Search : BaseSearchEntity
    {
    }

    public class Color_Request : BaseEntity
    {
        public string? ColorName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Color_Response : BaseResponseEntity
    {
        public string? ColorName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region ItemNumber
    public class ItemNumber_Search : BaseSearchEntity
    {
    }

    public class ItemNumber_Request : BaseEntity
    {
        public string? ItemNumber { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ItemNumber_Response : BaseResponseEntity
    {
        public string? ItemNumber { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Material
    public class Material_Search : BaseSearchEntity
    {
    }

    public class Material_Request : BaseEntity
    {
        public string? MaterialName { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Material_Response : BaseResponseEntity
    {
        public string? MaterialName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Material Type
    public class MaterialType_Search : BaseSearchEntity
    {
    }

    public class MaterialType_Request : BaseEntity
    {
        public string? MaterialType { get; set; }
        public bool? IsActive { get; set; }
    }

    public class MaterialType_Response : BaseResponseEntity
    {
        public string? MaterialType { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region UOM
    public class UOM_Search : BaseSearchEntity
    {
    }

    public class UOM_Request : BaseEntity
    {
        public string? UOMName { get; set; }
        public string? UOMDesc { get; set; }
        public bool? IsActive { get; set; }
    }

    public class UOM_Response : BaseResponseEntity
    {
        public string? UOMName { get; set; }
        public string? UOMDesc { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Material Master
    public class MaterialMaster_Search : BaseSearchEntity
    {
    }

    public class MaterialMaster_Request : BaseEntity
    {
        public int? MaterialId { get; set; }
        public int? MaterialTypeId { get; set; }
        public int? UOMId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class MaterialMaster_Response : BaseResponseEntity
    {
        public int? MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public int? MaterialTypeId { get; set; }
        public string? MaterialType { get; set; }
        public int? UOMId { get; set; }
        public string? UOMName { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Material Details
    public class MaterialDetails_Search : BaseSearchEntity
    {
    }

    public class MaterialDetails_Request : BaseEntity
    {
        public int? MaterialId { get; set; }
        public int? MaterialTypeId { get; set; }
        public int? UOMId { get; set; }
        public decimal? MinQty { get; set; }
        public decimal? AvailableMaterial { get; set; }
        public bool? IsActive { get; set; }
    }

    public class MaterialDetails_Response : BaseResponseEntity
    {
        public int? MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public int? MaterialTypeId { get; set; }
        public string? MaterialType { get; set; }
        public int? UOMId { get; set; }
        public string? UOMName { get; set; }
        public decimal? MinQty { get; set; }
        public decimal? AvailableMaterial { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Product Type
    public class ProductType_Search : BaseSearchEntity
    {
    }

    public class ProductType_Request : BaseEntity
    {
        public string? ProductType { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ProductType_Response : BaseResponseEntity
    {
        public string? ProductType { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Payment Term
    public class PaymentTerm_Search : BaseSearchEntity
    {
    }

    public class PaymentTerm_Request : BaseEntity
    {
        public string? PaymentTerm { get; set; }
        public bool? IsActive { get; set; }
    }

    public class PaymentTerm_Response : BaseResponseEntity
    {
        public string? PaymentTerm { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion
}
