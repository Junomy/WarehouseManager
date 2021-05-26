using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces.RepositoryInterfaces
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        Task<List<Stock>> GetByProduct(int productId);
        Task<List<Stock>> GetByWarehouse(int warehouseId);
        Task<Stock> FindStock(int productId, int warehouseId);
    }
}
