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

namespace BLL.Interfaces
{
    public class WarehousesServices : IWarehousesServices
    {
        private IUnitOfWork Database { get; set; }
        private readonly IConfiguration _configuration;
        private IMapper _mapper { get; set; }
        public WarehousesServices(IUnitOfWork uow, IConfiguration config)
        {
            Database = uow;
            _configuration = config;
        }

        public async Task<IEnumerable<Warehouse>> GetWarehouses()
        {
            return await Database.Warehouses.Get();
        }

        public async Task<Warehouse> AddWarehouse(WarehouseRegisterDTO WarehouseRegisterDTO)
        {
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<WarehouseRegisterDTO, Warehouse>()).CreateMapper();
            if (WarehouseRegisterDTO == null) return null;
            await Database.Warehouses.Insert(_mapper.Map<Warehouse>(WarehouseRegisterDTO));
            await Database.Complete();
            return null;
        }

        public async Task<Warehouse> GetWarehouse(int Id)
        {
            return await Database.Warehouses.Get(Id);
        }

        public async Task<Warehouse> GetByAdmin(string adminId)
            => await Database.Warehouses.GetByAdminId(adminId);

        public async Task<Warehouse> UpdateWarehouse(Warehouse warehouse)
        {
            /*
            if (WarehouseIdDTO == null || WarehouseRegisterDTO == null) return null;
            Warehouse Warehouse = await GetWarehouse(WarehouseIdDTO);
            Warehouse.Name = WarehouseRegisterDTO.Name;
            Warehouse.Address = WarehouseRegisterDTO.Address;
            await Database.Warehouses.Update(Warehouse);
            Database.Complete();
            return Warehouse;
            */
            await Database.Warehouses.Update(warehouse);
            await Database.Complete();
            return warehouse;
        }

        public async Task<Warehouse> DeleteWarehouse(string adminId)
        {
            Warehouse warehouse = await Database.Warehouses.GetByAdminId(adminId);
            await Database.Warehouses.Delete(warehouse.Id);
            await Database.Complete();
            return warehouse;
        }

        public async Task<Stock> AddProduct(StockDTO stockDTO)
        {
            Stock stock = await Database.Stock.FindStock(stockDTO.ProductId, stockDTO.WarehouseId);
            if (stock != null)
            {
                stock.Amount += stockDTO.Amount;
                stock.WarehouseId = stockDTO.WarehouseId;
                if (stock.SellPrice != stockDTO.SellPrice)
                    stock.SellPrice = stockDTO.SellPrice;
                await Database.Stock.Update(stock);
            }
            else
            {
                stock = new Stock
                {
                    ProductId = stockDTO.ProductId,
                    WarehouseId = stockDTO.WarehouseId,
                    Amount = stockDTO.Amount,
                    SellPrice = stockDTO.SellPrice
                };
                await Database.Stock.Insert(stock);
            }
            await Database.Complete();
            return stock;
        }

        public async Task<Driver> AddDriver(DriverDTO driverDTO)
        {
            Driver driver = new Driver
            {
                Name = driverDTO.Name,
                Surname = driverDTO.Surname,
                EmploymentDate = driverDTO.EmploymentDate,
                Hours = driverDTO.Hours,
                Wage = driverDTO.Wage,
                Rating = driverDTO.Rating,
                WarehouseId = driverDTO.WarehouseId
            };
            await Database.Drivers.Insert(driver);
            await Database.Complete();
            return driver;
        }

        public async Task<List<Driver>> GetDrivers(WarehouseIdDTO warehouseIdDTO)
        {
            return await Database.Warehouses.GetDrivers(warehouseIdDTO.Id);
        }

        public async Task<List<Product>> GetProducts(WarehouseIdDTO warehouseId)
        {
            return await Database.Warehouses.GetProducts(warehouseId.Id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
