using DAL.Repositories;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private IUnitOfWork uow;
        private IWarehousesServices services;
        public WarehousesController(IUnitOfWork uow, IWarehousesServices services)
        {
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Warehouse>> Get() 
            => await services.GetWarehouses();

        [HttpGet("{wId}/info")]
        public async Task<Warehouse> Get(int wId)
            => await services.GetWarehouse(wId);
        [HttpGet("{aId}")]
        public async Task<Warehouse> GetByAdmin(string aId)
            => await services.GetByAdmin(aId);

        [HttpGet("{wId}/drivers")]
        public async Task<IEnumerable<Driver>> GetDrivers([FromBody] WarehouseIdDTO warehouseId)
            => await services.GetDrivers(warehouseId);

        [HttpGet("{wId}/products")]
        public async Task<IEnumerable<Product>> GetProducts([FromBody]WarehouseIdDTO productDTO)
            => await services.GetProducts(productDTO);

        [HttpPost("{aId}/add")]
        public async Task Post([FromBody] WarehouseRegisterDTO WarehouseRegisterDTO, string aId)
        {
            WarehouseRegisterDTO.AdminId = aId;
            Ok(await services.AddWarehouse(WarehouseRegisterDTO));
        } 

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct([FromBody] StockDTO stockDTO)
        {
            return Ok(await services.AddProduct(stockDTO));
        } 

        [HttpPut("{wId}/edit")]
        public async Task Put([FromBody]Warehouse warehouse)
            => Ok(await services.UpdateWarehouse(warehouse));

        // DELETE /Warehouses/5
        [HttpDelete("{aId}/delete")]
        public async Task Delete(string aId)
            => Ok(await services.DeleteWarehouse(aId));
    }
}

