using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;

namespace BLL.Services
{
    public class OrdersServices : IOrdersServices
    {
        private IUnitOfWork Database { get; set; }
        private readonly IConfiguration _configuration;
        private IMapper _mapper { get; set; }

        public OrdersServices(IUnitOfWork uow, IConfiguration config)
        {
            Database = uow;
            _configuration = config;
        }

        public async Task<Order> AddOrder(OrderDTO orderDTO)
        {
            //_mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            //if (orderDTO == null) return null;
            Order order = new Order
            {
                ClientId = orderDTO.ClientId,
                ProductId = orderDTO.ProductId,
                ProductAmount = orderDTO.ProductAmount,
                WarehouseId = orderDTO.WarehouseId,
                Cost = orderDTO.Cost
            };
            await Database.Orders.Insert(order);
            return order;
        }

        public async Task<Order> DeleteOrder(OrderDTO orderDTO)
        {
            if (orderDTO == null)
            {
                throw new ArgumentException("Order is null");
            }
            else
            {
                await Database.Orders.Delete(orderDTO.Id);
            }
            await Database.Complete();
            return null;
        }

        public async Task<Order> GetOrder(OrderDTO orderDTO)
        {
            return await Database.Orders.Get(orderDTO.Id);
        }

        public async Task<Client> GetClientInfo(OrderDTO orderDTO)
        {
            return await Database.Clients.Get(orderDTO.ClientId);
        }

        public async Task<Product> GetProductInfo(OrderDTO orderDTO)
        {
            return await Database.Products.Get(orderDTO.ProductId);
        }

        public async Task<List<Order>> GetByWarehouse(int warehouseId, int page)
        {
            var all = await Database.Orders.GetByWarehouse(warehouseId);
            if (page == 0)
            {
                return all;
            }
            else if (all.Count() / 15 >= page)
            {
                return all.Skip((page - 1) * 15).Take(15).ToList();
            }
            else
            {
                return all.Skip((page - 1) * 15).ToList();
            }
        }
        public async Task<int> Amount(int wId)
        {
            var all = await Database.Orders.GetByWarehouse(wId);
            int amount = all.Count() / 15;
            return amount;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
