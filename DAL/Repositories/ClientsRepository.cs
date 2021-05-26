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
    public class ClientsRepository : GenericRepository<Client>, IClientsRepository
    {
        public ClientsRepository(ApplicationContext context) : base(context) { }
        /*
        private readonly string _connectionString;

        public ClientsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Client>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var response = new List<Client>();
                using (var reader = await sql.ExecuteReaderAsync("[GetClients]"))
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToValue(reader));
                    }
                }
                return response;
            }
        }

        private Client MapToValue(System.Data.Common.DbDataReader reader)
        {
            return new Client()
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Address = reader["Address"].ToString()
            };
        }

        public async Task<Client> GetById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                Client response = null;
                using (var reader = await sql.ExecuteReaderAsync("[GetClientsByIds] @Id = @Id", new { Id = Id }))
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToValue(reader);
                    }
                }
                return response;
            }
        }

        public async Task Insert(Client value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var proc = "[InsertClients]";
                var parameters = new
                {
                    Name = value.Name,
                    Address = value.Address
                };
                await sql.QueryAsync(proc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task DeleteById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var proc = "[DeleteClients]";
                var parameters = new { Id = Id };
                await sql.QueryAsync(proc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task UpdateById(int Id, Client value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var proc = "[UpdateClients]";
                var parameters = new
                {
                    Id = Id,
                    Name = value.Name,
                    Address = value.Address
                };
                await sql.QueryAsync(proc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        */
    }
}
