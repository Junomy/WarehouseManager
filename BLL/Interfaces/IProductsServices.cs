using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using DAL.Entities;
using System.Threading.Tasks;
namespace BLL.Interfaces
{
    public interface IProductsServices
    {
        Task<Product> AddProduct(ProductDTO ProductRegisterDTO);
        Task<Product> UpdateProduct(ProductDTO ProductRegisterDTO);
        Task<Product> DeleteProduct(int pId);
        Task<Product> GetProduct(int pId);
        Task<Provider> GetProvider(int pId);
        Task<IEnumerable<Product>> GetProducts();
        void Dispose();
    }
}
