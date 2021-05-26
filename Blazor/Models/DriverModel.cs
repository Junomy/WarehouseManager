using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class DriverModel
    {
        [Required]
        [StringLength(16, ErrorMessage = "Name too long (16 character limit).")]
        public string Name { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Surname too long (16 character limit).")]
        public string Surname { get; set; }

        public DateTime EmploymentDate { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Working hours must be between 1 & 12")]
        public int Hours { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Wage must be >= 1 ")]
        public decimal Wage { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 & 5")]
        public decimal Rating { get; set; }

        public int WarehouseId { get; set; }
    }
}
