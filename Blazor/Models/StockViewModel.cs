using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class StockViewModel
    {
        [Required]
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public decimal BuyPrice { get; set; }
        [Required]
        public decimal SellPrice { get; set; }
        [Required]
        public int Amount { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderAddress { get; set; }
    }
}
