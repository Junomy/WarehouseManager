using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Blazor.Models
{
    public class AccountInfoModel : PageModel
    {
        public string AdminId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int WarehouseId { get; set; }
        public string Token { get; set; }
        public AccountInfoModel()
        {
            Name = "NameTest";
            Surname = "SNameTest";
        }
    }
}
