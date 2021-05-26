using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces.RepositoryInterfaces
{
    public interface IProvidersRepository : IGenericRepository<Provider>
    {
        Task<List<Product>> GetProducts(int Id);
    }
}
