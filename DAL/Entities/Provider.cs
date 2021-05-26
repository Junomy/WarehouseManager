using System.Collections.Generic;

namespace DAL.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
