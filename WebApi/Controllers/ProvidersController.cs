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
    public class ProvidersController : ControllerBase
    {
        private IUnitOfWork uow;
        private IProvidersServices services;

        public ProvidersController(IUnitOfWork uow, IProvidersServices services)
        {
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet("{page}")]
        public async Task<IEnumerable<Provider>> GetAll(int page)
            => await services.GetProviders(page);

        [HttpGet("{pId}/info")]
        public async Task<Provider> Get(int pId)
            => await services.GetProvider(pId);

        [HttpGet("{id}/products/{page}")]
        public async Task<List<Product>> GetProducts(int id, int page)
            => await services.GetProducts(new ProviderDTO { Id = id }, page);

        [HttpPost("add")]
        public async Task Post([FromBody] ProviderDTO providerDTO)
            => Ok(await services.AddProvider(providerDTO));

        [HttpPut("{pId}/edit")]
        public async Task Put([FromBody] ProviderDTO providerDTO)
            => Ok(await services.UpdateProvider(providerDTO));

        [HttpDelete("{pId}/delete")]
        public async Task Delete([FromBody] ProviderDTO providerDTO)
            => Ok(await services.DeleteProvider(providerDTO));
    }
}

