using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClientsServices
    {
        Task<Client> AddClient(ClientDTO ClientRegisterDTO);
        Task<Client> UpdateClient(ClientDTO ClientDTO);
        Task DeleteClient(ClientDTO ClientIdDTO);
        Task<Client> GetClient(ClientDTO ClientIdDTO);
        Task<List<Order>> GetOrders(ClientDTO clientDTO);
        Task<IEnumerable<Client>> GetClients();
        void Dispose();
    }
}
