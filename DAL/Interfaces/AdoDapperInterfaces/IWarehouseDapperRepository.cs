using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces.AdoDapperInterfaces
{
    public interface IWarehouseDapperRepository
    {
        Task<List<Warehouse>> GetAll();
        Task<Warehouse> GetById(int Id);
        Task Insert(Warehouse value);
        Task DeleteById(int Id);
        Task UpdateById(int Id, Warehouse value);
    }
}
