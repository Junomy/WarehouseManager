using DAL.DapperRepositories;
using DAL.Interfaces.AdoDapperInterfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseDapperController : ControllerBase
    {
        private readonly IWarehouseDapperRepository _repository;
        public WarehouseDapperController(IWarehouseDapperRepository repository)
        {
            this._repository = repository ?? throw new ArgumentException(nameof(repository));
        }
        [HttpGet("get")]
        public async Task<List<Warehouse>> GetAll()
            => await _repository.GetAll();

        [HttpGet("get/{id}")]
        public async Task<Warehouse> GetById(int id)
            => await _repository.GetById(id);

        [HttpPost("add")]
        public async Task Post([FromBody] Warehouse warehouse)
            => await _repository.Insert(warehouse);

        [HttpPut("{id}/edit")]
        public async Task Put([FromBody] Warehouse warehouse, int id)
            => await _repository.UpdateById(id, warehouse);

        [HttpDelete("{id}/delete")]
        public async Task Delete(int id)
            => await _repository.DeleteById(id);
    }
}
