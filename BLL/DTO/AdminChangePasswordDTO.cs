using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class AdminChangePasswordDTO
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
