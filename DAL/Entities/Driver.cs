using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int Hours { get; set; }
        public decimal Wage { get; set; }
        public decimal Rating { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
