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
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(ApplicationContext context) : base(context) { }
        public async Task<List<Order>> GetClientOrders(int Id)
            => await entities.Where(o => o.ClientId == Id).ToListAsync();
        public async Task<List<Order>> GetByWarehouse(int Id)
            => await entities.Where(o => o.WarehouseId == Id).ToListAsync();
    }
}
