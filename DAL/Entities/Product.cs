using System.Collections.Generic;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public List<Order> Orders { get; set; }
        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
        public List<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
