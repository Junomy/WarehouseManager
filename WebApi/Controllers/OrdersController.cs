using DAL.Repositories;
using DAL.Interfaces;
using DAL.Entities;
using BLL.Interfaces;
using BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IUnitOfWork uow;
        private IOrdersServices services;

        public OrdersController(IUnitOfWork uow, IOrdersServices services)
        {
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet("{id}/info")]
        public async Task<Order> Get(int id)
            => await services.GetOrder(new OrderDTO { Id = id });

        [HttpGet("{wId}/{page}")]
        public async Task<IEnumerable<Order>> GetByWarehouse(int wId, int page)
            => await services.GetByWarehouse(wId, page);

        [HttpGet("{id}/clientinfo")]
        public async Task<Client> GetClient(int id)
            => await services.GetClientInfo(new OrderDTO { Id = id });

        [HttpGet("{id}/productinfo")]
        public async Task<Product> GetProduct(int id)
            => await services.GetProductInfo(new OrderDTO { Id = id });

        [HttpPost("add")]
        public async Task Post([FromBody] OrderDTO orderDTO)
            => Ok(await services.AddOrder(orderDTO));

        [HttpDelete("{id}/delete")]
        public async Task Delete(int id)
            => Ok(await services.DeleteOrder(new OrderDTO { Id = id }));
    }
}

