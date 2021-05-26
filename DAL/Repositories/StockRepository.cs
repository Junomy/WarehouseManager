using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace DAL.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationContext context) : base(context) { }
        public async Task<List<Stock>> GetByProduct(int productId)
            => await entities.Where(s => s.ProductId == productId).ToListAsync();
        public async Task<List<Stock>> GetByWarehouse(int warehouseId)
            => await entities.Where(s => s.WarehouseId == warehouseId).ToListAsync();
        public async Task<Stock> FindStock(int productId, int warehouseId)
            => await entities.Where(s => s.WarehouseId == warehouseId && s.ProductId == productId).FirstOrDefaultAsync();
    }
}
