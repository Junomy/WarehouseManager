using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces.RepositoryInterfaces
{
    public interface IWarehousesRepository : IGenericRepository<Warehouse>
    {
        Task<List<Driver>> GetDrivers(int warehouseId);
        Task<List<Product>> GetProducts(int warehouseId);
        Task<Warehouse> GetByAdminId(string Id);
    }
}
