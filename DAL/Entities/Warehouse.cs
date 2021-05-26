using System.Collections.Generic;

namespace DAL.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AdminId { get; set; }
        public Admin Admin { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Driver> Drivers { get; set; } = new List<Driver>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
