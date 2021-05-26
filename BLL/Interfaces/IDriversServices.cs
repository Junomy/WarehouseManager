using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDriversServices
    {
        Task<Driver> AddDriver(DriverRegisterDTO driverRegisterDTO);
        Task<Driver> UpdateDriver(DriverDTO DriverRegisterDTO);
        Task<Driver> DeleteDriver(int warehouseId);
        Task<Driver> GetDriver(DriverDTO DriverIdDTO);
        Task<Driver> ChangeName(DriverChangeNameDTO driverChangeNameDTO);
        Task<Driver> ChangeWage(DriverChangeWageDTO driverChangeNameDTO);
        Task<List<Driver>> GetDriversByWarehouse(WarehouseIdDTO warehouseIdDTO, int page);
        Task<int> Amount(int wId);
        void Dispose();
    }
}
