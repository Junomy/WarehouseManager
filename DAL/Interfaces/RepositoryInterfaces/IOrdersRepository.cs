using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces.RepositoryInterfaces
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetClientOrders(int Id);
        Task<List<Order>> GetByWarehouse(int Id);
    }
}
