using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces.RepositoryInterfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminsRepository Admins { get; }
        IClientsRepository Clients { get; }
        IDriversRepository Drivers { get; }
        IOrdersRepository Orders { get; }
        IProductsRepository Products { get; }
        IProvidersRepository Providers { get; }
        IWarehousesRepository Warehouses { get; }
        IStockRepository Stock { get; }
        UserManager<Admin> UserManager { get; set; }
        SignInManager<Admin> SignInManager { get; set; }
        Task<int> Complete();
    }
}
