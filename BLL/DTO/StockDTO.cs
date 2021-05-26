using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class StockDTO
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal SellPrice { get; set; }
    }
}
