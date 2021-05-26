using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;

namespace BLL.Services
{
    public class StockServices : IStockServices
    {
        private IUnitOfWork Database { get; set; }
        private readonly IConfiguration _configuration;
        private IMapper _mapper { get; set; }

        public StockServices(IUnitOfWork uow, IConfiguration config)
        {
            Database = uow;
            _configuration = config;
        }

        public async Task<List<Stock>> GetByWarehouse(int Id, int page)
        {
            var all = await Database.Stock.GetByWarehouse(Id);
            if (page == 0)
            {
                return all;
            }
            else if (all.Count() / 15 >= page)
            {
                return all.Skip((page - 1) * 15).Take(15).ToList();
            }
            else
            {
                return all.Skip((page - 1) * 15).ToList();
            }
        }
        public async Task<int> Amount(int wId)
        {
            var all = await Database.Stock.GetByWarehouse(wId);
            int amount = all.Count() / 15;
            return amount;
        }

        public async Task<List<Stock>> GetByProduct(int Id)
            => await Database.Stock.GetByProduct(Id);

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
