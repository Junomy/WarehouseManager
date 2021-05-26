using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Interfaces
{
    public interface IAdminsServices
    {
        Task<Admin> Register(AdminRegisterDTO  adminRegDTO);
        Task<Warehouse> AttachWarehouse(AdminWarehouseDTO adminRegisterDTO);
        Task<Admin> Login(AdminLoginDTO adminLoginDTO);
        Task<bool> Logout();
        Task<Warehouse> GetWarehouse(AdminLoginDTO loginDTO);
        Task<Admin> GetInfo(AdminLoginDTO loginDTO);
        Task<Admin> ChangeName(AdminChangeNameDTO adminChangeNameDTO);
        Task<Admin> ChangePassword(AdminChangePasswordDTO adminChangePasswordDTO);
        Task<Admin> DeleteAdmin(AdminLoginDTO adminLoginDTO);
        void Dispose();
    }
}
