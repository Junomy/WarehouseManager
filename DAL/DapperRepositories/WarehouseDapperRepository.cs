using DAL.Entities;
using DAL.Interfaces.RepositoryInterfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DAL.Interfaces.AdoDapperInterfaces;
using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;

namespace DAL.DapperRepositories
{
    public class WarehouseDapperRepository : IWarehouseDapperRepository
    {
        private readonly string _connectionString;

        public WarehouseDapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<List<Warehouse>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var response = new List<Warehouse>();
                using (var reader = await sql.ExecuteReaderAsync("[GetWarehouses]"))
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToValue(reader));
                    }
                }
                return response;
            }
        }

        private Warehouse MapToValue(System.Data.Common.DbDataReader reader)
        {
            return new Warehouse()
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Address = reader["Address"].ToString(),
                AdminId = reader["AdminId"].ToString()
            };
        }

        public async Task<Warehouse> GetById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                Warehouse response = null;
                using (var reader = await sql.ExecuteReaderAsync("[GetWarehouseById] @Id = @Id", new { Id = Id }))
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToValue(reader);
                    }
                }
                return response;
            }
        }

        public async Task Insert(Warehouse value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var proc = "[InsertWarehouse]";
                var parameters = new
                {
                    Name = value.Name,
                    Address = value.Address,
                    AdminId = value.AdminId
                };
                await sql.QueryAsync(proc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task DeleteById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var proc = "[DeleteWarehouse]";
                var parameters = new { Id = Id };
                await sql.QueryAsync(proc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task UpdateById(int Id, Warehouse value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                var proc = "[UpdateWarehouse]";
                var parameters = new
                {
                    Id = Id,
                    Name = value.Name,
                    Address = value.Address
                };
                await sql.QueryAsync(proc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
