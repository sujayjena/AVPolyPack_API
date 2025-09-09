using AVPolyPack.Domain.Entities;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    #region Mesh Entry
    public class MeshEntry_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
    public class MeshEntry_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public string? RequiredMesh { get; set; }
        public string? ActualMesh { get; set; }
    }

    public class MeshEntry_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public string? RequiredMesh { get; set; }
        public string? ActualMesh { get; set; }
    }
    #endregion

    #region AvgGSM Entry
    public class AvgGSMEntry_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
    public class AvgGSMEntry_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public string? RequiredAvg { get; set; }
        public string? RequiredGSM { get; set; }
        public string? ActualAvg { get; set; }
        public string? ActualGSM { get; set; }
    }

    public class AvgGSMEntry_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public string? RequiredAvg { get; set; }
        public string? RequiredGSM { get; set; }
        public string? ActualAvg { get; set; }
        public string? ActualGSM { get; set; }
    }
    #endregion

    #region Strength Entry
    public class StrengthEntry_Search : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
    public class StrengthEntry_Request : BaseEntity
    {
        public int? RollId { get; set; }
        public string? RequiredStrength { get; set; }
        public string? WARP { get; set; }
        public string? WARP_ELO { get; set; }
        public string? WEFT { get; set; }
        public string? WEFT_ELO { get; set; }
    }

    public class StrengthEntry_Response : BaseResponseEntity
    {
        public int? RollId { get; set; }
        public string? RollNo { get; set; }
        public string? RollCode { get; set; }
        public string? RequiredStrength { get; set; }
        public string? WARP { get; set; }
        public string? WARP_ELO { get; set; }
        public string? WEFT { get; set; }
        public string? WEFT_ELO { get; set; }
    }
    #endregion
}
