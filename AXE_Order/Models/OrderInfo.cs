using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXE_Order.Models
{
    public class OrderInfo
    {
        public string CustomerCode { get; set; }
        public string StockCode { get; set; }
        public int Seq { get; set; }
        public int ExecutionVolumn { get; set; }
        public int ExecutionAmount { get; set; }

        public OrderInfo()
        {
            this.CustomerCode = string.Empty;
            this.StockCode = string.Empty;
            this.Seq = 0;
            this.ExecutionVolumn = 0;
            this.ExecutionAmount = 0;

        }
    }
}
