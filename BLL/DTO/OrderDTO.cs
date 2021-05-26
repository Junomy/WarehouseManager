using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
        public int WarehouseId { get; set; }
        public decimal Cost { get; set; }
    }
}
