using Blazor.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Blazored.LocalStorage;
using BLL.Services;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Entities;
using BLL.JWT;
using Blazor.Components;

namespace Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IJwtGenerator, JwtGenerator>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IWarehousesServices, WarehousesServices>();
            services.AddTransient<IAdminsServices, AdminsServices>();
            services.AddTransient<IDriversServices, DriversServices>();
            services.AddTransient<IClientsServices, ClientsServices>();
            services.AddTransient<IProductsServices, ProductsServices>();
            services.AddTransient<IProvidersServices, ProvidersServices>();
            services.AddTransient<IOrdersServices, OrdersServices>();
            services.AddTransient<IStockServices, StockServices>();

            services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<Admin, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

            services.AddHttpClient<DriverView>();
            services.AddHttpClient<ProductView>();
            services.AddHttpClient<OrderView>();
            services.AddHttpClient<ProviderView>();
            services.AddHttpClient<SignIn>();
            services.AddHttpClient<WarehouseView>();
            services.AddHttpClient<AccountInfo>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateAudience = false,
                        ValidateIssuer = false,
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/SignIn");
            });
        }
    }
}
