using DAL.Entities;
using DAL.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace DAL.Repositories
{
    public class ProvidersRepository: GenericRepository<Provider>, IProvidersRepository
    {
        public ProvidersRepository(ApplicationContext context) : base(context) { }
        public async Task<List<Product>> GetProducts(int Id)
        {
            return _context.Products.Where(p => p.ProviderId == Id).ToList();
        }
    }
}
