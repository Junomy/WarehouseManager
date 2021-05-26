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
using System.IdentityModel.Tokens.Jwt;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using BLL.JWT;


namespace BLL.Services
{
    public class AdminsServices : IAdminsServices
    {
        private IUnitOfWork Database { get; set; }
        private readonly IConfiguration _configuration;
        private IMapper _mapper { get; set; }
        private readonly JwtGenerator _generator = new JwtGenerator();

        public AdminsServices(IUnitOfWork uow, IConfiguration config)
        {
            Database = uow;
            _configuration = config;
        }

        public async Task<Admin> Register(AdminRegisterDTO adminRegDTO)
        {
            Admin admin = await Database.UserManager.FindByEmailAsync(adminRegDTO.Email);
            if(admin == null)
            {
                // _mapper = new MapperConfiguration(cfg => cfg.CreateMap<AdminRegisterDTO, Admin>()).CreateMapper();
                //admin = _mapper.Map<Admin>(adminRegDTO);
                admin = new Admin { 
                    Name = adminRegDTO.Name,
                    Surname = adminRegDTO.Surname,
                    Email = adminRegDTO.Email,
                    UserName = adminRegDTO.Name + adminRegDTO.Surname
                };
                var result = await Database.UserManager.CreateAsync(admin, adminRegDTO.Password);
                if (!result.Succeeded)
                {
                    string errors = string.Join("\n", result.Errors.Select(error => error.Description));
                    throw new ArgumentException(errors);
                }
                await Database.Complete();
                return admin;
            }
            await Database.Complete();
            return null;
        }
        
        public async Task<Admin> Login(AdminLoginDTO loginDTO)
        {
            //var result = await Database.SignInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, false, false);
            if (true)//result.Succeeded)
            {
                var admin = await Database.UserManager.FindByEmailAsync(loginDTO.Email);
                var response = new
                {
                    token = _generator.CreateToken(admin),
                    id = admin.Id
                };

                //return Newtonsoft.Json.JsonConvert.SerializeObject(response);
                return admin;
            }
            return null;
        }

        public async Task<bool> Logout()
        {
            await Database.SignInManager.SignOutAsync();
            return true;
        }

        public async Task<Warehouse> GetWarehouse(AdminLoginDTO loginDTO)
            => await Database.Warehouses.GetByAdminId(loginDTO.Id);

        public async Task<Admin> GetInfo(AdminLoginDTO loginDTO)
            => await Database.UserManager.FindByIdAsync(loginDTO.Id);

        public async Task<Warehouse> AttachWarehouse(AdminWarehouseDTO adminWarehouseDTO)
        {
            if (adminWarehouseDTO == null) return null;
            Warehouse warehouse = await Database.Warehouses.Get(adminWarehouseDTO.WarehouseId);
            //warehouse.AdminId = adminWarehouseDTO.AdminId;
            await Database.Warehouses.Update(warehouse);
            await Database.Complete();
            return warehouse;
        }

        public async Task<Admin> ChangeName(AdminChangeNameDTO adminChangeNameDTO)
        {
            Admin admin = await Database.UserManager.FindByIdAsync(adminChangeNameDTO.Id);
            admin.Name = adminChangeNameDTO.Name;
            admin.Surname = adminChangeNameDTO.Surname;
            admin.UserName = admin.Name + admin.Surname;
            await Database.Admins.Update(admin);
            await Database.Complete();
            return admin;
        }

        public async Task<Admin> ChangePassword(AdminChangePasswordDTO newPasswordDTO)
        {
            Admin admin = await Database.UserManager.FindByIdAsync(newPasswordDTO.Id);
            if(admin != null)
            {
                var result = await Database.UserManager.ChangePasswordAsync(admin, newPasswordDTO.OldPassword, newPasswordDTO.NewPassword);
                if (!result.Succeeded)
                {
                    string errors = string.Join("\n", result.Errors.Select(error => error.Description));
                    throw new ArgumentException(errors);
                }
            }

            //if (adminChangePasswordDTO == null) return null;
            //Admin admin = await GetByLogin(adminChangePasswordDTO.Login);
            //if (admin.Password == adminChangePasswordDTO.OldPassword)
            //{
            //    admin.Password = adminChangePasswordDTO.NewPassword;
            //    await Database.Admins.Update(admin);
            //}
            //Database.Complete();
            return admin;
        }

        public async Task<Admin> DeleteAdmin(AdminLoginDTO adminLoginDTO)
        {
            Admin admin = await Database.UserManager.FindByIdAsync(adminLoginDTO.Id);
            Warehouse warehouse = await Database.Warehouses.GetByAdminId(admin.Id);
            await Database.Admins.DeleteAdmin(adminLoginDTO.Id);
            await Database.Warehouses.Delete(warehouse.Id);
            await Database.Complete();
            return null;
        }
        
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
