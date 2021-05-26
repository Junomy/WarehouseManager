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
    public class ClientsServices : IClientsServices
    {
        private IUnitOfWork Database { get; set; }
        private readonly IConfiguration _configuration;
        private IMapper _mapper { get; set; }
        private ClientDTOValidator validator { get; set; }

        public ClientsServices(IUnitOfWork uow, IConfiguration config)
        {
            Database = uow;
            _configuration = config;
            validator = new ClientDTOValidator();
        }

        public async Task<Client> AddClient(ClientDTO clientRegisterDTO)
        {
            //_mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, Client>()).CreateMapper();
            var result = await validator.ValidateAsync(clientRegisterDTO);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            Client client = new Client
            {
                Name = clientRegisterDTO.Name,
                Address = clientRegisterDTO.Address
            };
            await Database.Clients.Insert(client);
            await Database.Complete();
            return client;
        }

        public async Task<Client> GetClient(ClientDTO ClientIdDTO)
        {
            return await Database.Clients.Get(ClientIdDTO.Id);
        }

        public async Task<Client> UpdateClient(ClientDTO clientDTO)
        {
            var result = await validator.ValidateAsync(clientDTO);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            Client client = GetClient(clientDTO).Result;
            client.Name = clientDTO.Name;
            client.Address = clientDTO.Address;
            await Database.Clients.Update(client);
            await Database.Complete();
            return client;
        }

        public async Task DeleteClient(ClientDTO clientIdDTO)
        {
            if (clientIdDTO == null)
            {
                throw new ArgumentException("Client is null");
            }
            else
            {
                await Database.Clients.Delete(clientIdDTO.Id);
            }
            await Database.Complete();
        }

        public async Task<List<Order>> GetOrders(ClientDTO clientDTO)
        {
            return await Database.Orders.GetClientOrders(clientDTO.Id);
        }

        public async Task<IEnumerable<Client>> GetClients()
            => await Database.Clients.Get();

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
