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
using BLL.Validators;

namespace BLL.Services
{
    public class DriversServices : IDriversServices
    {
        private IUnitOfWork Database { get; set; }
        private readonly IConfiguration _configuration;
        private IMapper _mapper { get; set; }
        private const decimal minimalWage = 10;
        private DriverValidator validator { get; set; }

        public DriversServices(IUnitOfWork uow, IConfiguration config)
        {
            Database = uow;
            _configuration = config;
            validator = new DriverValidator();
        }

        public async Task<Driver> AddDriver(DriverRegisterDTO driverRegisterDTO)
        {
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<DriverRegisterDTO, Driver>()).CreateMapper();
            Driver driver = _mapper.Map<Driver>(driverRegisterDTO);
            var result = await validator.ValidateAsync(driver);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            await Database.Drivers.Insert(driver);
            await Database.Complete();
            return driver;
        }

        public async Task<Driver> GetDriver(DriverDTO DriverIdDTO)
        {
            return await Database.Drivers.Get(DriverIdDTO.Id);
        }

        public async Task<Driver> UpdateDriver(DriverDTO DriverRegisterDTO)
        {
            if (DriverRegisterDTO == null) return null;
            Driver Driver = GetDriver(DriverRegisterDTO).Result;
            Driver.Name = DriverRegisterDTO.Name;
            Driver.Surname = DriverRegisterDTO.Name;
            Driver.EmploymentDate = DriverRegisterDTO.EmploymentDate;
            Driver.Hours = DriverRegisterDTO.Hours;
            Driver.Wage = DriverRegisterDTO.Wage;
            Driver.Rating = DriverRegisterDTO.Rating;
            Driver.WarehouseId = DriverRegisterDTO.WarehouseId;

            var result = await validator.ValidateAsync(Driver);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            await Database.Drivers.Update(Driver);
            await Database.Complete();
            return Driver;
        }

        public async Task<Driver> DeleteDriver(int driverId)
        {
            Driver driver = await Database.Drivers.Get(driverId);
            await Database.Drivers.Delete(driver.Id);
            await Database.Complete();
            return driver;
        }

        private async Task<Driver> GetById(int Id)
        {
            return await Database.Drivers.Get(Id);
        }

        public async Task<Driver> ChangeName(DriverChangeNameDTO driverChangeNameDTO)
        {
            if (driverChangeNameDTO == null) return null;
            Driver driver = await GetById(driverChangeNameDTO.Id);
            var result = await validator.ValidateAsync(driver);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            driver.Name = driverChangeNameDTO.Name;
            driver.Surname = driverChangeNameDTO.Surname;
            await Database.Drivers.Update(driver);
            await Database.Complete();
            return driver;
        }

        private async Task<Driver> CalculateWage(DriverChangeWageDTO driverChangeWageDTO, int driverId, decimal minimalWage)
        {
            Driver driver = await GetById(driverId);
            driver.Rating = driverChangeWageDTO.Rating;
            driver.Hours = driverChangeWageDTO.Hours;
            driver.Wage = driver.Rating * minimalWage;
            return driver;
        }

        public async Task<Driver> ChangeWage(DriverChangeWageDTO driverChangeWageDTO)
        {
            if (driverChangeWageDTO == null) return null;
            Driver driver = await CalculateWage(driverChangeWageDTO, driverChangeWageDTO.Id, minimalWage);
            var result = await validator.ValidateAsync(driver);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            await Database.Drivers.Update(driver);
            await Database.Complete();
            return driver;
        }
        public async Task<List<Driver>> GetDriversByWarehouse(WarehouseIdDTO warehouseIdDTO, int page)
        {
            var all = await Database.Drivers.GetByWarehouseId(warehouseIdDTO.Id);
            if(page == 0)
            {
                return all;
            }
            else if(all.Count()/15 >= page)
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
            var all = await Database.Drivers.GetByWarehouseId(wId);
            int amount = all.Count() / 15;
            return amount;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
