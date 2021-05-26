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

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController
    {
        private IUnitOfWork uow;
        private IStockServices services;

        public StocksController(IUnitOfWork uow, IStockServices services)
        {
            this.uow = uow ?? throw new ArgumentException(nameof(uow));
            this.services = services ?? throw new ArgumentException(nameof(services));
        }

        [HttpGet("{wId}/{page}")]
        public async Task<IEnumerable<Stock>> Get(int wId, int page)
            => await services.GetByWarehouse(wId, page);
    }
}
