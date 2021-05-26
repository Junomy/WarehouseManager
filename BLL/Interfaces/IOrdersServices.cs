using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IOrdersServices
    {
        Task<Order> AddOrder(OrderDTO orderDTO);
        Task<Order> DeleteOrder(OrderDTO orderDTO);
        Task<Order> GetOrder(OrderDTO orderDTO);
        Task<Client> GetClientInfo(OrderDTO orderDTO);
        Task<Product> GetProductInfo(OrderDTO orderDTO);
        Task<List<Order>> GetByWarehouse(int warehouseId, int page);
        Task<int> Amount(int wId);
        void Dispose();
    }
}
