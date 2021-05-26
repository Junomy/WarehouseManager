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
    public class ClientsController : ControllerBase
    {
        private IUnitOfWork uow;
        private IClientsServices services;

        public ClientsController(IUnitOfWork uow, IClientsServices services)
        {
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.services = services ?? throw new ArgumentException(nameof(services));
        }
        [HttpGet("{id}/info")]
        public async Task<Client> Get(int id)
            => await services.GetClient(new ClientDTO { Id = id });

        [HttpGet("{id}/orders")]
        public async Task<IEnumerable<Order>> GetOrders(int id)
            => await services.GetOrders(new ClientDTO { Id = id });

        [HttpPost("add")]
        public async Task Post([FromBody] ClientDTO registerDTO)
            => Ok(await services.AddClient(registerDTO));

        [HttpPut("{id}/edit")]
        public async Task Put(int id)
            => Ok(await services.UpdateClient(new ClientDTO { Id = id }));

        [HttpDelete("{id}/delete")]
        public async Task Delete(int id) =>
            await services.DeleteClient(new ClientDTO { Id = id });
    }
}

