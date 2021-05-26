using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class ProviderViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Provider name too long(20 character limit).")]
        public string Name { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Provider address too long(30 character limit).")]
        public string Address { get; set; }
        public bool ProductsShow { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public int ProdAmount { get; set; }
        public int ProdPage { get; set; }
    }
}
