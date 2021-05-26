using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Blazor.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductAmount { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public decimal Cost { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
    }
}
