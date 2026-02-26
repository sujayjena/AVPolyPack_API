using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Models
{
    public class Dashboard_OutwardingStock_Search
    {
       
    }

    public class Dashboard_OutwardingStock_Response
    {
        public int? TotalLabTestCount { get; set; }
        public int? TotalLaminationCount { get; set; }
        public int? TotalLaminationLabTestCount { get; set; }
        public int? TotalPrintingCount { get; set; }
        public int? TotalCuttingCount { get; set; }
        public int? TotalInventoryCount { get; set; }
        //public int? TotalCount { get; set; }
    }

    public class Dashboard_Roll_Response
    {
        public int? TotalRoll_PendingPickupCount { get; set; }
        public int? TotalRoll_CurrentStockCount { get; set; }
        public int? TotalRoll_OutwardingCount { get; set; }

        public int? TotalLabTest_PendingPickupCount { get; set; }
        public int? TotalLabTest_CurrentStockCount { get; set; }
        public int? TotalLabTest_OutwardingCount { get; set; }

        public int? TotalLamination_PendingPickupCount { get; set; }
        public int? TotalLamination_CurrentStockCount { get; set; }
        public int? TotalLamination_OutwardingCount { get; set; }

        public int? TotalLaminationLabTest_PendingPickupCount { get; set; }
        public int? TotalLaminationLabTest_CurrentStockCount { get; set; }
        public int? TotalLaminationLabTest_OutwardingCount { get; set; }

        public int? TotalPrinting_PendingPickupCount { get; set; }
        public int? TotalPrinting_CurrentStockCount { get; set; }
        public int? TotalPrinting_OutwardingCount { get; set; }

        public int? TotalCutting_PendingPickupCount { get; set; }
        public int? TotalCutting_CurrentStockCount { get; set; }
        public int? TotalCutting_OutwardingCount { get; set; }

        public int? TotalInventory_PendingPickupCount { get; set; }
        public int? TotalInventory_CurrentStockCount { get; set; }
        public int? TotalInventory_OutwardingCount { get; set; }

        public int? TotalSplit_PendingCount { get; set; }
        public int? TotalMerge_PendingCount { get; set; }
        public int? TotalDispatch_PendingCount { get; set; }
    }
}
