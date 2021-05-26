using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public decimal Cost { get; set; }
        public Product Product { get; set; }
        public Client Client { get; set; }
    }
}
