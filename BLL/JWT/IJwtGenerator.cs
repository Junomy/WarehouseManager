using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BLL.JWT
{
    public interface IJwtGenerator
    {
        string CreateToken(Admin admin);
    }
}
