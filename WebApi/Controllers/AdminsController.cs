using DAL.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.RepositoryInterfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : Controller
    {
        private IUnitOfWork uow;
        private IAdminsServices services;

        public AdminsController(IUnitOfWork uow, IAdminsServices services)
        {
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Admin>> GetAll()
            => await uow.Admins.Get();

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
            => Ok(await services.GetInfo(new AdminLoginDTO { Id = id }));

        [HttpPost("register")]
        public async Task Register([FromBody] AdminRegisterDTO adminRegisterDTO)
            => Ok(await services.Register(adminRegisterDTO));

        [HttpPost("login")]
        public async Task<Admin> Login([FromBody] AdminLoginDTO loginDTO)
            => await services.Login(loginDTO);

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
            => Ok(await services.Logout());

        [HttpPut("{id}/changepassword")]
        public async Task UpdatePassword(string id) 
            => Ok(await services.ChangePassword(new AdminChangePasswordDTO { Id = id }));

        [HttpPut("{id}/changename")]
        public async Task UpdateName(string id)
            => Ok(await services.ChangeName(new AdminChangeNameDTO { Id = id }));

        [HttpDelete("{id}/delete")]
        public async Task Delete(string id)
            => Ok(await services.DeleteAdmin(new AdminLoginDTO { Id = id }));
    }
}

