using System;
using System.Collections.Generic;
using System.Text;
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
    public class ProductsServices : IProductsServices
    {
        private IUnitOfWork Database { get; set; }
        private readonly IConfiguration _configuration;
        private IMapper _mapper { get; set; }
        private ProductDTOValidator validator { get; set; }
        public ProductsServices(IUnitOfWork uow, IConfiguration config)
        {
            Database = uow;
            _configuration = config;
            validator = new ProductDTOValidator();
        }

        public async Task<Product> AddProduct(ProductDTO ProductRegisterDTO)
        {
            //_mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            //if (ProductRegisterDTO == null) return null;
            var result = await validator.ValidateAsync(ProductRegisterDTO);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            Product p = new Product
            {
                Name = ProductRegisterDTO.Name,
                Price = ProductRegisterDTO.Price,
                ProviderId = ProductRegisterDTO.ProviderId
            };
            await Database.Products.Insert(p);
            await Database.Complete();
            return p;
        }

        public async Task<Product> GetProduct(int pId)
        {
            return await Database.Products.Get(pId);
        }

        public async Task<Product> UpdateProduct(ProductDTO ProductRegisterDTO)
        {
            var result = await validator.ValidateAsync(ProductRegisterDTO);
            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString("~"));
            }
            Product Product = GetProduct(ProductRegisterDTO.Id).Result;
            Product.Name = ProductRegisterDTO.Name;
            Product.Price = ProductRegisterDTO.Price;
            await Database.Products.Update(Product);
            await Database.Complete();
            return Product;
        }

        public async Task<Product> DeleteProduct(int pId)
        {
            await Database.Products.Delete(pId);
            await Database.Complete();
            return null;
        }

        public async Task<Provider> GetProvider(int pId)
        {
            return await Database.Providers.Get(pId);
        }

        public async Task<IEnumerable<Product>> GetProducts()
            => await Database.Products.Get();

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
