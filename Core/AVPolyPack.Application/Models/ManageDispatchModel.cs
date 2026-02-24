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
    public class Dispatch_Search : BaseSearchEntity
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class Dispatch_Request : BaseEntity
    {
        public string? DispatchNo { get; set; }
        public DateTime? DispatchDate { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public int? OrderItemId { get; set; }
        public string? VehicleNumber { get; set; }
        public string? Remarks { get; set; }

        [DefaultValue(false)]
        public bool? IsDispatch { get; set; }
    }

    public class Dispatch_Response : BaseResponseEntity
    {
        public string? DispatchNo { get; set; }
        public DateTime? DispatchDate { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public int? OrderItemId { get; set; }
        public string? OrderItemNo { get; set; }
        public string? VehicleNumber { get; set; }
        public string? Remarks { get; set; }
        public bool? IsDispatch { get; set; }
    }
}
