using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IWarehousesServices
    {
        Task<IEnumerable<Warehouse>> GetWarehouses();
        Task<Warehouse> AddWarehouse(WarehouseRegisterDTO warehouseRegisterDTO);
        Task<Warehouse> UpdateWarehouse(Warehouse warehouse);
        Task<Warehouse> DeleteWarehouse(string adminId);
        Task<Warehouse> GetWarehouse(int wId);
        Task<Warehouse> GetByAdmin(string adminId);
        Task<Stock> AddProduct(StockDTO stockDTO);
        Task<Driver> AddDriver(DriverDTO driverDTO);
        Task<List<Driver>> GetDrivers(WarehouseIdDTO warehouseIdDTO);
        Task<List<Product>> GetProducts(WarehouseIdDTO warehouseIdDTO);
        void Dispose();
    }
}
