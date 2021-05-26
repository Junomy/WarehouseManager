using System.Collections.Generic;

namespace DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
