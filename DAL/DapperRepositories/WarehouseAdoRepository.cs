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
    public class WarehouseAdoRepository : IWarehouseAdoRepository
    {
        private readonly string _connectionString;

        public WarehouseAdoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<List<Warehouse>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[GetWarehouses]", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Warehouse>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    return response;
                }
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
                using (SqlCommand cmd = new SqlCommand("[GetWarehouseById]", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    var response = new Warehouse();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }
                    }
                    return response;
                }
            }
        }

        public async Task Insert(Warehouse value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[InsertWarehouse]", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", value.Name));
                    cmd.Parameters.Add(new SqlParameter("@Address", value.Address));
                    cmd.Parameters.Add(new SqlParameter("@AdminId", value.AdminId));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task DeleteById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteWarehouse", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        public async Task UpdateById(int Id, Warehouse value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateWarehouse", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", value.Name));
                    cmd.Parameters.Add(new SqlParameter("@Address", value.Address));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
    }
}
