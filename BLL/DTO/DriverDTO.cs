using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DriverDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int Hours { get; set; }
        public decimal Wage { get; set; }
        public decimal Rating { get; set; }
        public int WarehouseId { get; set; }
    }
}
