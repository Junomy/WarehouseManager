using DAL.Entities;
using DAL.Interfaces.RepositoryInterfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;

namespace DAL.Repositories
{
    public class AdminsRepository : GenericRepository<Admin>, IAdminsRepository
    {
        public AdminsRepository(ApplicationContext context) : base(context) { }
        public async Task<Admin> DeleteAdmin(string id)
        {
            Admin admin = await entities.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (admin == null) throw new ArgumentException("entity is null");
            entities.Remove(admin);
            return admin;
        }
    }
}
