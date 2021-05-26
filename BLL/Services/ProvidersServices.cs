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
using BLL.Validators;

namespace BLL.Services
{
    public class ProvidersServices : IProvidersServices
    {
        private IUnitOfWork Database { get; set; }
        private readonly IConfiguration _configuration;
        private IMapper _mapper { get; set; }
        private ProvidersDTOValidator validator { get; set;}
        public ProvidersServices(IUnitOfWork uow, IConfiguration config)
        {
            Database = uow;
            _configuration = config;
            validator = new ProvidersDTOValidator();
        }

        public async Task<Provider> AddProvider(ProviderDTO providerRegisterDTO)
        {
            //_mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProviderDTO, Provider>()).CreateMapper();
            //if (providerRegisterDTO == null) return null;
            var result = await validator.ValidateAsync(providerRegisterDTO);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            Provider p = new Provider
            {
                Name = providerRegisterDTO.Name,
                Address = providerRegisterDTO.Address
            };
            await Database.Providers.Insert(p);
            await Database.Complete();
            return null;
        }

        public async Task<Provider> GetProvider(int pId)
        {
            return await Database.Providers.Get(pId);
        }

        public async Task<Provider> UpdateProvider(ProviderDTO providerRegisterDTO)
        {
            var result = await validator.ValidateAsync(providerRegisterDTO);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            Provider provider = await GetProvider(providerRegisterDTO.Id);
            provider.Name = providerRegisterDTO.Name;
            provider.Address = providerRegisterDTO.Address;
            await Database.Providers.Update(provider);
            await Database.Complete();
            return provider;
        }

        public async Task<Provider> DeleteProvider(ProviderDTO providerIdDTO)
        {
            if (providerIdDTO == null) return null;
            await Database.Providers.Delete(providerIdDTO.Id);
            await Database.Complete();
            return null;
        }

        public async Task<List<Product>> GetProducts(ProviderDTO providerDTO, int page)
        {
            var all = await Database.Providers.GetProducts(providerDTO.Id);
            if (page == 0)
            {
                return all;
            }
            else if (all.Count() / 5 >= page)
            {
                return all.Skip((page - 1) * 5).Take(5).ToList();
            }
            else
            {
                return all.Skip((page - 1) * 5).ToList();
            }
        }
        public async Task<int> ProvAmount(int wId)
        {
            var all = await Database.Drivers.GetByWarehouseId(wId);
            int amount = all.Count() / 10;
            return amount;
        }
        public async Task<int> ProdAmount(int pId)
        {
            var all = await Database.Providers.GetProducts(pId);
            int amount = all.Count() / 5;
            return amount;
        }
        public async Task<IEnumerable<Provider>> GetProviders(int page)
        {
            var all = await Database.Providers.Get();
            if (page == 0)
            {
                return all;
            }
            else if (all.Count() / 10 >= page)
            {
                return all.Skip((page - 1) * 10).Take(10).ToList();
            }
            else
            {
                return all.Skip((page - 1) * 10).ToList();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
