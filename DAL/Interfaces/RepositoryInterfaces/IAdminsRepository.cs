using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces.RepositoryInterfaces
{
    public interface IAdminsRepository : IGenericRepository<Admin>
    {
        Task<Admin> DeleteAdmin(string id);
    }
}
