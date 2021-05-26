using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Stock
    {
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Amount { get; set; }
        public decimal SellPrice { get; set; }
    }
}
