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
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork uow;
        private IProductsServices services;

        public ProductsController(IUnitOfWork uow, IProductsServices services)
        {
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet("{pId}/info")]
        public async Task<Product> Get(int pId)
            => await services.GetProduct(pId);

        [HttpGet("{pId}/providerinfo")]
        public async Task<Provider> GetProvider(int pId)
            => await services.GetProvider(pId);

        [HttpPost("add")]
        public async Task Post([FromBody] ProductDTO productDTO)
            => Ok(await services.AddProduct(productDTO));

        [HttpPut("{pId}/edit")]
        public async Task Put([FromBody] ProductDTO productDTO)
            => Ok(await services.UpdateProduct(productDTO));

        [HttpDelete("{pId}/delete")]
        public async Task Delete(int pId)
            => Ok(await services.DeleteProduct(pId));
    }
}

