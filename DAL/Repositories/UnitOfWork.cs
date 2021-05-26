using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Interfaces.RepositoryInterfaces;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IAdminsRepository Admins { get; }
        public IClientsRepository Clients { get; }
        public IDriversRepository Drivers { get; }
        public IOrdersRepository Orders { get; }
        public IProductsRepository Products { get; }
        public IProvidersRepository Providers { get; }
        public IWarehousesRepository Warehouses { get; }
        public IStockRepository Stock { get; }
        public UserManager<Admin> UserManager { get; set; }
        public SignInManager<Admin> SignInManager { get; set; }
        public UnitOfWork(
                ApplicationContext context,
                UserManager<Admin> userManager,
                SignInManager<Admin> signInManager
            )
        {
            _context = context;
            Admins = new AdminsRepository(_context);
            Clients = new ClientsRepository(_context);
            Drivers = new DriversRepository(_context);
            Orders = new OrdersRepository(_context);
            Products = new ProductsRepository(_context);
            Providers = new ProvidersRepository(_context);
            Warehouses = new WarehousesRepository(_context);
            Stock = new StockRepository(_context);

            UserManager = userManager;
            SignInManager = signInManager;
        }

        public async Task<int> Complete()
            => await _context.SaveChangesAsync();
        public void Dispose()
            => _context.Dispose();
    }
}
