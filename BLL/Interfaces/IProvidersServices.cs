using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProvidersServices
    {
        Task<Provider> AddProvider(ProviderDTO providerRegisterDTO);
        Task<Provider> UpdateProvider(ProviderDTO providerRegisterDTO);
        Task<Provider> DeleteProvider(ProviderDTO providerIdDTO);
        Task<Provider> GetProvider(int pId);
        Task<List<Product>> GetProducts(ProviderDTO providerDTO, int page);
        Task<IEnumerable<Provider>> GetProviders(int page);
        Task<int> ProvAmount(int wId);
        Task<int> ProdAmount(int wId);
        void Dispose();
    }
}
