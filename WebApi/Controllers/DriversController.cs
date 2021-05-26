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
    public class DriversController : ControllerBase
    {
        private IUnitOfWork uow;
        private IDriversServices services;

        public DriversController(IUnitOfWork uow, IDriversServices services)
        {
            this.uow = uow ?? throw new ArgumentException(nameof(uow));
            this.services = services ?? throw new ArgumentException(nameof(services));
        }

        [HttpGet("{id}/driver-info")]
        public async Task<IActionResult> Get(int id)
            => Ok(await services.GetDriver(new DriverDTO { Id = id }));

        [HttpGet("{wId}/{page}")]
        public async Task<IEnumerable<Driver>> GetDrivers(int wId, int page)
            => await services.GetDriversByWarehouse(new WarehouseIdDTO { Id = wId }, page);

        [HttpPost("add")]
        public async Task Post([FromBody] DriverRegisterDTO driverDTO)
            => Ok(await services.AddDriver(driverDTO));

        [HttpPut("changename")]
        public async Task ChangeName([FromBody] DriverChangeNameDTO driverDTO)
            => Ok(await services.ChangeName(driverDTO));

        [HttpPut("changewage")]
        public async Task ChangeWage([FromBody] DriverChangeWageDTO driverDTO)
            => Ok(await services.ChangeWage(driverDTO));

        [HttpDelete("{id}/delete")]
        public async Task Delete(int id)
            => Ok(await services.DeleteDriver(id));
    }
}

