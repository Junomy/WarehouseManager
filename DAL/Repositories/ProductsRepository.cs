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
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(ApplicationContext context) : base(context) { }
        /*
        private readonly string _connectionString;

        public ProductsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Product>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var response = new List<Product>();
                using (var reader = await sql.ExecuteReaderAsync("[GetProducts]"))
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToValue(reader));
                    }
                }
                return response;
            }
        }

        private Product MapToValue(System.Data.Common.DbDataReader reader)
        {
            return new Product()
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Price = (decimal)reader["Price"],
                ProviderId = (int)reader["ProviderId"]
            };
        }

        public async Task<Product> GetById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                Product response = null;
                using (var reader = await sql.ExecuteReaderAsync("[GetProductsByIds] @Id = @Id", new { Id = Id }))
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToValue(reader);
                    }
                }
                return response;
            }
        }

        public async Task Insert(Product value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var proc = "[InsertProducts]";
                var parameters = new
                {
                    Name = value.Name,
                    Price = value.Price,
                    ProviderId = value.ProviderId
                };
                await sql.QueryAsync(proc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task DeleteById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var proc = "[DeleteProducts]";
                var parameters = new { Id = Id };
                await sql.QueryAsync(proc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task UpdateById(int Id, Product value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var proc = "[UpdateProducts]";
                var parameters = new
                {
                    Id = Id,
                    Name = value.Name,
                    Price = value.Price,
                    ProviderId = value.ProviderId
                };
                await sql.QueryAsync(proc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        */
    }
}
