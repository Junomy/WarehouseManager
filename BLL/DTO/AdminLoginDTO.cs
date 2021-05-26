using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class AdminLoginDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; } 
    }
}
