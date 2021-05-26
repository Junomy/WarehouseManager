using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using DAL.Interfaces.RepositoryInterfaces;
using DAL.Repositories;
using DAL.Interfaces.AdoDapperInterfaces;
using DAL.DapperRepositories;
using DAL.Interfaces;
using DAL.Entities; 
using BLL.Interfaces;
using BLL.Services;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IAdminsRepository, AdminsRepository>();
            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.AddTransient<IDriversRepository, DriversRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IProvidersRepository, ProvidersRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IWarehousesRepository, WarehousesRepository>();

            services.AddTransient<IWarehouseDapperRepository, WarehouseDapperRepository>();
            services.AddTransient<IWarehouseAdoRepository, WarehouseAdoRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IWarehousesServices, WarehousesServices>();
            services.AddTransient<IAdminsServices, AdminsServices>();
            services.AddTransient<IDriversServices, DriversServices>();
            services.AddTransient<IClientsServices, ClientsServices>();
            services.AddTransient<IProductsServices, ProductsServices>();
            services.AddTransient<IStockServices, StockServices>();
            services.AddTransient<IProvidersServices, ProvidersServices>();
            services.AddTransient<IOrdersServices, OrdersServices>();

            services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<Admin, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();
            services.AddControllers();

            services.AddSwaggerGen();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
                    c.RoutePrefix = String.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
