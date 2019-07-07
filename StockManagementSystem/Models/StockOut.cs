using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.Models
{
    [Serializable]
    public class StockOut
    {
        public int StockOutId { get; set; }
        public int ItemId { get; set; }
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public int StockOutQuantity { get; set; }

        public string Flag { get; set; }
        public DateTime StockOutDate { get; set; }
    }
}