using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces.RepositoryInterfaces
{
    public interface IDriversRepository : IGenericRepository<Driver>
    {
        Task<List<Driver>> GetByWarehouseId(int warehouseId);
    }
}
