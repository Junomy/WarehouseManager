using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class ProductViewModel
    {
        [Required]
        [StringLength(16, ErrorMessage = "Name too long(16 character limit).")]
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Price must be >= 1")]
        public decimal Price { get; set; }
        [Required]
        public int ProviderId { get; set; }
    }
}
