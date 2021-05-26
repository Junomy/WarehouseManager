using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStockServices
    {
        Task<List<Stock>> GetByWarehouse(int Id, int page);
        Task<List<Stock>> GetByProduct(int Id);
        Task<int> Amount(int wId);
        void Dispose();
    }
}
