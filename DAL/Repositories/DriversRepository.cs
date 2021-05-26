using DAL.Entities;
using DAL.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
namespace DAL.Repositories
{
    public class DriversRepository : GenericRepository<Driver>, IDriversRepository
    {
        public DriversRepository(ApplicationContext context) : base(context) { }
        public async Task<List<Driver>> GetByWarehouseId(int warehouseId)
            => await _context.Drivers.Where(d => d.WarehouseId == warehouseId).ToListAsync();
    }
}
