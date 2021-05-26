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
    public class WarehousesRepository : GenericRepository<Warehouse>, IWarehousesRepository
    {
        public WarehousesRepository(ApplicationContext context) : base(context) { }
        public async Task<List<Driver>> GetDrivers(int warehouseId) =>
            await _context.Drivers.Where(d => d.WarehouseId == warehouseId).ToListAsync();
        public async Task<List<Product>> GetProducts(int warehouseId)
        {
            List<Stock> stock = await _context.Stocks.Where(s => s.WarehouseId == warehouseId).ToListAsync();
            List<Product> products = new List<Product>();
            foreach (Stock s in stock)
            {
                products.Add(_context.Products.Where(p => p.Id == s.ProductId).FirstOrDefault());
            }
            return products;
        }
        public async Task<Warehouse> GetByAdminId(string Id)
            => await _context.Warehouses.Where(w => w.AdminId == Id).FirstOrDefaultAsync();
    }
}
